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
using System.Windows.Shapes;
using PerfectFarming.Database;
using PerfectFarming.Models;
namespace PerfectFarming.Dialogs
{
    /// <summary>
    /// Interaction logic for AddCrops.xaml
    /// </summary>
    public partial class AddCrops : Window
    {
        DatabaseLayer db;
        public AddCrops()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
            txtExpense.PreviewTextInput += PreviewTextInput;
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
            base.OnPreviewTextInput(e);
        }
        private bool AreAllValidNumericChars(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsNumber(c)) return false;
            }

            return true;
        }
        private bool validateFieldForm()
        {
            if (txtName.Text.Trim() == "") { txtName.Background = System.Windows.Media.Brushes.Red; return false; } else { txtName.Background = null; }
            if (txtDescripton.Text.Trim() == "") { txtDescripton.Background = System.Windows.Media.Brushes.Red; return false; } else { txtDescripton.Background = null; }
            if (txtExpense.Text.Trim() == "") { txtExpense.Background = System.Windows.Media.Brushes.Red; return false; } else { txtExpense.Background = null; }

            return true;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateFieldForm())
            {
                Crop crop = new Crop
                {
                    name = txtName.Text,
                    description = txtDescripton.Text,
                    color = colorSelector.SelectedColor.ToString(),
                    planned_expense = Convert.ToInt64(txtExpense.Text)
                    
                };
                db.AddCrop(crop);
                db.Commit();
                this.Close();
            }
        }

        private void txtCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void colorSelector_SelectedColorChanged(object sender, EventArgs e)
        {
            this.colordisplay.Background = new SolidColorBrush(colorSelector.SelectedColor);
        }
    }
}
