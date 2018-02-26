using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileControl {
    public partial class NewSaveSetDlg : Form {

        public enum DialogResult { OK,Cancel};

        public string Name { get; set; }
        public DialogResult dialogResult { get; set; }
        public List<string> fileList { get; set; }
        public string Comment { get; set; }

        public NewSaveSetDlg() {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e ) {

            Name = textBoxSaveSetName.Text;
            StringBuilder sb = new StringBuilder();
            foreach(string s in textBoxComment.Lines) {
                sb.Append(s);
                sb.Append("/CL/");
            }
            Comment = sb.ToString();
            Comment = Comment.Replace("COMMENTS GO HERE:", "");

            dialogResult = DialogResult.OK;
            this.Close();

        }

        private void button2_Click( object sender, EventArgs e ) {
            Name = string.Empty;
            Comment = string.Empty;
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void NewSaveSetDlg_Load( object sender, EventArgs e ) {

            if(fileList == null) {
                MessageBox.Show("Hay Man, you did not include the file list");
                button2_Click(null, null);
            }
            else {

                StringBuilder sb = new StringBuilder();

                sb.AppendLine();
                sb.AppendLine("COMMENTS GO HERE:");
                sb.AppendLine();
                sb.AppendLine();

                foreach(string f in fileList) {
                    sb.AppendLine(f);

                }
                textBoxComment.Text = sb.ToString();
                Application.DoEvents();

            }
        }
    }
}
