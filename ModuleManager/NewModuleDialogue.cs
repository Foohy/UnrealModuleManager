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

        public NewModuleDialogue()
        {
            InitializeComponent();

            comboModuleType.DataSource = Enum.GetValues(typeof(Generator.ModuleType));
            comboLoadingPhase.DataSource = Enum.GetValues(typeof(Generator.ModuleLoadingPhase));
        }

        public string[] GetPrivateDependencies()
        {
            return textboxPrivateDependencies.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries );
        }

        public string[] GetPublicDependencies()
        {
            return textboxPublicDependencies.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); 
        }

        public string[] GetAdditionalDependencies()
        {
            return textAdditionalDependencies.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public bool ShouldWriteToProjectFile
        {
            get { return checkShouldEditUProject.Checked; }
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
    }
}
