using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace webbanhang
{
    public partial class frmChungtuBan : Form
    {
        string tentaikhoan = "", matkhau = "", loaiTK = "";
        public frmChungtuBan(string tentaikhoan, string matkhau, string loaiTK)
        {
            InitializeComponent();
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            this.loaiTK = loaiTK;
        }
        SABEntities3  context;
        CHUNG_TU_BAN rec_ct;
        List<CHUNG_TU_BAN> list_ct;
        KHACH_HANG rec_kh;
        List<KHACH_HANG> list_kh;
        KY_THONG_KE rec_ktk;
        List<KY_THONG_KE> list_ktk;
        int ID_Selected_ct = 0;
        int idx_DGView_ct;

        private void frmChungtuBan_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_ct = new CHUNG_TU_BAN();
            list_ct = new List<CHUNG_TU_BAN>();
            rec_kh = new KHACH_HANG();
            list_kh = new List<KHACH_HANG>();
            rec_ktk = new KY_THONG_KE();
            list_ktk = new List<KY_THONG_KE>();
            Load_DgviewHH();
            btnaddnew.Enabled = false;
            btnSave.Enabled = false;
            txtTienThue.ReadOnly = true;
            txtTienHang.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtSoCT.ReadOnly = true;
            if (loaiTK == "nhanvien")
            {
                MessageBox.Show("Bạn không có quyền sửa đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnaddnew.Enabled = false;
                btnSave.Enabled = false;
                txtGhichu.ReadOnly = true;
                txtIdKH.ReadOnly = true;
                txtThue.ReadOnly = true;
            }
        }

        public void Load_DgviewHH()
        {
            list_ct = context.CHUNG_TU_BAN.ToList();
            if (list_ct.Count != 0)
            {
                var query = from chungtu in context.CHUNG_TU_BAN
                            join khachhang in context.KHACH_HANG on chungtu.ID_KHACHHANG equals khachhang.ID_KHACH_HANG into list_ctkh
                            from ctkh in list_ctkh.DefaultIfEmpty()
                            select new
                            {
                                ID_KHACHHANG = ctkh.ID_KHACH_HANG,
                                TEN_KH = ctkh.TEN_KH,
                                MASOCT = chungtu.MASOCT,
                                NGAYDATHANG = chungtu.NGAYDATHANG,
                                THUE = chungtu.THUE,
                                TIENTHUE = chungtu.TIENTHUE,
                                TIENHANG = chungtu.TONGTIENHANG,
                                TONGCONG =chungtu.TONGCONG,
                                GHICHU = chungtu.GHICHU,
                            };
                dgViewCTB.DataSource = query.ToList();
                formatDGView();
                txtSLCT.Text = list_ct.Count().ToString();
                txtTrangthai.ReadOnly = true;
                txtSLCT.ReadOnly = true;
                txtSoCT.ReadOnly = true;
            }
            else
            {
                dgViewCTB.DataSource = null;
                txtSLCT.Text = list_ct.Count().ToString();
                txtSLCT.ReadOnly = true;
                txtTrangthai.ReadOnly = true;
            }
        }
        public void formatDGView()
        {
            dgViewCTB.Columns[0].HeaderText = "ID khách hàng";
            dgViewCTB.Columns[0].Width = 200;
            dgViewCTB.Columns[1].HeaderText = "Tên khách hàng";
            dgViewCTB.Columns[1].Width = 200;
            dgViewCTB.Columns[2].HeaderText = "Mã số chứng từ";
            dgViewCTB.Columns[2].Width = 200;
            dgViewCTB.Columns[3].HeaderText = "Ngày đặt hàng";
            dgViewCTB.Columns[3].Width = 200;
            dgViewCTB.Columns[4].HeaderText = "Thuế";
            dgViewCTB.Columns[4].Width = 200;
            dgViewCTB.Columns[5].HeaderText = "Tiền thuế";
            dgViewCTB.Columns[5].Width = 200;
            dgViewCTB.Columns[6].HeaderText = "Tiền hàng";
            dgViewCTB.Columns[6].Width = 200;
            dgViewCTB.Columns[7].HeaderText = "Tổng cộng";
            dgViewCTB.Columns[7].Width = 200; 
            dgViewCTB.Columns[8].HeaderText = "Ghi chú";
            dgViewCTB.Columns[8].Width = 200;
            dgViewCTB.AllowUserToAddRows = false;
            dgViewCTB.AllowUserToDeleteRows = false;
            dgViewCTB.ReadOnly = true;
            dgViewCTB.BackgroundColor = Color.LightGray;
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            EmptyControl();
            rec_ct = new CHUNG_TU_BAN();
            rec_kh = new KHACH_HANG();
            rec_ktk = new KY_THONG_KE();
            ID_Selected_ct = 0;
        }
        public void EmptyControl()
        {
            txtTenKH.Clear();
            txtIdKH.Clear();
            txtSoCT.Clear();
            txtThue.Clear();
            txtTienThue.Clear();
            txtTienHang.Clear();
            txtTongTien.Clear();
            txtTrangthai.Clear();
            txtGhichu.Clear();
            txtIdKH.ReadOnly = false;
            txtSoCT.ReadOnly = false;
            txtIdKH.Select();
        }
        public bool checkEmpty()
        {
            if (txtTenKH.Text.Length == 0 && txtIdKH.Text.Length == 0 && txtSoCT.Text.Length == 0 && txtThue.Text.Length == 0 &&
                txtTienThue.Text.Length == 0 && txtTienHang.Text.Length == 0 && txtTongTien.Text.Length == 0 && txtTrangthai.Text.Length == 0 &&
                txtGhichu.Text.Length == 0 && txtSoCT.Text.Length == 0)
            {
                return true;
            }
            else { return false; }
        }

        private async void dgViewCTB_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            idx_DGView_ct = dgViewCTB.CurrentRow.Index;
            rec_ct = list_ct[idx_DGView_ct];
            ID_Selected_ct = rec_ct.ID_CTBAN;
            txtSoCT.Text = rec_ct.MASOCT;
            txtSoCT.ReadOnly = true;
            txtThue.Text = rec_ct.THUE.ToString() + " %";
            txtTienThue.Text = rec_ct.TIENTHUE.ToString() + " VND";
            txtTienHang.Text = rec_ct.TONGTIENHANG.ToString() + " VND";
            txtTongTien.Text = rec_ct.TONGCONG.ToString() + " VND";
            txtGhichu.Text = rec_ct.GHICHU.ToString();
            if (rec_ct.TRANGTHAI == true)
                txtTrangthai.Text = "Đã bán";
            else txtTrangthai.Text = "Chưa đến hạn";
            var kh = await context.KHACH_HANG.Where(p => p.ID_KHACH_HANG == rec_ct.ID_KHACHHANG).ToListAsync();
            txtTenKH.Text = kh.FirstOrDefault().TEN_KH.ToString();
            txtTenKH.ReadOnly = true;
            txtIdKH.Text = kh.FirstOrDefault().ID_KHACH_HANG.ToString();
            txtIdKH.ReadOnly = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ID_Selected_ct == 0)
            {
                if (!checkEmpty())
                {
                    int.TryParse(txtIdKH.Text.ToString(), out int id);
                    var he = (from kh in context.KHACH_HANG
                              where kh.ID_KHACH_HANG == id
                              select new
                              {
                                  kh.ID_KHACH_HANG,
                                  kh.TEN_KH,
                                  kh.SOB
                              }).ToList();
                    rec_ct.ID_KHACHHANG = he.First().ID_KHACH_HANG;
                    rec_ct.NGAYDATHANG = dateTimePicker1.Value;
                    rec_ct.TRANGTHAI = rec_ct.NGAYDATHANG.Value.Ticks < DateTime.Now.Ticks;
                    var query = (from chungtu in context.CHUNG_TU_BAN
                                 join chitiet in context.CHUNG_TU_BAN_CT on chungtu.ID_CTBAN equals chitiet.ID_CTBAN
                                 join hanghoa in context.HANG_HOA on chitiet.ID_HANGHOA equals hanghoa.ID_HANGHOA
                                 join dongia in context.DON_GIA_BAN on hanghoa.ID_HANGHOA equals dongia.ID_HANGHOA
                                 where chungtu.MASOCT == rec_ct.MASOCT
                                 select
                                     chitiet.THANHTIEN).ToArray();
                    txtTienHang.Text = query.Sum().ToString();
                    decimal.TryParse(txtTienHang.Text.ToString(), out decimal th);
                    rec_ct.TONGTIENHANG = th;
                    int.TryParse(txtThue.Text.ToString(), out int thue);
                    rec_ct.THUE = thue;
                    decimal tthue = (th * thue / 100);
                    rec_ct.TIENTHUE = tthue;
                    decimal tongtien = (tthue + th);
                    rec_ct.TONGCONG = tongtien;
                    rec_ct.GHICHU = txtGhichu.Text.ToString();
                    context.SaveChanges();
                    int maxIdct = await context.CHUNG_TU_BAN.MaxAsync(h => h.ID_CTBAN);
                    rec_ct.MASOCT = (maxIdct + 1).ToString();
                    txtSoCT.ReadOnly = true;
                    context.CHUNG_TU_BAN.Add(rec_ct);
                    context.SaveChanges();
                    RefreshforNew();
                }                           
            }
            else
            {
               
                
                    if (MessageBox.Show("Chứng từ bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        rec_ct.NGAYDATHANG = dateTimePicker1.Value;
                        rec_ct.TRANGTHAI = rec_ct.NGAYDATHANG.Value.Ticks < DateTime.Now.Ticks;
                        var query = (from chungtu in context.CHUNG_TU_BAN
                                     join chitiet in context.CHUNG_TU_BAN_CT on chungtu.ID_CTBAN equals chitiet.ID_CTBAN
                                     join hanghoa in context.HANG_HOA on chitiet.ID_HANGHOA equals hanghoa.ID_HANGHOA
                                     join dongia in context.DON_GIA_BAN on hanghoa.ID_HANGHOA equals dongia.ID_HANGHOA
                                     where chungtu.MASOCT == rec_ct.MASOCT
                                     select
                                         chitiet.THANHTIEN).ToArray();
                        txtTienHang.Text = query.Sum().ToString();
                        decimal.TryParse(txtTienHang.Text.ToString(), out decimal th);
                        rec_ct.TONGTIENHANG = th;
                        int.TryParse(txtThue.Text.ToString(), out int thue);
                        if (txtThue.Text.Length == 0 || txtThue.Text.ToString() == "0 %")
                        {
                            if (MessageBox.Show("Thuế bằng không", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                decimal tthue = (th * thue / 100);
                                rec_ct.TIENTHUE = tthue;
                                decimal tongtien = (tthue + th);
                                rec_ct.TONGCONG = tongtien;
                                rec_ct.THUE = thue;
                                rec_ct.GHICHU = txtGhichu.Text.ToString();
                                context.SaveChanges();
                                RefreshforNew();
                            }
                        }
                        else
                        {
                            decimal tthue = (th * thue / 100);
                            rec_ct.TIENTHUE = tthue;
                            decimal tongtien = (tthue + th);
                            rec_ct.TONGCONG = tongtien;
                            rec_ct.THUE = thue;
                            rec_ct.GHICHU = txtGhichu.Text.ToString();
                            context.SaveChanges();
                            RefreshforNew();
                        }
                    
                }
            }
        }
        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewHH();
            rec_ct = new CHUNG_TU_BAN();
            ID_Selected_ct = 0;
        }
        private async void txtIdKH_MouseLeaveAsync(object sender, EventArgs e)
        {
            if (txtIdKH.Text.Length > 0)
            {
                int.TryParse(txtIdKH.Text.ToString(), out int id);
                var he = await (from kh in context.KHACH_HANG
                                where kh.ID_KHACH_HANG == id
                                select new
                                {
                                    kh.ID_KHACH_HANG,
                                    kh.TEN_KH,
                                    kh.SOB
                                }).ToListAsync();
                if (he.Any())
                {
                    bool loai = (bool)he.First().SOB;
                    if (loai == false)
                    {
                        MessageBox.Show("Khách hàng thuộc loại khách hàng mua", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdKH.Clear();
                        txtTenKH.Clear();
                    }
                    else
                    {
                        txtTenKH.Text = he.FirstOrDefault().TEN_KH.ToString();
                        txtTenKH.ReadOnly = true;
                    }
                }
                else
                {
                    MessageBox.Show("Khách hàng không tồn tại", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIdKH.Clear();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập ID khách hàng", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
