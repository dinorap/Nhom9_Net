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

namespace NHOM9
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        public frmMain(String LoaiTKhoan)
        {
            InitializeComponent();
            if (LoaiTKhoan == "0")
            {
                mniDanhMuc.IsEnabled = true;
                mi_QLHT.IsEnabled = true;
                mi_QLHS.IsEnabled = true;
            }
            else
            {
                mniDanhMuc.IsEnabled = false;
                mi_QLHT.IsEnabled = false;
                mi_QLHS.IsEnabled = true;
            }
        }
        public frmMain()
        {
            InitializeComponent();
        }
        private void mi_thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mi_TimKiem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmTimkiem TK = new frmTimkiem();
            TK.Show();
        }

        private void mi_QLTK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmTaiKhoan TK = new frmTaiKhoan();
            TK.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmChucVu CV = new frmChucVu();
            CV.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmDuAn DA = new frmDuAn();
            DA.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            frmThongKe TK = new frmThongKe();
            TK.Show();
        }

        private void mi_thoat_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
