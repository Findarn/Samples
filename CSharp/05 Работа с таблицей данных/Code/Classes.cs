using System;
using System.Collections.Generic;

namespace C_3
{
    interface IMarkCar
    {
        string Mark { get; set; }
        string Model { get; set; }
        int Power { get; set; }
        double MaxSpeed { get; set; }
        string Type { get; set; }
    }    
    public class MarkCar : IMarkCar
    {
        protected string mark;
        protected string model;
        protected int power;
        protected double maxSpeed;
        protected string type;

        public string Mark
        {
            get
            {
                return this.mark;
            }
            set
            {
                this.mark = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public int Power
        {
            get
            {
                return this.power;
            }
            set
            {
                if (value > 0)
                    this.power = value;
                else
                    this.power = -1;
            }
        }
        public double MaxSpeed
        {
            get
            {
                return this.maxSpeed;
            }
            set
            {
                if (value > 0)
                    this.maxSpeed = value;
                else
                    this.maxSpeed = -1;
            }
        }
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        public MarkCar()
        {

        }
        public void CopyFrom(MarkCar mc)
        {
            mark = mc.mark;
            model = mc.model;
            power = mc.power;
            maxSpeed = mc.maxSpeed;
            type = mc.type;
        }
        public void Clear()
        {
            mark = "Не задана";
            model = "Не задана";
            power = 0;
            maxSpeed = 0;
            type = "Не задан";
        }
        public bool Equal(MarkCar mc)
        {
            bool rez = true;

            if (this.mark != mc.mark)
                rez = false;
            if (this.model != mc.model)
                rez = false;
            if (this.power != mc.power)
                rez = false;
            if (this.maxSpeed != mc.maxSpeed)
                rez = false;
            if (this.type != mc.type)
                rez = false;

            return rez;
        }
    }    
    public class LightCar : MarkCar
    {
        string reg;
        string multi;
        int pillars;       

        public string Reg
        {
            get
            {
                return this.reg;
            }
            set
            {
                this.reg = value;
            }
        }
        public string Multi
        {
            get
            {
                return this.multi;
            }
            set
            {
                this.multi = value;
            }
        }
        public int Pillars
        {
            get
            {
                return this.pillars;
            }
            set
            {
                if (value > 0)
                    this.pillars = value;
                else
                    this.pillars = -1;
            }
        }

        public LightCar(int o)
        {
            mark = "Lmark" + o;
            model = "Lmodel" + o * 10;
            power = o * 100 + 1;
            maxSpeed = o * 22.3 + 1;
            type = "Легковая";
            reg = "" + (char)o + (10 + o);
            multi = "Lmulti" + o;
            pillars = 2;
        }
        public LightCar()
        {
            mark = "Не задана L";
            model = "Не задана";
            power = 0;
            maxSpeed = 0;
            type = "Легковая";
            reg = "Не задан";
            multi = "Не задана";
            pillars = 0; 
        }
    }   
    public class CargoCar : MarkCar
    {
        string reg;
        int numOfC;
        double v;       

        public string Reg
        {
            get
            {
                return this.reg;
            }
            set
            {
                this.reg = value;
            }
        }
        public int NumOfC
        {
            get
            {
                return this.numOfC;
            }
            set
            {
                if (value >= 4)
                    this.numOfC = value;
                else
                    this.numOfC = -1;
            }
        }
        public double V
        {
            get
            {
                return this.v;
            }
            set
            {
                if (value > 0)
                    this.v = value;
                else
                    this.v = -1;
            }
        }

        public CargoCar(int o)
        {
            mark = "Cmark" + o;
            model = "Cmodel" + o * 10;
            power = o * 100 + 1;
            maxSpeed = o * 22.3 + 1;
            type = "Грузовая";
            reg = "" + (char)o + (10 + o);
            numOfC = new Random().Next(4, 8);
            v = new Random().Next(8, 22);
        }
        public CargoCar()
        {
            mark = "Не задана C";
            model = "Не задана" ;
            power = 0;
            maxSpeed = 0;
            type = "Грузовая";
            reg = "Не задан";
            numOfC = 0;
            v = 0;
        }
    }

    class Loader
    {
        public static Dictionary<string, List<MarkCar>> Tables;

        static Loader()
        {
            Tables = new Dictionary<string, List<MarkCar>>();
        }

        public static List<MarkCar> Load(MarkCar MC)
        {
            if (string.IsNullOrEmpty(MC.Model))
            {
                return null;
            }

            if (!Tables.ContainsKey(MC.Model))
            {
                Tables[MC.Model] = new List<MarkCar>();
                Random R = new Random();
                int count = R.Next(10, 20);
                if (MC is LightCar)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Tables[MC.Model].Add(new LightCar());
                        Tables[MC.Model][i].CopyFrom(MC);
                        LightCar LC = Tables[MC.Model][i] as LightCar;
                        string RegNumber = "";
                        RegNumber += (char)R.Next(0x0410, 0x042F);
                        RegNumber += R.Next(1, 1000).ToString("D3");
                        RegNumber += (char)R.Next(0x0410, 0x042F);
                        RegNumber += (char)R.Next(0x0410, 0x042F);
                        RegNumber += ' ';
                        RegNumber += R.Next(1, 163).ToString("D3");
                        string[] Multi = new string[] {"Alpine", "Sony", "Pioneer", "Mystery", "ACV", "INCAR", "MRM", "Prology" };
                        LC.Reg = RegNumber;
                        LC.Multi = Multi[R.Next(0, Multi.Length)];
                        LC.Pillars = R.Next(1, 15);
                    }
                    return Tables[MC.Model];
                }
                if (MC is CargoCar)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Tables[MC.Model].Add(new CargoCar());
                        Tables[MC.Model][i].CopyFrom(MC);
                        CargoCar CC = Tables[MC.Model][i] as CargoCar;
                        string RegNumber = "";
                        RegNumber += (char)R.Next(0x0410, 0x042F);
                        RegNumber += R.Next(1, 1000).ToString("D3");
                        RegNumber += (char)R.Next(0x0410, 0x042F);
                        RegNumber += (char)R.Next(0x0410, 0x042F);
                        RegNumber += ' ';
                        RegNumber += R.Next(1, 163).ToString("D3");
                        string[] Multi = new string[] { "Alpine", "Sony", "Pioneer", "Mystery", "ACV", "INCAR", "MRM", "Prology" };
                        CC.Reg = RegNumber;
                        int a = 1;
                        while (a%2 != 0)
                        {
                            a = R.Next(4, 19);
                        }
                        CC.NumOfC = a;
                        CC.V = R.Next(1, 1200) / (double)10 + 1;
                    }
                    return Tables[MC.Model];
                }
            }
            else
                return Tables[MC.Model];
            return null;
        }
        

    }
}
