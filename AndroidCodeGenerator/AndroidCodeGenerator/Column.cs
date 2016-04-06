using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidCodeGenerator
{
    public class Column
    {
        public bool IsPK { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public int Length { get; set; }
        public bool IsUnicode { get; set; }
        public string SQLiteDataType { get; set; }
        public string JavaDataType { get; set; }
        


        public Column(System.Data.IDataReader dr) {
            this.IsPK = dr["IsPK"].ToString() == "1";
            this.ColumnName = dr["COLUMN_NAME"].ToString();
            this.DataType = dr["DATA_TYPE"].ToString();
            this.Length = Convert.ToInt32(dr["CHARACTER_MAXIMUM_LENGTH"]);
            this.IsUnicode = dr["CHARACTER_SET_NAME"].ToString() == "UNICODE";


            this.SQLiteDataType = Column.GetSQLiteDataType(this.DataType);
            this.JavaDataType = Column.GetJavaDataType(this.DataType);
        }

        public string AsJavaPropertyDeclaration() {
            return string.Format("public {0} {1};", this.JavaDataType, this.ColumnName);
        }


        public string AsJavaParameter() {
            return string.Format("{0} {1}", this.JavaDataType, CamelCase(this.ColumnName, true));
        }

        public string AsConstructorAssignment() {
            var res = string.Format("this.{0} = {1};", this.ColumnName, CamelCase(this.ColumnName, true));
            return res;
        }


        public string AsParcelAssignment() {
            var txt = this.JavaDataType == "Boolean" ? "this.{0} = Boolean.valueOf(in.readString());" : "this.{0} = in.read{1}();";
            var res = string.Format(txt, this.ColumnName, CamelCase(this.JavaDataType));
            return res;
        }

        public string AsWriteToParcel() {
            var txt = this.JavaDataType == "Boolean" ? "dest.writeString(String.valueOf(this.{1}));" : "dest.write{0}(this.{1});";
            var res = string.Format(txt, CamelCase(this.JavaDataType), this.ColumnName);
            return res;
        }

        public string AsFromJSon() {
            var res = string.Format("res.{0} = jsonItem.get{1}(\"{0}\");", this.ColumnName, CamelCase(this.JavaDataType));
            res = res.Replace("jsonItem.getFloat(", "(float) jsonItem.getDouble(");
            return res;
        }

        public string AsFromCursor() {
            var txt = this.JavaDataType == "Boolean"
                ? "res.{0} = Boolean.valueOf(cursorItem.getString(cursorItem.getColumnIndex(\"{0}\")));"
                : "res.{0} = cursorItem.get{1}(cursorItem.getColumnIndex(\"{0}\"));";

            return string.Format(txt, this.ColumnName, CamelCase(this.JavaDataType));
        }


        public static string CamelCase(string text, Boolean toLower = false) {
            if (text.Length > 1)
                text = ((toLower == true) ? text[0].ToString().ToLower() : text[0].ToString().ToUpper()) + text.Substring(1);
            else
                text = (toLower == true) ? text.ToLower() : text.ToUpper();

            return text;
        }

        public static string GetSQLiteDataType(string dataType) {
            var res = "";
            switch (dataType) {
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                    res = "TEXT";
                    break;

                case "date":
                case "datetime":
                case "datetime2":
                case "datetimeoffset":
                    res = "TEXT";
                    break;

                case "bigint":
                case "int":
                    res = "INTEGER";
                    break;

                case "bit":
                case "decimal":
                    res = "NUMERIC";
                    break;

                case "money":
                case "real":
                case "float":
                    res = "REAL";
                    break;


                case "geography":
                case "geometry":
                case "hierarchyid":
                    res = "TEXT";
                    break;

                case "image":
                case "varbinary":
                    res = "TEXT"; //"BLOB";
                    break;


                default:
                    res = "INVALID_DATA_TYPE[" + dataType + "]";
                    break;
            }

            return res;
        }

        public static string GetJavaDataType(string dataType) {
            var res = "";
            switch (dataType) {
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                    res = "String";
                    break;

                case "date":
                case "datetime":
                case "datetime2":
                case "datetimeoffset":
                    res = "String";
                    break;

                case "int": res = "int"; break;

                case "decimal": 
                case "bigint": res = "long"; break;

                case "bit": res = "Boolean"; break;

                case "money":
                case "real":
                case "float": res = "float"; break;

                case "geography":
                case "geometry":
                case "hierarchyid":
                    res = "String";
                    break;

                case "image":
                case "varbinary":
                    res = "String";// "Blob";
                    break;

                    

                default:
                    res = "INVALID_DATA_TYPE[" + dataType + "]";
                    break;
            }

            return res;
        }

        public static string GetSelectCommandText(string databaseName, string tableName) {
            var cmdText = string.Format(Properties.Resources.GetColumns, databaseName, tableName);
            return cmdText;
        }
    }
}
