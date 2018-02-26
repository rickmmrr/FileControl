using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileControl {


    public partial class Form1 : Form {

        FolderNode _parent = null;
        public Form1() {
            InitializeComponent();

            //Init the Theme Manager and assign it to the ListView
            //***************************************************************
            ThemeManager theme = null;
            if(radioButtonHouseHold.Checked)
                theme = new ThemeManager(ThemeManager.FileTheme.Family);
            else
                theme = new ThemeManager(ThemeManager.FileTheme.Business);
            listViewFiles.Tag = theme;
            //***************************************************************

        }
        /// <summary>
        /// Run When the form is created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load( object sender, EventArgs e ) {

            //rick 6-23-17 we are reworking this to look like 
            //windows exploror
            _parent = FolderNode.InitRootTree();
            treeViewFolders.Nodes.Add(_parent);

            //set the default search box captions
            textBoxSearchSS.Text = "Search Box";
            textBoxSearchSS.ForeColor = SystemColors.InactiveCaption;
            textBoxSearchFiles.Text = "Search Box";
            textBoxSearchFiles.ForeColor = SystemColors.InactiveCaption;


            // OLD NOT USING
            /*
            //read the drives and set the current one to the last one used
            // or the first one in the list that will
            // most likely be C:
            var driveInfo = DriveInfo.GetDrives();
            foreach(DriveInfo d in driveInfo) {
                comboBoxDrives.Items.Add(d.Name);
            }

            //check if the last saved is still in the list.
            bool found = false;
            foreach(string d in comboBoxDrives.Items) {
                if(Properties.Settings.Default.LastDrive == d) {
                    found = true;
                    comboBoxDrives.Text = d;
                    break;
                }
            }
            if(!found) {
                comboBoxDrives.Text = comboBoxDrives.Items[0].ToString();
            }
           
            
            //Populate the Folder Tree
            InitFolderTree(comboBoxDrives.Text);


            treeViewFolders.Nodes.Add(_parent);
            */



        }

        /// <summary>
        /// Run When the form is destroyed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed( object sender, FormClosedEventArgs e ) {

        }


        

        #region TreeView Event Handlers
        /// <summary>
        /// Only Fires when the Folder is selected 
        /// NOT when the folder is clicked or Not Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewFolders_AfterSelect( object sender, TreeViewEventArgs a ) {

            var folderNode = a.Node as FolderNode;

            if(folderNode.ThisFolderInfo == null)
                return;

            folderNode.AfterSelect(listViewDisplayFiles);
        }

        /// <summary>
        /// Fires when the Tree node is checked of unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="a"></param>
        private void treeViewFolders_AfterCheck( object sender, TreeViewEventArgs a ) {

            var folderNode = a.Node as FolderNode;

            if(folderNode.ThisFolderInfo == null)
                return;


            folderNode.AfterCheck(listViewFiles);

        }
        private void treeViewFolders_BeforeExpand( object sender, TreeViewCancelEventArgs e ) {

            FolderNode folderNode = e.Node as FolderNode;

            if(folderNode.ThisFolderInfo == null)
                return;


            folderNode.AddChildren();

        }
        private void comboBoxDrives_SelectedIndexChanged( object sender, EventArgs e ) {

           // var b = sender as ComboBox;
            //Populate the Folder Tree
           // InitFolderTree(b.Text);

           // treeViewFolders.Nodes.Add(_parent);

        }
        #endregion

        private void button1_Click( object sender, EventArgs e ) {




            MessageBox.Show("Done");

        }
        /// <summary>
        /// Convert Files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConvert_Click( object sender, EventArgs e ) {

            _parent.ConvertFiles(listViewFiles, textBoxEncrptionKey.Text);

            MessageBox.Show("Done");


        }
        /// <summary>
        /// Populate the SaveSet ListView when tab is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged( object sender, EventArgs e ) {

            const int LAUNCH_TAP_INDEX = 1;

            var swf = sender as System.Windows.Forms.TabControl;
            if(swf.SelectedIndex == LAUNCH_TAP_INDEX) {
                _parent.PopulateSaveSetListView(listViewCurrentEncrypSet, listViewEncrypSaveSets);
                Application.DoEvents();
            }
        }

        private void listViewEncrypSaveSets_SelectedIndexChanged( object sender, EventArgs e ) {

            var lv = sender as ListView;
            var indexCollection = lv.SelectedIndices;
            if(indexCollection.Count == 0)
                return;
            _parent.PopulateTheItemsFromSaveSetOnSelect(listViewCurrentEncrypSet, listViewEncrypSaveSets);
            Application.DoEvents();

        }

        private void buttonSearch_Click( object sender, EventArgs e ) {

            if(buttonSearchSS.Text.Equals("Close Search")) {
                buttonSearchSS.Text = "Search";
                _parent.PopulateSaveSetListView(listViewCurrentEncrypSet, listViewEncrypSaveSets);
                Application.DoEvents();
                return;

            }

            if(_parent.SearchSaveSets(textBoxSearchSS.Text, listViewEncrypSaveSets)) {

                buttonSearchSS.Text = "Close Search";
            }
            Application.DoEvents();
        }

        private void radioButtonHouseHold_CheckedChanged( object sender, EventArgs e ) {


        }

        private void button2_Click( object sender, EventArgs e ) {

        }

      private void buttonAddFileTypeAndLaunchInfo_Click( object sender, EventArgs e ) {

      }
   }
}
