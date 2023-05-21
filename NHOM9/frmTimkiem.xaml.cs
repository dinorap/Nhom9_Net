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
        public string LoaiTKhoan;
        public frmTimkiem(string LoaiTKhoan)
        {
            this.LoaiTKhoan = LoaiTKhoan;
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
        private System.ComponentModel.IContainer components = null;

        public frmTimkiem()
        {
            InitializeComponent();
        }
        private void UpdateHeaderNames()
        {
            dgvMain.Columns[0].Header = "ID nhân viên";
            dgvMain.Columns[1].Header = "Mã chức vụ";
            dgvMain.Columns[2].Header = "Tên phòng ban";
            dgvMain.Columns[3].Header = "Họ tên";
            dgvMain.Columns[4].Header = "Ngày sinh";
            dgvMain.Columns[5].Header = "Giới tính";
            dgvMain.Columns[6].Header = "Quê quán";
            dgvMain.Columns[7].Header = "Số CCCD";
            dgvMain.Columns[8].Header = "Lương";
            dgvMain.Columns[9].Header = "Số điện thoại";
            dgvMain.Columns[10].Header = "Số tài khoản";
            dgvMain.Columns[11].Header = "Ngày vào làm";
        }
        private void btTimKiem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTimKiem.Text.Trim() == "")
                {
                    MessageBox.Show("Hãy nhập thông tin tìm kiếm", "thông báo");
                }
                else
                {
                    string sql;
                    if (radio1.IsChecked == true)
                    {
                        sql = "select * from tblNhanVien where Ho_Ten like N'%" + txtTimKiem.Text + "%'";
                    }
                    else if (radio2.IsChecked == true)
                    {
                        int id;
                        if (int.TryParse(txtTimKiem.Text.Trim(), out id))
                        {
                            sql = "select * from tblNhanVien where ID_NhanVien = '" + id + "'";
                        }
                        else
                        {
                            MessageBox.Show("ID phải là một số nguyên", "Lỗi");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn tiêu chí tìm kiếm", "thông báo");
                        return;
                    }
                    var dataTable = TruyXuatCSDL.Laybang(sql);
                    UpdateHeaderNames();
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy bản ghi nào phù hợp", "Thông báo");
                    }
                    else
                    {
                        dgvMain.ItemsSource = dataTable.DefaultView;
                        dgvMain.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[5].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[6].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[7].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[8].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[9].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[10].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        dgvMain.Columns[11].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                        UpdateHeaderNames();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "thông báo");
            }
        }
        private void btTroVe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmMain main = new frmMain(LoaiTKhoan);
            main.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblNhanVien").DefaultView;
            UpdateHeaderNames();
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
            frmTaiKhoan TK = new frmTaiKhoan();
            TK.Owner = Application.Current.MainWindow;
            TK.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmChucVu CV = new frmChucVu();
            CV.Owner = Application.Current.MainWindow;
            CV.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmDuAn DA = new frmDuAn();
            DA.Owner = Application.Current.MainWindow;
            DA.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmThongKe TK = new frmThongKe();
            TK.Owner = Application.Current.MainWindow;
            TK.Show();
        }

        private void mi_thoat_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButton.OKCancel);
            if (traloi == MessageBoxResult.OK)
            {
                // Đóng tất cả các cửa sổ đang mở
                foreach (Window window in Application.Current.Windows)
                {
                    if (window != Application.Current.MainWindow)
                    {
                        window.Close();
                    }
                }

                // Mở frmLogin
                frmLogin lg = new frmLogin();
                lg.Show();

                // Đóng cửa sổ chính
                Application.Current.MainWindow.Close();
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
            frmPhongBan PB = new frmPhongBan();
            PB.Owner = Application.Current.MainWindow;
            PB.Show();
        }
    }
}
