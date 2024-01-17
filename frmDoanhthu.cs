using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace webbanhang
{
    public partial class frmDoanhthu : Form
    {
        public frmDoanhthu()
        {
            InitializeComponent();
        }
        SABEntities3 context;
        KY_THONG_KE rec_tke;
        List<KY_THONG_KE> list_tke;
        int ID_Selected_tke = 0;
        int idx_DGView_tke;
        private void frmDoanhthu_Load(object sender, EventArgs e)
        {
            context = new SABEntities3();
            rec_tke = new KY_THONG_KE();
            list_tke = new List<KY_THONG_KE>();
            Load_DgviewTK();
            txtLoinhuan.ReadOnly = true;
            txtSongayhd.ReadOnly = true;
            txtDoanhthu.ReadOnly = true;

        }
        public void Load_DgviewTK()
        {
            list_tke = context.KY_THONG_KE.ToList();
            if (list_tke.Count() != 0)
            {
                dgViewTK.Columns.Clear();
                dgViewTK.DataSource = list_tke.Select(s => new { s.TENTHONGKE, s.NGAYBATDAU, s.NGAYKETHUC, s.SONGAYHOATDONG, s.TONGDOANHTHU }).ToList();
                formatDGView();
            }
            else
            {
                dgViewTK.DataSource = null;
            }
        }
        public void formatDGView()
        {
            dgViewTK.Columns[0].HeaderText = "Tên thống kê";
            dgViewTK.Columns[0].Width = 150;
            dgViewTK.Columns[1].HeaderText = "Ngày bắt đầu";
            dgViewTK.Columns[1].Width = 150;
            dgViewTK.Columns[2].HeaderText = "Ngày kết thúc";
            dgViewTK.Columns[2].Width = 150;
            dgViewTK.Columns[3].HeaderText = "Số ngày hoạt động";
            dgViewTK.Columns[3].Width = 150;
            dgViewTK.Columns[4].HeaderText = "Tổng doanh thu";
            dgViewTK.Columns[4].Width = 150;
            dgViewTK.AllowUserToAddRows = false;
            dgViewTK.AllowUserToDeleteRows = false;
            dgViewTK.ForeColor = Color.Black;
            dgViewTK.RowTemplate.Height = 40;
            dgViewTK.DefaultCellStyle.Font = new Font("Arial", 14);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            RefreshforNew();
            ngaybatdau.Enabled = true;
            ngayketthuc.Enabled = true;
            Load_DgviewTK();
            check = false;
        }
        public void EmptyControl()
        {
            txtTK.Clear();
            txtDoanhthu.Clear();
            ngaybatdau.Value = DateTime.Now;
            ngayketthuc.Value = DateTime.Now;
            txtDoanhthu.Clear();
            txtLoinhuan.Clear();
            txtSongayhd.Clear();
            txtTK.Select();
        }
        public bool checkEmpty()
        {
            if (txtTK.Text.Length == 0 || txtDoanhthu.Text.Length == 0 || txtSongayhd.Text.Length == 0)
            {
                return true;
            }
            else { return false; }
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            if (ID_Selected_tke == 0)
            {
                if (!checkEmpty())
                {
                    rec_tke.TENTHONGKE = txtTK.Text.ToString().Trim();
                    rec_tke.NGAYBATDAU = ngaybatdau.Value;
                    rec_tke.NGAYKETHUC = ngayketthuc.Value;
                    TimeSpan so = ngayketthuc.Value - ngaybatdau.Value;
                    int songay = so.Days;
                    rec_tke.SONGAYHOATDONG = songay;
                    var query = (from x in context.CHUNG_TU_BAN
                                 where ngaybatdau.Value <= x.NGAYDATHANG && ngayketthuc.Value >= x.NGAYDATHANG
                                 select new
                                 {
                                     x.TONGCONG,
                                     x.MASOCT
                                 }
                                     ).ToList();
                    decimal tong = (decimal)query.Sum(x => x.TONGCONG);
                    if (tong == 0)
                    {
                        if (MessageBox.Show("Không có hóa đơn nào trong thời gian này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            EmptyControl();
                        }
                    }
                    else
                    {
                        rec_tke.TONGDOANHTHU = tong;
                        context.KY_THONG_KE.Add(rec_tke);
                        context.SaveChanges();
                        RefreshforNew();
                    }
                }
                else
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Thông tin thống kê bị thay đổi! Bạn có muốn lưu?", "Thông báo thay đổi thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rec_tke.TENTHONGKE = txtTK.Text.ToString().Trim();
                    TimeSpan so = ngayketthuc.Value - ngaybatdau.Value;
                    int songay = so.Days;
                    rec_tke.SONGAYHOATDONG = songay;
                    var query = (from x in context.CHUNG_TU_BAN
                                 where ngaybatdau.Value <= x.NGAYDATHANG && ngayketthuc.Value >= x.NGAYDATHANG
                                 select x).ToList();
                    decimal tong = (decimal)query.Sum(x => x.TONGCONG);
                    rec_tke.TONGDOANHTHU = tong;
                    context.SaveChanges();
                    RefreshforNew();
                }
            }

        }
        public void RefreshforNew()
        {
            EmptyControl();
            Load_DgviewTK();
            rec_tke = new KY_THONG_KE();
            ID_Selected_tke = 0;
        }
        public bool check = false;
        private void dgViewTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (check == false)
            {
                idx_DGView_tke = dgViewTK.CurrentRow.Index;
                rec_tke = list_tke[idx_DGView_tke];
                ID_Selected_tke = rec_tke.ID_THONGKE;
                txtTK.Text = rec_tke.TENTHONGKE;
                txtDoanhthu.Text = rec_tke.TONGDOANHTHU.ToString() + " VND";
                txtSongayhd.Text = rec_tke.SONGAYHOATDONG.ToString();
                ngaybatdau.Value = rec_tke.NGAYBATDAU.Value;
                ngayketthuc.Value = rec_tke.NGAYKETHUC.Value;
                decimal doanhthu = (decimal)rec_tke.TONGDOANHTHU;
                decimal loinhuan = (doanhthu - (doanhthu * 70 / 100));
                txtLoinhuan.Text = loinhuan.ToString() + " VND";
                
                var query = (from x in context.CHUNG_TU_BAN
                             where ngaybatdau.Value <= x.NGAYDATHANG && ngayketthuc.Value >= x.NGAYDATHANG
                             select new
                             {
                                 x.MASOCT,
                                 x.TONGCONG

                             }).ToList();
                dgViewTK.DataSource = query;
                dgViewTK.Columns[0].HeaderText = "Mã thống kê";
                dgViewTK.Columns[0].Width = 200;
                dgViewTK.Columns[1].HeaderText = "Tổng cộng";
                dgViewTK.Columns[1].Width = 200;
                //Tính phần trăm doanh thu của mỗi chứng từ so với tổng doanh thu
                decimal tongDoanhThu = (decimal)rec_tke.TONGDOANHTHU;             
                    dgViewTK.Columns.Add("PhanTram", "Phần trăm");
                for (int i = 0; i < query.Count; i++)
                    {
                        var phanTram = (double)(query[i].TONGCONG / tongDoanhThu) * 100;
                        // Cập nhật giá trị của cột PhanTram trong từng dòng
                        dgViewTK.Rows[i].Cells["PhanTram"].Value = phanTram.ToString("0.00") + "%";
                    }

                    // Hiển thị biểu đồ

                    chartTK.Series["Thongke"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTK.Series["Thongke"].XValueMember = "MASOCT";
                    chartTK.Series["Thongke"].YValueMembers = "TONGCONG";


                chartTK.DataSource = query;

                    // Tùy chỉnh giao diện biểu đồ
                    chartTK.ChartAreas[0].AxisX.Title = "Mã chứng từ";
                    chartTK.ChartAreas[0].AxisY.Title = "Tổng doanh thu";
                    chartTK.Titles.Clear();
                    chartTK.Titles.Add("DOANH THU THEO CHỨNG TỪ");
                    ngaybatdau.Enabled = false;
                    ngayketthuc.Enabled = false;
                    check = true;
                
            }
            else if (check == true)
            {
                dgViewTK.ReadOnly = true;

            }

            
        }

 
    }


}

