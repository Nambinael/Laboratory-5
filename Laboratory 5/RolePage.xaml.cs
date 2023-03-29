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
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        roleTableAdapter Role = new roleTableAdapter();
        public RolePage()
        {
            InitializeComponent();
            RoleGrid.ItemsSource = Role.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            if (RoleBox.Text == null || RoleBox.Text == "")
            {
                MessageBox.Show("Введите данные в поля");
            }
            else if ((double.TryParse(RoleBox.Text, out num)))
            {
                MessageBox.Show("Вы ввели число");
            }
            else
            {
                Role.InsertQuery(RoleBox.Text);
                RoleGrid.ItemsSource = Role.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (RoleGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
            else
            {
                int id = (int)(RoleGrid.SelectedValue as DataRowView).Row[0];
                Role.DeleteQuery(id);
                RoleGrid.ItemsSource = Role.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (RoleGrid.SelectedValue != null)
            {
                var item = RoleGrid.SelectedItem as DataRowView;
                Role.UpdateQuery(RoleBox.Text, (int)item.Row[0]);
                RoleGrid.ItemsSource = Role.GetData();

            }
        }

        private void RoleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleGrid.SelectedValue != null)
            {
                var item = RoleGrid.SelectedItem as DataRowView;
                RoleBox.Text = (string)item.Row[1];

            }
        }
    }
}
