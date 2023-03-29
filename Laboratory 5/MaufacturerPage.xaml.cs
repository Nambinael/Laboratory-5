using Laboratory_5.Lab5DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для MaufacturerPage.xaml
    /// </summary>
    public partial class MaufacturerPage : Page
    {
        manufacturerTableAdapter manufacturer = new manufacturerTableAdapter();
        public MaufacturerPage()
        {
            InitializeComponent();
            ManufacturerGrid.ItemsSource = manufacturer.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            if (ManufacturerBox.Text == null || ManufacturerBox.Text == "")
            {
                MessageBox.Show("Введите данные во все поля");
            }
            else if ((double.TryParse(ManufacturerBox.Text, out num)))
            {
                MessageBox.Show("Вы ввели число");
            }
            else
            {
                manufacturer.InsertQuery(ManufacturerBox.Text);
                ManufacturerGrid.ItemsSource = manufacturer.GetData();
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ManufacturerGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент длдя удаления");
            }
            else
            {
                int id = (int)(ManufacturerGrid.SelectedValue as DataRowView).Row[0];
                manufacturer.DeleteQuery(id);
                ManufacturerGrid.ItemsSource = manufacturer.GetData();

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ManufacturerGrid.SelectedValue != null)
            {
                var item = ManufacturerGrid.SelectedItem as DataRowView;
                manufacturer.UpdateQuery(ManufacturerBox.Text, (int)item.Row[0]);
                ManufacturerGrid.ItemsSource = manufacturer.GetData();

            }
        }

        private void ManufacturerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ManufacturerGrid.SelectedValue != null)
            {
                var item = ManufacturerGrid.SelectedItem as DataRowView;
                ManufacturerBox.Text = (string)item.Row[1];

            }
        }
    }
}
