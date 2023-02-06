using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace Warships
{
    public class Square
    {
        public PictureBox WSPB;    //графическое отображение квадрата поля
        int occup;          //занят ли квадрат кораблём (1 - да, 0 - нет)
        int hit;            //совершено ли попадание в квадрат (1 - да, 0 - нет)
        int indexi;         //индекс строки квадрата в матрице
        int indexj;         //индекс столбца квадрата в матрице

        public Square(int i, int j, ConstructorForm f)
        {
            WSPB = new PictureBox();
            WSPB.Margin = new Padding(0);
            WSPB.Padding = new Padding(0);
            WSPB.Size = new System.Drawing.Size(30, 30);
            WSPB.BackColor = Color.Transparent;           
            using (Pen p = new Pen(Color.Black, 1))     //создаём инструмент рисования прямых
            {
                Bitmap b = new Bitmap(WSPB.Width, WSPB.Height);   //создаём изображение (полотно)
                using (Graphics g = Graphics.FromImage(b))      //используем Graphics для рисования
                {                    
                    g.DrawRectangle(p, 0, 0, WSPB.Width - 1, WSPB.Height - 1);    //по краям рисуем прямоугольник - рамку
                }
                WSPB.Image = b;      //помещаем нарисованное изображение в PictureBox
            }
            occup = 0;
            hit = 0;
            indexi = i;
            indexj = j;
            WSPB.Name = "" + indexi + " " + indexj;
            WSPB.MouseDown += new System.Windows.Forms.MouseEventHandler(f.WSPB_MouseRightClick);       //подписка на событие - нажатие ПКМ
            WSPB.MouseDown += new System.Windows.Forms.MouseEventHandler(f.WSPB_MouseLeftClick);        //подписка на событие - нажатие ЛКМ
            
        }

        public void DrawX()
        {
            using (Pen p = new Pen(Color.Red, 1))
            {
                Bitmap b = new Bitmap(WSPB.Image);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.DrawLine(p, new Point(0, 0), new Point(30, 30));
                    g.DrawLine(p, new Point(30, 0), new Point(0, 30));
                }
                WSPB.Image = b;
            }
        }

        public void SetOccup(int o)
        {
            occup = o;
        }

        public int GetOccup()
        {
            return occup;
        }

        public void SetHit(int h)
        {
            hit = h;
        }

        public int GetHit()
        {
            return hit;
        }   

        public Square(Square s)
        {
            WSPB = s.WSPB;
            occup = s.occup;
            hit = s.hit;
            indexi = s.indexi;
            indexj = s.indexj;
        }

        public void SignGame(MainForm f)
        {
            WSPB.MouseDown += new System.Windows.Forms.MouseEventHandler(f.WSPB_MouseLeftClick);        //подписка на событие - нажатие ЛКМ
        }
    }
    class Ship
    {
            
        int size;       //количество палуб (1-4)        
        int status;     //статус корабля (1 - распределён, 0 - не распределён)
        int messages;   //участвует ли имя корабля в сообщениях (1 - участвует, 0 - не участвует)
        string Type;    //тип корабля
        string Name;    //имя корабля
        public List<Point> Decks;
        public Ship(int s)
        {
            
            size = s;            
            status = 0;
            messages = 1;
            switch (size)
            {
                case 1: Type = "Катер"; break;
                case 2: Type = "Корвет"; break;
                case 3: Type = "Фрегат"; break;
                case 4: Type = "Линкор"; break;
            }
            Decks = new List<Point>();            
            Name = null;
        }                
        public void SetMess(int m)
        {
            messages = m;
        }
        public int GetMess()
        {
            return messages;
        }
        public void ChangeStat(int stat)
        {
            status = stat;
        }        
        public void SetName(string n)
        {
            Name = n;
        }
        public string GetName()
        {
            if (Name != "")
            {
                return Type + ' ' + '"' + Name + '"';
            }
            else
            {
                return Type;
            }
        }        
        public int GetStatus()
        {
            return status;
        }    }
    
    class Fleet
    {
        public List<Ship> Battleships = new List<Ship>();
        public List<Ship> Frigates = new List<Ship>();
        public List<Ship> Corvettes = new List<Ship>();
        public List<Ship> Boats = new List<Ship>();

        public int UnABattleships;
        public int UnAFrigates;
        public int UnACorvettes;
        public int UnABoats;

        public Fleet ()
        {
            Battleships.Add(new Ship(4));
            Frigates.Add(new Ship(3));
            Frigates.Add(new Ship(3));
            Corvettes.Add(new Ship(2));
            Corvettes.Add(new Ship(2));
            Corvettes.Add(new Ship(2));
            Boats.Add(new Ship(1));
            Boats.Add(new Ship(1));
            Boats.Add(new Ship(1));
            Boats.Add(new Ship(1));
            UnABattleships = 1;
            UnAFrigates = 2;
            UnACorvettes = 3;
            UnABoats = 4;
        }
        public Fleet (Fleet f)
        {
            Battleships = f.Battleships;
            Frigates = f.Frigates;
            Corvettes = f.Corvettes;
            Boats = f.Boats;
            UnABattleships = f.UnABattleships;
            UnAFrigates = f.UnAFrigates;
            UnACorvettes = f.UnACorvettes;
            UnABoats = f.UnABoats;
        }
    }
    static class Data
    {
        static public Square[,] Field1 = new Square[10, 10];   //поле первого игрока
        static public Square[,] Field2 = new Square[10, 10];   //поле второго игрока
        static public Fleet Fleet1;              //флот первого игрока
        static public Fleet Fleet2;              //флот второго игрока
        static public string Name1;                            //имя первого игрока
        static public string Name2;                            //имя второго игрока
        static public string[] Attacks = { " открыл огонь! ", " атакует! ", " дал залп! ", " выстрелил! ", " стреляет! " };
        static public string[] Hits = { "Попадание!", "Точно в цель!", "Флот противника несёт потери!", "Есть пробитие!", "Враг идёт на дно!" };
        static public string[] Miss = { "Мимо!", "Промах!", "Снаряд ушёл в молоко!", "Враг невредим!", "Пустая трата боеприпасов!" };
        static public string[] Final = { " ставит жирную точку в этом бою. ", " даёт победный залп по противнику. ", " забивает последний гвоздь в крышку гроба. " };
    }

    static class Operations
    {
        static public void NearPoints(List<Point> Engaged, List<Point> Neighbour, int i,int j)  //для списка точек E определяет соседние существующие точки в одном экземпляре и записывает в список N
        {
            Point o;
            o = new Point(i - 1, j - 1);
            if (i - 1 >= 0 && j - 1 >= 0 && !Engaged.Contains(o) && !Neighbour.Contains(o))
            {
                Neighbour.Add(o);
            }
            o = new Point(i - 1, j);
            if (i - 1 >= 0 && !Engaged.Contains(o) && !Neighbour.Contains(o))
            {
                Neighbour.Add(o);
            }
            o = new Point(i - 1, j + 1);
            if (i - 1 >= 0 && j + 1 <= 9 && !Engaged.Contains(o) && !Neighbour.Contains(o))
            {
                Neighbour.Add(o);
            }
            o = new Point(i, j + 1);
            if (j + 1 <= 9 && !Engaged.Contains(o) && !Neighbour.Contains(o))
            {
                Neighbour.Add(o);
            }
            o = new Point(i + 1, j + 1);
            if (i + 1 <= 9 && j + 1 <= 9 && !Engaged.Contains(o) && !Neighbour.Contains(o))
            {
                Neighbour.Add(o);
            }
            o = new Point(i + 1, j);
            if (i + 1 <= 9 && !Engaged.Contains(o) && !Neighbour.Contains(o))
            {
                Neighbour.Add(o);
            }
            o = new Point(i + 1, j - 1);
            if (i + 1 <= 9 && j - 1 >= 0 && !Engaged.Contains(o) && !Neighbour.Contains(o))
            {
                Neighbour.Add(o);
            }
            o = new Point(i, j - 1);
            if (j - 1 >= 0 && !Engaged.Contains(o) && !Neighbour.Contains(o))
            {
                Neighbour.Add(o);
            }
        }       

        static public string AnyShip(Fleet F)
        {
            Random rnd = new Random();
            int f, c, b;    //индексы кораблей из списка фрегатов f, корветов c и катеров b
            bool fcond = false, ccond = false, bcond = false, Bacond = false;   // проверка, существуют ли в списках подходящие корабли
            int result;     //итоговый выбор
            List<Ship> Buf = new List<Ship>();
            if (F.Battleships[0].GetMess() == 1)
            {
                Bacond = true;
            }
            for (int a = 0; a < F.Frigates.Count; a++)
            {
                if (F.Frigates[a].GetMess() == 1)
                {
                    fcond = true;
                }
            }
            for (int a = 0; a < F.Corvettes.Count; a++)
            {
                if (F.Corvettes[a].GetMess() == 1)
                {
                    ccond = true;
                }
            }
            for (int a = 0; a < F.Boats.Count; a++)
            {
                if (F.Boats[a].GetMess() == 1)
                {
                    bcond = true;
                }
            }
            if (Bacond)
            {
                Buf.Add(F.Battleships[0]);
            }
            if(fcond)
            {
                f = rnd.Next(0, 2);
                while(F.Frigates[f].GetMess() == 0)
                {
                    f = rnd.Next(0, 2);
                }
                Buf.Add(F.Frigates[f]);
            }
            if (ccond)
            {
                c = rnd.Next(0, 3);
                while (F.Corvettes[c].GetMess() == 0)
                {
                    c = rnd.Next(0, 3);
                }
                Buf.Add(F.Corvettes[c]);
            }
            if (bcond)
            {
                b = rnd.Next(0, 4);
                while (F.Boats[b].GetMess() == 0)
                {
                    b = rnd.Next(0, 4);
                }
                Buf.Add(F.Boats[b]);
            }
            result = rnd.Next(0, Buf.Count);
            return Buf[result].GetName();
        }
    }
}