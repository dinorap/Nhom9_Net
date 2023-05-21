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

namespace NHOM9
{
    /// <summary>
    /// Interaction logic for frmChucVu.xaml
    /// </summary>
    public partial class frmChucVu : Window
    {
        public string LoaiTKhoan;
        bool isNew = false;
        public frmChucVu(string LoaiTKhoan)
        {
            this.LoaiTKhoan = LoaiTKhoan;
            InitializeComponent();
            if (LoaiTKhoan == "1")
            {
                mniDanhMuc.Visibility = Visibility.Visible;
                mi_QLHT.Visibility = Visibility.Collapsed;
                mi_QLHS.Visibility = Visibility.Visible;
                btboqua.Visibility = Visibility.Collapsed;
                btthemmoi.Visibility = Visibility.Collapsed;
                btnSua.Visibility = Visibility.Collapsed;
                btnThem.Visibility = Visibility.Collapsed;
                btnXoa.Visibility = Visibility.Collapsed;
                button2.Visibility = Visibility.Collapsed;
            }
            else
            {
                mniDanhMuc.Visibility = Visibility.Visible;
                mi_QLHT.Visibility = Visibility.Visible;
                mi_QLHS.Visibility = Visibility.Visible;
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine(LoaiTKhoan);
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
            System.Console.WriteLine(LoaiTKhoan);
            frmChucVu CV = new frmChucVu(LoaiTKhoan);
            CV.Owner = Application.Current.MainWindow;
            CV.Show(); this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            frmDuAn DA = new frmDuAn(LoaiTKhoan);
            DA.Owner = Application.Current.MainWindow;
            DA.Show();
            this.Close();
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
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (isNew)
            {
                try
                {
                    string sql = "insert into tblChuVu values(N'" + txtidchucvu.Text + "', N'" + txtmachucvu.Text + "', " +
                   "N'" + txttenchucvu.Text + "', N'" + txtghichu.Text + "')";
                    CapNhat(sql);
                    MessageBox.Show("Đã thêm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm Thất bại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                try
                {
                    string sql = "update tblChuVu set ID_ChucVu=N'" + txtidchucvu.Text + "',Ma_ChucVu=N'" + txtmachucvu.Text + "',Ten_ChuVu=N'"
                     + txttenchucvu.Text + "', Ghi_Chu=N'" + txtghichu.Text + "' where ID_ChucVu=" + txtidchucvu.Text + "";

                    CapNhat(sql);
                    MessageBox.Show("Đã sửa", "Thông báo",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa Thất bại", "Thông báo",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            SetObjectState();
        }
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState(true);
            isNew = false;
            txtidchucvu.Focus();
        }
        private void SetObjectState(bool Editing = false)
        {
            btnThem.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btboqua.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            button2.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            Editing = !Editing;
            btthemmoi.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btnSua.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btnXoa.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            button1.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;

            dgvMain.IsEnabled = Editing;
        }

        public frmChucVu()
        {
            InitializeComponent();
        }

        private void UpdateHeaderNames()
        {
            dgvMain.Columns[0].Header = "ID chức vụ";
            dgvMain.Columns[1].Header = "Mã chức vụ";
            dgvMain.Columns[2].Header = "Tên chức vụ";
            dgvMain.Columns[3].Header = "Ghi chú";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblChuVu").DefaultView;

            dgvMain.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Star);

            // cột cuối cùng tự động căn chỉnh kích thước theo chiều rộng còn lại của DataGrid
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);


            cbhoten.ItemsSource = TruyXuatCSDL.LayDanhSach("select distinct Ten_ChuVu from tblChuVu");
            cbhoten.SelectedIndex = 0;
            UpdateHeaderNames();
            btnXoa.IsEnabled = false;
            btnSua.IsEnabled = false;

        }


        private void dgvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = true;
            DataRowView obj = dgvMain.SelectedItem as DataRowView;
            if (obj == null)
            {
                btnXoa.IsEnabled = false;
                btnSua.IsEnabled = false;
                txtidchucvu.Text = "";
                txtmachucvu.Text = "";
                txttenchucvu.Text = "";
                txtghichu.Text = "";
                return;
            }
            txtidchucvu.Text = obj["ID_ChucVu"]?.ToString();
            txtmachucvu.Text = obj["Ma_ChucVu"]?.ToString();
            txttenchucvu.Text = obj["Ten_ChuVu"]?.ToString();
            txtghichu.Text = obj["Ghi_Chu"]?.ToString();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            txtidchucvu.Text = "";
            txtmachucvu.Text = "";
            txttenchucvu.Text = "";
            txtghichu.Text = "";
            return;
        }

        private void CapNhat(string sql)
        {
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblChuVu").DefaultView;
            UpdateHeaderNames();
        }

        private void btthemmoi_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState(true);
            isNew = true;
            txtidchucvu.Focus();
        }

        private void btboqua_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState();
        }


        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from tblChuVu where ID_ChucVu=" + txtidchucvu.Text + "";

                CapNhat(sql);
                MessageBox.Show("Đã xóa", "Thông báo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa Thất bại", "Thông báo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cbhoten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbhoten.SelectedItem == "All")
            {
                dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblChuVu").DefaultView;
            }
            else
            {
                dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblChuVu  where Ten_ChuVu = N'" + cbhoten.SelectedItem + "'").DefaultView;
            }
        }

    }
}