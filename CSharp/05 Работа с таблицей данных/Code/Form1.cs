using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace C_3
{
    public partial class MainForm : Form
    {
        List<MarkCar> Marks;        
        BindingSource BSMarks;
        List<string> types;
        Color ForLight;
        Color ForCargo;
        MarkCar oldCar;
        ToolStripLabel TSL;
        bool isValidation;
        public MainForm()
        {
            InitializeComponent();            
            oldCar = new MarkCar();
            ForLight = Color.FromArgb(222, 184, 135);
            ForCargo = Color.FromArgb(128, 128, 128);
            Marks = new List<MarkCar>();
            types = new List<string> {"Легковая", "Грузовая"};            
            
            BSMarks = new BindingSource();
            BSMarks.DataSource = Marks;
            // отключаем автоматическую генерацию столбцов
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = BSMarks;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            // 1 столбец - марка
            DataGridViewTextBoxColumn dgvC0 = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(dgvC0);            
            dgvC0.DataPropertyName = "Mark";
            dgvC0.HeaderText = "Марка";
            dgvC0.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvC0.HeaderCell.Style.Font = new Font("Consolas", 12);
            // 2 столбец - модель
            DataGridViewTextBoxColumn dgvC1 = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(dgvC1);            
            dgvC1.DataPropertyName = "Model";
            dgvC1.HeaderText = "Модель";
            dgvC1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvC1.HeaderCell.Style.Font = new Font("Consolas", 12);
            // 3 столбец - мощность
            DataGridViewTextBoxColumn dgvC2 = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(dgvC2);
            dgvC2.DataPropertyName = "Power";
            dgvC2.HeaderText = "Мощность";
            dgvC2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvC2.HeaderCell.Style.Font = new Font("Consolas", 12);
            // 4 столбец - скорость
            DataGridViewTextBoxColumn dgvC3 = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(dgvC3);
            dgvC3.DataPropertyName = "MaxSpeed";
            dgvC3.HeaderText = "Максимальная скорость";
            dgvC3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvC3.HeaderCell.Style.Font = new Font("Consolas", 12);
            // 5 столбец - тип
            DataGridViewComboBoxColumn dgvC4 = new DataGridViewComboBoxColumn();
            dataGridView1.Columns.Add(dgvC4);
            dgvC4.DataSource = types;
            dgvC4.DataPropertyName = "Type";
            dgvC4.HeaderText = "Тип машины";
            dgvC4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvC4.HeaderCell.Style.Font = new Font("Consolas", 12);
            // метка в меню
            TSL = new ToolStripLabel("Не заданы некоторые модели в таблице!");
            TSL.Font = new Font("Consolas", 9);    TSL.ForeColor = Color.Red;
            TSL.Visible = false;
            Size s = TextRenderer.MeasureText("Не заданы некоторые модели в таблице!", new Font("Consolas", 9));
            TSL.Margin = new Padding(this.Width-s.Width-menuStrip1.Items[0].Width-25, 3, 3, 3);
            menuStrip1.Items.Add(TSL);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.CurrentCell = null;
            isValidation = false;            
        }
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if ((string)dataGridView1.Rows[e.RowIndex].Cells[4].Value == types[0])
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = ForLight;
            }
            if ((string)dataGridView1.Rows[e.RowIndex].Cells[4].Value == types[1])
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = ForCargo;
            }
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldCar.CopyFrom(Marks[e.RowIndex]); 
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            isValidation = false;            
            switch (e.ColumnIndex)
            {
                case 0:
                    {
                        Marks[e.RowIndex].Mark = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    break;
                case 1:
                    {
                        int rep = 0;
                        foreach (MarkCar mc in Marks)
                        {
                            if (mc.Model == dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString())
                            {
                                rep++;                                
                            }
                        }
                        if (rep > 1)
                        {
                            MessageBox.Show("Такая модель уже записана!");
                            dataGridView1.Rows[e.RowIndex].Cells[1].Value = oldCar.Model;
                            return;
                        }
                        else
                        {
                            Marks[e.RowIndex].Model = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        }
                    }
                    break;
                case 2:
                    {
                        int buf1 = 0;
                        if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), out buf1))
                        {
                            MessageBox.Show("Неверно задана мощность в строке " + e.RowIndex, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = Marks[e.RowIndex].Power;
                            return;
                        }
                        else
                        {
                            Marks[e.RowIndex].Power = buf1;
                        }
                    }
                    break;
                case 3:
                    {
                        double buf2 = 0;
                        if (!double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), out buf2))
                        {
                            MessageBox.Show("Неверно задана макс. скорость в строке " + e.RowIndex, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridView1.Rows[e.RowIndex].Cells[3].Value = Marks[e.RowIndex].MaxSpeed;
                            return;
                        }
                        else
                        {
                            Marks[e.RowIndex].MaxSpeed = buf2;
                        }
                    }
                    break;
                case 4:
                    {
                        if (oldCar.Type != (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value)
                        {
                            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == types[0])
                            {
                                Marks[e.RowIndex] = new LightCar();
                                Marks[e.RowIndex].Type = types[0];
                                dataGridView1.Rows[e.RowIndex].ReadOnly = false;
                            }
                            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == types[1])
                            {
                                Marks[e.RowIndex] = new CargoCar();
                                Marks[e.RowIndex].Type = types[1];
                                dataGridView1.Rows[e.RowIndex].ReadOnly = false;
                            }
                        }
                        oldCar.Clear();
                    }
                    break;
            }
            dataGridView1.Rows[e.RowIndex].ErrorText = "";
            TSL.Visible = false;
            if (добавлениеToolStripMenuItem.Checked)
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].ReadOnly = true;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].ReadOnly = false;
            }
            foreach(MarkCar mc in Marks)
            {
                if (mc.Mark == "Не задана" || mc.Model == "Не задана" || mc.Power == 0 || mc.MaxSpeed == 0 || mc.Power == -1 || mc.MaxSpeed == -1)
                {
                    TSL.Visible = true;
                    return;
                }
            }
        }
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            Size s = TextRenderer.MeasureText("Не заданы некоторые модели в таблице!", new Font("Consolas", 10));
            TSL.Margin = new Padding(this.Width - s.Width - menuStrip1.Items[0].Width - 0, 3, 3, 3);
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            isValidation = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
            {
                isValidation = false;
                return;
            }
            switch (e.ColumnIndex)
            {
                case 0:
                    {
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            dataGridView1.Rows[e.RowIndex].ErrorText = "Марка должна быть указана!";
                            e.Cancel = true;
                        }
                    } break;
                case 1:
                    {
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            dataGridView1.Rows[e.RowIndex].ErrorText = "Модель должна быть указана!";
                            e.Cancel = true;
                        }
                    } break;
                case 2:
                    {
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            dataGridView1.Rows[e.RowIndex].ErrorText = "Максимальная скорость должна быть указана!";
                            e.Cancel = true;
                        }
                        int buf1;
                        if (!int.TryParse(e.FormattedValue.ToString(),out buf1))
                        {
                            dataGridView1.Rows[e.RowIndex].ErrorText = "Максимальная скорость задается целыми числами!";
                            e.Cancel = true;
                        }
                    } break;
                case 3:
                    {
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            dataGridView1.Rows[e.RowIndex].ErrorText = "Мощность должна быть указана!";
                            e.Cancel = true;
                        }
                        double buf2;
                        if (!double.TryParse(e.FormattedValue.ToString(), out buf2))
                        {
                            dataGridView1.Rows[e.RowIndex].ErrorText = "Мощность задается дробными числами!";
                            e.Cancel = true;
                        }
                    } break;
            }    
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SFD = new SaveFileDialog())
            {
                SFD.InitialDirectory = Application.StartupPath;
                SFD.Filter = "XML-файл|*.xml";
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer XS = new XmlSerializer(typeof(List<MarkCar>), new Type[] { typeof(LightCar), typeof(CargoCar) });
                    try
                    {
                        using (FileStream FS = new FileStream(SFD.FileName, FileMode.Truncate))
                        {                            
                                XS.Serialize(FS, Marks);                         
                            
                        }
                    }
                    catch
                    {
                        using (FileStream FSC = new FileStream(SFD.FileName, FileMode.Create))
                        { 
                            XS.Serialize(FSC, Marks);
                        }
                    }            
                }
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == -1)    // клик по выделению ряда
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip CMS = new ContextMenuStrip();
                    ToolStripMenuItem TSMI = new ToolStripMenuItem("Удалить элемент");
                    CMS.Items.Add(TSMI);
                    Point ShowPoint = new Point(this.Location.X, this.Location.Y);
                    ShowPoint.X = ShowPoint.X + dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location.X + e.Location.X;
                    ShowPoint.Y = ShowPoint.Y + dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location.Y + e.Location.Y+45;
                    TSMI.Tag = e.RowIndex;
                    TSMI.Click += new System.EventHandler(this.TSMI_Click);
                    CMS.Show(ShowPoint);                    
                }
            }
        }
        private void TSMI_Click(object sender, EventArgs e)
        {
            if (!isValidation)
            {
                int index = (int)((ToolStripMenuItem)sender).Tag;
                Marks.RemoveAt(index);
                BSMarks.DataSource = Marks;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = BSMarks;
                dataGridView1.Refresh();
                
            }
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == -1)    // клик по выделению ряда
            {
                MarkCar mc = dataGridView1.Rows[e.RowIndex].DataBoundItem as MarkCar;
                if (mc.Mark == "Не задана" || mc.Model == "Не задана" || mc.Power == 0 || mc.MaxSpeed == 0 || mc.Power == -1 || mc.MaxSpeed == -1)
                {
                    MessageBox.Show("Невозможно получить список автомобилей для незаданной марки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                
                if (e.Button == MouseButtons.Left)
                {
                    ModelForm mf = new ModelForm(this, dataGridView1.Rows[e.RowIndex].DataBoundItem);
                    mf.Text = mc.Mark + ' ' + mc.Model;
                    mf.Show();
                }
            }
        }
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.InitialDirectory = Application.StartupPath;
                OFD.Filter = "XML-файл|*.xml";
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer XS = new XmlSerializer(typeof(List<MarkCar>), new Type[] { typeof(LightCar), typeof(CargoCar) });
                    using (FileStream FS = new FileStream(OFD.FileName, FileMode.OpenOrCreate))
                    {
                        Marks = XS.Deserialize(FS) as List<MarkCar>;
                    }
                    BSMarks.DataSource = Marks;
                    dataGridView1.CurrentCell = null;
                }
            }
                   

        }
        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!добавлениеToolStripMenuItem.Checked)
            {
                добавлениеToolStripMenuItem.Checked = true;
                редактированиеToolStripMenuItem.Checked = true;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.ReadOnly = false;
                dataGridView1.CurrentCell = null;
                dataGridView1.Rows[dataGridView1.Rows.Count-1].ReadOnly = true;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].ReadOnly = false;
            }
            else
            {
                добавлениеToolStripMenuItem.Checked = false;
                dataGridView1.AllowUserToAddRows = false;
                for (int i = 0; i < Marks.Count; i++)
                {
                    if (Marks[i].Mark == "Не задана" || Marks[i].Model == "Не задана" || Marks[i].Power == 0 ||
                        Marks[i].MaxSpeed == 0 || Marks[i].Power == -1 || Marks[i].MaxSpeed == -1)
                    {
                        Marks.RemoveAt(i);  // удаляем не заданную модель                        
                        return;
                    }
                }
            }
        }
        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!редактированиеToolStripMenuItem.Checked)
            {
                редактированиеToolStripMenuItem.Checked = true;
                dataGridView1.ReadOnly = false;
            }
            else
            {
                редактированиеToolStripMenuItem.Checked = false;
                dataGridView1.ReadOnly = true;
            }
        }
    }
}
