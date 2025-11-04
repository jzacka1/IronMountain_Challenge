namespace Iron_Mountain_Coding_Challenge
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.employeeIdTxtBox = new System.Windows.Forms.TextBox();
            this.employeeLable = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.firstNameTxtBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameTxtBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DobLabel = new System.Windows.Forms.Label();
            this.DobTxtBox = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.createTxtFileBtn = new System.Windows.Forms.Button();
            this.createXmlFileBtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textPromptPanel = new System.Windows.Forms.Panel();
            this.txtSrchPrmpt = new System.Windows.Forms.RichTextBox();
            this.textSearchPromptLabel = new System.Windows.Forms.Label();
            this.naturalLanguageSearchBtn = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.textPromptPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeIdTxtBox
            // 
            this.employeeIdTxtBox.Location = new System.Drawing.Point(144, 17);
            this.employeeIdTxtBox.MaxLength = 8;
            this.employeeIdTxtBox.Name = "employeeIdTxtBox";
            this.employeeIdTxtBox.Size = new System.Drawing.Size(296, 26);
            this.employeeIdTxtBox.TabIndex = 0;
            this.employeeIdTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.employeeIdTxtBox_KeyPress);
            // 
            // employeeLable
            // 
            this.employeeLable.AutoSize = true;
            this.employeeLable.Location = new System.Drawing.Point(23, 20);
            this.employeeLable.Name = "employeeLable";
            this.employeeLable.Size = new System.Drawing.Size(104, 20);
            this.employeeLable.TabIndex = 1;
            this.employeeLable.Text = "Employee ID:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.employeeLable);
            this.panel1.Controls.Add(this.employeeIdTxtBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 85);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.firstNameLabel);
            this.panel2.Controls.Add(this.firstNameTxtBox);
            this.panel2.Location = new System.Drawing.Point(12, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 85);
            this.panel2.TabIndex = 3;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(23, 20);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(90, 20);
            this.firstNameLabel.TabIndex = 1;
            this.firstNameLabel.Text = "First Name:";
            // 
            // firstNameTxtBox
            // 
            this.firstNameTxtBox.Location = new System.Drawing.Point(144, 17);
            this.firstNameTxtBox.MaxLength = 30;
            this.firstNameTxtBox.Name = "firstNameTxtBox";
            this.firstNameTxtBox.Size = new System.Drawing.Size(296, 26);
            this.firstNameTxtBox.TabIndex = 0;
            this.firstNameTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firstNameTxtBox_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lastNameLabel);
            this.panel3.Controls.Add(this.lastNameTxtBox);
            this.panel3.Location = new System.Drawing.Point(12, 238);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 85);
            this.panel3.TabIndex = 4;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(23, 20);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(90, 20);
            this.lastNameLabel.TabIndex = 1;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTxtBox
            // 
            this.lastNameTxtBox.Location = new System.Drawing.Point(144, 17);
            this.lastNameTxtBox.MaxLength = 30;
            this.lastNameTxtBox.Name = "lastNameTxtBox";
            this.lastNameTxtBox.Size = new System.Drawing.Size(296, 26);
            this.lastNameTxtBox.TabIndex = 0;
            this.lastNameTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lastNameTxtBox_KeyPress);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DobLabel);
            this.panel4.Controls.Add(this.DobTxtBox);
            this.panel4.Location = new System.Drawing.Point(12, 351);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(462, 85);
            this.panel4.TabIndex = 5;
            this.panel4.Leave += new System.EventHandler(this.DobTxtBox_Leave);
            // 
            // DobLabel
            // 
            this.DobLabel.AutoSize = true;
            this.DobLabel.Location = new System.Drawing.Point(23, 20);
            this.DobLabel.Name = "DobLabel";
            this.DobLabel.Size = new System.Drawing.Size(103, 20);
            this.DobLabel.TabIndex = 1;
            this.DobLabel.Text = "Date of Birth:";
            // 
            // DobTxtBox
            // 
            this.DobTxtBox.Location = new System.Drawing.Point(144, 14);
            this.DobTxtBox.MaxLength = 8;
            this.DobTxtBox.Name = "DobTxtBox";
            this.DobTxtBox.Size = new System.Drawing.Size(296, 26);
            this.DobTxtBox.TabIndex = 0;
            this.DobTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DobTxtBox_KeyPress);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(684, 12);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(189, 60);
            this.submitBtn.TabIndex = 6;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // createTxtFileBtn
            // 
            this.createTxtFileBtn.Location = new System.Drawing.Point(684, 78);
            this.createTxtFileBtn.Name = "createTxtFileBtn";
            this.createTxtFileBtn.Size = new System.Drawing.Size(189, 60);
            this.createTxtFileBtn.TabIndex = 7;
            this.createTxtFileBtn.Text = "Create Text File";
            this.createTxtFileBtn.UseVisualStyleBackColor = true;
            this.createTxtFileBtn.Click += new System.EventHandler(this.createTxtFileBtn_Click);
            // 
            // createXmlFileBtn
            // 
            this.createXmlFileBtn.Location = new System.Drawing.Point(684, 144);
            this.createXmlFileBtn.Name = "createXmlFileBtn";
            this.createXmlFileBtn.Size = new System.Drawing.Size(189, 60);
            this.createXmlFileBtn.TabIndex = 8;
            this.createXmlFileBtn.Text = "Create XML File";
            this.createXmlFileBtn.UseVisualStyleBackColor = true;
            this.createXmlFileBtn.Click += new System.EventHandler(this.createXmlFileBtn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // textPromptPanel
            // 
            this.textPromptPanel.Controls.Add(this.naturalLanguageSearchBtn);
            this.textPromptPanel.Controls.Add(this.textSearchPromptLabel);
            this.textPromptPanel.Controls.Add(this.txtSrchPrmpt);
            this.textPromptPanel.Location = new System.Drawing.Point(519, 238);
            this.textPromptPanel.Name = "textPromptPanel";
            this.textPromptPanel.Size = new System.Drawing.Size(354, 198);
            this.textPromptPanel.TabIndex = 9;
            // 
            // txtSrchPrmpt
            // 
            this.txtSrchPrmpt.Location = new System.Drawing.Point(27, 39);
            this.txtSrchPrmpt.Name = "txtSrchPrmpt";
            this.txtSrchPrmpt.Size = new System.Drawing.Size(324, 96);
            this.txtSrchPrmpt.TabIndex = 0;
            this.txtSrchPrmpt.Text = "";
            // 
            // textSearchPromptLabel
            // 
            this.textSearchPromptLabel.AutoSize = true;
            this.textSearchPromptLabel.Location = new System.Drawing.Point(27, 14);
            this.textSearchPromptLabel.Name = "textSearchPromptLabel";
            this.textSearchPromptLabel.Size = new System.Drawing.Size(149, 20);
            this.textSearchPromptLabel.TabIndex = 1;
            this.textSearchPromptLabel.Text = "Text Search Prompt";
            // 
            // naturalLanguageSearchBtn
            // 
            this.naturalLanguageSearchBtn.Location = new System.Drawing.Point(162, 136);
            this.naturalLanguageSearchBtn.Name = "naturalLanguageSearchBtn";
            this.naturalLanguageSearchBtn.Size = new System.Drawing.Size(189, 59);
            this.naturalLanguageSearchBtn.TabIndex = 2;
            this.naturalLanguageSearchBtn.Text = "Search";
            this.naturalLanguageSearchBtn.UseVisualStyleBackColor = true;
            this.naturalLanguageSearchBtn.Click += new System.EventHandler(this.naturalLanguageSearchBtn_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(12, 466);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 62;
            this.dgvResults.RowTemplate.Height = 28;
            this.dgvResults.Size = new System.Drawing.Size(861, 223);
            this.dgvResults.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 837);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.textPromptPanel);
            this.Controls.Add(this.createXmlFileBtn);
            this.Controls.Add(this.createTxtFileBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(919, 506);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.textPromptPanel.ResumeLayout(false);
            this.textPromptPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox employeeIdTxtBox;
        private System.Windows.Forms.Label employeeLable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstNameTxtBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTxtBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label DobLabel;
        private System.Windows.Forms.TextBox DobTxtBox;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button createTxtFileBtn;
        private System.Windows.Forms.Button createXmlFileBtn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel textPromptPanel;
        private System.Windows.Forms.RichTextBox txtSrchPrmpt;
        private System.Windows.Forms.Label textSearchPromptLabel;
        private System.Windows.Forms.Button naturalLanguageSearchBtn;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}

