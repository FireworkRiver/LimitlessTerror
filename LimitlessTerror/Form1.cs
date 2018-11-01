using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LimitlessTerror {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            AttributesGrids_Load();
            Skill_Load();
        }

        private void VirtueEvil_CheckedChanged(object sender, EventArgs e) {
            CheckBox ThisBox = (CheckBox)sender;
            if (ThisBox.Checked) {
                ThisBox.ForeColor = Color.Black;
            } else {
                ThisBox.ForeColor = Color.Silver;
            }
        }

        private void AddNewSpeciality(string SpecialityName, string SpecialityMessage) {
            int index = SpecialityGrid.Rows.Add();
            SpecialityGrid.Rows[index].Cells[0].Value = SpecialityName;
            SpecialityGrid.Rows[index].Cells[1].Value = SpecialityMessage;
        }
        private void AddSpeciality_Click(object sender, EventArgs e) {

            if (SpecialityNameText.Text == "") {
                SpecialityError.Visible = true;
                SpecialityErrorText.Text = "请输入专长名。";
                return;
            }
            for (int i = 0; i < SpecialityGrid.Rows.Count; i++) {
                if (SpecialityGrid.Rows[i].Cells[0].Value.ToString() == SpecialityNameText.Text.Trim()) {
                    SpecialityError.Visible = true;
                    SpecialityErrorText.Text = "请不要重复输入。";
                    return;
                }

            }
            AddNewSpeciality(SpecialityNameText.Text.Trim(), SpecialityDescriptionText.Text);
        }

        private void ErrorConfirm_Click(object sender, EventArgs e) {
            Button ConfirmButton = (Button)sender;
            ConfirmButton.Parent.Visible = false;
        }

        private void DeleteSpeciality_Click(object sender, EventArgs e) {
            if (SpecialityNameText.Text == "") {
                SpecialityError.Visible = true;
                SpecialityErrorText.Text = "请输入专长名。";
                return;
            }
            foreach (DataGridViewRow row in SpecialityGrid.Rows) {
                if (row.Cells[0].Value.ToString() == SpecialityNameText.Text.Trim()) {
                    SpecialityGrid.Rows.Remove(row);
                }
            }
        }
        private void AddNewTypeOfAttributes(string TypeName, int DefaultValue) {
            int index = AttributesGrids.Rows.Add();
            AttributesGrids.Rows[index].Cells[0].Value = TypeName;
            for (int i = 1; i <= 9; i++) {
                AttributesGrids.Rows[index].Cells[i].Value = DefaultValue;
            }
        }
        private void AddAttributesType_Click(object sender, EventArgs e) {
            if (AttributesTypeText.Text == "") {
                AttributesTypeError.Visible = true;
                AttributesTypeErrorText.Text = "请输入属性名。";
                return;
            }
            for (int i = 0; i < AttributesGrids.Rows.Count; i++) {
                if (AttributesGrids.Rows[i].Cells[0].Value.ToString() == AttributesTypeText.Text.Trim()) {
                    AttributesTypeError.Visible = true;
                    AttributesTypeErrorText.Text = "请不要重复输入。";
                    return;
                }
            }
            AddNewTypeOfAttributes(AttributesTypeText.Text, 0);
        }

        private void DeleteAttributeType_Click(object sender, EventArgs e) {
            if (AttributesTypeText.Text == "") {
                AttributesTypeError.Visible = true;
                AttributesTypeErrorText.Text = "请输入属性名。";
                return;
            }

            foreach (DataGridViewRow row in AttributesGrids.Rows) {
                if (row.Cells[0].Value.ToString() == AttributesTypeText.Text.Trim()) {
                    AttributesGrids.Rows.Remove(row);
                }
            }
        }
        private void SumAttributesGrids_Load() {
            if (SumAttributeGrids.Rows.Count == 0) {
                int index = SumAttributeGrids.Rows.Add();
                SumAttributeGrids.Rows[index].Cells[0].Value = "总和";
                for (int i = 1; i <= 9; i++) {
                    SumAttributeGrids.Rows[index].Cells[i].Value = 1;
                }
            }
            if (SumAttributeGrids.Rows.Count == 1) {
                int index = SumAttributeGrids.Rows.Add();
                SumAttributeGrids.Rows[index].Cells[0].Value = "传奇";
                for (int i = 1; i <= 9; i++) {
                    SumAttributeGrids.Rows[index].Cells[i].Value = 0;
                }
            }
        }
        private void AttributesGrids_Load() {
            SumAttributesGrids_Load();
            AddNewTypeOfAttributes("基础", 1);
            AddNewTypeOfAttributes("内在", 0);
            AddNewTypeOfAttributes("增强", 0);
            AddNewTypeOfAttributes("修行", 0);
        }

        private void AttributesGride_ValueChange(int i) {
            int sum = 0;
            foreach (DataGridViewRow row in AttributesGrids.Rows) {
                sum += int.Parse(row.Cells[i].Value.ToString());
            }
            SumAttributeGrids.Rows[0].Cells[i].Value = sum;
            SumAttributeGrids.Rows[1].Cells[i].Value = (sum - 1) / 5;
        }

        private void AttributesGrids_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            for (int i = 1; i <= 9; i++) {
                AttributesGride_ValueChange(i);
            }
        }

        private void AttributesGrids_RowsChanged(object sender, DataGridViewRowsAddedEventArgs e) {
            for (int i = 1; i <= 9; i++) {
                AttributesGride_ValueChange(i);
            }
        }

        private void AttributesGrids_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) {
            for (int i = 1; i <= 9; i++) {
                AttributesGride_ValueChange(i);
            }
        }


        private void AddSkill(string Text) {
            int index = SkillGridView.Rows.Add();
            SkillGridView.Rows[index].Cells[0].Value = Text;
            SkillGridView.Rows[index].Cells[1].Value = '0';
        }
        private void Skill_Load() {
            string[] SkillList = new string[] { "学识","电脑", "调查", "医学", "神秘学", "科学",
                                                "运动", "肉搏" , "驾驶", "枪械", "隐藏", "求生" , "白刃" , "弓箭" ,
                                                "动物沟通", "感受","胁迫","交际","掩饰"};
            foreach (string skill in SkillList) {
                AddSkill(skill);
            }
        }
        private void AddNewSkill_Click(object sender, EventArgs e) {
            if (NewSkillText.Text == "") {
                SkillError.Visible = true;
                SkillErrorText.Text = "请输入技能名。";
                return;
            }
            for (int i = 0; i < SkillGridView.Rows.Count; i++) {
                if (SkillGridView.Rows[i].Cells[0].Value.ToString() == NewSkillText.Text.Trim()) {
                    SkillError.Visible = true;
                    SkillErrorText.Text = "请不要重复输入。";
                    return;
                }
            }
            AddSkill(NewSkillText.Text);
        }

        private void DeletSkill_Click(object sender, EventArgs e) {
            if (NewSkillText.Text == "") {
                SkillError.Visible = true;
                SkillErrorText.Text = "请输入技能名。";
                return;
            }
            foreach (DataGridViewRow row in SkillGridView.Rows) {
                if (row.Cells[0].Value.ToString() == NewSkillText.Text.Trim()) {
                    SkillGridView.Rows.Remove(row);
                }
            }
        }

        private void OpenPicture_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                string ImgPath = openFileDialog1.FileName;
                AppearancePicture.ImageLocation = ImgPath;
            }
        }
        private string GetLog() {
            Txt Content = new Txt();
            //基础信息
            Content.Head(UserName.Text, 0, false);
            Content.AddDetail(NameBox.Text, true);
            Content.Head(Age.Text, 0, false);
            Content.AddDetail(AgeBox.Text, true);
            Content.Head(Sex.Text, 0, false);
            Content.AddDetail(SexBox.Text, true);
            Content.Head(RaceAndNationality.Text, 0, false);
            Content.AddDetail(RaceAndNationalityBox.Text, true);
            Content.Head(HeightAndWeight.Text, 0, false);
            Content.AddDetail(HeightAndWeightText.Text, true);
            Content.Head(Language.Text, 0, false);
            Content.AddDetail(LanguageBox.Text, true);
            Content.Head(VirtueEvil.Text, 0, false);
            foreach (CheckBox box in VirtueEvil.Controls) {
                if (box.Checked) {
                    Content.AddDetail(box.Text, false);
                }
            }
            Content.AddDetail("", true);
            Content.Head(Appearance.Text, 0, false);
            Content.AddDetail(ApperenceDicscriptionText.Text, true);
            Content.Head(Backgroud.Text, 0, false);
            Content.AddDetail(BackgroundText.Text, true);
            Content.AddDetail("", true);
            //专长项
            Content.Head("专长:", 0, true);
            foreach (DataGridViewRow row in SpecialityGrid.Rows) {
                Content.Head(row.Cells[0].Value + ":", 0, false);
                Content.AddDetail(row.Cells[1].Value.ToString(), true);
            }

            //属性
            Content.Head("属性:", 4, true);
            for (int i = 1; i <= 9; i++) {
                Content.Head(AttributesGrids.Columns[i].HeaderText + "=", 1, false);
                Content.Value_add(AttributesGrids.Rows[0].Cells[0].Value.ToString(), AttributesGrids.Rows[0].Cells[i].Value.ToString());
                for (int j = 1; j < AttributesGrids.Rows.Count; j++) {
                    Content.AddDetail("+", false);
                    Content.Value_add(AttributesGrids.Rows[j].Cells[0].Value.ToString(), AttributesGrids.Rows[j].Cells[i].Value.ToString());
                }
                Content.AddDetail("=", false);
                Content.AddDetail(SumAttributeGrids.Rows[0].Cells[i].Value.ToString(), false);
                Content.Value_add(SumAttributeGrids.Rows[1].Cells[0].Value.ToString(), SumAttributeGrids.Rows[1].Cells[i].Value.ToString());
                Content.AddDetail("", true);
                Content.AddDetail("", true);
            }
            Content.AddDetail("", true);

            //技能
            Content.Head("技能:", 4, true);
            foreach (DataGridViewRow row in SkillGridView.Rows) {
                Content.Head(row.Cells[0].Value + ":", 1, false);
                Content.AddDetail(row.Cells[1].Value.ToString(), false);
                Content.AddDetail("\t专业：", false);
                if (row.Cells[2].Value != null) {
                    Content.AddDetail(row.Cells[2].Value.ToString(), false);
                }
                Content.AddDetail("", true);
                Content.AddDetail("", true);
            }
            return Content.GetResult();

        }
        private void Export_Click(object sender, EventArgs e) {
            string Log = GetLog();
            openFileDialog1.Filter = "*txt|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                string Path = openFileDialog1.FileName;
                FileStream fs = new FileStream(Path, FileMode.Create, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(Log);
                sr.Close();
                fs.Close();
            }
        }

    }
}
