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

        public NewModuleDialogue()
        {
            InitializeComponent();
        }

        public string[] GetPrivateDependencies()
        {
            return textboxPrivateDependencies.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries );
        }

        public string[] GetPublicDependencies()
        {
            return textboxPublicDependencies.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
