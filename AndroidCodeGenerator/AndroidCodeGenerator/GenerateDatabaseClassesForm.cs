using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WizardingTools;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace AndroidCodeGenerator
{
    public partial class GenerateDatabaseClassesForm : WizardingTools.WizardFormSizable
    {
        public List<Table> TablesList { get; set; }
        public List<Table> ExportingTablesList { get; set; }
        public List<string> DatabasesList { get; set; }
        public string ServerName { get; set; }
        string LastDataPath;


        public GenerateDatabaseClassesForm()
            : base(Language.English) {
            InitializeComponent();

            this.LastDataPath = AppDomain.CurrentDomain.BaseDirectory + "lastData.tmp";
            this.TablesList = new List<Table>();
            this.DatabasesList = new List<string>();


        }

        #region Choose data

        private void ChooseDatabaseWizardPanel_OnValidatePanelData(WizardPanel currentPanel, ref bool isValid) {
            if (this.tablesCheckedListBox.CheckedItems.Count == 0) {
                MessageBox.Show("There is No table selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            this.ExportingTablesList = new List<Table>();
            foreach (var item in this.tablesCheckedListBox.CheckedItems) {
                var itemText = this.tablesCheckedListBox.GetItemText(item);
                this.ExportingTablesList.Add(this.TablesList.First(w => w.TableName == itemText));
            }
        }

        private void connectToServerButton_Click(object sender, EventArgs e) {
            this.ServerName = this.serverNameTextBox.Text;
            this.DatabasesList = this.GetDatabasesList(this.ServerName);
            this.databasesComboBox.DataSource = this.DatabasesList;
        }

        private void databasesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.TablesList = this.GetTables(this.ServerName, this.databasesComboBox.Text);
            this.tablesCheckedListBox.Items.Clear();
            foreach (var item in this.TablesList) {
                this.tablesCheckedListBox.Items.Add(item.TableName, CheckState.Unchecked);
            }
        }

        public List<Column> GetTableColumns(string serverName, string databaseName, string tableName) {
            var res = new List<Column>();
            string conString = string.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=true; Connect Timeout=5;", serverName, databaseName);

            using (SqlConnection con = new SqlConnection(conString)) {
                con.Open();

                var cmdText = Column.GetSelectCommandText(databaseName, tableName);
                using (SqlCommand cmd = new SqlCommand(cmdText, con)) {
                    using (IDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            res.Add(new Column(dr));
                        }
                    }
                }
            }

            return res;


        }

        public List<Table> GetTables(string serverName, string databaseName) {
            var res = new List<Table>();
            string conString = string.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=true; Connect Timeout=5;", serverName, databaseName);

            using (SqlConnection con = new SqlConnection(conString)) {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'U'", con)) {
                    using (IDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            var tmpTable = new Table(dr[0].ToString());
                            tmpTable.Columns = GetTableColumns(serverName, databaseName, tmpTable.TableName);
                            res.Add(tmpTable);
                        }
                    }
                }
            }

            return res;
        }

        public List<string> GetDatabasesList(string serverName) {
            var res = new List<string>();

            string conString = string.Format("server={0}; Integrated Security=true;Connect Timeout=5;", serverName);

            using (SqlConnection con = new SqlConnection(conString)) {
                var conss = new SqlConnectionStringBuilder();
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con)) {
                    using (IDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            res.Add(dr[0].ToString());
                        }
                    }
                }
            }

            return res;
        }

        #endregion

        #region Export

        private void setOutputPathButton_Click(object sender, EventArgs e) {
            var dlgFolder = new FolderBrowserDialog();

            dlgFolder.SelectedPath = this.outputPathTextBox.Text;
            if (dlgFolder.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            this.outputPathTextBox.Text = dlgFolder.SelectedPath;


        }

        public void generateClassesButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(this.androidDatabaseNameTextBox.Text)) {
                MessageBox.Show("Invalid database name!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.androidDatabaseNameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.javaPackageNameTextBox.Text)) {
                MessageBox.Show("Invalid package name!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.javaPackageNameTextBox.Focus();
                return;
            }

            if (Directory.Exists(this.outputPathTextBox.Text) == false) {
                Directory.CreateDirectory(this.outputPathTextBox.Text);
                //MessageBox.Show("Invalid output path!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.outputPathTextBox.Focus();
                //return;
            }

            var path = this.outputPathTextBox.Text;
            var srcIndex = path.Contains("\\app\\src\\main\\java\\") ? path.IndexOf("java") + 4 : path.IndexOf("src") + 3;
            var srcPath = (srcIndex < 0) ? path : path.Substring(0, srcIndex );
            var databaseNameAndroid = this.androidDatabaseNameTextBox.Text;
            var javaPackageName = this.javaPackageNameTextBox.Text;


            foreach (var item in this.ExportingTablesList) {
                var MainTypeClassContent = GetMainTypeClass(item, true, true, true, javaPackageName);
                var MainTypeClassFileName = string.Format("{0}\\{1}.java", path, item.TableName);
                File.WriteAllText(MainTypeClassFileName, MainTypeClassContent);

                var DataSourceContent = GetDataSourceClass(item, databaseNameAndroid, javaPackageName);
                var DataSourceClassFileName = string.Format("{0}\\{1}DataSource.java", path, item.TableName);
                File.WriteAllText(DataSourceClassFileName, DataSourceContent);

                var OpenHelperContent = GetOpenHelperClass(item, databaseNameAndroid, javaPackageName);
                var OpenHelperClassFileName = string.Format("{0}\\{1}OpenHelper.java", path, item.TableName);
                File.WriteAllText(OpenHelperClassFileName, OpenHelperContent);
            }

            if(this.generateBaseClassesCheckedBox.Checked) {
                // make the path if not exists
                var dataLibPath = string.Format("{0}\\ir\\royapajoohesh\\DataLib\\", srcPath);
                if (Directory.Exists(dataLibPath) == false) {
                    Directory.CreateDirectory(dataLibPath);
                }

                // generate TableBase class
                var tableBaseContent = Properties.Resources.TableBase;
                var tableBaseClassFileName = string.Format("{0}TableBase.java", dataLibPath);
                File.WriteAllText(tableBaseClassFileName, tableBaseContent);


                // generate Column class
                var columnContent = Properties.Resources.Column;
                var columnClassFileName = string.Format("{0}Column.java", dataLibPath);
                File.WriteAllText(columnClassFileName, columnContent);

            }


            if (this.generateUtilsCheckedBox.Checked) {
                var utilsPath = string.Format("{0}\\ir\\royapajoohesh\\utils\\", srcPath);
                if (Directory.Exists(utilsPath) == false) {
                    Directory.CreateDirectory(utilsPath);
                }

                // generate ActivityUtils class
                var ActivityUtilsContent = Properties.Resources.ActivityUtils;
                var ActivityUtilsClassFileName = string.Format("{0}ActivityUtils.java", utilsPath);
                File.WriteAllText(ActivityUtilsClassFileName, ActivityUtilsContent);

                // generate Orientations class
                var OrientationsContent = Properties.Resources.Orientations;
                var OrientationsClassFileName = string.Format("{0}Orientations.java", utilsPath);
                File.WriteAllText(OrientationsClassFileName, OrientationsContent);

                // generate FileDownloader class
                var FileDownloaderContent = Properties.Resources.FileDownloader;
                var FileDownloaderClassFileName = string.Format("{0}FileDownloader.java", utilsPath);
                File.WriteAllText(FileDownloaderClassFileName, FileDownloaderContent);

                // generate ImageDownloader class
                var ImageDownloaderContent = Properties.Resources.ImageDownloader;
                var ImageDownloaderClassFileName = string.Format("{0}ImageDownloader.java", utilsPath);
                File.WriteAllText(ImageDownloaderClassFileName, ImageDownloaderContent);

                // generate CurrentUser class
                var CurrentUserContent = Properties.Resources.CurrentUser;
                var CurrentUserClassFileName = string.Format("{0}CurrentUser.java", utilsPath);
                File.WriteAllText(CurrentUserClassFileName, CurrentUserContent);

                // generate KeyValuePair class
                var KeyValuePairContent = Properties.Resources.KeyValuePair;
                var KeyValuePairClassFileName = string.Format("{0}KeyValuePair.java", utilsPath);
                File.WriteAllText(KeyValuePairClassFileName, KeyValuePairContent);

            }


            if (this.loginActivityCheckBox.Checked) {
                // generate LOGIN activity classes 

                // add it to the Application.xml

            }

            if (this.registerActivityCheckBox.Checked) {
                // generate REGISTER activity classes 

                // add it to the Application.xml

            }


            try {
                var lastData = new string[] { outputPathTextBox.Text, this.androidDatabaseNameTextBox.Text, javaPackageNameTextBox.Text };
                File.WriteAllLines(LastDataPath, lastData);
            }
            catch (Exception ex) {
            }

            MessageBox.Show("Operation done!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("explorer.exe", path);
        }

        public string GetOpenHelperClass(Table table, string androidDatabaseName, string javaPackageName) {
            var res = Properties.Resources.OpenHelper;
            res = res.Replace("{PackageName}", javaPackageName);
            res = res.Replace("{TableName}", table.TableName);
            res = res.Replace("{DatabaseName}", androidDatabaseName);

            // add columns
            // this.{TableName}Table.AddColumn("{FieldName}", "{DataType}", false, false);
            var tmp = new List<string>();
            foreach (var item in table.Columns) {
                tmp.Add("this.{TableName}Table.AddColumn(\"{FieldName}\", \"{DataType}\", false, false);".Replace("{TableName}", table.TableName)
                                                                                                         .Replace("{FieldName}", item.ColumnName)
                                                                                                         .Replace("{DataType}", item.SQLiteDataType));
            }

            res = res.Replace("{AddColumns()}", string.Join("\n\t\t", tmp));

            return res;
        }

        public string GetDataSourceClass(Table table, string androidDatabaseName, string javaPackageName) {
            var res = Properties.Resources.DataSource;
            res = res.Replace("{PackageName}", javaPackageName);

            var tmpColNames = new List<string>();
            var tmpInsert = new List<string>();
            var tmpUpdate = new List<string>();

            tmpColNames.Add("\"1 as _id\"");    // for cursors 
            foreach (var item in table.Columns) {
                // add column names
                tmpColNames.Add("\"{FieldName}\"".Replace("{FieldName}", item.ColumnName));

                // insert function
                //  values.put("{FieldName}", new{TableName}Values.{FieldName});
                tmpInsert.Add("values.put(\"{FieldName}\", new{TableName}Values.{FieldName});".Replace("{FieldName}", item.ColumnName));

                // update function
                //  values.put("{FieldName}", new{TableName}Values.{FieldName});
                if (!item.IsPK) tmpUpdate.Add("values.put(\"{FieldName}\", new{TableName}Values.{FieldName});".Replace("{FieldName}", item.ColumnName));
            }
            
            // where clauses
            var pks = table.GetPrimaryKeyColumns();
            res = res.Replace("{WhereClausesCount}", pks.Count.ToString());

            var tmpWhereList = new List<string>();
            var tmpDeleteParamsList = new List<string>();
            for (int i = 0; i < pks.Count; i++) {
                var whereString = (pks[i].JavaDataType != "String")
                    ? "whereArgs[{whereArgItemIndex}] = String.valueOf(new{TableName}Values.{FieldName});"
                    : "whereArgs[{whereArgItemIndex}] = new{TableName}Values.{FieldName};";

                tmpWhereList.Add(whereString.Replace("{whereArgItemIndex}", i.ToString())
                                            .Replace("{FieldName}", pks[i].ColumnName));

                tmpDeleteParamsList.Add(string.Format("{0} {1}", pks[i].JavaDataType, pks[i].ColumnName));
            }

            res = res.Replace("{ColumnNames()}", string.Join(",\n\t\t", tmpColNames));
            res = res.Replace("{InsertParameterValues()}", string.Join("\n\t\t", tmpInsert));
            res = res.Replace("{UpdateParameterValues()}", string.Join("\n\t\t", tmpUpdate));
            

            res = res.Replace("{WhereArgsList()}", string.Join("\n\t\t", tmpWhereList));
            res = res.Replace("{DeleteWhereArgsList()}", string.Join("\n\t\t", tmpWhereList).Replace("new{TableName}Values.", ""));
            res = res.Replace("{DeleteParams()}", string.Join(", ", tmpDeleteParamsList));

            var tmpWhereClauseList = pks.Select(w => w.ColumnName + " = ?").ToList();
            res = res.Replace("{WhereClauseString}", string.Join(" and ", tmpWhereClauseList));
            
            res = res.Replace("{TableName}", table.TableName);
            res = res.Replace("{DatabaseName}", androidDatabaseName);

            var tmpPKsAsParameterValuesFromObjectVariableList = pks.Select(w=> string.Format("new{0}Values.{1}", table.TableName, w.ColumnName));
            res = res.Replace("{PKsAsParameterValuesFromObjectVariable}", string.Join(", ", tmpPKsAsParameterValuesFromObjectVariableList));

            return res;
        }

        public string GetMainTypeClass(Table table, bool ParcelableFunctions, bool FromJSon_Function, bool FromCursor_Function, string javaPackageName) {
            var res = Properties.Resources.ClassDef;
            res = res.Replace("{PackageName}", javaPackageName);

            var declarationsList = new List<string>();
            var columnNamesAsStringList = new List<string>();
            var constructorAssignmentList = new List<string>();
            var constructorParametersList = new List<string>();
            var parcelAssignmentList = new List<string>();
            var writeToParcelList = new List<string>();
            var parcelToStringList = new List<string>();
            var fromJSonList = new List<string>();
            var fromCursorList = new List<string>();
            var toStringList = new List<string>();

            foreach (var item in table.Columns) {
                // variable declarations
                declarationsList.Add(item.AsJavaPropertyDeclaration());

                // Column Names as string for strongly coding 
                columnNamesAsStringList.Add(string.Format("public static String Column_{0} = \"{0}\";", item.ColumnName));

                // Constructor parameters
                constructorParametersList.Add(item.AsJavaParameter());

                // Constructor assignments
                constructorAssignmentList.Add(item.AsConstructorAssignment());



                // Parcel assignments constructor
                parcelAssignmentList.Add(item.AsParcelAssignment());

                // Write to Parcel 
                writeToParcelList.Add(item.AsWriteToParcel());

                // ToString()
                if (item.IsPK)
                    parcelToStringList.Add(string.Format("\"{0}: \" + this.{0}", item.ColumnName));
            
                // FromJSon
                fromJSonList.Add(item.AsFromJSon());

                // FromCursor
                fromCursorList.Add(item.AsFromCursor()); 

                // toString()
                toStringList.Add(string.Format("\", {0}: \" + this.{0}", item.ColumnName));
            }


            res = res.Replace("{ConstructorParameters}", string.Join(", ", constructorParametersList));
            res = res.Replace("{ConstructorAssignments()}", string.Join("\n\t\t", constructorAssignmentList));            
            res = res.Replace("{PropertyDeclaration()}", string.Join("\n\t", declarationsList));
            res = res.Replace("{columnNamesAsStringList()}", string.Join("\n\t", columnNamesAsStringList));
            res = res.Replace("{ParcelAssignments()}", string.Join("\n\t\t", parcelAssignmentList));
            res = res.Replace("{WriteToParcel()}", string.Join("\n\t\t", writeToParcelList));
            res = res.Replace("{ParcelToString()}", string.Join(" + \"\\n\" + ", parcelToStringList).Replace("\" + \"", ""));
            res = res.Replace("{FromJSonAssignment()}", string.Join("\n\t\t", fromJSonList));
            res = res.Replace("{FromCursorAssignment()}", string.Join("\n\t\t", fromCursorList));
            res = res.Replace("{ToString()}", "\"" + string.Join(" + ", toStringList).Substring("\", ".Length));

            res = res.Replace("{TableName}", table.TableName);
            return res;
        }


        #endregion

        private void reverseSelectionButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < this.tablesCheckedListBox.Items.Count; i++) {
                this.tablesCheckedListBox.SetItemChecked(i, !this.tablesCheckedListBox.GetItemChecked(i));
            }
        }

        private void selectNoneButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < this.tablesCheckedListBox.Items.Count; i++) {
                this.tablesCheckedListBox.SetItemChecked(i, false);
            }
        }

        private void selectAllButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < this.tablesCheckedListBox.Items.Count; i++) {
                this.tablesCheckedListBox.SetItemChecked(i, true);
            }
        }

        private void GenerateDatabaseClassesForm_Load(object sender, EventArgs e) {
            try {

                if (File.Exists(LastDataPath)) {
                    var data = File.ReadAllLines(LastDataPath);
                    if (data.Length == 3) {
                        this.outputPathTextBox.Text = data[0];
                        this.androidDatabaseNameTextBox.Text = data[1];
                        this.javaPackageNameTextBox.Text = data[2];
                    }
                }
            }
            catch (Exception ex) {
            }

        }
    }
}
