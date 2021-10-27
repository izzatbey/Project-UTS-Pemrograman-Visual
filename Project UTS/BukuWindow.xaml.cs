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
    /// Interaction logic for BukuWindow.xaml
    /// </summary>
    public partial class BukuWindow : Window
    {
        private DatabaseContext DatabaseContext;
        private int BukuId;
        private string Judul;
        private string Author;
        public BukuWindow(DatabaseContext dbContext)
        {
            InitializeComponent();
            DatabaseContext = dbContext;
            RefreshData();
        }

        private void BukuIDTextbox_TextChanged(object sender, TextChangedEventArgs e)
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
        private void JudulTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            Judul = JudulTextbox.Text;
        }
        private void AuthorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            Author = AuthorTextbox.Text;
        }
        private void ClearTextBox()
        {
            BukuIDTextbox.Text = "";
            JudulTextbox.Text = "";
            AuthorTextbox.Text = "";
        }

        private void RefreshData()
        {
            var result = DatabaseContext.Bukus.ToList();
            ListBukuDataGrid.ItemsSource = result;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow(DatabaseContext);
            this.Close();
            homeWindow.Show();
        }

        private void AddBukuButton_Click(object sender, RoutedEventArgs e)
        {
            var buku = new Buku() { Id = BukuId, NamaBuku = Judul, AuthorBuku = Author };
            DatabaseContext.Add(buku);
            DatabaseContext.SaveChanges();
            ClearTextBox();
            RefreshData();
        }

        private void DeleteBukuButton_Click(object sender, RoutedEventArgs e)
        {
            var buku = DatabaseContext.Bukus.First(b => b.Id == BukuId);
            DatabaseContext.Bukus.Remove(buku);
            DatabaseContext.SaveChanges();
            ClearTextBox();
            RefreshData();
        }

        private void UpdateBukuButton_Click(object sender, RoutedEventArgs e)
        {
            var buku = DatabaseContext.Bukus.First(b => b.Id == BukuId);
            buku.NamaBuku = Judul;
            buku.AuthorBuku = Author;
            DatabaseContext.SaveChanges();
            ClearTextBox();
            RefreshData();
        }
    }
}
