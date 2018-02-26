using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace FileControl {

    public class ManageSaveSet {

        public static void UpdateSaveSet(List<EncryptedFileItem> items, SaveSetItem saveSet) {

            //first append the file items to the file item file
            long locStartIndex = 0;

            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileControl");
            if(!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            path = System.IO.Path.Combine(path, "edcvfgtbn.txt");

            using(var fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
            using(var sw = new System.IO.StreamWriter(fs)) {

                locStartIndex = fs.Seek(0, System.IO.SeekOrigin.End);

                foreach(EncryptedFileItem ii in items) {
                    sw.WriteLine(EncryptedFileItem.MakeLine(ii));
                }
                sw.Flush();
                sw.Close();
            }

            //add index and count
            saveSet.IndexIntoFile = locStartIndex;
            saveSet.TotalFileCount = items.Count;
            saveSet.IsActive = true;

            //now save the save set
            using(var sw = new System.IO.StreamWriter(System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "fileControl", "tbhtyplsd.txt")
                , true, Encoding.Default)) {

                sw.WriteLine(SaveSetItem.MakeLine(saveSet));
                sw.Flush();
                sw.Close();
            }
         Properties.Settings.Default.themeIndex += items.Count;
         Properties.Settings.Default.Save();


        }
        public static List<SaveSetItem> ReturnSaveSetList() {

         var retVal = new List<SaveSetItem>();

         string path = System.IO.Path.Combine(
             Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
             "fileControl");

         if(!Directory.Exists(path)) {
            Directory.CreateDirectory(path);
            return retVal;
         }

         path = System.IO.Path.Combine(
             Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
             "fileControl", "tbhtyplsd.txt");

         if(!File.Exists(path))
            return retVal;


            using(var sr = new System.IO.StreamReader(path, Encoding.Default)) {

                //Only return the active sets
                string line = string.Empty;
                while((line = sr.ReadLine()) != null) {
                    SaveSetItem i = SaveSetItem.MakeItem(line);
                    if(i.IsActive == true)
                        retVal.Add(i);

                }

                sr.Close();
            }
            return retVal;


        }
        public static List<EncryptedFileItem> ReturnEncryptedFolderList( long fileIndex, int totalCount ) {

            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileControl");
            path = System.IO.Path.Combine(path, "edcvfgtbn.txt");

            var retVal = new List<EncryptedFileItem>();

            using(var fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            using(var sw = new System.IO.StreamReader(fs)) {

                fs.Seek(fileIndex, System.IO.SeekOrigin.Begin);

                for(int x = 0; x < totalCount; x++) {
                    retVal.Add(EncryptedFileItem.MakeItem(sw.ReadLine()));
                }

                sw.Close();
                return retVal;
            }

        }



        





    }




    public class EncryptedFileItem {

        private EncryptedFileItem() {

        }
        public static EncryptedFileItem MakeItem( string saveSet, string originalName, string newName, string path, string count ) {

            var c = new EncryptedFileItem();
            c.count = int.Parse(count);
            c.newName = newName;
            c.originalName = originalName;
            c.path = path;
            c.SaveSetName = saveSet;
            return c;
        }
        public static EncryptedFileItem MakeItem(string fromFile) {

            string[] split = fromFile.Split(new char[] { '|' });

            var i = new EncryptedFileItem();
            i.count = Convert.ToInt32(split[4]);
            i.newName = split[2];
            i.originalName = split[1];
            i.path = split[3];
            i.SaveSetName = split[0];
            return i;
        }


        public string originalName { get; set; }
        public string newName { get; set; }
        public int count { get; set; }
        public string path { get; set; }
        public string SaveSetName { get; set; }
        public static string MakeLine( EncryptedFileItem c ) {

            StringBuilder sb = new StringBuilder();
            sb.Append(c.SaveSetName);
            sb.Append("|");
            sb.Append(c.originalName);
            sb.Append("|");
            sb.Append(c.newName);
            sb.Append("|");
            sb.Append(c.path);
            sb.Append("|");
            sb.Append(c.count.ToString());
            return sb.ToString();

        }

    }
    public class SaveSetItem {

        private SaveSetItem() { }

        public static SaveSetItem MakeItem( string saveSetName, string comment, string password ) {

            var s = new SaveSetItem();
            s.Comment = comment;
            s.CreationDate = DateTime.Now;
            s.Password = password;
            s.SaveSetName = saveSetName;
            return s;
        }
        public static SaveSetItem MakeItem(string fromFile) {

            string[] split = fromFile.Split(new char[] { '|'});

            var s = new SaveSetItem();

            string[] tc = split[2].Trim().Split(new string[] {"/CL/"}, StringSplitOptions.None);
            StringBuilder sb = new StringBuilder();
            foreach(string sc in tc) {
                sb.AppendLine(sc);
            }
            s.Comment = sb.ToString();
            s.CreationDate = DateTime.Parse(split[1]);
            s.Password = split[3].Trim();
            s.SaveSetName = split[0].Trim();
            s.TotalFileCount = Convert.ToInt32(split[5]);
            s.IndexIntoFile = Convert.ToInt64(split[4]);
            s.IsActive = bool.Parse(split[6]);
            return s;
        }
        public DateTime CreationDate { get; set; }
        public string SaveSetName { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }
        public long IndexIntoFile { get; set; }
        public int TotalFileCount { get; set; }
        public bool IsActive { get; set; }
        public static string MakeLine( SaveSetItem s) {

            StringBuilder sb = new StringBuilder();

            sb.Append(s.SaveSetName);
            sb.Append("|");
            sb.Append(s.CreationDate.ToString());
            sb.Append("|");
            sb.Append(s.Comment);
            sb.Append("|");
            sb.Append(s.Password);
            sb.Append("|");
            sb.Append(s.IndexIntoFile.ToString());
            sb.Append("|");
            sb.Append(s.TotalFileCount.ToString());
            sb.Append("|");
            sb.Append(s.IsActive.ToString());
            return sb.ToString();
        }

    }
}
