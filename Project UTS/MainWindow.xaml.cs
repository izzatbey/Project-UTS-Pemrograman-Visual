using Project_UTS.Config;
using Project_UTS.Model;
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

namespace Project_UTS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string Username;
        private string Password;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            DatabaseContext dbContext = new DatabaseContext();

            var resultUser = dbContext.Users.FirstOrDefault(u => u.Username == Username);
            if (resultUser != null)
            {
                if(resultUser.Password == Password)
                {
                    HomeWindow home = new HomeWindow(dbContext);
                    this.Close();
                    home.Show();
                } else
                {
                    MessageBox.Show("Akun Tidak Dikenal");
                }
            }
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            Username = UsernameTextBox.Text;
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            Password = PasswordTextBox.Text;
        }
    }
}
