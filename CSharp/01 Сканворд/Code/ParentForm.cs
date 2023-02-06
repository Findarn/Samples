using System;
using System.Windows.Forms;
using System.IO;

namespace Проект
{
    public partial class ParentForm : Form
    {
        public string path_input = "";
        public string path_dict = "";
        public string path_scan = "";

        
        public ParentForm()
        {
            InitializeComponent();
        }

        private void модульРаботыСоСловарёмПонятийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form DictForm = new Dictionary_form(this);
            DictForm.MdiParent = this;
            DictForm.Show();
        }

        private void модульСоставленияСканвордаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ScanForm = new Scan_form(this);
            ScanForm.MdiParent = this;
            ScanForm.Show();
        }

        

        private void ParentForm_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            string path1 = path + @"\1. Input";
            string path2 = path + @"\2. Dictionary";
            string path3 = path + @"\3. Scanwords";
            DirectoryInfo dirInfo1 = new DirectoryInfo(path1);
            DirectoryInfo dirInfo2 = new DirectoryInfo(path2);
            DirectoryInfo dirInfo3 = new DirectoryInfo(path3);
            if (!dirInfo1.Exists)
            {
                dirInfo1.Create();
            }
            path_input = path1;
            if (!dirInfo2.Exists)
            {
                dirInfo2.Create();

            }
            path_dict = path2;
            if (!dirInfo3.Exists)
            {
                dirInfo3.Create();
            }
            path_scan = path3;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tКурсовой проект по дисциплине \n      \"Инженерия программного обеспечения\" \nЗадача: автоматизированная система генерации сканвордов \nВыполнили: \n\tст. группы КС-17 Выростков Д.И. \n\tст. группы КС-17 Трубицына Ю.А.\nРуководитель: \n\tЗавадская Т.В.\n\t\t2020 - г. Донецк", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
