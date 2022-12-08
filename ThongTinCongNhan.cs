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
    public partial class ThongTinCongNhan : Form
    {
        public ThongTinCongNhan()
        {
            InitializeComponent();
        }
        //Check trường hợp
        int check;
        void LoadData()
        {
            dgvNhanSu.DataSource = null;
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        var listnv = QLNS.CongNhans.Select(x => new { x.MaNS, x.HoTen, x.GioiTinh, x.QueQuan, x.NgSinh, x.TrinhĐoHV, x.SĐT, x.DiaChi, x.Bac, x.To_Nhom, x.To_Truong, x.Luong, x.Thuong }).ToList();
                        dgvNhanSu.DataSource = listnv;
                        Transaction.Commit();
                    }
                    catch
                    {
                        MessageBox.Show("Không lấy được nội dung trong table CongNhan.Lỗi rồi!!!");
                        Transaction.Rollback();
                    }
                }
            }
            // Xóa trống các đối tượng trong Panel
            this.txtMaNS.ResetText();
            this.txtHoTen.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtQueQuan.ResetText();
            this.dtNgaySinh.ResetText();
            this.txtTDHV.ResetText();
            this.txtSĐT.ResetText();
            this.txtDiaChi.ResetText();
            this.cbBac.ResetText();
            this.txtTo.ResetText();
            this.txtToTruong.ResetText();
            this.chkThuong.Checked = false;
            // Không cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.panel1.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
        }

        private void ThongTinCongNhan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNS = txtMaNS.Text.ToString();
            string hoTen = txtHoTen.Text.ToString();
            string gioiTinh = txtGioiTinh.Text.ToString();
            string queQuan = txtQueQuan.Text.ToString();
            string ngSinh = dtNgaySinh.Text.ToString();
            string trinhDoHV = txtTDHV.Text.ToString();
            string sdt = txtSĐT.Text.ToString();
            string diaChi = txtDiaChi.Text.ToString();
            int bac = Convert.ToInt32(cbBac.Text.ToString());
            string to = txtTo.Text.ToString();
            string toTruong = txtToTruong.Text.ToString();
            bool thuong = chkThuong.Checked;

            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    // Thêm dữ liệu
                    if (check == 1)
                    {
                        try
                        {
                            CongNhan.InsertNewRowsCongNhan(maNS, hoTen, gioiTinh, queQuan, ngSinh, trinhDoHV, sdt, diaChi, bac, to, toTruong, null, thuong);
                            // Load lại dữ liệu trên DataGridView
                            LoadData();
                            // Thông báo
                            MessageBox.Show("Đã thêm xong!");
                        }
                        catch
                        {
                            MessageBox.Show("Không thêm được. Lỗi rồi!");
                            Transaction.Rollback();
                        }
                    }
                    //Sửa dữ liệu
                    if (check == 2)
                    {
                        try
                        {
                            // Thứ tự dòng hiện hành
                            int r = dgvNhanSu.CurrentCell.RowIndex;
                            // MaNV hiện hành
                            string strMaNS = dgvNhanSu.Rows[r].Cells[0].Value.ToString();
                            var result = QLNS.CongNhans.Where(cn => cn.MaNS.Equals(strMaNS)).Single();
                            // Cập nhật
                            result.MaNS = maNS;
                            result.HoTen = hoTen;
                            result.GioiTinh = gioiTinh;
                            result.QueQuan = queQuan;
                            result.NgSinh = Convert.ToDateTime(ngSinh);
                            result.TrinhĐoHV = trinhDoHV;
                            result.SĐT = sdt;
                            result.DiaChi = diaChi;
                            result.Bac = bac;
                            result.To_Nhom = to;
                            result.To_Truong = toTruong;
                            result.Thuong = thuong;
                            QLNS.SaveChanges();
                            Transaction.Commit();
                            // Load lại dữ liệu trên DataGridView
                            LoadData();
                            // Thông báo
                            MessageBox.Show("Đã sửa xong!");
                        }
                        catch
                        {
                            MessageBox.Show("Không sửa được. Lỗi rồi!");
                        }
                    }
                    //Xóa dữ liệu
                    if (check == 3)
                    {
                        try
                        {
                            // Thứ tự dòng hiện hành
                            int r = dgvNhanSu.CurrentCell.RowIndex;
                            // MaNS hiện hành
                            string strMaNV = dgvNhanSu.Rows[r].Cells[0].Value.ToString();
                            // Xóa các bản ghi ở các bản khác tham chiếu đến MaNS hiện hành
                            var result1 = QLNS.ChamCongs.Where(nv => nv.MaNS.Equals(strMaNV)).SingleOrDefault();
                            if (result1 != null)
                            {
                                QLNS.ChamCongs.Remove(result1);
                            }
                            // Xóa bản ghi CongNhan
                            var result2 = QLNS.CongNhans.Where(nv => nv.MaNS.Equals(strMaNV)).Single();
                            QLNS.CongNhans.Remove(result2);
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
                    this.btnExport.Enabled = true;
                    this.btnHuy.Enabled = false;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến check
            check = 1;
            // Xóa trống các đối tượng trong Panel
            this.txtMaNS.ResetText();
            this.txtHoTen.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtQueQuan.ResetText();
            this.dtNgaySinh.ResetText();
            this.txtTDHV.ResetText();
            this.txtSĐT.ResetText();
            this.txtDiaChi.ResetText();
            this.cbBac.ResetText();
            this.txtTo.ResetText();
            this.txtToTruong.ResetText();
            this.chkThuong.Checked = false;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.panel1.Enabled = true;
            // Không cho thao tác trên các nút Export / Thêm / Xóa
            this.btnExport.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaNS.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            check = 2;
            // Thứ tự dòng hiện hành
            int r = dgvNhanSu.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaNS.Text = dgvNhanSu.Rows[r].Cells[0].Value.ToString();
            this.txtHoTen.Text = dgvNhanSu.Rows[r].Cells[1].Value.ToString();
            this.txtGioiTinh.Text = dgvNhanSu.Rows[r].Cells[2].Value.ToString();
            this.txtQueQuan.Text = dgvNhanSu.Rows[r].Cells[3].Value.ToString();
            this.dtNgaySinh.Text = dgvNhanSu.Rows[r].Cells[4].Value.ToString();
            this.txtTDHV.Text = dgvNhanSu.Rows[r].Cells[5].Value.ToString();
            this.txtSĐT.Text = dgvNhanSu.Rows[r].Cells[6].Value.ToString();
            this.txtDiaChi.Text = dgvNhanSu.Rows[r].Cells[7].Value.ToString();
            this.cbBac.Text = dgvNhanSu.Rows[r].Cells[8].Value.ToString();
            this.txtTo.Text = dgvNhanSu.Rows[r].Cells[9].Value.ToString();
            this.txtToTruong.Text = dgvNhanSu.Rows[r].Cells[10].Value.ToString();
            this.chkThuong.Checked = (bool) dgvNhanSu.Rows[r].Cells[12].Value;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.panel1.Enabled = true;
            // Không cho thao tác trên các nút Export / Thêm / Sửa / Xóa
            this.btnExport.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaNS.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Xóa
            check = 3;
            // Thứ tự dòng hiện hành
            int r = dgvNhanSu.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaNS.Text = dgvNhanSu.Rows[r].Cells[0].Value.ToString();
            this.txtHoTen.Text = dgvNhanSu.Rows[r].Cells[1].Value.ToString();
            this.txtGioiTinh.Text = dgvNhanSu.Rows[r].Cells[2].Value.ToString();
            this.txtQueQuan.Text = dgvNhanSu.Rows[r].Cells[3].Value.ToString();
            this.dtNgaySinh.Text = dgvNhanSu.Rows[r].Cells[4].Value.ToString();
            this.txtTDHV.Text = dgvNhanSu.Rows[r].Cells[5].Value.ToString();
            this.txtSĐT.Text = dgvNhanSu.Rows[r].Cells[6].Value.ToString();
            this.txtDiaChi.Text = dgvNhanSu.Rows[r].Cells[7].Value.ToString();
            this.cbBac.Text = dgvNhanSu.Rows[r].Cells[8].Value.ToString();
            this.txtTo.Text = dgvNhanSu.Rows[r].Cells[9].Value.ToString();
            this.txtToTruong.Text = dgvNhanSu.Rows[r].Cells[10].Value.ToString();
            this.chkThuong.Checked = (bool)dgvNhanSu.Rows[r].Cells[12].Value;
            // Cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Export / Thêm / Sửa
            this.btnExport.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaNS.ResetText();
            this.txtHoTen.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtQueQuan.ResetText();
            this.dtNgaySinh.ResetText();
            this.txtTDHV.ResetText();
            this.txtSĐT.ResetText();
            this.txtDiaChi.ResetText();
            this.cbBac.ResetText();
            this.txtTo.ResetText();
            this.txtToTruong.ResetText();
            this.chkThuong.Checked = false;
            // Cho thao tác trên các nút Export / Thêm / Sửa / Xóa
            this.btnExport.Enabled = true;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.panel1.Enabled = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvNhanSu, saveFileDialog1.FileName);
            }
        }
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = "Quản lý Công Nhân";

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
    }
}
