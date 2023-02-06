using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ключ

{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        bool drawing;
        int str;
        Circle[,] Keys;
        List<Point> Password;
        List<Point> TruePassword;
        bool newPassword;
        string path = Application.StartupPath + @"\password.txt";
        public Form1()
        {
            InitializeComponent();
            Keys = new Circle[3,3];
            Password = new List<Point>();
            TruePassword = new List<Point>();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            newPassword = false;
        }

        private void SetNewPassword()
        {
            TruePassword.Clear();
            StreamReader SR = new StreamReader(path);
            while (!SR.EndOfStream)
            {
                string buf = SR.ReadLine();
                string[] split = buf.Split(',');
                if (split.Length == 2)
                {
                    Point p = new Point(int.Parse(split[0]), int.Parse(split[1]));
                    TruePassword.Add(p);
                }
            }
            SR.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            str = pictureBox1.Width / 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Keys[i, j] = new Circle((j+1)*100, (i+1)*100, str);
                }
            }
            DrawFon();
            SetNewPassword();
        }
        private void bNew_Click(object sender, EventArgs e)
        {
            newPassword = true;            
        }

        private void DrawFon()
        {
            g.Clear(Color.White);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    g.FillEllipse(new SolidBrush(Color.Blue), Keys[i, j].Center.X - Keys[i, j].Radius, Keys[i, j].Center.Y - Keys[i, j].Radius,
                        2* Keys[i, j].Radius, 2 * Keys[i, j].Radius);
                }
            }

            pictureBox1.Image = bmp;
        }

        private void PB_MD(object sender, MouseEventArgs e)
        {
            Password.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (SCD(e.Location.X, Keys[i, j].Center.X-Keys[i,j].Radius, Keys[i, j].Center.X + Keys[i, j].Radius) &&
                        SCD(e.Location.Y, Keys[i, j].Center.Y - Keys[i, j].Radius, Keys[i, j].Center.Y + Keys[i, j].Radius))
                    {
                        Password.Add(Keys[i,j].Center);
                        Keys[i, j].pass = true;
                        drawing = true;
                        return;
                    }
                }
            }
        }

        private void PB_MM(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                DrawFon();
                if (Password.Count == 1)
                {
                    g.DrawLine(new Pen(Color.Blue, 3), Password[Password.Count-1], e.Location);
                }
                else
                {
                    for (int i = 0; i < Password.Count; i++)
                    {
                        if (i == Password.Count-1)
                        {
                            g.DrawLine(new Pen(Color.Blue, 3), Password[Password.Count - 1], e.Location);
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Blue, 3), Password[i], Password[i + 1]);
                        }
                    }
                    
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!Keys[i, j].pass)
                        {
                            
                            if (SCD(e.Location.X, Keys[i, j].Center.X - Keys[i, j].Radius, Keys[i, j].Center.X + Keys[i, j].Radius) &&
                                SCD(e.Location.Y, Keys[i, j].Center.Y - Keys[i, j].Radius, Keys[i, j].Center.Y + Keys[i, j].Radius))
                            {
                                
                                bool nei_circle = true; 

                                if (Password.Count > 0)
                                {
                                    bool checkX = Math.Abs((Password[Password.Count - 1].X - 50) / 100 - j) <= 1;
                                    bool checkY = Math.Abs((Password[Password.Count - 1].Y - 50) / 100 - i) <= 1;

                                    nei_circle = checkX & checkY;
                                }

                                // если соседний круг
                                if (nei_circle)
                                {




                                    Password.Add(Keys[i, j].Center);
                                    Keys[i, j].pass = true;
                                    
                                    if (Password.Count == 6)
                                    {
                                        if (newPassword)
                                        {
                                            // запись в файл
                                            StreamWriter SW = new StreamWriter(path);
                                            for (int k = 0; k < Password.Count; k++)
                                            {
                                                SW.WriteLine(Password[k].X.ToString() + ',' + Password[k].Y.ToString());
                                            }
                                            SW.Close();
                                            SetNewPassword();

                                            newPassword = false;
                                            drawing = false;
                                            Password.Clear();
                                            for (int a = 0; a < 3; a++)
                                            {
                                                for (int b = 0; b < 3; b++)
                                                {
                                                    Keys[a, b].pass = false;
                                                }
                                            }
                                            DrawFon();
                                            return;
                                        }
                                        else
                                        {
                                            // сравнение паролей
                                            if (AreEqual(Password, TruePassword))
                                                MessageBox.Show("Пароль совпал!");
                                            else
                                                MessageBox.Show("Пароль неверный!");
                                            drawing = false;
                                            Password.Clear();
                                            for (int a = 0; a < 3; a++)
                                            {
                                                for (int b = 0; b < 3; b++)
                                                {
                                                    Keys[a, b].pass = false;
                                                }
                                            }
                                            DrawFon();
                                            return;
                                        }
                                    }
                                }
                                return;
                            }
                        }
                    }
                }

            }
        }

        private void PB_MU(object sender, MouseEventArgs e)
        {
            drawing = false;
            Password.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Keys[i, j].pass = false;
                }
            }
                    DrawFon();
        }

        public bool SCD(float check, float left, float right)   // Strict Check Diapason
        {
            if (check >= left && check <= right)
                return true;
            else
                return false;
        }

        public bool AreEqual(List<Point> L1, List<Point> L2)
        {
            if (L1 == null)
                return false;
            if (L2 == null)
                return false;
            if (L1.Count != L2.Count)
                return false;          

            for (int i = 0; i < L1.Count; i++)
            {
                if (L1[i] != L2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
    public class Circle
    {
        public Point Center;
        public int Radius;
        public int x, y;
        public bool pass;

        public Circle(int x1, int y1, int str)
        {
            pass = false;
            Radius = 15;
            Center = new Point(x1-str/2, y1-str/2);
            x = x1 / 100 - 1;
            y = y1 / 100 - 1;
        }

        

    }   

}
