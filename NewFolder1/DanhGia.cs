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
    public partial class DanhGia : Form
    {
        public DanhGia()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            dgvDanhGia.DataSource = null;
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        var listnv = QLNS.DanhGiaToes.Select(x => new { x.To_Nhom, x.DanhGia_GD, x.DanhGia_PGD, x.DanhGia_KSPT, x.Diem_GD, x.Diem_PGD, x.Diem_KSPT, x.DiemTB }).ToList();
                        dgvDanhGia.DataSource = listnv;
                        Transaction.Commit();
                    }
                    catch
                    {
                        MessageBox.Show("Không lấy được nội dung trong table DanhGiaTo.Lỗi rồi!!!");
                        Transaction.Rollback();
                    }
                }
            }
        }

        private void DanhGia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int coBan = 10000000;
            int bac = 1000000;
            int thuongCN = 500000;
            dgvLuong.DataSource = null;
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        var resultCN = QLNS.CongNhans;
                        int? t = 0;
                        if (QLNS.DanhGiaToes.Select(x => x.DiemTB).FirstOrDefault() != null)
                            t = QLNS.DanhGiaToes.Max(x => x.DiemTB);
                        foreach (var obj in resultCN)
                        {
                            if (obj.To_Truong.TrimEnd() == "Co")
                                obj.Luong = (int)(1.1 * coBan + (5 - obj.Bac) * bac);
                            else
                                obj.Luong = (int)(1.0 * coBan + (5 - obj.Bac) * bac);
                            if (obj.Thuong)
                                obj.Luong += thuongCN;
                            if (obj.ChamCong != null && obj.ChamCong.SoLanChamCong >= 24)
                                obj.Luong += thuongCN;
                            if (QLNS.DanhGiaToes.Where(x => x.DiemTB == t && x.To_Nhom.Equals(obj.To_Nhom)).SingleOrDefault() != null)
                                obj.Luong += 300000;
                        }
                        QLNS.SaveChanges();
                        var listnv = resultCN.Select(x => new { x.MaNS, x.Bac, x.To_Nhom, x.Thuong, x.Luong }).ToList();
                        dgvLuong.DataSource = listnv;
                        this.btnCapNhat.Enabled = false;
                        Transaction.Commit();
                    }
                    catch
                    {
                        MessageBox.Show("Không thể cập nhật.Lỗi rồi!!!");
                        Transaction.Rollback();
                    }
                }
            }
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        var result = QLNS.DanhGiaToes;
                        foreach (var obj in result)
                        {
                            obj.DiemTB = obj.Diem_KSPT + obj.Diem_GD + obj.Diem_PGD;
                        }
                        QLNS.SaveChanges();
                        Transaction.Commit();
                        LoadData();
                        this.btnDiem.Enabled = false;
                        this.btnCapNhat.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Không thể tính điểm.Lỗi rồi!!!");
                        Transaction.Rollback();
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    var result = QLNS.DanhGiaToes.Select(x => x.DiemTB).FirstOrDefault();
                    if (result == null)
                        this.btnDiem.Enabled = true;
                    LoadData();
                }
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
