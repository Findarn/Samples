using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Лабиринт
{
    public partial class Labirint : Form
    {
        class Cell
        {
            public PictureBox LPB;     //графическая часть клетки лабиринта
            public int state;          //статус ячейки 1 - проходимая, 2 - непроходимая, 3 - выход, 4 - игрок, 0 - нераспределённая
            public int ves;            //вес клетки при распространении волны
            public int state_wave;     //0 - волна не касалась ячейки, 1 - источник, 2 - распространение
            public int indexi;         //индекс строки в матрице
            public int indexj;         //индекс столбца в матрице
            public Cell(int i, int j, float meas, Labirint link)
            {
                LPB = new PictureBox();             //создаём Picturebox
                LPB.Margin = new Padding(0);        //убираем внешние отступы
                LPB.Padding = new Padding(0);       //убираем внутренние отступы
                LPB.Size = new System.Drawing.Size(Convert.ToInt32(meas), Convert.ToInt32(meas));   //задаем размер Picturebox
                LPB.BackColor = Color.Lavender;     //задаём фоновый цвет
                using (Pen p = new Pen(Color.Black, 2))     //создаём инструмент рисования прямых
                {
                    Bitmap b = new Bitmap(LPB.Width, LPB.Height);   //создаём изображение (полотно)
                    using (Graphics g = Graphics.FromImage(b))      //используем Graphics для рисования
                    {
                        g.Clear(Color.White);                                   //заполняем полотно белым цветом
                        g.DrawRectangle(p, 1, 1, LPB.Width - 1, LPB.Height - 1);    //по краям рисуем прямоугольник - рамку
                    }
                    LPB.Image = b;      //помещаем нарисованное изображение в PictureBox
                }
                state_wave = 0;         //начальное значение состояния волны
                state = 0;              //начальное значение статуса ячейки
                ves = -1;               //начальный вес ячейки
                indexi = i;             //индекс среди строк
                indexj = j;             //индекс среди столбцов
            }   //конструктор по умолчанию - создаёт экземпляр класса (объект)
            public void setBlack()
            {
                using (Pen p = new Pen(Color.Black, 2))     //создаём инструмент рисования прямых
                {
                    Bitmap b = new Bitmap(LPB.Width, LPB.Height);   //создаём изображение (полотно)
                    using (Graphics g = Graphics.FromImage(b))      //используем Graphics для рисования
                    {
                        g.Clear(Color.Black);                       //заполняем полотно чёрным цветом      
                    }
                    LPB.Image = b;      //помещаем изображение в PictureBox
                }
                state = 2;  //задаём статус ячейки - непроходимая
            }   //перекрашивает ячейку в чёрный цвет - препятствие
            public void setWhite()
            {
                using (Pen p = new Pen(Color.Black, 2))     //создаём инструмент рисования прямых
                {
                    Bitmap b = new Bitmap(LPB.Width, LPB.Height);   //создаём изображение (полотно)
                    using (Graphics g = Graphics.FromImage(b))      //используем Graphics для рисования
                    {
                        g.Clear(Color.White);                       //заполняем полотно белым цветом   
                    }
                    LPB.Image = b;                           //помещаем изображение в PictureBox
                }
                state = 1;      //задаём статус ячейки - проходимая
            }   //перекрашивает ячейку в белый цвет - проходимая клетка
            public void setGreen()
            {
                using (Pen p = new Pen(Color.Black, 2))     //создаём инструмент рисования прямых
                {
                    Bitmap b = new Bitmap(LPB.Width, LPB.Height);       //создаём изображение (полотно)
                    using (Graphics g = Graphics.FromImage(b))          //используем Graphics для рисования
                    {
                        g.Clear(Color.Green);       //заполняем полотно зелёным цветом
                        Size str_ves = TextRenderer.MeasureText("В", new Font("Courier", LPB.Image.Width - 1));     //определяем размер текста
                        int wstart = (LPB.Image.Width - str_ves.Width) / 2;         //определяем, откуда начать отрисовку текста по ширине
                        int hstart = (LPB.Image.Height - str_ves.Height) / 2;       //определяем, откуда начать отрисовку текста по высоте
                        g.DrawString("В", new Font("Courier", LPB.Image.Width - 1), new SolidBrush(Color.WhiteSmoke), wstart + 1, hstart);  //отрисовываем текст
                    }
                    LPB.Image = b;      //помещаем изображение в PictureBox
                }
                state = 3;      //задаём статус ячейки - выход
            }   //перекрашивает ячейку в зелёный цвет - точка выхода
            public void setYellow()
            {
                using (Pen p = new Pen(Color.Black, 2))     //создаём инструмент рисования прямых
                {
                    Bitmap b = new Bitmap(LPB.Width, LPB.Height);       //создаём изображение (полотно)
                    using (Graphics g = Graphics.FromImage(b))          //используем Graphics для рисования
                    {
                        g.Clear(Color.Yellow);                  //заполняем полотно жёлтым цветом           
                        Size str_ves = TextRenderer.MeasureText("И", new Font("Courier", LPB.Image.Width - 1)); //определяем размер текста
                        int wstart = (LPB.Image.Width - str_ves.Width) / 2;     //определяем, откуда начать отрисовку текста по ширине
                        int hstart = (LPB.Image.Height - str_ves.Height) / 2;   //определяем, откуда начать отрисовку текста по высоте
                        g.DrawString("И", new Font("Courier", LPB.Image.Width - 1), new SolidBrush(Color.Black), wstart + 1, hstart);   //отрисовываем текст
                    }
                    LPB.Image = b;          //помещаем изображение в PictureBox              
                }
                state = 4;      //задаём статус ячейки - игрок
            }  //перекрашивает ячейку в жёлтый цвет - ячейка игрока
            public void setUndef()
            {
                using (Pen p = new Pen(Color.Black, 2))     //создаём инструмент рисования прямых
                {
                    Bitmap b = new Bitmap(LPB.Width, LPB.Height);       //создаём изображение (полотно)
                    using (Graphics g = Graphics.FromImage(b))          //используем Graphics для рисования
                    {
                        g.Clear(Color.White);                                        //заполняем полотно жёлтым цветом   
                        g.DrawRectangle(p, 1, 1, LPB.Width - 1, LPB.Height - 1);     //отрисовываем прямоугольник по границам
                    }
                    LPB.Image = b;      //помещаем изображение в PictureBox  
                    state = 0;
                    ves = -1;       //задаём начальные состояния параметрам ячейки
                    state_wave = 0;
                }
            }   //убираем цвет ячейки, заменяя её на неопределённое поле
            public void setSky()
            {
                using (Pen p = new Pen(Color.Black, 2))     //создаём инструмент рисования прямых
                {
                    Bitmap b = new Bitmap(LPB.Width, LPB.Height);       //создаём изображение (полотно)
                    using (Graphics g = Graphics.FromImage(b))          //используем Graphics для рисования
                    {
                        SolidBrush sb = new SolidBrush(Color.White);    //создаём кисть белого цвета
                        g.Clear(Color.SkyBlue);         //заполняем полотно голубым цветом
                        RectangleF buffer = new RectangleF(0 + LPB.Width / 4, 0 + LPB.Height / 4, LPB.Width / 4, LPB.Height / 4);   //определяем параметры прямоугольника
                        float startW = (LPB.Image.Width - buffer.Width) / 2;        //определяем начальную позицию отрисовки по ширине
                        float startH = (LPB.Image.Height - buffer.Height) / 2;      //определяем начальную позицию отрисовки по высоте
                        g.DrawEllipse(p, startW - 1, startH - 1, buffer.Width, buffer.Height);  //рисуем круг, вписанный в прямоугольник
                        g.FillEllipse(sb, startW - 1, startH - 1, buffer.Width, buffer.Height); //заполняем круг белым цветом
                        sb.Dispose();   //освобождаем ресурсы, выделенные под кисть
                    }
                    LPB.Image = b;      //помещаем изображение в PictureBox
                }
            }     //перекрашивает ячейку в голубой - распространение волны
            public void setBlue()
            {
                using (Pen p = new Pen(Color.Black, 2))     //создаём инструмент рисования прямых
                {
                    Bitmap b = new Bitmap(LPB.Width, LPB.Height);       //создаём изображение (полотно)
                    using (Graphics g = Graphics.FromImage(b))          //используем Graphics для рисования
                    {
                        g.Clear(Color.Blue);                    //заполняем полотно синим цветом
                        string buf = Convert.ToString(ves);     //переводим значение веса ячейки (число) в строку
                        float fontsize = 10;                    //задаем начальный размер шрифта - 10
                        switch (buf.Length)     //анализируем количество цифр веса
                        {
                            case 1: fontsize = (LPB.Image.Width) - 1; break;
                            case 2: fontsize = ((LPB.Image.Width) / 2); break;  //в зависимости от количества цифр изменяем размер шрифта
                            case 3: fontsize = ((LPB.Image.Width) / 3); break;
                            case 4: fontsize = ((LPB.Image.Width) / 4); break;
                        }
                        Size str_ves = TextRenderer.MeasureText(Convert.ToString(ves), new Font("Courier", fontsize));  //определяем размер надписи веса ячейки
                        int wstart = (LPB.Image.Width - str_ves.Width) / 2;         //определяем начальную координату для рисования строки (веса) по ширине
                        int hstart = (LPB.Image.Height - str_ves.Height) / 2;       //определяем начальную координату для рисования строки (веса) по высоте
                        g.DrawString(Convert.ToString(ves), new Font("Courier", fontsize), new SolidBrush(Color.WhiteSmoke), wstart + 1, hstart);   //рисуем строку (вес)
                    }
                    LPB.Image = b;      //помещаем изображение в PictureBox
                }
            }    //перекрашивает ячейку в синей - источник волны
            public void setGreenRoute()
            {
                using (Pen p = new Pen(Color.Black, 2))     //создаём инструмент рисования прямых
                {
                    Bitmap b = new Bitmap(LPB.Width, LPB.Height);       //создаём изображение (полотно)
                    using (Graphics g = Graphics.FromImage(b))          //используем Graphics для рисования
                    {
                        g.Clear(Color.Green);                           //заполняем полотно зелёным цветом
                        string buf = Convert.ToString(ves);             //переводим значение веса ячейки (число) в строку
                        float fontsize = 10;                            //задаем начальный размер шрифта - 10
                        switch (buf.Length)     //анализируем количество цифр веса
                        {
                            case 1: fontsize = (LPB.Image.Width) - 1; break;
                            case 2: fontsize = ((LPB.Image.Width) / 2); break;
                            case 3: fontsize = ((LPB.Image.Width) / 3); break;      //в зависимости от количества цифр изменяем размер шрифта
                            case 4: fontsize = ((LPB.Image.Width) / 4); break;
                        }
                        Size str_ves = TextRenderer.MeasureText(Convert.ToString(ves), new Font("Courier", fontsize));  //определяем размер надписи веса ячейки
                        int wstart = (LPB.Image.Width - str_ves.Width) / 2;     //определяем начальную координату для рисования строки (веса) по ширине
                        int hstart = (LPB.Image.Height - str_ves.Height) / 2;   //определяем начальную координату для рисования строки (веса) по высоте
                        g.DrawString(Convert.ToString(ves), new Font("Courier", fontsize), new SolidBrush(Color.WhiteSmoke), wstart + 1, hstart);   //рисуем строку (вес)
                    }
                    LPB.Image = b;      //помещаем изображение в PictureBox
                }
            }   //перекрашивает ячейку в зелёный - клетки маршрута
        }

        Cell[,] Lab = null;                         //Лабиринт - матрица из ячеека
        Cell src = null;                            //Ячейка - первый источник (клетка игрока)           
        Cell pre_exit = null;                       //Ячейка, в окружении которой был найден выход
        List<Cell> Borders = new List<Cell>();      //Список ячеек, которые формируют границу лабиринта
        List<Cell> Free = new List<Cell>();         //Список проходимых ячеек в лабиринте


        public Labirint()
        {
            InitializeComponent();
        }

        private void MenuCreate_Click(object sender, EventArgs e)
        {
            Borders.Clear();        //очистка списка граничных ячеек
            Free.Clear();           //очистка списка проходимых ячеек
            src = null;             //обнуление ссылки на ячейку-источник (игрок)
            pre_exit = null;        //обнуление ссылки на ячейку перед выходом
            LabirintTable.RowCount = 0;                         //обнуление рядов таблицы
            LabirintTable.ColumnCount = 0;                      //обнуление столбцов таблицы
            LabirintTable.Controls.Clear();                     //очистка таблицы от элементов управления
            int measure = Convert.ToInt32(NumSize.Value);       //получение количества ячеек из окна со стрелочками
            float percent;
            percent = LabirintTable.Width / measure;            //делим ширину таблицы на количество ячеек
            int side = Convert.ToInt32(percent);                //получаем размер стороны одной ячейки целым числом
            float sidefloat = side;                             //и в дробном представлении
            LabirintTable.RowCount = measure;                   //устанавливаем количество рядов таблицы = количество элементов
            LabirintTable.ColumnCount = measure;                //устанавливаем количество столбцов таблицы = количество элементов
            LabirintTable.RowStyles.Clear();                                //сбрасываем стиль рядов
            for (int i = 0; i < LabirintTable.RowCount; i++)                //обходим все ряды
            {
                LabirintTable.RowStyles.Add(new RowStyle());                //создаём новый стиль ряда
                LabirintTable.RowStyles[i].SizeType = SizeType.Absolute;    //определяем единицы измерения размеров - абсолютные
                LabirintTable.RowStyles[i].Height = sidefloat;              //высоту строки задаём размером стороны
            }
            LabirintTable.ColumnStyles.Clear();                             //сбрасываем стиль столбцов
            for (int i = 0; i < LabirintTable.ColumnCount; i++)             //обходим все столбцы
            {
                LabirintTable.ColumnStyles.Add(new ColumnStyle());          //создаём новый стиль столбцы
                LabirintTable.ColumnStyles[i].SizeType = SizeType.Absolute; //определяем единицы измерения размеров - абсолютные
                LabirintTable.ColumnStyles[i].Width = sidefloat;            //ширину столбца задаём размером стороны
            }

            Lab = new Cell[measure, measure];           //создаём матрицу ячеек - лабиринт, размерностью NxN, N - число в окне со стрелочками
            for (int i = 0; i < measure; i++)           //обходим лабиринт по строкам
            {
                for (int j = 0; j < measure; j++)       //обходим лабиринт по столбцам
                {
                    Lab[i, j] = new Cell(i, j, side, this);             //создаём по текущему индексу новую ячейку
                    LabirintTable.Controls.Add(Lab[i, j].LPB, j, i);    //на форму по индексу помещаем PictureBox
                }
            }
        }      //пункт меню создаёт поле для лабиринта

        private void MenuGenerate_Click(object sender, EventArgs e)
        {
            if (Lab == null)        //если лабиринт не был создан
            {
                MessageBox.Show("Поле под лабиринт не создано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Borders.Clear();        //очищение списка граничных ячеек
            Free.Clear();           //очищение списка проходимых ячеек
            src = null;             //обнуление ссылки на ячейку-источник (игрока)
            pre_exit = null;        //обнуление ссылки на ячейку-выход

            //1 шаг - определение ячеек границы
            for (int i = 0; i < LabirintTable.RowCount; i++)            //перебор строк
            {
                for (int j = 0; j < LabirintTable.ColumnCount; j++)     //перебор столбцов
                {
                    if (i == 0 || j == 0 || i == LabirintTable.RowCount - 1 || j == LabirintTable.ColumnCount - 1)  // если один из индексов принадлежит границе матрицы
                    {
                        Borders.Add(Lab[i, j]);     //добавляем ячейку в список границ
                        Lab[i, j].setBlack();       //закрашиваем ячейку чёрным цветом
                    }
                    Lab[i, j].state_wave = 0;   //при генерации обнуляем в каждой ячейке статус распространения волны
                    Lab[i, j].ves = -1;         //и вес ячейки
                }
            }
            //2 шаг - определение ячейки выхода
            Random r = new Random();                    //создаём класс, генерирующий случайные числа
            int index = r.Next(0, Borders.Count);       //в индекс записываем случайное число из диапазона от нуля до количества граничных ячеек
            while (Borders[index].indexi == 0 && Borders[index].indexj == 0 ||
                    Borders[index].indexi == LabirintTable.RowCount - 1 && Borders[index].indexj == 0 ||
                    Borders[index].indexi == 0 && Borders[index].indexj == LabirintTable.ColumnCount - 1 ||
                    Borders[index].indexi == LabirintTable.RowCount - 1 && Borders[index].indexj == LabirintTable.ColumnCount - 1)
            //проверяем, не попало ли случайное значение в углы лабиринта - в них не может быть выход
            {
                index = r.Next(0, Borders.Count);       //если попало - выбираем новое случайное значение для индекса
            }
            Lab[Borders[index].indexi, Borders[index].indexj].setGreen();       //по этому случайному индексу в списке границ выбирается одна ячейка и назначается выходом

            //3 шаг - заполнение поля лабиринта препятствиями и проходами
            int l;      //переменная для подсчёта случайных значений
            for (int i = 1; i < LabirintTable.RowCount - 1; i++)              //обходим строки (без граничных)
            {
                for (int j = 1; j < LabirintTable.ColumnCount - 1; j++)       //обходим столбцы (без граничных)
                {
                    l = r.Next(0, 2);           //получаем случайное число - 0 или 1
                    if (l == 1)
                        Lab[i, j].setBlack();   //если 1 - помечаем ячейку как препятствие
                    if (l == 0)
                        Lab[i, j].setWhite();   //если 0 - помечаем ячейку как проходимую
                }
            }

            //4 шаг - дополнительное увеличение количества проходов в лабиринте
            for (int i = 1; i < LabirintTable.RowCount - 1; i += 2)             //проходим каждые две строки
            {
                for (int j = 1; j < LabirintTable.ColumnCount - 1; j += 3)      //проходим каждые три столбца
                {
                    if (Lab[i, j].state == 2)       //если клетка была препятстсвием
                        Lab[i, j].setWhite();       //делаем её проходимой
                }
            }

            //5 шаг - расчистка ячеек перед выходом из лабиринта
            if (Borders[index].indexi == 0)                             //если выход находится в верхней границе
            {
                for (int i = 1; i < LabirintTable.RowCount / 2; i++)
                    Lab[i, Borders[index].indexj].setWhite();           //делаем проходные ячейки от выхода до середины лабиринта
            }

            if (Borders[index].indexj == 0)                             //если выход находится в левой границе
            {
                for (int j = 1; j < LabirintTable.ColumnCount / 2; j++)
                    Lab[Borders[index].indexi, j].setWhite();           //делаем проходные ячейки от выхода до середины лабиринта
            }

            if (Borders[index].indexi == LabirintTable.RowCount - 1)    //если выход находится в нижней границе
            {
                for (int i = LabirintTable.RowCount - 2; i > LabirintTable.RowCount / 2; i--)
                    Lab[i, Borders[index].indexj].setWhite();           //делаем проходные ячейки от выхода до середины лабиринта
            }

            if (Borders[index].indexj == LabirintTable.ColumnCount - 1) //если выход находится в правой границе
            {
                for (int j = LabirintTable.ColumnCount - 2; j > LabirintTable.ColumnCount / 2; j--)
                    Lab[Borders[index].indexi, j].setWhite();           //делаем проходные ячейки от выхода до середины лабиринта
            }

            //6 шаг - определение ячейки игрока
            for (int i = 0; i < LabirintTable.RowCount; i++)            //обходим лабиринт по строкам
            {
                for (int j = 0; j < LabirintTable.ColumnCount; j++)     //обходим лабиринт по столбцам
                {
                    if (Lab[i, j].state == 1)           //если ячейка проходная
                    {
                        Free.Add(Lab[i, j]);            //добавляем её в список проходных ячеек
                    }
                }
            }
            int indexP = r.Next(0, Free.Count);         //получаем случайное значение индекса среди проходимых ячеек           
            Lab[Free[indexP].indexi, Free[indexP].indexj].setYellow();      //помещаем в эту ячейку ячейку игрока
            src = Lab[Free[indexP].indexi, Free[indexP].indexj];            //запоминаем ячейку игрока в src
        }    //пункт меню генерирует в поле лабиринт - границы, выход, препятствия и игрока

        private void MenuPath_Click(object sender, EventArgs e)
        {
            if (Lab == null)        //если лабиринт не существует
            {
                MessageBox.Show("Поле под лабиринт не создано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (src == null)        //если лабиринт не сгенерирован - проверяем по объекту src, который заполняется при генерации
            {
                MessageBox.Show("Лабиринт не сгенерирован!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Cell> Sources = new List<Cell>();       //список источников
            List<Cell> Spreades = new List<Cell>();      //список распространений
            int start_ves = 0;      //начальный вес = 0
            Sources.Add(src);       //добавляем в список источников клетку игрока
            bool exit = false;      //флаг того, что выход найден

            for (int i = 0; i < LabirintTable.RowCount; i++)            //обходим лабиринт по строкам
            {
                for (int j = 0; j < LabirintTable.ColumnCount; j++)     //обходим лабиринт по столбцам
                {
                    if (Lab[i, j].state == 1)           //если ячейка проходная
                    {
                        Lab[i, j].state_wave = 0;       //сбрасываем значение статуса волны
                        Lab[i, j].ves = -1;             //сбрасываем вес
                        Lab[i, j].setWhite();
                        Lab[i, j].LPB.Refresh();
                    }
                }
            }

            //1 часть волнового алгоритма - попытка распространения волны до выхода
            while (Sources.Count != 0)      //пока список источников не пуст
            {
                for (int i = 0; i < Sources.Count; i++)     //перебираем список источников
                {
                    Lab[Sources[i].indexi, Sources[i].indexj].ves = start_ves;      //задаём источнику вес
                    Lab[Sources[i].indexi, Sources[i].indexj].state_wave = 1;       //задаём клетке статус источника
                    //проверка ячейки снизу
                    if (Lab[Sources[i].indexi + 1, Sources[i].indexj].state != 3)   //если ячейка снизу - не выход
                    {
                        if (Lab[Sources[i].indexi + 1, Sources[i].indexj].state == 1 && Lab[Sources[i].indexi + 1, Sources[i].indexj].state_wave == 0)
                        {   //если ячейка снизу проходная и не была задействована в волне раньше
                            Lab[Sources[i].indexi + 1, Sources[i].indexj].state_wave = 2;   //задаём клетке статус распространения
                            Lab[Sources[i].indexi + 1, Sources[i].indexj].setSky();         //красим клетку
                            Lab[Sources[i].indexi + 1, Sources[i].indexj].LPB.Refresh();    //обновляем PictureBox чтобы увидеть изменение цвета
                            Spreades.Add(Lab[Sources[i].indexi + 1, Sources[i].indexj]);    //добавляем клетку в список распространений
                        }
                    }
                    else        //если ячейка снизу - выход
                    {
                        exit = true;    //устанавливаем флаг того, что выход найден
                        pre_exit = Lab[Sources[i].indexi, Sources[i].indexj];   //запоминаем клетку, возле которой найден выход
                        break;      //прекращаем обход списка источников
                    }
                    //проверка ячейки справа
                    if (Lab[Sources[i].indexi, Sources[i].indexj + 1].state != 3)     //если ячейка справа - не выход
                    {
                        if (Lab[Sources[i].indexi, Sources[i].indexj + 1].state == 1 && Lab[Sources[i].indexi, Sources[i].indexj + 1].state_wave == 0)
                        {   //если ячейка справа проходная и не была задействована в волне раньше
                            Lab[Sources[i].indexi, Sources[i].indexj + 1].state_wave = 2;   //задаём клетке статус распространения
                            Lab[Sources[i].indexi, Sources[i].indexj + 1].setSky();         //красим клетку
                            Lab[Sources[i].indexi, Sources[i].indexj + 1].LPB.Refresh();    //обновляем PictureBox чтобы увидеть изменение цвета
                            Spreades.Add(Lab[Sources[i].indexi, Sources[i].indexj + 1]);    //добавляем клетку в список распространений
                        }
                    }
                    else  //если ячейка справа - выход
                    {
                        exit = true;        //устанавливаем флаг того, что выход найден
                        pre_exit = Lab[Sources[i].indexi, Sources[i].indexj];        //запоминаем клетку, возле которой найден выход
                        break;              //прекращаем обход списка источников
                    }
                    //проверка ячейки слева
                    if (Lab[Sources[i].indexi, Sources[i].indexj - 1].state != 3)   //если ячейка слева - не выход
                    {
                        if (Lab[Sources[i].indexi, Sources[i].indexj - 1].state == 1 && Lab[Sources[i].indexi, Sources[i].indexj - 1].state_wave == 0)
                        {   //если ячейка слева проходная и не была задействована в волне раньше
                            Lab[Sources[i].indexi, Sources[i].indexj - 1].state_wave = 2;   //задаём клетке статус распространения
                            Lab[Sources[i].indexi, Sources[i].indexj - 1].setSky();         //красим клетку
                            Lab[Sources[i].indexi, Sources[i].indexj - 1].LPB.Refresh();    //обновляем PictureBox чтобы увидеть изменение цвета
                            Spreades.Add(Lab[Sources[i].indexi, Sources[i].indexj - 1]);    //добавляем клетку в список распространений
                        }
                    }
                    else        //если ячейка слева - выход
                    {
                        exit = true;        //устанавливаем флаг того, что выход найден
                        pre_exit = Lab[Sources[i].indexi, Sources[i].indexj];       //запоминаем клетку, возле которой найден выход
                        break;      //прекращаем обход списка источников
                    }
                    //проверка ячейки сверху
                    if (Lab[Sources[i].indexi - 1, Sources[i].indexj].state != 3)       //если ячейка сверху - не выход
                    {
                        if (Lab[Sources[i].indexi - 1, Sources[i].indexj].state == 1 && Lab[Sources[i].indexi - 1, Sources[i].indexj].state_wave == 0)
                        {   //если ячейка сверху проходная и не была задействована в волне раньше
                            Lab[Sources[i].indexi - 1, Sources[i].indexj].state_wave = 2;   //задаём клетке статус распространения
                            Lab[Sources[i].indexi - 1, Sources[i].indexj].setSky();         //красим клетку
                            Lab[Sources[i].indexi - 1, Sources[i].indexj].LPB.Refresh();    //обновляем PictureBox чтобы увидеть изменение цвета
                            Spreades.Add(Lab[Sources[i].indexi - 1, Sources[i].indexj]);    //добавляем клетку в список распространений
                        }
                    }
                    else    //если ячейка сверху - выход
                    {
                        exit = true;        //устанавливаем флаг того, что выход найден
                        pre_exit = Lab[Sources[i].indexi, Sources[i].indexj];       //запоминаем клетку, возле которой найден выход
                        break;       //прекращаем обход списка источников
                    }
                }
                if (exit == true)   //если выход был найден
                    break;  //прекращаем распространение волны

                System.Threading.Thread.Sleep(300); //задержка 0.3 секунды для анимации алгоритма - отрисовка распространения

                Sources.Clear();        //очищаем список источников
                for (int i = 0; i < Spreades.Count; i++)
                {
                    Sources.Add(Spreades[i]);   //переносим распространения в источники
                }

                start_ves++;            //наращиваем вес
                for (int i = 0; i < Sources.Count; i++)     //обходим список источников
                {
                    Lab[Sources[i].indexi, Sources[i].indexj].ves = start_ves;  //задаём вес
                    Lab[Sources[i].indexi, Sources[i].indexj].setBlue();        //красим клетку
                    Lab[Sources[i].indexi, Sources[i].indexj].LPB.Refresh();    //обновляем PictureBox чтобы увидеть изменение цвета
                }
                System.Threading.Thread.Sleep(300); //задержка 0.3 секунды для анимации алгоритма - отрисовка источников

                Spreades.Clear();       //очищаем список распространения                
            }

            if (exit == false)      //если список источников пуст, и выход не найден
            {
                MessageBox.Show("Маршрута для выхода из лабиринта не существует!", "Решение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //2 часть волнового алгоритма - проход по весу волны от выхода к игроку 
            int iroute, jroute;         //вводим индексы маршрута
            iroute = pre_exit.indexi;   //начальными индексами назначаем
            jroute = pre_exit.indexj;   //индексы ячейки перед выходом
            for (int a = start_ves; a != 0; a--)    //используем максимальный вес как условие для формирования и выхода из цикла
            {
                Lab[iroute, jroute].setGreenRoute();    //помечаем текущую клетку на маршруте зелёным
                Lab[iroute, jroute].LPB.Refresh();      //обновляем PictureBox чтобы увидеть изменение цвета            
                                                        //определяем, где находится следующая клетка маршрута
                if (Lab[iroute, jroute].ves - 1 == Lab[iroute - 1, jroute].ves && Lab[iroute - 1, jroute].state != 4)   //вес следующей клетки должен быть на 1 меньше текущей
                {
                    iroute--;   //клетка находится выше
                }
                else
                {
                    if (Lab[iroute, jroute].ves - 1 == Lab[iroute + 1, jroute].ves && Lab[iroute + 1, jroute].state != 4)   //вес следующей клетки должен быть на 1 меньше текущей
                    {
                        iroute++;   //клетка находится ниже
                    }
                    else
                    {
                        if (Lab[iroute, jroute].ves - 1 == Lab[iroute, jroute - 1].ves && Lab[iroute, jroute - 1].state != 4)   //вес следующей клетки должен быть на 1 меньше текущей
                        {
                            jroute--;   //клетка находится слева
                        }
                        else
                        {
                            if (Lab[iroute, jroute].ves - 1 == Lab[iroute, jroute + 1].ves && Lab[iroute, jroute + 1].state != 4)   //вес следующей клетки должен быть на 1 меньше текущей
                            {
                                jroute++;   //клетка находится справа
                            }
                        }
                    }
                }
                System.Threading.Thread.Sleep(100);     //задержка в 0.1 с для анимации построения маршрута
            }

            //сообщение перед выходом
            MessageBox.Show("Маршрут для выхода из лабиринта построен!", "Решение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuClear_Click(object sender, EventArgs e)
        {
            if (Lab == null)    //если лабиринт не создан
            {
                MessageBox.Show("Поле под лабиринт не создано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            src = null;         //сбрасывем ссылку на источник (клетка игрока)
            pre_exit = null;    //сбрасываем ссылку на ячейку перед выходом
            Borders.Clear();    //очищаем список границ
            Free.Clear();       //очищаем список проходимых ячеек
            for (int i = 0; i < LabirintTable.RowCount; i++)            //обходим поле по строкам
            {
                for (int j = 0; j < LabirintTable.ColumnCount; j++)     //обходим поле по столбцам
                {
                    Lab[i, j].setUndef();       //каждую ячейку помечаем как нераспределённую
                }
            }
        }

    }
}