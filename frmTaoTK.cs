using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace webbanhang
{
    public partial class frmTaoTK : Form
    {
        public frmTaoTK()
        {
            InitializeComponent();
        }
        SABEntities3 context;
        TaiKhoan rec_tk;
        List<TaiKhoan> list_tk;
        int ID_Selected_tk = 0;
        int idx_DGView_tk;
        bool check = false;

        private void frmTaoTK_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_tk = new TaiKhoan();
            list_tk = new List<TaiKhoan>();
            Load_DgviewTK();
        }
        public void Load_DgviewTK()
        {
            list_tk = context.TaiKhoan.ToList();
            if (list_tk.Count() != 0)
            {
                dgViewTK.DataSource = list_tk.Select(s => new { s.TenTaiKhoan, s.MatKhau, s.LoaiTK }).ToList();
                formatDGView();
                txtSLTK.Text = list_tk.Count.ToString();
                txtSLTK.ReadOnly = true;
            }
            else
            {
                dgViewTK.DataSource = null;
                txtSLTK.Text = list_tk.Count().ToString();
                txtSLTK.ReadOnly = true;
            }
            comboBox1.DataSource = list_tk;
            comboBox1.DisplayMember = "LoaiTK";
            comboBox1.ValueMember = "TenTaiKhoan";
        }
        public void formatDGView()
        {
            dgViewTK.Columns[0].HeaderText = "Tên tài khoản";
            dgViewTK.Columns[0].Width = 200;
            dgViewTK.Columns[1].HeaderText = "Mật khẩu";
            dgViewTK.Columns[1].Width = 200;
            dgViewTK.Columns[2].HeaderText = "Loại tài khoản";
            dgViewTK.Columns[2].Width = 200;
            dgViewTK.AllowUserToAddRows = false;
            dgViewTK.AllowUserToDeleteRows = false;
            dgViewTK.ReadOnly = true;
            dgViewTK.RowTemplate.Height = 50;
            dgViewTK.ForeColor = Color.Black;
            dgViewTK.DefaultCellStyle.Font = new Font("Time new roman", 12);
        }
        public void EmptyControl()
        {
            txtTenTK.Clear();
            txtMK.Clear();
            txtTenTK.Select();
        }
        public bool checkEmpty()
        {
            if (txtTenTK.Text.Length == 0 || txtMK.Text.Length == 0)
            {
                return true;
            }
            else { return false; }
        }

        private async void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (ID_Selected_tk == 0)
            {
                if (!checkEmpty())
                {
                    rec_tk.TenTaiKhoan = txtTenTK.Text.ToString().Trim();
                    var ttk = await context.TaiKhoan.Where(h => h.TenTaiKhoan == txtTenTK.Text.ToString().Trim()).ToListAsync();
                    if (ttk.Any())
                        MessageBox.Show("Tài khoản đã tồn tại", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        int.TryParse(txtIDNV.Text.ToString(), out int id);
                        var iid = await context.NHAN_VIEN.Where(h => h.ID_NHAN_VIEN == id).ToListAsync();
                        if (iid.Any())
                        {
                            rec_tk.ID_NHAN_VIEN = id;
                            rec_tk.LoaiTK = comboBox1.Text.ToString().Trim();
                            rec_tk.TenTaiKhoan = txtTenTK.Text.ToString().Trim();
                            rec_tk.MatKhau = txtMK.Text.ToString().Trim();
                            context.TaiKhoan.Add(rec_tk);
                            context.SaveChanges();
                            RefreshforNew();
                        }
                        else
                        {
                            MessageBox.Show("Nhân viên không tồn tại", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show("Thông tin tài khoản bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rec_tk.LoaiTK = comboBox1.Text.ToString().Trim();
                    rec_tk.TenTaiKhoan = txtTenTK.Text.ToString().Trim();
                    rec_tk.MatKhau = txtMK.Text.ToString().Trim();
                    context.SaveChanges();
                    RefreshforNew();
                }
            }
        }
        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewTK();
            rec_tk = new TaiKhoan();
            ID_Selected_tk = 0;
        }

        private void dgViewTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (check == true)
            {
                string searchText = txtSLTK.Text.Trim();
                list_tk = (from x in context.TaiKhoan
                           where x.TenTaiKhoan.Contains(searchText)
                           select x).ToList();
                idx_DGView_tk = dgViewTK.CurrentRow.Index;
                rec_tk = list_tk[idx_DGView_tk];
                ID_Selected_tk = rec_tk.ID_TK;
                txtTenTK.Text = rec_tk.TenTaiKhoan;
                txtMK.Text = rec_tk.MatKhau;
                comboBox1.Text = rec_tk.LoaiTK;
                txtIDNV.Text = rec_tk.ID_NHAN_VIEN.ToString();
                check = false;
                txtIDNV.ReadOnly = true;
            }
            else
            {
                idx_DGView_tk = dgViewTK.CurrentRow.Index;
                rec_tk = list_tk[idx_DGView_tk];
                ID_Selected_tk = rec_tk.ID_TK;
                txtTenTK.Text = rec_tk.TenTaiKhoan;
                txtMK.Text = rec_tk.MatKhau;
                comboBox1.Text = rec_tk.LoaiTK;
                txtIDNV.Text = rec_tk.ID_NHAN_VIEN.ToString();
                txtIDNV.ReadOnly = true;

            }
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            if (ID_Selected_tk != 0)
            {
                if (MessageBox.Show("Bạn chắc muốn xóa?", "Cảnh báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    context.TaiKhoan.Remove(rec_tk);
                    context.SaveChanges();
                    RefreshforNew();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtKeyTK_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSLTK.Text.Trim();
            var lsPL = (from x in context.TaiKhoan
                        where x.TenTaiKhoan.Contains(searchText)
                        select new
                        {
                            x.TenTaiKhoan,
                            x.MatKhau,
                            x.LoaiTK
                        }
                        ).ToList();
            dgViewTK.DataSource = lsPL;
            check = true;
            txtSLTK.Text = lsPL.ToList().Count().ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            EmptyControl();
            rec_tk = new TaiKhoan();
            ID_Selected_tk = 0;
        }


    }
}
