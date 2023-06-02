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
    /// Interaction logic for frmDuAn.xaml
    /// </summary>
    public partial class frmDuAn : Window
    {
        public string LoaiTKhoan;
        bool isNew = false;
        public frmDuAn(string LoaiTKhoan)
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
                btnsua.Visibility = Visibility.Collapsed;
                btnthem.Visibility = Visibility.Collapsed;
                btnxoa.Visibility = Visibility.Collapsed;
                btnreset.Visibility = Visibility.Collapsed;
            }
            else
            {
                mniDanhMuc.Visibility = Visibility.Visible;
                mi_QLHT.Visibility = Visibility.Visible;
                mi_QLHS.Visibility = Visibility.Visible;
            }
        }
        public frmDuAn()
        {
            InitializeComponent();
        }
        private void UpdateHeaderNames()
        {
            dgvMain.Columns[0].Header = "Id dự án ";
            dgvMain.Columns[1].Header = "Mã dự án ";
            dgvMain.Columns[2].Header = "Tên dự án ";
            dgvMain.Columns[3].Header = "Số nhân viên ";
            dgvMain.Columns[4].Header = "Mô tả dự án";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblDuAn").DefaultView;
            dgvMain.Columns[0].Visibility = Visibility.Collapsed; // Ẩn cột ; 
            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            UpdateHeaderNames();
            btnxoa.IsEnabled = false;
            btnsua.IsEnabled = false;
        }
        string sID = "";
        private void dgvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnxoa.IsEnabled = true;
            btnsua.IsEnabled = true;
            DataRowView obj = dgvMain.SelectedItem as DataRowView;
            if (obj == null)
            {
                txtid.Text = "";
                txtten.Text = "";
                txtso.Text = "";
                txtchuthich.Text = "";
                return;
                btnxoa.IsEnabled = false;
                btnsua.IsEnabled = false;
            }

            txtid.Text = obj["id_Da"]?.ToString();
            txtten.Text = obj["name_Da"]?.ToString();
            txtso.Text = obj["Sonv_Da"]?.ToString();
            txtchuthich.Text = obj["Mota_Da"]?.ToString();
            sID = obj["id_Da"].ToString();
        }

        private void btnreset_Click(object sender, RoutedEventArgs e)
        {
            txtid.Text = "";
            txtten.Text = "";
            txtso.Text = "";
            txtchuthich.Text = "";
            return;
        }
        private void CapNhat(string sql)
        {
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblDuAn").DefaultView;
            dgvMain.Columns[0].Visibility = Visibility.Collapsed; // Ẩn cột ; 
            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            UpdateHeaderNames();
        }
        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            if (isNew)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtid.Text) || string.IsNullOrEmpty(txtten.Text) || string.IsNullOrEmpty(txtso.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                        return;
                    }
                    string sql = "insert into tblDuAn values(N'" + txtid.Text + "', N'" + txtten.Text + "', " +
                   "N'" + txtso.Text + "', N'" + txtchuthich.Text + "')";
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
                    if (string.IsNullOrEmpty(txtid.Text) || string.IsNullOrEmpty(txtten.Text) || string.IsNullOrEmpty(txtso.Text) )
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                        return;
                    }
                    string sql = "update tblDuAn set ma_Da=N'" + txtid.Text + "',name_Da=N'" + txtten.Text + "',sonv_Da=" + txtso.Text + ", mota_Da=N'" + txtchuthich.Text + "' where id_Da=N'" + sID + "'";

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
            txtid.Focus();
        }
        private void SetObjectState(bool Editing = false)
        {
            btnthem.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btboqua.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btnreset.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            Editing = !Editing;
            btthemmoi.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btnsua.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btnxoa.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btntrove.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;

            dgvMain.IsEnabled = Editing;
        }
        private void btthemmoi_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState(true);
            isNew = true;
            txtid.Focus();
        }

        private void btboqua_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState();
        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from tblDuAn  where id_Da=N'" + sID + "'";

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

        private void btntrove_Click(object sender, RoutedEventArgs e)
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
