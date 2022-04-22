using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PerfectFarming.Controls;
using PerfectFarming.Database;
using PerfectFarming.Models;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.SqlServer.Types;
using Point = System.Windows.Point;
using PerfectFarming.Dialogs;

namespace PerfectFarming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum STATES
    {
        NONE,
        ADD_FIELD,
        ADD_EQUIPMENT
    }
    public partial class MainWindow : Window
    {
        System.Drawing.Color selectColor = ColorTranslator.FromHtml("#4CAF50");
        System.Windows.Media.Color noColor = Colors.Transparent;
        DatabaseLayer db;
        List<Location> temp_geopoint;
        MapPolygon temp_polygon;
        STATES c_state;
        Dictionary<int, MapPolygon> fieldPolygonDict;
        public MainWindow()
        {
            InitializeComponent();
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            PFButton.Click += PFButton_Click; 
            db = DatabaseLayer.Instance;
            temp_geopoint = new List<Location>();
            fieldPolygonDict = new Dictionary<int, MapPolygon>();
            //Field field = new Field { name = "Field 1", session_id = 1, area_covered = 200 };
            //db.AddField(field);
            txtCoveredArea.PreviewTextInput += TxtCoveredArea_PreviewTextInput; ;
            listFields.ItemsSource = db.getFields((season.SelectedItem as ComboBoxItem).Content.ToString());
            //btnMap.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(selectColor.A, selectColor.R, selectColor.G, selectColor.B));
        }

        private void TxtCoveredArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void PFButton_Click(object sender, RoutedEventArgs e)
        {
            String button = (sender as Border).Tag.ToString();
            setallNoColor();
            (sender as Border).Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(selectColor.A, selectColor.R, selectColor.G, selectColor.B));
            fieldView.Visibility = Visibility.Collapsed;
            switch (button)
            {
                case "Dashboard":
                    {
                        hideAll();
                        tabDashboard.IsSelected = true;
                        tabControl.SetValue(Grid.RowProperty,1);
                        tabControl.SetValue(Grid.RowSpanProperty,1);
                        topPanel.Background= new SolidColorBrush(System.Windows.Media.Color.FromArgb(selectColor.A, selectColor.R, selectColor.G, selectColor.B));
                        topPanel.Opacity = 1;
                        dashboard.setSeason((season.SelectedItem as ComboBoxItem).Content.ToString());
                        dashboard.Refresh();
                        break;
                    }
                case "Fields":
                    {
                        hideAll();
                        tabControl.SetValue(Grid.RowProperty, 1);
                        tabControl.SetValue(Grid.RowSpanProperty, 1);
                        topPanel.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(selectColor.A, selectColor.R, selectColor.G, selectColor.B));
                        topPanel.Opacity = 1;
                        tabMap.IsSelected = true;
                        fieldsStack.Visibility = Visibility.Visible;
                        break;
                    }
                case "Map":
                    {
                        tabControl.SetValue(Grid.RowProperty, 0);
                        tabControl.SetValue(Grid.RowSpanProperty, 2);
                        topPanel.Background = new SolidColorBrush(Colors.Black);
                        topPanel.Opacity = 0.5;
                        hideAll();
                        tabMap.IsSelected = true;
                        break;
                    }
                case "Notes":
                    {
                        hideAll();
                        tabControl.SetValue(Grid.RowProperty, 1);
                        tabControl.SetValue(Grid.RowSpanProperty, 1);
                        topPanel.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(selectColor.A, selectColor.R, selectColor.G, selectColor.B));
                        topPanel.Opacity = 1;
                        tabNotes.IsSelected = true;
                        notes.Refresh();
                        break;
                    }
                case "Work Flows":
                    {
                        hideAll();
                        tabControl.SetValue(Grid.RowProperty, 1);
                        tabControl.SetValue(Grid.RowSpanProperty, 1);
                        topPanel.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(selectColor.A, selectColor.R, selectColor.G, selectColor.B));
                        topPanel.Opacity = 1;
                        tabWorks.IsSelected = true;
                        workFlow.setSeason((season.SelectedItem as ComboBoxItem).Content.ToString());
                        workFlow.Refresh();
                        break;
                    }
                case "Equipments":
                    {
                        hideAll();
                        tabControl.SetValue(Grid.RowProperty, 1);
                        tabControl.SetValue(Grid.RowSpanProperty, 1);
                        topPanel.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(selectColor.A, selectColor.R, selectColor.G, selectColor.B));
                        topPanel.Opacity = 1;
                        tabEquipments.IsSelected = true;
                        equipmentsControl.Refresh();
                        break;
                    }
                case "Warehouse":
                    {
                        hideAll();
                        tabControl.SetValue(Grid.RowProperty, 1);
                        tabControl.SetValue(Grid.RowSpanProperty, 1);
                        topPanel.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(selectColor.A, selectColor.R, selectColor.G, selectColor.B));
                        topPanel.Opacity = 1;
                        tabWarehouse.IsSelected = true;
                        warehouseControl.Refresh();
                        break;
                    }
            }
        }
        void setallNoColor()
        {
            btnField.setNoColor();
            btnDashboard.setNoColor();
            btnNotes.setNoColor();
            btnEquipment.setNoColor();
            btnWork.setNoColor();
            btnMap.setNoColor();
            btnWarehouse.setNoColor();

        }
        void hideAll()
        {
            fieldsStack.Visibility = Visibility.Collapsed;
        }

        
        private void vectorLayer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (c_state == STATES.ADD_FIELD)
            {
                //GeoPoint geoPt = mapControl.Layers[0].ScreenToGeoPoint(e.GetPosition(vectorLayer));
                //temp_geopoint.Add(geoPt);
                coordinateListBox.ItemsSource = null;
                coordinateListBox.ItemsSource = temp_geopoint;
            }
        }

        private void BtnClearCoordinates_Click(object sender, RoutedEventArgs e)
        {
            coordinateListBox.ItemsSource = null;
            temp_geopoint.Clear();
            fieldsLayer.Children.Remove(temp_polygon);
            c_state = STATES.NONE;
        }

        private void btnAddField_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (gridNewField.Visibility == Visibility.Hidden)
            {
                cropsCombo.Items.Clear();
                foreach(Crop cp in db.getCrops())
                {
                    ComboBoxItem item = new ComboBoxItem { Content = cp.name, Tag = cp.crop_id,IsSelected=true };
                    cropsCombo.Items.Add(item);
                }
                gridNewField.Visibility = Visibility.Visible;
                coordinateListBox.ItemsSource = null;
                temp_geopoint.Clear();
                txtCoveredArea.Text = "";
                txtFieldName.Text = "";
                btnInsertField.IsEnabled = true;

            }
            else
            {
                gridNewField.Visibility = Visibility.Hidden;
                c_state = STATES.NONE;
            }
        }

        private void btnInsertField_Click(object sender, RoutedEventArgs e)
        {
            if (validateFieldForm())
            {
                btnInsertField.IsEnabled = false;
                Field field = new Field { 
                    name = txtFieldName.Text,
                    area_covered=Convert.ToInt32(txtCoveredArea.Text),
                    season_id=Convert.ToInt32( (season.SelectedItem as ComboBoxItem).Content.ToString())};
                int fieldid = db.AddField(field);
                foreach(Location location in temp_geopoint)
                {
                    FieldCoordinate fieldCoordinate = new FieldCoordinate { 
                        field_id = fieldid, 
                        latitude=location.Latitude,
                        longitude=location.Longitude};
                    db.AddFieldCoordinate(fieldCoordinate);
                }
                db.Commit();
                listFields.ItemsSource = null;
                listFields.ItemsSource = db.getFields((season.SelectedItem as ComboBoxItem).Content.ToString());
                gridNewField.Visibility = Visibility.Hidden;

                c_state = STATES.NONE;
            }
        }

        private void btnCancelField_Click(object sender, RoutedEventArgs e)
        {
            gridNewField.Visibility = Visibility.Hidden;
        }

        private void btnAddCoordinates_Click(object sender, RoutedEventArgs e)
        {
            if (c_state != STATES.ADD_FIELD)
            {
                c_state = STATES.ADD_FIELD;
                temp_polygon = new MapPolygon();
                // Defines the polygon fill details
                temp_polygon.Locations = new LocationCollection();
                temp_polygon.Fill = new SolidColorBrush(Colors.Transparent);
                temp_polygon.Stroke = new SolidColorBrush(Colors.Green);
                temp_polygon.StrokeThickness = 2;
                temp_polygon.Opacity = 0.8;
                fieldsLayer.Children.Add(temp_polygon);
                //Set focus back to the map so that +/- work for zoom in/out
                mapControl.Focus();
                
            }
        }

        private void ImageLayer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            c_state = STATES.NONE;
        }

        private bool validateFieldForm()
        {
            if(txtFieldName.Text.Trim() == "") { txtFieldName.Background = System.Windows.Media.Brushes.Red; return false; } else { txtFieldName.Background = null; }
            if (txtCoveredArea.Text.Trim() == "") { txtCoveredArea.Background = System.Windows.Media.Brushes.Red; return false; } else { txtCoveredArea.Background = null; }
            if(temp_geopoint.Count < 3) { MessageBox.Show("Area points must be greater than 2!"); return false; }
            return true;
        }
        private void mapControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (c_state == STATES.ADD_FIELD)
            {
                //GeoPoint geoPt = mapControl.Layers[0].ScreenToGeoPoint(e.GetPosition(vectorLayer));
                //temp_geopoint.Add(geoPt);
                Point mousePosition = e.GetPosition(this.mapControl);
                //Convert the mouse coordinates to a location on the map
                Location polygonPointLocation = mapControl.ViewportPointToLocation(
                    mousePosition);
                

                temp_polygon.Locations.Add(polygonPointLocation);
                temp_geopoint.Add(polygonPointLocation);

                //Set focus back to the map so that +/- work for zoom in/out
                mapControl.Focus();
                coordinateListBox.ItemsSource = null;
                coordinateListBox.ItemsSource = temp_geopoint;
            }
        }

        private void season_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadFields();
        }
        void loadFields()
        {
            if (listFields != null)
            {
                listFields.ItemsSource = null;
                List<Field> fields = db.getFields((season.SelectedItem as ComboBoxItem).Content.ToString());
                listFields.ItemsSource = fields;
                fieldsLayer.Children.Clear();
                fieldPolygonDict.Clear();
                foreach (Field field in fields)
                {
                    List<FieldCoordinate> fieldCoordinates = db.GetFieldCoordinates(field.field_id);
                    LocationCollection locations = new LocationCollection();
                    foreach (FieldCoordinate fieldCoordinate in fieldCoordinates)
                    {
                        locations.Add(new Location { Latitude = fieldCoordinate.latitude, Longitude = fieldCoordinate.longitude });
                    }
                    temp_polygon = new MapPolygon();
                    // Defines the polygon fill details
                    temp_polygon.Locations = locations;
                    FieldExplored fieldex = db.GetFieldsExplored((season.SelectedItem as ComboBoxItem).Content.ToString()).Where(p=> p.field_id == field.field_id).FirstOrDefault();
                    if (fieldex != null && fieldex.is_used) { temp_polygon.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(ColorTranslator.FromHtml(fieldex.color).A, ColorTranslator.FromHtml(fieldex.color).R, ColorTranslator.FromHtml(fieldex.color).G, ColorTranslator.FromHtml(fieldex.color).B)); }
                    else
                    {
                        temp_polygon.Fill = new SolidColorBrush(Colors.Gray);
                    }
                    temp_polygon.Stroke = new SolidColorBrush(Colors.Green);
                    temp_polygon.StrokeThickness = 2;
                    temp_polygon.Opacity = 0.8;
                    temp_polygon.ToolTip = field.name;
                    temp_polygon.Tag = field.field_id;
                    temp_polygon.MouseDown += Temp_polygon_MouseDown;
                    fieldsLayer.Children.Add(temp_polygon);
                    fieldPolygonDict.Add(field.field_id, temp_polygon);

                    if (temp_polygon.Locations.Count > 0)
                        mapControl.Center = temp_polygon.Locations[0];
                }
            }
        }

        private void Temp_polygon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int field_id =Convert.ToInt32( (sender as MapPolygon).Tag.ToString());
            
            fieldView.setFieldInfo(field_id);
            //List<FieldCoordinate> fieldCoordinates = db.GetFieldCoordinates(field_id);
            //if (fieldCoordinates.Count > 0)
            //{
            //    Location location = new Location { Latitude = fieldCoordinates[0].latitude, Longitude = fieldCoordinates[0].longitude };

            //    mapControl.Center = location;
            //    mapControl.ZoomLevel = 15;
            //}
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mapControl.Center = new Location(39.0997, -94.5786);
            mapControl.ZoomLevel = 8;
            loadFields();
            
        }

        private void addField_Click(object sender, RoutedEventArgs e)
        {
            if (gridNewField.Visibility == Visibility.Hidden)
            {
                cropsCombo.Items.Clear();
                foreach (Crop cp in db.getCrops())
                {
                    ComboBoxItem item = new ComboBoxItem { Content = cp.name, Tag = cp.crop_id, IsSelected = true };
                    cropsCombo.Items.Add(item);
                }
                gridNewField.Visibility = Visibility.Visible;
                coordinateListBox.ItemsSource = null;
                temp_geopoint.Clear();
                txtCoveredArea.Text = "";
                txtFieldName.Text = "";
                btnInsertField.IsEnabled = true;

            }
        }

        private void addNotes_Click(object sender, RoutedEventArgs e)
        {
            AddNote addNote = new AddNote();
            addNote.ShowDialog();
        }

        private void addWorkflow_Click(object sender, RoutedEventArgs e)
        {
            AddWorkFlow addWorkFlow = new AddWorkFlow((season.SelectedItem as ComboBoxItem).Content.ToString());
            addWorkFlow.ShowDialog();
        }
        private bool validateLoginForm()
        {
            if (txtUserName.Text.Trim() == "") { txtUserName.Background = System.Windows.Media.Brushes.Red; return false; } else { txtUserName.Background = System.Windows.Media.Brushes.White; }
            if (txtPassword.Password.Trim() == "") { txtPassword.Background = System.Windows.Media.Brushes.Red; return false; } else { txtPassword.Background = System.Windows.Media.Brushes.White; }
            return true;
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (validateLoginForm())
            {
                List<User> users = db.checkLogin(txtUserName.Text, txtPassword.Password);
                if (users.Count > 0)
                {
                    loginArea.Visibility = Visibility.Hidden;
                    if(users[0].user_type != "Admin")
                    {
                        addUser.Visibility = Visibility.Collapsed;

                    }
                    else
                    {
                        addUser.Visibility = Visibility.Visible;
                    }
                    loggedUserName.Label = users[0].first_name;
                }
                else
                {
                    MessageBox.Show("Invalid User Name or Password!");
                }
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee employeedlg = new AddEmployee();
            employeedlg.ShowDialog();

        }

        private void addCrop_Click(object sender, RoutedEventArgs e)
        {
            AddCrops addCropsdlg = new AddCrops();
            addCropsdlg.ShowDialog();
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser userdlg = new AddUser();
            userdlg.ShowDialog();
        }

        private void logoutUser_Click(object sender, RoutedEventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Password = "";
            loginArea.Visibility = Visibility.Visible;
            fieldView.Visibility = Visibility.Collapsed;
        }

        private void listFields_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Field selectedfield = (Field)listFields.SelectedItem;
            if (selectedfield != null)
            {
                fieldView.setFieldInfo(selectedfield.field_id);
                List<FieldCoordinate> fieldCoordinates = db.GetFieldCoordinates(selectedfield.field_id);
                if (fieldCoordinates.Count > 0)
                {
                    Location location = new Location { Latitude = fieldCoordinates[0].latitude, Longitude = fieldCoordinates[0].longitude };

                    mapControl.Center = location;
                    mapControl.ZoomLevel = 15;
                }
            }
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private void searchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(searchField.Text != null)
            {
                List<Field> fields = db.getFields(searchField.Text, (season.SelectedItem as ComboBoxItem).Content.ToString());
                listFields.ItemsSource = null;
                listFields.ItemsSource = fields;
            }
            else
            {
                List<Field> fields = db.getFields((season.SelectedItem as ComboBoxItem).Content.ToString());
                listFields.ItemsSource = null;
                listFields.ItemsSource = fields;
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddNote addNote = new AddNote();
            addNote.ShowDialog();
        }
    }
}
