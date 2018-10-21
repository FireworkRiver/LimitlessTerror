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

        private void AddNewSpeciality(string SpecialityName, string SpecialityMessage)
        {
            int index = SpecialityGrid.Rows.Add();
            SpecialityGrid.Rows[index].Cells[0].Value = SpecialityName;
            SpecialityGrid.Rows[index].Cells[1].Value = SpecialityMessage;
        }
        private void AddSpeciality_Click(object sender, EventArgs e)
        {

            if (SpecialityNameText.Text=="")
            {
                SpecialityError.Visible = true;
                SpecialityErrorText.Text = "请输入专长名。";
                return;
            }
            for (int i = 0; i < SpecialityGrid.Rows.Count ; i++)
            {
                if (SpecialityGrid.Rows[i].Cells[0].Value.ToString() == SpecialityNameText.Text.Trim())
                {
                    SpecialityError.Visible = true;
                    SpecialityErrorText.Text = "请不要重复输入。";
                    return;
                }

            }
            AddNewSpeciality(SpecialityNameText.Text.Trim(), SpecialityDescriptionText.Text);
        }

        private void SpecialityErrorConfirm_Click(object sender, EventArgs e)
        {
            SpecialityError.Visible = false;
        }

        private void DeleteSpeciality_Click(object sender, EventArgs e)
        {
            if (SpecialityNameText.Text == "")
            {
                SpecialityError.Visible = true;
                SpecialityErrorText.Text = "请输入专长名。";
                return;
            }
            foreach(DataGridViewRow row in SpecialityGrid.Rows)
            {
                if(row.Cells[0].Value.ToString()== SpecialityNameText.Text.Trim())
                {
                    SpecialityGrid.Rows.Remove(row);
                }
            }
        }
    }
}
