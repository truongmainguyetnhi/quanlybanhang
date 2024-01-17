namespace webbanhang
{
    partial class frmDoanhthu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.txtSongayhd = new System.Windows.Forms.TextBox();
            this.txtDoanhthu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLoinhuan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgViewTK = new System.Windows.Forms.DataGridView();
            this.chartTK = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ngaybatdau = new System.Windows.Forms.DateTimePicker();
            this.ngayketthuc = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnthem = new ePOSOne.btnProduct.Button_WOC();
            this.btnThongke = new ePOSOne.btnProduct.Button_WOC();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTK)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên thống kê";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(375, 611);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 20, 3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số ngày hoạt động";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(27, 309);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 20, 3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày kết thúc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(27, 211);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 20, 3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày bắt đầu";
            // 
            // txtTK
            // 
            this.txtTK.BackColor = System.Drawing.SystemColors.Control;
            this.txtTK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTK.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTK.ForeColor = System.Drawing.Color.Black;
            this.txtTK.Location = new System.Drawing.Point(32, 156);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(300, 32);
            this.txtTK.TabIndex = 5;
            // 
            // txtSongayhd
            // 
            this.txtSongayhd.BackColor = System.Drawing.SystemColors.Control;
            this.txtSongayhd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSongayhd.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSongayhd.ForeColor = System.Drawing.Color.Black;
            this.txtSongayhd.Location = new System.Drawing.Point(380, 645);
            this.txtSongayhd.Name = "txtSongayhd";
            this.txtSongayhd.Size = new System.Drawing.Size(300, 32);
            this.txtSongayhd.TabIndex = 6;
            // 
            // txtDoanhthu
            // 
            this.txtDoanhthu.BackColor = System.Drawing.SystemColors.Control;
            this.txtDoanhthu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDoanhthu.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDoanhthu.ForeColor = System.Drawing.Color.Black;
            this.txtDoanhthu.Location = new System.Drawing.Point(380, 458);
            this.txtDoanhthu.Name = "txtDoanhthu";
            this.txtDoanhthu.Size = new System.Drawing.Size(300, 32);
            this.txtDoanhthu.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(375, 424);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 20, 3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tổng doanh thu";
            // 
            // txtLoinhuan
            // 
            this.txtLoinhuan.BackColor = System.Drawing.SystemColors.Control;
            this.txtLoinhuan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoinhuan.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtLoinhuan.ForeColor = System.Drawing.Color.Black;
            this.txtLoinhuan.Location = new System.Drawing.Point(380, 547);
            this.txtLoinhuan.Name = "txtLoinhuan";
            this.txtLoinhuan.Size = new System.Drawing.Size(300, 32);
            this.txtLoinhuan.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(375, 513);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 20, 3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Lợi nhuận";
            // 
            // dgViewTK
            // 
            this.dgViewTK.AllowUserToAddRows = false;
            this.dgViewTK.AllowUserToDeleteRows = false;
            this.dgViewTK.AllowUserToOrderColumns = true;
            this.dgViewTK.AllowUserToResizeColumns = false;
            this.dgViewTK.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewTK.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewTK.BackgroundColor = System.Drawing.Color.White;
            this.dgViewTK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewTK.CausesValidation = false;
            this.dgViewTK.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewTK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgViewTK.ColumnHeadersHeight = 32;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgViewTK.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgViewTK.GridColor = System.Drawing.Color.White;
            this.dgViewTK.Location = new System.Drawing.Point(380, 12);
            this.dgViewTK.Name = "dgViewTK";
            this.dgViewTK.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewTK.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgViewTK.RowHeadersVisible = false;
            this.dgViewTK.RowHeadersWidth = 100;
            this.dgViewTK.RowTemplate.Height = 24;
            this.dgViewTK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewTK.Size = new System.Drawing.Size(722, 328);
            this.dgViewTK.TabIndex = 13;
            this.dgViewTK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewTK_CellClick);
            // 
            // chartTK
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTK.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTK.Legends.Add(legend1);
            this.chartTK.Location = new System.Drawing.Point(697, 367);
            this.chartTK.Name = "chartTK";
            this.chartTK.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Thongke";
            series1.YValuesPerPoint = 6;
            this.chartTK.Series.Add(series1);
            this.chartTK.Size = new System.Drawing.Size(393, 310);
            this.chartTK.TabIndex = 14;
            title1.Name = "Title1";
            title1.Text = "Thống kê theo mã chứng từ";
            this.chartTK.Titles.Add(title1);
            // 
            // ngaybatdau
            // 
            this.ngaybatdau.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ngaybatdau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ngaybatdau.Location = new System.Drawing.Point(32, 247);
            this.ngaybatdau.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.ngaybatdau.Name = "ngaybatdau";
            this.ngaybatdau.Size = new System.Drawing.Size(300, 39);
            this.ngaybatdau.TabIndex = 17;
            // 
            // ngayketthuc
            // 
            this.ngayketthuc.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ngayketthuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ngayketthuc.Location = new System.Drawing.Point(32, 343);
            this.ngayketthuc.Name = "ngayketthuc";
            this.ngayketthuc.Size = new System.Drawing.Size(300, 39);
            this.ngayketthuc.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(380, 676);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 1);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Location = new System.Drawing.Point(380, 578);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 1);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel3.Location = new System.Drawing.Point(380, 489);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 1);
            this.panel3.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel4.Location = new System.Drawing.Point(32, 187);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 1);
            this.panel4.TabIndex = 20;
            // 
            // btnthem
            // 
            this.btnthem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnthem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnthem.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnthem.FlatAppearance.BorderSize = 0;
            this.btnthem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthem.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnthem.Location = new System.Drawing.Point(32, 423);
            this.btnthem.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.btnthem.Name = "btnthem";
            this.btnthem.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnthem.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnthem.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnthem.Size = new System.Drawing.Size(141, 51);
            this.btnthem.TabIndex = 47;
            this.btnthem.Text = "Thêm";
            this.btnthem.TextColor = System.Drawing.Color.Black;
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnThongke
            // 
            this.btnThongke.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThongke.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThongke.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnThongke.FlatAppearance.BorderSize = 0;
            this.btnThongke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongke.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongke.Location = new System.Drawing.Point(191, 423);
            this.btnThongke.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.btnThongke.Name = "btnThongke";
            this.btnThongke.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThongke.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThongke.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnThongke.Size = new System.Drawing.Size(141, 51);
            this.btnThongke.TabIndex = 48;
            this.btnThongke.Text = "Thống kê";
            this.btnThongke.TextColor = System.Drawing.Color.Black;
            this.btnThongke.UseVisualStyleBackColor = true;
            this.btnThongke.Click += new System.EventHandler(this.btnThongke_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(374, 367);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 30, 3, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 35);
            this.label7.TabIndex = 49;
            this.label7.Text = "DỮ LIỆU ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(26, 60);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 20, 3, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(243, 35);
            this.label8.TabIndex = 50;
            this.label8.Text = "TẠO THỐNG KÊ";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(11)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 707);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1114, 34);
            this.panel5.TabIndex = 51;
            // 
            // frmDoanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1114, 741);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.btnThongke);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ngayketthuc);
            this.Controls.Add(this.ngaybatdau);
            this.Controls.Add(this.chartTK);
            this.Controls.Add(this.dgViewTK);
            this.Controls.Add(this.txtLoinhuan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDoanhthu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSongayhd);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmDoanhthu";
            this.Text = "Doanh thu";
            this.Load += new System.EventHandler(this.frmDoanhthu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.TextBox txtSongayhd;
        private System.Windows.Forms.TextBox txtDoanhthu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLoinhuan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgViewTK;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTK;
        private System.Windows.Forms.DateTimePicker ngaybatdau;
        private System.Windows.Forms.DateTimePicker ngayketthuc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private ePOSOne.btnProduct.Button_WOC btnthem;
        private ePOSOne.btnProduct.Button_WOC btnThongke;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
    }
}