using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TQL;

namespace FinanceCryptoCHRJ
{
    public partial class FrmEdit : Form
    {
        
        string savepassword = "";
        public FrmEdit(string password)
        {
            InitializeComponent();
            savepassword = password;
        }

        private void chkPy_CheckedChanged(object sender, EventArgs e)
        {
            tblList.Columns[1].Visible = chkPy.Checked;
        }

        Form1.AppSettings appSettingObject;

        private void FrmEdit_Load(object sender, EventArgs e)
        {
            appSettingObject = JsonConvert.DeserializeObject<Form1.AppSettings>(Form1.cryptor.getData());
            loadComboBox();

            loadSubPass();
            
        }

        void loadSubPass() {
            lblSubpassCount.Text = $"当前共有{appSettingObject.subpasswords.Count}个子密码";
        }

        void loadComboBox() {
            cmbSelection.SelectedIndexChanged -= cmbSelection_SelectedIndexChanged;
            BindingSource bs = new BindingSource();
            Dictionary<int, string> list = new Dictionary<int, string>();
            for (int i = 0; i < appSettingObject.nameListCollections.Count; i++)
            {
                list.Add(i, "["+(i+1)+"] "+appSettingObject.nameListCollections[i].name);
            }
            bs.DataSource = list;
            cmbSelection.DataSource = bs;
            cmbSelection.DisplayMember = "Value";
            cmbSelection.ValueMember = "Key";
            cmbSelection.SelectedIndexChanged += cmbSelection_SelectedIndexChanged;
            cmbSelection_SelectedIndexChanged(null, null);
        }

        private void cmbSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.NameItemCollecton editingobject = appSettingObject.nameListCollections[(int)cmbSelection.SelectedValue];
            txtTitle.Text = editingobject.name;
            tblList.Rows.Clear();
            editingobject.items.ForEach(i => tblList.Rows.Add(i.name, i.isDisabled));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Form1.NameItemCollecton editingobject = appSettingObject.nameListCollections[(int)cmbSelection.SelectedValue];
            editingobject.name = txtTitle.Text;
            editingobject.items.Clear();
            for (int i = 0; i < tblList.RowCount-1; i++) {
                editingobject.items.Add(new Form1.NameItem(tblList.Rows[i].Cells[0].Value.ToString(), tblList.Rows[i].Cells[1].Value.ToString().ToUpper().Contains("TRUE")));
            }
            MessageBox.Show("保存成功");
            chkPy.Checked = false;
        }

        private void btnBatchAdd_Click(object sender, EventArgs e)
        {
            FrmAddTask frm = new FrmAddTask();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                String[] tasks = frm.textBox1.Lines;
                foreach (string task in tasks)
                {
                    string t = task.Trim();
                    if (t.Length > 0)
                    {
                        tblList.Rows.Add(t, false);
                    }
                }
            }
        }

        private void FrmEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.cryptor.setData(JsonConvert.SerializeObject(appSettingObject), savepassword);
        }

        private void btnNewSubpass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("添加子密码后，通过子密码可以修改名单。");
            if (Form1.cryptor.verifyPassword(FrmInputPassword.Input(this, "请输入主密码")))
            {
                string subpass = FrmInputPassword.CreatePassword(this);
                appSettingObject.subpasswords.Add(FinanceCrypto.CryptoHelper.AesEncrypt("MAINPASS" + FinanceCrypto.CryptoObject.randomMask() + savepassword, subpass));
            }
            else {
                MessageBox.Show("主密码错误");
            }
            loadSubPass();
        }

        private void btnClearSubpass_Click(object sender, EventArgs e)
        {
            if (Form1.cryptor.verifyPassword(FrmInputPassword.Input(this, "请输入主密码确认操作")))
            {
                appSettingObject.subpasswords.Clear();
            }
            else
            {
                MessageBox.Show("主密码错误");
            }
            loadSubPass();
        }

        private void btnTestSubpass_Click(object sender, EventArgs e)
        {
            if (testSubPassword(FrmInputPassword.Input(this, "请输入其中一个子密码")) != "")
            {
                MessageBox.Show("子密码认证成功");
            }
            else {
                MessageBox.Show("子密码错误或不存在");
            }
        }

        string testSubPassword(string password)
        {
            foreach (string subp in appSettingObject.subpasswords)
            {
                try
                {
                    string mainpass = FinanceCrypto.CryptoHelper.AesDecrypt(subp, password);
                    if (mainpass.StartsWith("MAINPASS"))
                    {
                        return mainpass.Substring(24);
                    }
                }
                catch (Exception ex) { }
            }
            return "";
        }
    }
}
