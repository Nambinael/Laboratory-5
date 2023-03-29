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
    /// Логика взаимодействия для MoficationsTypePage.xaml
    /// </summary>
    public partial class MoficationsTypePage : Page
    {
        modification_typeTableAdapter ModificationType = new modification_typeTableAdapter();
        public MoficationsTypePage()
        {
            InitializeComponent();
            ModificationTypeGrid.ItemsSource = ModificationType.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            if (ModificationTypeBox.Text == null || ModificationTypeBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else if ((double.TryParse(ModificationTypeBox.Text, out num)))
            {
                MessageBox.Show("Вы ввели число");
            }
            else
            {
                ModificationType.InsertQuery(ModificationTypeBox.Text);
                ModificationTypeGrid.ItemsSource = ModificationType.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ModificationTypeGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
            else
            {
            int id = (int)(ModificationTypeGrid.SelectedValue as DataRowView).Row[0];
            ModificationType.DeleteQuery(id);
                ModificationTypeGrid.ItemsSource = ModificationType.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ModificationTypeGrid.SelectedValue != null)
            {
                var item = ModificationTypeGrid.SelectedItem as DataRowView;
                ModificationType.UpdateQuery(ModificationTypeBox.Text, (int)item.Row[0]);
                ModificationTypeGrid.ItemsSource = ModificationType.GetData();

            }
        }

        private void ModificationsTypeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModificationTypeGrid.SelectedValue != null)
            {
                var item = ModificationTypeGrid.SelectedItem as DataRowView;
                ModificationTypeBox.Text = (string)item.Row[1];

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<ModificationTypeModel> forImport = DeserializeClass.DeserializeObject<List<ModificationTypeModel>>();
            foreach (var item in forImport)
            {
                ModificationType.InsertQuery(item.modification_type_name);

            }
            ModificationTypeGrid.ItemsSource = null;
            ModificationTypeGrid.ItemsSource = ModificationType.GetData();
        }
    }
}
