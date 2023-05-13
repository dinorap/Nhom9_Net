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
        private System.ComponentModel.IContainer components = null;

        public frmTimkiem()
        {
            InitializeComponent();
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
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy bản ghi nào phù hợp", "Thông báo");
                    }
                    else
                    {
                        dgvMain.ItemsSource = dataTable.DefaultView;
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
        }
    }
}
