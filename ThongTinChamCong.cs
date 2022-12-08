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
    public partial class ThongTinChamCong : Form
    {
        public ThongTinChamCong()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            dgvChamCong.DataSource = null;
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        var listchamcong = QLNS.ChamCongs.Select(x => new { x.MaNS, x.HoTen, x.SoLanChamCong }).ToList();
                        dgvChamCong.DataSource = listchamcong;
                        Transaction.Commit();
                    }
                    catch
                    {
                        MessageBox.Show("Không lấy được nội dung trong table ChamCong.Lỗi rồi!!!");
                        Transaction.Rollback();
                    }
                }
            }
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ThongTinChamCong_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
