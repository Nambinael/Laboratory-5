using Laboratory_5.Lab5DataSetTableAdapters;
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

namespace Laboratory_5
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        ammoTableAdapter ammo = new ammoTableAdapter();
        caliberTableAdapter caliber = new caliberTableAdapter();
        fire_modeTableAdapter fire_mode = new fire_modeTableAdapter();
        gunsTableAdapter guns = new gunsTableAdapter();
        gun_typeTableAdapter gun_type = new gun_typeTableAdapter();
        manufacturerTableAdapter manufacturer = new manufacturerTableAdapter(); 
        manufacturer_countryTableAdapter manufacturer_Country = new manufacturer_countryTableAdapter();
        modification_typeTableAdapter modification_Type = new modification_typeTableAdapter();
        modificationsTableAdapter modifications = new modificationsTableAdapter();
        check_infoTableAdapter check_info = new check_infoTableAdapter();
        roleTableAdapter role = new roleTableAdapter();
        personTableAdapter person = new personTableAdapter();
        goodsTableAdapter goods = new goodsTableAdapter();
        checkTableAdapter check = new checkTableAdapter();


        public AdminPage()
        {
            InitializeComponent();

            string[] qwers = new string[] { "Патроны", "Калибр", "Режим огня", "Тип оружия", "Оружие", "Производитель", "Страна производителя", "Модули", "Тип модуля", "Информация о чеке"};
            TableCbx.ItemsSource = qwers;

        }

        private void TableCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TableCbx.SelectedIndex == 0)
            {
                SecondFrame.Content = new AmmoPage();
            }
            if (TableCbx.SelectedIndex == 1)
            {
                SecondFrame.Content = new CaliberPage();
            }
        
            if (TableCbx.SelectedIndex == 2)
            {
                SecondFrame.Content = new FireModePage();
            }
            if (TableCbx.SelectedIndex == 3)
            {
                SecondFrame.Content = new GunTypePage();
            }
            if (TableCbx.SelectedIndex == 4)
            {
                SecondFrame.Content = new GunsPage();
            }
            if (TableCbx.SelectedIndex == 5)
            {
                SecondFrame.Content = new MaufacturerPage();
            }
            if (TableCbx.SelectedIndex == 6)
            {
                SecondFrame.Content = new ManufacturerCountryPage();
            }
            if (TableCbx.SelectedIndex == 7)
            {
                SecondFrame.Content = new Modifications();
            }
            if (TableCbx.SelectedIndex == 8)
            {
                SecondFrame.Content = new MoficationsTypePage();
            }
            if (TableCbx.SelectedIndex == 9)
            {
                SecondFrame.Content = new CheckInfoPage();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SecondFrame.Content = new RolePage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SecondFrame.Content = new PersonPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SecondFrame.Content = new GoodsPage();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).MainFrame.Content = new CheckPage();
        }
    }
}
