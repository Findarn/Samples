using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Проект
{
    public partial class Dictionary_form : Form
    {
        ParentForm refPar;
        bool error_flag = false;
        Dictionary Dict;
        public Dictionary_form(ParentForm refer)
        {
            InitializeComponent();
            refPar = refer;
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tДанная подпрограмма в составе АСГС выполняет считывание текстового файла, либо предлагает возможности ручного набора в данном модуле для дальнейшего представления текста в виде словаря понятий.\n\n\tПереданный/записанный текст проверяется на наличие ошибок при составлении. Если ошибки отсутствуют, текст можно сохранить в виде словаря понятий.\n\n\tСохраненные словари и собственноручно написанный/отредактированный текст можно сохранять и впоследствии открывать в данной подпрограмме для дальнейшего редактирования.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TextCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputtext.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Поле ввода текста не пустое. Убедитесь, что вы сохранили данные. \nВы уверены, что желаете создать новый файл?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                    inputtext.Clear();
                else
                    return;
            }
        }

        private void TextOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputtext.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Поле ввода текста не пустое. Убедитесь, что вы сохранили данные. \nВы уверены, что желаете открыть другой файл?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Текстовые файлы|*.txt";
                    ofd.InitialDirectory = refPar.path_input;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        inputtext.Text = File.ReadAllText(ofd.FileName, Encoding.Default);
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
                ofd.Filter = "Текстовые файлы|*.txt";
                ofd.InitialDirectory = refPar.path_input;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputtext.Text = File.ReadAllText(ofd.FileName, Encoding.Default);
                }
                else
                {
                    return;
                }
            }
        }

        private void TextSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputtext.Text == "")
            {
                MessageBox.Show("Поле ввода, предназначенное для сохранения - пусто!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Текстовые файлы|*.txt";
                sfd.InitialDirectory = refPar.path_input;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, inputtext.Text, Encoding.Default);
                }
            }
        }

        private void Button_Check_Click(object sender, EventArgs e)
        {
            error_flag = false;
            if (inputtext.Text == "")
            {
                MessageBox.Show("Поле ввода, предназначенное для сохранения - пусто!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error_flag = true;                
            }
            string[] textlines = new string[inputtext.Lines.Length];
            for (int i = 0; i < textlines.Length; i++)
            {
                textlines[i] = inputtext.Lines[i];
            }
            if (textlines.Length < 5)
            {
                MessageBox.Show("В словаре понятий слишком мало записей (нужно не меньше четырёх)!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error_flag = true;
                return;
            }
            for (int i = 0; i < textlines.Length; i++)
            {
                if (i == 0)
                {
                    string[] split_first = textlines[i].Split(' ');
                    if (split_first.Length > 2 || split_first.Length < 1)
                    {
                        MessageBox.Show("В первой строке должна содержаться тема сканворда!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error_flag = true;
                    }
                }
                else
                {
                    string[] split = textlines[i].Split('_');
                    if (split.Length != 2)
                    {
                        MessageBox.Show("Строка №" + i + ":неверный формат строки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error_flag = true;
                    }
                    else
                    {
                        string word_without_space = split[0].Replace(" ", "");
                        if (word_without_space.Length > 11 || word_without_space.Length < 2)
                        {
                            MessageBox.Show("Строка №" + i + ":длина слова превышает заданный интервал (2:11 символов)!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error_flag = true;
                        }
                        string term_clear = split[1].Trim(' ');
                        string[] terms_array = term_clear.Split(' ');
                        if (terms_array.Length > 3 || terms_array.Length < 1)
                        {
                            MessageBox.Show("Строка №" + i + ":количество слов в понятии превышает заданное количество (1:3 слова)!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error_flag = true;
                        }
                        else
                        {
                            for (int j = 0; j < terms_array.Length; j++)
                            {
                                if (terms_array[j].Length > 11 || terms_array[j].Length < 1)
                                {
                                    MessageBox.Show("Строка №" + i + ":длина слова №" + j +" в понятии превышает заданный интервал (1:11 символов)!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    error_flag = true;
                                }
                            }
                        }
                    }
                }
            }

            if (error_flag == false)
            {
                MessageBox.Show("Ошибок при составлении словаря не обнаружено.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Button_Form.Enabled = true;
            }
            

        }

        private void Button_Form_Click(object sender, EventArgs e)
        {
            Dict = new Dictionary();
            string[] textlines = new string[inputtext.Lines.Length];
            for (int i = 0; i < textlines.Length; i++)
            {
                textlines[i] = inputtext.Lines[i];
            }
            Dict.theme = textlines[0].Trim(' ');
            for (int i = 1; i < textlines.Length; i++)
            {
                WordAndTerm New = new WordAndTerm(textlines[i]);
                New.CreateTermArray();
                Dict.DictionaryList.Add(New);
            }
            outputdict.Items.Clear();
            label1.Text = "Тема: " + Dict.theme;
            for (int i = 0; i < Dict.DictionaryList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(new[] {Dict.DictionaryList[i].word, Dict.DictionaryList[i].term } );
                outputdict.Items.Add(lvi);
            }
            DictSaveToolStripMenuItem.Enabled = true;
            Button_Edit.Enabled = true;
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (inputtext.Text != "")
            {
                DialogResult dialog = MessageBox.Show("В поле ввода текста существуют записи. \nВы уверены, что желаете перезаписать их?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    inputtext.Clear();
                    string[] textlines = new string[Dict.DictionaryList.Count + 1];
                    textlines[0] = Dict.theme + "\r\n";
                    for (int i = 0; i < Dict.DictionaryList.Count; i++)
                    {
                        if (i == Dict.DictionaryList.Count - 1)
                            textlines[i + 1] = Dict.DictionaryList[i].word + " _ " + Dict.DictionaryList[i].term;
                        else
                            textlines[i + 1] = Dict.DictionaryList[i].word + " _ " + Dict.DictionaryList[i].term + "\r\n";
                    }
                    for (int i = 0; i < textlines.Length; i++)
                    {
                        inputtext.Text += textlines[i];
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                string[] textlines = new string[Dict.DictionaryList.Count + 1];
                textlines[0] = Dict.theme + "\r\n";
                for (int i = 0; i < Dict.DictionaryList.Count; i++)
                {
                    if (i == Dict.DictionaryList.Count - 1)
                        textlines[i + 1] = Dict.DictionaryList[i].word + " _ " + Dict.DictionaryList[i].term;
                    else
                        textlines[i + 1] = Dict.DictionaryList[i].word + " _ " + Dict.DictionaryList[i].term + "\r\n";
                }
                for (int i = 0; i < textlines.Length; i++)
                {
                    inputtext.Text += textlines[i];
                }
            }
        }

        private void DictCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Dict.DictionaryList.Count != 0)
            {
                DialogResult dialog = MessageBox.Show("В программе уже содерижтся сформированный словарь. Дальнейшее действие удалит его. \nВы уверены, что желаете создать новый файл?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    Dict = new Dictionary();
                    outputdict.Items.Clear();
                    Button_Edit.Enabled = false;
                }
                else
                    return;
            }
        }

        private void DictOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Dict != null)
            {
                DialogResult dialog = MessageBox.Show("В памяти программы содержится другой словарь. \nВы уверены, что желаете открыть другой файл?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
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
                        outputdict.Items.Clear();
                        label1.Text = "Тема: " + Dict.theme;
                        for (int i = 0; i < Dict.DictionaryList.Count; i++)
                        {
                            ListViewItem lvi = new ListViewItem(new[] { Dict.DictionaryList[i].word, Dict.DictionaryList[i].term });
                            outputdict.Items.Add(lvi);
                        }
                        DictSaveToolStripMenuItem.Enabled = true;
                        Button_Edit.Enabled = true;
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
                    outputdict.Items.Clear();
                    label1.Text = "Тема: " + Dict.theme;
                    for (int i = 0; i < Dict.DictionaryList.Count; i++)
                    {
                        ListViewItem lvi = new ListViewItem(new[] { Dict.DictionaryList[i].word, Dict.DictionaryList[i].term });
                        outputdict.Items.Add(lvi);
                    }
                    DictSaveToolStripMenuItem.Enabled = true;
                    Button_Edit.Enabled = true;
                }
                else
                {
                    return;
                }
            }
        }

        private void DictSaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Dict.DictionaryList.Count == 0)
            {
                MessageBox.Show("Словарь в памяти программы пуст!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Файлы словаря|*.svd";
                sfd.InitialDirectory = refPar.path_dict;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    BinaryWriter dictbw = new BinaryWriter(File.Open(sfd.FileName, FileMode.Create));
                    Dict.to_stream(dictbw);
                    dictbw.Close();
                }
            }
        }

        private void inputtext_TextChanged(object sender, EventArgs e)
        {
            Button_Form.Enabled = false;
            if (inputtext.Text == "")
            {
                Button_Check.Enabled = false;
                TextSaveToolStripMenuItem.Enabled = false;
            }
            else
            {
                Button_Check.Enabled = true;
                TextSaveToolStripMenuItem.Enabled = true;
            }
        }
    }
}
