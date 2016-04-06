namespace AndroidCodeGenerator
{
    partial class GenerateDatabaseClassesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChooseDatabaseWizardPanel = new WizardingTools.WizardPanel();
            this.reverseSelectionButton = new System.Windows.Forms.Button();
            this.selectNoneButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tablesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.databasesComboBox = new System.Windows.Forms.ComboBox();
            this.connectToServerButton = new System.Windows.Forms.Button();
            this.serverNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.generateCodeWizardPanel = new WizardingTools.WizardPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.generateBaseClassesCheckedBox = new System.Windows.Forms.CheckBox();
            this.generateUtilsCheckedBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loginActivityCheckBox = new System.Windows.Forms.CheckBox();
            this.registerActivityCheckBox = new System.Windows.Forms.CheckBox();
            this.setOutputPathButton = new System.Windows.Forms.Button();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.javaPackageNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.androidDatabaseNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.generateClassesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.placeHolderPanel.SuspendLayout();
            this.ChooseDatabaseWizardPanel.SuspendLayout();
            this.generateCodeWizardPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(657, 427);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(536, 427);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(631, 39);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Size = new System.Drawing.Size(598, 27);
            // 
            // placeHolderPanel
            // 
            this.placeHolderPanel.Controls.Add(this.generateCodeWizardPanel);
            this.placeHolderPanel.Controls.Add(this.ChooseDatabaseWizardPanel);
            this.placeHolderPanel.Size = new System.Drawing.Size(626, 347);
            // 
            // ChooseDatabaseWizardPanel
            // 
            this.ChooseDatabaseWizardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChooseDatabaseWizardPanel.Controls.Add(this.reverseSelectionButton);
            this.ChooseDatabaseWizardPanel.Controls.Add(this.selectNoneButton);
            this.ChooseDatabaseWizardPanel.Controls.Add(this.selectAllButton);
            this.ChooseDatabaseWizardPanel.Controls.Add(this.label3);
            this.ChooseDatabaseWizardPanel.Controls.Add(this.tablesCheckedListBox);
            this.ChooseDatabaseWizardPanel.Controls.Add(this.label2);
            this.ChooseDatabaseWizardPanel.Controls.Add(this.databasesComboBox);
            this.ChooseDatabaseWizardPanel.Controls.Add(this.connectToServerButton);
            this.ChooseDatabaseWizardPanel.Controls.Add(this.serverNameTextBox);
            this.ChooseDatabaseWizardPanel.Controls.Add(this.label1);
            this.ChooseDatabaseWizardPanel.Description = "Choose your database and its tables to export";
            this.ChooseDatabaseWizardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseDatabaseWizardPanel.Location = new System.Drawing.Point(0, 0);
            this.ChooseDatabaseWizardPanel.Name = "ChooseDatabaseWizardPanel";
            this.ChooseDatabaseWizardPanel.NextPanel = this.generateCodeWizardPanel;
            this.ChooseDatabaseWizardPanel.Padding = new System.Windows.Forms.Padding(10);
            this.ChooseDatabaseWizardPanel.PreviousePanel = null;
            this.ChooseDatabaseWizardPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChooseDatabaseWizardPanel.Size = new System.Drawing.Size(626, 347);
            this.ChooseDatabaseWizardPanel.TabIndex = 0;
            this.ChooseDatabaseWizardPanel.Title = "Select data";
            this.ChooseDatabaseWizardPanel.ValidationResult = false;
            this.ChooseDatabaseWizardPanel.OnValidatePanelData += new WizardingTools.PanelValidationEventHandler(this.ChooseDatabaseWizardPanel_OnValidatePanelData);
            // 
            // reverseSelectionButton
            // 
            this.reverseSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reverseSelectionButton.Location = new System.Drawing.Point(13, 308);
            this.reverseSelectionButton.Name = "reverseSelectionButton";
            this.reverseSelectionButton.Size = new System.Drawing.Size(70, 23);
            this.reverseSelectionButton.TabIndex = 9;
            this.reverseSelectionButton.Text = "Reverse";
            this.reverseSelectionButton.UseVisualStyleBackColor = true;
            this.reverseSelectionButton.Click += new System.EventHandler(this.reverseSelectionButton_Click);
            // 
            // selectNoneButton
            // 
            this.selectNoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectNoneButton.Location = new System.Drawing.Point(13, 279);
            this.selectNoneButton.Name = "selectNoneButton";
            this.selectNoneButton.Size = new System.Drawing.Size(70, 23);
            this.selectNoneButton.TabIndex = 8;
            this.selectNoneButton.Text = "None";
            this.selectNoneButton.UseVisualStyleBackColor = true;
            this.selectNoneButton.Click += new System.EventHandler(this.selectNoneButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAllButton.Location = new System.Drawing.Point(13, 250);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(70, 23);
            this.selectAllButton.TabIndex = 7;
            this.selectAllButton.Text = "All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Check tables to convert :";
            // 
            // tablesCheckedListBox
            // 
            this.tablesCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablesCheckedListBox.CheckOnClick = true;
            this.tablesCheckedListBox.FormattingEnabled = true;
            this.tablesCheckedListBox.Location = new System.Drawing.Point(89, 93);
            this.tablesCheckedListBox.Name = "tablesCheckedListBox";
            this.tablesCheckedListBox.Size = new System.Drawing.Size(522, 238);
            this.tablesCheckedListBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Database :";
            // 
            // databasesComboBox
            // 
            this.databasesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.databasesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databasesComboBox.FormattingEnabled = true;
            this.databasesComboBox.Location = new System.Drawing.Point(89, 42);
            this.databasesComboBox.Name = "databasesComboBox";
            this.databasesComboBox.Size = new System.Drawing.Size(522, 24);
            this.databasesComboBox.TabIndex = 3;
            this.databasesComboBox.SelectedIndexChanged += new System.EventHandler(this.databasesComboBox_SelectedIndexChanged);
            // 
            // connectToServerButton
            // 
            this.connectToServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectToServerButton.Location = new System.Drawing.Point(536, 11);
            this.connectToServerButton.Name = "connectToServerButton";
            this.connectToServerButton.Size = new System.Drawing.Size(75, 26);
            this.connectToServerButton.TabIndex = 2;
            this.connectToServerButton.Text = "Connect";
            this.connectToServerButton.UseVisualStyleBackColor = true;
            this.connectToServerButton.Click += new System.EventHandler(this.connectToServerButton_Click);
            // 
            // serverNameTextBox
            // 
            this.serverNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverNameTextBox.Location = new System.Drawing.Point(89, 13);
            this.serverNameTextBox.Name = "serverNameTextBox";
            this.serverNameTextBox.Size = new System.Drawing.Size(441, 23);
            this.serverNameTextBox.TabIndex = 1;
            this.serverNameTextBox.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server :";
            // 
            // generateCodeWizardPanel
            // 
            this.generateCodeWizardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.generateCodeWizardPanel.Controls.Add(this.groupBox2);
            this.generateCodeWizardPanel.Controls.Add(this.groupBox1);
            this.generateCodeWizardPanel.Controls.Add(this.setOutputPathButton);
            this.generateCodeWizardPanel.Controls.Add(this.outputPathTextBox);
            this.generateCodeWizardPanel.Controls.Add(this.label6);
            this.generateCodeWizardPanel.Controls.Add(this.javaPackageNameTextBox);
            this.generateCodeWizardPanel.Controls.Add(this.label5);
            this.generateCodeWizardPanel.Controls.Add(this.androidDatabaseNameTextBox);
            this.generateCodeWizardPanel.Controls.Add(this.label4);
            this.generateCodeWizardPanel.Controls.Add(this.generateClassesButton);
            this.generateCodeWizardPanel.Description = "Generate the code and enjoy it!";
            this.generateCodeWizardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateCodeWizardPanel.Location = new System.Drawing.Point(0, 0);
            this.generateCodeWizardPanel.Name = "generateCodeWizardPanel";
            this.generateCodeWizardPanel.NextPanel = null;
            this.generateCodeWizardPanel.Padding = new System.Windows.Forms.Padding(10);
            this.generateCodeWizardPanel.PreviousePanel = this.ChooseDatabaseWizardPanel;
            this.generateCodeWizardPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.generateCodeWizardPanel.Size = new System.Drawing.Size(626, 347);
            this.generateCodeWizardPanel.TabIndex = 1;
            this.generateCodeWizardPanel.Title = "Generate the code";
            this.generateCodeWizardPanel.ValidationResult = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.generateBaseClassesCheckedBox);
            this.groupBox2.Controls.Add(this.generateUtilsCheckedBox);
            this.groupBox2.Location = new System.Drawing.Point(171, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(199, 87);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Base classes";
            // 
            // generateBaseClassesCheckedBox
            // 
            this.generateBaseClassesCheckedBox.AutoSize = true;
            this.generateBaseClassesCheckedBox.Checked = true;
            this.generateBaseClassesCheckedBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.generateBaseClassesCheckedBox.Location = new System.Drawing.Point(21, 27);
            this.generateBaseClassesCheckedBox.Name = "generateBaseClassesCheckedBox";
            this.generateBaseClassesCheckedBox.Size = new System.Drawing.Size(155, 20);
            this.generateBaseClassesCheckedBox.TabIndex = 9;
            this.generateBaseClassesCheckedBox.Text = "Generate base classes";
            this.generateBaseClassesCheckedBox.UseVisualStyleBackColor = true;
            // 
            // generateUtilsCheckedBox
            // 
            this.generateUtilsCheckedBox.AutoSize = true;
            this.generateUtilsCheckedBox.Checked = true;
            this.generateUtilsCheckedBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.generateUtilsCheckedBox.Location = new System.Drawing.Point(21, 53);
            this.generateUtilsCheckedBox.Name = "generateUtilsCheckedBox";
            this.generateUtilsCheckedBox.Size = new System.Drawing.Size(107, 20);
            this.generateUtilsCheckedBox.TabIndex = 10;
            this.generateUtilsCheckedBox.Text = "Generate Utils";
            this.generateUtilsCheckedBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.loginActivityCheckBox);
            this.groupBox1.Controls.Add(this.registerActivityCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(376, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(199, 87);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forms";
            // 
            // loginActivityCheckBox
            // 
            this.loginActivityCheckBox.AutoSize = true;
            this.loginActivityCheckBox.Location = new System.Drawing.Point(21, 27);
            this.loginActivityCheckBox.Name = "loginActivityCheckBox";
            this.loginActivityCheckBox.Size = new System.Drawing.Size(101, 20);
            this.loginActivityCheckBox.TabIndex = 11;
            this.loginActivityCheckBox.Text = "Login Activity";
            this.loginActivityCheckBox.UseVisualStyleBackColor = true;
            // 
            // registerActivityCheckBox
            // 
            this.registerActivityCheckBox.AutoSize = true;
            this.registerActivityCheckBox.Location = new System.Drawing.Point(21, 53);
            this.registerActivityCheckBox.Name = "registerActivityCheckBox";
            this.registerActivityCheckBox.Size = new System.Drawing.Size(118, 20);
            this.registerActivityCheckBox.TabIndex = 12;
            this.registerActivityCheckBox.Text = "Register Activity";
            this.registerActivityCheckBox.UseVisualStyleBackColor = true;
            // 
            // setOutputPathButton
            // 
            this.setOutputPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setOutputPathButton.Location = new System.Drawing.Point(581, 11);
            this.setOutputPathButton.Name = "setOutputPathButton";
            this.setOutputPathButton.Size = new System.Drawing.Size(30, 26);
            this.setOutputPathButton.TabIndex = 8;
            this.setOutputPathButton.Text = "...";
            this.setOutputPathButton.UseVisualStyleBackColor = true;
            this.setOutputPathButton.Click += new System.EventHandler(this.setOutputPathButton_Click);
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputPathTextBox.Location = new System.Drawing.Point(71, 13);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(504, 23);
            this.outputPathTextBox.TabIndex = 7;
            this.outputPathTextBox.Text = "E:\\__Work\\AndroidCounter\\src\\ir\\royapajoohesh\\androidcounter\\data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Output :";
            // 
            // javaPackageNameTextBox
            // 
            this.javaPackageNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.javaPackageNameTextBox.Location = new System.Drawing.Point(171, 71);
            this.javaPackageNameTextBox.Name = "javaPackageNameTextBox";
            this.javaPackageNameTextBox.Size = new System.Drawing.Size(404, 23);
            this.javaPackageNameTextBox.TabIndex = 5;
            this.javaPackageNameTextBox.Text = "ir.royapajoohesh.androidcounter.data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Java Class Package Name :";
            // 
            // androidDatabaseNameTextBox
            // 
            this.androidDatabaseNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.androidDatabaseNameTextBox.Location = new System.Drawing.Point(171, 42);
            this.androidDatabaseNameTextBox.Name = "androidDatabaseNameTextBox";
            this.androidDatabaseNameTextBox.Size = new System.Drawing.Size(404, 23);
            this.androidDatabaseNameTextBox.TabIndex = 3;
            this.androidDatabaseNameTextBox.Text = "AndroidCounterData";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Android Database Name :";
            // 
            // generateClassesButton
            // 
            this.generateClassesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generateClassesButton.Location = new System.Drawing.Point(231, 259);
            this.generateClassesButton.Name = "generateClassesButton";
            this.generateClassesButton.Size = new System.Drawing.Size(163, 26);
            this.generateClassesButton.TabIndex = 1;
            this.generateClassesButton.Text = "Generate Classes";
            this.generateClassesButton.UseVisualStyleBackColor = true;
            this.generateClassesButton.Click += new System.EventHandler(this.generateClassesButton_Click);
            // 
            // GenerateDatabaseClassesForm
            // 
            this.ActivePanel = this.ChooseDatabaseWizardPanel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(784, 472);
            this.Name = "GenerateDatabaseClassesForm";
            this.Text = "Generate android code wizard";
            this.Load += new System.EventHandler(this.GenerateDatabaseClassesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.placeHolderPanel.ResumeLayout(false);
            this.ChooseDatabaseWizardPanel.ResumeLayout(false);
            this.ChooseDatabaseWizardPanel.PerformLayout();
            this.generateCodeWizardPanel.ResumeLayout(false);
            this.generateCodeWizardPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardingTools.WizardPanel ChooseDatabaseWizardPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverNameTextBox;
        private System.Windows.Forms.Button connectToServerButton;
        private System.Windows.Forms.ComboBox databasesComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox tablesCheckedListBox;
        private System.Windows.Forms.Label label3;
        private WizardingTools.WizardPanel generateCodeWizardPanel;
        private System.Windows.Forms.Button generateClassesButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox androidDatabaseNameTextBox;
        private System.Windows.Forms.TextBox javaPackageNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button setOutputPathButton;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button selectNoneButton;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button reverseSelectionButton;
        private System.Windows.Forms.CheckBox generateBaseClassesCheckedBox;
        private System.Windows.Forms.CheckBox generateUtilsCheckedBox;
        private System.Windows.Forms.CheckBox loginActivityCheckBox;
        private System.Windows.Forms.CheckBox registerActivityCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
