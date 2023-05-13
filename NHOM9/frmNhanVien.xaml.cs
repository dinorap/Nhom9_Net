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
using System.Linq;
namespace NHOM9
{
    /// <summary>
    /// Interaction logic for frmNhanVien.xaml
    /// </summary>
    public partial class frmNhanVien : Window
    {
        TruyXuatCSDL truyxuat; // Declare the object
        public frmNhanVien()
        {
            InitializeComponent();
           
        }
        
        private void CapNhat(string sql)
        {
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblNhanVien").DefaultView;
        }
        
            
        private void btnreset_Click(object sender, RoutedEventArgs e)
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblNhanVien").DefaultView;
            txtidnhanvien.Text = "";
            cbmachuvu.Text = "";
            cbtenphongban.Text = "";
            txthoten.Text = "";
            dtpngaysinh.Text = "";
            txtgioitinh.Text = "";
            txtquequan.Text = "";
            txtsocmt.Text = "";
            txtluong.Text = "";
            txtsodienthoai.Text = "";
            txtsotaikhoan.Text = "";
            dtpngaytao.Text = "";
            txtidnhanvien.Focus();
        }
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            
            
                this.Close();
            
        }
        

        public static DataTable machuvu()
        {
            String sql = "Select Ma_ChucVu from tblChuVu ";
            DataTable dt;
            dt = TruyXuatCSDL.Laybang(sql);
            return dt;
        }
        public static DataTable tenphongban()
        {
            string sql = "Select Ten_PhongBan from tblPhongBan ";
            DataTable dt;
            dt = TruyXuatCSDL.Laybang(sql);
            return dt;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            // lấy mã chức vụ
            string chuvu = "Select Ten_ChuVu from tblChuVu where Ma_ChucVu='" + cbmachuvu.Text.ToString() + "'";
            // string ma_chucvu = Convert.ToString(truyxuat.executeScalar(chuvu));
            // lấy tên phòng ban
            string phongban = "Select Ma_PhongBan from tblPhongBan where Ten_PhongBan='" + cbtenphongban.Text.ToString() + "'";
            //string ten_phongban = Convert.ToString(truyxuat.executeScalar(phongban));
            // câu lệnh truy vấn sql 

            try
            {
                string sql = "insert into tblNhanVien values(" + txtidnhanvien.Text + ",N'" + cbmachuvu.Text + "',N'" + cbtenphongban.Text + "',N'" + txthoten.Text + "'," +
                            "N'" + dtpngaysinh.Text + "',N'" + txtgioitinh.Text + "',N'" + txtquequan.Text + "',N'" + txtsocmt.Text + "'," + txtluong.Text + ",N'" + txtsodienthoai.Text + "',N'" + txtsotaikhoan.Text + "',N'" + dtpngaytao.Text + "')";
                CapNhat(sql);

                MessageBox.Show("Đã thêm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Thất bại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /*private void fontChữToolStripMenuItem_Click(object sender, RoutedEventArgs e)
         {
             var dialog = new FontChooserDialog();
             if (dialog.ShowDialog() == true)
             {
                 dgvMain.FontFamily = new FontFamily(dialog.SelectedFont.FamilyName);
                 dgvMain.FontSize = dialog.SelectedFont.Size;
                 dgvMain.FontStyle = dialog.SelectedFont.Style;
                 dgvMain.FontWeight = dialog.SelectedFont.Weight;
             }
         }

         private void màuChữToolStripMenuItem_Click(object sender, RoutedEventArgs e)
         {
             var dialog = new System.Windows.Controls.ColorPickerDialog();
             if (dialog.ShowDialog() == true)
             {
                 var color = new SolidColorBrush(dialog.SelectedColor);
                 dgvMain.Foreground = color;
                 txtidnhanvien.Foreground = color;
                 cbmachuvu.Foreground = color;
                 cbtenphongban.Foreground = color;
                 txthoten.Foreground = color;
                 dtpngaysinh.Foreground = color;
                 txtgioitinh.Foreground = color;
                 txtquequan.Foreground = color;
                 txtsocmt.Foreground = color;
                 txtluong.Foreground = color;
                 txtsodienthoai.Foreground = color;
                 txtsotaikhoan.Foreground = color;
                 dtpngaytao.Foreground = color;
             }
         }
        */

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "delete from tblNhanVien  where ID_NhanVien=" + txtidnhanvien.Text + "";

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
            
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblNhanVien").DefaultView;
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
            List<string> item2 = TruyXuatCSDL.LayDanhSach("select Ma_ChucVu from tblChuVu").Cast<string>().Where(x => x != "All").ToList();
            cbmachuvu.ItemsSource = item2;
            List<string> item1 = TruyXuatCSDL.LayDanhSach("select Ten_PhongBan from tblPhongBan").Cast<string>().Where(x => x != "All").ToList();
            cbtenphongban.ItemsSource = item1;
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

        



        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            // lấy mã chức vụ
            string chuvu = "Select Ten_ChuVu from tblChuVu where Ma_ChucVu='" + cbmachuvu.Text.ToString() + "'";

            // lấy tên phòng ban
            string phongban = "Select Ma_PhongBan from tblPhongBan where Ten_PhongBan='" + cbtenphongban.Text.ToString() + "'";
            try
            {
                string sql = "update tblNhanVien set Ma_ChucVu=N'" + cbmachuvu.Text + "',Ten_PhongBan=N'" + cbtenphongban.Text + "', Ho_Ten=N'" + txthoten.Text + "'" +
                    ",Ngay_Sinh=N'" + dtpngaysinh.Text + "',Gioi_Tinh=N'" + txtgioitinh.Text + "',Que_Quan=N'" + txtquequan.Text + "',So_CMT=N'" + txtsocmt.Text + "'," +
                    "Luong=" + txtluong.Text + ",So_DienThoai=N'" + txtsodienthoai.Text + "',So_TK=N'" + txtsotaikhoan.Text + "',Ngay_Tao=N'" + dtpngaytao.Text + "' where ID_NhanVien=" + txtidnhanvien.Text + "";
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

        private void dgvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // thiết lập giá trị của các textbox tương ứng với thông tin của nhân viên đầu tiên
            
           
                DataRowView rowView = dgvMain.SelectedItem as DataRowView;
                if (rowView != null)
                {
                    txtidnhanvien.Text = rowView[0]?.ToString();
                    cbmachuvu.Text = rowView[1]?.ToString();
                    cbtenphongban.Text = rowView[2]?.ToString();
                    txthoten.Text = rowView[3]?.ToString();
                    dtpngaysinh.Text = rowView[4]?.ToString();
                    txtgioitinh.Text = rowView[5]?.ToString();
                    txtquequan.Text = rowView[6]?.ToString();
                    txtsocmt.Text = rowView[7]?.ToString();
                    txtluong.Text = rowView[8]?.ToString();
                    txtsodienthoai.Text = rowView[9]?.ToString();
                    txtsotaikhoan.Text = rowView[10]?.ToString();
                    dtpngaytao.Text = rowView[11]?.ToString();
               
                    // Lấy giá trị của chức vụ và phòng ban từ dòng được chọn
                    string chucVu = rowView[1]?.ToString();
                    string tenPhongBan = rowView[2]?.ToString();

                    // Populate ComboBoxes
                    cbmachuvu.ItemsSource = machuvu().DefaultView;
                    cbmachuvu.DisplayMemberPath = "Ma_ChucVu";
                    cbmachuvu.SelectedValuePath = "Ma_ChucVu"; // Chọn thuộc tính để binding
                    cbmachuvu.SelectedValue = chucVu;

                    cbtenphongban.ItemsSource = tenphongban().DefaultView;
                    cbtenphongban.DisplayMemberPath = "Ten_PhongBan";
                    cbtenphongban.SelectedValuePath = "Ten_PhongBan"; // Chọn thuộc tính để binding
                    cbtenphongban.SelectedValue = tenPhongBan;
                }
                else
            {
                txtidnhanvien.Text = "";
                cbmachuvu.Text = "";
                cbtenphongban.Text = "";
                txthoten.Text = "";
                dtpngaysinh.Text = "";
                txtgioitinh.Text = "";
                txtquequan.Text = "";
                txtsocmt.Text = "";
                txtluong.Text = "";
                txtsodienthoai.Text = "";
                txtsotaikhoan.Text = "";
                dtpngaytao.Text = "";
                return;
            }
        }
        



    }
}
    


