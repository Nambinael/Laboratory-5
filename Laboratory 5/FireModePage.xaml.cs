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
    /// Логика взаимодействия для FireModePage.xaml
    /// </summary>
    public partial class FireModePage : Page
    {
        fire_modeTableAdapter fire_mode = new fire_modeTableAdapter();
        public FireModePage()
        {
            InitializeComponent();
            FireModeGrid.ItemsSource = fire_mode.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            if (fire_modeBox.Text == null || fire_modeBox.Text == "")
            {
                MessageBox.Show("Заполните поле ввода");
            }
            else if ((double.TryParse(fire_modeBox.Text, out num)))
            {
                MessageBox.Show("Вы ввели число");
            }
            else
            {
            fire_mode.InsertQuery(fire_modeBox.Text);
            FireModeGrid.ItemsSource = fire_mode.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (FireModeGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
            else 
            { 
            int id = (int)(FireModeGrid.SelectedValue as DataRowView).Row[0];
            fire_mode.DeleteQuery(id);
            FireModeGrid.ItemsSource = fire_mode.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (FireModeGrid.SelectedValue != null)
            {
                var item = FireModeGrid.SelectedItem as DataRowView;
                fire_mode.UpdateQuery(fire_modeBox.Text, (int)item.Row[0]);
                FireModeGrid.ItemsSource = fire_mode.GetData();

            }
        }

        private void FireModeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FireModeGrid.SelectedValue != null)
            {
                var item = FireModeGrid.SelectedItem as DataRowView;
                fire_modeBox.Text = (string)item.Row[1];

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<FireModeModel> forImport = DeserializeClass.DeserializeObject<List<FireModeModel>>();
            foreach (var item in forImport)
            {
                fire_mode.InsertQuery(item.fire_mode_name);

            }
            FireModeGrid.ItemsSource = null;
            FireModeGrid.ItemsSource = fire_mode.GetData();

        }
    }
}
