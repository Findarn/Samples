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
    public partial class MainForm : Form
    {
        public int NumOfF2 = 0;
        bool P1 = false, P2 = false;
        int curP;   //1 - ход первого игрока, 2 - ход второго игрока
        int P1S = 0, P2S = 0;
        List<Point> Engaged1 = new List<Point>();
        List<Point> Neighbour1 = new List<Point>();
        List<Point> Engaged2 = new List<Point>();
        List<Point> Neighbour2 = new List<Point>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Курсовая работа Виталия Ермолина \n Группа ИСТ-19Г \n \t \"Морской бой\"" +
                "\n Программа реализует известную игру в морской бой \n Для начала игры нажмите соответствующий пункт меню", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void WSPB_MouseLeftClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox buffer = (PictureBox)sender;
                string[] split = buffer.Name.Split(' ');
                int i = Convert.ToInt32(split[0]);
                int j = Convert.ToInt32(split[1]);
                bool condB = false, condF = false, condC = false;
                int F = 0, C = 0;
                Random R = new Random();
                switch(curP)
                {
                    case 1:
                        {
                            if (buffer.Parent.Name == "Player2Field")
                            {
                                if(Data.Field2[i, j].GetHit() == 0)
                                {
                                    Data.Field2[i, j].SetHit(1);
                                    Data.Field2[i, j].DrawX();
                                    if (Data.Field2[i, j].GetOccup() == 1)
                                    {
                                        buffer.BackColor = Color.Blue;
                                        P2S--;
                                        Point p = new Point(i, j);
                                        if (Data.Fleet2.Battleships[0].Decks.Contains(p))
                                        {
                                            for (int b = 0; b < Data.Fleet2.Battleships[0].Decks.Count; b++)
                                            {
                                                if (Data.Field2[Data.Fleet2.Battleships[0].Decks[b].X, Data.Fleet2.Battleships[0].Decks[b].Y].GetHit() == 1)
                                                {
                                                    Data.Fleet2.Battleships[0].SetMess(0);
                                                    condB = true;
                                                }
                                                else
                                                {
                                                    Data.Fleet2.Battleships[0].SetMess(1);
                                                    condB = false; break;                                                    
                                                }                                                
                                            }                                            
                                        }
                                        for (int a = 0; a < Data.Fleet2.Frigates.Count; a++)
                                        {
                                            if (Data.Fleet2.Frigates[a].Decks.Contains(p))
                                            {
                                                for (int b = 0; b < Data.Fleet2.Frigates[a].Decks.Count; b++)
                                                {
                                                    if (Data.Field2[Data.Fleet2.Frigates[a].Decks[b].X, Data.Fleet2.Frigates[a].Decks[b].Y].GetHit() == 1)
                                                    {
                                                        Data.Fleet2.Frigates[a].SetMess(0);
                                                        condF = true;
                                                    }
                                                    else
                                                    {
                                                        Data.Fleet2.Frigates[a].SetMess(1);
                                                        condF = false; break;                                                        
                                                    }
                                                    F = a;
                                                }
                                                break;
                                            }
                                        }
                                        for (int a = 0; a < Data.Fleet2.Corvettes.Count; a++)
                                        {
                                            if (Data.Fleet2.Corvettes[a].Decks.Contains(p))
                                            {
                                                for (int b = 0; b < Data.Fleet2.Corvettes[a].Decks.Count; b++)
                                                {
                                                    if (Data.Field2[Data.Fleet2.Corvettes[a].Decks[b].X, Data.Fleet2.Corvettes[a].Decks[b].Y].GetHit() == 1)
                                                    {
                                                        Data.Fleet2.Corvettes[a].SetMess(0);
                                                        condC = true;
                                                    }
                                                    else
                                                    {
                                                        Data.Fleet2.Corvettes[a].SetMess(1);
                                                        condC = false; break;

                                                    }
                                                    C = a;
                                                }
                                                break;
                                            }
                                        }
                                        for (int a = 0; a < Data.Fleet2.Boats.Count; a++)
                                        {
                                            if (Data.Fleet2.Boats[a].Decks.Contains(p))
                                            {
                                                Data.Fleet2.Boats[a].SetMess(0);
                                                Operations.NearPoints(Engaged2, Neighbour2, p.X, p.Y);
                                                break;
                                            }
                                        }

                                        if(condB)
                                        {
                                            for (int b = 0; b < Data.Fleet2.Battleships[0].Decks.Count; b++)
                                            {
                                                Operations.NearPoints(Engaged2, Neighbour2, Data.Fleet2.Battleships[0].Decks[b].X, Data.Fleet2.Battleships[0].Decks[b].Y);
                                            }
                                        }
                                        if (condF)
                                        {
                                            for (int b = 0; b < Data.Fleet2.Frigates[F].Decks.Count; b++)
                                            {
                                                Operations.NearPoints(Engaged2, Neighbour2, Data.Fleet2.Frigates[F].Decks[b].X, Data.Fleet2.Frigates[F].Decks[b].Y);
                                            }
                                        }
                                        if (condC)
                                        {
                                            for (int b = 0; b < Data.Fleet2.Corvettes[C].Decks.Count; b++)
                                            {
                                                Operations.NearPoints(Engaged2, Neighbour2, Data.Fleet2.Corvettes[C].Decks[b].X, Data.Fleet2.Corvettes[C].Decks[b].Y);
                                            }
                                        }

                                        for (int c = 0; c < Neighbour2.Count; c++)
                                        {
                                            Data.Field2[Neighbour2[c].X, Neighbour2[c].Y].SetHit(1);
                                            Data.Field2[Neighbour2[c].X, Neighbour2[c].Y].WSPB.BackColor = Color.Yellow;
                                            Data.Field2[Neighbour2[c].X, Neighbour2[c].Y].DrawX();
                                        }

                                        if (P2S == 0)
                                        {
                                            curP = 0;
                                            BattleLog.Text += Operations.AnyShip(Data.Fleet1) + Data.Final[R.Next(0, Data.Final.Length)] + Data.Name1 + " победил! Морской бой окончен." + "\n";
                                            GameResult.Text = "Победил " + Data.Name1 + "!";
                                            return;
                                        }
                                        BattleLog.Text += Operations.AnyShip(Data.Fleet1) + Data.Attacks[R.Next(0, Data.Attacks.Length)] + Data.Hits[R.Next(0, Data.Hits.Length)] + "\n";
                                    }
                                    else
                                    {
                                        buffer.BackColor = Color.Yellow;
                                        curP = 2;
                                        BattleLog.Text += Operations.AnyShip(Data.Fleet1) + Data.Attacks[R.Next(0, Data.Attacks.Length)] + Data.Miss[R.Next(0, Data.Miss.Length)] + "\n";
                                        PlayerCurrentAction.Text = Data.Name2 + ", стреляй по " + Data.Name1 + "!";
                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            if (buffer.Parent.Name == "Player1Field")
                            {
                                if (Data.Field1[i, j].GetHit() == 0)
                                {
                                    Data.Field1[i, j].SetHit(1);
                                    Data.Field1[i, j].DrawX();
                                    if (Data.Field1[i, j].GetOccup() == 1)
                                    {
                                        buffer.BackColor = Color.Blue;
                                        P1S--;
                                        Point p = new Point(i, j);
                                        if (Data.Fleet1.Battleships[0].Decks.Contains(p))
                                        {
                                            for (int b = 0; b < Data.Fleet1.Battleships[0].Decks.Count; b++)
                                            {
                                                if (Data.Field1[Data.Fleet1.Battleships[0].Decks[b].X, Data.Fleet1.Battleships[0].Decks[b].Y].GetHit() == 1)
                                                {
                                                    Data.Fleet1.Battleships[0].SetMess(0);
                                                    condB = true;
                                                }
                                                else
                                                {
                                                    Data.Fleet1.Battleships[0].SetMess(1);
                                                    condB = false; break;
                                                }
                                            }
                                        }
                                        for (int a = 0; a < Data.Fleet1.Frigates.Count; a++)
                                        {
                                            if (Data.Fleet1.Frigates[a].Decks.Contains(p))
                                            {
                                                for (int b = 0; b < Data.Fleet1.Frigates[a].Decks.Count; b++)
                                                {
                                                    if (Data.Field1[Data.Fleet1.Frigates[a].Decks[b].X, Data.Fleet1.Frigates[a].Decks[b].Y].GetHit() == 1)
                                                    {
                                                        Data.Fleet1.Frigates[a].SetMess(0);
                                                        condF = true;
                                                    }
                                                    else
                                                    {
                                                        Data.Fleet1.Frigates[a].SetMess(1);
                                                        condF = false; break;
                                                    }
                                                    F = a;
                                                }
                                                break;
                                            }
                                        }
                                        for (int a = 0; a < Data.Fleet1.Corvettes.Count; a++)
                                        {
                                            if (Data.Fleet1.Corvettes[a].Decks.Contains(p))
                                            {
                                                for (int b = 0; b < Data.Fleet1.Corvettes[a].Decks.Count; b++)
                                                {
                                                    if (Data.Field1[Data.Fleet1.Corvettes[a].Decks[b].X, Data.Fleet1.Corvettes[a].Decks[b].Y].GetHit() == 1)
                                                    {
                                                        Data.Fleet1.Corvettes[a].SetMess(0);
                                                        condC = true;
                                                    }
                                                    else
                                                    {
                                                        Data.Fleet1.Corvettes[a].SetMess(1);
                                                        condC = false; break;
                                                    }
                                                    C = a;
                                                }
                                                break;
                                            }
                                        }
                                        for (int a = 0; a < Data.Fleet1.Boats.Count; a++)
                                        {
                                            if (Data.Fleet1.Boats[a].Decks.Contains(p))
                                            {
                                                Data.Fleet1.Boats[a].SetMess(0);
                                                Operations.NearPoints(Engaged1, Neighbour1, p.X, p.Y);
                                                break;
                                            }
                                        }

                                        if (condB)
                                        {
                                            for (int b = 0; b < Data.Fleet1.Battleships[0].Decks.Count; b++)
                                            {
                                                Operations.NearPoints(Engaged1, Neighbour1, Data.Fleet1.Battleships[0].Decks[b].X, Data.Fleet1.Battleships[0].Decks[b].Y);
                                            }
                                        }
                                        if (condF)
                                        {
                                            for (int b = 0; b < Data.Fleet1.Frigates[F].Decks.Count; b++)
                                            {
                                                Operations.NearPoints(Engaged1, Neighbour1, Data.Fleet1.Frigates[F].Decks[b].X, Data.Fleet1.Frigates[F].Decks[b].Y);
                                            }
                                        }
                                        if (condC)
                                        {
                                            for (int b = 0; b < Data.Fleet1.Corvettes[C].Decks.Count; b++)
                                            {
                                                Operations.NearPoints(Engaged1, Neighbour1, Data.Fleet1.Corvettes[C].Decks[b].X, Data.Fleet1.Corvettes[C].Decks[b].Y);
                                            }
                                        }

                                        for (int c = 0; c < Neighbour1.Count; c++)
                                        {
                                            Data.Field1[Neighbour1[c].X, Neighbour1[c].Y].SetHit(1);
                                            Data.Field1[Neighbour1[c].X, Neighbour1[c].Y].WSPB.BackColor = Color.Yellow;
                                            Data.Field1[Neighbour1[c].X, Neighbour1[c].Y].DrawX();
                                        }

                                        if (P1S == 0)
                                        {
                                            curP = 0;
                                            BattleLog.Text += Operations.AnyShip(Data.Fleet2) + Data.Final[R.Next(0, Data.Final.Length)] + Data.Name2 + " победил! Морской бой окончен." + "\n";
                                            GameResult.Text = "Победил " + Data.Name2 + "!";
                                            return;
                                        }
                                        BattleLog.Text += Operations.AnyShip(Data.Fleet2) + Data.Attacks[R.Next(0, Data.Attacks.Length)] + Data.Hits[R.Next(0, Data.Hits.Length)] + "\n";
                                    }
                                    else
                                    {
                                        buffer.BackColor = Color.Yellow;
                                        curP = 1;
                                        BattleLog.Text += Operations.AnyShip(Data.Fleet2) + Data.Attacks[R.Next(0, Data.Attacks.Length)] + Data.Miss[R.Next(0, Data.Miss.Length)] + "\n";
                                        PlayerCurrentAction.Text = Data.Name1 + ", огонь по " + Data.Name2 + "!";
                                    }
                                }
                            }
                        }
                        break;
                }  
            }
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NumOfF2 == 2)
            {
                DialogResult DR = MessageBox.Show("Текущая партия будет закрыта! Вы уверены, что хотите начать новую игру?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DR == DialogResult.Yes)
                {
                    NumOfF2 = 0;
                    P1 = false; P1S = 0;
                    P2 = false; P2S = 0;
                    PlayerCurrentAction.Text = "";
                    GameResult.Text = "";
                    BattleLog.Text = "";
                    Engaged1.Clear();
                    Engaged2.Clear();
                    Neighbour1.Clear();
                    Neighbour2.Clear();
                }
                else
                {
                    return;
                }
            }



            if (NumOfF2 == 0)
            {
                ConstructorForm CF1 = new ConstructorForm(this);
                CF1.ShowDialog();                
                P1 = true;
                P1S = 20;
            }

            if (NumOfF2 == 1)
            {
                ConstructorForm CF2 = new ConstructorForm(this);
                CF2.ShowDialog();                
                P2 = true;
                P2S = 20;
            }

            if (P1 != true && P2 != true)
            {
                MessageBox.Show("При создании новой игры возникла ошибка! Повторите попытку!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Player1Name.Text = Data.Name1;
            Player2Name.Text = Data.Name2;            
            Player1Field.Controls.Clear();
            Player2Field.Controls.Clear();
            Player1Field.RowCount = 10;
            Player1Field.ColumnCount = 10;
            Player2Field.RowCount = 10;
            Player2Field.ColumnCount = 10;
            Player1Field.RowStyles.Clear();
            Player2Field.RowStyles.Clear();
            for (int i = 0; i < 10; i++)                //обходим все ряды
            {
                Player1Field.RowStyles.Add(new RowStyle());                //создаём новый стиль ряда
                Player1Field.RowStyles[i].SizeType = SizeType.Absolute;    //определяем единицы измерения размеров - абсолютные
                Player1Field.RowStyles[i].Height = 30;              //высоту строки задаём размером стороны
                Player2Field.RowStyles.Add(new RowStyle());                //создаём новый стиль ряда
                Player2Field.RowStyles[i].SizeType = SizeType.Absolute;    //определяем единицы измерения размеров - абсолютные
                Player2Field.RowStyles[i].Height = 30;              //высоту строки задаём размером стороны
            }
            Player1Field.ColumnStyles.Clear();
            Player2Field.ColumnStyles.Clear();
            for (int i = 0; i < 10; i++)                //обходим все ряды
            {
                Player1Field.ColumnStyles.Add(new ColumnStyle());               //создаём новый стиль ряда
                Player1Field.ColumnStyles[i].SizeType = SizeType.Absolute;      //определяем единицы измерения размеров - абсолютные
                Player1Field.ColumnStyles[i].Width = 30;
                Player2Field.ColumnStyles.Add(new ColumnStyle());               //создаём новый стиль ряда
                Player2Field.ColumnStyles[i].SizeType = SizeType.Absolute;      //определяем единицы измерения размеров - абсолютные
                Player2Field.ColumnStyles[i].Width = 30;
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Player1Field.Controls.Add(Data.Field1[i, j].WSPB, j, i);
                    Data.Field1[i, j].WSPB.BackColor = Color.Transparent;
                    Data.Field1[i, j].SignGame(this);
                    Player2Field.Controls.Add(Data.Field2[i, j].WSPB, j, i);
                    Data.Field2[i, j].WSPB.BackColor = Color.Transparent;
                    Data.Field2[i, j].SignGame(this);
                }
            }

            for (int b = 0; b < Data.Fleet1.Battleships[0].Decks.Count; b++)
            {
                Engaged1.Add(Data.Fleet1.Battleships[0].Decks[b]);
            }
            for (int a = 0; a < Data.Fleet1.Frigates.Count; a++)
            {
                for (int b = 0; b < Data.Fleet1.Frigates[a].Decks.Count; b++)
                {
                    Engaged1.Add(Data.Fleet1.Frigates[a].Decks[b]);
                }                
            }
            for (int a = 0; a < Data.Fleet1.Corvettes.Count; a++)
            {
                for (int b = 0; b < Data.Fleet1.Corvettes[a].Decks.Count; b++)
                {
                    Engaged1.Add(Data.Fleet1.Corvettes[a].Decks[b]);
                }
            }
            for (int a = 0; a < Data.Fleet1.Boats.Count; a++)
            {                
                Engaged1.Add(Data.Fleet1.Boats[a].Decks[0]);                
            }

            for (int b = 0; b < Data.Fleet2.Battleships[0].Decks.Count; b++)
            {
                Engaged2.Add(Data.Fleet2.Battleships[0].Decks[b]);
            }
            for (int a = 0; a < Data.Fleet2.Frigates.Count; a++)
            {
                for (int b = 0; b < Data.Fleet2.Frigates[a].Decks.Count; b++)
                {
                    Engaged2.Add(Data.Fleet2.Frigates[a].Decks[b]);
                }
            }
            for (int a = 0; a < Data.Fleet2.Corvettes.Count; a++)
            {
                for (int b = 0; b < Data.Fleet2.Corvettes[a].Decks.Count; b++)
                {
                    Engaged2.Add(Data.Fleet2.Corvettes[a].Decks[b]);
                }
            }
            for (int a = 0; a < Data.Fleet2.Boats.Count; a++)
            {
                Engaged2.Add(Data.Fleet2.Boats[a].Decks[0]);
            }

            Random rnd = new Random();
            curP = rnd.Next(1, 3);            
            switch (curP)
            {
                case 1: PlayerCurrentAction.Text = Data.Name1 + ", огонь по " + Data.Name2 + "!"; break;
                case 2: PlayerCurrentAction.Text = Data.Name2 + ", стреляй по " + Data.Name1 + "!"; break;
            }
        }
    }
}
