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
using System.IO;
namespace NHOM9
{
    /// <summary>
    /// Interaction logic for frmNhanVien.xaml
    /// </summary>
    public partial class frmNhanVien : Window
    {
        string filename = "";
        string filename1 = "";
        public string LoaiTKhoan;
        bool isNew = false;
        public frmNhanVien(string LoaiTKhoan)
        {
            this.LoaiTKhoan = LoaiTKhoan;
            InitializeComponent();
            if (LoaiTKhoan == "1")
            {
                mniDanhMuc.Visibility = Visibility.Visible;
                mi_QLHT.Visibility = Visibility.Collapsed;
                mi_QLHS.Visibility = Visibility.Visible;
                btnreset.Visibility = Visibility.Collapsed;
                btnsua.Visibility = Visibility.Collapsed;
                btnthem.Visibility = Visibility.Collapsed;
                btnxoa.Visibility = Visibility.Collapsed;
                btdoc.Visibility = Visibility.Collapsed;
                btghi.Visibility = Visibility.Collapsed;
                btboqua.Visibility = Visibility.Collapsed;
                btthemmoi.Visibility = Visibility.Collapsed;
            }
            else
            {
                

                mniDanhMuc.Visibility = Visibility.Visible;
                mi_QLHT.Visibility = Visibility.Visible;
                mi_QLHS.Visibility = Visibility.Visible;
            }
        }
        TruyXuatCSDL truyxuat; // Declare the object
        public frmNhanVien()
        {
            InitializeComponent();
           
        }
        
        private void CapNhat(string sql)
        {
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblNhanVien").DefaultView;
            UpdateHeaderNames();
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
            frmMain main = new frmMain(LoaiTKhoan);
            main.Show();
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
            if (isNew)
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
            else
            { // lấy mã chức vụ
                string chuvu = "Select Ten_ChuVu from tblChuVu where Ma_ChucVu='" + cbmachuvu.Text.ToString() + "'";

                // lấy tên phòng ban
                string phongban = "Select Ma_PhongBan from tblPhongBan where Ten_PhongBan='" + cbtenphongban.Text.ToString() + "'";
                try
                {
                    string sql = "update tblNhanVien set Ma_ChucVu=N'" + cbmachuvu.Text + "',Ten_PhongBan=N'" + cbtenphongban.Text + "',ID_NhanVien=N'" + txtidnhanvien.Text + "', Ho_Ten=N'" + txthoten.Text + "'" +
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
            SetObjectState();
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
            button6.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btghi.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            btdoc.Visibility = Editing ? Visibility.Visible : Visibility.Hidden;
            dgvMain.IsEnabled = Editing;
        }
        private void btthemmoi_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState(true);
            isNew = true;
            txtidnhanvien.Focus();
        }

        private void btboqua_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState();
        }


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
            if (LoaiTKhoan == "1")
            {
                string s1 = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string currentPath = System.IO.Path.GetDirectoryName(s1);
                filename = currentPath + "\\nhanvien.txt";
                filename1 = currentPath + "\\nhanvien1.txt";
                dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblNhanVien").DefaultView;
                dgvMain.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                dgvMain.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                dgvMain.Columns[5].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                dgvMain.Columns[6].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                dgvMain.Columns[7].Visibility = Visibility.Collapsed;
                dgvMain.Columns[8].Visibility = Visibility.Collapsed;
                dgvMain.Columns[9].Visibility = Visibility.Collapsed;
                dgvMain.Columns[10].Visibility = Visibility.Collapsed;
                dgvMain.Columns[11].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                List<string> item2 = TruyXuatCSDL.LayDanhSach("select Ma_ChucVu from tblChuVu").Cast<string>().Where(x => x != "All").ToList();
                cbmachuvu.ItemsSource = item2;
                List<string> item1 = TruyXuatCSDL.LayDanhSach("select Ten_PhongBan from tblPhongBan").Cast<string>().Where(x => x != "All").ToList();
                cbtenphongban.ItemsSource = item1;
                UpdateHeaderNames();
                btnxoa.IsEnabled = false;
                btnsua.IsEnabled = false;
            }
            else
            {
                string s1 = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string currentPath = System.IO.Path.GetDirectoryName(s1);
                filename = currentPath + "\\nhanvien.txt";
                filename1 = currentPath + "\\nhanvien1.txt";
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
                UpdateHeaderNames();
                btnxoa.IsEnabled = false;
                btnsua.IsEnabled = false;
            }
        }
        private void btghi_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter writer = new StreamWriter(filename);

            // Lấy dữ liệu từ DataGrid
            foreach (var dataItem in dgvMain.Items)
            {
                if (dataItem is DataRowView rowView)
                {
                    DataRow row = rowView.Row;
                    string rowData = string.Join(",", row.ItemArray.Select(item => item.ToString()));
                    writer.WriteLine(rowData);
                }
            }
            // Đóng tệp
            writer.Close();
            string successMessage = "Ghi thành công vào tệp: " + filename;
            MessageBox.Show(successMessage, "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btdoc_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(filename1))
            {
                MessageBox.Show("Không tìm thấy tệp " + filename1, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                // Mở tệp
                StreamReader reader = new StreamReader(filename1);
                string line = reader.ReadLine();

                // Tạo một DataTable mới để chứa dữ liệu
                DataTable dataTable = new DataTable();

                // Tạo các cột trong DataTable
                dataTable.Columns.Add("ID Nhân Viên");
                dataTable.Columns.Add("Mã Chức Vụ");
                dataTable.Columns.Add("Tên Phòng Ban");
                dataTable.Columns.Add("Họ Tên");
                dataTable.Columns.Add("Ngày Sinh");
                dataTable.Columns.Add("Giới Tính");
                dataTable.Columns.Add("Quê Quán");
                dataTable.Columns.Add("SoCMT");
                dataTable.Columns.Add("Lương");
                dataTable.Columns.Add("SĐT");
                dataTable.Columns.Add("STK");
                dataTable.Columns.Add("Ngày vào làm");

                // Đọc từng dòng trong tệp
                while (line != null)
                {
                    // Tạo một mảng các giá trị từ chuỗi dòng
                    string[] rowData = line.Split(',');

                    // Thêm dòng vào DataTable
                    dataTable.Rows.Add(rowData);

                    line = reader.ReadLine();
                }

                // Đặt DataTable làm ItemsSource của DataGrid
                dgvMain.ItemsSource = dataTable.DefaultView;

                // Đóng tệp
                reader.Close();

                // Hiển thị thông báo thành công
                MessageBox.Show("Đọc và cập nhật dữ liệu thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rất tiếc, đã xảy ra lỗi: " + ex.Message);
            }
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

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState(true);
            isNew = false;
            txtidnhanvien.Focus();
        }

        private void dgvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // thiết lập giá trị của các textbox tương ứng với thông tin của nhân viên đầu tiên

            btnxoa.IsEnabled = false;
            btnsua.IsEnabled = false;
            DataRowView rowView = dgvMain.SelectedItem as DataRowView;
            
                if (rowView != null)
                {
                    btnxoa.IsEnabled = true;
                    btnsua.IsEnabled = true;
                    txtidnhanvien.Text = rowView[0]?.ToString();
                    cbmachuvu.Text = rowView[1]?.ToString();
                    cbtenphongban.Text = rowView[2]?.ToString();
                    txthoten.Text = rowView[3]?.ToString();
                    dtpngaysinh.Text = rowView[4]?.ToString();
                    txtgioitinh.Text = rowView[5]?.ToString();
                    txtquequan.Text = rowView[6]?.ToString();
                if (LoaiTKhoan == "1")
                {
                    // Ẩn các cột 7, 8, 9, 10
                    dgvMain.Columns[7].Visibility = Visibility.Collapsed;
                    dgvMain.Columns[8].Visibility = Visibility.Collapsed;
                    dgvMain.Columns[9].Visibility = Visibility.Collapsed;
                    dgvMain.Columns[10].Visibility = Visibility.Collapsed;
                }
                else
                {
                    txtsocmt.Text = rowView[7]?.ToString();
                    txtluong.Text = rowView[8]?.ToString();
                    txtsodienthoai.Text = rowView[9]?.ToString();
                    txtsotaikhoan.Text = rowView[10]?.ToString();
                }
               
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
    


