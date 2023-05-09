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
using WFB4;

namespace NHOM9
{
    /// <summary>
    /// Interaction logic for frmTimkiem.xaml
    /// </summary>
    public partial class frmTimkiem : Window
    {
        private System.ComponentModel.IContainer components = null;

        public frmTimkiem()
        {
            InitializeComponent();
        }

        private void btTimKiem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTimKiem.Text.Trim() == "")
                {
                    MessageBox.Show("Hãy nhập thông tin tìm kiếm ", "thông báo");
                }
                else
                {
                    string sql = "select * from tblNhanVien where Ho_Ten like N'%" + txtTimKiem.Text + "%'";
                    dgvMain.ItemsSource = TruyXuatCSDL.Laybang(sql).DefaultView;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "thông báo");
            }
        }

        private void btTroVe_Click(object sender, RoutedEventArgs e)
        {
            frmMain M = new frmMain();
            M.Show();
            this.Close();
        }
    }
}
