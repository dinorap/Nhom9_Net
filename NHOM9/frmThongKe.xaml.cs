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
    /// Interaction logic for frmThongKe.xaml
    /// </summary>
    public partial class frmThongKe : Window
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        TruyXuatCSDL truyxuat = new TruyXuatCSDL();
        private void frmThongke_Loaded(object sender, EventArgs e)
        {
            string sql1 = "Select COUNT(*) from tblNhanVien";
            string sql2 = "Select COUNT(*) from tblPhongBan";
            string sql3 = "Select COUNT(*) from tblDuAn";
            string sql4 = "Select COUNT(*) from tblTaiKhoan";


            int a = Convert.ToInt32(truyxuat.executeScalar(sql1));
            int b = Convert.ToInt32(truyxuat.executeScalar(sql2));
            int c = Convert.ToInt32(truyxuat.executeScalar(sql3));
            int d = Convert.ToInt32(truyxuat.executeScalar(sql4));


            lblSoluongnv.Content += a.ToString();
            lblSoluongphongban.Content += b.ToString();
            lblSoluongduan.Content += c.ToString();
            lblSoluongtk.Content += d.ToString();



        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult traloi = MessageBox.Show("bạn có chắc muốn thoát không", "thông báo");
            if (traloi == MessageBoxResult.OK)
            {
                this.Close();
            }
        }
    }
}

