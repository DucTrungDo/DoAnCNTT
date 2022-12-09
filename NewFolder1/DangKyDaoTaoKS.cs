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
    public partial class DangKyDaoTaoKS : Form
    {
        public DangKyDaoTaoKS()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            dgvNhanSu.DataSource = null;
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        var listnv = QLNS.DangKyDaoTaoKySus.Select(x => new { x.MaNS, x.HoTen, x.CT_DaoTao}).ToList();
                        dgvNhanSu.DataSource = listnv;
                        Transaction.Commit();
                    }
                    catch
                    {
                        MessageBox.Show("Không lấy được nội dung trong table DangKyDaoTaoKySu.Lỗi rồi!!!");
                        Transaction.Rollback();
                    }
                }
            }
        }

        private void DaoTao_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnĐK_Click(object sender, EventArgs e)
        {
            string maNS = txtMaNS.Text.ToString();
            string hoTen = txtHoTen.Text.ToString();
            string CTDT = cbCTDT.Text.ToString();

            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        DangKyDaoTaoKySu.InsertNewRowsDangKyDaoTaoKySu(maNS, hoTen, CTDT);
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đăng ký thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Không đăng ký được. Lỗi rồi!");
                        Transaction.Rollback();
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        // Thứ tự dòng hiện hành
                        int r = dgvNhanSu.CurrentCell.RowIndex;
                        // MaNS hiện hành
                        string strMaNV = dgvNhanSu.Rows[r].Cells[0].Value.ToString();
                        // Xóa bản ghi CongNhan
                        var result = QLNS.DangKyDaoTaoKySus.Where(nv => nv.MaNS.Equals(strMaNV)).Single();
                        QLNS.DangKyDaoTaoKySus.Remove(result);
                        //Lưu dữ liệu sau khi xóa 
                        QLNS.SaveChanges();
                        // Kết thúc transaction                                          
                        Transaction.Commit();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Hủy thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Không hủy được. Lỗi rồi!");
                    }
                }
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
