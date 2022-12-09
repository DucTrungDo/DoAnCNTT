using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSuDVSX
{
    public partial class ThongTinTrinhDoHV : Form
    {
        public ThongTinTrinhDoHV()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            dgvTrinhDo.DataSource = null;
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        var listnv = QLNS.TrinhDoes.Select(x => new { x.TrinhDoHV, x.SoLuongNS }).ToList();
                        dgvTrinhDo.DataSource = listnv;
                        Transaction.Commit();
                    }
                    catch
                    {
                        MessageBox.Show("Không lấy được nội dung trong TrinhDo.Lỗi rồi!!!");
                        Transaction.Rollback();
                    }
                }
            }
        }
        private void ThongTinTrinhDoHV_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        var listns = QLNS.TrinhDoes;

                        foreach (var obj in listns)
                        {
                            obj.SoLuongNS = QLNS.NhanSus.Where(x => x.TrinhĐoHV.Equals(obj.TrinhDoHV)).Count();
                        }

                        QLNS.SaveChanges();
                        Transaction.Commit();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã cập nhật thông tin TrinhDo thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                        Transaction.Rollback();
                    }
                }
            }
        }
    }
}
