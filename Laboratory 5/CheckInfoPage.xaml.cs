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
    /// Логика взаимодействия для CheckInfoPage.xaml
    /// </summary>
    public partial class CheckInfoPage : Page
    {
        check_infoTableAdapter check_info = new check_infoTableAdapter();
        personTableAdapter person = new personTableAdapter();
        roleTableAdapter role = new roleTableAdapter();
        public CheckInfoPage()
        {
            InitializeComponent();
            CheckInfoGrid.ItemsSource = check_info.GetData();
            ComboRoleId.ItemsSource = person.GetData();
            ComboRoleId.DisplayMemberPath = "surname";
            ComboRoleId.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboRoleId.SelectedItem == null || DateBox.SelectedDate == null)
            {
                MessageBox.Show("Необходимо выбрать все данные");            
            }
            else
            {
                int id = (int)ComboRoleId.SelectedValue;
                DateTime date = (DateTime)DateBox.SelectedDate;
                check_info.InsertQuery(id, date.ToString());
                CheckInfoGrid.ItemsSource = check_info.GetData();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CheckInfoGrid.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать элемент для удаления");
            }
            else 
            { 
                int id = (int)(CheckInfoGrid.SelectedValue as DataRowView).Row[0];
                check_info.DeleteQuery(id);
                CheckInfoGrid.ItemsSource = check_info.GetData();            
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CheckInfoGrid.SelectedValue != null)
            {
                var item = CheckInfoGrid.SelectedItem as DataRowView;
                check_info.UpdateQuery((int)ComboRoleId.SelectedValue, Convert.ToString((DateTime)DateBox.SelectedDate), (int)item.Row[0]);
                CheckInfoGrid.ItemsSource = check_info.GetData();
            }
        }

        private void CheckInfoGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckInfoGrid.SelectedValue != null)
            {
                var item = CheckInfoGrid.SelectedItem as DataRowView;
                ComboRoleId.SelectedValue = (int)item.Row[1];
                DateBox.SelectedDate = (DateTime)item.Row[2];
            }
        }
    }
}
