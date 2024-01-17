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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        SABEntities3 context;
        NHAN_VIEN rec_nv;
        List<NHAN_VIEN> list_nv;
        LUONG rec_l;
        List<LUONG> list_l;
        int ID_Selected_nv = 0;
        int idx_DGView_nv;
        bool check = false;

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_nv = new NHAN_VIEN();
            list_nv = new List<NHAN_VIEN>();
            rec_l = new LUONG();
            list_l = new List<LUONG>();
            Load_DgviewNV();
            txtIDNV.ReadOnly = true;
            txtLuong.ReadOnly = true;
        }
        public void Load_DgviewNV()
        {
            list_nv = context.NHAN_VIEN.ToList();
            if (list_nv.Count() != 0)
            {
                var query = (from n in context.NHAN_VIEN
                             join l in context.LUONGs on n.ID_NHAN_VIEN equals l.ID_NHAN_VIEN
                             select new
                             {
                                 n.ID_NHAN_VIEN,
                                 n.TEN_NV,
                                 n.SODIENTHOAI,
                                 n.DIACHI,
                                 n.GIOITINH,
                                 l.SONGAYNGHICOPHEP,
                                 l.SONGAYNGHIKHONGPHEP,
                                 l.TONGNGAYLAM,
                                 l.HESO,
                                 l.DONGIA,
                                 l.TONGLUONG,
                                 n.HINHANH
                             }).ToList();
                dgViewNV.DataSource = query;
                formatDGView();
                txtSLNV.Text = list_nv.Count.ToString();
                txtSLNV.ReadOnly = true;
            }
            else
            {
                dgViewNV.DataSource = null;
                txtSLNV.Text = list_nv.Count().ToString();
                txtSLNV.ReadOnly = true;
            }
        }
        public void formatDGView()
        {
            
            dgViewNV.Columns[0].HeaderText = "ID nhân viên";
            dgViewNV.Columns[0].Width = 150;
            dgViewNV.Columns[1].HeaderText = "Tên nhân viên";
            dgViewNV.Columns[1].Width = 150;
            dgViewNV.Columns[2].HeaderText = "Số điện thoại";
            dgViewNV.Columns[2].Width = 150;
            dgViewNV.Columns[3].HeaderText = "Địa chỉ";
            dgViewNV.Columns[3].Width = 150;
            dgViewNV.Columns[4].HeaderText = "Giới tính";
            dgViewNV.Columns[4].Width = 150;
            dgViewNV.Columns[5].HeaderText = "Ngày phép";
            dgViewNV.Columns[5].Width = 150;
            dgViewNV.Columns[6].HeaderText = "Ngày không phép";
            dgViewNV.Columns[6].Width = 150;
            dgViewNV.Columns[7].HeaderText = "Tổng ngày làm";
            dgViewNV.Columns[7].Width = 150;
            dgViewNV.Columns[8].HeaderText = "Hệ số";
            dgViewNV.Columns[8].Width = 150;
            dgViewNV.Columns[9].HeaderText = "Đơn giá";
            dgViewNV.Columns[9].Width = 150;
            dgViewNV.Columns[10].HeaderText = "Tổng lương";
            dgViewNV.Columns[10].Width = 150;
            dgViewNV.Columns[11].HeaderText = "Hình ảnh";
            dgViewNV.Columns[11].Width = 150;
            dgViewNV.RowTemplate.Height = 100;
            dgViewNV.AllowUserToAddRows = false;
            dgViewNV.AllowUserToDeleteRows = false;
            dgViewNV.ReadOnly = true;
            dgViewNV.BackgroundColor = Color.LightGray;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileImage.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileImage.ShowDialog() == DialogResult.OK)
            {
                Image root_img, re_img;
                imgNV.SizeMode = PictureBoxSizeMode.StretchImage;
                root_img = new Bitmap(openFileImage.FileName);
                re_img = new Bitmap(root_img, new Size(150, 100));
                imgNV.Image = re_img;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EmptyControl();
            rec_nv = new NHAN_VIEN();
            rec_l = new LUONG();

            ID_Selected_nv = 0;
        }
        public void EmptyControl()
        {
            txtTenNV.Clear();
            txtDiachi.Clear();
            txtSdt.Clear();
            radiNu.Checked = false;
            radiNam.Checked = false;
            txtHeso.Clear();
            txtDongia.Clear();
            txtKophep.Clear();
            txtPhep.Clear();
            txtTongngay.Clear();
            txtLuong.Clear();
            txtIDNV.Clear();
            imgNV.Image = null;
            txtTenNV.Select();
        }
        public bool checkEmpty()
        {
            if (txtTenNV.Text.Length == 0 || txtDiachi.Text.Length == 0 || imgNV.Image == null || txtSdt.Text.Length == 0
                || txtHeso.Text.Length == 0 || txtDongia.Text.Length == 0 || txtKophep.Text.Length == 0
                || txtPhep.Text.Length == 0 || txtTongngay.Text.Length == 0 )
            {
                return true;
            }
            else
            {
                return false; }
        }
        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewNV();
            rec_nv = new NHAN_VIEN();
            rec_l= new LUONG();

            ID_Selected_nv = 0;
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            if (ID_Selected_nv != 0)
            {              
                if (MessageBox.Show("Bạn chắc muốn xóa?", "Cảnh báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var xoa = context.NHAN_VIEN.Find(ID_Selected_nv);
                    context.NHAN_VIEN.Remove(xoa);
                    context.SaveChanges();
                    RefreshforNew();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTimTen_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimTen.Text.Trim();
            int num = 0;
            if (!int.TryParse(searchText, out num))
            {
                var query = (from n in context.NHAN_VIEN
                             join l in context.LUONGs on n.ID_NHAN_VIEN equals l.ID_NHAN_VIEN
                             select new
                             {
                                 n.ID_NHAN_VIEN,
                                 n.TEN_NV,
                                 n.SODIENTHOAI,
                                 n.DIACHI,
                                 l.SONGAYNGHICOPHEP,
                                 l.SONGAYNGHIKHONGPHEP,
                                 l.TONGNGAYLAM,
                                 l.HESO,
                                 l.DONGIA,
                                 n.HINHANH
                             }).ToList();
                dgViewNV.DataSource = query;
                check = true;
                txtSLNV.Text = query.ToList().Count().ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên", "Lỗi nhập", MessageBoxButtons.OK);
                txtTimTen.Text = "";
            }
        }

        private async void dgViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int.TryParse(dgViewNV[0, e.RowIndex].Value.ToString(), out ID_Selected_nv);
            var query = (from n in context.NHAN_VIEN
                         join l in context.LUONGs on n.ID_NHAN_VIEN equals l.ID_NHAN_VIEN
                         where n.ID_NHAN_VIEN == ID_Selected_nv
                         select new
                         {
                             n.ID_NHAN_VIEN,
                             n.TEN_NV,
                             n.SODIENTHOAI,
                             n.DIACHI,
                             n.GIOITINH,
                             l.SONGAYNGHICOPHEP,
                             l.SONGAYNGHIKHONGPHEP,
                             l.TONGNGAYLAM,
                             l.HESO,
                             l.DONGIA,
                             l.TONGLUONG,
                             n.HINHANH
                         }).ToList();
            txtIDNV.Text = query.FirstOrDefault().ID_NHAN_VIEN.ToString();
            txtTenNV.Text = query.FirstOrDefault().TEN_NV.ToString();
            txtDiachi.Text = query.FirstOrDefault().DIACHI.ToString();
            txtSdt.Text = query.FirstOrDefault().SODIENTHOAI.ToString();
            txtHeso.Text = query.FirstOrDefault().HESO.ToString();
            txtDongia.Text = query.FirstOrDefault().DONGIA.ToString();
            txtKophep.Text = query.FirstOrDefault().SONGAYNGHIKHONGPHEP.ToString();
            txtPhep.Text = query.FirstOrDefault().SONGAYNGHICOPHEP.ToString();
            txtTongngay.Text = query.FirstOrDefault().TONGNGAYLAM.ToString();
            txtLuong.Text = query.FirstOrDefault().TONGLUONG.ToString();
            var gt = query.FirstOrDefault().GIOITINH.ToString();
            if (gt == "Nữ")
            {
                radiNu.Checked = true;
            }
            else radiNam.Checked = true;
            imgNV.Image = Common.ByteArrayToImage(query.FirstOrDefault().HINHANH);
            imgNV.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ID_Selected_nv == 0)
            {
                if (!checkEmpty())
                {
                    rec_nv.TEN_NV = txtTenNV.Text.ToString().Trim();
                    rec_nv.DIACHI = txtDiachi.Text.ToString().Trim();
                    rec_nv.SODIENTHOAI = txtSdt.Text.ToString().Trim();
                    rec_nv.HINHANH = Common.ImageToByteArray(imgNV.Image);
                    rec_nv.GIOITINH = radiNu.Checked ? "Nữ" : "Nam";
                    context.NHAN_VIEN.Add(rec_nv);
                    await context.SaveChangesAsync();
                    int id = rec_nv.ID_NHAN_VIEN;
                    rec_l.ID_NHAN_VIEN = id;
                    int.TryParse(txtHeso.Text.ToString().Trim(), out int heso);
                    rec_l.HESO = heso;
                    int.TryParse(txtTongngay.Text.ToString(), out int songay);
                    rec_l.TONGNGAYLAM = songay;
                    rec_l.SONGAYNGHICOPHEP = int.Parse(txtPhep.Text.ToString());
                    rec_l.SONGAYNGHIKHONGPHEP = int.Parse(txtKophep.Text.ToString());
                    decimal.TryParse(txtDongia.Text.ToString(), out decimal gia);
                    rec_l.DONGIA = gia;
                    decimal luong = heso * songay * gia;
                    rec_l.TONGLUONG = luong;
                    context.LUONGs.Add(rec_l);
                    await context.SaveChangesAsync();
                    RefreshforNew();
                }
                else MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Thông tin nhân viên bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rec_nv = context.NHAN_VIEN.Find(ID_Selected_nv);
                    rec_nv.TEN_NV = txtTenNV.Text.ToString().Trim();
                    rec_nv.DIACHI = txtDiachi.Text.ToString().Trim();
                    rec_nv.SODIENTHOAI = txtSdt.Text.ToString().Trim();
                    rec_nv.HINHANH = Common.ImageToByteArray(imgNV.Image);
                    rec_nv.GIOITINH = radiNu.Checked ? "Nữ" : "Nam";
                    int.TryParse(txtHeso.Text.ToString().Trim(), out int heso);
                    rec_l = context.LUONGs.FirstOrDefault(l => l.ID_NHAN_VIEN == ID_Selected_nv);
                    rec_l.HESO = heso;
                    int.TryParse(txtTongngay.Text.ToString(), out int songay);
                    rec_l.TONGNGAYLAM = songay;
                    rec_l.SONGAYNGHICOPHEP = int.Parse(txtPhep.Text.ToString());
                    rec_l.SONGAYNGHIKHONGPHEP = int.Parse(txtKophep.Text.ToString());
                    decimal.TryParse(txtDongia.Text.ToString(), out decimal gia);
                    rec_l.DONGIA = gia;
                    decimal luong = heso * songay * gia;
                    rec_l.TONGLUONG = luong;
                    await context.SaveChangesAsync();
                    RefreshforNew();
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radiNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radiNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
