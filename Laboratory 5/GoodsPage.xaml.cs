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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Laboratory_5.Lab5DataSet;

namespace Laboratory_5
{
    /// <summary>
    /// Логика взаимодействия для GoodsPage.xaml
    /// </summary>
    public partial class GoodsPage : Page
    {
        goodsTableAdapter goods = new goodsTableAdapter();
        public GoodsPage()
        {
            InitializeComponent();
            GoodsGrid.ItemsSource = goods.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            if (NameBox.Text == null || NameBox.Text == "" || PriceBox.Text == null || PriceBox.Text == "" || AmmountBox.Text == null || AmmountBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else if ((double.TryParse(PriceBox.Text, out num)) && (double.TryParse(AmmountBox.Text, out num)))
            {
                if (Convert.ToInt32(PriceBox.Text) < 0  || (Convert.ToInt32(AmmountBox.Text) < 0))
                {
                    MessageBox.Show("Вы ввели отрицательное число");
                }
                else
                {
                    goods.InsertQuery(NameBox.Text, Convert.ToDecimal(PriceBox.Text), Convert.ToInt32(AmmountBox.Text));
                    GoodsGrid.ItemsSource = goods.GetData();
                }
            }
            else
            {
                MessageBox.Show("Введите ЦИФРЫ в поля с ценой и количеством");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (GoodsGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
            else
            {
                int id = (int)(GoodsGrid.SelectedValue as DataRowView).Row[0];
                goods.DeleteQuery(id);
                GoodsGrid.ItemsSource = goods.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (GoodsGrid.SelectedValue != null)
            {
                var item = GoodsGrid.SelectedItem as DataRowView;
                goods.UpdateQuery(NameBox.Text, Convert.ToDecimal(PriceBox.Text), Convert.ToInt32(AmmountBox.Text), (int)item.Row[0]);
                GoodsGrid.ItemsSource = goods.GetData();

            }
        }

        private void GoodsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GoodsGrid.SelectedValue != null)
            {
                var item = GoodsGrid.SelectedItem as DataRowView;
                NameBox.Text = (string)item.Row[1];
                PriceBox.Text = (Math.Round((decimal)item.Row[2], 2)).ToString();
                AmmountBox.Text = ((int)item.Row[3]).ToString();

            }
        }
    }
}
