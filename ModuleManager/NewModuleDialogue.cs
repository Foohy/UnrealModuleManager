using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleManager
{
    public partial class NewModuleDialogue : Form
    {
        public string ModuleName
        {
            get
            {
                return textModuleName.Text;
            }
        }

        public Generator.ModuleType Type
        {
            get
            {
                return (Generator.ModuleType)(comboModuleType.SelectedValue ?? Generator.ModuleType.Unknown);
            }
        }

        public Generator.ModuleLoadingPhase LoadPhase
        {
            get
            {
                return (Generator.ModuleLoadingPhase)(comboLoadingPhase.SelectedValue ?? Generator.ModuleLoadingPhase.Unknown); 
            }
        }

        public NewModuleDialogue( ref Generator.ModuleDefinition[] DataSource )
        {
            InitializeComponent();

            comboModuleType.DataSource = Enum.GetValues(typeof(Generator.ModuleType));
            comboLoadingPhase.DataSource = Enum.GetValues(typeof(Generator.ModuleLoadingPhase));

            foreach (Generator.ModuleDefinition module in DataSource)
            {
                textAddDependency.AutoCompleteCustomSource.Add(module.ModuleName);
            }
        }

        public string[] GetPrivateDependencies()
        {
            var privateOnly = from ListViewItem item in listAddedItems.Items
                              where !item.Checked
                              select item.SubItems[1].Text;
            return privateOnly.ToArray();
        }

        public string[] GetPublicDependencies()
        {
            var privateOnly = from ListViewItem item in listAddedItems.Items
                              where item.Checked
                              select item.SubItems[1].Text;
            return privateOnly.ToArray();
        }

        public string[] GetAdditionalDependencies()
        {
            return textAdditionalDependencies.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public bool ShouldWriteToProjectFile
        {
            get { return checkShouldEditUProject.Checked; }
        }

        private bool addDependency(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;

            ListViewItem item = listAddedItems.Items.Add("Private");
            item.SubItems.Add(Name);

            return true;
        }

        private bool removeSelectedDependency()
        {
            if (listAddedItems.SelectedItems.Count <= 0)
                return false;

            listAddedItems.SelectedItems[0].Remove();
            return true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void checkShouldEditUProject_CheckedChanged(object sender, EventArgs e)
        {
            groupUProjSettings.Enabled = checkShouldEditUProject.Checked;
        }

        private void btnAddDependency_Click(object sender, EventArgs e)
        {
            if (addDependency(textAddDependency.Text))
                textAddDependency.Text = "";
        }

        private void listAddedItems_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            e.Item.Text = e.Item.Checked ? "Public" : "Private";
        }

        private void textAddDependency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (addDependency(textAddDependency.Text))
                    textAddDependency.Text = "";
            }
        }

        private void contextItem_Opening(object sender, CancelEventArgs e)
        {
            if (listAddedItems.SelectedItems.Count <=0)
            {
                e.Cancel = true;
                return;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeSelectedDependency();
        }

        private void listAddedItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                removeSelectedDependency();
        }
    }
}
