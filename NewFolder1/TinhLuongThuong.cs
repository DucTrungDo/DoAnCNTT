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
    public partial class TinhLuongThuong : Form
    {
        public TinhLuongThuong()
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
                        var listnv = QLNS.NhanViens.Select(x => new { x.MaNS, x.HoTen, x.Luong }).ToList();
                        listnv.AddRange(QLNS.CongNhans.Select(x => new { x.MaNS, x.HoTen, x.Luong }).ToList());
                        listnv.AddRange(QLNS.KySus.Select(x => new { x.MaNS, x.HoTen, x.Luong }).ToList());
                        listnv = listnv.OrderBy(x => x.MaNS).ToList();

                        dgvNhanSu.DataSource = listnv;
                        Transaction.Commit();
                    }
                    catch
                    {
                        MessageBox.Show("Không tính được lương.Lỗi rồi!!!");
                        Transaction.Rollback();
                    }
                }
            }
        }
        private void TinhLuongThuong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            int coBan = 10000000;
            int bac = 1000000;
            int thuongNV = 1000000;
            int thuongKS = 1500000;
            int thuongCN = 500000;
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        var resultNV = QLNS.NhanViens;
                        foreach (var obj in resultNV)
                        {
                            if (obj.ChucVuNV.TrimEnd().Equals("Nhan vien"))
                                obj.Luong = (int)(1.5 * coBan + thuongNV * obj.SoLanThuong);
                            else if (obj.ChucVuNV.TrimEnd().Equals("Pho giam doc"))
                                obj.Luong = (int)(3.5 * coBan + thuongNV * obj.SoLanThuong);
                            else if (obj.ChucVuNV.TrimEnd().Equals("Giam doc"))
                                    obj.Luong = 5 * coBan + thuongNV*obj.SoLanThuong;

                            if (obj.ChamCong != null && obj.ChamCong.SoLanChamCong >= 24)
                                obj.Luong += thuongNV;
                        }

                        var resultCN = QLNS.CongNhans;
                        int? t = 0;
                        if (QLNS.DanhGiaToes.Select(x => x.DiemTB).FirstOrDefault() != null)
                            t = QLNS.DanhGiaToes.Max(x => x.DiemTB);
                        foreach (var obj in resultCN)
                        {
                            if (obj.To_Truong.TrimEnd() == "Co")
                                obj.Luong = (int)(1.1*coBan + (5 - obj.Bac)*bac);
                            else
                                obj.Luong = (int)(1.0*coBan + (5 - obj.Bac)*bac);
                            if (obj.Thuong)
                                obj.Luong += thuongCN;
                            if (obj.ChamCong !=null && obj.ChamCong.SoLanChamCong >= 24)
                                obj.Luong += thuongCN;
                            if (QLNS.DanhGiaToes.Where(x => x.DiemTB == t && x.To_Nhom.Equals(obj.To_Nhom)).SingleOrDefault() != null)
                                obj.Luong += 300000;
                        }

                        var resultKS = QLNS.KySus;
                        foreach (var obj in resultKS)
                        {
                            if (obj.BoPhan.TrimEnd() == "Thi Cong")
                                obj.Luong = (int)(2.1*coBan + thuongKS*obj.SoLanThuong);
                            else
                                obj.Luong = (int)(2.3*coBan + thuongKS*obj.SoLanThuong);
                        }


                        QLNS.SaveChanges();
                        Transaction.Commit();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã cập nhật lương nhân sự thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                        Transaction.Rollback();
                    }
                }
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
