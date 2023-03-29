using Laboratory_5.Lab5DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CaliberPage.xaml
    /// </summary>
    public partial class CaliberPage : Page
    {
        caliberTableAdapter caliber = new caliberTableAdapter();
        public CaliberPage()
        {
            InitializeComponent();
            CaliberGrid.ItemsSource = caliber.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CaliberBox.Text == null || CaliberBox.Text == "" || CaliberBox.Text.StartsWith("-"))
            {
                MessageBox.Show("Вы введи неправильные данные");
            }
            else
            {
                caliber.InsertQuery(CaliberBox.Text);
                CaliberGrid.ItemsSource = caliber.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CaliberGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
            else
            {
            int id = (int)(CaliberGrid.SelectedValue as DataRowView).Row[0];
            caliber.DeleteQuery(id);
            CaliberGrid.ItemsSource = caliber.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CaliberGrid.SelectedValue != null)
            {
                var item = CaliberGrid.SelectedItem as DataRowView;
                caliber.UpdateQuery(CaliberBox.Text, (int)item.Row[0]);
                CaliberGrid.ItemsSource = caliber.GetData();

            }
        }

        private void CaliberGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CaliberGrid.SelectedValue != null)
            {
                var item = CaliberGrid.SelectedItem as DataRowView;
                CaliberBox.Text = (string)item.Row[1];

            }
        }
    }
}
