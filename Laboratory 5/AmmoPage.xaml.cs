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
    /// Логика взаимодействия для AmmoPage.xaml
    /// </summary>
    public partial class AmmoPage : Page
    {
        ammoTableAdapter ammo = new ammoTableAdapter();
        goodsTableAdapter goods = new goodsTableAdapter();
        caliberTableAdapter caliber = new caliberTableAdapter();

        public AmmoPage()
        {
            InitializeComponent();
            AmmoGrid.ItemsSource = ammo.GetData();
            ComboGoodsId.ItemsSource = goods.GetData();
            ComboCaliberId.ItemsSource = caliber.GetData();
            ComboGoodsId.DisplayMemberPath = "Name";
            ComboGoodsId.SelectedValuePath = "Id";
            ComboCaliberId.DisplayMemberPath = "caliber_name";
            ComboCaliberId.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
            if (ComboGoodsId.SelectedItem == null || ComboCaliberId.SelectedItem == null || NomenclatureBox.Text == null || NomenclatureBox.Text == "")
            {
                MessageBox.Show("Введите данные во все поля");
            }
            else
            {
                var allid = ammo.GetData().Rows;

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
                    int id1 = (int)ComboCaliberId.SelectedValue;
                    ammo.InsertQuery(id, id1, NomenclatureBox.Text);
                    AmmoGrid.ItemsSource = ammo.GetData();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (AmmoGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
            else
            {
                int id = (int)(AmmoGrid.SelectedValue as DataRowView).Row[0];
                ammo.DeleteQuery(id);
                AmmoGrid.ItemsSource = ammo.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (AmmoGrid.SelectedValue != null)
            {
                var item = AmmoGrid.SelectedItem as DataRowView;
                ammo.UpdateQuery((int)ComboCaliberId.SelectedValue, NomenclatureBox.Text, (int)item.Row[0]);
                AmmoGrid.ItemsSource = ammo.GetData();

            }
        }

        private void AmmoGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AmmoGrid.SelectedValue != null)
            {
                var item = AmmoGrid.SelectedItem as DataRowView;
                ComboGoodsId.SelectedValue = (int)item.Row[0];
                ComboCaliberId.SelectedValue = (int)item.Row[1];
                NomenclatureBox.Text = (string)item.Row[2];
            }
        }
    }
}
