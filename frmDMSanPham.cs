using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static webbanhang.frmPhanloai;

namespace webbanhang
{
    public partial class frmDMSanPham : Form
    {
        public frmDMSanPham()
        {
            InitializeComponent();
        }
        SABEntities3 context;
        HANG_HOA rec_hh;
        List<HANG_HOA> list_hh;
        PHAN_LOAI rec_pl;
        List<PHAN_LOAI> list_pl;
        DON_GIA_BAN rec_dgb;
        List<DON_GIA_BAN> list_dgb;
        int ID_Selected_hh = 0;
        int idx_DGView_hh;
        int idx_DGView_dg;

        private void frmDMSanPham_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_hh = new HANG_HOA();
            list_hh = new List<HANG_HOA>();
            rec_pl = new PHAN_LOAI();
            list_pl = new List<PHAN_LOAI>();
            rec_dgb = new DON_GIA_BAN();
            list_dgb = new List<DON_GIA_BAN>();
            Load_DgviewHH();
        }

        public class HangHoa
        {
            public int ID_HANGHOA { get; set; }
            public string TENHANGHOA { get; set; }
            public string MOTA { get; set; }
            public string DONVITINH { get; set; }
            public byte[] HINHANH { get; set; }
            public string TENPHANLOAI { get; set; }
            public decimal? GIATRI { get; set; }
            public DateTime? NGAYBATDAU { get; set; }
        }

        public void Load_DgviewHH()
        {
                list_hh = context.HANG_HOA.ToList();
                if (list_hh.Count != 0)
                {
                var query = from hanghoa in context.HANG_HOA
                            join phanloai in context.PHAN_LOAI on hanghoa.ID_PHANLOAI equals phanloai.ID_PHANLOAI into list_pl
                            from ploai in list_pl.DefaultIfEmpty()
                            select new 
                            {
                                ID_HANGHOA = hanghoa.ID_HANGHOA,
                                TENHANGHOA = hanghoa.TENHANGHOA,
                                MOTA = hanghoa.MOTA,
                                DONVITINH = hanghoa.DONVITINH,
                                HINHANH = hanghoa.HINHANH,
                                TENPHANLOAI = ploai.TENPHANLOAI,

                                //GIATRI = 0,
                                //NGAYBATDAU = null
                            };

                
                    dgViewSP.DataSource = query.ToList();
                    formatDGView();
                    txtSLSP.Text = list_hh.Count().ToString();
                    txtSLSP.ReadOnly = true;
            }
            else
                {
                    dgViewSP.DataSource = null;
                    txtSLSP.Text = list_hh.Count().ToString();
                    txtSLSP.ReadOnly = true;
                }
                var pl = context.PHAN_LOAI.ToList();
                comboBoxPL.DataSource = pl;
                comboBoxPL.DisplayMember = "TENPHANLOAI";
                comboBoxPL.ValueMember = "ID_PHANLOAI";
        }
        public void formatDGView()
        {
            dgViewSP.Columns[0].HeaderText = "Id";
            dgViewSP.Columns[0].Width = 200;
            dgViewSP.Columns[1].HeaderText = "Tên sản phẩm";
            dgViewSP.Columns[1].Width = 200;
            dgViewSP.Columns[2].HeaderText = "Mô tả";
            dgViewSP.Columns[2].Width = 200;
            dgViewSP.Columns[3].HeaderText = "Đơn vị tính";
            dgViewSP.Columns[3].Width = 200;
            dgViewSP.Columns[4].HeaderText = "Hình ảnh";
            dgViewSP.Columns[4].Width = 200;
            dgViewSP.Columns[5].HeaderText = "Phân loại";
            dgViewSP.Columns[5].Width = 200;
            dgViewSP.RowTemplate.Height = 100;
            dgViewSP.AllowUserToAddRows = false;
            dgViewSP.AllowUserToDeleteRows = false;
            dgViewSP.ReadOnly = true;
            dgViewSP.ForeColor = Color.Black;
            dgViewSP.DefaultCellStyle.Font = new Font("Time new roman", 12);
        }

        private void imgSP_Click(object sender, EventArgs e)
        {
            openFileImage.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileImage.ShowDialog() == DialogResult.OK)
            {
                Image root_img, re_img;
                imgSP.SizeMode = PictureBoxSizeMode.StretchImage;
                root_img = new Bitmap(openFileImage.FileName);
                re_img = new Bitmap(root_img, new Size(200, 100));
                imgSP.Image = re_img;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            EmptyControl();
            rec_hh = new HANG_HOA();
            rec_pl = new PHAN_LOAI();
            rec_dgb = new DON_GIA_BAN();
            ID_Selected_hh = 0;
            Load_dgviewgia();
        }
        public void EmptyControl()
        {
            txtTenSP.Clear();
            txtmota.Clear();
            txtdonvi.Clear();
            imgSP.Image = null;
            txtdongia.Clear();
            txtTenSP.Select();
        }
        public bool checkEmpty()
        {
            if (txtTenSP.Text.Length == 0 || txtmota.Text.Length == 0 || txtdonvi.Text.Length == 0
                || txtdongia.Text.Length == 0 || imgSP.Image == null)
            {
                return true;
            }
            else { return false; }
        }

        private async void btnluu_Click(object sender, EventArgs e)
        {
            if (ID_Selected_hh == 0)
            {
                if (!checkEmpty())
                {
                    rec_hh.TENHANGHOA = txtTenSP.Text.ToString().Trim();
                    rec_hh.MOTA = txtmota.Text.ToString().Trim();
                    rec_hh.DONVITINH = txtdonvi.Text.ToString().Trim();
                    rec_hh.HINHANH = Common.ImageToByteArray(imgSP.Image);
                    int maxIdHangHoa = await context.HANG_HOA.MaxAsync(h => h.ID_HANGHOA);
                    rec_hh.ID_HANGHOA = maxIdHangHoa + 1;
                    //rec_hh.ID_PHANLOAI = int.Parse(comboBoxPL.ValueMember);
                    rec_hh.ID_PHANLOAI = int.Parse(comboBoxPL.SelectedValue.ToString().Trim());
                     context.HANG_HOA.Add(rec_hh);
                    //rec_pl.TENPHANLOAI = comboBoxPL.Text.ToString().Trim();
                    //context.PHAN_LOAI.Add(rec_pl);
                    decimal.TryParse(txtdongia.Text.ToString(), out decimal giatri);
                    rec_dgb.GIATRI = giatri;
                    rec_dgb.NGAYBATDAU = dateTimePicker1.Value;
                    rec_dgb.APDUNG = rec_dgb.NGAYBATDAU.Value.Ticks < DateTime.Now.Ticks;
                    rec_dgb.ID_HANGHOA = rec_hh.ID_HANGHOA;
                    context.DON_GIA_BAN.Add(rec_dgb);
                    await context.SaveChangesAsync();
                    RefreshforNew();
                    
                }
                else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show("Thông tin khách hàng bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rec_hh.TENHANGHOA = txtTenSP.Text.ToString().Trim();
                    rec_hh.MOTA = txtmota.Text.ToString().Trim();
                    rec_hh.DONVITINH = txtdonvi.Text.ToString().Trim();
                    rec_hh.HINHANH = Common.ImageToByteArray(imgSP.Image);
                    rec_hh.ID_PHANLOAI = int.Parse(comboBoxPL.SelectedValue.ToString().Trim());
                    // To do : hiển thị danh sách giá, không cho thay đổi - xóa quá khứ, chỉ đc thêm sửa xóa mốc thời gian ơr tương lai
                    if (dateTimePicker1.Value < DateTime.Now)
                    {
                        MessageBox.Show("Không thể thay đổi giá cũ", "Thông báo thay đổi thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        decimal.TryParse(txtdongia.Text.ToString(), out decimal giatri);
                        rec_dgb.GIATRI = giatri;
                        rec_dgb.NGAYBATDAU = dateTimePicker1.Value;
                        rec_dgb.APDUNG = rec_dgb.NGAYBATDAU.Value.Ticks < DateTime.Now.Ticks;
                        rec_dgb.ID_HANGHOA = rec_hh.ID_HANGHOA;
                        context.DON_GIA_BAN.Add(rec_dgb);
                        context.SaveChanges();
                        RefreshforNew();
                    }
                }
            }
            Load_dgviewgia();
        }
        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewHH();
            rec_hh = new HANG_HOA();
            ID_Selected_hh = 0;
        }
        private async void dgViewSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int.TryParse(dgViewSP[0, e.RowIndex].Value.ToString(), out ID_Selected_hh);
            rec_hh = await context.HANG_HOA.FirstOrDefaultAsync(h => h.ID_HANGHOA == ID_Selected_hh);
            txtTenSP.Text = rec_hh.TENHANGHOA;
            txtmota.Text = rec_hh.MOTA;
            txtdonvi.Text = rec_hh.DONVITINH;
            var pl = await context.PHAN_LOAI.Where(p => p.ID_PHANLOAI == rec_hh.ID_PHANLOAI).ToListAsync();
            comboBoxPL.Text = pl.FirstOrDefault().TENPHANLOAI.ToString();

            // To do : hiển thị danh sách giá, không cho thay đổi - xóa quá khứ, chỉ đc thêm sửa xóa mốc thời gian ơr tương lai
            /*var dsdg = await context.DON_GIA_BAN.Where(d => d.ID_HANGHOA == ID_Selected_hh).ToListAsync();
            if (dsdg.Any())
            {
                txtdongia.Text = dsdg.First().GIATRI.ToString();
                dateTimePicker1.Value = dsdg.FirstOrDefault().NGAYBATDAU.Value;
            }*/
            if (rec_hh.HINHANH != null)
            {
                imgSP.Image = Common.ByteArrayToImage(rec_hh.HINHANH);
                imgSP.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            txtdongia.Clear();
            dateTimePicker1.CustomFormat = " ";
            Load_dgviewgia();
        }

        private async void btnxoa_Click(object sender, EventArgs e)
        {
            if (ID_Selected_hh != 0)
            {
                var ctb = await context.CHUNG_TU_BAN_CT.Where(ct => ct.ID_HANGHOA == ID_Selected_hh).ToListAsync();
                if (ctb.Any())
                    MessageBox.Show("Không thể xóa sản phẩm", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (MessageBox.Show("Bạn chắc muốn xóa?", "Cảnh báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    context.HANG_HOA.Remove(rec_hh);
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

        private void txtKeySP_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtKeySP.Text.Trim();
            int num = 0;
            if (!int.TryParse(searchText, out num))
            {
                var lsSP = (from hanghoa in context.HANG_HOA
                            join phanloai in context.PHAN_LOAI on hanghoa.ID_PHANLOAI equals phanloai.ID_PHANLOAI
                            where hanghoa.TENHANGHOA.Contains(searchText)
                            select new
                            {
                                TENHANGHOA = hanghoa.TENHANGHOA,
                                MOTA = hanghoa.MOTA,
                                DONVITINH = hanghoa.DONVITINH,
                                HINHANH = hanghoa.HINHANH,
                                TENPHANLOAI = phanloai.TENPHANLOAI,
                                ID_HANGHOA = hanghoa.ID_HANGHOA
                            }
                        ).ToList();
                dgViewSP.DataSource = lsSP;
                txtSLSP.Text = lsSP.Count().ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên", "Lỗi nhập", MessageBoxButtons.OK);
                txtKeySP.Text = "";
            }
        }

        public void Load_dgviewgia()
        {

            list_hh = context.HANG_HOA.ToList();
            if (ID_Selected_hh != 0)
            {
                var he = context.DON_GIA_BAN
                    .Where(dgb => dgb.ID_HANGHOA == ID_Selected_hh)
                    .Select(dgia => new
                    {
                        GIATRI = dgia.GIATRI,
                        NGAYBATDAU = dgia.NGAYBATDAU.Value,
                        ID_DONGIA = dgia.ID_DONGIA
                    })
                    .ToList();
                dgViewgia.DataSource = he;
                formatDGViewgia();
            }
            else
            {
                dgViewgia.DataSource = null;
            }
        }
        public void formatDGViewgia()
        {
            dgViewgia.Columns[0].HeaderText = "Giá trị";
            dgViewgia.Columns[0].Width = 150;
            dgViewgia.Columns[1].HeaderText = "Ngày bắt đầu";
            dgViewgia.Columns[1].Width = 150;
            dgViewgia.RowTemplate.Height = 20;
            dgViewgia.AllowUserToAddRows = false;
            dgViewgia.AllowUserToDeleteRows = false;
            dgViewgia.ReadOnly = true;
            dgViewgia.ForeColor = Color.Black;
            dgViewgia.DefaultCellStyle.Font = new Font("Time new roman", 12);
        }

        private async void dgViewgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //list_dgb = context.DON_GIA_BAN.ToList();
            
            list_dgb = context.DON_GIA_BAN.Where(h => h.ID_HANGHOA == ID_Selected_hh).ToList();

            idx_DGView_dg = dgViewgia.CurrentRow.Index;
            rec_dgb = list_dgb[idx_DGView_dg];
            ID_Selected_hh = rec_hh.ID_HANGHOA;
            txtdongia.Text = rec_dgb.GIATRI.ToString();
            dateTimePicker1.Value = rec_dgb.NGAYBATDAU.Value;
        }


        private void txtdongia_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = txtdongia.Text.Trim();
            int num = 0;
            if (!int.TryParse(searchText, out num))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi nhập", MessageBoxButtons.OK);
                txtdongia.Text = "";
            }
        }
    }
}
