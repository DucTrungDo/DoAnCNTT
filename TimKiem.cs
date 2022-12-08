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
    public partial class TimKiem : Form
    {
        public TimKiem()
        {
            InitializeComponent();
        }

        private void cbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTimKiem.SelectedIndex == 0)
            {
                this.panel1.Enabled = true;
            }
            else if (cbTimKiem.SelectedIndex == 1)
            {
                this.panel1.Enabled = false;
            }
            else
            {
                this.panel1.Enabled = false;
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (var QLNS = new QLNhanSuDVSXs())
            {
                if (cbTimKiem.SelectedIndex == 0)
                {
                    try
                    {
                        dgvTimKiem.DataSource = null;
                        if (QLNS.CongNhans.Where(x => x.MaNS.Equals(txtMaNS.Text.ToString())).SingleOrDefault() != null)
                            dgvTimKiem.DataSource = QLNS.CongNhans.Where(x => x.MaNS.Equals(txtMaNS.Text.ToString())).Select(x => new { x.MaNS, x.HoTen, x.GioiTinh, x.QueQuan, x.NgSinh, x.TrinhĐoHV, x.SĐT, x.DiaChi, x.Bac, x.To_Nhom, x.To_Truong }).ToList();

                        else if (QLNS.KySus.Where(x => x.MaNS.Equals(txtMaNS.Text.ToString())).SingleOrDefault() != null)
                            dgvTimKiem.DataSource = QLNS.KySus.Where(x => x.MaNS.Equals(txtMaNS.Text.ToString())).Select(x => new { x.MaNS, x.HoTen, x.GioiTinh, x.QueQuan, x.NgSinh, x.TrinhĐoHV, x.SĐT, x.DiaChi, x.NganhDaoTao, x.BoPhan, x.TruongBoPhan, x.PhuTrachTo }).ToList();

                        else if (QLNS.NhanViens.Where(x => x.MaNS.Equals(txtMaNS.Text.ToString())).SingleOrDefault() != null)
                            dgvTimKiem.DataSource = QLNS.NhanViens.Where(x => x.MaNS.Equals(txtMaNS.Text.ToString())).Select(x => new { x.MaNS, x.HoTen, x.GioiTinh, x.QueQuan, x.NgSinh, x.TrinhĐoHV, x.SĐT, x.DiaChi, x.CongViecDamNhiem, x.ChucVuNV, x.PhongBan }).ToList();
                        else
                            throw new Exception();
                }
                    catch
                {
                    MessageBox.Show("Không tìm thấy nhân sự!");
                }
            }
                if (cbTimKiem.SelectedIndex == 1)
                {
                    try
                    {
                        dgvTimKiem.DataSource = null;
                        var listnv = QLNS.NhanViens.Select(x => new { x.MaNS, x.HoTen, x.Luong }).ToList();
                        listnv.AddRange(QLNS.CongNhans.Select(x => new { x.MaNS, x.HoTen, x.Luong }).ToList());
                        listnv.AddRange(QLNS.KySus.Select(x => new { x.MaNS, x.HoTen, x.Luong }).ToList());
                        listnv = listnv.OrderByDescending(x => x.Luong).Take(10).ToList();
                        if (listnv.Select(x => x.Luong).FirstOrDefault() != null)
                            dgvTimKiem.DataSource = listnv;
                        else
                            throw new Exception();
                    }
                    catch
                    {
                        MessageBox.Show("Chưa được tính lương!");
                    }
                }
                if (cbTimKiem.SelectedIndex == 2)
                {
                    try
                    {
                        dgvTimKiem.DataSource = null;
                        var listnv = new[]
                        {
                                new {bac = 1, soLuong = QLNS.CongNhans.Where(x => x.Bac.Equals(1)).Count() },
                                new {bac = 2, soLuong = QLNS.CongNhans.Where(x => x.Bac.Equals(2)).Count() },
                                new {bac = 3, soLuong = QLNS.CongNhans.Where(x => x.Bac.Equals(3)).Count() },
                                new {bac = 4, soLuong = QLNS.CongNhans.Where(x => x.Bac.Equals(4)).Count() },
                            }.ToList();
                        dgvTimKiem.DataSource = listnv;
                    }
                    catch
                    {
                        MessageBox.Show("Không thống kê được!");
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dgvNhanSu và filename từ SaveFileDialog
                ToExcel(dgvTimKiem, saveFileDialog1.FileName);
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
                worksheet.Name = "Thông tin";

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