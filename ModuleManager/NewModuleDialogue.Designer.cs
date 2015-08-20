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
            this.components = new System.ComponentModel.Container();
            this.textModuleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupUProjSettings = new System.Windows.Forms.GroupBox();
            this.checkShouldEditUProject = new System.Windows.Forms.CheckBox();
            this.comboModuleType = new System.Windows.Forms.ComboBox();
            this.comboLoadingPhase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textAdditionalDependencies = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listAddedItems = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddDependency = new System.Windows.Forms.Button();
            this.textAddDependency = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupUProjSettings.SuspendLayout();
            this.contextItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // textModuleName
            // 
            this.textModuleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textModuleName.Location = new System.Drawing.Point(91, 6);
            this.textModuleName.Name = "textModuleName";
            this.textModuleName.Size = new System.Drawing.Size(299, 20);
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
            this.btnCreate.Location = new System.Drawing.Point(234, 11);
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
            this.btnCancel.Location = new System.Drawing.Point(315, 11);
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
            this.panel1.Location = new System.Drawing.Point(0, 422);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 46);
            this.panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textAddDependency);
            this.groupBox1.Controls.Add(this.btnAddDependency);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.listAddedItems);
            this.groupBox1.Location = new System.Drawing.Point(15, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 169);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dependencies (one per line)";
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
            this.groupUProjSettings.Location = new System.Drawing.Point(15, 230);
            this.groupUProjSettings.Name = "groupUProjSettings";
            this.groupUProjSettings.Size = new System.Drawing.Size(375, 186);
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
            this.checkShouldEditUProject.Location = new System.Drawing.Point(12, 207);
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
            this.comboModuleType.Location = new System.Drawing.Point(76, 31);
            this.comboModuleType.Name = "comboModuleType";
            this.comboModuleType.Size = new System.Drawing.Size(199, 21);
            this.comboModuleType.TabIndex = 1;
            // 
            // comboLoadingPhase
            // 
            this.comboLoadingPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLoadingPhase.FormattingEnabled = true;
            this.comboLoadingPhase.Location = new System.Drawing.Point(76, 71);
            this.comboLoadingPhase.Name = "comboLoadingPhase";
            this.comboLoadingPhase.Size = new System.Drawing.Size(199, 21);
            this.comboLoadingPhase.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Module Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 55);
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
            this.textAdditionalDependencies.Location = new System.Drawing.Point(76, 111);
            this.textAdditionalDependencies.Multiline = true;
            this.textAdditionalDependencies.Name = "textAdditionalDependencies";
            this.textAdditionalDependencies.Size = new System.Drawing.Size(293, 68);
            this.textAdditionalDependencies.TabIndex = 11;
            this.textAdditionalDependencies.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Additional Dependencies (one per line)";
            // 
            // listAddedItems
            // 
            this.listAddedItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listAddedItems.CheckBoxes = true;
            this.listAddedItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listAddedItems.ContextMenuStrip = this.contextItem;
            this.listAddedItems.FullRowSelect = true;
            this.listAddedItems.GridLines = true;
            this.listAddedItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listAddedItems.Location = new System.Drawing.Point(6, 19);
            this.listAddedItems.MultiSelect = false;
            this.listAddedItems.Name = "listAddedItems";
            this.listAddedItems.Size = new System.Drawing.Size(363, 115);
            this.listAddedItems.TabIndex = 13;
            this.listAddedItems.UseCompatibleStateImageBehavior = false;
            this.listAddedItems.View = System.Windows.Forms.View.Details;
            this.listAddedItems.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listAddedItems_ItemChecked);
            this.listAddedItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listAddedItems_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Dependency Module";
            // 
            // btnAddDependency
            // 
            this.btnAddDependency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDependency.Location = new System.Drawing.Point(294, 139);
            this.btnAddDependency.Name = "btnAddDependency";
            this.btnAddDependency.Size = new System.Drawing.Size(75, 23);
            this.btnAddDependency.TabIndex = 17;
            this.btnAddDependency.Text = "Add...";
            this.btnAddDependency.UseVisualStyleBackColor = true;
            this.btnAddDependency.Click += new System.EventHandler(this.btnAddDependency_Click);
            // 
            // textAddDependency
            // 
            this.textAddDependency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAddDependency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textAddDependency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textAddDependency.Location = new System.Drawing.Point(118, 140);
            this.textAddDependency.Name = "textAddDependency";
            this.textAddDependency.Size = new System.Drawing.Size(170, 20);
            this.textAddDependency.TabIndex = 18;
            this.textAddDependency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textAddDependency_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Public?";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 260;
            // 
            // contextItem
            // 
            this.contextItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextItem.Name = "contextItem";
            this.contextItem.Size = new System.Drawing.Size(108, 26);
            this.contextItem.Opening += new System.ComponentModel.CancelEventHandler(this.contextItem_Opening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // NewModuleDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(402, 468);
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
            this.groupBox1.PerformLayout();
            this.groupUProjSettings.ResumeLayout(false);
            this.groupUProjSettings.PerformLayout();
            this.contextItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textModuleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupUProjSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textAdditionalDependencies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboLoadingPhase;
        private System.Windows.Forms.ComboBox comboModuleType;
        private System.Windows.Forms.CheckBox checkShouldEditUProject;
        private System.Windows.Forms.Button btnAddDependency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listAddedItems;
        private System.Windows.Forms.TextBox textAddDependency;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}