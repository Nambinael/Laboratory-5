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
    /// Логика взаимодействия для PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        goodsTableAdapter goods = new goodsTableAdapter();
        checkTableAdapter check = new checkTableAdapter();
        personTableAdapter person = new personTableAdapter();
        public PurchasePage()
        {
            InitializeComponent();
            GoodsGrid.ItemsSource = goods.GetData();
            CheckGrid.ItemsSource = check.GetData();
            ComboRoleId.ItemsSource = person.GetData();
            ComboRoleId.SelectedValuePath = "Id";
            ComboRoleId.DisplayMemberPath = "surname";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsGrid.SelectedValue == null || ComboRoleId.SelectedItem == null)
            {
                MessageBox.Show("Вам нужно выбрать все данные");
            }
            else
            {
                var item = GoodsGrid.SelectedItem as DataRowView;
                int id1 = (int)ComboRoleId.SelectedValue;
                check.InsertQuery(id1, (int)item.Row[0]);
                CheckGrid.ItemsSource = check.GetData();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CheckGrid.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать элемент из чека для удаления");
            }
            else
            {
                int id = (int)(CheckGrid.SelectedValue as DataRowView).Row[0];
                check.DeleteQuery(id);
                CheckGrid.ItemsSource = check.GetData();
            }
        }
    }
}
