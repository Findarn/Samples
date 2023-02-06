using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warships;

namespace Warships
{
    public partial class ConstructorForm : Form
    {
        MainForm reference;
        Fleet F = new Fleet();
        Square[,] FieldBuf = new Square[10, 10];
        List<Point> Engaged = new List<Point>();
        List<Point> Neighbour = new List<Point>();
        public ConstructorForm(MainForm mf)
        {
            InitializeComponent();
            reference = mf;
            Field.Controls.Clear();
            Field.RowCount = 10;
            Field.ColumnCount = 10;
            Field.RowStyles.Clear();
            for (int i = 0; i < Field.RowCount; i++)                //обходим все ряды
            {
                Field.RowStyles.Add(new RowStyle());                //создаём новый стиль ряда
                Field.RowStyles[i].SizeType = SizeType.Absolute;    //определяем единицы измерения размеров - абсолютные
                Field.RowStyles[i].Height = 30;              //высоту строки задаём размером стороны
            }
            Field.ColumnStyles.Clear();
            for (int i = 0; i < Field.ColumnCount; i++)                //обходим все ряды
            {
                Field.ColumnStyles.Add(new ColumnStyle());               //создаём новый стиль ряда
                Field.ColumnStyles[i].SizeType = SizeType.Absolute;      //определяем единицы измерения размеров - абсолютные
                Field.ColumnStyles[i].Width = 30;                        //высоту строки задаём размером стороны
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    FieldBuf[i, j] = new Square(i, j, this);                    
                    Field.Controls.Add(FieldBuf[i, j].WSPB, j, i);
                }
            }

            switch (reference.NumOfF2)
            {
                case 0:
                    TBLinN.Text = "Бородино";
                    TBFrigN1.Text = "Петербург";
                    TBFrigN2.Text = "Святой Пётр";
                    TBCorN1.Text = "Гремящий";
                    TBCorN2.Text = "Воевода";
                    TBCorN3.Text = "Варяг";
                    TBKatN1.Text = "Буян";
                    TBKatN2.Text = "Страж";
                    TBKatN3.Text = "Змея";
                    TBKatN4.Text = "Барсук";
                    LabelName.Text = "Имя игрока 1:";
                    break;
                case 1:
                    TBLinN.Text = "Королевская удача";
                    TBFrigN1.Text = "Месть королевы Анны";
                    TBFrigN2.Text = "Бродяга";
                    TBCorN1.Text = "Аквила";
                    TBCorN2.Text = "Галка";
                    TBCorN3.Text = "Морриган";
                    TBKatN1.Text = "Бенджамин";
                    TBKatN2.Text = "Месть";
                    TBKatN3.Text = "Принц";
                    TBKatN4.Text = "Феникс";
                    LabelName.Text = "Имя игрока 2:";
                    break;
            }
        }        
        public void WSPB_MouseRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox buffer = (PictureBox)sender;
                string[] split = buffer.Name.Split(' ');
                int i = Convert.ToInt32(split[0]);
                int j = Convert.ToInt32(split[1]);
                if (FieldBuf[i, j].GetOccup() == 1)
                {
                    MenuDelete.Show(FieldBuf[i, j].WSPB, new Point (0, FieldBuf[i, j].WSPB.Height/2));
                }                
            }
        }
        public void WSPB_MouseLeftClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox buffer = (PictureBox)sender;
                string[] split = buffer.Name.Split(' ');
                int i = Convert.ToInt32(split[0]);
                int j = Convert.ToInt32(split[1]);
                if (RB4S.Checked == true && F.UnABattleships > 0)
                {
                    if (RB_H.Checked == true)
                    {
                        if (j+3 <= 9)
                        {
                            for (int a = 0; a < 4; a++)
                            {
                                Point p = new Point(i, j+a);
                                if (Engaged.Contains(p) || Neighbour.Contains(p) || F.Battleships[0].GetStatus() == 1)
                                {
                                    return;                                    
                                }                                
                            }
                            for (int a = 0; a < 4; a++)
                            {
                                Point p = new Point(i, j + a);
                                FieldBuf[i, j + a].WSPB.BackColor = Color.Blue;
                                FieldBuf[i, j + a].SetOccup(1);
                                Engaged.Add(p);
                                F.Battleships[0].Decks.Add(p);
                            }
                            for (int a = 0; a < 4; a++)
                            {
                                Operations.NearPoints(Engaged, Neighbour, i, j+a);                                                          
                            }
                            F.Battleships[0].ChangeStat(1);
                            F.UnABattleships--;
                            Label4S.Text = "Не размещено: " + F.UnABattleships;
                        }
                    }

                    if (RB_V.Checked == true)
                    {
                        if (i + 3 <= 9)
                        {
                            for (int a = 0; a < 4; a++)
                            {
                                Point p = new Point(i + a, j);
                                if (Engaged.Contains(p) || Neighbour.Contains(p) || F.Battleships[0].GetStatus() == 1)
                                {
                                    return;
                                }
                            }
                            for (int a = 0; a < 4; a++)
                            {
                                Point p = new Point(i + a, j);
                                FieldBuf[i + a, j].WSPB.BackColor = Color.Blue;
                                FieldBuf[i + a, j].SetOccup(1);
                                Engaged.Add(p);
                                F.Battleships[0].Decks.Add(p);
                            }
                            for (int a = 0; a < 4; a++)
                            {
                                Operations.NearPoints(Engaged, Neighbour, i + a, j);
                            }
                            F.Battleships[0].ChangeStat(1);
                            F.UnABattleships--;
                            Label4S.Text = "Не размещено: " + F.UnABattleships;
                        }
                    }
                }
                if (RB3S.Checked == true && F.UnAFrigates != 0)
                {
                    if (RB_H.Checked == true)
                    {
                        if (j + 2 <= 9)
                        {
                            for (int a = 0; a < 3; a++)
                            {
                                Point p = new Point(i , j + a);
                                if (Engaged.Contains(p) || Neighbour.Contains(p))
                                {
                                    return;
                                }
                            }
                            for (int b = 0; b < F.Frigates.Count; b++)
                            {
                                if (F.Frigates[b].GetStatus() == 0)
                                {
                                    for (int a = 0; a < 3; a++)
                                    {
                                        Point p = new Point(i, j + a);
                                        FieldBuf[i, j + a].WSPB.BackColor = Color.Green;
                                        FieldBuf[i, j + a].SetOccup(1);
                                        Engaged.Add(p);
                                        F.Frigates[b].Decks.Add(p);
                                    }
                                    for (int a = 0; a < 3; a++)
                                    {
                                        Operations.NearPoints(Engaged, Neighbour, i, j + a);
                                    }
                                    F.Frigates[b].ChangeStat(1);
                                    F.UnAFrigates--;
                                    Label3S.Text = "Не размещено: " + F.UnAFrigates;
                                    break;
                                }
                            }
                        }
                    }

                    if (RB_V.Checked == true)
                    {
                        if (i + 2 <= 9)
                        {
                            for (int a = 0; a < 3; a++)
                            {
                                Point p = new Point(i + a, j);
                                if (Engaged.Contains(p) || Neighbour.Contains(p))
                                {
                                    return;
                                }
                            }
                            for (int b = 0; b < F.Frigates.Count; b++)
                            {
                                if (F.Frigates[b].GetStatus() == 0)
                                {
                                    for (int a = 0; a < 3; a++)
                                    {
                                        Point p = new Point(i + a, j);
                                        FieldBuf[i + a, j].WSPB.BackColor = Color.Green;
                                        FieldBuf[i + a, j].SetOccup(1);
                                        Engaged.Add(p);
                                        F.Frigates[b].Decks.Add(p);
                                    }
                                    for (int a = 0; a < 3; a++)
                                    {
                                        Operations.NearPoints(Engaged, Neighbour, i + a, j);
                                    }
                                    F.Frigates[b].ChangeStat(1);
                                    F.UnAFrigates--;
                                    Label3S.Text = "Не размещено: " + F.UnAFrigates;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (RB2S.Checked == true && F.UnACorvettes != 0)
                {
                    if (RB_H.Checked == true)
                    {
                        if (j + 1 <= 9)
                        {
                            for (int a = 0; a < 2; a++)
                            {
                                Point p = new Point(i, j + a);
                                if (Engaged.Contains(p) || Neighbour.Contains(p))
                                {
                                    return;
                                }
                            }
                            for (int b = 0; b < F.Corvettes.Count; b++)
                            {
                                if (F.Corvettes[b].GetStatus() == 0)
                                {
                                    for (int a = 0; a < 2; a++)
                                    {
                                        Point p = new Point(i, j + a);
                                        FieldBuf[i, j + a].WSPB.BackColor = Color.Yellow;
                                        FieldBuf[i, j + a].SetOccup(1);
                                        Engaged.Add(p);
                                        F.Corvettes[b].Decks.Add(p);
                                    }
                                    for (int a = 0; a < 2; a++)
                                    {
                                        Operations.NearPoints(Engaged, Neighbour, i, j + a);
                                    }
                                    F.Corvettes[b].ChangeStat(1);
                                    F.UnACorvettes--;
                                    Label2S.Text = "Не размещено: " + F.UnACorvettes;
                                    break;
                                }
                            }
                        }
                    }

                    if (RB_V.Checked == true)
                    {
                        if (i + 1 <= 9)
                        {
                            for (int a = 0; a < 3; a++)
                            {
                                Point p = new Point(i + a, j);
                                if (Engaged.Contains(p) || Neighbour.Contains(p))
                                {
                                    return;
                                }
                            }
                            for (int b = 0; b < F.Corvettes.Count; b++)
                            {
                                if (F.Corvettes[b].GetStatus() == 0)
                                {
                                    for (int a = 0; a < 2; a++)
                                    {
                                        Point p = new Point(i + a, j);
                                        FieldBuf[i + a, j].WSPB.BackColor = Color.Yellow;
                                        FieldBuf[i + a, j].SetOccup(1);
                                        Engaged.Add(p);
                                        F.Corvettes[b].Decks.Add(p);
                                    }
                                    for (int a = 0; a < 2; a++)
                                    {
                                        Operations.NearPoints(Engaged, Neighbour, i + a, j);
                                    }
                                    F.Corvettes[b].ChangeStat(1);
                                    F.UnACorvettes--;
                                    Label2S.Text = "Не размещено: " + F.UnACorvettes;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (RB1S.Checked == true && F.UnABoats != 0)
                {
                    for (int b = 0; b < F.Boats.Count; b++)
                    {
                        Point p = new Point(i, j);
                        if (Engaged.Contains(p) || Neighbour.Contains(p))
                        {
                            return;
                        }
                        if (F.Boats[b].GetStatus() == 0)
                        {
                            FieldBuf[i, j].WSPB.BackColor = Color.Purple;
                            FieldBuf[i, j].SetOccup(1);
                            Engaged.Add(p);
                            F.Boats[b].Decks.Add(p);
                            Operations.NearPoints(Engaged, Neighbour, i, j);
                            F.Boats[b].ChangeStat(1);
                            F.UnABoats--;
                            Label1S.Text = "Не размещено: " + F.UnABoats;
                            break;
                        }
                    }
                }
            }
        }
        private void Button4S_Click(object sender, EventArgs e)
        {
            RB4S.Checked = true;            
        }
        private void Button3S_Click(object sender, EventArgs e)
        {
            RB3S.Checked = true;
        }
        private void Button2S_Click(object sender, EventArgs e)
        {
            RB2S.Checked = true;
        }
        private void Button1S_Click(object sender, EventArgs e)
        {
            RB1S.Checked = true;
        }
        private void RBStandart_CheckedChanged(object sender, EventArgs e)
        {
            if (RBStandart.Checked == true)
            {
                TBLinN.Enabled = false;
                TBFrigN1.Enabled = false;
                TBFrigN2.Enabled = false;
                TBCorN1.Enabled = false;
                TBCorN2.Enabled = false;
                TBCorN3.Enabled = false;
                TBKatN1.Enabled = false;
                TBKatN2.Enabled = false;
                TBKatN3.Enabled = false;
                TBKatN4.Enabled = false;

                switch (reference.NumOfF2)
                {
                    case 0:
                        TBLinN.Text = "Бородино";
                        TBFrigN1.Text = "Петербург";
                        TBFrigN2.Text = "Святой Пётр";
                        TBCorN1.Text = "Гремящий";
                        TBCorN2.Text = "Воевода";
                        TBCorN3.Text = "Варяг";
                        TBKatN1.Text = "Буян";
                        TBKatN2.Text = "Страж";
                        TBKatN3.Text = "Змея";
                        TBKatN4.Text = "Барсук";
                        break;
                    case 1:
                        TBLinN.Text = "Королевская удача";
                        TBFrigN1.Text = "Месть королевы Анны";
                        TBFrigN2.Text = "Бродяга";
                        TBCorN1.Text = "Аквила";
                        TBCorN2.Text = "Галка";
                        TBCorN3.Text = "Морриган";
                        TBKatN1.Text = "Бенджамин";
                        TBKatN2.Text = "Месть";
                        TBKatN3.Text = "Принц";
                        TBKatN4.Text = "Феникс";
                        break;
                }
            }
        }
        private void RBUser_CheckedChanged(object sender, EventArgs e)
        {
            if (RBUser.Checked == true)
            {
                TBLinN.Enabled = true;
                TBFrigN1.Enabled = true;
                TBFrigN2.Enabled = true;
                TBCorN1.Enabled = true;
                TBCorN2.Enabled = true;
                TBCorN3.Enabled = true;
                TBKatN1.Enabled = true;
                TBKatN2.Enabled = true;
                TBKatN3.Enabled = true;
                TBKatN4.Enabled = true;
            }
        }
        private void RBNoName_CheckedChanged(object sender, EventArgs e)
        {
            if (RBNoName.Checked == true)
            {
                TBLinN.Enabled = false;
                TBFrigN1.Enabled = false;
                TBFrigN2.Enabled = false;
                TBCorN1.Enabled = false;
                TBCorN2.Enabled = false;
                TBCorN3.Enabled = false;
                TBKatN1.Enabled = false;
                TBKatN2.Enabled = false;
                TBKatN3.Enabled = false;
                TBKatN4.Enabled = false;

                TBLinN.Text = "";
                TBFrigN1.Text = "";
                TBFrigN2.Text = "";
                TBCorN1.Text = "";
                TBCorN2.Text = "";
                TBCorN3.Text = "";
                TBKatN1.Text = "";
                TBKatN2.Text = "";
                TBKatN3.Text = "";
                TBKatN4.Text = "";
            }
        }
        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem buf1 = (ToolStripMenuItem)sender;
            ToolStrip buf2 = buf1.Owner;
            ContextMenuStrip buf3 = (ContextMenuStrip)buf2;
            Control link = buf3.SourceControl;
            PictureBox buffer = (PictureBox)link;
            string[] split = buffer.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            Point p = new Point(i, j);


            if (F.Battleships[0].Decks.Contains(p))
            {
                for (int a = 0; a < F.Battleships[0].Decks.Count; a++)
                {
                    Point o = F.Battleships[0].Decks[a];
                    FieldBuf[o.X, o.Y].WSPB.BackColor = Color.Transparent;
                    FieldBuf[o.X, o.Y].SetOccup(0);
                    Engaged.Remove(o);
                }
                F.Battleships[0].ChangeStat(0);
                F.Battleships[0].Decks.Clear();
                F.UnABattleships++;
                Label4S.Text = "Не размещено: " + F.UnABattleships;               
            }

            for (int b = 0; b < F.Frigates.Count; b++)
            {
                if (F.Frigates[b].Decks.Contains(p))
                {
                    for (int a = 0; a < F.Frigates[b].Decks.Count; a++)
                    {
                        Point o = F.Frigates[b].Decks[a];
                        FieldBuf[o.X, o.Y].WSPB.BackColor = Color.Transparent;
                        FieldBuf[o.X, o.Y].SetOccup(0);
                        Engaged.Remove(o);
                    }
                    F.Frigates[b].ChangeStat(0);
                    F.Frigates[b].Decks.Clear();
                    F.UnAFrigates++;
                    Label3S.Text = "Не размещено: " + F.UnAFrigates;
                }
            }

            for (int b = 0; b < F.Corvettes.Count; b++)
            {
                if (F.Corvettes[b].Decks.Contains(p))
                {
                    for (int a = 0; a < F.Corvettes[b].Decks.Count; a++)
                    {
                        Point o = F.Corvettes[b].Decks[a];
                        FieldBuf[o.X, o.Y].WSPB.BackColor = Color.Transparent;
                        FieldBuf[o.X, o.Y].SetOccup(0);
                        Engaged.Remove(o);
                    }
                    F.Corvettes[b].ChangeStat(0);
                    F.Corvettes[b].Decks.Clear();
                    F.UnACorvettes++;
                    Label2S.Text = "Не размещено: " + F.UnACorvettes;
                }
            }

            for (int b = 0; b < F.Boats.Count; b++)
            {
                if (F.Boats[b].Decks.Contains(p))
                {                    
                    Point o = F.Boats[b].Decks[0];
                    FieldBuf[o.X, o.Y].WSPB.BackColor = Color.Transparent;
                    FieldBuf[o.X, o.Y].SetOccup(0);
                    Engaged.Remove(o);                    
                    F.Boats[b].ChangeStat(0);
                    F.Boats[b].Decks.Clear();
                    F.UnABoats++;
                    Label1S.Text = "Не размещено: " + F.UnABoats;
                }
            }

            Neighbour.Clear();
            for (int a = 0; a < Engaged.Count; a++)
            {
                Operations.NearPoints(Engaged, Neighbour, Engaged[a].X, Engaged[a].Y);
            }

        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            bool cond1 = F.UnABoats == 0 & F.UnACorvettes == 0 & F.UnAFrigates == 0 & F.UnABattleships == 0;
            bool cond2 = TBName.Text.Length >= 2;

            if (cond1 == false)
            {
                MessageBox.Show("Не все корабли расположены на поле!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cond2 == false)
            {
                MessageBox.Show("Не задано имя игрока!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cond1 == true && cond2 == true)
            {
                F.Battleships[0].SetName(TBLinN.Text);
                F.Frigates[0].SetName(TBFrigN1.Text);
                F.Frigates[1].SetName(TBFrigN2.Text);
                F.Corvettes[0].SetName(TBCorN1.Text);
                F.Corvettes[1].SetName(TBCorN2.Text);
                F.Corvettes[2].SetName(TBCorN3.Text);
                F.Boats[0].SetName(TBKatN1.Text);
                F.Boats[1].SetName(TBKatN2.Text);
                F.Boats[2].SetName(TBKatN3.Text);
                F.Boats[3].SetName(TBKatN4.Text);
                switch (reference.NumOfF2)
                {
                    case 0:
                        {
                            Data.Name1 = TBName.Text;
                            for (int i = 0; i < 10; i ++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    Data.Field1[i, j] = new Square(FieldBuf[i, j]);                                   
                                }
                            } 
                            Data.Fleet1 = new Fleet(F);
                        } break;
                    case 1:
                        {
                            Data.Name2 = TBName.Text;
                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    Data.Field2[i, j] = new Square(FieldBuf[i, j]);
                                }
                            }
                            Data.Fleet2 = new Fleet(F);

                        }
                        break;
                }
                reference.NumOfF2++;
                this.Close();
            }
        }
    }
}