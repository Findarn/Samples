using System;
using System.Collections.Generic;
using System.Drawing;

namespace Task2
{
    interface IFunction     // интерфейс функции
    {
        float calc(float x);        
    }
    class Calc          // общий класс вычисления функции
    {
        protected List<float> X;
        protected List<float> Y;
        public List<PointF> Func { get; set; }
        
        public Calc(float min, float max)
        {
            X = new List<float>();
            Y = new List<float>();
            Func = new List<PointF>();
            for (float i = min; i < max; i += 0.1f)
                X.Add(i);            
        }

        public virtual float calc(float x)
        {
            return 1f;
        }
    }
    class CalcSin : Calc, IFunction
    {
        public CalcSin(float min, float max)
            : base(min, max)
        {
            for (int i = 0; i < X.Count; i++)
                Y.Add(calc(X[i]));
            for (int i = 0; i < X.Count; i++)
                Func.Add(new PointF(X[i], Y[i]));
        }            
        override public float calc(float x)
        {
            return (float)Math.Round(Math.Sin((double)x), 2);
        }
    }
    class CalcPow : Calc, IFunction
    {
        public CalcPow(float min, float max)
            : base(min, max)
        {
            for (int i = 0; i < X.Count; i++)
                Y.Add(calc(X[i]));
            for (int i = 0; i < X.Count; i++)
                Func.Add(new PointF(X[i], Y[i]));
        }
        override public float calc(float x)
        {
            return (float)Math.Round(Math.Pow((double)x, 2), 2);
        }
    }
    class CalcTg : Calc, IFunction
    {
        public CalcTg(float min, float max)
            :base(min, max)
        {            
            for (int i = 0; i < X.Count; i++)
                Y.Add(calc(X[i]));
            for (int i = 0; i < X.Count; i++)
                Func.Add(new PointF(X[i], Y[i]));
        }
        override public float calc(float x)
        {
            return (float)Math.Round(Math.Tan((double)x), 2);
        }
    }
    class CalcCube : Calc, IFunction
    {
        public CalcCube(float min, float max)
            : base(min, max)
        {
           for (int i = 0; i < X.Count; i++)
                Y.Add(calc(X[i]));
            for (int i = 0; i < X.Count; i++)
                Func.Add(new PointF(X[i], Y[i]));
        }
        override public float calc(float x)
        {
            return (float)Math.Round(Math.Pow((double)x, 3), 2);
        }
    }
    class CalcLinear : Calc, IFunction
    {        
        public CalcLinear(float min, float max)
            : base(min, max)
        {            
            for (int i = 0; i < X.Count; i++)
                Y.Add(calc(X[i]));
            for (int i = 0; i < X.Count; i++)
                Func.Add(new PointF(X[i], Y[i]));
        }
        override public float calc(float x)
        {
            return (float)Math.Round((2*x+5), 2);
        }
    }

    public class FonState
    {
        public Color MainColor         { get; set; }       // основной фоновый цвет, используется при gradient - false
        public bool gradient           { get; set; }       // выбор между градиентом и обычной заливкой
        public bool gradient_direct    { get; set; }       // выбор направления градиента (вертикальный - true, горизонтальный - false)
        public Color StartGradient     { get; set; }       // начальный цвет градиента
        public Color EndGradiend       { get; set; }       // конечный цвет градиента
        public bool streak             { get; set; }       // наличие штриховки
        public float step_streak       { get; set; }       // шаг штриховки
        public bool grid               { get; set; }       // наличие сетки
        public Color ColorGrid         { get; set; }       // цвет сетки
        public float step_grid         { get; set; }       // шаг сетки
        public bool streak_note        { get; set; }       // подпись штрихов
        public bool axis_note          { get; set; }       // подпись осей
        public int font_size           { get; set; }       // размер шрифта надписей 

        public FonState()       // конструктор фона по умолчанию
        {
            MainColor = Color.AntiqueWhite;
            gradient = false;
            gradient_direct = false;
            StartGradient = Color.Empty;
            EndGradiend = Color.Empty;
            streak = true;
            step_streak = 1;
            grid = true;
            ColorGrid = Color.LightGray;
            step_grid = 1;
            streak_note = true;
            axis_note = true;
            font_size = 8;
        }

        public void CopyFrom(FonState fs)
        {
            this.gradient = fs.gradient;
            this.MainColor = fs.MainColor;            
            this.gradient_direct = fs.gradient_direct;
            this.StartGradient = fs.StartGradient;
            this.EndGradiend = fs.EndGradiend;
            this.streak = fs.streak;
            this.step_streak = fs.step_streak;
            this.grid = fs.grid;
            this.ColorGrid = fs.ColorGrid;
            this.step_grid = fs.step_grid;
            this.streak_note = fs.streak_note;
            this.axis_note = fs.axis_note;
            this.font_size = fs.font_size;
        }
    }
}
