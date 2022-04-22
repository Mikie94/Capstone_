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

namespace PerfectFarming.Controls
{
    /// <summary>
    /// Interaction logic for Equipments.xaml
    /// </summary>
    public partial class Equipments : UserControl
    {

        private AddEquipment eqdlg;
        private List<Equipment> equipments;
        DatabaseLayer db;
        Equipment selectedEquipment;
        public Equipments()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
            //equipments = db.getEquipments();
            //listEquipments.ItemsSource = equipments;
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            eqdlg = new AddEquipment();
            eqdlg.ShowDialog();
            equipments = db.getEquipments();
            listEquipments.ItemsSource = null;
            listEquipments.ItemsSource = equipments;
        }

        internal void Refresh()
        {
            equipments = db.getEquipments();
            listEquipments.ItemsSource = null;
            listEquipments.ItemsSource = equipments;
        }

        private void searchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchField.Text != null)
            {
                List<Equipment> fields = db.getEquipments(searchField.Text);
                listEquipments.ItemsSource = null;
                listEquipments.ItemsSource = fields;
            }
            else
            {
                List<Note> fields = db.getNotes();
                listEquipments.ItemsSource = null;
                listEquipments.ItemsSource = fields;
            }
        }

        private void listEquipments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEquipment = (listEquipments.SelectedItem as Equipment);
            if (selectedEquipment != null)
            {
                equipmentName.Content = selectedEquipment.name;
                make.Text = selectedEquipment.make;
                model.Text = selectedEquipment.model;
                detailGrid.Visibility = Visibility.Visible;
                
            }
            else
            {
                detailGrid.Visibility = Visibility.Collapsed;
            }
        }
    }
}
