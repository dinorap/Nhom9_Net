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
    /// Interaction logic for frmPhongBan.xaml
    /// </summary>
    public partial class frmPhongBan : Window
    {
        public frmPhongBan()
        {
            InitializeComponent();
            dgvMain.SelectionChanged += dgvMain_SelectionChanged;
        }

        private void CapNhat(string sql)
        {
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblPhongBan").DefaultView;
        }
        
        private void dgvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvMain.SelectedItem != null)
            {
                DataRowView rowView = (DataRowView)dgvMain.SelectedItem;
                txtidphongban.Text = rowView["id phòng ban"].ToString();
                txtmaphongban.Text = rowView["mã phòng ban"].ToString();
                txttenphongban.Text = rowView["tên phòng ban"].ToString();
                txtdiachi.Text = rowView["địa chỉ"].ToString();
                txtghichu.Text = rowView["ghi chú"].ToString();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBoxResult traloi = MessageBox.Show("bạn có chắc muốn thoát không", "thông báo");
            if (traloi == MessageBoxResult.OK)
            {
                this.Close();
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into tblPhongBan values(" + txtidphongban.Text + ", N'" + txtmaphongban.Text + "', " +
               "N'" + txttenphongban.Text + "', N'" + txtdiachi.Text + "', N'" + txtghichu.Text + "')";
                CapNhat(sql);
                MessageBox.Show("Đã thêm", "Thông báo",
                  MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Thất bại", "Thông báo",
                 MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblPhongBan").DefaultView;
            txtidphongban.Clear();
            txtmaphongban.Clear();
            txttenphongban.Clear();
            txtdiachi.Clear();
            txtghichu.Clear();
            txtidphongban.Focus();
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update tblPhongBan set Ma_PhongBan=N'" + txtmaphongban.Text + "',Ten_PhongBan=N'"
                 + txttenphongban.Text + "',Dia_Chi=N'" + txtdiachi.Text + "', Ghi_chu=N'" + txtghichu.Text + "' where ID_PhongBan=" + txtidphongban.Text + "";

                CapNhat(sql);
                MessageBox.Show("Đã sửa", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa Thất bại", "Thông báo",
                 MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "delete from tblPhongBan where ID_PhongBan=" + txtidphongban.Text + "";

                CapNhat(sql);
                MessageBox.Show("Đã xóa", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa Thất bại", "Thông báo",
                 MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblPhongBan").DefaultView;


            dgvMain.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgvMain.Columns[0].Header = "id phòng ban";
            dgvMain.Columns[1].Header = "mã phòng ban";
            dgvMain.Columns[2].Header = "tên phòng ban";
            dgvMain.Columns[3].Header = "dịa chỉ";
            dgvMain.Columns[4].Header = "ghi chú ";
        }
    }
}