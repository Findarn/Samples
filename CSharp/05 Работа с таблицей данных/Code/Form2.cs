using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace C_3
{
    public partial class ModelForm : Form
    {
        MainForm reference;
        List<MarkCar> LMC;
        int index;
        public ModelForm(MainForm mf, object o)
        {
            InitializeComponent();
            reference = mf;
            index = 0;
            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.ReadOnly = true;
            DataGridViewTextBoxColumn dgvC0 = new DataGridViewTextBoxColumn();
            DGV.Columns.Add(dgvC0);
            dgvC0.HeaderText = "Марка";
            dgvC0.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvC0.HeaderCell.Style.Font = new Font("Consolas", 11);
            DataGridViewTextBoxColumn dgvC1 = new DataGridViewTextBoxColumn();
            DGV.Columns.Add(dgvC1);
            dgvC1.HeaderText = "Модель";
            dgvC1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvC1.HeaderCell.Style.Font = new Font("Consolas", 11);
            DataGridViewTextBoxColumn dgvC2 = new DataGridViewTextBoxColumn();
            DGV.Columns.Add(dgvC2);
            dgvC2.HeaderText = "Регистрационный номер";
            dgvC2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvC2.DefaultCellStyle.Font = new Font("Consolas", 10);
            dgvC2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvC2.HeaderCell.Style.Font = new Font("Consolas", 11);
            if (o is LightCar LC)
            {
                DataGridViewTextBoxColumn dgvC3 = new DataGridViewTextBoxColumn();
                DGV.Columns.Add(dgvC3);
                dgvC3.HeaderText = "Мультимедиа";
                dgvC3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                dgvC3.HeaderCell.Style.Font = new Font("Consolas", 11);
                DataGridViewTextBoxColumn dgvC4 = new DataGridViewTextBoxColumn();
                DGV.Columns.Add(dgvC4);
                dgvC4.HeaderText = "Подушки";
                dgvC4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                dgvC4.HeaderCell.Style.Font = new Font("Consolas", 11);                
                LMC = new List<MarkCar>();
                LMC = Loader.Load(LC);
            }
            if (o is CargoCar CC)
            {
                DataGridViewTextBoxColumn dgvC3 = new DataGridViewTextBoxColumn();
                DGV.Columns.Add(dgvC3);
                dgvC3.HeaderText = "Количество колес";
                dgvC3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                dgvC3.HeaderCell.Style.Font = new Font("Consolas", 11);
                DataGridViewTextBoxColumn dgvC4 = new DataGridViewTextBoxColumn();
                DGV.Columns.Add(dgvC4);
                dgvC4.HeaderText = "Объём кузова";
                dgvC4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                dgvC4.HeaderCell.Style.Font = new Font("Consolas", 11);                
                LMC = new List<MarkCar>();
                LMC = Loader.Load(CC);
            }
            PB.Minimum = 0;
            PB.Maximum = LMC.Count;
            TLoad.Start();
            
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            
        }

        private void TLoad_Tick(object sender, EventArgs e)
        {
            if (LMC != null)
            {
                Random R = new Random();
                if (index < LMC.Count)
                {
                    
                    if (LMC[index] is LightCar)
                    {
                        LightCar LC = LMC[index] as LightCar;
                        DGV.Rows.Add(LC.Mark, LC.Model, LC.Reg, LC.Multi, LC.Pillars);
                        TLoad.Interval = R.Next(1, 501);
                    }
                    if (LMC[index] is CargoCar)
                    {
                        CargoCar CC = LMC[index] as CargoCar;
                        DGV.Rows.Add(CC.Mark, CC.Model, CC.Reg, CC.NumOfC, CC.V);
                        TLoad.Interval = R.Next(1, 501);
                    }
                    index++;
                    PB.Value = index;
                }
                else
                    TLoad.Stop();
            }
        }
    }
}
