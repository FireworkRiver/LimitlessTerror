using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessTerror
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void VirtueEvil_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ThisBox = (CheckBox)sender;
            if (ThisBox.Checked)
            {
                ThisBox.ForeColor = Color.Black;
            }
            else
            {
                ThisBox.ForeColor = Color.Silver;
            }
        }
    }
}
