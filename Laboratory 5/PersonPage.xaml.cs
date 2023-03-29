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
    /// Логика взаимодействия для PersonPage.xaml
    /// </summary>
    public partial class PersonPage : Page
    {
        personTableAdapter person = new personTableAdapter();
        roleTableAdapter role = new roleTableAdapter();
        public PersonPage()
        {
            InitializeComponent();
            PersonGrid.ItemsSource = person.GetData();
            ComboRoleId.ItemsSource = role.GetData();
            ComboRoleId.DisplayMemberPath = "role_name";
            ComboRoleId.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;

            if (SurnameBox.Text == null || NameBox.Text == null || LoginBox.Text == null || PasswordBox.Text == null || ComboRoleId.SelectedItem == null||SurnameBox.Text == "" || NameBox.Text == "" || LoginBox.Text == "" || PasswordBox.Text == "" || ComboRoleId.SelectedItem == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
            }
            else if ((double.TryParse(SurnameBox.Text, out num)) || (double.TryParse(NameBox.Text, out num)) || (double.TryParse(PatronymicBox.Text, out num)) || (double.TryParse(LoginBox.Text, out num)))
            {
                MessageBox.Show("Цифры не вводи сюда");
            }
            else
            {
                int id = (int)ComboRoleId.SelectedValue;
                person.InsertQuery(SurnameBox.Text, NameBox.Text, PatronymicBox.Text, id, LoginBox.Text, PasswordBox.Text);
                PersonGrid.ItemsSource = person.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PersonGrid.SelectedIndex == 0)
            {
                MessageBox.Show("Админа не удалить");
            }
            else if (PersonGrid.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать элеменет для удаления");
            }
            else
            {
                int id = (int)(PersonGrid.SelectedValue as DataRowView).Row[0];
                person.DeleteQuery(id);
                PersonGrid.ItemsSource = person.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (PersonGrid.SelectedValue != null)
            {
                var item = PersonGrid.SelectedItem as DataRowView;
                person.UpdateQuery(SurnameBox.Text, NameBox.Text, PatronymicBox.Text, (int)ComboRoleId.SelectedValue, LoginBox.Text, PasswordBox.Text, (int)item.Row[0]);
                PersonGrid.ItemsSource = person.GetData();

            }
        }

        private void PersonGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PersonGrid.SelectedValue != null)
            {
                var item = PersonGrid.SelectedItem as DataRowView;
                SurnameBox.Text = (string)item.Row[1];
                NameBox.Text = (string)item.Row[2];
                PatronymicBox.Text = (string)item.Row[3];
                ComboRoleId.SelectedValue = (int)item.Row[4];
                LoginBox.Text = (string)item.Row[5];
                PasswordBox.Text = (string)item.Row[6];
            }
        }
    }
}
