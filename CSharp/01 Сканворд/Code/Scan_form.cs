using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Проект
{
    public partial class Scan_form : Form
    {
        ParentForm refPar;
        Cell[,] Scanword;
        Dictionary Dict;
        bool maket_exist = false;
        bool error_dictionary = false;
        public Scan_form(ParentForm refer)
        {
            InitializeComponent();
            refPar = refer;            
        }

        public void RTBCell_MouseHover(object sender, EventArgs e)
        {
            RichTextBox buffer = (RichTextBox)sender;
            string[] split = buffer.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            //ToolTip t = new ToolTip();
            toolTip1.SetToolTip(Scanword[i,j].RTBCell, Scanword[i,j].RTBCell.Text);            
        }

        public void RTBCell_MouseRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                RichTextBox buffer = (RichTextBox)sender;
                string[] split = buffer.Name.Split(' ');
                int i = Convert.ToInt32(split[0]);
                int j = Convert.ToInt32(split[1]);
                int starti = i;
                int startj = j;

                ToolStripMenuItem firstitem = (ToolStripMenuItem)contextMenuStrip1.Items[0];
                ToolStripMenuItem undef = (ToolStripMenuItem)firstitem.DropDownItems[0];
                ToolStripMenuItem term = (ToolStripMenuItem)firstitem.DropDownItems[1];
                ToolStripMenuItem letter = (ToolStripMenuItem)firstitem.DropDownItems[2];
                ToolStripMenuItem seconditem = (ToolStripMenuItem)contextMenuStrip1.Items[1];
                ToolStripMenuItem thirditem = (ToolStripMenuItem)contextMenuStrip1.Items[2];
                ToolStripMenuItem toRight = (ToolStripMenuItem)seconditem.DropDownItems[0];
                ToolStripMenuItem toDown = (ToolStripMenuItem)seconditem.DropDownItems[1];
                ToolStripMenuItem fourthitem = (ToolStripMenuItem)contextMenuStrip1.Items[3];       //доступ к элементам меню
                ToolStripMenuItem u = (ToolStripMenuItem)thirditem.DropDownItems[0];
                ToolStripMenuItem ur = (ToolStripMenuItem)thirditem.DropDownItems[1];
                ToolStripMenuItem r = (ToolStripMenuItem)thirditem.DropDownItems[2];
                ToolStripMenuItem dr = (ToolStripMenuItem)thirditem.DropDownItems[3];
                ToolStripMenuItem d = (ToolStripMenuItem)thirditem.DropDownItems[4];
                ToolStripMenuItem dl = (ToolStripMenuItem)thirditem.DropDownItems[5];
                ToolStripMenuItem l = (ToolStripMenuItem)thirditem.DropDownItems[6];
                ToolStripMenuItem ul = (ToolStripMenuItem)thirditem.DropDownItems[7];

                seconditem.Enabled = false;
                thirditem.Enabled = false;
                fourthitem.Enabled = false;
                letter.Enabled = false;
                u.Enabled = false; u.Checked = false;
                ur.Enabled = false; ur.Checked = false;
                r.Enabled = false; r.Checked = false;
                dr.Enabled = false; dr.Checked = false;
                d.Enabled = false; d.Checked = false;
                dl.Enabled = false; dl.Checked = false;
                l.Enabled = false; l.Checked = false;
                ul.Enabled = false; ul.Checked = false;
                fourthitem.DropDownItems.Clear();

                if (Scanword[i, j].state_undef == true)
                {
                    undef.Checked = true;
                    term.Checked = false;
                    letter.Checked = false;
                }

                if (Scanword[i, j].state_term == true)
                {
                    undef.Checked = false;
                    term.Checked = true;
                    letter.Checked = false;
                }

                if (Scanword[i, j].state_letter == true)
                {
                    undef.Checked = false;
                    term.Checked = false;
                    letter.Checked = true;
                }

                if (term.Checked == true)
                {
                    seconditem.Enabled = true;
                }

                if (Scanword[i, j].direction == -1)
                {
                    seconditem.Checked = false;
                    toRight.Checked = false;
                    toDown.Checked = false;
                }

                if (Scanword[i, j].direction == 0)
                {
                    seconditem.Checked = true;
                    toRight.Checked = true;
                    toDown.Checked = false;
                }

                if (Scanword[i, j].direction == 1)
                {
                    seconditem.Checked = true;
                    toRight.Checked = false;
                    toDown.Checked = true;
                }

                switch (Scanword[i, j].clock)
                {
                    case -1: thirditem.Checked = false; break;
                    case 0: thirditem.Checked = true; u.Checked = true; break;
                    case 1: thirditem.Checked = true; ur.Checked = true; break;
                    case 2: thirditem.Checked = true; r.Checked = true; break;
                    case 3: thirditem.Checked = true; dr.Checked = true; break;
                    case 4: thirditem.Checked = true; d.Checked = true; break;
                    case 5: thirditem.Checked = true; dl.Checked = true; break;
                    case 6: thirditem.Checked = true; l.Checked = true; break;
                    case 7: thirditem.Checked = true; ul.Checked = true; break;
                }

                if (seconditem.Checked == true)
                {
                    thirditem.Enabled = true;
                }

                if (i - 1 >= 0)
                {
                    if (Scanword[i - 1, j].state_term == false && toDown.Checked != true)
                    {
                        u.Enabled = true;
                    }
                }

                if (i - 1 >= 0 && j + 1 < tableScan.ColumnCount)
                {
                    if (Scanword[i - 1, j + 1].state_term == false)
                    {
                        ur.Enabled = true;
                    }
                }

                if (j + 1 < tableScan.ColumnCount)
                {
                    if (Scanword[i, j + 1].state_term == false)
                    {
                        r.Enabled = true;
                    }
                }

                if (i + 1 < tableScan.RowCount && j + 1 < tableScan.ColumnCount)
                {
                    if (Scanword[i + 1, j + 1].state_term == false)
                    {
                        dr.Enabled = true;
                    }
                }

                if (i + 1 < tableScan.RowCount)
                {
                    if (Scanword[i + 1, j].state_term == false)
                    {
                        d.Enabled = true;
                    }
                }

                if (i + 1 < tableScan.RowCount && j - 1 >= 0)
                {
                    if (Scanword[i + 1, j - 1].state_term == false)
                    {
                        dl.Enabled = true;
                    }
                }

                if (j - 1 >= 0)
                {
                    if (Scanword[i, j - 1].state_term == false && toRight.Checked != true)
                    {
                        l.Enabled = true;
                    }
                }

                if (i - 1 >= 0 && j - 1 >= 0)
                {
                    if (Scanword[i - 1, j - 1].state_term == false)
                    {
                        ul.Enabled = true;
                    }
                }


                if (Dict != null && Scanword[i, j].state_term == true && thirditem.Checked == true)
                {
                    fourthitem.Enabled = true;
                    for (int k = 0; k < Dict.DictionaryList.Count; k++)
                    {
                        starti = i;
                        startj = j;
                        bool used_term = false;     //признак того, использовано ли слово
                        bool length_term = false;   //признак того, что слово подходит по длине
                        bool cross_term = false;    //признак того, что слово подходит по пересечению букв
                        bool result;

                        if (Dict.DictionaryList[k].used == false)
                        {
                            used_term = true;
                        }

                        switch (Scanword[i, j].clock)
                        {
                            case 0: starti--; break;
                            case 1: starti--; startj++; break;
                            case 2: startj++; break;
                            case 3: starti++; startj++; break;
                            case 4: starti++; break;
                            case 5: starti++; startj--; break;
                            case 6: startj--; break;
                            case 7: starti--; startj--; break;
                        }

                        switch (Scanword[i, j].direction)
                        {
                            case 0:
                                {
                                    if (startj + Dict.DictionaryList[k].word.Length <= tableScan.ColumnCount)
                                    {
                                        length_term = true;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                    cross_term = true;
                                    for (int lw = 0; lw < Dict.DictionaryList[k].word.Length; lw++)
                                    {
                                        if (Scanword[starti, startj + lw].RTBCell.Text == "")
                                        {
                                            cross_term = true;
                                        }
                                        else
                                        {
                                            if (Dict.DictionaryList[k].word[lw] != Scanword[starti, startj + lw].RTBCell.Text[0])
                                            {
                                                cross_term = false;
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (starti + Dict.DictionaryList[k].word.Length <= tableScan.RowCount)
                                    {
                                        length_term = true;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                    cross_term = true;
                                    for (int lw = 0; lw < Dict.DictionaryList[k].word.Length; lw++)
                                    {
                                        if (Scanword[starti + lw, startj].RTBCell.Text == "")
                                        {
                                            cross_term = true;
                                        }
                                        else
                                        {
                                            if (Dict.DictionaryList[k].word[lw] != Scanword[starti + lw, startj].RTBCell.Text[0])
                                            {
                                                cross_term = false;
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                }
                        }
                        result = used_term & length_term & cross_term;
                        if (result == true)
                        {
                            ToolStripMenuItem TermItem = new ToolStripMenuItem();
                            TermItem.Name = Convert.ToString(k);  //Имя понятия - индекс в массиве словаря
                            TermItem.Text = Dict.DictionaryList[k].word + " " + Dict.DictionaryList[k].term;
                            TermItem.Click += new System.EventHandler(this.TermItem_Click);
                            fourthitem.DropDownItems.Add(TermItem);
                        }

                    }
                }

                if (Scanword[i, j].state_term == true && Scanword[i, j].RTBCell.Text != "")
                {
                    fourthitem.Checked = true;
                }
                else
                {
                    fourthitem.Checked = false;
                }


                contextMenuStrip1.Show(Scanword[i, j].RTBCell, new Point(0, Scanword[i, j].RTBCell.Height/2));
            }
        }

        private void TermItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem TermItem = (ToolStripMenuItem)sender;
            int index = Convert.ToInt32(TermItem.Name);                 //получили индекс понятия в словаре
            ContextMenuStrip buf = (ContextMenuStrip)TermItem.OwnerItem.Owner;
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            int starti = i;
            int startj = j;

            switch (Scanword[i, j].clock)
            {
                case 0: starti--; break;
                case 1: starti--; startj++; break;
                case 2: startj++; break;
                case 3: starti++; startj++; break;
                case 4: starti++; break;
                case 5: starti++; startj--; break;
                case 6: startj--; break;
                case 7: starti--; startj--; break;
            }

            if (rtb.Text == "")     //если в ячейке было пусто
            {
                for (int tl = 0; tl < Dict.DictionaryList[index].term_array.Length; tl++)
                {
                    Scanword[i, j].RTBCell.Text += Dict.DictionaryList[index].term_array[tl] + "\r\n";
                    Scanword[i, j].RTBCell.Text += "\r\n";
                }                
                for (int lw = 0; lw < Dict.DictionaryList[index].word.Length; lw++)
                {
                    if (Scanword[starti, startj].RTBCell.Text != "")
                    {
                        Scanword[starti, startj].cross = true;
                    }
                    else
                    {
                        Scanword[starti, startj].RTBCell.Text += Dict.DictionaryList[index].word[lw];
                        Scanword[starti, startj].state_letter = true;
                        Scanword[starti, startj].state_undef = false;
                    }                    
                    if (Scanword[i, j].direction == 0)
                        startj++;
                    if (Scanword[i, j].direction == 1)
                        starti++;
                }
            }
            else                    //если в ячейке было записано другое понятие
            {
                MessageBox.Show("Это поле занято под букву одного из слов. Чтобы освободить его, уберите клетку с понятием!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Dict.DictionaryList[index].used = true;
            Scanword[i, j].used_word = index;
        } 
        private void неопределеноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem buf1 = (ToolStripMenuItem)sender;
            ToolStripItem buf2 = buf1.OwnerItem;
            ToolStrip buf3 = buf2.Owner;
            ContextMenuStrip buf4 = (ContextMenuStrip)buf3;
            Control link = buf4.SourceControl;

            RichTextBox buffer = (RichTextBox)link;
            string[] split = buffer.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            int starti = i;
            int startj = j;

            if (Scanword[i,j].state_term == true)
            {
                
                switch (Scanword[i, j].clock)
                {
                    case 0: starti--; break;
                    case 1: starti--; startj++; break;
                    case 2: startj++; break;
                    case 3: starti++; startj++; break;
                    case 4: starti++; break;
                    case 5: starti++; startj--; break;
                    case 6: startj--; break;
                    case 7: starti--; startj--; break;
                }
                if (Scanword[i, j].used_word != -1)
                {
                    for (int lw = 0; lw < Dict.DictionaryList[Scanword[i, j].used_word].word.Length; lw++)
                    {
                        if (Scanword[starti, startj].cross == true)
                        {
                            Scanword[starti, startj].cross = false;
                        }
                        else
                        {
                            Scanword[starti, startj].RTBCell.Clear();
                            Scanword[starti, startj].state_letter = false;
                            Scanword[starti, startj].state_undef = true;
                        }
                        if (Scanword[i, j].direction == 0)
                            startj++;
                        if (Scanword[i, j].direction == 1)
                            starti++;
                    }
                }

                Scanword[i, j].clock = -1;
                Scanword[i, j].direction = -1;
                Scanword[i, j].state_undef = true;
                Scanword[i, j].state_letter = false;
                Scanword[i, j].state_term = false;
                Scanword[i, j].RTBCell.Font = new System.Drawing.Font("Courier", Scanword[i, j].RTBCell.Height / 2);
                buffer.Clear();
                if (Scanword[i, j].used_word != -1)
                {
                    Dict.DictionaryList[Scanword[i, j].used_word].used = false;
                    Scanword[i, j].used_word = -1;
                }
                Scanword[i, j].used_word = -1;
            }
        }

        private void понятиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem buf1 = (ToolStripMenuItem)sender;
            ToolStripItem buf2 = buf1.OwnerItem;
            ToolStrip buf3 = buf2.Owner;
            ContextMenuStrip buf4 = (ContextMenuStrip)buf3;
            Control link = buf4.SourceControl;   

            
            RichTextBox buffer = (RichTextBox)link;
            string[] split = buffer.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (Scanword[i,j].state_undef == true)
            {
                Scanword[i, j].state_undef = false;
                Scanword[i, j].state_letter = false;
                Scanword[i, j].state_term = true;
                Scanword[i, j].RTBCell.Font = new System.Drawing.Font("Courier", (Scanword[i,j].RTBCell.Height/10)-1);
            }
            else
            {
                MessageBox.Show("Это поле занято под букву одного из слов. Чтобы освободить его, уберите клетку с понятием!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Dict != null)
            {
                DialogResult dialog = MessageBox.Show("В памяти программы содержится другой словарь. При открытии нового словаря макет сканворда будет утрачен. \nВы уверены, что желаете открыть другой файл?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {

                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Файлы словаря|*.svd";
                    ofd.InitialDirectory = refPar.path_dict;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (Scanword != null)
                        {
                            for (int i = 0; i < tableScan.RowCount; i++)
                            {
                                for (int j = 0; j < tableScan.ColumnCount; j++)
                                {
                                    Scanword[i, j].RTBCell.Clear();
                                    Scanword[i, j].state_undef = true;
                                    Scanword[i, j].state_term = false;
                                    Scanword[i, j].state_letter = false;
                                    Scanword[i, j].RTBCell.Font = new System.Drawing.Font("Courier", Scanword[i, j].RTBCell.Height / 2);
                                    Scanword[i, j].direction = -1;
                                    Scanword[i, j].clock = -1;
                                    Scanword[i, j].cross = false;
                                }
                            }
                        }
                        Dict = new Dictionary();
                        BinaryReader dictbr = new BinaryReader(File.Open(ofd.FileName, FileMode.Open));
                        Dict.from_stream(dictbr);
                        dictbr.Close();
                        label3.Text = "Тема сканворда: " + Dict.theme;                        
                        создатьToolStripMenuItem.Enabled = true;
                        очиститьToolStripMenuItem.Enabled = true;
                    }
                    else
                        return;
                }
                else
                    return;
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Файлы словаря|*.svd";
                ofd.InitialDirectory = refPar.path_dict;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Dict = new Dictionary();
                    BinaryReader dictbr = new BinaryReader(File.Open(ofd.FileName, FileMode.Open));
                    Dict.from_stream(dictbr);
                    dictbr.Close();
                    label3.Text = "Тема сканворда: " + Dict.theme;                    
                    создатьToolStripMenuItem.Enabled = true;
                    очиститьToolStripMenuItem.Enabled = true;
                }
                else
                {
                    return;
                }
            }

            if (error_dictionary == true && Scanword != null)
            {
                if (Dict.theme == Scanword[0, 0].name_theme)
                {
                    error_dictionary = false;
                    contextMenuStrip1.Enabled = true;
                }
                else
                {
                    error_dictionary = true;
                }
            }

            if (error_dictionary == false && Scanword != null && Dict != null)
            {
                экспортСканвордаToolStripMenuItem.Enabled = true;
                for (int i = 0; i < tableScan.RowCount; i++)
                {
                    for (int j = 0; j < tableScan.ColumnCount; j++)
                    {
                        if (Scanword[i, j].state_term == true && Scanword[i, j].used_word != -1)
                        {
                            Dict.DictionaryList[Scanword[i, j].used_word].used = true;
                        }
                    }
                }
            }
        }

        private void вправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem DirectionItem = (ToolStripMenuItem)sender;            
            ContextMenuStrip buf = (ContextMenuStrip)DirectionItem.OwnerItem.Owner;
            ToolStripMenuItem fourthitem = (ToolStripMenuItem)buf.Items[3];
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (fourthitem.Checked == false)
            {
                Scanword[i, j].direction = 0;
                Scanword[i, j].clock = -1;
            }
            else
            {
                MessageBox.Show("Для ячейки уже задано понятие! Для сброса параметров ячейки переключите её статус в \"Неопределено\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void внизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem DirectionItem = (ToolStripMenuItem)sender;
            ContextMenuStrip buf = (ContextMenuStrip)DirectionItem.OwnerItem.Owner;
            ToolStripMenuItem fourthitem = (ToolStripMenuItem)buf.Items[3];
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (fourthitem.Checked == false)
            {
                Scanword[i, j].direction = 1;
                Scanword[i, j].clock = -1;
            }
            else
            {
                MessageBox.Show("Для ячейки уже задано понятие! Для сброса параметров ячейки переключите её статус в \"Неопределено\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void сверхуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem StartingItem = (ToolStripMenuItem)sender;
            ContextMenuStrip buf = (ContextMenuStrip)StartingItem.OwnerItem.Owner;
            ToolStripMenuItem fourthitem = (ToolStripMenuItem)buf.Items[3];
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (fourthitem.Checked == false)
            {               
                Scanword[i, j].clock = 0;
            }
            else
            {
                MessageBox.Show("Для ячейки уже задано понятие! Для сброса параметров ячейки переключите её статус в \"Неопределено\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void сверхусправаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem StartingItem = (ToolStripMenuItem)sender;
            ContextMenuStrip buf = (ContextMenuStrip)StartingItem.OwnerItem.Owner;
            ToolStripMenuItem fourthitem = (ToolStripMenuItem)buf.Items[3];
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (fourthitem.Checked == false)
            {
                Scanword[i, j].clock = 1;
            }
            else
            {
                MessageBox.Show("Для ячейки уже задано понятие! Для сброса параметров ячейки переключите её статус в \"Неопределено\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void справаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem StartingItem = (ToolStripMenuItem)sender;
            ContextMenuStrip buf = (ContextMenuStrip)StartingItem.OwnerItem.Owner;
            ToolStripMenuItem fourthitem = (ToolStripMenuItem)buf.Items[3];
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (fourthitem.Checked == false)
            {
                Scanword[i, j].clock = 2;
            }
            else
            {
                MessageBox.Show("Для ячейки уже задано понятие! Для сброса параметров ячейки переключите её статус в \"Неопределено\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void снизусправаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem StartingItem = (ToolStripMenuItem)sender;
            ContextMenuStrip buf = (ContextMenuStrip)StartingItem.OwnerItem.Owner;
            ToolStripMenuItem fourthitem = (ToolStripMenuItem)buf.Items[3];
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (fourthitem.Checked == false)
            {
                Scanword[i, j].clock = 3;
            }
            else
            {
                MessageBox.Show("Для ячейки уже задано понятие! Для сброса параметров ячейки переключите её статус в \"Неопределено\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void снизуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem StartingItem = (ToolStripMenuItem)sender;
            ContextMenuStrip buf = (ContextMenuStrip)StartingItem.OwnerItem.Owner;
            ToolStripMenuItem fourthitem = (ToolStripMenuItem)buf.Items[3];
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (fourthitem.Checked == false)
            {
                Scanword[i, j].clock = 4;
            }
            else
            {
                MessageBox.Show("Для ячейки уже задано понятие! Для сброса параметров ячейки переключите её статус в \"Неопределено\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void снизуслеваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem StartingItem = (ToolStripMenuItem)sender;
            ContextMenuStrip buf = (ContextMenuStrip)StartingItem.OwnerItem.Owner;
            ToolStripMenuItem fourthitem = (ToolStripMenuItem)buf.Items[3];
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (fourthitem.Checked == false)
            {
                Scanword[i, j].clock = 5;
            }
            else
            {
                MessageBox.Show("Для ячейки уже задано понятие! Для сброса параметров ячейки переключите её статус в \"Неопределено\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void слеваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem StartingItem = (ToolStripMenuItem)sender;
            ContextMenuStrip buf = (ContextMenuStrip)StartingItem.OwnerItem.Owner;
            ToolStripMenuItem fourthitem = (ToolStripMenuItem)buf.Items[3];
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (fourthitem.Checked == false)
            {
                Scanword[i, j].clock = 6;
            }
            else
            {
                MessageBox.Show("Для ячейки уже задано понятие! Для сброса параметров ячейки переключите её статус в \"Неопределено\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void слевасверхуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem StartingItem = (ToolStripMenuItem)sender;
            ContextMenuStrip buf = (ContextMenuStrip)StartingItem.OwnerItem.Owner;
            ToolStripMenuItem fourthitem = (ToolStripMenuItem)buf.Items[3];
            Control link = buf.SourceControl;
            RichTextBox rtb = (RichTextBox)link;
            string[] split = rtb.Name.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (fourthitem.Checked == false)
            {
                Scanword[i, j].clock = 7;
            }
            else
            {
                MessageBox.Show("Для ячейки уже задано понятие! Для сброса параметров ячейки переключите её статус в \"Неопределено\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("При очистке текущего словаря макет сканворда будет утрачен. Продолжить?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < tableScan.RowCount; i++)
                {
                    for (int j = 0; j < tableScan.ColumnCount; j++)
                    {
                        Scanword[i, j].RTBCell.Clear();
                        Scanword[i, j].state_undef = true;
                        Scanword[i, j].state_term = false;
                        Scanword[i, j].state_letter = false;
                        Scanword[i, j].RTBCell.Font = new System.Drawing.Font("Courier", Scanword[i, j].RTBCell.Height / 2);
                        Scanword[i, j].direction = -1;
                        Scanword[i, j].clock = -1;
                        Scanword[i, j].cross = false;
                        Scanword[i, j].name_theme = "";
                    }
                }
                Dict = null;                
                очиститьToolStripMenuItem.Enabled = false;
                создатьToolStripMenuItem.Enabled = false;
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (maket_exist == false)
            {
                tableScan.RowCount = 0;
                tableScan.ColumnCount = 0;
                tableScan.Controls.Clear();
                int strok = Convert.ToInt32(ChoseRows.Value);
                int stolb = Convert.ToInt32(ChoseColumns.Value);
                float percent_row;
                float percent_clmn;
                percent_row = tableScan.Width / strok;
                percent_clmn = tableScan.Height / stolb;
                int side;
                if (percent_row >= percent_clmn)
                {
                    side = Convert.ToInt32(percent_clmn);
                }
                else
                {
                    side = Convert.ToInt32(percent_row);
                }
                float sidefloat = side;
                tableScan.RowCount = strok;
                tableScan.ColumnCount = stolb;
                tableScan.RowStyles.Clear();
                for (int i = 0; i < tableScan.RowCount; i++)
                {
                    tableScan.RowStyles.Add(new RowStyle());
                    tableScan.RowStyles[i].SizeType = SizeType.Absolute;
                    tableScan.RowStyles[i].Height = sidefloat;
                }
                tableScan.ColumnStyles.Clear();
                for (int i = 0; i < tableScan.ColumnCount; i++)
                {
                    tableScan.ColumnStyles.Add(new ColumnStyle());
                    tableScan.ColumnStyles[i].SizeType = SizeType.Absolute;
                    tableScan.ColumnStyles[i].Width = sidefloat;
                }

                Scanword = new Cell[strok, stolb];

                for (int i = 0; i < strok; i++)
                {
                    for (int j = 0; j < stolb; j++)
                    {
                        Scanword[i, j] = new Cell();
                        Scanword[i, j].set_elements(tableScan.RowStyles[i].Height, tableScan.ColumnStyles[j].Width, this, i, j, Dict.theme);
                        tableScan.Controls.Add(Scanword[i, j].RTBCell, j, i);

                    }
                }
                maket_exist = true;
                сохранитьМакетToolStripMenuItem.Enabled = true;
                экспортСканвордаToolStripMenuItem.Enabled = true;
            }
            else
            {
                DialogResult result = MessageBox.Show("Макет сканворда уже существует. При выполнении этого действия он будет утрачен. Продолжить?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    for (int i = 0; i < tableScan.RowCount; i++)
                    {
                        for (int j = 0; j < tableScan.ColumnCount; j++)
                        {
                            Scanword[i, j].RTBCell.Clear();
                            if (Scanword[i, j].state_term == true && Dict != null)
                            {
                                Dict.DictionaryList[Scanword[i, j].used_word].used = false;
                            }
                            Scanword[i, j].state_undef = true;
                            Scanword[i, j].state_term = false;
                            Scanword[i, j].state_letter = false;
                            Scanword[i, j].RTBCell.Font = new System.Drawing.Font("Courier", Scanword[i, j].RTBCell.Height / 2);
                            Scanword[i, j].direction = -1;
                            Scanword[i, j].clock = -1;
                            Scanword[i, j].cross = false;
                            Scanword[i, j].name_theme = "";
                        }
                    }

                    tableScan.RowCount = 0;
                    tableScan.ColumnCount = 0;
                    tableScan.Controls.Clear();
                    int strok = Convert.ToInt32(ChoseRows.Value);
                    int stolb = Convert.ToInt32(ChoseColumns.Value);
                    float percent_row;
                    float percent_clmn;
                    percent_row = tableScan.Width / strok;
                    percent_clmn = tableScan.Height / stolb;
                    int side;
                    if (percent_row >= percent_clmn)
                    {
                        side = Convert.ToInt32(percent_clmn);
                    }
                    else
                    {
                        side = Convert.ToInt32(percent_row);
                    }
                    float sidefloat = side;
                    tableScan.RowCount = strok;
                    tableScan.ColumnCount = stolb;
                    tableScan.RowStyles.Clear();
                    for (int i = 0; i < tableScan.RowCount; i++)
                    {
                        tableScan.RowStyles.Add(new RowStyle());
                        tableScan.RowStyles[i].SizeType = SizeType.Absolute;
                        tableScan.RowStyles[i].Height = sidefloat;
                    }
                    tableScan.ColumnStyles.Clear();
                    for (int i = 0; i < tableScan.ColumnCount; i++)
                    {
                        tableScan.ColumnStyles.Add(new ColumnStyle());
                        tableScan.ColumnStyles[i].SizeType = SizeType.Absolute;
                        tableScan.ColumnStyles[i].Width = sidefloat;
                    }

                    Scanword = new Cell[strok, stolb];

                    for (int i = 0; i < strok; i++)
                    {
                        for (int j = 0; j < stolb; j++)
                        {
                            Scanword[i, j] = new Cell();
                            Scanword[i, j].set_elements(tableScan.RowStyles[i].Height, tableScan.ColumnStyles[j].Width, this, i, j, Dict.theme);
                            tableScan.Controls.Add(Scanword[i, j].RTBCell, j, i);

                        }
                    }

                    maket_exist = true;
                    сохранитьМакетToolStripMenuItem.Enabled = true;
                    экспортСканвордаToolStripMenuItem.Enabled = true;
                }

            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tДанная подпрограмма в составе АСГС выполняет формирование макета сканворда, предлагая возможности разметки ячеек в поле сканворда.\n\n\t Составление сканворда привязано к словарю понятий. Загрузка и очистка словарей также предусмотрены.\n\n\tРезультатом работы является либо сформированный макет, который в дальнейшем можно редактировать, либо экспорт макета в виде изображения для печати.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void сохранитьМакетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Scanword == null)
            {
                MessageBox.Show("Макет не задан!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Файлы макета|*.mkt";
                sfd.InitialDirectory = refPar.path_scan;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    BinaryWriter bwmkt = new BinaryWriter(File.Open(sfd.FileName, FileMode.Create));
                    bwmkt.Write(tableScan.RowCount);
                    bwmkt.Write(tableScan.ColumnCount);
                    for (int i = 0; i < tableScan.RowCount; i++)
                        for (int j = 0; j < tableScan.ColumnCount; j++)
                            Scanword[i, j].to_stream(bwmkt);
                    bwmkt.Close();
                }
            }
        }

        private void открытьМакетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Scanword == null)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Файлы макета|*.mkt";
                ofd.InitialDirectory = refPar.path_scan;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    BinaryReader brmkt = new BinaryReader(File.Open(ofd.FileName, FileMode.Open));
                    ChoseRows.Value = brmkt.ReadInt32();
                    ChoseColumns.Value = brmkt.ReadInt32();
                    tableScan.RowCount = 0;
                    tableScan.ColumnCount = 0;
                    tableScan.Controls.Clear();
                    int strok = Convert.ToInt32(ChoseRows.Value);
                    int stolb = Convert.ToInt32(ChoseColumns.Value);
                    float percent_row;
                    float percent_clmn;
                    percent_row = tableScan.Width / strok;
                    percent_clmn = tableScan.Height / stolb;
                    int side;
                    if (percent_row >= percent_clmn)
                    {
                        side = Convert.ToInt32(percent_clmn);
                    }
                    else
                    {
                        side = Convert.ToInt32(percent_row);
                    }
                    float sidefloat = side;
                    tableScan.RowCount = strok;
                    tableScan.ColumnCount = stolb;
                    tableScan.RowStyles.Clear();
                    for (int i = 0; i < tableScan.RowCount; i++)
                    {
                        tableScan.RowStyles.Add(new RowStyle());
                        tableScan.RowStyles[i].SizeType = SizeType.Absolute;
                        tableScan.RowStyles[i].Height = sidefloat;
                    }
                    tableScan.ColumnStyles.Clear();
                    for (int i = 0; i < tableScan.ColumnCount; i++)
                    {
                        tableScan.ColumnStyles.Add(new ColumnStyle());
                        tableScan.ColumnStyles[i].SizeType = SizeType.Absolute;
                        tableScan.ColumnStyles[i].Width = sidefloat;
                    }

                    Scanword = new Cell[strok, stolb];

                    for (int i = 0; i < strok; i++)
                    {
                        for (int j = 0; j < stolb; j++)
                        {
                            Scanword[i, j] = new Cell();
                            Scanword[i, j].set_elements(tableScan.RowStyles[i].Height, tableScan.ColumnStyles[j].Width, this, i, j, "");
                            Scanword[i, j].from_stream(brmkt);
                            if (Scanword[i, j].state_term == true)
                                Scanword[i, j].RTBCell.Font = new System.Drawing.Font("Courier", (Scanword[i, j].RTBCell.Height / 10) - 1);
                            tableScan.Controls.Add(Scanword[i, j].RTBCell, j, i);
                        }
                    }

                    if (Dict == null)
                    {
                        error_dictionary = true;
                        maket_exist = true;
                        сохранитьМакетToolStripMenuItem.Enabled = true;
                        contextMenuStrip1.Enabled = false;
                        return;
                    }

                    if (Dict.theme != Scanword[0,0].name_theme)
                    {
                        error_dictionary = true;
                        maket_exist = true;
                        сохранитьМакетToolStripMenuItem.Enabled = true;
                        contextMenuStrip1.Enabled = false;
                        return;
                    }
                    else
                    {
                        error_dictionary = false;
                    }

                    if (error_dictionary == false && Scanword != null && Dict != null)
                    {
                        экспортСканвордаToolStripMenuItem.Enabled = true;
                        for (int i = 0; i < tableScan.RowCount; i++)
                        {
                            for (int j = 0; j < tableScan.ColumnCount; j++)
                            {
                                if (Scanword[i, j].state_term == true)
                                {
                                    Dict.DictionaryList[Scanword[i, j].used_word].used = true;
                                }
                            }
                        }
                    }

                    maket_exist = true;
                    сохранитьМакетToolStripMenuItem.Enabled = true;
                    экспортСканвордаToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("При открытии другого макета текущий макет будет утрачен. Продолжить?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Файлы макета|*.mkt";
                    ofd.InitialDirectory = refPar.path_scan;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        Scanword = null;
                        tableScan.Controls.Clear();
                        BinaryReader brmkt = new BinaryReader(File.Open(ofd.FileName, FileMode.Open));
                        ChoseRows.Value = brmkt.ReadInt32();
                        ChoseColumns.Value = brmkt.ReadInt32();
                        tableScan.RowCount = 0;
                        tableScan.ColumnCount = 0;
                        tableScan.Controls.Clear();
                        int strok = Convert.ToInt32(ChoseRows.Value);
                        int stolb = Convert.ToInt32(ChoseColumns.Value);
                        float percent_row;
                        float percent_clmn;
                        percent_row = tableScan.Width / strok;
                        percent_clmn = tableScan.Height / stolb;
                        int side;
                        if (percent_row >= percent_clmn)
                        {
                            side = Convert.ToInt32(percent_clmn);
                        }
                        else
                        {
                            side = Convert.ToInt32(percent_row);
                        }
                        float sidefloat = side;
                        tableScan.RowCount = strok;
                        tableScan.ColumnCount = stolb;
                        tableScan.RowStyles.Clear();
                        for (int i = 0; i < tableScan.RowCount; i++)
                        {
                            tableScan.RowStyles.Add(new RowStyle());
                            tableScan.RowStyles[i].SizeType = SizeType.Absolute;
                            tableScan.RowStyles[i].Height = sidefloat;
                        }
                        tableScan.ColumnStyles.Clear();
                        for (int i = 0; i < tableScan.ColumnCount; i++)
                        {
                            tableScan.ColumnStyles.Add(new ColumnStyle());
                            tableScan.ColumnStyles[i].SizeType = SizeType.Absolute;
                            tableScan.ColumnStyles[i].Width = sidefloat;
                        }

                        Scanword = new Cell[strok, stolb];

                        for (int i = 0; i < strok; i++)
                        {
                            for (int j = 0; j < stolb; j++)
                            {
                                Scanword[i, j] = new Cell();
                                Scanword[i, j].set_elements(tableScan.RowStyles[i].Height, tableScan.ColumnStyles[j].Width, this, i, j, "");
                                Scanword[i, j].from_stream(brmkt);
                                if (Scanword[i, j].state_term == true)
                                    Scanword[i, j].RTBCell.Font = new System.Drawing.Font("Courier", (Scanword[i, j].RTBCell.Height / 10) - 1);
                                tableScan.Controls.Add(Scanword[i, j].RTBCell, j, i);
                            }
                        }

                        maket_exist = true;
                        сохранитьМакетToolStripMenuItem.Enabled = true;
                        экспортСканвордаToolStripMenuItem.Enabled = true;
                    }
                }
            }
        }

        private void экспортСканвордаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap[] d = new Bitmap[8];
            Bitmap[] r = new Bitmap[8];
            Bitmap cell = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\base.png"));
            Bitmap term = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\term.png"));
            d[1] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\d1.png"));
            d[2] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\d2.png"));
            d[3] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\d3.png"));
            d[4] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\d4.png"));
            d[5] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\d5.png"));
            d[6] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\d6.png"));            
            d[7] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\d7.png"));            
            r[0] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\r0.png"));
            r[1] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\r1.png"));
            r[2] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\r2.png"));
            r[3] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\r3.png"));
            r[4] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\r4.png"));
            r[5] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\r5.png"));
            r[7] = new Bitmap(Bitmap.FromFile(@"B:\учеба\7 семестр\КП ИПО Завадская\КП ИПО\клетки\r7.png"));
            Clipboard.Clear();
            Bitmap Export = new Bitmap((101 * tableScan.ColumnCount)+1, (101 * tableScan.RowCount)+1);
            //Export.SetResolution(101, 101);
            Graphics g = Graphics.FromImage(Export);
            for (int i = 0; i < tableScan.RowCount; i++)
            {
                for (int j = 0; j < tableScan.ColumnCount; j++)
                {
                    g.DrawImage(cell, j * 101, i * 101);
                }
            }
            for (int i = 0; i < tableScan.RowCount; i++)
            {
                for (int j = 0; j < tableScan.ColumnCount; j++)
                {
                    if (Scanword[i, j].state_term == true)
                    {
                        g.DrawImage(term, j * 101, i * 101);
                        string[] split = Dict.DictionaryList[Scanword[i, j].used_word].term.Split(' ');
                        int step=0; int step2 = 1; int step3 = 0;
                        switch (split.Length)
                        {
                            case 1: step = 40; break;
                            case 2: step = 30; break;
                            case 3: step = 20; break;
                        }
                        for (int l = 0; l < split.Length; l++)
                        {
                            Size str = TextRenderer.MeasureText(split[l], new Font("Courier", (float)10));
                            step3 = (100 - str.Width) / 2;
                            step2 = step * (l + 1);
                            g.DrawString(split[l], new Font("Courier", (float)10), new SolidBrush(Color.Black), (j*101) + step3, (i*101)+step2);                            
                        }
                        switch(Scanword[i, j].direction)
                        {
                            case 0: 
                                {
                                    switch(Scanword[i, j].clock)
                                    {
                                        case 0:
                                            {
                                                g.DrawImage(r[0], j * 101, (i-1) * 101);
                                                break;
                                            }
                                        case 1:
                                            {
                                                g.DrawImage(r[1], (j+1) * 101, (i-1) * 101);
                                                break;
                                            }
                                        case 2:
                                            {
                                                g.DrawImage(r[2], (j+1) * 101, i * 101);
                                                break;
                                            }
                                        case 3:
                                            {
                                                g.DrawImage(r[3], (j+1) * 101, (i+1) * 101);
                                                break;
                                            }
                                        case 4:
                                            {
                                                g.DrawImage(r[4], j * 101, (i+1) * 101);
                                                break;
                                            }
                                        case 5:
                                            {
                                                g.DrawImage(r[5], (j-1) * 101, (i+1) * 101);
                                                break;
                                            }
                                        case 7:
                                            {
                                                g.DrawImage(r[7], (j-1) * 101, (i-1) * 101);
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    switch (Scanword[i, j].clock)
                                    {
                                        case 1:
                                            {
                                                g.DrawImage(d[1], (j + 1) * 101, (i - 1) * 101);
                                                break;
                                            }
                                        case 2:
                                            {
                                                g.DrawImage(d[2], (j + 1) * 101, i * 101);
                                                break;
                                            }
                                        case 3:
                                            {
                                                g.DrawImage(d[3], (j + 1) * 101, (i + 1) * 101);
                                                break;
                                            }
                                        case 4:
                                            {
                                                g.DrawImage(d[4], j * 101, (i + 1) * 101);
                                                break;
                                            }
                                        case 5:
                                            {
                                                g.DrawImage(d[5], (j - 1) * 101, (i + 1) * 101);
                                                break;
                                            }
                                        case 6:
                                            {
                                                g.DrawImage(d[6], (j - 1) * 101, i * 101);
                                                break;
                                            }
                                        case 7:
                                            {
                                                g.DrawImage(d[7], (j - 1) * 101, (i - 1) * 101);
                                                break;
                                            }
                                    }
                                    break;                                    
                                }

                        }
                    }
                }
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Изображение JPG|*.jpg";
            sfd.InitialDirectory = refPar.path_scan;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export.Save(sfd.FileName);
            }
            
        }
    }
}
