using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileControl {
    class FolderNode : TreeNode {

        public bool HasFiles = false;
        public System.IO.DirectoryInfo ThisFolderInfo = null;
        private static Dictionary<string, FolderNode> _alreadyProcessedList = new Dictionary<string, FolderNode>();


        public FolderNode(string title, System.IO.DirectoryInfo info = null ) :base(title){

            ThisFolderInfo = info;
            //added 6-23-17
            if(info != null)
                _alreadyProcessedList.Add(ThisFolderInfo.FullName,this);
           

        }
        /// <summary>
        /// Add the Folders to the parent
        /// Check for Files as well
        /// </summary>
        /// <param name="folders"></param>
        public void AddChildren() {

            if(ThisFolderInfo == null)
                return;


            System.IO.DirectoryInfo[] subDirs = null;
         // Now find all the subdirectories under this directory.

         try {

            subDirs = ThisFolderInfo.GetDirectories();
         }
         catch(System.UnauthorizedAccessException e) {
            Debug.WriteLine(e.Message);

         }
         catch(System.IO.PathTooLongException e) {
            Debug.WriteLine(e.Message);
         }
         catch(IOException io) {

            Debug.WriteLine("IOException " + io.Message);
         }


                if(subDirs != null) {


                    foreach(System.IO.DirectoryInfo f in subDirs) {
                    FolderNode n = null;
                    bool NewNode = false;
                    if(_alreadyProcessedList.ContainsKey(f.FullName))
                        n = _alreadyProcessedList[f.FullName];
                    else {
                        n = new FolderNode(f.Name, f);
                        NewNode = true;
                    }


                        bool remove = false;
                        n.AddSecondLevelChildren(out remove);

                        if(!remove && NewNode) {
                            this.Nodes.Add(n);
                        }

                    
                    }


                }

            
        }
        private void AddSecondLevelChildren( out bool remove ) {
            System.IO.DirectoryInfo[] subDirs = null;
            // Now find all the subdirectories under this directory.
            remove = false;


            //change this when you can
            if(this.Text == "$Recycle.Bin") {
                remove = true;
                return;
            }




            try {

                subDirs = ThisFolderInfo.GetDirectories();
            }
            catch(System.UnauthorizedAccessException e) {
                Debug.WriteLine(e.Message);
                remove = true;
                return;


            }
            catch(System.IO.PathTooLongException e) {
                Debug.WriteLine(e.Message);
            }

            #region Now Check For Files
            //now check for files
            System.IO.FileInfo[] files = null;

            // First, process all the files directly under this folder
            try {
                files = ThisFolderInfo.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch(UnauthorizedAccessException e) {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                Debug.WriteLine(e.Message);
                remove = true;
                return;
            }

            catch(System.IO.DirectoryNotFoundException e) {
                Debug.WriteLine(e.Message);
            }
            catch(System.IO.PathTooLongException e) {
                Debug.WriteLine(e.Message);
                remove = true;
                return;
            }
            #endregion

            //Remove any files that are hidden
            List<FileInfo> tempList = new List<FileInfo>();
            foreach(FileInfo fi in files) {
                if((fi.Attributes & FileAttributes.Hidden) == 0)
                    tempList.Add(fi);
            }
            

            //if the folder has NO sub-folders and no Files
            // remove it
            if((files == null || files.Length == 0) && (subDirs == null || subDirs.Length == 0)) {
                remove = true;
                return;
            }




            
            if(subDirs != null) {

                foreach(System.IO.DirectoryInfo f in subDirs) {

                    FolderNode n = null;
                    if(_alreadyProcessedList.ContainsKey(f.FullName))
                        n = _alreadyProcessedList[f.FullName];
                    else {
                        n = new FolderNode(f.Name, f);
                        this.Nodes.Add(n);
                    }
                }
                
            }
        



    }
    /// <summary>
    /// Fired when the user checks or unchecks the folder node
    /// </summary>
    /// <param name="listViewFiles">ListView control that displays the files</param>
    public void AfterCheck(ListView listViewFiles ) {

            if(ThisFolderInfo == null)
                return;

            System.IO.FileInfo[] files = null;

            if(Checked == true) {


                

                // First, process all the files directly under this folder
                try {
                    files = ThisFolderInfo.GetFiles("*.*");
                }
                // This is thrown if even one of the files requires permissions greater
                // than the application provides.
                catch(UnauthorizedAccessException e) {
                    // This code just writes out the message and continues to recurse.
                    // You may decide to do something different here. For example, you
                    // can try to elevate your privileges and access the file again.
                    Debug.WriteLine(e.Message);
                }

                catch(System.IO.DirectoryNotFoundException e) {
                    Debug.WriteLine(e.Message);
                }

                if(files != null) {

                    //Get the set of new file names from the theme manager
                    //*******************************************************************************************************************
                    List<string> newNames = (listViewFiles.Tag as ThemeManager).GetFileNameSet(listViewFiles.Items.Count, files.Length);
                    int newNamesIndex = 0;
                    //*******************************************************************************************************************

                    int count = listViewFiles.Items.Count + 1;
                    foreach(System.IO.FileInfo fi in files) {

                        if((fi.Attributes & FileAttributes.Hidden) == 0) {

                            //string[] fileInfo = { fi.Name, newNames[newNamesIndex++], "To Convert", count.ToString(), FullPath };
                            string[] fileInfo = { fi.Name, newNames[newNamesIndex++], "To Convert", count.ToString(), fi.DirectoryName };
                            listViewFiles.Items.Add(new ListViewItem(fileInfo));
                            count++;
                        }
                    }

                }

            }

            //If unchecking 
            if(Checked == false) {

                // First, process all the files directly under this folder
                try {
                    files = ThisFolderInfo.GetFiles("*.*");
                }
                // This is thrown if even one of the files requires permissions greater
                // than the application provides.
                catch(UnauthorizedAccessException e) {
                    // This code just writes out the message and continues to recurse.
                    // You may decide to do something different here. For example, you
                    // can try to elevate your privileges and access the file again.
                    Debug.WriteLine(e.Message);
                }

                //remove the items from the listview
                for(int x = listViewFiles.Items.Count - 1; x >= 0; x--) {

                    var subItems = listViewFiles.Items[x].SubItems;
                    var subItem = subItems[4];
                    var str = subItem.Text.ToString();

                    if(str == files[0].DirectoryName)
                        listViewFiles.Items.RemoveAt(x);

                }


                //Get the set of new file names from the theme manager
                //*******************************************************************************************************************
                List<string> newNames = (listViewFiles.Tag as ThemeManager).GetFileNameSet(0, listViewFiles.Items.Count);
                int newNamesIndex = 0;
                //*******************************************************************************************************************

                //recount the items
                int count = 1;
                foreach(ListViewItem i in listViewFiles.Items) {
                    i.SubItems[3].Text = count.ToString();
                    i.SubItems[1].Text = newNames[newNamesIndex++];

                    count++;
                }
            }

        }
        public void AfterSelect( ListView listViewDisplayFiles ) {

            listViewDisplayFiles.Items.Clear();

            System.IO.FileInfo[] files = null;

            // First, process all the files directly under this folder
            try {
                files = ThisFolderInfo.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch(UnauthorizedAccessException e) {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                Debug.WriteLine(e.Message);
            }

            catch(System.IO.DirectoryNotFoundException e) {
                Debug.WriteLine(e.Message);
            }

            if(files != null) {

                foreach(System.IO.FileInfo fi in files) {

                    if((fi.Attributes & FileAttributes.Hidden) == 0) {

                        string[] fileInfo = { fi.Name, fi.DirectoryName };
                        listViewDisplayFiles.Items.Add(new ListViewItem(fileInfo));
                    }
                }

            }

        }
        /// <summary>
        /// Convert all the files
        /// Encrypt all the files
        /// </summary>
        /// <param name="listViewFiles"></param>
        public void ConvertFiles(ListView listViewFiles, string encryptionKey) {

            const bool ACTUALLY_ENCRYPT = false;

            //Create a list of original file names 
            var f = new List<string>();
            foreach(ListViewItem i in listViewFiles.Items) {
                f.Add(i.SubItems[0].Text);
            }

            NewSaveSetDlg dlg = new NewSaveSetDlg();
            dlg.fileList = f;
            dlg.ShowDialog();
            if(dlg.dialogResult == NewSaveSetDlg.DialogResult.OK) {


                var finishedList = new List<EncryptedFileItem>();

                try {

                    foreach(ListViewItem i in listViewFiles.Items) {

                        string originalName = i.SubItems[0].Text;
                        string newName = i.SubItems[1].Text;
                        string status = i.SubItems[2].Text;
                        string count = i.SubItems[3].Text;
                        string path = i.SubItems[4].Text;

                        finishedList.Add(EncryptedFileItem.MakeItem(dlg.Name, originalName, newName, path, count));

                        string source = Path.Combine(path, originalName);
                        string destination = Path.Combine(path, newName);

                        i.SubItems[2].Text = "Encrypting File";
                        Application.DoEvents();
                        SimpleEncryption.EncryptFile(source, destination, encryptionKey, ACTUALLY_ENCRYPT);
                        i.SubItems[2].Text = "Convertion Complete";
                        Application.DoEvents();



                    }
                }
                catch(Exception ex) {

                    //delete any converted file so as to resore directory before conversion
                    foreach(EncryptedFileItem fi in finishedList) {

                        string destination = Path.Combine(fi.path, fi.newName);
                        if(File.Exists(destination))
                            File.Delete(destination);
                    }
                    foreach(ListViewItem i in listViewFiles.Items) {

                        i.SubItems[2].Text = "To Convert";
                    }
                    Application.DoEvents();

                    throw new Exception("An error occured in the conversion process.  Restored all files back to before conversion started. ERROR = " + ex.Message);
                }




                if(ACTUALLY_ENCRYPT) {

                    //now delete the original
                    foreach(EncryptedFileItem fi in finishedList) {

                        string source = Path.Combine(fi.path, fi.originalName);
                        if(File.Exists(source))
                            File.Delete(source);
                    }
                }

                //Now create the saveSetItem
                var ssi = SaveSetItem.MakeItem(dlg.Name, dlg.Comment, encryptionKey);


                ManageSaveSet.UpdateSaveSet(finishedList, ssi);





            }
            else {

                MessageBox.Show("Canceled encryption of files.");
            }

        }
        public void PopulateSaveSetListView( ListView ssDetails, ListView ssListView) {

            ssListView.Items.Clear();
            ssDetails.Items.Clear();

            List<SaveSetItem> l = ManageSaveSet.ReturnSaveSetList();
            if(l.Count == 0)
                return;

            foreach(SaveSetItem i in l) {
                var t = new string[5];
                t[0] = i.SaveSetName;
                t[1] = i.CreationDate.ToShortDateString();
                t[2] = i.Comment;
                t[3] = i.Password;
                t[4] = i.TotalFileCount.ToString();
                ssListView.Items.Add(new ListViewItem(t));
                ssListView.Items[ssListView.Items.Count - 1].Tag = i.IndexIntoFile;
            }



        }
        public void PopulateTheItemsFromSaveSetOnSelect(ListView ssDetails, ListView ssSaveSet) {

            //It should be only one
            var indexCollection = ssSaveSet.SelectedIndices;
            ListViewItem lvi = ssSaveSet.Items[indexCollection[0]];

            long indexIntoFile = (long)lvi.Tag;
            int totalFiles = Convert.ToInt32(lvi.SubItems[4].Text);

            List<EncryptedFileItem> r = ManageSaveSet.ReturnEncryptedFolderList(indexIntoFile, totalFiles);

            ssDetails.Items.Clear();
            foreach(EncryptedFileItem i in r) {

                string[] t = new string[4];
                t[0] = i.originalName;
                t[1] = i.newName;
                t[2] = "File Type";
                t[3] = "Launch";
                ListViewItem lvin = new ListViewItem(t);
                ssDetails.Items.Add(lvin);
            }

        }
        public bool SearchSaveSets(string searchString, ListView view) {

            List<SaveSetItem> l =  ManageSaveSet.ReturnSaveSetList();
            List<SaveSetItem> retList = new List<SaveSetItem>();

            searchString = searchString.ToLower();

            foreach(SaveSetItem ssi in l) {

                string name = ssi.SaveSetName.ToLower();
                string comment = ssi.Comment.ToLower();

                if(name.Contains(searchString)) {
                    retList.Add(ssi);
                    continue;
                }
                if(comment.Contains(searchString)) {
                    retList.Add(ssi);
                    continue;
                }
            }

            if(retList.Count > 0) {
                view.Items.Clear();

                foreach(SaveSetItem i in retList) {
                    var t = new string[5];
                    t[0] = i.SaveSetName;
                    t[1] = i.CreationDate.ToShortDateString();
                    t[2] = i.Comment;
                    t[3] = i.Password;
                    t[4] = i.TotalFileCount.ToString();
                    view.Items.Add(new ListViewItem(t));
                    view.Items[view.Items.Count - 1].Tag = i.IndexIntoFile;
                }
                return true;
            }
            else
                MessageBox.Show("No encrypted files contain that search phrase.");
            return false;


        }
        public bool SearchFileNames( string searchString, ListView view ) {

            var ssL = ManageSaveSet.ReturnSaveSetList();

            return true;





        }
        /// <summary>
        /// return the root folder name
        /// </summary>
        /// <param name="fullPath">The Full Path of the Folder</param>
        /// <returns></returns>
        public static  string returnRootName(string fullPath ) {

            return fullPath.Substring(fullPath.LastIndexOf('\\') + 1);
        }

      /// <summary>
      /// This will create the parent tree structure
      /// Similar to what windows exploror looks like
      /// </summary>
      /// <returns></returns>
      public static FolderNode InitRootTree() {

         var root = new FolderNode("This PC");


         var favorites = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
         if(Directory.Exists(favorites)) { 
     
         var FavoritesInfo = new FolderNode(returnRootName(favorites), new DirectoryInfo(favorites));
         FavoritesInfo.AddChildren();
         root.Nodes.Add(FavoritesInfo);
         }


            var desk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         if(Directory.Exists(desk)) {

            var deskInfo = new FolderNode(returnRootName(desk), new DirectoryInfo(desk));
            deskInfo.AddChildren();
            root.Nodes.Add(deskInfo);
         }

            var doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         if(Directory.Exists(doc)) {

            var docInfo = new FolderNode(returnRootName(doc), new DirectoryInfo(doc));
            docInfo.AddChildren();
            root.Nodes.Add(docInfo);
         }

            var down = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var down2 = Path.Combine(down,"Downloads");
         if(Directory.Exists(down2)) {

            var downInfo = new FolderNode(returnRootName(down2), new DirectoryInfo(down2));
            downInfo.AddChildren();
            root.Nodes.Add(downInfo);
         }


         var vid = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
         if(Directory.Exists(vid)) {

            var vidInfo = new FolderNode(returnRootName(vid), new DirectoryInfo(vid));
            vidInfo.AddChildren();
            root.Nodes.Add(vidInfo);
         }

            var pic = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
         if(Directory.Exists(pic)) {

            var picInfo = new FolderNode(returnRootName(pic), new DirectoryInfo(pic));
            picInfo.AddChildren();
            root.Nodes.Add(picInfo);
         }

            var music = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
         if(Directory.Exists(music)) {

            var musicInfo = new FolderNode(returnRootName(music), new DirectoryInfo(music));
            musicInfo.AddChildren();
            root.Nodes.Add(musicInfo);
         }

            //var mycomp = Environment.GetFolderPath(Environment.SpecialFolder.);
            //var mycompInfo = new FolderNode(returnRootName(mycomp), new DirectoryInfo(mycomp));
            //mycompInfo.AddChildren();
            //root.Nodes.Add(mycomp);

            var home = Environment.GetEnvironmentVariable("USERPROFILE");
            var dropBox = Path.Combine(home, "Dropbox");
         if(Directory.Exists(dropBox)) {


            var dropboxInfo = new FolderNode(returnRootName("Dropbox"), new DirectoryInfo(dropBox));
            dropboxInfo.AddChildren();
            root.Nodes.Add(dropboxInfo);
         }

            var driveInfo = DriveInfo.GetDrives();
            foreach(DriveInfo d in driveInfo) {

                var t = new FolderNode(d.RootDirectory.Name, new DirectoryInfo(d.RootDirectory.FullName));
                t.AddChildren();
                root.Nodes.Add(t);



            }
            
            return root;

        }
    }



}
