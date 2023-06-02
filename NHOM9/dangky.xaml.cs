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
using System.Data.SqlClient;

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
        TruyXuatCSDL truyxuat = new TruyXuatCSDL();
        private bool TaiKhoanDaTonTai(string tenTaiKhoan)
        {
            string sql = "SELECT COUNT(*) FROM tblTaiKhoan WHERE Ten_TKhoan = N'" + tenTaiKhoan + "'";

            // Assuming you have a method named 'executeScalar' that executes the SQL command and returns the result as an object
            object result = truyxuat.executeScalar(sql);

            int count = 0;
            if (result != null && int.TryParse(result.ToString(), out count))
            {
                return count > 0;
            }

            return false;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string loaitaikhoan = "1";
                string matkhau = txtMatKhau.Password;
                string xacnhanmatkhau = txtMatKhau_Copy.Password;
                string tenTaiKhoan = txtTenTKhoan.Text;

                // Kiểm tra nếu có một trường thông tin không được nhập
                if (string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(matkhau) || string.IsNullOrEmpty(xacnhanmatkhau))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                else if (string.IsNullOrEmpty(tenTaiKhoan))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản");
                    return;
                }
                else if (string.IsNullOrEmpty(matkhau))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu");
                    return;
                }
                else if (string.IsNullOrEmpty(xacnhanmatkhau))
                {
                    MessageBox.Show("Vui lòng xác thực mật khẩu");
                    return;
                }
                else if (matkhau.Length < 8 || !matkhau.Any(char.IsDigit) || !matkhau.Any(char.IsLetter))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự và phải chứa cả chữ và số");
                    return;
                }

                if (TaiKhoanDaTonTai(tenTaiKhoan))
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại");
                    return;
                }

                if (matkhau == xacnhanmatkhau)
                {
                    string matkhauMaHoa = MaHoaMatKhau(matkhau);

                    string sql = "insert into tblTaiKhoan values(N'" + tenTaiKhoan + "', N'" + matkhauMaHoa + "', " +
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
