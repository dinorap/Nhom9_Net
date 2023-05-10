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
    /// Interaction logic for frmTaiKhoan.xaml
    /// </summary>
    public partial class frmTaiKhoan : Window
    {
        string sID = "";
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        private void CapNhat(string sql)
        {
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblTaiKhoan").DefaultView; ;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblTaiKhoan").DefaultView;
            dgvMain.Columns[0].Header = "ID ";
            dgvMain.Columns[1].Header = "Tài khoản ";
            dgvMain.Columns[2].Header = "Mật khẩu ";
            dgvMain.Columns[3].Header = "Loại tài khoản ";

            dgvMain.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "insert into tblTaiKhoan values(N'" + txtTaiKhoan.Text + "', N'" + txtMatKhau.Password + "', " +
               "N'" + txtLoaiTaiKhoan.Text + "')";
                CapNhat(sql);
                MessageBox.Show("Đã thêm");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Thất bại");
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
            try
            {
                
                string sql = "update tblTaiKhoan set Ten_TKhoan=N'" + txtTaiKhoan.Text + "',Mat_Khau=N'"
                 + txtMatKhau.Password + "',Loai_TKhoan=N'"
                 + txtLoaiTaiKhoan.Text + "' where id=" + sID;
                CapNhat(sql);
                MessageBox.Show("Đã sửa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa Thất bại" + ex.Message);
            }
        }

        private void dgvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvMain.SelectedItem == null) return;
            DataRowView dataRow = dgvMain.SelectedItem as DataRowView;
            txtTaiKhoan.Text = dataRow["Ten_TKhoan"].ToString();
            txtMatKhau.Password = dataRow["Mat_Khau"].ToString();
            txtLoaiTaiKhoan.Text = dataRow["Loai_TKhoan"].ToString();
            sID = dataRow["id"].ToString();
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

        private void btTroVe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
