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
using static webbanhang.frmDMSanPham;

namespace webbanhang
{
    public partial class frmThuoctinh : Form
    {
        public frmThuoctinh()
        {
            InitializeComponent();
        }
        SABEntities3 context;
        THUOC_TINH rec_tt;
        List<THUOC_TINH> list_tt;
        HANG_HOA rec_hh;
        List<HANG_HOA> list_hh;
        int ID_Selected_tt = 0;
        int idx_DGView_tt;
        bool check = false;

        private void frmThuoctinh_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_tt = new THUOC_TINH();
            list_tt = new List<THUOC_TINH>();
            Load_DgviewTT();
        }
        
        public void Load_DgviewTT()
        {
            list_tt = context.THUOC_TINH.ToList();
            if (list_tt.Count != 0)
            {
                var query = from thuoctinh in context.THUOC_TINH
                            join hanghoa in context.HANG_HOA on thuoctinh.ID_HANGHOA equals hanghoa.ID_HANGHOA into list_hh
                            from hhoa in list_hh.DefaultIfEmpty()
                            select new
                            {
                                TENHANGHOA = hhoa.TENHANGHOA,
                                TEN = thuoctinh.TEN,
                                GIATRI = thuoctinh.GIATRI,
                                HINHANH = thuoctinh.HINHANH,
                            };


                dgViewTT.DataSource = query.ToList();
                formatDGView();
                txtSLTT.Text = list_tt.Count().ToString();
                txtSLTT.ReadOnly = true;
            }
            else
            {
                dgViewTT.DataSource = null;
                txtSLTT.Text = list_tt.Count().ToString();
                txtSLTT.ReadOnly = true;
            }
        }
        public void formatDGView()
        {
            dgViewTT.Columns[0].HeaderText = "Tên hàng hóa";
            dgViewTT.Columns[0].Width = 200;
            dgViewTT.Columns[1].HeaderText = "Tên thuộc tính";
            dgViewTT.Columns[1].Width = 200;
            dgViewTT.Columns[2].HeaderText = "Giá trị";
            dgViewTT.Columns[2].Width = 200;
            dgViewTT.Columns[3].HeaderText = "Hình ảnh";
            dgViewTT.Columns[3].Width = 200;
            dgViewTT.RowTemplate.Height = 100;
            dgViewTT.AllowUserToAddRows = false;
            dgViewTT.AllowUserToDeleteRows = false;
            dgViewTT.ReadOnly = true;
            dgViewTT.BackgroundColor = Color.LightGray;
        }

 

        private void imgTT_Click(object sender, EventArgs e)
        {
            openFileImage.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileImage.ShowDialog() == DialogResult.OK)
            {
                Image root_img, re_img;
                imgTT.SizeMode = PictureBoxSizeMode.StretchImage;
                root_img = new Bitmap(openFileImage.FileName);
                re_img = new Bitmap(root_img, new Size(200, 100));
                imgTT.Image = re_img;
            }
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            EmptyControl();
            rec_tt = new THUOC_TINH();
            rec_hh = new HANG_HOA();
            ID_Selected_tt = 0;
        }
        public void EmptyControl()
        {
            txtTenHH.Clear();
            txtTenTT.Clear();
            txtGiatri.Clear();
            imgTT.Image = null;
            txtTenTT.Select();
        }
        public bool checkEmpty()
        {
            if (txtTenHH.Text.Length == 0 && txtTenTT.Text.Length == 0 && txtGiatri.Text.Length == 0 && imgTT == null)
            {
                return true;
            }
            else { return false; }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            btnsave_Click(sender, e, txtTenHH.Text.ToString().Trim());
        }

        private async void btnsave_Click(object sender, EventArgs e, string m)
        {
            if (ID_Selected_tt == 0)
            {
                if (!checkEmpty())
                {
                    //nếu đã có hàng hóa nhưng chưa thuộc tính thì lưu thuộc tính này cho hàng hóa đó bằng id hàng hóa 
                    var thh = await context.HANG_HOA.Where(h => h.TENHANGHOA == txtTenHH.Text.ToString().Trim()).ToArrayAsync();
                    if (thh.Any())
                    {
                        rec_tt.TEN = txtTenTT.Text.ToString().Trim();
                        rec_tt.GIATRI = txtGiatri.Text.ToString().Trim();
                        rec_tt.HINHANH = Common.ImageToByteArray(imgTT.Image);
                        var he = (from hh in context.HANG_HOA
                                  where hh.TENHANGHOA == txtTenHH.Text.ToString().Trim()
                                  select hh.ID_HANGHOA).ToList();
                        rec_tt.ID_HANGHOA = he.First();
                        context.THUOC_TINH.Add(rec_tt);
                        context.SaveChanges();
                        RefreshforNew();

                    }
                    //chưa có hàng hóa chưa có thuộc tính 
                    else
                    {
                        MessageBox.Show("Hàng hóa không tồn tại", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Thuộc tính hàng hóa bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rec_tt.TEN = txtTenTT.Text.ToString().Trim();
                    rec_tt.GIATRI = txtGiatri.Text.ToString().Trim();
                    rec_tt.HINHANH = Common.ImageToByteArray(imgTT.Image);
                    context.SaveChanges();
                    RefreshforNew();
                }
            }
        }
        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewTT();
            rec_tt = new THUOC_TINH();
            ID_Selected_tt = 0;
        }

        private async void dgViewTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(check == true)
            {
                string searchText = txtKeyTT.Text.Trim();
                list_tt = (from x in context.THUOC_TINH
                           where x.TEN.Contains(searchText)
                           select x).ToList();
                idx_DGView_tt = dgViewTT.CurrentRow.Index;
                rec_tt = list_tt[idx_DGView_tt];
                ID_Selected_tt = rec_tt.ID_THUOCTINH;
                txtTenTT.Text = rec_tt.TEN;
                var pl = await context.HANG_HOA.Where(p => p.ID_HANGHOA == rec_tt.ID_HANGHOA).ToListAsync();
                txtTenHH.Text = pl.FirstOrDefault().TENHANGHOA.ToString();
                txtGiatri.Text = rec_tt.GIATRI;
                imgTT.Image = Common.ByteArrayToImage(rec_tt.HINHANH);
                imgTT.SizeMode = PictureBoxSizeMode.StretchImage;
                check = false;
            }
            else
            {
                idx_DGView_tt = dgViewTT.CurrentRow.Index;
                rec_tt = list_tt[idx_DGView_tt];
                ID_Selected_tt = rec_tt.ID_THUOCTINH;
                txtTenTT.Text = rec_tt.TEN;
                var pl1 = await context.HANG_HOA.Where(p => p.ID_HANGHOA == rec_tt.ID_HANGHOA).ToListAsync();
                txtTenHH.Text = pl1.FirstOrDefault().TENHANGHOA.ToString();
                txtGiatri.Text = rec_tt.GIATRI;
                imgTT.Image = Common.ByteArrayToImage(rec_tt.HINHANH);
                imgTT.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
            
        }

        private async void btndel_Click(object sender, EventArgs e)
        {
            if (ID_Selected_tt != 0)
            {
                var hh = await context.THUOC_TINH.Where(h => h.ID_THUOCTINH == ID_Selected_tt).ToListAsync();
                if (hh.Any())
                    MessageBox.Show("Phân loại tồn tại sản phẩn", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (MessageBox.Show("Bạn chắc muốn xóa?", "Cảnh báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    context.THUOC_TINH.Remove(rec_tt);
                    context.SaveChanges();
                    RefreshforNew();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //to do: xem ko đúng id ko nhấp vào

        private async void txtKeyTT_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtKeyTT.Text.Trim();
            var lstt = (from x in context.THUOC_TINH
                        join n in context.HANG_HOA on x.ID_HANGHOA equals n.ID_HANGHOA
                        where x.TEN.Contains(searchText)
                        select new
                        {
                            n.TENHANGHOA,
                            x.TEN,
                            x.GIATRI,
                            x.HINHANH,
                        }
                        ).ToList();
            dgViewTT.DataSource = lstt;
            check = true;
            txtSLTT.Text = lstt.ToList().Count().ToString();
        }


    }
}
