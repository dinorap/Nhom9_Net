﻿using System;
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
        bool isNew = false;
        public string LoaiTKhoan;
        public frmPhongBan(string LoaiTKhoan)
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
        public frmPhongBan()
        {
            InitializeComponent();
            dgvMain.SelectionChanged += dgvMain_SelectionChanged_1;
        }
        private void UpdateHeaderNames()
        {
            dgvMain.Columns[0].Header = "ID phòng ban";
            dgvMain.Columns[1].Header = "Mã phòng ban";
            dgvMain.Columns[2].Header = "Tên phòng ban";
            dgvMain.Columns[3].Header = "Địa chỉ";
            dgvMain.Columns[4].Header = "Ghi chú ";
        }
        private void CapNhat(string sql)
        {
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblPhongBan").DefaultView;
            dgvMain.Columns[0].Visibility = Visibility.Collapsed; // Ẩn cột ; 

            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            UpdateHeaderNames();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            
        }
        string sID = "";
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtmaphongban.Text) || string.IsNullOrEmpty(txttenphongban.Text) || string.IsNullOrEmpty(txtdiachi.Text) || string.IsNullOrEmpty(txtghichu.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                        return;
                    }
                    string sql = "insert into tblPhongBan values(N'" + txtmaphongban.Text + "', " +
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
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(txtmaphongban.Text) || string.IsNullOrEmpty(txttenphongban.Text) || string.IsNullOrEmpty(txtdiachi.Text) || string.IsNullOrEmpty(txtghichu.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                        return;
                    }
                    string sql = "update tblPhongBan set Ma_PhongBan=N'" + txtmaphongban.Text + "',Ten_PhongBan=N'"
                     + txttenphongban.Text + "',Dia_Chi=N'" + txtdiachi.Text + "', Ghi_chu=N'" + txtghichu.Text + "' where ID_PhongBan=" + sID + "";

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
        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState(true);
            isNew = false;
            txtmaphongban.Focus();
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

            dgvMain.IsEnabled = Editing;
        }
        private void btthemmoi_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState(true);
            isNew = true;
            txtmaphongban.Focus();
        }

        private void btboqua_Click(object sender, RoutedEventArgs e)
        {
            SetObjectState();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            dgvMain.ItemsSource = TruyXuatCSDL.Laybang("select * from tblPhongBan").DefaultView;
            
            txtmaphongban.Clear();
            txttenphongban.Clear();
            txtdiachi.Clear();
            txtghichu.Clear();
            txtmaphongban.Focus();
        }
        
        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "delete from tblPhongBan where ID_PhongBan=" + sID + "";

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

            dgvMain.Columns[0].Visibility = Visibility.Collapsed; // Ẩn cột ; 
           
            dgvMain.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            dgvMain.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            UpdateHeaderNames();
            btnxoa.IsEnabled = false;
            btnsua.IsEnabled = false;

        }

        private void dgvMain_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            btnxoa.IsEnabled = true;
            btnsua.IsEnabled = true;
            DataRowView obj = dgvMain.SelectedItem as DataRowView;
            if (obj == null)
            {
                btnxoa.IsEnabled = false;
                btnsua.IsEnabled = false;
                
                txtmaphongban.Text = "";
                txttenphongban.Text = "";
                txtdiachi.Text = "";
                txtghichu.Text = "";
                return;
            }

           
            txtmaphongban.Text = obj["Ma_PhongBan"]?.ToString();
            txttenphongban.Text = obj["Ten_PhongBan"]?.ToString();
            txtdiachi.Text = obj["Dia_Chi"]?.ToString();
            txtghichu.Text = obj["Ghi_Chu"]?.ToString();
            sID = obj["ID_PhongBan"].ToString();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
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