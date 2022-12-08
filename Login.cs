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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string User = txtUser.Text.ToString();
            string Pass = txtPass.Text.ToString();
            using (var QLNS = new QLNhanSuDVSXs())
            {
                using (var Transaction = QLNS.Database.BeginTransaction())
                {
                    try
                    {
                        // kiểm tra tài khoản đăng nhập có khớp với tài khoản đã cho trong bảng USERS hay không
                        var myUser = QLNS.USERS.Where(u => u.UserName.Equals(User)).Where(u => u.Pass.Equals(Pass)).SingleOrDefault();
                        if (myUser != null)
                        {
                            MenuQuanLyNhanSu qlns = new MenuQuanLyNhanSu();
                            qlns.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Đăng Nhập Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtUser.ResetText();
                            this.txtPass.ResetText();
                            this.txtUser.Focus();
                        }
                    }
                    catch (Exception ex)
                    {

                        Transaction.Rollback();
                        MessageBox.Show("Lỗi dữ liệu", ex.Message);
                    }
                }
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPass.Focus();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnDangNhap_Click(sender, e);
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            this.txtUser.Focus();
        }
    }
}
