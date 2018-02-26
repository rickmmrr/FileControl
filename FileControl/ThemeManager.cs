using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileControl {
    
    public class FilePathSctrucList {

        public string RootFolderStruc { get; set; }
        public List<FilePathStruc> RunList { get; set; }
        

        public class FilePathStruc {

            public string OriginalPath { get; set; }
            public string NewPath { get; set; }
        }
    }
    
    
    
    
    /// <summary>
    /// This class defines and manaages the themes for 
    /// writing out the results
    /// 
    /// </summary>
    class ThemeManager {

        public enum FileTheme { Business,Family}
        string[] _businessNouns = { "Corporate", "Extra", "Inline", "Misc", "Office", "Travel", "Holiday", "Cash","Unspecified" };
        string[] _businessVerbs = { "payments", "savings", "account", "fund", "outlays", "expenses" };


        string[] _householdNouns = { "Family", "Extra", "Vacation", "Misc", "Food", "Budget","Cash","Holiday","Gifts", "Unspecified" };
        string[] _householdVerbs = { "payments", "savings", "account", "fund", "outlays", "expenses" };

        string[] _months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

      static string[] _notYear = null;


        FileTheme _currentTheme = FileTheme.Family;

        /// <summary>
        /// Set the theme in the constructor
        /// </summary>
        /// <param name="theme"></param>
        public ThemeManager( FileTheme theme ) {

            _currentTheme = theme;

         _notYear = new string[9999];
         for(int x = 1; x < 10000; x++)
            _notYear[x - 1] = x.ToString("0000");
            
        }

        /// <summary>
        /// Returns a list of file names needed for the current set
        /// As long as the caller keeps track of the start index we are good
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<string> GetFileNameSet(int startIndex, int count) {

         //init return value
         //***************************************
         List<string> list = new List<string>();
         //***************************************

         //assign either Business or Household
         //*************************************
         string[] nouns = null;
         string[] verbs = null;
         if(_currentTheme == FileTheme.Business) {
               nouns = _businessNouns;
               verbs = _businessVerbs;
         }
         else {
               nouns = _householdNouns;
               verbs = _householdVerbs;
         }
         //*************************************


         //Get the Date
         //*************************************************
         var dt = DateTime.Now.ToShortDateString();
         dt = dt.Replace('/','-');
         //*************************************************


         // Perform the loop
         //******************************************************
         bool allDoneLoop = false;

         int s = startIndex + Properties.Settings.Default.themeIndex;
         if(s > 0)
            s--;


         for(int c = 0; c < count; c++) {

            int nounx = 0;
            int verbx = 0;
            int monthx = 0;
            int notYear = 0;

            nounx = s % nouns.Length;
            verbx = (s / nouns.Length) % verbs.Length;
            monthx = s / (verbs.Length * nouns.Length) % _months.Length;
            notYear = s / ((verbs.Length * nouns.Length) * _months.Length) %  _notYear.Length;


            var result = String.Format("{0}-{1}-{2}-{3}.fcr", nouns[nounx], verbs[verbx], _months[monthx], _notYear[notYear]);
            list.Add(result);
            s++;
         }
           
         //******************************************************



         //return the list
         //***********
         return list;
         //***********


        }
        public void ReleaseFileNameSet() {

        }
    }
}
