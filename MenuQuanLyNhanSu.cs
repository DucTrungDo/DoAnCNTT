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
    public partial class MenuQuanLyNhanSu : Form
    {
        public MenuQuanLyNhanSu()
        {
            InitializeComponent();
            hideSubMenu();
        }
        private void hideSubMenu()
        {
            panelNhanSu.Visible = false;
            panelKySu.Visible = false;
            panelCongNhan.Visible = false;
            panelNhanVien.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (traloi == DialogResult.OK)
            {
                Form frmLog = new Login();
                frmLog.Show();
                this.Hide();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            showSubMenu(panelNhanSu);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            showSubMenu(panelKySu);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCongNhan);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            showSubMenu(panelNhanVien);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form DS_NhanSu = new ThongTinNhanSu();
            DS_NhanSu.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form Tinh_LuongThuong = new TinhLuongThuong();
            Tinh_LuongThuong.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form Tim_Kiem = new TimKiem();
            Tim_Kiem.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Cham_Cong = new ThongTinChamCong();
            Cham_Cong.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form DS_KySu = new ThongTinKySu();
            DS_KySu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form DK_DaoTaoKS = new DangKyDaoTaoKS();
            DK_DaoTaoKS.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form DS_CongNhan = new ThongTinCongNhan();
            DS_CongNhan.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form DanhGia_To = new DanhGia();
            DanhGia_To.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form DS_NhanVien = new ThongTinNhanVien();
            DS_NhanVien.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form DK_TeamBuilding = new DangKyTeamBuillding();
            DK_TeamBuilding.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form thongTinTrinhDoHV = new ThongTinTrinhDoHV();
            thongTinTrinhDoHV.Show();
        }
    }
}
