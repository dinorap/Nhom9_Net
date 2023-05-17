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

            dgvMain.HorizontalAlignment = HorizontalAlignment.Stretch;
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblChuVu").DefaultView;

            dgvMain.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);

            cbhoten.ItemsSource = TruyXuatCSDL.LayDanhSach("select distinct Ten_ChuVu from tblChuVu");
            cbhoten.SelectedIndex = 0;
            UpdateHeaderNames();
        }


        private void dgvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            DataRowView obj = dgvMain.SelectedItem as DataRowView;
            if (obj == null)
            {
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
        private void btnThem_Click(object sender, RoutedEventArgs e)
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
                this.Close();
            
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update tblChuVu set Ma_ChucVu=N'" + txtmachucvu.Text + "',Ten_ChuVu=N'"
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
    }
}
