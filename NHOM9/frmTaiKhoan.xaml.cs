using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for frmTaiKhoan.xaml
    /// </summary>
    public partial class frmTaiKhoan : Window
    {
        bool isNew = false;
        public string LoaiTKhoan;
        public frmTaiKhoan(string LoaiTKhoan)
        {
            this.LoaiTKhoan = LoaiTKhoan;
            InitializeComponent();
            InitializeComponent();
            if (LoaiTKhoan == "1")
            {
                mniDanhMuc.Visibility = Visibility.Collapsed;
                mi_QLHT.Visibility = Visibility.Collapsed;
                mi_QLHS.Visibility = Visibility.Visible;
            }
            else
            {

                mniDanhMuc.Visibility = Visibility.Visible;
                mi_QLHT.Visibility = Visibility.Visible;
                mi_QLHS.Visibility = Visibility.Visible;
            }
        }
        string sID = "";
        
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        private void CapNhat(string sql)
        {
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select id,Ten_TKhoan,Mat_khau,Loai_TKhoan from tblTaiKhoan").DefaultView; ;
            UpdateHeaderNames();
        }
        private void UpdateHeaderNames()
        {
            dgvMain.Columns[0].Header = "ID ";
            dgvMain.Columns[1].Header = "Tài khoản ";
            dgvMain.Columns[2].Header = "Mật khẩu ";
            dgvMain.Columns[3].Header = "Loại tài khoản ";
        }
        private void LoadData()
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select id, Ten_TKhoan, Mat_khau, Loai_TKhoan from tblTaiKhoan").DefaultView;

            dgvMain.Columns[0].Visibility = Visibility.Collapsed; // Ẩn cột ; 
            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);

            UpdateHeaderNames();

            bbtXoa.IsEnabled = false;
            btSua.IsEnabled = false;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
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
        private void anma(object sender, RoutedEventArgs e)
        {
            LoadData();
            btthemmoi_Copy.Visibility = Visibility.Visible;
        }

        private void mahoa(object sender, RoutedEventArgs e)
        {
            CapNhatBangDuLieu();
            btthemmoi_Copy.Visibility = Visibility.Hidden;
        }
        private void CapNhatBangDuLieu()
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblTaiKhoan").DefaultView;

            dgvMain.Columns[0].Visibility = Visibility.Collapsed; // Ẩn cột ; 
            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);

            UpdateHeaderNames();

            dgvMain.Columns[4].Header = "Mật khẩu được giải mã";
        }


        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            if (isNew)
            {
                try
                {
                    string matkhau = txtMatKhau.Password;
                    string matkhauMaHoa = MaHoaMatKhau(matkhau);
                    string sql = "insert into tblTaiKhoan values(N'" + txtTaiKhoan.Text + "', N'" + matkhauMaHoa + "', " +
                   "N'" + txtLoaiTaiKhoan.Text + "', N'" + matkhau + "')";
                    CapNhat(sql);
                    MessageBox.Show("Đã thêm");
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm Thất bại");
                }
            }
            else
            {
                try
                {
                    string matkhau = txtMatKhau.Password;
                    string matkhauMaHoa = MaHoaMatKhau(matkhau);
                    string sql = "update tblTaiKhoan set Ten_TKhoan=N'" + txtTaiKhoan.Text + "',Mat_Khau=N'"
                     + txtMatKhau.Password + "',Loai_TKhoan=N'"
                     + txtLoaiTaiKhoan.Text + "', N'" + matkhau + "'where id=" + sID;
                    CapNhat(sql);
                    MessageBox.Show("Đã sửa");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa Thất bại" + ex.Message);
                }
            }
            SetObjectState();
        }
        private void bbtXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from tblTaiKhoan   where id=" + sID;
                CapNhat(sql);
                MessageBox.Show("Đã xóa");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa Thất bại");
            }
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblTaiKhoan").DefaultView;
            txtTaiKhoan.Text = "";
            txtMatKhau.Password = "";
            txtLoaiTaiKhoan.Text = "";
            txtTaiKhoan.Focus();
        }

        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState(true);
            isNew = false;
            txtTaiKhoan.Focus();
        }
        private void SetObjectState(bool Editing = false)
        {
            btThem.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btboqua.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btReset.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            Editing = !Editing;
            btthemmoi.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btSua.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            bbtXoa.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btTroVe.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;

            dgvMain.IsEnabled = Editing;
        }
        private void btthemmoi_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState(true);
            isNew = true;
            txtTaiKhoan.Focus();
        }

        private void btboqua_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState();
        }


        private void dgvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bbtXoa.IsEnabled = false;
            btSua.IsEnabled = false;
            if (dgvMain.SelectedItem == null) return;
            DataRowView dataRow = dgvMain.SelectedItem as DataRowView;
            if (dataRow != null)
            {
                bbtXoa.IsEnabled = true;
                btSua.IsEnabled = true;
                txtTaiKhoan.Text = dataRow["Ten_TKhoan"].ToString();
                txtMatKhau.Password = dataRow["Mat_Khau"].ToString();
                txtLoaiTaiKhoan.Text = dataRow["Loai_TKhoan"].ToString();
                sID = dataRow["id"].ToString();
            }
            else
            {
                txtTaiKhoan.Text = "";
                txtMatKhau.Password = "";
                txtLoaiTaiKhoan.Text = "";
            }
        }


       

        private void btTroVe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmMain main = new frmMain(LoaiTKhoan);
            main.Show();

        }
        private void mi_TimKiem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmTimkiem TK = new frmTimkiem(LoaiTKhoan);
            TK.Owner = Application.Current.MainWindow;
            TK.Show();

        }

        private void mi_QLTK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmTaiKhoan TK = new frmTaiKhoan(LoaiTKhoan);
            TK.Owner = Application.Current.MainWindow;
            TK.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmChucVu CV = new frmChucVu(LoaiTKhoan);
            CV.Owner = Application.Current.MainWindow;
            CV.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmDuAn DA = new frmDuAn(LoaiTKhoan);
            DA.Owner = Application.Current.MainWindow;
            DA.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmThongKe TK = new frmThongKe(LoaiTKhoan);
            TK.Owner = Application.Current.MainWindow;
            TK.Show();
        }

        private void mi_thoat_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButton.OKCancel);
            if (traloi == MessageBoxResult.OK)
            {
                this.Close();
                frmLogin lg = new frmLogin();
                lg.Show();

            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmNhanVien NV = new frmNhanVien(LoaiTKhoan);
            NV.Owner = Application.Current.MainWindow;
            NV.Show();
        }
        
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmPhongBan PB = new frmPhongBan(LoaiTKhoan);
            PB.Owner = Application.Current.MainWindow;
            PB.Show();
        }

        
    }
}
