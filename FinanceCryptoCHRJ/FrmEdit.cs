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

        private void FrmEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
