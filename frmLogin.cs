using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webbanhang
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMK quenMK = new frmQuenMK();
            quenMK.ShowDialog();
        }
        //Modify modify = new Modify();
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTK.Text.ToString();
            string MK = txtMK.Text.ToString();
            if(tenTK == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(MK == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //string query = "Select * from Taikhoan where tentaikhoan = '"+tenTK+"' and matkhau = '"+MK+"'";               
                //modify.TaiKhoans(query).Count
                SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-4IN8B14\SQLEXPRESS;Initial Catalog=SAB;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("Select * from Taikhoan where tentaikhoan = N'" + txtTenTK.Text + "' and matkhau = N'" + txtMK.Text + "'", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
              {
                    this.Hide();
                    frmMain f = new frmMain(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
