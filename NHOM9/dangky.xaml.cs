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
using System.Security.Cryptography;
using WFB4;
namespace NHOM9
{
    /// <summary>
    /// Interaction logic for dangky.xaml
    /// </summary>
    public partial class dangky : Window
    {
        public dangky()
        {
            InitializeComponent();
        }
        private void CapNhat(string sql)
        {
            TruyXuatCSDL.ThemSuaXoa(sql);
        }
        private string MaHoaMatKhau(string matkhau)
        {
            using (SHA256 sha256 = new SHA256Managed())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(matkhau);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string loaitaikhoan = "1";
                string matkhau = txtMatKhau.Password;
                string xacnhanmatkhau = txtMatKhau_Copy.Password;

                if (matkhau == xacnhanmatkhau)
                {
                    string matkhauMaHoa = MaHoaMatKhau(matkhau);

                    string sql = "insert into tblTaiKhoan values(N'" + txtTenTKhoan.Text + "', N'" + matkhauMaHoa + "', " +
                        "N'" + loaitaikhoan + "', N'" + matkhau + "')";
                    CapNhat(sql);
                    MessageBox.Show("Đăng ký thành công");
                    frmLogin lg = new frmLogin();
                    lg.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đăng ký thất bại");
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            frmLogin lg = new frmLogin();
            lg.Show();
            this.Close();
        }
    }
}
