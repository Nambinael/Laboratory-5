using Laboratory_5.Lab5DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
using static Laboratory_5.Lab5DataSet;

namespace Laboratory_5
{
    /// <summary>
    /// Логика взаимодействия для ManufacturerCountryPage.xaml
    /// </summary>
    public partial class ManufacturerCountryPage : Page
    {
        manufacturer_countryTableAdapter manufacturer_Country = new manufacturer_countryTableAdapter();
        public ManufacturerCountryPage()
        {
            InitializeComponent();
            ManufacturerCountryGrid.ItemsSource = manufacturer_Country.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            if (CountryBox.Text == null || CountryBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else if ((double.TryParse(CountryBox.Text, out num)))
            {
                MessageBox.Show("Вы ввели число");
            }
            else
            {
                manufacturer_Country.InsertQuery(CountryBox.Text);
                ManufacturerCountryGrid.ItemsSource = manufacturer_Country.GetData();
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ManufacturerCountryGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
            else
            {
                int id = (int)(ManufacturerCountryGrid.SelectedValue as DataRowView).Row[0];
                manufacturer_Country.DeleteQuery(id);
                ManufacturerCountryGrid.ItemsSource = manufacturer_Country.GetData();
            }
        }
            

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ManufacturerCountryGrid.SelectedValue != null)
            {
                var item = ManufacturerCountryGrid.SelectedItem as DataRowView;
                manufacturer_Country.UpdateQuery(CountryBox.Text, (int)item.Row[0]);
                ManufacturerCountryGrid.ItemsSource = manufacturer_Country.GetData();

            }
        }

        private void ManufacturerCountryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ManufacturerCountryGrid.SelectedValue != null)
            {
                var item = ManufacturerCountryGrid.SelectedItem as DataRowView;
                CountryBox.Text = (string)item.Row[1];

            }
        }
    }
}
