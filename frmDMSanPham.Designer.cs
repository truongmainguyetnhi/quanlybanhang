namespace webbanhang
{
    partial class frmDMSanPham
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMSanPham));
            this.labTenSp = new System.Windows.Forms.Label();
            this.labDvt = new System.Windows.Forms.Label();
            this.labMota = new System.Windows.Forms.Label();
            this.labhinhanh = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtmota = new System.Windows.Forms.TextBox();
            this.txtdonvi = new System.Windows.Forms.TextBox();
            this.labPhanloai = new System.Windows.Forms.Label();
            this.txtdongia = new System.Windows.Forms.TextBox();
            this.txtKeySP = new System.Windows.Forms.TextBox();
            this.labtsp = new System.Windows.Forms.Label();
            this.txtSLSP = new System.Windows.Forms.TextBox();
            this.labSL = new System.Windows.Forms.Label();
            this.openFileImage = new System.Windows.Forms.OpenFileDialog();
            this.imgSP = new System.Windows.Forms.PictureBox();
            this.comboBoxPL = new System.Windows.Forms.ComboBox();
            this.labngay = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.dgViewgia = new System.Windows.Forms.DataGridView();
            this.entityCommand2 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btnthem = new ePOSOne.btnProduct.Button_WOC();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnxoa = new ePOSOne.btnProduct.Button_WOC();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnluu = new ePOSOne.btnProduct.Button_WOC();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgViewSP = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imgSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewgia)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewSP)).BeginInit();
            this.SuspendLayout();
            // 
            // labTenSp
            // 
            this.labTenSp.AutoSize = true;
            this.labTenSp.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labTenSp.Location = new System.Drawing.Point(21, 36);
            this.labTenSp.Margin = new System.Windows.Forms.Padding(11, 22, 4, 0);
            this.labTenSp.Name = "labTenSp";
            this.labTenSp.Size = new System.Drawing.Size(155, 26);
            this.labTenSp.TabIndex = 0;
            this.labTenSp.Text = "Tên sản phẩm";
            // 
            // labDvt
            // 
            this.labDvt.AutoSize = true;
            this.labDvt.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labDvt.Location = new System.Drawing.Point(23, 113);
            this.labDvt.Margin = new System.Windows.Forms.Padding(4, 11, 4, 0);
            this.labDvt.Name = "labDvt";
            this.labDvt.Size = new System.Drawing.Size(132, 26);
            this.labDvt.TabIndex = 1;
            this.labDvt.Text = "Đơn vị tính: ";
            // 
            // labMota
            // 
            this.labMota.AutoSize = true;
            this.labMota.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labMota.Location = new System.Drawing.Point(23, 75);
            this.labMota.Margin = new System.Windows.Forms.Padding(4, 11, 4, 0);
            this.labMota.Name = "labMota";
            this.labMota.Size = new System.Drawing.Size(81, 26);
            this.labMota.TabIndex = 2;
            this.labMota.Text = "Mô tả: ";
            // 
            // labhinhanh
            // 
            this.labhinhanh.AutoSize = true;
            this.labhinhanh.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labhinhanh.Location = new System.Drawing.Point(509, 19);
            this.labhinhanh.Margin = new System.Windows.Forms.Padding(4, 11, 4, 0);
            this.labhinhanh.Name = "labhinhanh";
            this.labhinhanh.Size = new System.Drawing.Size(102, 26);
            this.labhinhanh.TabIndex = 3;
            this.labhinhanh.Text = "Hình ảnh";
            // 
            // txtTenSP
            // 
            this.txtTenSP.BackColor = System.Drawing.SystemColors.Control;
            this.txtTenSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenSP.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenSP.ForeColor = System.Drawing.Color.Black;
            this.txtTenSP.Location = new System.Drawing.Point(184, 30);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(309, 32);
            this.txtTenSP.TabIndex = 5;
            // 
            // txtmota
            // 
            this.txtmota.BackColor = System.Drawing.SystemColors.Control;
            this.txtmota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmota.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtmota.ForeColor = System.Drawing.Color.Black;
            this.txtmota.Location = new System.Drawing.Point(184, 70);
            this.txtmota.Margin = new System.Windows.Forms.Padding(4);
            this.txtmota.Name = "txtmota";
            this.txtmota.Size = new System.Drawing.Size(309, 32);
            this.txtmota.TabIndex = 6;
            // 
            // txtdonvi
            // 
            this.txtdonvi.BackColor = System.Drawing.SystemColors.Control;
            this.txtdonvi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdonvi.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtdonvi.ForeColor = System.Drawing.Color.Black;
            this.txtdonvi.Location = new System.Drawing.Point(184, 107);
            this.txtdonvi.Margin = new System.Windows.Forms.Padding(4);
            this.txtdonvi.Name = "txtdonvi";
            this.txtdonvi.Size = new System.Drawing.Size(309, 32);
            this.txtdonvi.TabIndex = 7;
            // 
            // labPhanloai
            // 
            this.labPhanloai.AutoSize = true;
            this.labPhanloai.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labPhanloai.Location = new System.Drawing.Point(23, 153);
            this.labPhanloai.Margin = new System.Windows.Forms.Padding(4, 11, 4, 0);
            this.labPhanloai.Name = "labPhanloai";
            this.labPhanloai.Size = new System.Drawing.Size(117, 26);
            this.labPhanloai.TabIndex = 9;
            this.labPhanloai.Text = "Phân loại: ";
            // 
            // txtdongia
            // 
            this.txtdongia.BackColor = System.Drawing.SystemColors.Control;
            this.txtdongia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdongia.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtdongia.ForeColor = System.Drawing.Color.Black;
            this.txtdongia.Location = new System.Drawing.Point(184, 211);
            this.txtdongia.Margin = new System.Windows.Forms.Padding(4);
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.Size = new System.Drawing.Size(149, 32);
            this.txtdongia.TabIndex = 12;
            this.txtdongia.TextChanged += new System.EventHandler(this.txtdongia_TextChanged_1);
            // 
            // txtKeySP
            // 
            this.txtKeySP.BackColor = System.Drawing.SystemColors.Control;
            this.txtKeySP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKeySP.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtKeySP.ForeColor = System.Drawing.Color.Black;
            this.txtKeySP.Location = new System.Drawing.Point(184, 300);
            this.txtKeySP.Margin = new System.Windows.Forms.Padding(55, 0, 0, 0);
            this.txtKeySP.Name = "txtKeySP";
            this.txtKeySP.Size = new System.Drawing.Size(178, 32);
            this.txtKeySP.TabIndex = 18;
            this.txtKeySP.TextChanged += new System.EventHandler(this.txtKeySP_TextChanged);
            // 
            // labtsp
            // 
            this.labtsp.AutoSize = true;
            this.labtsp.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labtsp.Location = new System.Drawing.Point(23, 306);
            this.labtsp.Margin = new System.Windows.Forms.Padding(55, 0, 0, 0);
            this.labtsp.Name = "labtsp";
            this.labtsp.Size = new System.Drawing.Size(160, 26);
            this.labtsp.TabIndex = 17;
            this.labtsp.Text = "Tìm sản phẩm:";
            // 
            // txtSLSP
            // 
            this.txtSLSP.BackColor = System.Drawing.SystemColors.Control;
            this.txtSLSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSLSP.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSLSP.ForeColor = System.Drawing.Color.Black;
            this.txtSLSP.Location = new System.Drawing.Point(1031, 301);
            this.txtSLSP.Margin = new System.Windows.Forms.Padding(55, 0, 0, 0);
            this.txtSLSP.Name = "txtSLSP";
            this.txtSLSP.Size = new System.Drawing.Size(68, 32);
            this.txtSLSP.TabIndex = 20;
            // 
            // labSL
            // 
            this.labSL.AutoSize = true;
            this.labSL.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labSL.Location = new System.Drawing.Point(916, 306);
            this.labSL.Margin = new System.Windows.Forms.Padding(55, 0, 0, 0);
            this.labSL.Name = "labSL";
            this.labSL.Size = new System.Drawing.Size(116, 26);
            this.labSL.TabIndex = 19;
            this.labSL.Text = "Số lượng: ";
            // 
            // openFileImage
            // 
            this.openFileImage.FileName = "openFileDialog1";
            // 
            // imgSP
            // 
            this.imgSP.BackgroundImage = global::webbanhang.Properties.Resources.image;
            this.imgSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgSP.Location = new System.Drawing.Point(514, 48);
            this.imgSP.Margin = new System.Windows.Forms.Padding(4, 11, 4, 4);
            this.imgSP.Name = "imgSP";
            this.imgSP.Size = new System.Drawing.Size(276, 148);
            this.imgSP.TabIndex = 13;
            this.imgSP.TabStop = false;
            this.imgSP.Click += new System.EventHandler(this.imgSP_Click);
            // 
            // comboBoxPL
            // 
            this.comboBoxPL.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxPL.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBoxPL.ForeColor = System.Drawing.Color.Black;
            this.comboBoxPL.FormattingEnabled = true;
            this.comboBoxPL.Location = new System.Drawing.Point(184, 145);
            this.comboBoxPL.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPL.Name = "comboBoxPL";
            this.comboBoxPL.Size = new System.Drawing.Size(309, 40);
            this.comboBoxPL.TabIndex = 22;
            // 
            // labngay
            // 
            this.labngay.AutoSize = true;
            this.labngay.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labngay.Location = new System.Drawing.Point(23, 216);
            this.labngay.Margin = new System.Windows.Forms.Padding(3, 11, 3, 0);
            this.labngay.Name = "labngay";
            this.labngay.Size = new System.Drawing.Size(133, 26);
            this.labngay.TabIndex = 23;
            this.labngay.Text = "Thiết lập giá";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // dgViewgia
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewgia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewgia.BackgroundColor = System.Drawing.Color.White;
            this.dgViewgia.CausesValidation = false;
            this.dgViewgia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewgia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgViewgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgViewgia.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgViewgia.Location = new System.Drawing.Point(797, 19);
            this.dgViewgia.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.dgViewgia.Name = "dgViewgia";
            this.dgViewgia.RowHeadersVisible = false;
            this.dgViewgia.RowHeadersWidth = 51;
            this.dgViewgia.RowTemplate.Height = 24;
            this.dgViewgia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewgia.Size = new System.Drawing.Size(386, 223);
            this.dgViewgia.TabIndex = 25;
            this.dgViewgia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewgia_CellClick);
            // 
            // entityCommand2
            // 
            this.entityCommand2.CommandTimeout = 0;
            this.entityCommand2.CommandTree = null;
            this.entityCommand2.Connection = null;
            this.entityCommand2.EnablePlanCaching = true;
            this.entityCommand2.Transaction = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel18);
            this.panel1.Controls.Add(this.btnthem);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.btnxoa);
            this.panel1.Controls.Add(this.txtTenSP);
            this.panel1.Controls.Add(this.labTenSp);
            this.panel1.Controls.Add(this.dgViewgia);
            this.panel1.Controls.Add(this.labDvt);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.btnluu);
            this.panel1.Controls.Add(this.labMota);
            this.panel1.Controls.Add(this.labngay);
            this.panel1.Controls.Add(this.labhinhanh);
            this.panel1.Controls.Add(this.comboBoxPL);
            this.panel1.Controls.Add(this.txtmota);
            this.panel1.Controls.Add(this.txtdonvi);
            this.panel1.Controls.Add(this.labPhanloai);
            this.panel1.Controls.Add(this.txtdongia);
            this.panel1.Controls.Add(this.imgSP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 303);
            this.panel1.TabIndex = 26;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel18.Location = new System.Drawing.Point(184, 242);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(149, 1);
            this.panel18.TabIndex = 48;
            // 
            // btnthem
            // 
            this.btnthem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnthem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnthem.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnthem.FlatAppearance.BorderSize = 0;
            this.btnthem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthem.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnthem.Location = new System.Drawing.Point(687, 248);
            this.btnthem.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnthem.Name = "btnthem";
            this.btnthem.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnthem.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnthem.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnthem.Size = new System.Drawing.Size(150, 50);
            this.btnthem.TabIndex = 45;
            this.btnthem.Text = "+";
            this.btnthem.TextColor = System.Drawing.Color.Black;
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel4.Location = new System.Drawing.Point(184, 137);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(309, 1);
            this.panel4.TabIndex = 49;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel5.Location = new System.Drawing.Point(184, 101);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(309, 1);
            this.panel5.TabIndex = 49;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel6.Location = new System.Drawing.Point(184, 61);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(309, 1);
            this.panel6.TabIndex = 49;
            // 
            // btnxoa
            // 
            this.btnxoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnxoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnxoa.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnxoa.FlatAppearance.BorderSize = 0;
            this.btnxoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxoa.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxoa.Location = new System.Drawing.Point(860, 248);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnxoa.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnxoa.OnHoverTextColor = System.Drawing.Color.Red;
            this.btnxoa.Size = new System.Drawing.Size(150, 50);
            this.btnxoa.TabIndex = 46;
            this.btnxoa.Text = "DELETE";
            this.btnxoa.TextColor = System.Drawing.Color.Black;
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(354, 211);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 22, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 34);
            this.dateTimePicker1.TabIndex = 24;
            // 
            // btnluu
            // 
            this.btnluu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnluu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnluu.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnluu.FlatAppearance.BorderSize = 0;
            this.btnluu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnluu.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnluu.Location = new System.Drawing.Point(1033, 248);
            this.btnluu.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnluu.Name = "btnluu";
            this.btnluu.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnluu.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnluu.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnluu.Size = new System.Drawing.Size(150, 50);
            this.btnluu.TabIndex = 47;
            this.btnluu.Text = "SAVE";
            this.btnluu.TextColor = System.Drawing.Color.Black;
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel7.Location = new System.Drawing.Point(1031, 332);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(68, 1);
            this.panel7.TabIndex = 49;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel8.Location = new System.Drawing.Point(184, 331);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(178, 1);
            this.panel8.TabIndex = 49;
            // 
            // dgViewSP
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewSP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgViewSP.BackgroundColor = System.Drawing.Color.White;
            this.dgViewSP.CausesValidation = false;
            this.dgViewSP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgViewSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgViewSP.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgViewSP.Location = new System.Drawing.Point(26, 339);
            this.dgViewSP.Name = "dgViewSP";
            this.dgViewSP.RowHeadersVisible = false;
            this.dgViewSP.RowHeadersWidth = 51;
            this.dgViewSP.RowTemplate.Height = 24;
            this.dgViewSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewSP.Size = new System.Drawing.Size(1157, 383);
            this.dgViewSP.TabIndex = 21;
            this.dgViewSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewSP_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(11)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 670);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1219, 34);
            this.panel2.TabIndex = 50;
            // 
            // frmDMSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1219, 704);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.dgViewSP);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.labSL);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSLSP);
            this.Controls.Add(this.txtKeySP);
            this.Controls.Add(this.labtsp);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDMSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục sản phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDMSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewgia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTenSp;
        private System.Windows.Forms.Label labDvt;
        private System.Windows.Forms.Label labMota;
        private System.Windows.Forms.Label labhinhanh;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtmota;
        private System.Windows.Forms.TextBox txtdonvi;
        private System.Windows.Forms.Label labPhanloai;
        private System.Windows.Forms.TextBox txtdongia;
        private System.Windows.Forms.PictureBox imgSP;
        private System.Windows.Forms.TextBox txtKeySP;
        private System.Windows.Forms.Label labtsp;
        private System.Windows.Forms.TextBox txtSLSP;
        private System.Windows.Forms.Label labSL;
        private System.Windows.Forms.OpenFileDialog openFileImage;
        private System.Windows.Forms.ComboBox comboBoxPL;
        private System.Windows.Forms.Label labngay;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.DataGridView dgViewgia;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private ePOSOne.btnProduct.Button_WOC btnthem;
        private ePOSOne.btnProduct.Button_WOC btnluu;
        private ePOSOne.btnProduct.Button_WOC btnxoa;
        private System.Windows.Forms.DataGridView dgViewSP;
        private System.Windows.Forms.Panel panel2;
    }
}