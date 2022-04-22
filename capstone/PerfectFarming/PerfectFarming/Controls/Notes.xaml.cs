using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PerfectFarming.Dialogs;
using PerfectFarming.Models;
using PerfectFarming.Database;
using System.IO;

namespace PerfectFarming.Controls
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : UserControl
    {
        DatabaseLayer db;
        List<Note> notes;
        Note selectedNote;
        public Notes()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
            //notes = new List<Note>();
            //Refresh();
        }

        private void btnAddNote_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddNote notedlg = new AddNote();
            notedlg.ShowDialog();
            Refresh();
        }
        public void Refresh()
        {
            notes = db.getNotes();
            listNotes.ItemsSource = null;
            listNotes.ItemsSource = notes;
        }

        private void listNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedNote = (listNotes.SelectedItem as Note);
            if (selectedNote != null)
            {
                noteName.Content = selectedNote.name;
                description.Text = selectedNote.description;
                detailGrid.Visibility = Visibility.Visible;
                if (selectedNote.file_size > 0)
                {
                    fileName.Text = selectedNote.filename;
                    btnDownload.IsEnabled = true;
                }
                else
                {
                    btnDownload.IsEnabled = false;
                }
            }
            else
            {
                detailGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.FileName = selectedNote.filename;
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllBytes(dialog.FileName, selectedNote.data);
                MessageBox.Show("File Saved!");
            }
        }

        private void searchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchField.Text != null)
            {
                List<Note> fields = db.getNotes(searchField.Text);
                listNotes.ItemsSource = null;
                listNotes.ItemsSource = fields;
            }
            else
            {
                List<Note> fields = db.getNotes();
                listNotes.ItemsSource = null;
                listNotes.ItemsSource = fields;
            }
        }
    }
}
