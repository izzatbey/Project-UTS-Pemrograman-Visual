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
using System.Windows.Shapes;

namespace Project_UTS
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private DatabaseContext DatabaseContext;
        private int PinjamId;
        private int BukuId;
        private int UserId;
        public HomeWindow(DatabaseContext dbContext)
        {
            InitializeComponent();
            DatabaseContext = dbContext;
            RefreshData();
        }

        private void IDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            try
            {
                PinjamId = int.Parse(textBox.Text);
            }
            catch (Exception)
            {
                PinjamId = 1;
            }
        }

        private void BukuIDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            try
            {
                BukuId = int.Parse(textBox.Text);
            }
            catch (Exception)
            {
                BukuId = 1;
            }
        }

        private void UserIDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            try
            {
                UserId = int.Parse(textBox.Text);
            }
            catch (Exception)
            {
                UserId = 1;
            }
        }

        private void ClearTextBox()
        {
            IDTextBox.Text = "";
            BukuIDTextbox.Text = "";
            UserIDTextBox.Text = "";
        }

        private void RefreshData()
        {
            var result = DatabaseContext.Peminjamans.ToList();
            PeminjamanDataGrid.ItemsSource = result;
        }

        private void SimpanButton_Click(object sender, RoutedEventArgs e)
        {
            var peminjaman = new Peminjaman() { Id = PinjamId, bukuId = BukuId, userId = UserId };
            DatabaseContext.Add(peminjaman);
            DatabaseContext.SaveChanges();
            ClearTextBox();
            RefreshData();
        }

        private void ListBukuButton_Click(object sender, RoutedEventArgs e)
        {
            BukuWindow bukuWindow = new BukuWindow(DatabaseContext);
            this.Close();
            bukuWindow.Show();
        }

        private void HapusButton_Click(object sender, RoutedEventArgs e)
        {
            var peminjaman = DatabaseContext.Peminjamans.First(p => p.Id == PinjamId);
            DatabaseContext.Peminjamans.Remove(peminjaman);
            DatabaseContext.SaveChanges();
            ClearTextBox();
            RefreshData();
        }

        private void UpdateButton_lick(object sender, RoutedEventArgs e)
        {
            var peminjaman = DatabaseContext.Peminjamans.First(p => p.Id == PinjamId);
            peminjaman.bukuId = BukuId;
            peminjaman.userId = UserId;
            DatabaseContext.SaveChanges();
            ClearTextBox();
            RefreshData();
        }
    }
}
