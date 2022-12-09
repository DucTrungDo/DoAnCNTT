
namespace QLNhanSuDVSX
{
    partial class ThongTinNhanSu
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
            this.dgvNhanSu = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanSu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNhanSu
            // 
            this.dgvNhanSu.AllowUserToAddRows = false;
            this.dgvNhanSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNhanSu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNhanSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanSu.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvNhanSu.Location = new System.Drawing.Point(14, 124);
            this.dgvNhanSu.Margin = new System.Windows.Forms.Padding(5);
            this.dgvNhanSu.Name = "dgvNhanSu";
            this.dgvNhanSu.RowHeadersWidth = 51;
            this.dgvNhanSu.RowTemplate.Height = 24;
            this.dgvNhanSu.Size = new System.Drawing.Size(1125, 356);
            this.dgvNhanSu.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(469, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(246, 32);
            this.label12.TabIndex = 41;
            this.label12.Text = "Thông tin Nhân Sự";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closebtn
            // 
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closebtn.Location = new System.Drawing.Point(1104, 29);
            this.closebtn.Margin = new System.Windows.Forms.Padding(5);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(35, 42);
            this.closebtn.TabIndex = 40;
            this.closebtn.Text = "X";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(534, 490);
            this.btnExport.Margin = new System.Windows.Forms.Padding(5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(101, 39);
            this.btnExport.TabIndex = 83;
            this.btnExport.Text = "Xuất File";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ThongTinNhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1155, 563);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.dgvNhanSu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThongTinNhanSu";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Nhân Sự";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNhanSu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button btnExport;
    }
}

