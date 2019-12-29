using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceCryptoCHRJ
{
    public partial class FrmInputPassword : Form
    {
        public FrmInputPassword()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n') {
                DialogResult = DialogResult.OK;
            }
        }


        public static string Input(Form owner, String hint) {
            bool ownerToplevel = owner.TopMost;
            String password = "";
            FrmInputPassword form = new FrmInputPassword();
            form.Text = hint;
            if (form.ShowDialog(owner) == DialogResult.OK) {
                password = form.textBox1.Text;
            }
            owner.TopMost = ownerToplevel;
            return password;
        }

        public static string CreatePassword(Form owner) {
            string pw1 = "",pw2 = "";
            while (pw1 != pw2 || pw1.Length < 6) {
                while (pw1.Length < 6) {
                    pw1 = Input(owner,"请设定密码");
                    if (pw1.Length < 6) {
                        MessageBox.Show("密码长度不得少于6位");
                    }
                }
                while (pw2.Length < 6)
                {
                    pw2 = Input(owner, "请再次输入密码");
                    if (pw2.Length < 6)
                    {
                        MessageBox.Show("密码长度不得少于6位");
                    }
                }
                if (pw1 != pw2) {
                    MessageBox.Show("两次密码不一致");
                    pw1 = "";pw2 = "";
                }
            }
            return pw1;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
