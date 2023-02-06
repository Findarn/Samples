using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Проект
{
    class WordAndTerm
    {
        public string word;             //слово
        public string term;             //понятие, записанное как строка
        public string[] term_array;     //понятие, записанное как массив слов
        public bool used;               //использовано ли слово

        public WordAndTerm()    //пустой конструктор
        {
            word = "";
            term = "";
            used = false;
        }

        public WordAndTerm(string correct)  //в конструктор передаётся проверенная корректная строка
        {
            string[] buf1 = correct.Split('_');   //разделяем строку по разделителю _, отделяя слово от понятия
            word = buf1[0].Trim(' ');     //в слово заносим левую часть строки
            term = buf1[1].Trim(' ');     //в понятие - правую
            used = false;
        }

        public bool CreateTermArray()
        {
            try
            {
                term_array = term.Split(' ');                
            }
            catch
            {
                return false;
            }
            if (term_array.Length > 3)
                return false;
            return true;
        }  
        
        public bool to_stream(BinaryWriter bw)
        {
            try
            {
                bw.Write(word.ToUpper());
                bw.Write(term);
                bw.Write(used);
                bw.Write(term_array.Length);
                for (int i = 0; i < term_array.Length; i++)
                {
                    bw.Write(term_array[i]);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool from_stream(BinaryReader br)
        {

            try
            {
                word = br.ReadString();
                term = br.ReadString();
                used = br.ReadBoolean();
                term_array = new string[br.ReadInt32()];
                for (int i = 0; i < term_array.Length; i++)
                {
                    term_array[i] = br.ReadString();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }       //Связка слово-понятие
    class Dictionary
    {
        public string theme;                           //тема словаря понятий
        public List<WordAndTerm> DictionaryList;       //список понятий

        public Dictionary()
        {
            theme = "";
            DictionaryList = new List<WordAndTerm>();
        }

        public bool to_stream(BinaryWriter bw)
        {
            try
            {
                bw.Write(theme);
                bw.Write(DictionaryList.Count);
                for (int i = 0; i < DictionaryList.Count; i++)
                {
                    DictionaryList[i].to_stream(bw);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool from_stream(BinaryReader br)
        {
            try
            {
                theme = br.ReadString();
                int buf = br.ReadInt32();
                for (int i = 0; i < buf; i++)
                {
                    DictionaryList.Add(new WordAndTerm());
                    DictionaryList[i].from_stream(br);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }        //словарь понятий
    class Cell
    {
        public PictureBox PBCell;          //Для графического заполнения - поля, стрелки
        public RichTextBox RTBCell;        //Для текстового оформления
        public bool state_undef;           //состояние - неопределено
        public bool state_term;            //состояние - содержит понятие
        public bool state_letter;          //состояние - содержит букву отгадываемого слова
        public bool cross;                 //флаг, указывающий на наличие пересечения
        public int used_word;              //индекс использованного слова из словаря
        public int indexi;
        public int indexj;
        public int direction;
        public int clock;
        public string name_theme;          //название темы сканворда

        public Cell()
        {
            PBCell = new PictureBox();            
            RTBCell = new RichTextBox();
            state_undef = true;
            state_term = false;
            state_letter = false;
            cross = false;
            used_word = -1;
            direction = -1;     //0 - вправо, 0 - вниз
            clock = -1;         
        }

        public bool set_elements(float h, float w, Scan_form sf, int i, int j, string theme)
        {
            RTBCell.Margin = new Padding(0);
            RTBCell.Size = new System.Drawing.Size(Convert.ToInt32(w), Convert.ToInt32(h));
            RTBCell.ScrollBars = RichTextBoxScrollBars.None;
            RTBCell.Font = new System.Drawing.Font("Courier", w/2);
            RTBCell.ReadOnly = true;
            RTBCell.BackColor = System.Drawing.Color.Lavender;
            name_theme = theme;
            indexi = i;
            indexj = j;
            direction = -1;
            clock = -1;
            used_word = -1;
            RTBCell.Name = "" + i + " " + j;
            RTBCell.MouseHover += new System.EventHandler(sf.RTBCell_MouseHover);
            RTBCell.MouseDown += new System.Windows.Forms.MouseEventHandler(sf.RTBCell_MouseRightClick);
            RTBCell.SelectAll();
            RTBCell.SelectionAlignment = HorizontalAlignment.Center;
            RTBCell.DeselectAll();
            return true;
        }

        public bool to_stream(BinaryWriter bw)
        {
            try
            {
                bw.Write(state_undef);
                bw.Write(state_term);
                bw.Write(state_letter);
                bw.Write(cross);
                bw.Write(used_word);
                bw.Write(indexi);
                bw.Write(indexj);
                bw.Write(direction);
                bw.Write(clock);
                bw.Write(name_theme);
                bw.Write(RTBCell.Lines.Length);
                for (int i = 0; i < RTBCell.Lines.Length; i++)
                    bw.Write(RTBCell.Lines[i]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool from_stream(BinaryReader br)
        {
            try
            {
                state_undef = br.ReadBoolean();
                state_term = br.ReadBoolean();
                state_letter = br.ReadBoolean();
                cross = br.ReadBoolean();
                used_word = br.ReadInt32();
                indexi = br.ReadInt32();
                indexj = br.ReadInt32();
                direction = br.ReadInt32();
                clock = br.ReadInt32();
                name_theme = br.ReadString();
                int buf = br.ReadInt32();
                for (int i = 0; i < buf; i++)
                    RTBCell.Text += br.ReadString() + "\r\n";
                return true;
            }
            catch 
            {
                return false;
            }
        }


    }       //ячейка-клетка сканворда
    
}
