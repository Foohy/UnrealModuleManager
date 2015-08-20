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
        UnrealProject LoadedProject;
        public ModuleDefinition[] ModuleDataSource;

        public MainForm()
        {
            InitializeComponent();
        }

        private void onProjectLoaded(UnrealProject newProject)
        {
            LoadedProject = newProject;
            setEnabled(true);

            ModuleDataSource = newProject.GetProjectModules();
            ModuleDataSource = ModuleDataSource.Concat( newProject.GetEngineModules()).ToArray();

            listAllModules.Items.Clear();
            foreach (ModuleDefinition def in ModuleDataSource)
            {
                ListViewItem item = listAllModules.Items.Add(def.ModuleName);
                item.Tag = def;
            }
        }

        private void setEnabled( bool bIsEnabled )
        {
            moduleToolStripMenuItem.Enabled = bIsEnabled;
        }

        private void updateSelectionInfo( ModuleDefinition def )
        {
            labelModuleName.Text = def == null ? "None" : def.ModuleName;
            labelModulePath.Text = def == null ? "None" : def.FullModulePath;
            labelRealm.Text = def == null ? "Unknown" : (def.IsProjectModule ? "Project" : "Engine");
            labelModuleType.Text = def == null ? "Unknown" : (def.Type.ToString());
            labelModuleLoadingPhase.Text = def == null ? "Unknown" : (def.LoadingPhase.ToString());
            textAdditionalDependencies.Text = string.Join(Environment.NewLine, def.AdditionalDependencies);
        }

        private bool findSelectModule( string moduleName )
        {
            foreach (ListViewItem item in listAllModules.Items)
            {
                if (item.Text.Equals(moduleName, StringComparison.InvariantCultureIgnoreCase))
                {
                    listAllModules.Focus();
                    item.Selected = true;
                    return true;
                }
            }

            return false;
        }

        private void reloadModules( string DefaultSelectModuleName )
        {
            //Reload the project, refreshing the generator entirely
            UnrealProject newProj = new UnrealProject(LoadedProject.ProjectFile);
            if (newProj != null)
                onProjectLoaded(newProj);

            //Select the module we want
            findSelectModule(DefaultSelectModuleName);
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openProjectDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openProjectDialog.FileName;

                try
                {
                    UnrealProject newProj = new UnrealProject(fileName);
                    if (newProj != null)
                        onProjectLoaded(newProj);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void moduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoadedProject == null) return;

            NewModuleDialogue dialog = new NewModuleDialogue(ref ModuleDataSource);
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
                    UProjectModule settings = null;

                    if (dialog.ShouldWriteToProjectFile)
                    {
                        settings = new UProjectModule()
                        {
                            Name = dialog.ModuleName,
                            LoadingPhase = dialog.LoadPhase,
                            Type = dialog.Type,
                            AdditionalDependencies = dialog.GetAdditionalDependencies()
                        };
                    }

                    //Generate the new module with the provided settings
                    LoadedProject.GenerateNewModule(dialog.ModuleName, dialog.GetPublicDependencies(), dialog.GetPrivateDependencies(), settings);

                    //Reload and select the module with the matching name
                    reloadModules(dialog.ModuleName);

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
            updateSelectionInfo(selectedDef);
        }
    }
}
