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

namespace Laboratory_5
{
    /// <summary>
    /// Логика взаимодействия для GunTypePage.xaml
    /// </summary>
    public partial class GunTypePage : Page
    {
        gun_typeTableAdapter gun_type = new gun_typeTableAdapter();
        public GunTypePage()
        {
            InitializeComponent();
            GunTypeGrid.ItemsSource = gun_type.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            if (GunTypeBox.Text == null || GunTypeBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else if ((double.TryParse(GunTypeBox.Text, out num)))
            {
                MessageBox.Show("Вы ввели число");
            }
            else
            {
                gun_type.InsertQuery(GunTypeBox.Text);
                GunTypeGrid.ItemsSource = gun_type.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (GunTypeGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
            else
            {
                int id = (int)(GunTypeGrid.SelectedValue as DataRowView).Row[0];
                gun_type.DeleteQuery(id);
                GunTypeGrid.ItemsSource = gun_type.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (GunTypeGrid.SelectedValue != null)
            {
                var item = GunTypeGrid.SelectedItem as DataRowView;
                gun_type.UpdateQuery(GunTypeBox.Text, (int)item.Row[0]);
                GunTypeGrid.ItemsSource = gun_type.GetData();

            }
        }

        private void GunTypeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GunTypeGrid.SelectedValue != null)
            {
                var item = GunTypeGrid.SelectedItem as DataRowView;
                GunTypeBox.Text = (string)item.Row[1];

            }
        }
    }
}
