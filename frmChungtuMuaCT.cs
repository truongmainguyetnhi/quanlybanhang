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

namespace webbanhang
{
    public partial class frmChungtuMuaCT : Form
    {
        string tentaikhoan = "", matkhau = "", loaiTK = "";

        public frmChungtuMuaCT(string tentaikhoan, string matkhau, string loaiTK)
        {
            InitializeComponent();
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            this.loaiTK = loaiTK;
        }

        SABEntities3 context;
        CHUNG_TU_MUA_CT rec_ctct;
        List<CHUNG_TU_MUA_CT> list_ctct;
        CHUNG_TU_MUA rec_ct;
        List<CHUNG_TU_MUA> list_ct;
        KHACH_HANG rec_kh;
        List<KHACH_HANG> list_kh;
        HANG_HOA rec_hh;
        List<HANG_HOA> list_hh;
        int ID_Selected_ctct = 0;
        int idx_DGView_ctct;
        bool check = false;

        private void frmChungtuMuaCT_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_ctct = new CHUNG_TU_MUA_CT();
            list_ctct = new List<CHUNG_TU_MUA_CT>();
            rec_kh = new KHACH_HANG();
            list_kh = new List<KHACH_HANG>();
            rec_hh = new HANG_HOA();
            list_hh = new List<HANG_HOA>();
            Load_DgviewHH();
            txtDiachi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtNgaydathang.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongso.ReadOnly = true;
            txtGiamua.ReadOnly = true;
            txtTenHH.ReadOnly = true;
            txtIDKH.ReadOnly = true;
            if (loaiTK == "nhanvien")
            {
                MessageBox.Show("Bạn không có quyền sửa đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnaddnew.Enabled = false;
                btnSave.Enabled =  false;
                txtSLHH.ReadOnly = true;
                txtIDHH.ReadOnly = true;
                txtMaCT.ReadOnly = true;
            }

        }
        public async void Load_DgviewHH()
        {
            list_ctct = context.CHUNG_TU_MUA_CT.ToList();
            if (list_ctct.Count != 0)
            {
                var query = await (from chungtu in context.CHUNG_TU_MUA_CT
                                   join hanghoa in context.HANG_HOA on chungtu.ID_HANGHOA equals hanghoa.ID_HANGHOA
                                   join ctu in context.CHUNG_TU_MUA on chungtu.ID_CTMUA equals ctu.ID_CTMUA
                                   join kh in context.KHACH_HANG on ctu.ID_KHACHHANG equals kh.ID_KHACH_HANG into list_cthh
                                   from cthh in list_cthh.DefaultIfEmpty()
                                   select new
                                   {
                                       ID_HANGHOA = hanghoa.ID_HANGHOA,
                                       ID_KHACH_HANG = cthh.ID_KHACH_HANG,
                                       TENHANGHOA = hanghoa.TENHANGHOA,
                                       SOLUONG = chungtu.SOLUONG,
                                       GIAMUA = chungtu.GIAMUA,
                                       THANHTIEN = chungtu.THANHTIEN
                                   }).ToListAsync();
                dgViewCTCT.DataSource = query;
                formatDGView();
                txtTongso.Text = list_ctct.Count().ToString();
            }
            else
            {
                dgViewCTCT.DataSource = null;
                txtTongso.Text = list_ctct.Count().ToString();
            }
        }
        public void formatDGView()
        {
            dgViewCTCT.Columns[0].HeaderText = "ID Hàng hóa";
            dgViewCTCT.Columns[0].Width = 150;
            dgViewCTCT.Columns[1].HeaderText = "ID khách hàng";
            dgViewCTCT.Columns[1].Width = 150;
            dgViewCTCT.Columns[2].HeaderText = "Tên hàng hóa";
            dgViewCTCT.Columns[2].Width = 150;
            dgViewCTCT.Columns[3].HeaderText = "Số lượng";
            dgViewCTCT.Columns[3].Width = 150;
            dgViewCTCT.Columns[4].HeaderText = "Giá mua";
            dgViewCTCT.Columns[4].Width = 150;
            dgViewCTCT.Columns[5].HeaderText = "Thành tiền";
            dgViewCTCT.Columns[5].Width = 150;
            dgViewCTCT.AllowUserToAddRows = false;
            dgViewCTCT.AllowUserToDeleteRows = false;
            dgViewCTCT.ReadOnly = true;
            dgViewCTCT.BackgroundColor = Color.LightGray;
        }








        private void btnaddnew_Click(object sender, EventArgs e)
        {
            EmptyControl();
            rec_ctct = new CHUNG_TU_MUA_CT();
            rec_ct = new CHUNG_TU_MUA();
            rec_kh = new KHACH_HANG();
            rec_hh = new HANG_HOA();
            ID_Selected_ctct = 0;
        }
        public void EmptyControl()
        {
            txtTenKH.Clear();
            txtDiachi.Clear();
            txtIDKH.Clear();
            txtMaCT.Clear();
            txtNgaydathang.Clear();
            txtTenHH.Clear();
            txtIDHH.Clear();
            txtThanhtien.Clear();
            txtSDT.Clear();
            txtGiamua.Clear();
            txtSLHH.Clear();
            txtTongso.Clear();
            txtIDHH.ReadOnly = false;
            txtMaCT.Select();
        }
        public bool checkEmpty()
        {
            if (txtTenHH.Text.Length == 0 && txtIDHH.Text.Length == 0 && txtThanhtien.Text.Length == 0
                && txtGiamua.Text.Length == 0 && txtSLHH.Text.Length == 0 && txtTongso.Text.Length == 0)
            {
                return true;
            }
            else { return false; }
        }

        private async void dgViewCTCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (check == true)
            {
                string searchText = txtMaCT.Text.Trim();
                list_ctct = await(from x in context.CHUNG_TU_MUA_CT
                                  where x.ID_CTMUA.ToString().Contains(searchText)
                                  select x).ToListAsync();
                idx_DGView_ctct = dgViewCTCT.CurrentRow.Index;
                rec_ctct = list_ctct[idx_DGView_ctct];
                txtMaCT.Text = rec_ctct.ID_CTMUA.ToString();
                ID_Selected_ctct = (int)rec_ctct.ID_HANGHOA;
                txtGiamua.Text = rec_ctct.GIAMUA.ToString() + " VND";
                txtSLHH.Text = rec_ctct.SOLUONG.ToString();
                txtThanhtien.Text = rec_ctct.THANHTIEN.ToString() + " VND";
                txtTongso.ReadOnly = true;
                var hh = await context.HANG_HOA.Where(p => p.ID_HANGHOA == rec_ctct.ID_HANGHOA).ToListAsync();
                txtIDHH.Text = rec_ctct.ID_HANGHOA.ToString();

                txtTenHH.Text = hh.FirstOrDefault().TENHANGHOA.ToString();
                txtTenHH.ReadOnly = true;
                txtIDHH.ReadOnly = true;
                check = false;
            }
            else
            {
                idx_DGView_ctct = dgViewCTCT.CurrentRow.Index;
                rec_ctct = list_ctct[idx_DGView_ctct];
                txtMaCT.Text = rec_ctct.ID_CTMUA.ToString();
                ID_Selected_ctct = (int)rec_ctct.ID_HANGHOA;
                txtSLHH.Text = rec_ctct.SOLUONG.ToString();
                txtThanhtien.Text = rec_ctct.THANHTIEN.ToString() + " VND";
                txtGiamua.Text = rec_ctct.GIAMUA.ToString() + " VND";
                txtTongso.ReadOnly = true;
                var hh = await context.HANG_HOA.Where(p => p.ID_HANGHOA == rec_ctct.ID_HANGHOA).ToListAsync();
                txtIDHH.Text = rec_ctct.ID_HANGHOA.ToString();
                txtTenHH.Text = hh.FirstOrDefault().TENHANGHOA.ToString();
                txtTenHH.ReadOnly = true;
                txtIDHH.ReadOnly = true;
            }
        }
        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewHH();
            rec_ctct = new CHUNG_TU_MUA_CT();
            ID_Selected_ctct = 0;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ID_Selected_ctct == 0)
            {
                if (!checkEmpty())
                {
                    if (txtMaCT.Text.Length == 0)
                    {
                        MessageBox.Show("Chưa nhập mã chứng từ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int.TryParse(txtIDHH.Text.ToString(), out int idhh);
                        rec_ctct.ID_HANGHOA = idhh;
                        var query = (
                                     from hh in context.HANG_HOA
                                     join dg in context.DON_GIA_BAN on hh.ID_HANGHOA equals dg.ID_HANGHOA into list_dg
                                     from gia in list_dg.DefaultIfEmpty()
                                     where hh.ID_HANGHOA == idhh
                                     select gia.GIATRI).ToList();
                        var giamua = query.First().ToString();
                        decimal.TryParse(giamua.ToString(), out decimal giamua1);
                        txtGiamua.Text = (giamua1).ToString();
                        decimal.TryParse(txtGiamua.Text.ToString(), out decimal gb);
                        rec_ctct.GIAMUA = gb;
                        rec_ctct.SOLUONG = int.Parse(txtSLHH.Text.ToString());
                        decimal.TryParse(txtSLHH.Text.ToString(), out decimal sl);
                        rec_ctct.THANHTIEN = (int)gb * (int)sl;
                        txtThanhtien.ReadOnly = true;
                        int.TryParse(txtMaCT.Text.ToString(), out int idct);
                        rec_ctct.ID_CTMUA = idct;
                        context.CHUNG_TU_MUA_CT.Add(rec_ctct);
                        context.SaveChanges();
                        RefreshforNew();
                    }
                }
            }
            else
            {
               

                    if (MessageBox.Show("Thuộc tính hàng hóa của chứng từ bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int.TryParse(txtIDHH.Text.ToString(), out int idhh);
                        var query = await (from hh in context.HANG_HOA
                                           join dg in context.DON_GIA_BAN on hh.ID_HANGHOA equals dg.ID_HANGHOA into list_dg
                                           from gia in list_dg.DefaultIfEmpty()
                                           where hh.ID_HANGHOA == idhh
                                           select gia.GIATRI).ToListAsync();
                        var giamua = query.First().ToString();
                        decimal.TryParse(giamua.ToString(), out decimal giamua1);
                        txtGiamua.Text = (giamua1).ToString();
                        decimal.TryParse(txtGiamua.Text.ToString(), out decimal gb);
                        rec_ctct.GIAMUA = gb;
                        rec_ctct.SOLUONG = int.Parse(txtSLHH.Text.ToString());
                        decimal.TryParse(txtSLHH.Text.ToString(), out decimal sl);
                        rec_ctct.THANHTIEN = (int)gb * (int)sl;
                        txtThanhtien.ReadOnly = true;
                        context.SaveChanges();
                        RefreshforNew();
                    }
                
            }
        }

        private async void txtMaCT_MouseLeave(object sender, EventArgs e)
        {
            var dk = await context.CHUNG_TU_MUA.Where(d => d.MASOCT == txtMaCT.Text).ToListAsync();
            string searchText = txtMaCT.Text.Trim();
            if (dk.Any())
            {
                var lsCT = await (from x in context.CHUNG_TU_MUA_CT
                                  join h in context.HANG_HOA on x.ID_HANGHOA equals h.ID_HANGHOA
                                  join c in context.CHUNG_TU_MUA on x.ID_CTMUA equals c.ID_CTMUA
                                  join k in context.KHACH_HANG on c.ID_KHACHHANG equals k.ID_KHACH_HANG
                                  where x.ID_CTMUA.ToString().Contains(searchText)
                                  select new
                                  {
                                      h.ID_HANGHOA,
                                      k.ID_KHACH_HANG,
                                      h.TENHANGHOA,
                                      x.SOLUONG,
                                      x.GIAMUA,
                                      x.THANHTIEN
                                  }
                            ).ToListAsync();
                dgViewCTCT.DataSource = lsCT;
                check = true;
                txtTongso.Text = lsCT.Count().ToString();

                var lot = await (from ctu in context.CHUNG_TU_MUA
                                 join khang in context.KHACH_HANG on ctu.ID_KHACHHANG equals khang.ID_KHACH_HANG
                                 where ctu.ID_CTMUA.ToString().Contains(searchText)
                                 select new
                                 {
                                     ID_KHACH_HANG = khang.ID_KHACH_HANG,
                                     TEN_KH = khang.TEN_KH,
                                     DIACHI = khang.DIACHI,
                                     SODIENTHOAI = khang.SODIENTHOAI,
                                     NGAYPHATSINH = ctu.NGAYPHATSINH
                                 }).ToListAsync();
                txtIDKH.Text = lot.First().ID_KHACH_HANG.ToString();
                txtTenKH.Text = lot.First().TEN_KH.ToString();
                txtDiachi.Text = lot.First().DIACHI.ToString();
                txtSDT.Text = lot.First().SODIENTHOAI.ToString();
                txtNgaydathang.Text = lot.First().NGAYPHATSINH.ToString();
            }

            else
            {
                MessageBox.Show("Mã chứng từ không tồn tại", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void txtIDHH_MouseLeave(object sender, EventArgs e)
        {
            string eng = txtIDHH.Text.ToString();
            int.TryParse(eng, out int englot);
            var hang = await context.HANG_HOA.Where(h => h.ID_HANGHOA == englot).ToListAsync();
            if (hang.Any())
            {
                var engeng = await(from ef in context.HANG_HOA
                                   join cl in context.DON_GIA_BAN on ef.ID_HANGHOA equals cl.ID_HANGHOA
                                   where ef.ID_HANGHOA.ToString().Contains(eng)
                                   select new
                                   {
                                       TENHANGHOA = ef.TENHANGHOA,
                                       GIATRI = cl.GIATRI
                                   }).ToListAsync();
                txtTenHH.Text = engeng.First().TENHANGHOA;
                var giamua = engeng.First().GIATRI.ToString();
                decimal.TryParse(giamua.ToString(), out decimal giamua1);
                txtGiamua.Text = (giamua1).ToString() + " VND";

            }
            else
                MessageBox.Show("Hàng hóa không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
