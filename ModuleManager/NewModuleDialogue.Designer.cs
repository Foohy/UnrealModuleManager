namespace ModuleManager
{
    partial class NewModuleDialogue
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
            this.textModuleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textboxPublicDependencies = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textboxPrivateDependencies = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupUProjSettings = new System.Windows.Forms.GroupBox();
            this.checkShouldEditUProject = new System.Windows.Forms.CheckBox();
            this.comboModuleType = new System.Windows.Forms.ComboBox();
            this.comboLoadingPhase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textAdditionalDependencies = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupUProjSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // textModuleName
            // 
            this.textModuleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textModuleName.Location = new System.Drawing.Point(91, 6);
            this.textModuleName.Name = "textModuleName";
            this.textModuleName.Size = new System.Drawing.Size(328, 20);
            this.textModuleName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Module Name";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(263, 11);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(344, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 46);
            this.panel1.TabIndex = 7;
            // 
            // textboxPublicDependencies
            // 
            this.textboxPublicDependencies.AcceptsReturn = true;
            this.textboxPublicDependencies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxPublicDependencies.Location = new System.Drawing.Point(3, 23);
            this.textboxPublicDependencies.Multiline = true;
            this.textboxPublicDependencies.Name = "textboxPublicDependencies";
            this.textboxPublicDependencies.Size = new System.Drawing.Size(178, 123);
            this.textboxPublicDependencies.TabIndex = 8;
            this.textboxPublicDependencies.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Public";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Private";
            // 
            // textboxPrivateDependencies
            // 
            this.textboxPrivateDependencies.AcceptsReturn = true;
            this.textboxPrivateDependencies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxPrivateDependencies.Location = new System.Drawing.Point(3, 23);
            this.textboxPrivateDependencies.Multiline = true;
            this.textboxPrivateDependencies.Name = "textboxPrivateDependencies";
            this.textboxPrivateDependencies.Size = new System.Drawing.Size(198, 123);
            this.textboxPrivateDependencies.TabIndex = 10;
            this.textboxPrivateDependencies.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(15, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 174);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dependencies (one per line)";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(6, 19);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textboxPublicDependencies);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textboxPrivateDependencies);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(392, 149);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 12;
            // 
            // groupUProjSettings
            // 
            this.groupUProjSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupUProjSettings.Controls.Add(this.label6);
            this.groupUProjSettings.Controls.Add(this.textAdditionalDependencies);
            this.groupUProjSettings.Controls.Add(this.label5);
            this.groupUProjSettings.Controls.Add(this.label4);
            this.groupUProjSettings.Controls.Add(this.comboLoadingPhase);
            this.groupUProjSettings.Controls.Add(this.comboModuleType);
            this.groupUProjSettings.Location = new System.Drawing.Point(15, 235);
            this.groupUProjSettings.Name = "groupUProjSettings";
            this.groupUProjSettings.Size = new System.Drawing.Size(404, 186);
            this.groupUProjSettings.TabIndex = 13;
            this.groupUProjSettings.TabStop = false;
            this.groupUProjSettings.Text = "UProject Settings";
            // 
            // checkShouldEditUProject
            // 
            this.checkShouldEditUProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkShouldEditUProject.AutoSize = true;
            this.checkShouldEditUProject.Checked = true;
            this.checkShouldEditUProject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShouldEditUProject.Location = new System.Drawing.Point(12, 212);
            this.checkShouldEditUProject.Name = "checkShouldEditUProject";
            this.checkShouldEditUProject.Size = new System.Drawing.Size(101, 17);
            this.checkShouldEditUProject.TabIndex = 0;
            this.checkShouldEditUProject.Text = "Add to .uproject";
            this.checkShouldEditUProject.UseVisualStyleBackColor = true;
            this.checkShouldEditUProject.CheckedChanged += new System.EventHandler(this.checkShouldEditUProject_CheckedChanged);
            // 
            // comboModuleType
            // 
            this.comboModuleType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboModuleType.FormattingEnabled = true;
            this.comboModuleType.Location = new System.Drawing.Point(50, 32);
            this.comboModuleType.Name = "comboModuleType";
            this.comboModuleType.Size = new System.Drawing.Size(228, 21);
            this.comboModuleType.TabIndex = 1;
            // 
            // comboLoadingPhase
            // 
            this.comboLoadingPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLoadingPhase.FormattingEnabled = true;
            this.comboLoadingPhase.Location = new System.Drawing.Point(50, 72);
            this.comboLoadingPhase.Name = "comboLoadingPhase";
            this.comboLoadingPhase.Size = new System.Drawing.Size(228, 21);
            this.comboLoadingPhase.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Module Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Loading Phase";
            // 
            // textAdditionalDependencies
            // 
            this.textAdditionalDependencies.AcceptsReturn = true;
            this.textAdditionalDependencies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAdditionalDependencies.Location = new System.Drawing.Point(50, 112);
            this.textAdditionalDependencies.Multiline = true;
            this.textAdditionalDependencies.Name = "textAdditionalDependencies";
            this.textAdditionalDependencies.Size = new System.Drawing.Size(228, 68);
            this.textAdditionalDependencies.TabIndex = 11;
            this.textAdditionalDependencies.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Additional Dependencies (one per line)";
            // 
            // NewModuleDialogue
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(431, 473);
            this.Controls.Add(this.groupUProjSettings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textModuleName);
            this.Controls.Add(this.checkShouldEditUProject);
            this.Name = "NewModuleDialogue";
            this.Text = "Create a New Module";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupUProjSettings.ResumeLayout(false);
            this.groupUProjSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textModuleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textboxPublicDependencies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textboxPrivateDependencies;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupUProjSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textAdditionalDependencies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboLoadingPhase;
        private System.Windows.Forms.ComboBox comboModuleType;
        private System.Windows.Forms.CheckBox checkShouldEditUProject;
    }
}