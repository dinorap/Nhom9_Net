using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TruyXuatCSDL ac = new TruyXuatCSDL();
                string tk = txtTenTKhoan.Text;
                string mk = txtMatKhau.Password;
                string sql = "select Loai_TKhoan from [tblTaiKhoan] where Ten_TKhoan =N'" + tk + "'and Mat_Khau =N'" + mk + "'";//USER LÀ TỪ KHÓA RIÊNG CỦA SQL SERVER VÌ VẬY PHẢI ĐẶT NGOẶC VUÔNG BÊN NGOÀI ĐỂ LÀM RÕ USER LÀ ĐỐI TƯỢNG BẢNG CỦA DATABASE CHỨ KHÔNG PHẢI TỪ KHÓA CỦA SQL
                object kq = ac.executeScalar(sql);
                if (kq.ToString() == "1")
                {
                    MessageBox.Show("Chào mừng user !!", "Thông báo");
                    frmMain main = new frmMain(kq.ToString());
                    main.Show();
                    this.Hide();
                }
                else if (kq.ToString() == "0")
                {
                    MessageBox.Show("Chào mừng Admin !!", "Thông báo");

                    frmMain main = new frmMain(kq.ToString());
                    main.Show();
                    this.Hide();

                }
                else {
                    MessageBox.Show("Đăng nhập thất bại", "Thông báo");
                    txtTenTKhoan.SelectAll();
                    txtMatKhau.Clear();
                    txtTenTKhoan.Focus();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
