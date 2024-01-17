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
    public partial class frmChungtuBanCT : Form
    {
        string tentaikhoan = "", matkhau = "", loaiTK = "";
        public frmChungtuBanCT(string tentaikhoan, string matkhau, string loaiTK)
        {
            InitializeComponent();
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            this.loaiTK = loaiTK;
        }
        SABEntities3 context;
        CHUNG_TU_BAN_CT rec_ctct;
        List<CHUNG_TU_BAN_CT> list_ctct;
        CHUNG_TU_BAN rec_ct;
        List<CHUNG_TU_BAN> list_ct;
        KHACH_HANG rec_kh;
        List<KHACH_HANG> list_kh;
        HANG_HOA rec_hh;
        List<HANG_HOA> list_hh;
        int ID_Selected_ctct = 0;
        int idx_DGView_ctct;
        bool check = false;
        private void frmChungtuBanCT_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_ctct = new CHUNG_TU_BAN_CT();
            list_ctct = new List<CHUNG_TU_BAN_CT>();
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
            txtGiaban.ReadOnly = true;
            txtTenHH.ReadOnly = true;
            txtIDKH.ReadOnly = true;
            if (loaiTK == "nhanvien")
            {
                MessageBox.Show("Bạn không có quyền sửa đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                btnaddnew.Enabled = false;
                txtSLHH.ReadOnly = true;
                txtIDHH.ReadOnly = true;
                txtMaCT.ReadOnly = true;
            }
        }
        public  async void Load_DgviewHH()
        {
            list_ctct = context.CHUNG_TU_BAN_CT.ToList();
            if (list_ctct.Count != 0)
            {
                var query = await (from chungtu in context.CHUNG_TU_BAN_CT
                                   join hanghoa in context.HANG_HOA on chungtu.ID_HANGHOA equals hanghoa.ID_HANGHOA
                                   join ctu in context.CHUNG_TU_BAN on chungtu.ID_CTBAN equals ctu.ID_CTBAN
                                   join kh in context.KHACH_HANG on ctu.ID_KHACHHANG equals kh.ID_KHACH_HANG into list_cthh
                                   from cthh in list_cthh.DefaultIfEmpty()
                                   select new
                                   {
                                       ID_HANGHOA = hanghoa.ID_HANGHOA,
                                       ID_KHACH_HANG = cthh.ID_KHACH_HANG,
                                       TENHANGHOA = hanghoa.TENHANGHOA,
                                       SOLUONG = chungtu.SOLUONG,
                                       GIABAN = chungtu.GIABAN,
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
            dgViewCTCT.Columns[0].Width = 200;
            dgViewCTCT.Columns[1].HeaderText = "ID khách hàng";
            dgViewCTCT.Columns[1].Width = 200;
            dgViewCTCT.Columns[2].HeaderText = "Tên hàng hóa";
            dgViewCTCT.Columns[2].Width = 200;
            dgViewCTCT.Columns[3].HeaderText = "Số lượng";
            dgViewCTCT.Columns[3].Width = 200;
            dgViewCTCT.Columns[4].HeaderText = "Giá bán";
            dgViewCTCT.Columns[4].Width = 200;
            dgViewCTCT.Columns[5].HeaderText = "Thành tiền";
            dgViewCTCT.Columns[5].Width = 200;
            dgViewCTCT.AllowUserToAddRows = false;
            dgViewCTCT.AllowUserToDeleteRows = false;
            dgViewCTCT.ReadOnly = true;
            dgViewCTCT.BackgroundColor = Color.LightGray;
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            EmptyControl();
            rec_ctct = new CHUNG_TU_BAN_CT();
            rec_ct = new CHUNG_TU_BAN();
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
            txtGiaban.Clear();
            txtSLHH.Clear();
            txtTongso.Clear();
            txtIDHH.ReadOnly = false;
            txtMaCT.Select();
        }
        public bool checkEmpty()
        {
            if (txtTenHH.Text.Length == 0 && txtIDHH.Text.Length == 0 && txtThanhtien.Text.Length == 0 
                && txtGiaban.Text.Length == 0 && txtSLHH.Text.Length == 0 && txtTongso.Text.Length == 0)
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
                list_ctct = await (from x in context.CHUNG_TU_BAN_CT
                           where x.ID_CTBAN.ToString().Contains(searchText)
                           select x).ToListAsync();
                idx_DGView_ctct = dgViewCTCT.CurrentRow.Index;
                rec_ctct = list_ctct[idx_DGView_ctct];
                txtMaCT.Text = rec_ctct.ID_CTBAN.ToString();
                ID_Selected_ctct = (int)rec_ctct.ID_HANGHOA;
                txtGiaban.Text = rec_ctct.GIABAN.ToString() + " VND";
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
                txtMaCT.Text = rec_ctct.ID_CTBAN.ToString();
                ID_Selected_ctct = (int)rec_ctct.ID_HANGHOA;
                txtSLHH.Text = rec_ctct.SOLUONG.ToString();
                txtThanhtien.Text = rec_ctct.THANHTIEN.ToString() + " VND";
                txtGiaban.Text = rec_ctct.GIABAN.ToString() + " VND";
                txtTongso.ReadOnly = true;
                var hh = await context.HANG_HOA.Where(p => p.ID_HANGHOA == rec_ctct.ID_HANGHOA).ToListAsync();
                txtIDHH.Text = rec_ctct.ID_HANGHOA.ToString();
                txtTenHH.Text = hh.FirstOrDefault().TENHANGHOA.ToString();
                txtTenHH.ReadOnly = true;
                txtIDHH.ReadOnly = true;
            }
        }
        #region macttextchange
        /*private void txtMaCT_TextChanged(object sender, EventArgs e)
        {
            var dk = context.CHUNG_TU_BAN.Where(d => d.MASOCT == txtMaCT.Text).ToList();
            if (dk.Any())
            {
                SABEntities1 context = new SABEntities1();
                string searchText = txtMaCT.Text.Trim();
                var lsCT = (from x in context.CHUNG_TU_BAN_CT
                            join h in context.HANG_HOA on x.ID_HANGHOA equals h.ID_HANGHOA
                            where x.ID_CTBAN.ToString().Contains(searchText)
                            select new
                            {
                                h.ID_HANGHOA,
                                h.TENHANGHOA,
                                x.SOLUONG,
                                x.GIABAN,
                                x.THANHTIEN
                            }
                            ).ToList();
                dgViewCTCT.DataSource = lsCT;
                var ma = (from ct in context.CHUNG_TU_BAN
                          where ct.ID_CTBAN.ToString().Contains(searchText)
                          select ct).ToList();
                txtNgaydathang.Text = ma.FirstOrDefault().NGAYDATHANG.ToString();
                var lot = (from chitiet in context.CHUNG_TU_BAN_CT
                           join ctu in context.CHUNG_TU_BAN on chitiet.ID_CTBAN equals ctu.ID_CTBAN
                           join khang in context.KHACH_HANG on ctu.ID_KHACHHANG equals khang.ID_KHACH_HANG
                           where ctu.MASOCT.ToString().Contains(searchText)
                           select new
                           {
                               khang.ID_KHACH_HANG,
                               khang.TEN_KH,
                               khang.DIACHI,
                               khang.SODIENTHOAI
                           }).ToList();
                txtIDKH.Text = lot.First().ID_KHACH_HANG.ToString();
                txtTenKH.Text = lot.First().TEN_KH.ToString();
                txtDiachi.Text = lot.First().DIACHI.ToString();
                txtSDT.Text = lot.First().SODIENTHOAI.ToString();
                check = true;
                txtTongso.Text = lsCT.Count().ToString();
            }
            else
            {
                MessageBox.Show("Mã chứng từ không tồn tại", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/
        #endregion
        #region del
        /*private void btndel_Click(object sender, EventArgs e)
        {
            
            if (txtIDHH.Text.Length != 0)
            {
                if (MessageBox.Show("Bạn chắc muốn xóa?", "Cảnh báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    context.CHUNG_TU_BAN_CT.Remove(rec_ctct);
                    context.SaveChanges();
                    RefreshforNew();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/
        #endregion
        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewHH();
            rec_ctct = new CHUNG_TU_BAN_CT();
            ID_Selected_ctct = 0;
        }
        #region nhapidhieninfo
        /*
        private void txtIDKH_MouseLeave(object sender, EventArgs e)
        {
            if (txtIDKH.Text.Length > 0)
            {
                int.TryParse(txtIDKH.Text.ToString(), out int id);
                var he = (from kh in context.KHACH_HANG
                          join ct in context.CHUNG_TU_BAN on kh.ID_KHACH_HANG equals ct.ID_KHACHHANG
                          where kh.ID_KHACH_HANG == id
                          select new
                          {
                              kh.ID_KHACH_HANG,
                              ct.NGAYDATHANG,
                              kh.TEN_KH,
                              kh.DIACHI,
                              kh.SODIENTHOAI
                          }).ToList();
                txtTenKH.Text = he.FirstOrDefault().TEN_KH.ToString();
                txtDiachi.Text = he.FirstOrDefault().DIACHI.ToString();
                txtSDT.Text = he.FirstOrDefault().SODIENTHOAI;               
                txtNgaydathang.Text = he.First().NGAYDATHANG.ToString();
                txtTenKH.ReadOnly = true;
                txtDiachi.ReadOnly = true;
                txtSDT.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Chưa nhập ID khách hàng", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        */
        #endregion
        private async void btnSave_Click(object sender, EventArgs e)
        {
            #region savecu
            
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
                        var giaban = query.First().ToString();
                        decimal.TryParse(giaban.ToString(), out decimal giaban1);
                        txtGiaban.Text = ((giaban1 * 30 / 100) + giaban1).ToString();
                        decimal.TryParse(txtGiaban.Text.ToString(), out decimal gb);
                        rec_ctct.GIABAN = gb;
                        rec_ctct.SOLUONG = int.Parse(txtSLHH.Text.ToString());
                        decimal.TryParse(txtSLHH.Text.ToString(), out decimal sl);
                        rec_ctct.THANHTIEN = (int)gb * (int)sl;
                        txtThanhtien.ReadOnly = true;
                        int.TryParse(txtMaCT.Text.ToString(), out int idct);
                        rec_ctct.ID_CTBAN = idct;
                        context.CHUNG_TU_BAN_CT.Add(rec_ctct);
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
                        var giaban = query.First().ToString();
                        decimal.TryParse(giaban.ToString(), out decimal giaban1);
                        txtGiaban.Text = ((giaban1 * 30 / 100) + giaban1).ToString();
                        decimal.TryParse(txtGiaban.Text.ToString(), out decimal gb);
                        rec_ctct.GIABAN = gb;
                        rec_ctct.SOLUONG = int.Parse(txtSLHH.Text.ToString());
                        decimal.TryParse(txtSLHH.Text.ToString(), out decimal sl);
                        rec_ctct.THANHTIEN = (int)gb * (int)sl;
                        txtThanhtien.ReadOnly = true;
                        context.SaveChanges();
                        RefreshforNew();
                    }

            }
            #endregion

        }



        private async void txtMaCT_MouseLeave(object sender, EventArgs e)
        {
            var dk =await context.CHUNG_TU_BAN.Where(d => d.MASOCT == txtMaCT.Text).ToListAsync();
                string searchText = txtMaCT.Text.Trim();
            if (dk.Any())
            {
                var lsCT = await(from x in context.CHUNG_TU_BAN_CT
                            join h in context.HANG_HOA on x.ID_HANGHOA equals h.ID_HANGHOA
                            join c in context.CHUNG_TU_BAN on x.ID_CTBAN equals c.ID_CTBAN
                            join k in context.KHACH_HANG on c.ID_KHACHHANG equals k.ID_KHACH_HANG
                            where x.ID_CTBAN.ToString().Contains(searchText)
                            select new
                            {
                                h.ID_HANGHOA,
                                k.ID_KHACH_HANG,
                                h.TENHANGHOA,
                                x.SOLUONG,
                                x.GIABAN,
                                x.THANHTIEN
                            }
                            ).ToListAsync();
                dgViewCTCT.DataSource = lsCT;
                check = true;
                txtTongso.Text = lsCT.Count().ToString();

                var lot = await (from  ctu in context.CHUNG_TU_BAN 
                                 join khang in context.KHACH_HANG on ctu.ID_KHACHHANG equals khang.ID_KHACH_HANG
                                 where ctu.ID_CTBAN.ToString().Contains(searchText)
                                 select new
                                 {
                                     ID_KHACH_HANG = khang.ID_KHACH_HANG,
                                     TEN_KH = khang.TEN_KH,
                                     DIACHI = khang.DIACHI,
                                     SODIENTHOAI = khang.SODIENTHOAI,
                                     NGAYDATHANG = ctu.NGAYDATHANG
                                 }).ToListAsync();
                txtIDKH.Text = lot.First().ID_KHACH_HANG.ToString();
                txtTenKH.Text = lot.First().TEN_KH.ToString();
                txtDiachi.Text = lot.First().DIACHI.ToString();
                txtSDT.Text = lot.First().SODIENTHOAI.ToString();
                txtNgaydathang.Text = lot.First().NGAYDATHANG.ToString();
            }
            
            else
            {
                MessageBox.Show("Mã chứng từ không tồn tại", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private async void txtIDHH_MouseLeave(object sender, EventArgs e)
        {

            string eng = txtIDHH.Text.ToString();
            int.TryParse(eng,out int englot);
            var hang = await context.HANG_HOA.Where(h => h.ID_HANGHOA == englot).ToListAsync();
            if(hang.Any())
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
            var giaban = engeng.First().GIATRI.ToString();
            decimal.TryParse(giaban.ToString(), out decimal giaban1);
            txtGiaban.Text = ((giaban1 * 30 / 100) + giaban1).ToString() + " VND";

            }
            else
                MessageBox.Show("Hàng hóa không tồn tại","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
