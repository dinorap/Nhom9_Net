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
using System.Security.Cryptography;
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
                TruyXuatCSDL ac = new TruyXuatCSDL();
                string tk = txtTenTKhoan.Text;
                string mk = MaHoaMatKhau(txtMatKhau.Password); // Mã hóa mật khẩu

                // Kiểm tra nếu có thông tin tài khoản và mật khẩu
                if (!string.IsNullOrEmpty(txtTenTKhoan.Text) && !string.IsNullOrEmpty(txtMatKhau.Password))
                {
                    string sql = "select Loai_TKhoan from [tblTaiKhoan] where Ten_TKhoan = N'" + tk + "' and Mat_Khau = N'" + mk + "'";
                    object kq = ac.executeScalar(sql);

                    if (kq.ToString() == "1")
                    {
                        MessageBox.Show("Chào mừng user !!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        frmMain main = new frmMain(kq.ToString());

                        main.Show();
                        this.Hide();
                    }
                    else if (kq.ToString() == "0")
                    {
                        MessageBox.Show("Chào mừng Admin !!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        frmMain main = new frmMain(kq.ToString());

                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtTenTKhoan.SelectAll();
                        txtMatKhau.Clear();
                        txtTenTKhoan.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin tài khoản và mật khẩu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButton.OKCancel);
            if (traloi == MessageBoxResult.OK)
            {
                Environment.Exit(0);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            
            dangky TK = new dangky();
            TK.Show();
            this.Close();
        }
    }
}
