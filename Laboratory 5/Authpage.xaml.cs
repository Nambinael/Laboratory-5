using Laboratory_5.Lab5DataSetTableAdapters;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Authpage.xaml
    /// </summary>
    public partial class Authpage : Page
    {
        Window window = new Window();
        personTableAdapter person = new personTableAdapter();
        public Authpage()
        {
            InitializeComponent();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            var alllogins = person.GetData().Rows;
            for (int i = 0; i < alllogins.Count; i++)
            {
                
                if (alllogins[i][5].ToString() == LoginTbx.Text && alllogins[i][6].ToString() == PasswordBx.Password) 
                {
                    int roleid = (int)alllogins[i][4];
                    switch (roleid)
                    {
                        case 1:
                            (Application.Current.MainWindow as MainWindow).MainFrame.Content = new AdminPage();
                            return;
                        case 3:
                            (Application.Current.MainWindow as MainWindow).MainFrame.Content = new PurchasePage();
                            return;

                    }
                }

            }
            MessageBox.Show("Вы ввели неправильные данные");

        }
    }
}
