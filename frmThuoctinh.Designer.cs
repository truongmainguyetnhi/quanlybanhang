namespace webbanhang
{
    partial class frmThuoctinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThuoctinh));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgViewTT = new System.Windows.Forms.DataGridView();
            this.txtSLTT = new System.Windows.Forms.TextBox();
            this.labSLTT = new System.Windows.Forms.Label();
            this.labkeyTT = new System.Windows.Forms.Label();
            this.txtKeyTT = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsave = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.btnaddnew = new System.Windows.Forms.Button();
            this.imgTT = new System.Windows.Forms.PictureBox();
            this.txtTenTT = new System.Windows.Forms.TextBox();
            this.txtGiatri = new System.Windows.Forms.TextBox();
            this.txtTenHH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labTenTT = new System.Windows.Forms.Label();
            this.labTenHH = new System.Windows.Forms.Label();
            this.openFileImage = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTT)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTT)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dgViewTT);
            this.panel1.Controls.Add(this.txtSLTT);
            this.panel1.Controls.Add(this.labSLTT);
            this.panel1.Controls.Add(this.labkeyTT);
            this.panel1.Controls.Add(this.txtKeyTT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(320, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 578);
            this.panel1.TabIndex = 0;
            // 
            // dgViewTT
            // 
            this.dgViewTT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewTT.Location = new System.Drawing.Point(3, 118);
            this.dgViewTT.Name = "dgViewTT";
            this.dgViewTT.RowHeadersWidth = 51;
            this.dgViewTT.RowTemplate.Height = 24;
            this.dgViewTT.Size = new System.Drawing.Size(589, 455);
            this.dgViewTT.TabIndex = 11;
            this.dgViewTT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewTT_CellClick);
            // 
            // txtSLTT
            // 
            this.txtSLTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSLTT.Location = new System.Drawing.Point(236, 73);
            this.txtSLTT.Name = "txtSLTT";
            this.txtSLTT.Size = new System.Drawing.Size(133, 26);
            this.txtSLTT.TabIndex = 9;
            // 
            // labSLTT
            // 
            this.labSLTT.AutoSize = true;
            this.labSLTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labSLTT.Location = new System.Drawing.Point(30, 76);
            this.labSLTT.Margin = new System.Windows.Forms.Padding(30, 30, 3, 0);
            this.labSLTT.Name = "labSLTT";
            this.labSLTT.Size = new System.Drawing.Size(147, 20);
            this.labSLTT.TabIndex = 10;
            this.labSLTT.Text = "Tổng số thuộc tính";
            // 
            // labkeyTT
            // 
            this.labkeyTT.AutoSize = true;
            this.labkeyTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labkeyTT.Location = new System.Drawing.Point(30, 30);
            this.labkeyTT.Margin = new System.Windows.Forms.Padding(30, 30, 3, 0);
            this.labkeyTT.Name = "labkeyTT";
            this.labkeyTT.Size = new System.Drawing.Size(115, 20);
            this.labkeyTT.TabIndex = 9;
            this.labkeyTT.Text = "Tìm thuộc tính";
            // 
            // txtKeyTT
            // 
            this.txtKeyTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtKeyTT.Location = new System.Drawing.Point(236, 25);
            this.txtKeyTT.Name = "txtKeyTT";
            this.txtKeyTT.Size = new System.Drawing.Size(133, 26);
            this.txtKeyTT.TabIndex = 6;
            this.txtKeyTT.TextChanged += new System.EventHandler(this.txtKeyTT_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 79);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "THUỘC TÍNH HÀNG HÓA";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.btnsave);
            this.panel3.Controls.Add(this.btndel);
            this.panel3.Controls.Add(this.btnaddnew);
            this.panel3.Controls.Add(this.imgTT);
            this.panel3.Controls.Add(this.txtTenTT);
            this.panel3.Controls.Add(this.txtGiatri);
            this.panel3.Controls.Add(this.txtTenHH);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.labTenTT);
            this.panel3.Controls.Add(this.labTenHH);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(314, 499);
            this.panel3.TabIndex = 2;
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnsave.Location = new System.Drawing.Point(194, 466);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(72, 28);
            this.btnsave.TabIndex = 12;
            this.btnsave.Text = "SAVE";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btndel
            // 
            this.btndel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btndel.Location = new System.Drawing.Point(114, 466);
            this.btndel.Margin = new System.Windows.Forms.Padding(8, 5, 3, 3);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(72, 28);
            this.btndel.TabIndex = 11;
            this.btndel.Text = "DELETE";
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnaddnew
            // 
            this.btnaddnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnaddnew.Location = new System.Drawing.Point(31, 466);
            this.btnaddnew.Name = "btnaddnew";
            this.btnaddnew.Size = new System.Drawing.Size(72, 28);
            this.btnaddnew.TabIndex = 10;
            this.btnaddnew.Text = "ADDNEW";
            this.btnaddnew.UseVisualStyleBackColor = true;
            this.btnaddnew.Click += new System.EventHandler(this.btnaddnew_Click);
            // 
            // imgTT
            // 
            this.imgTT.BackgroundImage = global::webbanhang.Properties.Resources.graphic_style__1_;
            this.imgTT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgTT.Location = new System.Drawing.Point(31, 249);
            this.imgTT.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.imgTT.Name = "imgTT";
            this.imgTT.Size = new System.Drawing.Size(235, 192);
            this.imgTT.TabIndex = 9;
            this.imgTT.TabStop = false;
            this.imgTT.Click += new System.EventHandler(this.imgTT_Click);
            // 
            // txtTenTT
            // 
            this.txtTenTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenTT.Location = new System.Drawing.Point(34, 115);
            this.txtTenTT.Name = "txtTenTT";
            this.txtTenTT.Size = new System.Drawing.Size(235, 26);
            this.txtTenTT.TabIndex = 8;
            // 
            // txtGiatri
            // 
            this.txtGiatri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtGiatri.Location = new System.Drawing.Point(33, 177);
            this.txtGiatri.Name = "txtGiatri";
            this.txtGiatri.Size = new System.Drawing.Size(235, 26);
            this.txtGiatri.TabIndex = 7;
            // 
            // txtTenHH
            // 
            this.txtTenHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenHH.Location = new System.Drawing.Point(34, 53);
            this.txtTenHH.Name = "txtTenHH";
            this.txtTenHH.Size = new System.Drawing.Size(235, 26);
            this.txtTenHH.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(30, 216);
            this.label5.Margin = new System.Windows.Forms.Padding(30, 10, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hình ảnh:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(30, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(30, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "GIá trị: ";
            // 
            // labTenTT
            // 
            this.labTenTT.AutoSize = true;
            this.labTenTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labTenTT.Location = new System.Drawing.Point(29, 92);
            this.labTenTT.Margin = new System.Windows.Forms.Padding(30, 10, 3, 0);
            this.labTenTT.Name = "labTenTT";
            this.labTenTT.Size = new System.Drawing.Size(120, 20);
            this.labTenTT.TabIndex = 2;
            this.labTenTT.Text = "Tên thuộc tính:";
            // 
            // labTenHH
            // 
            this.labTenHH.AutoSize = true;
            this.labTenHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labTenHH.Location = new System.Drawing.Point(30, 30);
            this.labTenHH.Margin = new System.Windows.Forms.Padding(30, 30, 3, 0);
            this.labTenHH.Name = "labTenHH";
            this.labTenHH.Size = new System.Drawing.Size(115, 20);
            this.labTenHH.TabIndex = 1;
            this.labTenHH.Text = "Tên hàng hóa:";
            // 
            // openFileImage
            // 
            this.openFileImage.FileName = "openFileDialog1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmThuoctinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 578);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThuoctinh";
            this.Text = "Thuộc tính hàng hóa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThuoctinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTT)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labTenHH;
        private System.Windows.Forms.TextBox txtTenHH;
        private System.Windows.Forms.TextBox txtTenTT;
        private System.Windows.Forms.TextBox txtGiatri;
        private System.Windows.Forms.TextBox txtKeyTT;
        private System.Windows.Forms.Label labTenTT;
        private System.Windows.Forms.Label labSLTT;
        private System.Windows.Forms.Label labkeyTT;
        private System.Windows.Forms.TextBox txtSLTT;
        private System.Windows.Forms.PictureBox imgTT;
        private System.Windows.Forms.DataGridView dgViewTT;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btnaddnew;
        private System.Windows.Forms.OpenFileDialog openFileImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}