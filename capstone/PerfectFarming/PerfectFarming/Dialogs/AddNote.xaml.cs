using PerfectFarming.Database;
using PerfectFarming.Models;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
namespace PerfectFarming.Dialogs
{
    /// <summary>
    /// Interaction logic for AddNote.xaml
    /// </summary>
    public partial class AddNote : Window
    {
        DatabaseLayer db;
        string c_filename = "";
        public AddNote()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
        }
        bool validateForm()
        {
            if (txtName.Text.Trim() == "") { txtName.Background = Brushes.Red; return false; } else { txtName.Background = null; }
            if (txtDescription.Text.Trim() == "") { txtDescription.Background = System.Windows.Media.Brushes.Red; return false; } else { txtDescription.Background = null; }
            return true;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateForm())
            {
                byte[] BlobValue = null;
                long filesize = 0;
                if (c_filename != "")
                {
                    FileStream fs = new FileStream(c_filename, FileMode.Open, FileAccess.Read);

                    //The reader reads the binary data from the file stream  
                    BinaryReader reader = new BinaryReader(fs);
                    filesize = fs.Length;
                    //Bytes from the binary reader stored in BlobValue array  
                    BlobValue = reader.ReadBytes((int)fs.Length);
                }
                Note note = new Note { name = txtName.Text, description = txtDescription.Text, filename = fileName.Text,file_size= filesize,data = BlobValue };
                db.AddNote(note);
                db.Commit();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName.Text = openFileDialog.SafeFileName;
                c_filename = openFileDialog.FileName;
            }
                
        }
    }
}
