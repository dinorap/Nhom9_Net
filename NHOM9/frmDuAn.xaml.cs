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
        public frmDuAn()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblDuAn").DefaultView;


            dgvMain.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgvMain.Columns[0].Header = "id dự án ";
            dgvMain.Columns[1].Header = "tên dự án ";
            dgvMain.Columns[2].Header = "số nhân viên ";
            dgvMain.Columns[3].Header = "mô tả dự án";
        }

        private void dgvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView obj = dgvMain.SelectedItem as DataRowView;
            if (obj == null)
            {
                txtid.Text = "";
                txtten.Text = "";
                txtso.Text = "";
                txtchuthich.Text = "";
                return;
            }

            txtid.Text = obj["id_Da"]?.ToString();
            txtten.Text = obj["name_Da"]?.ToString();
            txtso.Text = obj["Sonv_Da"]?.ToString();
            txtchuthich.Text = obj["Mota_Da"]?.ToString();
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
        }
        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update tblDuAn set name_Da=N'" + txtten.Text + "',sonv_Da=" + txtso.Text + ", mota_Da=N'" + txtchuthich.Text + "' where id_Da=N'" + txtid.Text + "'";

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

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from tblDuAn  where id_Da=N'" + txtid.Text + "'";

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
            
        }
    }
}
