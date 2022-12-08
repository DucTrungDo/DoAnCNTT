using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace QLNhanSuDVSX
{
    public partial class DangKyTeamBuillding : Form
    {
        public DangKyTeamBuillding()
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
                        var listnv = QLNS.DangKy_TeamBuildings.Select(x => new { x.MaNS, x.HoTen, x.ChiPhi}).ToList();
                        dgvNhanSu.DataSource = listnv;
                        Transaction.Commit();
                    }
                    catch
                    {
                        MessageBox.Show("Không lấy được nội dung trong table DangKy_TeamBuilding.Lỗi rồi!!!");
                        Transaction.Rollback();
                    }
                }
            }
        }
        private void TeamBuillding_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
           this.Hide();
        }

        private void btnĐK_Click(object sender, EventArgs e)
        {
            string maNS = txtMaNS.Text.ToString();
            string hoTen = txtHoTen.Text.ToString();

            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        DangKy_TeamBuilding.InsertNewRowDangKy_TeamBuilding(maNS, hoTen, null);
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã thêm xong!");
                    }
                    catch
                    {
                        MessageBox.Show("Không đăng ký được. Lỗi rồi!");
                        Transaction.Rollback();
                    }
                }
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        var result = QLNS.DangKy_TeamBuildings;
                        foreach (var obj in result)
                        {
                            var t = QLNS.NhanViens.Where(x => x.MaNS.Equals(obj.MaNS) && x.ChucVuNV == "Giam doc").SingleOrDefault();
                            if (t != null)
                            {
                                obj.ChiPhi = 0;
                                Console.Write(1);
                                Console.WriteLine(obj.MaNS);
                                continue;
                            }

                            t = QLNS.NhanViens.Where(x => x.MaNS.Equals(obj.MaNS) && x.ChucVuNV == "Pho giam doc").SingleOrDefault();
                            if (t != null)
                            {
                                obj.ChiPhi = 0;
                                continue;
                            }
                            t = QLNS.NhanViens.Where(x => x.MaNS.Equals(obj.MaNS) && x.SoLanThuong >= 3).SingleOrDefault();
                            if (t != null)
                            {
                                obj.ChiPhi = 0;
                            }
                            else
                            {
                                obj.ChiPhi = (Convert.ToInt32(txtCP.Text)) / 4;
                            }
                        }
                        QLNS.SaveChanges();
                        Transaction.Commit();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã cập nhật chi phí xong!");
                    }
                    catch
                    {
                        MessageBox.Show("Không tính được. Lỗi rồi!");
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
                        var result = QLNS.DangKy_TeamBuildings.Where(nv => nv.MaNS.Equals(strMaNV)).Single();
                        QLNS.DangKy_TeamBuildings.Remove(result);
                        //Lưu dữ liệu sau khi xóa 
                        QLNS.SaveChanges();
                        // Kết thúc transaction                                          
                        Transaction.Commit();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã xóa xong!");
                    }
                    catch
                    {
                        MessageBox.Show("Không xóa được. Lỗi rồi!");
                    }
                }
            }
        }
    }
}
