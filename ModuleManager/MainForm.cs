using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ModuleManager.Generator;

namespace ModuleManager
{
    public partial class MainForm : Form
    {
        ModuleGenerator LoadedProject;
        public MainForm()
        {
            InitializeComponent();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openProjectDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openProjectDialog.FileName;

                try
                {
                    ModuleGenerator newProj = new ModuleGenerator(fileName);
                    if (newProj != null)
                        OnProjectLoaded(newProj);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnProjectLoaded(ModuleGenerator newProject)
        {
            LoadedProject = newProject;
            SetEnabled(true);

            ModuleDefinition[] modules = newProject.GetProjectModules();
            foreach (ModuleDefinition def in modules)
            {
                ListViewItem item = listAllModules.Items.Add(def.ModuleName);
                item.Tag = def;
            }

            modules = newProject.GetEngineModules();
            foreach (ModuleDefinition def in modules)
            {
                ListViewItem item = listAllModules.Items.Add(def.ModuleName);
                item.Tag = def;
            }
        }

        private void SetEnabled( bool bIsEnabled )
        {
            moduleToolStripMenuItem.Enabled = bIsEnabled;
        }

        private void UpdateSelectionInfo( ModuleDefinition def )
        {
            labelModuleName.Text = def == null ? "None" : def.ModuleName;
            labelModulePath.Text = def == null ? "None" : def.FullModulePath;
            labelRealm.Text = def == null ? "Unknown" : (def.IsProjectModule ? "Project" : "Engine");
            labelModuleType.Text = def == null ? "Unknown" : (def.Type.ToString());
            labelModuleLoadingPhase.Text = def == null ? "Unknown" : (def.LoadingPhase.ToString());
            textAdditionalDependencies.Text = string.Join(Environment.NewLine, def.AdditionalDependencies);
        }

        private void moduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoadedProject == null) return;

            NewModuleDialogue dialog = new NewModuleDialogue();
            if ( dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                if (LoadedProject.QueryNewModuleExists(dialog.ModuleName))
                {
                    DialogResult res = MessageBox.Show(string.Format("A module named \"{0}\" already exists. Continue?", dialog.ModuleName), "Module Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (res == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                //Generate GO
                try
                {
                    LoadedProject.GenerateNewModule(dialog.ModuleName, dialog.GetPublicDependencies(), dialog.GetPrivateDependencies());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Generating Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listAllModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listAllModules.SelectedItems.Count <= 0) return;

            //Try getting the currently selected module definition
            ListViewItem SelectedItem = listAllModules.SelectedItems[0];
            ModuleDefinition selectedDef = SelectedItem.Tag as ModuleDefinition;

            //Update the side view info
            UpdateSelectionInfo(selectedDef);
        }
    }
}
