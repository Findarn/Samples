using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Task2
{
    public partial class MainForm : Form
    {
        public FonState FonGrafic { get; set; }       // состояние фона
        int fun;                                      // номер отображаемой функции
        Color cFun;                                   // цвет отрисовки функции
        Bitmap bmp;                                   // полотно для отрисовки
        Bitmap bmpbuf;                                // полотно для отрисовки масштабирования
        const float pix_to_unit = 20;                 // соотношение пикселей к единице измерения (20:1)
        float scale;                                  // масштаб
        float Wbuf, Hbuf;                             // ширина и высота масштабированной области
        float oX, oY;                                 // смещение масштабированной области 
        float startX, startY;                         // координаты начала перемещения
        bool drag;                                    // флаг перемещения
        int count;                                    // счетчик
        // пять экземпляров классов разных функций
        CalcSin cs;
        CalcPow cp;
        CalcTg ct;
        CalcCube cc;
        CalcLinear cl;
        float minx, maxx;                             // определяемые границы оси X для функции
        public MainForm()
        {
            InitializeComponent();                        
            DoubleBuffered = true;
            FonGrafic = new FonState();
            fun = -1;
            cFun = Color.Blue;            
            scale = 100;
            drag = false;
            oX = 0; oY = 0;
            startX = 0; startY = 0;
            count = 0;

            bmp = new Bitmap(PMain.Width, PMain.Height);
            bmpbuf = new Bitmap(PMain.Width, PMain.Height);
            DrawFon(FonGrafic, Graphics.FromImage(bmp));
            pbPanel.Image = bmp;            
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            // правая секция
            this.GBRight.Width = (int)(this.Width * 0.225);
            if (this.GBRight.Width < 130)
                this.GBRight.Width = 130;
            // кнопки
            this.BBack.Width = this.GBRight.Width - 10;
            this.BColor.Width = this.GBRight.Width - 10;
            this.BRandom.Width = this.GBRight.Width - 10;
            this.BSave.Width = this.GBRight.Width - 10;
            // надписи
            this.LPointText.Location = new Point(this.LPointText.Location.X ,GBRight.Height - 20);
            this.LPointValue.Location = new Point(this.LPointValue.Location.X, GBRight.Height - 20);
            this.LScaleText.Location = new Point(this.LScaleText.Location.X, LPointText.Location.Y - 20);
            this.LScaleValue.Location = new Point(this.LScaleValue.Location.X, LPointValue.Location.Y - 20);
            if ((this.LPointText.Size.Width + this.LPointValue.Size.Width) <= (this.GBRight.Width - 12))
                this.LPointValue.Location = new Point(this.GBRight.Width - this.LPointValue.Width - 6, this.LPointValue.Location.Y);
            else
                this.LPointValue.Location = new Point(this.LPointText.Location.X + this.LPointText.Width + 6, this.LPointValue.Location.Y);
            if ((this.LScaleText.Size.Width + this.LScaleValue.Size.Width) <= (this.GBRight.Width - 12))
                this.LScaleValue.Location = new Point(this.GBRight.Width - this.LScaleValue.Width - 6, this.LScaleValue.Location.Y);
            else
                this.LScaleValue.Location = new Point(this.LScaleText.Location.X + this.LScaleText.Width + 6, this.LScaleValue.Location.Y);
            bmp.Dispose();
            bmp = new Bitmap(PMain.Width, PMain.Height);
            DrawFon(FonGrafic, Graphics.FromImage(bmp));
            DrawGraph(fun, cFun, Graphics.FromImage(bmp));

            bmpbuf = new Bitmap(bmp);       

            
            RedrawScaled();
            if (scale == 100)
                pbPanel.Image = bmp;
            else
                pbPanel.Image = bmpbuf;
        }        

        private PointF FindCenter(Panel p)
        {
            PointF Center = new Point(p.Width/2, p.Height/2);
            return Center;
        }       

        void PMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                scale += 5;
                if (scale >= 400)
                    scale = 400f;
            }
            if (e.Delta < 0)
            {
                scale -= 5;
                if (scale <= 20)
                    scale = 20f;
            }
            LScaleValue.Text = scale.ToString() + '%';
            if (scale != 400)
            {
                Wbuf = PMain.Width / (scale / 100);
                Hbuf = PMain.Height / (scale / 100);
                if (scale > 100)
                {
                    oX = -((PMain.Width - Wbuf) * (e.X / (scale / 100) / Wbuf));
                    oY = -((PMain.Height - Hbuf) * (e.Y / (scale / 100) / Hbuf));
                }
                else
                {
                    oX = -((PMain.Width - Wbuf) * (FindCenter(PMain).X / (scale / 100) / Wbuf));
                    oY = -((PMain.Height - Hbuf) * (FindCenter(PMain).Y / (scale / 100) / Hbuf));
                }
            }
            RedrawScaled();
            
            if (scale == 100)
                pbPanel.Image = bmp;
            else
                pbPanel.Image = bmpbuf;
            
            if ((this.LScaleText.Size.Width + this.LScaleValue.Size.Width) <= (this.GBRight.Width - 12))
                this.LScaleValue.Location = new Point(this.GBRight.Width - this.LScaleValue.Width - 6, this.LScaleValue.Location.Y);
            else
                this.LScaleValue.Location = new Point(this.LScaleText.Location.X + this.LScaleText.Width + 6, this.LScaleValue.Location.Y);
        }

        private void DrawFon(FonState fs, Graphics PanelGraphics)  // отрисовка фона графика
        {
            
            Pen pAxis = new Pen(Color.Black, 2);                // перо для отрисовки осей 
            Pen pRound = new Pen(Color.Red, 1);                 // перо для отрисовки круга по единице в центре
            Pen pSquare = new Pen(fs.ColorGrid, 1);          // перо для отрисовки сетки
            Pen pStreak = new Pen(Color.Black, 1);              // перо для отрисовки штриховки
            pRound.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;  // пуктир для круга            
            // отрисовка фонового цвета
            if (!fs.gradient)
            {
                PanelGraphics.FillRectangle(new SolidBrush(fs.MainColor), PMain.ClientRectangle);
            }
            else
            {
                if (fs.gradient_direct)
                {
                    LinearGradientBrush LGB = new LinearGradientBrush(PMain.ClientRectangle, fs.StartGradient, fs.EndGradiend, 90F);
                    PanelGraphics.FillRectangle(LGB, PMain.ClientRectangle);
                }
                else
                {
                    LinearGradientBrush LGB = new LinearGradientBrush(PMain.ClientRectangle, fs.StartGradient, fs.EndGradiend, 0F);
                    PanelGraphics.FillRectangle(LGB, PMain.ClientRectangle);
                }
            }
            // клетки
            PointF step = new PointF(FindCenter(PMain).X, FindCenter(PMain).Y);
            if (fs.grid)
            {
                // начинаем с центра
                // проход лево-верх
                while (step.Y >= 0)
                {
                    step.Y = step.Y - (int)(fs.step_grid * pix_to_unit);
                    while (step.X >= 0)
                    {
                        step.X = step.X - (int)(fs.step_grid * pix_to_unit);
                        PanelGraphics.DrawRectangle(pSquare, step.X, step.Y, (int)(fs.step_grid * pix_to_unit), (int)(fs.step_grid * pix_to_unit));
                    }
                    step.X = FindCenter(PMain).X;
                }
                // установка в центр
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                // проход вправо-верх
                while (step.Y >= 0)
                {
                    step.Y = step.Y - (int)(fs.step_grid * pix_to_unit);
                    while (step.X <= PMain.Width)
                    {
                        PanelGraphics.DrawRectangle(pSquare, step.X, step.Y, (int)(fs.step_grid * pix_to_unit), (int)(fs.step_grid * pix_to_unit));
                        step.X = step.X + (int)(fs.step_grid * pix_to_unit);

                    }
                    step.X = FindCenter(PMain).X;
                }
                // установка в центр
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                // проход вправо-вниз
                while (step.Y <= PMain.Height)
                {
                    while (step.X <= PMain.Width)
                    {
                        PanelGraphics.DrawRectangle(pSquare, step.X, step.Y, (int)(fs.step_grid * pix_to_unit), (int)(fs.step_grid * pix_to_unit));
                        step.X = step.X + (int)(fs.step_grid * pix_to_unit);

                    }
                    step.X = FindCenter(PMain).X;
                    step.Y = step.Y + (int)(fs.step_grid * pix_to_unit);
                }
                // установка в центр
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                // проход влево-вниз
                while (step.Y <= PMain.Height)
                {
                    while (step.X >= 0)
                    {
                        step.X = step.X - (int)(fs.step_grid * pix_to_unit);
                        PanelGraphics.DrawRectangle(pSquare, step.X, step.Y, (int)(fs.step_grid * pix_to_unit), (int)(fs.step_grid * pix_to_unit));
                    }
                    step.X = FindCenter(PMain).X;
                    step.Y = step.Y + (int)(fs.step_grid * pix_to_unit);
                }
            }
            // оси
            PanelGraphics.DrawLine(pAxis, new PointF(0, FindCenter(PMain).Y), new PointF(PMain.Width, FindCenter(PMain).Y));
            PanelGraphics.DrawLine(pAxis, new PointF(FindCenter(PMain).X, 0), new PointF(FindCenter(PMain).X, PMain.Height));
            // штриховки
            if (fs.streak)
            {
                // по оси X
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                while (step.X >= 0)
                {
                    step.X = step.X - (int)(fs.step_streak * pix_to_unit);
                    PanelGraphics.DrawLine(pStreak, step.X, step.Y - 8, step.X, step.Y + 8);
                }
                while (step.X <= PMain.Width)
                {
                    step.X = step.X + (int)(fs.step_streak * pix_to_unit);
                    PanelGraphics.DrawLine(pStreak, step.X, step.Y - 8, step.X, step.Y + 8);
                }
                // по оси Y
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                while (step.Y >= 0)
                {
                    step.Y = step.Y - (int)(fs.step_streak * pix_to_unit);
                    PanelGraphics.DrawLine(pStreak, step.X - 8, step.Y, step.X + 8, step.Y);
                }
                while (step.Y <= PMain.Height)
                {
                    step.Y = step.Y + (int)(fs.step_streak * pix_to_unit);
                    PanelGraphics.DrawLine(pStreak, step.X - 8, step.Y, step.X + 8, step.Y);
                }
            }
            // подписи к штриховке
            if (fs.streak_note)
            {
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                float x = 0, y = 0;
                double w, h;
                while (step.X >= 0)
                {
                    step.X = step.X - (fs.step_streak * pix_to_unit);
                    x = x - fs.step_streak;
                    w = PanelGraphics.MeasureString(x.ToString(), new Font("Consolas", fs.font_size)).Width;
                    h = PanelGraphics.MeasureString(x.ToString(), new Font("Consolas", fs.font_size)).Height;
                    PanelGraphics.DrawString(x.ToString(), new Font("Consolas", fs.font_size), Brushes.Black, step.X - ((float)w / 2), step.Y + ((float)h));
                }
                minx = x; x = 0; step.X = FindCenter(PMain).X;
                while (step.X <= PMain.Width)
                {
                    step.X = step.X + (fs.step_streak * pix_to_unit);
                    x = x + fs.step_streak;
                    w = PanelGraphics.MeasureString(x.ToString(), new Font("Consolas", fs.font_size)).Width;
                    h = PanelGraphics.MeasureString(x.ToString(), new Font("Consolas", fs.font_size)).Height;
                    PanelGraphics.DrawString(x.ToString(), new Font("Consolas", fs.font_size), Brushes.Black, step.X - ((float)w / 2), step.Y + ((float)h));
                }
                maxx = x;
                // по оси Y
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                while (step.Y >= 0)
                {
                    step.Y = step.Y - (fs.step_streak * pix_to_unit);
                    y = y + fs.step_streak;
                    w = PanelGraphics.MeasureString(y.ToString(), new Font("Consolas", fs.font_size)).Width;
                    h = PanelGraphics.MeasureString(y.ToString(), new Font("Consolas", fs.font_size)).Height;
                    PanelGraphics.DrawString(y.ToString(), new Font("Consolas", fs.font_size), Brushes.Black, step.X - ((float)w * 2), step.Y - ((float)h / 2));
                }
                y = 0; step.Y = FindCenter(PMain).Y;
                while (step.Y <= PMain.Height)
                {

                    step.Y = step.Y + (fs.step_streak * pix_to_unit);
                    y = y - fs.step_streak;
                    w = PanelGraphics.MeasureString(y.ToString(), new Font("Consolas", fs.font_size)).Width;
                    h = PanelGraphics.MeasureString(y.ToString(), new Font("Consolas", fs.font_size)).Height;
                    if (y == -fs.step_streak)
                        continue;
                    PanelGraphics.DrawString(y.ToString(), new Font("Consolas", fs.font_size), Brushes.Black, step.X - ((float)w * 2), step.Y - ((float)h / 2));
                }
            }
            // подписи к осям
            if (fs.axis_note)
            {
                PanelGraphics.DrawString("Y", new Font("Consolas", fs.font_size + 4), Brushes.Black, FindCenter(PMain).X+10, 5);  // отрисовка Y
                PanelGraphics.DrawString("X", new Font("Consolas", fs.font_size + 4), Brushes.Black, PMain.Width-20, FindCenter(PMain).Y - 30);  // отрисовка X
            }
            // пунктирный круг
            PanelGraphics.DrawEllipse(pRound, FindCenter(this.PMain).X - pix_to_unit, FindCenter(this.PMain).Y - pix_to_unit, pix_to_unit * 2, pix_to_unit * 2);            
            // Освобождение ресурсов
            PanelGraphics.Dispose(); pAxis.Dispose(); pRound.Dispose(); pSquare.Dispose(); pStreak.Dispose();            
        }
        private void DrawGraph(int f, Color cF, Graphics PanelGraphics)
        {
            Pen pLine = new Pen(cF, 1);            
            switch (f)
            {
                case 0:
                    {
                        cs = new CalcSin(minx, maxx);
                        for (int i = 0; i < cs.Func.Count - 1; i++)
                        {
                            PointF p1 = new PointF(FindCenter(PMain).X + (int)(cs.Func[i].X * pix_to_unit), FindCenter(PMain).Y - (int)(cs.Func[i].Y * pix_to_unit));
                            PointF p2 = new PointF(FindCenter(PMain).X + (int)(cs.Func[i + 1].X * pix_to_unit), FindCenter(PMain).Y - (int)(cs.Func[i + 1].Y * pix_to_unit));
                            PanelGraphics.DrawLine(pLine, p1, p2);
                        }
                    }
                    break;
                case 1:
                    {
                        cp = new CalcPow(minx, maxx);
                        for (int i = 0; i < cp.Func.Count - 1; i++)
                        {
                            PointF p1 = new PointF(FindCenter(PMain).X + (int)(cp.Func[i].X * pix_to_unit), FindCenter(PMain).Y - (int)(cp.Func[i].Y * pix_to_unit));
                            PointF p2 = new PointF(FindCenter(PMain).X + (int)(cp.Func[i + 1].X * pix_to_unit), FindCenter(PMain).Y - (int)(cp.Func[i + 1].Y * pix_to_unit));
                            PanelGraphics.DrawLine(pLine, p1, p2);
                        }
                    }
                    break;
                case 2:
                    {
                        ct = new CalcTg(minx, maxx);
                        for (int i = 0; i < ct.Func.Count - 1; i++)
                        {
                            PointF p1 = new PointF(FindCenter(PMain).X + (int)(ct.Func[i].X * pix_to_unit), FindCenter(PMain).Y - (int)(ct.Func[i].Y * pix_to_unit));
                            PointF p2 = new PointF(FindCenter(PMain).X + (int)(ct.Func[i + 1].X * pix_to_unit), FindCenter(PMain).Y - (int)(ct.Func[i + 1].Y * pix_to_unit));
                            PanelGraphics.DrawLine(pLine, p1, p2);
                        }
                    }
                    break;
                case 3:
                    {
                        cc = new CalcCube(minx, maxx);
                        for (int i = 0; i < cc.Func.Count - 1; i++)
                        {
                            PointF p1 = new PointF(FindCenter(PMain).X + (int)(cc.Func[i].X * pix_to_unit), FindCenter(PMain).Y - (int)(cc.Func[i].Y * pix_to_unit));
                            PointF p2 = new PointF(FindCenter(PMain).X + (int)(cc.Func[i + 1].X * pix_to_unit), FindCenter(PMain).Y - (int)(cc.Func[i + 1].Y * pix_to_unit));
                            PanelGraphics.DrawLine(pLine, p1, p2);
                        }
                    }
                    break;
                case 4:
                    {
                        cl = new CalcLinear(minx,maxx);
                        for (int i = 0; i < cl.Func.Count - 1; i++)
                        {
                            PointF p1 = new PointF(FindCenter(PMain).X + (int)(cl.Func[i].X * pix_to_unit), FindCenter(PMain).Y - (int)(cl.Func[i].Y * pix_to_unit));
                            PointF p2 = new PointF(FindCenter(PMain).X + (int)(cl.Func[i + 1].X * pix_to_unit), FindCenter(PMain).Y - (int)(cl.Func[i + 1].Y * pix_to_unit));
                            PanelGraphics.DrawLine(pLine, p1, p2);
                        }
                    }
                    break;
            }            
            PanelGraphics.Dispose(); pLine.Dispose();
            
        }
        private void DrawFonScaled(FonState fs, Graphics PanelGraphics)  // отрисовка фона графика
        {
            float scaled = scale / 100;
            float font = fs.font_size * scaled;
            if (font < 6)
                font = 6;
            bool streak_note = fs.streak_note;
            if (scale <= 60)
                streak_note = false;
            Pen pAxis = new Pen(Color.Black, 2);                // перо для отрисовки осей 
            Pen pRound = new Pen(Color.Red, 1);                 // перо для отрисовки круга по единице в центре
            Pen pSquare = new Pen(fs.ColorGrid, 1);          // перо для отрисовки сетки
            Pen pStreak = new Pen(Color.Black, 1);              // перо для отрисовки штриховки
            pRound.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;  // пуктир для круга            
            // отрисовка фонового цвета
            if (!fs.gradient)
            {
                PanelGraphics.FillRectangle(new SolidBrush(fs.MainColor), PMain.ClientRectangle);
            }
            else
            {
                if (fs.gradient_direct)
                {
                    LinearGradientBrush LGB = new LinearGradientBrush(PMain.ClientRectangle, fs.StartGradient, fs.EndGradiend, 90F);
                    PanelGraphics.FillRectangle(LGB, PMain.ClientRectangle);
                }
                else
                {
                    LinearGradientBrush LGB = new LinearGradientBrush(PMain.ClientRectangle, fs.StartGradient, fs.EndGradiend, 0F);
                    PanelGraphics.FillRectangle(LGB, PMain.ClientRectangle);
                }
            }
            // клетки
            PointF step = new PointF(FindCenter(PMain).X, FindCenter(PMain).Y);
            if (fs.grid)
            {
                // начинаем с центра
                // проход лево-верх
                while (step.Y >= 0)
                {
                    step.Y = step.Y - (fs.step_grid * scaled * pix_to_unit);
                    while (step.X >= 0)
                    {
                        step.X = step.X - (fs.step_grid * scaled * pix_to_unit);
                        PanelGraphics.DrawRectangle(pSquare, step.X, step.Y, (fs.step_grid * scaled * pix_to_unit), (fs.step_grid * scaled * pix_to_unit));
                    }
                    step.X = FindCenter(PMain).X;
                }
                // установка в центр
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                // проход вправо-верх
                while (step.Y >= 0)
                {
                    step.Y = step.Y - (fs.step_grid * scaled * pix_to_unit);
                    while (step.X <= PMain.Width)
                    {
                        PanelGraphics.DrawRectangle(pSquare, step.X, step.Y, (fs.step_grid * scaled * pix_to_unit), (fs.step_grid * scaled * pix_to_unit));
                        step.X = step.X + (fs.step_grid * scaled * pix_to_unit);

                    }
                    step.X = FindCenter(PMain).X;
                }
                // установка в центр
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                // проход вправо-вниз
                while (step.Y <= PMain.Height)
                {
                    while (step.X <= PMain.Width)
                    {
                        PanelGraphics.DrawRectangle(pSquare, step.X, step.Y, (fs.step_grid * scaled * pix_to_unit), (fs.step_grid * scaled * pix_to_unit));
                        step.X = step.X + (fs.step_grid * scaled * pix_to_unit);

                    }
                    step.X = FindCenter(PMain).X;
                    step.Y = step.Y + (fs.step_grid * scaled * pix_to_unit);
                }
                // установка в центр
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                // проход влево-вниз
                while (step.Y <= PMain.Height)
                {
                    while (step.X >= 0)
                    {
                        step.X = step.X - (fs.step_grid * scaled * pix_to_unit);
                        PanelGraphics.DrawRectangle(pSquare, step.X, step.Y, (fs.step_grid * scaled * pix_to_unit), (fs.step_grid * scaled * pix_to_unit));
                    }
                    step.X = FindCenter(PMain).X;
                    step.Y = step.Y + (fs.step_grid * scaled * pix_to_unit);
                }
            }
            // оси
            PanelGraphics.DrawLine(pAxis, new PointF(0, FindCenter(PMain).Y), new PointF(PMain.Width, FindCenter(PMain).Y));
            PanelGraphics.DrawLine(pAxis, new PointF(FindCenter(PMain).X, 0), new PointF(FindCenter(PMain).X, PMain.Height));
            // штриховки
            if (fs.streak)
            {
                // по оси X
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                while (step.X >= 0)
                {
                    step.X = step.X - (fs.step_streak * scaled * pix_to_unit);
                    PanelGraphics.DrawLine(pStreak, step.X, step.Y - 8 * scaled, step.X, step.Y + 8 * scaled);
                }
                while (step.X <= PMain.Width)
                {
                    step.X = step.X + (fs.step_streak * scaled * pix_to_unit);
                    PanelGraphics.DrawLine(pStreak, step.X, step.Y - 8 * scaled, step.X, step.Y + 8 * scaled);
                }
                // по оси Y
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                while (step.Y >= 0)
                {
                    step.Y = step.Y - (fs.step_streak * scaled * pix_to_unit);
                    PanelGraphics.DrawLine(pStreak, step.X - 8 * scaled, step.Y, step.X + 8 * scaled, step.Y);
                }
                while (step.Y <= PMain.Height)
                {
                    step.Y = step.Y + (fs.step_streak * scaled * pix_to_unit);
                    PanelGraphics.DrawLine(pStreak, step.X - 8 * scaled, step.Y, step.X + 8 * scaled, step.Y);
                }
            }
            // подписи к штриховке
            if (streak_note)
            {
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                float x = 0, y = 0;
                double w, h;
                while (step.X >= 0)
                {
                    step.X = step.X - (fs.step_streak * scaled * pix_to_unit);
                    x = x - fs.step_streak;
                    w = PanelGraphics.MeasureString(x.ToString(), new Font("Consolas", font)).Width;
                    h = PanelGraphics.MeasureString(x.ToString(), new Font("Consolas", font)).Height;
                    PanelGraphics.DrawString(x.ToString(), new Font("Consolas", font), Brushes.Black, step.X - ((float)w/2), step.Y + ((float)h));
                }
                x = 0; step.X = FindCenter(PMain).X;
                while (step.X <= PMain.Width)
                {
                    step.X = step.X + (fs.step_streak * scaled * pix_to_unit);
                    x = x + fs.step_streak;
                    w = PanelGraphics.MeasureString(x.ToString(), new Font("Consolas", font)).Width;
                    h = PanelGraphics.MeasureString(x.ToString(), new Font("Consolas", font )).Height;
                    PanelGraphics.DrawString(x.ToString(), new Font("Consolas", font), Brushes.Black, step.X - ((float)w/2), step.Y + ((float)h));
                }                
                // по оси Y
                step.X = FindCenter(PMain).X;
                step.Y = FindCenter(PMain).Y;
                while (step.Y >= 0)
                {
                    step.Y = step.Y - (fs.step_streak * scaled * pix_to_unit);
                    y = y + fs.step_streak;
                    w = PanelGraphics.MeasureString(y.ToString(), new Font("Consolas", font)).Width;
                    h = PanelGraphics.MeasureString(y.ToString(), new Font("Consolas", font)).Height;
                    PanelGraphics.DrawString(y.ToString(), new Font("Consolas", font), Brushes.Black, step.X - ((float)w*2), step.Y - ((float)h/2));
                }
                y = 0; step.Y = FindCenter(PMain).Y;
                while (step.Y <= PMain.Height)
                {

                    step.Y = step.Y + (fs.step_streak * scaled * pix_to_unit);
                    y = y - fs.step_streak;
                    w = PanelGraphics.MeasureString(y.ToString(), new Font("Consolas", font)).Width;
                    h = PanelGraphics.MeasureString(y.ToString(), new Font("Consolas", font)).Height;
                    if (y == -fs.step_streak)
                        continue;
                    PanelGraphics.DrawString(y.ToString(), new Font("Consolas", font), Brushes.Black, step.X - ((float)w * 2), step.Y - ((float)h / 2));
                }
            }
            // подписи к осям
            if (fs.axis_note)
            {
                PanelGraphics.DrawString("Y", new Font("Consolas", fs.font_size + 4), Brushes.Black, FindCenter(PMain).X + 10, 5);  // отрисовка Y
                PanelGraphics.DrawString("X", new Font("Consolas", fs.font_size + 4), Brushes.Black, PMain.Width - 20, FindCenter(PMain).Y - 30);  // отрисовка X
            }
            // пунктирный круг
            PanelGraphics.DrawEllipse(pRound, FindCenter(this.PMain).X - pix_to_unit*scaled, FindCenter(this.PMain).Y - pix_to_unit*scaled, pix_to_unit * 2 * scaled, pix_to_unit * 2 * scaled);
            // Освобождение ресурсов
            
        }
        private void DrawGraphScaled(int f, Color cF, Graphics PanelGraphics)
        {
            float scaled = scale / 100;
            Pen pLine = new Pen(cF, 1);
            switch (f)
            {
                case 0:
                    {
                        cs = new CalcSin(minx, maxx);
                        for (int i = 0; i < cs.Func.Count - 1; i++)
                        {
                            PointF p1 = new PointF(FindCenter(PMain).X + (int)(cs.Func[i].X * pix_to_unit*scaled), FindCenter(PMain).Y - (int)(cs.Func[i].Y * pix_to_unit * scaled));
                            PointF p2 = new PointF(FindCenter(PMain).X + (int)(cs.Func[i + 1].X * pix_to_unit * scaled), FindCenter(PMain).Y - (int)(cs.Func[i + 1].Y * pix_to_unit * scaled));
                            PanelGraphics.DrawLine(pLine, p1, p2);
                        }
                    }
                    break;
                case 1:
                    {
                        cp = new CalcPow(minx, maxx);
                        for (int i = 0; i < cp.Func.Count - 1; i++)
                        {
                            PointF p1 = new PointF(FindCenter(PMain).X + (int)(cp.Func[i].X * pix_to_unit * scaled), FindCenter(PMain).Y - (int)(cp.Func[i].Y * pix_to_unit * scaled));
                            PointF p2 = new PointF(FindCenter(PMain).X + (int)(cp.Func[i + 1].X * pix_to_unit * scaled), FindCenter(PMain).Y - (int)(cp.Func[i + 1].Y * pix_to_unit * scaled));
                            PanelGraphics.DrawLine(pLine, p1, p2);
                        }
                    }
                    break;
                case 2:
                    {
                        ct = new CalcTg(minx, maxx);
                        for (int i = 0; i < ct.Func.Count - 1; i++)
                        {
                            PointF p1 = new PointF(FindCenter(PMain).X + (int)(ct.Func[i].X * pix_to_unit * scaled), FindCenter(PMain).Y - (int)(ct.Func[i].Y * pix_to_unit * scaled));
                            PointF p2 = new PointF(FindCenter(PMain).X + (int)(ct.Func[i + 1].X * pix_to_unit * scaled), FindCenter(PMain).Y - (int)(ct.Func[i + 1].Y * pix_to_unit * scaled));
                            PanelGraphics.DrawLine(pLine, p1, p2);
                        }
                    }
                    break;
                case 3:
                    {
                        cc = new CalcCube(minx, maxx);
                        for (int i = 0; i < cc.Func.Count - 1; i++)
                        {
                            PointF p1 = new PointF(FindCenter(PMain).X + (int)(cc.Func[i].X * pix_to_unit * scaled), FindCenter(PMain).Y - (int)(cc.Func[i].Y * pix_to_unit * scaled));
                            PointF p2 = new PointF(FindCenter(PMain).X + (int)(cc.Func[i + 1].X * pix_to_unit * scaled), FindCenter(PMain).Y - (int)(cc.Func[i + 1].Y * pix_to_unit * scaled));
                            PanelGraphics.DrawLine(pLine, p1, p2);
                        }
                    }
                    break;
                case 4:
                    {
                        cl = new CalcLinear(minx, maxx);
                        for (int i = 0; i < cl.Func.Count - 1; i++)
                        {
                            PointF p1 = new PointF(FindCenter(PMain).X + (int)(cl.Func[i].X * pix_to_unit * scaled), FindCenter(PMain).Y - (int)(cl.Func[i].Y * pix_to_unit * scaled));
                            PointF p2 = new PointF(FindCenter(PMain).X + (int)(cl.Func[i + 1].X * pix_to_unit * scaled), FindCenter(PMain).Y - (int)(cl.Func[i + 1].Y * pix_to_unit * scaled));
                            PanelGraphics.DrawLine(pLine, p1, p2);
                        }
                    }
                    break;
            }
            

        }

        private void BBack_Click(object sender, EventArgs e)
        {
            FormDialog FD = new FormDialog(this);
            FD.Location = new Point(100, 100);

            if (FD.ShowDialog() == DialogResult.OK)
            {
                DrawFon(FonGrafic, Graphics.FromImage(bmp));
                DrawGraph(fun, cFun, Graphics.FromImage(bmp));
                RedrawScaled();
                if (scale == 100)
                    pbPanel.Image = bmp;
                else
                    pbPanel.Image = bmpbuf;
            }            
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Изображение .bmp| *.bmp";
            if (sfd.ShowDialog() == DialogResult.OK) 
            {
                if (scale != 100)
                    bmpbuf.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                else
                    bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        private void BRandom_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            fun = r.Next(0, 5);           

            DrawFon(FonGrafic, Graphics.FromImage(bmp));
            DrawGraph(fun, cFun, Graphics.FromImage(bmp));
            RedrawScaled();
            if (scale == 100)
                pbPanel.Image = bmp;
            else
                pbPanel.Image = bmpbuf;
        }

        private void pbPanel_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startX = e.X;
            startY = e.Y;
        }

        private void pbPanel_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            count = 0;
        }

        private void BColor_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog(); 
                if (CD.ShowDialog() == DialogResult.OK)
            {
                cFun = CD.Color;                

                DrawFon(FonGrafic, Graphics.FromImage(bmp));
                DrawGraph(fun, cFun, Graphics.FromImage(bmp));
                RedrawScaled();
                if (scale == 100)
                    pbPanel.Image = bmp;
                else
                    pbPanel.Image = bmpbuf;
            }
        }
        private void pbPanel_MouseMove(object sender, MouseEventArgs e)
        {
            LPointValue.Text = e.X.ToString() + ';' + e.Y.ToString();            
            if ((this.LPointText.Size.Width + this.LPointValue.Size.Width) <= (this.GBRight.Width - 12))
                this.LPointValue.Location = new Point(this.GBRight.Width - this.LPointValue.Width - 6, this.LPointValue.Location.Y);
            else
                this.LPointValue.Location = new Point(this.LPointText.Location.X + this.LPointText.Width + 6, this.LPointValue.Location.Y);
            // перемещение
            if (drag)
            {
                if (scale > 100)
            {
                float deltaX, deltaY;
                deltaX = ((startX - e.X) / (scale / 100) / Wbuf) * (PMain.Width - Wbuf);
                deltaY = ((startY - e.Y) / (scale / 100) / Hbuf) * (PMain.Width - Wbuf);
                oX -= deltaX;
                if (oX > 0)
                    oX = 0;
                if (oX < -PMain.Width + Wbuf)
                    oX = -PMain.Width + Wbuf;
                oY -= deltaY;
                if (oY > 0)
                    oY = 0;
                if (oY < -PMain.Height + Hbuf)
                    oY = -PMain.Height + Hbuf;
                    if (count %3 == 0)
                    {
                        RedrawScaled();
                        startX = e.X;
                        startY = e.Y;
                    }
                if (scale == 100)
                    pbPanel.Image = bmp;
                else
                    pbPanel.Image = bmpbuf;
                    count++;
            }
            }
        }
                
        private void RedrawScaled()
        {
            Graphics g = Graphics.FromImage(bmpbuf);
            if (scale >= 100)
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.ScaleTransform(scale / 100, scale / 100);
                g.TranslateTransform(oX, oY);
                g.DrawImage(bmp, new Point(0, 0));
                g.Dispose();
            }
            else
            {
                DrawFonScaled(FonGrafic, g);
                DrawGraphScaled(fun, cFun, g);
                g.Dispose();
            }    
            
            
        }  
    }
}
