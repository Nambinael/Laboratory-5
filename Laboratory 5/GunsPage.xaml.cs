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
    /// Логика взаимодействия для GunsPage.xaml
    /// </summary>
    public partial class GunsPage : Page
    {
        gunsTableAdapter guns = new gunsTableAdapter();
        goodsTableAdapter goods = new goodsTableAdapter();
        gun_typeTableAdapter gun_type = new gun_typeTableAdapter();
        caliberTableAdapter caliber = new caliberTableAdapter();
        fire_modeTableAdapter fire_mode = new fire_modeTableAdapter();
        manufacturer_countryTableAdapter manufacturer_Country = new manufacturer_countryTableAdapter();
        public GunsPage()
        {
            InitializeComponent();
            GunsGrid.ItemsSource = guns.GetData();
            ComboGoodsId.ItemsSource = goods.GetData();
            ComboCaliberId.ItemsSource = caliber.GetData();
            ComboGunTypeId.ItemsSource = gun_type.GetData();
            ComboFireModeId.ItemsSource = fire_mode.GetData();
            ComboManufacturerId.ItemsSource = manufacturer_Country.GetData();
            ComboGoodsId.DisplayMemberPath = "Name";
            ComboGoodsId.SelectedValuePath = "Id";
            ComboCaliberId.DisplayMemberPath = "caliber_name";
            ComboCaliberId.SelectedValuePath = "Id";
            ComboGunTypeId.DisplayMemberPath = "gun_type_name";
            ComboGunTypeId.SelectedValuePath = "Id";
            ComboManufacturerId.DisplayMemberPath = "manufacturer_country_name";
            ComboManufacturerId.SelectedValuePath = "Id";
            ComboFireModeId.DisplayMemberPath = "fire_mode_name";
            ComboFireModeId.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboGoodsId.SelectedItem == null || ComboGunTypeId.SelectedItem == null || ComboCaliberId.SelectedItem == null || ComboManufacturerId.SelectedItem == null || ComboFireModeId.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать все поля");
            }
            else
            {
                var allid = guns.GetData().Rows;

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
                    int id1 = (int)ComboGunTypeId.SelectedValue;
                    int id2 = (int)ComboCaliberId.SelectedValue;
                    int id3 = (int)ComboManufacturerId.SelectedValue;
                    int id4 = (int)ComboFireModeId.SelectedValue;
                    guns.InsertQuery(id, id1, id2, id3, id4);
                    GunsGrid.ItemsSource = guns.GetData();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (GunsGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
            else
            {
                int id = (int)(GunsGrid.SelectedValue as DataRowView).Row[0];
                guns.DeleteQuery(id);
                GunsGrid.ItemsSource = guns.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (GunsGrid.SelectedValue != null)
            {
                var item = GunsGrid.SelectedItem as DataRowView;
                guns.UpdateQuery((int)ComboGunTypeId.SelectedValue, (int)ComboCaliberId.SelectedValue, (int)ComboManufacturerId.SelectedValue, (int)ComboFireModeId.SelectedValue, (int)item.Row[0]);
                GunsGrid.ItemsSource = guns.GetData();
            }
        }

        private void GunsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GunsGrid.SelectedValue != null)
            {
                var item = GunsGrid.SelectedItem as DataRowView;
                ComboGoodsId.SelectedValue = (int)item.Row[0];
                ComboGunTypeId.SelectedValue = (int)item.Row[1];
                ComboCaliberId.SelectedValue = (int)item.Row[2];
                ComboManufacturerId.SelectedValue = (int)item.Row[3];
                ComboFireModeId.SelectedValue = (int)item.Row[4];
            }
        }
    }
}
