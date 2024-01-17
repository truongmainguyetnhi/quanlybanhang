using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webbanhang
{
    public partial class frmPhanloai : Form
    {
        public frmPhanloai()
        {
            InitializeComponent();
        }
            SABEntities3 context;
            PHAN_LOAI rec_pl;
            List<PHAN_LOAI> list_pl;
            int ID_Selected_pl = 0;
            int idx_DGView_pl;
            bool check = false;
        private void frmPhanloai_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_pl = new PHAN_LOAI();
            list_pl = new List<PHAN_LOAI>();
            Load_DgviewPL();
        }
        public void Load_DgviewPL()
        {
            list_pl = context.PHAN_LOAI.ToList();
            if (list_pl.Count() != 0)
            {
                dgViewPL.DataSource = list_pl.Select(s => new { s.TENPHANLOAI, s.MOTA, s.HINHANH }).ToList();
                formatDGView();
                txtSLPL.Text = list_pl.Count.ToString();
                txtSLPL.ReadOnly = true;
            }
            else
            {
                dgViewPL.DataSource = null;
                txtSLPL.Text = list_pl.Count().ToString();
                txtSLPL.ReadOnly = true;
            }
        }
        public void formatDGView()
        {
            dgViewPL.Columns[0].HeaderText = "Tên phân loại";
            dgViewPL.Columns[0].Width = 200;
            dgViewPL.Columns[1].HeaderText = "Mô tả";
            dgViewPL.Columns[1].Width = 200;
            dgViewPL.Columns[2].HeaderText = "Hình ảnh";
            dgViewPL.Columns[2].Width = 200;
            dgViewPL.RowTemplate.Height = 100;
            dgViewPL.AllowUserToAddRows = false;
            dgViewPL.AllowUserToDeleteRows = false;
            dgViewPL.ReadOnly = true;
            dgViewPL.ForeColor = Color.Black;
            dgViewPL.DefaultCellStyle.Font = new Font("Arial", 14);
        }

        private void imgPL_Click(object sender, EventArgs e)
        {
            openFileImage.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileImage.ShowDialog() == DialogResult.OK)
            {
                Image root_img, re_img;
                imgPL.SizeMode = PictureBoxSizeMode.StretchImage;
                root_img = new Bitmap(openFileImage.FileName);
                re_img = new Bitmap(root_img, new Size(200, 100));
                imgPL.Image = re_img;
            }
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            EmptyControl();
            rec_pl = new PHAN_LOAI();
            ID_Selected_pl = 0;
        }
        public void EmptyControl()
        {
            txtTenPL.Clear();
            txtMota.Clear();
            imgPL.Image = null;
            txtTenPL.Select();
        }
        public bool checkEmpty()
        {
            if (txtTenPL.Text.Length == 0 || txtMota.Text.Length == 0 || imgPL.Image == null)
            {
                return true;
            }
            else { return false; }
        }

        private async void btnsave_Click(object sender, EventArgs e)
        {
            if (ID_Selected_pl == 0)
            {
                if (!checkEmpty())
                {                  
                    rec_pl.TENPHANLOAI = txtTenPL.Text.ToString().Trim();
                    var tpl = await context.PHAN_LOAI.Where(h => h.TENPHANLOAI == txtTenPL.Text.ToString().Trim()).ToListAsync();
                    if (tpl.Any())
                        MessageBox.Show("Phân loại đã tồn tại", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        rec_pl.TENPHANLOAI = txtTenPL.Text.ToString().Trim();
                        rec_pl.MOTA = txtMota.Text.ToString().Trim();
                        rec_pl.HINHANH = Common.ImageToByteArray(imgPL.Image);
                        context.PHAN_LOAI.Add(rec_pl);
                        context.SaveChanges();
                        RefreshforNew();
                    }
                    
                }
                else
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Thông tin phân loại bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rec_pl.TENPHANLOAI = txtTenPL.Text.ToString().Trim();
                    rec_pl.MOTA = txtMota.Text.ToString().Trim();
                    rec_pl.HINHANH = Common.ImageToByteArray(imgPL.Image);
                    context.SaveChanges();
                    RefreshforNew();
                }
            }
        }
        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewPL();
            rec_pl = new PHAN_LOAI();
            ID_Selected_pl = 0;
        }

        private void dgViewPL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (check == true)
            {
                string searchText = txtKeyPL.Text.Trim();
                list_pl = (from x in context.PHAN_LOAI
                           where x.TENPHANLOAI.Contains(searchText)
                           select x).ToList();
                idx_DGView_pl = dgViewPL.CurrentRow.Index;
                rec_pl = list_pl[idx_DGView_pl];
                ID_Selected_pl = rec_pl.ID_PHANLOAI;
                txtTenPL.Text = rec_pl.TENPHANLOAI;
                txtMota.Text = rec_pl.MOTA;
                imgPL.Image = Common.ByteArrayToImage(rec_pl.HINHANH);
                imgPL.SizeMode = PictureBoxSizeMode.StretchImage;
                check = false;
            }
            else
            {
                idx_DGView_pl = dgViewPL.CurrentRow.Index;
                rec_pl = list_pl[idx_DGView_pl];
                ID_Selected_pl = rec_pl.ID_PHANLOAI;
                txtTenPL.Text = rec_pl.TENPHANLOAI;
                txtMota.Text = rec_pl.MOTA;
                imgPL.Image = Common.ByteArrayToImage(rec_pl.HINHANH);
                imgPL.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }

        private async void btndel_Click(object sender, EventArgs e)
        {
            if (ID_Selected_pl != 0)
            {
                var hh = await context.HANG_HOA.Where(h => h.ID_PHANLOAI == ID_Selected_pl).ToListAsync();
                if (hh.Any())
                    MessageBox.Show("Phân loại tồn tại sản phẩn", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if(MessageBox.Show("Bạn chắc muốn xóa?", "Cảnh báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    context.PHAN_LOAI.Remove(rec_pl);
                    context.SaveChanges();
                    RefreshforNew();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtKeyPL_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtKeyPL.Text.Trim();
            int num = 0;
            if (!int.TryParse(searchText, out num))
            {
                var lsPL = (from x in context.PHAN_LOAI
                            where x.TENPHANLOAI.Contains(searchText)
                            select new
                            {
                                x.TENPHANLOAI,
                                x.MOTA,
                                x.HINHANH
                            }
                        ).ToList();
                dgViewPL.DataSource = lsPL;
                check = true;
                txtSLPL.Text = lsPL.ToList().Count().ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên", "Lỗi nhập", MessageBoxButtons.OK);
                txtKeyPL.Text = "";
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
