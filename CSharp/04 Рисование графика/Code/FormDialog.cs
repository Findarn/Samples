using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task2
{
    public partial class FormDialog : Form
    {
        MainForm MF;
        FonState fs;
        public FormDialog(MainForm mf)
        {
            InitializeComponent();
            MF = mf;
            pbFonColor.BackColor = Color.Empty;
            pbStartGrad.BackColor = Color.Empty;
            pbEndGrad.BackColor = Color.Empty;
            fs = new FonState();
            fs.CopyFrom(MF.FonGrafic);
            SetWindowControls();
        }

        private void SetWindowControls()
        {
            if (!fs.gradient)
            {
                pbFonColor.BackColor = fs.MainColor;
                cbGradient.Checked = false;
                pbStartGrad.BackColor = Color.Empty;
                pbEndGrad.BackColor = Color.Empty;                
            }
            else
            {
                pbFonColor.BackColor = Color.Empty;
                cbGradient.Checked = true;
                pbStartGrad.BackColor = fs.StartGradient;
                pbEndGrad.BackColor = fs.EndGradiend;                
            }
            rbDirHor.Checked = !fs.gradient_direct;
            rbDirVer.Checked = fs.gradient_direct;
            if (!fs.grid)
            {
                cbGrid.Checked = false;
                pbColorGrid.BackColor = Color.Empty;
                tbGridSize.Text = "0";
            }
            else
            {
                cbGrid.Checked = true;
                pbColorGrid.BackColor = fs.ColorGrid;
                tbGridSize.Text = fs.step_grid.ToString();
            }
            if (!fs.streak)
            {
                cbStreak.Checked = false;
                tbStreakSize.Text = "0";
                cbStreakText.Checked = false;
            }
            else
            {
                cbStreak.Checked = true;
                tbStreakSize.Text = fs.step_streak.ToString();
                if (fs.streak_note)
                    cbStreakText.Checked = true;
                else
                    cbStreakText.Checked = false;
            }
            if (fs.axis_note)
                cbAxisText.Checked = true;
            else
                cbAxisText.Checked = false;
            nudFont.Value = fs.font_size;
        }

        private void pbFonColor_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            if (CD.ShowDialog() == DialogResult.OK)
                pbFonColor.BackColor = CD.Color;
        }

        private void cbGradient_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGradient.Checked)
            {
                lStartGrad.Visible = true;
                lEndGrad.Visible = true;
                pbStartGrad.Visible = true;
                pbEndGrad.Visible = true;
                lGradDir.Visible = true;
                rbDirHor.Visible = true;
                rbDirVer.Visible = true;
            }
            else
            {
                lStartGrad.Visible = false;
                lEndGrad.Visible = false;
                pbStartGrad.Visible = false;
                pbEndGrad.Visible = false;
                lGradDir.Visible = false;
                rbDirHor.Visible = false;
                rbDirVer.Visible = false;
            }
        }

        private void pbStartGrad_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            if (CD.ShowDialog() == DialogResult.OK)
                pbStartGrad.BackColor = CD.Color;
        }

        private void pbEndGrad_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            if (CD.ShowDialog() == DialogResult.OK)
                pbEndGrad.BackColor = CD.Color;
        }

        private void cbGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGrid.Checked)
            {
                lColorGrid.Visible = true;
                pbColorGrid.Visible = true;
                lGridSize.Visible = true;
                tbGridSize.Visible = true;
            }
            else
            {
                lColorGrid.Visible = false;
                pbColorGrid.Visible = false;
                lGridSize.Visible = false;
                tbGridSize.Visible = false;
            }
        }

        private void cbStreak_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStreak.Checked)
            {
                lStreakSize.Visible = true;                
                tbStreakSize.Visible = true;
                cbStreakText.Visible = true;
            }
            else
            {
                lStreakSize.Visible = false;
                tbStreakSize.Visible = false;
                cbStreakText.Visible = false;
            }
        }

        private void pbColorGrid_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            if (CD.ShowDialog() == DialogResult.OK)
                pbColorGrid.BackColor = CD.Color;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            fs = new FonState();    // новый экземпляр фона
            // фоновый цвет - матовый или градиент
            if (cbGradient.Checked)
            {
                if (pbStartGrad.BackColor == Color.Empty)
                {
                    MessageBox.Show("Не задан начальный цвет градиента!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (pbEndGrad.BackColor == Color.Empty)
                {
                    MessageBox.Show("Не задан конечный цвет градиента!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                fs.MainColor = Color.Empty;
                fs.gradient = true;                
                fs.StartGradient = pbStartGrad.BackColor;
                fs.EndGradiend = pbEndGrad.BackColor;
                if (rbDirHor.Checked)
                    fs.gradient_direct = false;
                if (rbDirVer.Checked)
                    fs.gradient_direct = true;
            }
            else
            {
                if (pbFonColor.BackColor == Color.Empty)
                {
                    MessageBox.Show("Не задан фоновый цвет!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                fs.MainColor = pbFonColor.BackColor;
                fs.gradient = false;
                fs.gradient_direct = false;
                fs.StartGradient = Color.Empty;
                fs.EndGradiend = Color.Empty;
            }
            // отображение сетки
            if (cbGrid.Checked)
            {
                fs.grid = true;
                fs.ColorGrid = pbColorGrid.BackColor;
                float sg;
                if (float.TryParse(tbGridSize.Text, out sg))
                {
                    if (sg <= 0)
                    {
                        MessageBox.Show("Размер сетки должен быть больше нуля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    fs.step_grid = sg;
                }
                else
                {
                    MessageBox.Show("Неверное значение размера сетки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                
            }
            else
            {
                fs.grid = false;
                fs.ColorGrid = Color.Empty;
                fs.step_grid = 0;
            }
            // отображение штриховки
            if(cbStreak.Checked)
            {
                fs.streak = true;
                float sst;
                if (float.TryParse(tbStreakSize.Text, out sst))
                {
                    if (sst <= 0)
                    {
                        MessageBox.Show("Размер штриховки должен быть больше нуля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    fs.step_streak = sst;
                }
                else
                {
                    MessageBox.Show("Неверное значение размера штриховки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cbStreakText.Checked)
                    fs.streak_note = true;
                else
                    fs.streak_note = false;
            }
            else
            {
                fs.streak = false;
                fs.step_streak = 0;
                fs.streak_note = false;
            }
            // подпись осей
            if (cbAxisText.Checked)
                fs.axis_note = true;
            else
                fs.axis_note = false;
            // размер шрифта
            int fo_s;
            if (Int32.TryParse(nudFont.Value.ToString(), out fo_s))
            {
                if (fo_s <= 0)
                {
                    MessageBox.Show("Размер шрифта должен быть больше нуля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                fs.font_size = fo_s;
            }
            else
            {
                MessageBox.Show("Неверное значение размера шрифта!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MF.FonGrafic.CopyFrom(fs); this.DialogResult = DialogResult.OK; this.Close();
        }
    }
}
