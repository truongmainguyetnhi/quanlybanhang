using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webbanhang
{
    public partial class frmMain : Form
    {
        #region mainmenu
        /*
        private Form GetOpenedForm(string formName)
        {
            Form form = null;
            Form[] forms = frmMain.ActiveForm.MdiChildren;

            foreach (Form f in forms)
            {
                if (f.Name == formName)
                {
                    form = f;
                    break;
                }
            }
            return form;
        }
        private void DMKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = GetOpenedForm("frmDMKhachHang");
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                form = new frmDMKhachHang(); 
                form.MdiParent = this;
                form.Show();
            }
        }

        private void danhMụcSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = GetOpenedForm("frmDMSanPham");
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                form = new frmDMSanPham();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void phânLoạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = GetOpenedForm("frmPhanloai");
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                form = new frmPhanloai();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void thuộcTínhSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = GetOpenedForm("frmThuoctinh");
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                form = new frmThuoctinh();
                form.MdiParent = this;
                form.Show();
            }
        }
        */
        #endregion
        string tentaikhoan = "", matkhau = "", loaiTK = "";
        string ketnoi = @"Data Source=DESKTOP-4IN8B14\SQLEXPRESS;Initial Catalog=SAB;Integrated Security=True";
        public frmMain(string tentaikhoan, string matkhau, string loaiTK)
        {
            InitializeComponent();
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            this.loaiTK = loaiTK;
            customizeDesing();
        }
        /*public frmMain()
        {
            InitializeComponent();
        }*/
        private void customizeDesing()
        {
            paneldlcbMenu.Visible = false;
            panelCTMenu.Visible = false;
            panelTKMenu.Visible = false;
            panelHTsubmenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelCTMenu.Visible == true)
                panelCTMenu.Visible = false;
            if (panelTKMenu.Visible == true)
                panelTKMenu.Visible = false;
            if (paneldlcbMenu.Visible == true)
                paneldlcbMenu.Visible = false;
            if (panelHTsubmenu.Visible == true)
                panelHTsubmenu.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        #region dulieucoban
        private void btndulieucoban_Click(object sender, EventArgs e)
        {
            showSubMenu(paneldlcbMenu);
            if(loaiTK == "nhanvien")
            {
                btnNV.Enabled = false;
               

            }
        }
        private void btnKH_Click(object sender, EventArgs e)
        {
            openChilForm(new frmDMKhachHang());

            //
            hideSubMenu();
        }

        private void btnPL_Click(object sender, EventArgs e)
        {
            openChilForm(new frmPhanloai());

            //
            hideSubMenu();
        }

        private void btnHH_Click(object sender, EventArgs e)
        {
            openChilForm(new frmDMSanPham());
            //
            hideSubMenu();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            openChilForm(new frmNhanVien());

            //
            hideSubMenu();
        }

        private void btnluong_Click(object sender, EventArgs e)
        {
            //
            hideSubMenu();
        }

        #endregion
        #region chungtu
        private void btnCT_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCTMenu);
            if (loaiTK == "nhanvien")
            {
                btnCTban.Enabled = false;
                btnCTmua.Enabled = false;
            }

        }

        private void btnCTmua_Click(object sender, EventArgs e)
        {
            openChilForm(new CHUNGTUMUA(tentaikhoan, matkhau, loaiTK));

            //openChilForm(new frmChungtuMua(tentaikhoan, matkhau, loaiTK));
            //
            hideSubMenu();
        }
        /*
        private void btnCTmuaCT_Click(object sender, EventArgs e)
        {
            openChilForm(new frmChungtuMuaCT(tentaikhoan, matkhau, loaiTK)) ;
            //
            hideSubMenu();
        }
        */
        private void btnCTban_Click(object sender, EventArgs e)
        {
            openChilForm(new frmCHUNGTU(tentaikhoan, matkhau, loaiTK));
            //openChilForm(new frmChungtuBan(tentaikhoan, matkhau, loaiTK)); 
            //
            hideSubMenu();
        }
        /*
        private void btnCTbanCT_Click(object sender, EventArgs e)
        {
            openChilForm(new frmChungtuBanCT(tentaikhoan, matkhau, loaiTK));
            //
            hideSubMenu();
        }
        */
        #endregion
        #region thongke
        private void btnTK_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTKMenu);
            if (loaiTK == "nhanvien")
            {
                btnDoanhthu.Enabled = false;
            }
        }

        private void btnTKTonkho_Click(object sender, EventArgs e)
        {
            //
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            openChilForm(new frmDoanhthu());
            hideSubMenu();
        }
        #endregion
        #region hethong
        private void btnHT_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHTsubmenu);
            if (loaiTK == "nhanvien")
            {
                btnPhanquyen.Enabled = false;               
            }
        }
 
        private void btnLogout_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            if(MessageBox.Show("Bạn muốn đăng xuất!","Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                frmLogin login = new frmLogin();
                login.ShowDialog();
            }

        }
        private void btnPhanquyen_Click(object sender, EventArgs e)
        {

            //
            hideSubMenu();
        }

        #endregion
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPhanquyen_Click_1(object sender, EventArgs e)
        {
            openChilForm(new frmTaoTK());
            hideSubMenu();
        }

        private Form activeForm = null;
        

        private void openChilForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

    }

}
