using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webbanhang
{
    public partial class frmDMKhachHang : Form
    {
        public frmDMKhachHang()
        {
            InitializeComponent();
        }
        SABEntities3  context;
        KHACH_HANG rec_kh;
        List<KHACH_HANG> list_kh;
        int ID_Selected_kh = 0;
        int idx_DGView_kh;
        bool check = false;
        private void frmDMKhachHang_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_kh = new KHACH_HANG();
            list_kh = new List<KHACH_HANG>();
            Load_DgviewKH();
        }
        public void Load_DgviewKH()
        {
            list_kh= context.KHACH_HANG.ToList();
            if (list_kh.Count() != 0)
            {
                dgViewKH.DataSource = list_kh.Select(s => new {s.ID_KHACH_HANG ,s.TEN_KH, s.SODIENTHOAI, s.DIACHI, s.HINHANH }).ToList();
                formatDGView();
                txtSLKH.Text = list_kh.Count.ToString(); 
                txtSLKH.ReadOnly = true;
            }
        }
        public void formatDGView()
        {
            dgViewKH.Columns[0].HeaderText = "ID";
            dgViewKH.Columns[0].Width = 100;
            dgViewKH.Columns[1].HeaderText = "Tên khách hàng";
            dgViewKH.Columns[1].Width = 200;
            dgViewKH.Columns[2].HeaderText = "Số điện thoại";
            dgViewKH.Columns[2].Width = 200;
            dgViewKH.Columns[3].HeaderText = "Địa chỉ";
            dgViewKH.Columns[3].Width = 200;
            dgViewKH.Columns[4].HeaderText = "Hình ảnh";
            dgViewKH.Columns[4].Width = 200;
            dgViewKH.RowTemplate.Height = 100;
            dgViewKH.AllowUserToAddRows = false;
            dgViewKH.AllowUserToDeleteRows = false;
            dgViewKH.ReadOnly = true;
            dgViewKH.ForeColor = Color.Black;
            dgViewKH.DefaultCellStyle.Font = new Font("Arial", 14);
            dgViewKH.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);

        }

        private void imgKH_Click(object sender, EventArgs e)
        {
            openFileImage.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if(openFileImage.ShowDialog()== DialogResult.OK )
            {
                Image root_img, re_img;
                imgKH.SizeMode = PictureBoxSizeMode.StretchImage;
                root_img = new Bitmap(openFileImage.FileName);
                re_img = new Bitmap(root_img, new Size(200,100));
                imgKH.Image=re_img;
            }
        }


        public void EmptyControl()
        {
            txtTenKH.Clear();
            txtDiachiKH.Clear();
            txtSodienthoaiKH.Clear();
            imgKH.Image = null;
            raLoaiBanKH.Checked = true;
            txtTenKH.Select();
        }
        public bool checkEmpty()
        {
            if (txtTenKH.Text.Length == 0 || txtDiachiKH.Text.Length == 0 || txtSodienthoaiKH.Text.Length==0 || imgKH.Image == null)
            {
                return true;
            }
            else { return false; }
        }


        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewKH();
            rec_kh= new KHACH_HANG();
            ID_Selected_kh = 0;
        }

        private void dgViewKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (check == true)
            {
                string searchText = txtKeyKH.Text.Trim();
                list_kh = (from x in context.KHACH_HANG
                           where x.TEN_KH.Contains(searchText)
                           select x).ToList();
                idx_DGView_kh = dgViewKH.CurrentRow.Index;
                rec_kh = list_kh[idx_DGView_kh];
                ID_Selected_kh = rec_kh.ID_KHACH_HANG;
                txtTenKH.Text = rec_kh.TEN_KH;
                txtSodienthoaiKH.Text = rec_kh.SODIENTHOAI;
                txtDiachiKH.Text = rec_kh.DIACHI;
                if (rec_kh.SOB == true)
                {
                    raLoaiBanKH.Checked = true;
                }
                else
                {
                    raLoaiMuaKH.Checked = true;
                }
                imgKH.Image = Common.ByteArrayToImage(rec_kh.HINHANH);
                imgKH.SizeMode = PictureBoxSizeMode.StretchImage;
                check = false;
            }
            else
            {
                idx_DGView_kh = dgViewKH.CurrentRow.Index;
                rec_kh = list_kh[idx_DGView_kh];
                ID_Selected_kh = rec_kh.ID_KHACH_HANG;
                txtTenKH.Text = rec_kh.TEN_KH;
                txtSodienthoaiKH.Text = rec_kh.SODIENTHOAI;
                txtDiachiKH.Text = rec_kh.DIACHI;
                if (rec_kh.SOB == true)
                {
                    raLoaiBanKH.Checked = true;
                }
                else
                {
                    raLoaiMuaKH.Checked = true;
                }
                imgKH.Image = Common.ByteArrayToImage(rec_kh.HINHANH);
                imgKH.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }


     

        private void txtKeyKH_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtKeyKH.Text.Trim();
            int num = 0;
            if (!int.TryParse(searchText, out num))
            {
                var lsKH = (from x in context.KHACH_HANG
                            where x.TEN_KH.Contains(searchText)
                            select new
                            {
                                x.ID_KHACH_HANG,
                                x.TEN_KH,
                                x.SODIENTHOAI,
                                x.DIACHI,
                                x.HINHANH
                            }).ToList();
                dgViewKH.DataSource = lsKH;
                check = true;
                txtSLKH.Text = lsKH.ToList().Count().ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên", "Lỗi nhập", MessageBoxButtons.OK);
                txtKeyKH.Text = "";
            }
        }

        private void btnAddNewKH_Click(object sender, EventArgs e)
        {
            EmptyControl();
            rec_kh = new KHACH_HANG();
            ID_Selected_kh = 0;
        }

        private void btnDeleteKH_Click(object sender, EventArgs e)
        {
            if (ID_Selected_kh != 0)
            {
                if (MessageBox.Show("Bạn chắc muốn xóa?", "Cảnh báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    context.KHACH_HANG.Remove(rec_kh);
                    context.SaveChanges();
                    RefreshforNew();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveKH_Click_1(object sender, EventArgs e)
        {
            if (ID_Selected_kh == 0)
            {
                if (!checkEmpty())
                {
                    rec_kh.TEN_KH = txtTenKH.Text.ToString().Trim();
                    rec_kh.DIACHI = txtDiachiKH.Text.ToString().Trim();
                    rec_kh.SODIENTHOAI = txtSodienthoaiKH.Text.ToString().Trim();
                    rec_kh.HINHANH = Common.ImageToByteArray(imgKH.Image);
                    if (raLoaiBanKH.Checked == true)
                    {
                        rec_kh.SOB = true;
                    }
                    else
                    {
                        rec_kh.SOB = false;
                    }
                    context.KHACH_HANG.Add(rec_kh);
                    context.SaveChanges();
                    RefreshforNew();
                }
                else
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Thông tin khách hàng bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rec_kh.TEN_KH = txtTenKH.Text.ToString().Trim();
                    rec_kh.DIACHI = txtDiachiKH.Text.ToString().Trim();
                    rec_kh.SODIENTHOAI = txtSodienthoaiKH.Text.ToString().Trim();
                    rec_kh.HINHANH = Common.ImageToByteArray(imgKH.Image);
                    if (raLoaiBanKH.Checked == true)
                    {
                        rec_kh.SOB = true;
                    }
                    else
                    {
                        rec_kh.SOB = false;
                    }
                    context.SaveChanges();
                    RefreshforNew();
                }
            }
        }


    }
}
