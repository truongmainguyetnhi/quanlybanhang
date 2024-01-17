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
    public partial class CHUNGTUMUA : Form
    {
        string tentaikhoan = "", matkhau = "", loaiTK = "";
        public CHUNGTUMUA(string tentaikhoan, string matkhau, string loaiTK)
        {
            InitializeComponent();
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            this.loaiTK = loaiTK;
        }
        SABEntities3 context;
        CHUNG_TU_MUA rec_ct;
        List<CHUNG_TU_MUA> list_ct;
        CHUNG_TU_MUA_CT rec_hh;
        List<CHUNG_TU_MUA_CT> list_hh;

        int ID_Selected_ct = 0;
        int idx_DGView_ct;
        int ID_Selected_hh = 0;
        int idx_DGView_hh;
        public void Load_DgviewHH()
        {
            list_ct = context.CHUNG_TU_MUA.ToList();
            if (list_ct.Count != 0)
            {
                var query = from chungtu in context.CHUNG_TU_MUA
                            join khachhang in context.KHACH_HANG on chungtu.ID_KHACHHANG equals khachhang.ID_KHACH_HANG into list_ctkh
                            from ctkh in list_ctkh.DefaultIfEmpty()
                            select new
                            {
                                ID_KHACHHANG = ctkh.ID_KHACH_HANG,
                                TEN_KH = ctkh.TEN_KH,
                                MASOCT = chungtu.MASOCT,
                                NGAYPHATSINH = chungtu.NGAYPHATSINH,
                                THUE = chungtu.THUE,
                                TIENTHUE = chungtu.TIENTHUE,
                                TIENHANG = chungtu.TONGTIENHANG,
                                TONGCONG = chungtu.TONGCONG,
                            };
                dgViewCTCT.DataSource = query.ToList();
                formatDGView();
                txtSLCT.Text = list_ct.Count().ToString();
                txtSLCT.ReadOnly = true;
            }
            else
            {
                dgViewCTCT.DataSource = null;
                txtSLCT.Text = list_ct.Count().ToString();
                txtSLCT.ReadOnly = true;
            }
        }
        public void formatDGView()
        {
            dgViewCTCT.Columns[0].HeaderText = "ID khách hàng";
            dgViewCTCT.Columns[0].Width = 150;
            dgViewCTCT.Columns[1].HeaderText = "Tên khách hàng";
            dgViewCTCT.Columns[1].Width = 150;
            dgViewCTCT.Columns[2].HeaderText = "Mã số chứng từ";
            dgViewCTCT.Columns[2].Width = 150;
            dgViewCTCT.Columns[3].HeaderText = "Ngày đặt hàng";
            dgViewCTCT.Columns[3].Width = 150;
            dgViewCTCT.Columns[4].HeaderText = "Thuế";
            dgViewCTCT.Columns[4].Width = 150;
            dgViewCTCT.Columns[5].HeaderText = "Tiền thuế";
            dgViewCTCT.Columns[5].Width = 150;
            dgViewCTCT.Columns[6].HeaderText = "Tiền hàng";
            dgViewCTCT.Columns[6].Width = 150;
            dgViewCTCT.Columns[7].HeaderText = "Tổng cộng";
            dgViewCTCT.Columns[7].Width = 150;
            dgViewCTCT.AllowUserToAddRows = false;
            dgViewCTCT.AllowUserToDeleteRows = false;
            dgViewCTCT.ReadOnly = true;
            dgViewCTCT.ForeColor = Color.Black;
            dgViewCTCT.DefaultCellStyle.Font = new Font("Time new roman", 12);
        }

        private void CHUNGTUMUA_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_ct = new CHUNG_TU_MUA();
            list_ct = new List<CHUNG_TU_MUA>();
            rec_hh = new CHUNG_TU_MUA_CT();
            list_hh = new List<CHUNG_TU_MUA_CT>();
            Load_DgviewHH();
            txtTienThue.ReadOnly = true;
            txtTienHang.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtMaCT.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtGiamua.ReadOnly = true;
            txtTenHH.ReadOnly = true;
            txtTongso.ReadOnly = true;
            txtTongTien.ReadOnly = true;
        }

 
        public bool checkEmpty1()
        {
            if (txtIDHH.Text.Length == 0 || txtSLHH.Text.Length == 0)
            {
                return true;
            }
            else { return false; }
        }

        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewHH();
            rec_ct = new CHUNG_TU_MUA();
            rec_hh = new CHUNG_TU_MUA_CT();
            ID_Selected_ct = 0;
        }

        private async void dgViewCTCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx_DGView_ct = dgViewCTCT.CurrentRow.Index;
            rec_ct = list_ct[idx_DGView_ct];
            ID_Selected_ct = rec_ct.ID_CTMUA;
            txtThue.Text = rec_ct.THUE.ToString();
            txtTienThue.Text = rec_ct.TIENTHUE.ToString() + " VND";
            txtTienHang.Text = rec_ct.TONGTIENHANG.ToString() + " VND";
            txtTongTien.Text = rec_ct.TONGCONG.ToString() + " VND";
            var kh = await context.KHACH_HANG.Where(p => p.ID_KHACH_HANG == rec_ct.ID_KHACHHANG).ToListAsync();
            txtTenKH.Text = kh.FirstOrDefault().TEN_KH.ToString();
            txtTenKH.ReadOnly = true;
            txtIDKH.Text = kh.FirstOrDefault().ID_KHACH_HANG.ToString();
            txtIDKH.ReadOnly = true;
            txtMaCT.ReadOnly = true;
            txtMaCT.Text = rec_ct.MASOCT.ToString();
            dateTimePicker1.Value = rec_ct.NGAYPHATSINH.Value;
            dateTimePicker1.Enabled = false;
            btnChitiet_Click_1(sender, e);
        }

        private async void btnThemCT_Click(object sender, EventArgs e)
        {
            if (ID_Selected_ct == 0)
            {
                if (!checkEmpty())
                {
                    int.TryParse(txtIDKH.Text.ToString(), out int id);
                    var he = (from kh in context.KHACH_HANG
                              where kh.ID_KHACH_HANG == id
                              select new
                              {
                                  kh.ID_KHACH_HANG,
                                  kh.TEN_KH,
                                  kh.SOB
                              }).ToList();
                    rec_ct.ID_KHACHHANG = he.First().ID_KHACH_HANG;
                    rec_ct.NGAYPHATSINH = dateTimePicker1.Value;
                    int.TryParse(txtThue.Text.ToString(), out int thue);
                    if (txtThue.Text.Length == 0 || txtThue.Text.ToString() == "0")
                    {
                        if (MessageBox.Show("Thuế bằng không", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            rec_ct.THUE = thue;
                        }
                    }
                    context.SaveChanges();
                    int maxIdct = await context.CHUNG_TU_MUA.MaxAsync(h => h.ID_CTMUA);
                    rec_ct.MASOCT = (maxIdct + 1).ToString();
                    context.CHUNG_TU_MUA.Add(rec_ct);
                    context.SaveChanges();
                    RefreshforNew();
                    //
                }
                else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                if (MessageBox.Show("Chứng từ bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var query = (from chungtu in context.CHUNG_TU_MUA
                                 join chitiet in context.CHUNG_TU_MUA_CT on chungtu.ID_CTMUA equals chitiet.ID_CTMUA
                                 join hanghoa in context.HANG_HOA on chitiet.ID_HANGHOA equals hanghoa.ID_HANGHOA
                                 join dongia in context.DON_GIA_BAN on hanghoa.ID_HANGHOA equals dongia.ID_HANGHOA
                                 where chungtu.MASOCT == rec_ct.MASOCT
                                 select
                                     chitiet.THANHTIEN).ToArray();
                    txtTienHang.Text = query.Sum().ToString();
                    decimal.TryParse(txtTienHang.Text.ToString(), out decimal th);
                    rec_ct.TONGTIENHANG = th;
                    int.TryParse(txtThue.Text.ToString(), out int thue);
                    if (txtThue.Text.Length == 0 || txtThue.Text.ToString() == "0")
                    {
                        if (MessageBox.Show("Thuế bằng không", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            decimal tthue = (th * thue / 100);
                            rec_ct.TIENTHUE = tthue;
                            decimal tongtien = (tthue + th);
                            rec_ct.TONGCONG = tongtien;
                            rec_ct.THUE = thue;
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
                        context.SaveChanges();
                        RefreshforNew();
                    }
                }
            }
            Load_DgviewHH();
        }


        public void EmptyControl1()
        {
            txtTenHH.Clear();
            txtIDHH.Clear();
            txtGiamua.Clear();
            txtSLHH.Clear();
            txtThanhtien.Clear();
            txtTongso.Clear();
            txtIDHH.ReadOnly = false;
            txtIDKH.Select();
        }





        private async void txtIDKH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int num = 0;
            if (int.TryParse(txtIDKH.Text, out num))
            {
                if (txtIDKH.Text.Length > 0)
                {
                    int.TryParse(txtIDKH.Text.ToString(), out int id);
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
                        if (loai == true)
                        {
                            MessageBox.Show("Khách hàng thuộc loại khách hàng bán", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIDKH.Clear();
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
                        txtIDKH.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập ID khách hàng", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIDKH.Clear();
            }
        }


        private async void txtIDHH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int num = 0;
            if (int.TryParse(txtIDHH.Text, out num))
            {
                string eng = txtIDHH.Text.ToString();
                int.TryParse(eng, out int englot);
                var hang = await context.HANG_HOA.Where(h => h.ID_HANGHOA == englot).ToListAsync();
                if (hang.Any())
                {
                    var engeng = await (from ef in context.HANG_HOA
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
            else
            {
                MessageBox.Show("Vui lòng nhập ID", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIDHH.Clear();
            }
        }

        private async void dgViewHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int v = int.Parse(txtMaCT.Text.ToString());
            list_hh = context.CHUNG_TU_MUA_CT.Where(h => h.ID_CTMUA == v).ToList();
            idx_DGView_hh = dgViewHH.CurrentRow.Index;
            rec_hh = list_hh[idx_DGView_hh];
            ID_Selected_hh = (int)rec_hh.ID_CTMUA;
            var kh = await context.HANG_HOA.Where(p => p.ID_HANGHOA == rec_hh.ID_HANGHOA).ToListAsync();
            txtTenHH.Text = kh.FirstOrDefault().TENHANGHOA.ToString();
            txtTenHH.ReadOnly = true;
            txtIDHH.Text = kh.FirstOrDefault().ID_HANGHOA.ToString();
            txtIDHH.ReadOnly = true;
            txtGiamua.Text = rec_hh.GIAMUA.ToString();
            txtSLHH.Text = rec_hh.SOLUONG.ToString();
            txtThanhtien.Text = rec_hh.THANHTIEN.ToString() + " VND";
            txtThanhtien.ReadOnly = true;
            txtGiamua.ReadOnly = true;
            
        }

        private void txtSLHH_TextChanged(object sender, EventArgs e)
        {

            int num = 0;
            if (int.TryParse(txtSLHH.Text, out num))
            {
                rec_hh.SOLUONG = int.Parse(txtSLHH.Text.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSLHH.Clear();
            }
        }

        private void txtSLHH_TextChanged_1(object sender, EventArgs e)
        {
            int num = 0;
            if (int.TryParse(txtSLHH.Text, out num))
            {
                rec_hh.SOLUONG = int.Parse(txtSLHH.Text.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số", "Cảnh báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSLHH.Clear();
            }
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            txtIDKH.ReadOnly = true;
            if (ID_Selected_hh == 0)
            {
                if (!checkEmpty1())
                {
                    if (txtMaCT.Text.Length == 0)
                    {
                        MessageBox.Show("Chưa nhập mã chứng từ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int.TryParse(txtIDHH.Text.ToString(), out int idhh);
                        rec_hh.ID_HANGHOA = idhh;
                        var query = (
                                     from hh in context.HANG_HOA
                                     join dg in context.DON_GIA_BAN on hh.ID_HANGHOA equals dg.ID_HANGHOA into list_dg
                                     from gia in list_dg.DefaultIfEmpty()
                                     where hh.ID_HANGHOA == idhh
                                     select gia.GIATRI).ToList();
                        var giamua = query.First().ToString();
                        decimal.TryParse(giamua.ToString(), out decimal giamua1);
                        txtGiamua.Text = (giamua1).ToString();
                        decimal.TryParse(txtGiamua.Text.ToString(), out decimal gm);
                        rec_hh.SOLUONG = int.Parse(txtSLHH.Text.ToString());
                        rec_hh.GIAMUA = gm;
                        decimal.TryParse(txtSLHH.Text.ToString(), out decimal sl);
                        rec_hh.THANHTIEN = (int)gm * (int)sl;
                        txtThanhtien.ReadOnly = true;
                        int.TryParse(txtMaCT.Text.ToString(), out int idct);
                        rec_hh.ID_CTMUA = idct;
                        context.CHUNG_TU_MUA_CT.Add(rec_hh);
                        context.SaveChanges();
                        var query1 = (from chungtu in context.CHUNG_TU_MUA_CT
                                      where chungtu.ID_CTMUA == idct
                                      join hanghoa in context.HANG_HOA on chungtu.ID_HANGHOA equals hanghoa.ID_HANGHOA
                                      join dongia in context.DON_GIA_BAN on hanghoa.ID_HANGHOA equals dongia.ID_HANGHOA
                                      select
                                          chungtu.THANHTIEN).ToArray();
                        txtTienHang.Text = query1.Sum().ToString();
                        decimal.TryParse(txtTienHang.Text.ToString(), out decimal th);
                        rec_ct.TONGTIENHANG = th;
                        int.TryParse(txtThue.Text.ToString(), out int thue);
                        rec_ct.THUE = thue;
                        decimal tthue = (th * thue / 100);
                        rec_ct.TIENTHUE = tthue;
                        decimal tongtien = (tthue + th);
                        rec_ct.TONGCONG = tongtien;
                        context.SaveChanges();
                        RefreshforNew();
                        int.TryParse(txtMaCT.Text.ToString(), out int hehe);
                        var nhi = (from n in context.CHUNG_TU_MUA_CT
                                   join x in context.HANG_HOA on n.ID_HANGHOA equals x.ID_HANGHOA
                                   where n.ID_CTMUA == hehe
                                   select new
                                   {
                                       x.TENHANGHOA,
                                       n.SOLUONG,
                                       n.GIAMUA,
                                       n.THANHTIEN
                                   }).ToList();
                        dgViewHH.DataSource = nhi;
                        txtTongso.Text = nhi.Count().ToString();
                        dgViewHH.Columns[0].HeaderText = "Tên hàng hóa";
                        dgViewHH.Columns[0].Width = 150;
                        dgViewHH.Columns[1].HeaderText = "Số lượng";
                        dgViewHH.Columns[1].Width = 150;
                        dgViewHH.Columns[2].HeaderText = "Giá mua";
                        dgViewHH.Columns[2].Width = 150;
                        dgViewHH.Columns[3].HeaderText = "Thành tiền";
                        dgViewHH.Columns[3].Width = 150;
                        dgViewHH.AllowUserToAddRows = false;
                        dgViewHH.AllowUserToDeleteRows = false;
                        dgViewHH.ReadOnly = true;
                        dgViewHH.ForeColor = Color.Black;
                        dgViewHH.DefaultCellStyle.Font = new Font("Time new roman", 12);
                    }

                }
                else
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Thuộc tính hàng hóa của chứng từ bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int.TryParse(txtIDHH.Text.ToString(), out int idhh);
                    var query = await(from hh in context.HANG_HOA
                                      join dg in context.DON_GIA_BAN on hh.ID_HANGHOA equals dg.ID_HANGHOA into list_dg
                                      from gia in list_dg.DefaultIfEmpty()
                                      where hh.ID_HANGHOA == idhh
                                      select gia.GIATRI).ToListAsync();
                    var giamua = query.First().ToString();
                    decimal.TryParse(giamua.ToString(), out decimal giamua1);
                    txtGiamua.Text = (giamua1).ToString();
                    decimal.TryParse(txtGiamua.Text.ToString(), out decimal gm);
                    rec_hh.GIAMUA = gm;
                    rec_hh.SOLUONG = int.Parse(txtSLHH.Text.ToString());
                    decimal.TryParse(txtSLHH.Text.ToString(), out decimal sl);
                    rec_hh.THANHTIEN = (int)gm * (int)sl;
                    txtThanhtien.ReadOnly = true;
                    context.SaveChanges();
                    //
                    int idct = (int)rec_hh.ID_CTMUA;

                    var query1 = (from chungtu in context.CHUNG_TU_MUA_CT
                                  where chungtu.ID_CTMUA == idct
                                  join hanghoa in context.HANG_HOA on chungtu.ID_HANGHOA equals hanghoa.ID_HANGHOA
                                  join dongia in context.DON_GIA_BAN on hanghoa.ID_HANGHOA equals dongia.ID_HANGHOA
                                  select
                                      chungtu.THANHTIEN).ToArray();
                    txtTienHang.Text = query1.Sum().ToString();
                    decimal.TryParse(txtTienHang.Text.ToString(), out decimal th);
                    rec_ct.TONGTIENHANG = th;
                    int.TryParse(txtThue.Text.ToString(), out int thue);
                    rec_ct.THUE = thue;
                    decimal tthue = (th * thue / 100);
                    rec_ct.TIENTHUE = tthue;
                    decimal tongtien = (tthue + th);
                    rec_ct.TONGCONG = tongtien;
                    context.SaveChanges();
                    txtIDHH.Clear();
                    txtTenHH.Clear();
                    txtGiamua.Clear();
                    txtSLHH.Clear();
                    txtThanhtien.Clear();
                    RefreshforNew();
                    int.TryParse(txtMaCT.Text.ToString(), out int hehe);
                    var nhi = (from n in context.CHUNG_TU_MUA_CT
                               join x in context.HANG_HOA on n.ID_HANGHOA equals x.ID_HANGHOA
                               where n.ID_CTMUA == hehe
                               select new
                               {
                                   x.TENHANGHOA,
                                   n.SOLUONG,
                                   n.GIAMUA,
                                   n.THANHTIEN
                               }).ToList();
                    dgViewHH.DataSource = nhi;
                    txtTongso.Text = nhi.Count().ToString();
                    dgViewHH.Columns[0].HeaderText = "Tên hàng hóa";
                    dgViewHH.Columns[0].Width = 150;
                    dgViewHH.Columns[1].HeaderText = "Số lượng";
                    dgViewHH.Columns[1].Width = 150;
                    dgViewHH.Columns[2].HeaderText = "Giá mua";
                    dgViewHH.Columns[2].Width = 150;
                    dgViewHH.Columns[3].HeaderText = "Thành tiền";
                    dgViewHH.Columns[3].Width = 150;
                    dgViewHH.AllowUserToAddRows = false;
                    dgViewHH.AllowUserToDeleteRows = false;
                    dgViewHH.ReadOnly = true;
                    dgViewHH.ForeColor = Color.Black;
                    dgViewHH.DefaultCellStyle.Font = new Font("Time new roman", 12);
                }

            }
            Load_DgviewHH();
        }

        private void btnaddnewHH_Click(object sender, EventArgs e)
        {
                EmptyControl1();
                rec_ct = new CHUNG_TU_MUA();
                rec_hh = new CHUNG_TU_MUA_CT();
                ID_Selected_hh = 0;
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            EmptyControl();
            txtMaCT.Clear();
            rec_ct = new CHUNG_TU_MUA();
            ID_Selected_ct = 0;
            Load_DgviewHH();

        }

        
        // Nhập maCT để xem hàng trong đó (nma ko cho nhập maCT :)))

        private void btnChitiet_Click_1(object sender, EventArgs e)
        {
            int.TryParse(txtMaCT.Text.ToString(), out int hehe);
            var nhi = (from n in context.CHUNG_TU_MUA_CT
                       join x in context.HANG_HOA on n.ID_HANGHOA equals x.ID_HANGHOA
                       where n.ID_CTMUA == hehe
                       select new
                       {
                           x.TENHANGHOA,
                           n.SOLUONG,
                           n.GIAMUA,
                           n.THANHTIEN
                       }).ToList();
            dgViewHH.DataSource = nhi;
            txtTongso.Text = nhi.Count().ToString();
            dgViewHH.Columns[0].HeaderText = "Tên hàng hóa";
            dgViewHH.Columns[0].Width = 150;
            dgViewHH.Columns[1].HeaderText = "Số lượng";
            dgViewHH.Columns[1].Width = 150;
            dgViewHH.Columns[2].HeaderText = "Giá bán";
            dgViewHH.Columns[2].Width = 150;
            dgViewHH.Columns[3].HeaderText = "Thành tiền";
            dgViewHH.Columns[3].Width = 150;
            dgViewHH.AllowUserToAddRows = false;
            dgViewHH.AllowUserToDeleteRows = false;
            dgViewHH.ReadOnly = true;
            dgViewHH.ForeColor = Color.Black;
            dgViewHH.DefaultCellStyle.Font = new Font("Time new roman", 12);
        }

 

        public void EmptyControl()
        {
            txtTenKH.Clear();
            txtIDKH.Clear();
            txtThue.Clear();
            txtTienThue.Clear();
            txtTienHang.Clear();
            txtTongTien.Clear();
            txtIDKH.ReadOnly = false;
            txtIDKH.Select();
        }
        public bool checkEmpty()
        {
            if (txtTenKH.Text.Length == 0 || txtIDKH.Text.Length == 0 || txtThue.Text.Length == 0)
            {
                return true;
            }
            else { return false; }
        }

    }
}
