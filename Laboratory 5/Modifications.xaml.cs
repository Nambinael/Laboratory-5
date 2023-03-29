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
    /// Логика взаимодействия для Modifications.xaml
    /// </summary>
    public partial class Modifications : Page
    {
        modificationsTableAdapter modifications = new modificationsTableAdapter();
        goodsTableAdapter goods = new goodsTableAdapter();
        manufacturerTableAdapter manufacturer = new manufacturerTableAdapter();
        modification_typeTableAdapter modification_Type = new modification_typeTableAdapter();
        public Modifications()
        {
            InitializeComponent();
            ModificationsGrid.ItemsSource = modifications.GetData();
            ComboGoodsId.ItemsSource = goods.GetData();
            ComboManufacturerId.ItemsSource = manufacturer.GetData();
            ComboModificationTypeId.ItemsSource = modification_Type.GetData();
            ComboGoodsId.DisplayMemberPath = "Name";
            ComboGoodsId.SelectedValuePath = "Id";
            ComboManufacturerId.DisplayMemberPath = "manufacturer_name";
            ComboManufacturerId.SelectedValuePath = "Id";
            ComboModificationTypeId.DisplayMemberPath = "modification_type_name";
            ComboModificationTypeId.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (ComboGoodsId.SelectedItem == null || ComboManufacturerId.SelectedItem == null || ComboModificationTypeId.SelectedItem == null)
            {
                MessageBox.Show("Выберите все поля для добавления");
            }
            else
            {
                var allid = modifications.GetData().Rows;

                bool didwefounddisshitornot = false;
                for (int i = 0; i < allid.Count; i++)
                {
                    if ((int)allid[i][0] == (int)ComboGoodsId.SelectedValue)
                    {
                        didwefounddisshitornot = true;
                        break;
                    }
                }
                if (didwefounddisshitornot)
                {
                    MessageBox.Show("Вы не можете добавить существующий товар");
                }
                else
                {
                    int id = (int)ComboGoodsId.SelectedValue;
                    int id1 = (int)ComboManufacturerId.SelectedValue;
                    int id2 = (int)ComboModificationTypeId.SelectedValue;
                    modifications.InsertQuery(id, id1, id2);
                    ModificationsGrid.ItemsSource = modifications.GetData();
                }
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ModificationsGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удлаения");
            }
            else
            {
                int id = (int)(ModificationsGrid.SelectedValue as DataRowView).Row[0];
                modifications.DeleteQuery(id);
                ModificationsGrid.ItemsSource = modifications.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ModificationsGrid.SelectedValue != null)
            {
                var item = ModificationsGrid.SelectedItem as DataRowView;
                modifications.UpdateQuery((int)ComboManufacturerId.SelectedValue, (int)ComboModificationTypeId.SelectedValue, (int)item.Row[0]);
                ModificationsGrid.ItemsSource = modifications.GetData();
            }
        }

        private void ModificationsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModificationsGrid.SelectedValue != null)
            {
                var item = ModificationsGrid.SelectedItem as DataRowView;
                ComboGoodsId.SelectedValue = (int)item.Row[0];
                ComboManufacturerId.SelectedValue = (int)item.Row[1];
                ComboModificationTypeId.SelectedValue = (int)item.Row[2];
            }
        }
    }
}
