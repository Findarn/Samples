namespace Проект
{
    partial class Dictionary_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dictionary_form));
            this.DictionaryMenu = new System.Windows.Forms.MenuStrip();
            this.TextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextCreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DictCreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DictOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DictSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputtext = new System.Windows.Forms.RichTextBox();
            this.outputdict = new System.Windows.Forms.ListView();
            this.Words = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Terms = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Button_Check = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_Form = new System.Windows.Forms.Button();
            this.Button_Edit = new System.Windows.Forms.Button();
            this.DictionaryMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DictionaryMenu
            // 
            this.DictionaryMenu.AllowMerge = false;
            this.DictionaryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TextToolStripMenuItem,
            this.DictToolStripMenuItem,
            this.InfoToolStripMenuItem});
            this.DictionaryMenu.Location = new System.Drawing.Point(0, 0);
            this.DictionaryMenu.Name = "DictionaryMenu";
            this.DictionaryMenu.Size = new System.Drawing.Size(784, 24);
            this.DictionaryMenu.TabIndex = 0;
            this.DictionaryMenu.Text = "menuStrip1";
            // 
            // TextToolStripMenuItem
            // 
            this.TextToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TextCreateToolStripMenuItem,
            this.TextOpenToolStripMenuItem,
            this.TextSaveToolStripMenuItem});
            this.TextToolStripMenuItem.Name = "TextToolStripMenuItem";
            this.TextToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.TextToolStripMenuItem.Text = "Текстовый файл";
            // 
            // TextCreateToolStripMenuItem
            // 
            this.TextCreateToolStripMenuItem.Name = "TextCreateToolStripMenuItem";
            this.TextCreateToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.TextCreateToolStripMenuItem.Text = "Создать";
            this.TextCreateToolStripMenuItem.Click += new System.EventHandler(this.TextCreateToolStripMenuItem_Click);
            // 
            // TextOpenToolStripMenuItem
            // 
            this.TextOpenToolStripMenuItem.Name = "TextOpenToolStripMenuItem";
            this.TextOpenToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.TextOpenToolStripMenuItem.Text = "Открыть";
            this.TextOpenToolStripMenuItem.Click += new System.EventHandler(this.TextOpenToolStripMenuItem_Click);
            // 
            // TextSaveToolStripMenuItem
            // 
            this.TextSaveToolStripMenuItem.Enabled = false;
            this.TextSaveToolStripMenuItem.Name = "TextSaveToolStripMenuItem";
            this.TextSaveToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.TextSaveToolStripMenuItem.Text = "Сохранить";
            this.TextSaveToolStripMenuItem.Click += new System.EventHandler(this.TextSaveToolStripMenuItem_Click);
            // 
            // DictToolStripMenuItem
            // 
            this.DictToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DictCreateToolStripMenuItem,
            this.DictOpenToolStripMenuItem,
            this.DictSaveToolStripMenuItem});
            this.DictToolStripMenuItem.Name = "DictToolStripMenuItem";
            this.DictToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.DictToolStripMenuItem.Text = "Словарь";
            // 
            // DictCreateToolStripMenuItem
            // 
            this.DictCreateToolStripMenuItem.Name = "DictCreateToolStripMenuItem";
            this.DictCreateToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.DictCreateToolStripMenuItem.Text = "Создать";
            this.DictCreateToolStripMenuItem.Click += new System.EventHandler(this.DictCreateToolStripMenuItem_Click);
            // 
            // DictOpenToolStripMenuItem
            // 
            this.DictOpenToolStripMenuItem.Name = "DictOpenToolStripMenuItem";
            this.DictOpenToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.DictOpenToolStripMenuItem.Text = "Открыть";
            this.DictOpenToolStripMenuItem.Click += new System.EventHandler(this.DictOpenToolStripMenuItem_Click);
            // 
            // DictSaveToolStripMenuItem
            // 
            this.DictSaveToolStripMenuItem.Enabled = false;
            this.DictSaveToolStripMenuItem.Name = "DictSaveToolStripMenuItem";
            this.DictSaveToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.DictSaveToolStripMenuItem.Text = "Сохранить";
            this.DictSaveToolStripMenuItem.Click += new System.EventHandler(this.DictSaveToolStripMenuItem1_Click);
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.InfoToolStripMenuItem.Text = "О программе";
            this.InfoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // inputtext
            // 
            this.inputtext.BackColor = System.Drawing.Color.Lavender;
            this.inputtext.Location = new System.Drawing.Point(12, 27);
            this.inputtext.Name = "inputtext";
            this.inputtext.Size = new System.Drawing.Size(300, 322);
            this.inputtext.TabIndex = 1;
            this.inputtext.Text = "";
            this.inputtext.WordWrap = false;
            this.inputtext.TextChanged += new System.EventHandler(this.inputtext_TextChanged);
            // 
            // outputdict
            // 
            this.outputdict.BackColor = System.Drawing.Color.Lavender;
            this.outputdict.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Words,
            this.Terms});
            this.outputdict.HideSelection = false;
            this.outputdict.Location = new System.Drawing.Point(472, 49);
            this.outputdict.Name = "outputdict";
            this.outputdict.Size = new System.Drawing.Size(300, 300);
            this.outputdict.TabIndex = 2;
            this.outputdict.UseCompatibleStateImageBehavior = false;
            this.outputdict.View = System.Windows.Forms.View.Details;
            // 
            // Words
            // 
            this.Words.Text = "Слово";
            this.Words.Width = 100;
            // 
            // Terms
            // 
            this.Terms.Text = "Понятие";
            this.Terms.Width = 200;
            // 
            // Button_Check
            // 
            this.Button_Check.Enabled = false;
            this.Button_Check.Location = new System.Drawing.Point(317, 49);
            this.Button_Check.Name = "Button_Check";
            this.Button_Check.Size = new System.Drawing.Size(150, 25);
            this.Button_Check.TabIndex = 3;
            this.Button_Check.Text = "Проверка на ошибки";
            this.Button_Check.UseVisualStyleBackColor = true;
            this.Button_Check.Click += new System.EventHandler(this.Button_Check_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(473, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Тема:";
            // 
            // Button_Form
            // 
            this.Button_Form.Enabled = false;
            this.Button_Form.Location = new System.Drawing.Point(317, 177);
            this.Button_Form.Name = "Button_Form";
            this.Button_Form.Size = new System.Drawing.Size(150, 25);
            this.Button_Form.TabIndex = 5;
            this.Button_Form.Text = "Сформировать словарь";
            this.Button_Form.UseVisualStyleBackColor = true;
            this.Button_Form.Click += new System.EventHandler(this.Button_Form_Click);
            // 
            // Button_Edit
            // 
            this.Button_Edit.Enabled = false;
            this.Button_Edit.Location = new System.Drawing.Point(317, 325);
            this.Button_Edit.Name = "Button_Edit";
            this.Button_Edit.Size = new System.Drawing.Size(150, 25);
            this.Button_Edit.TabIndex = 6;
            this.Button_Edit.Text = "Редактировать словарь";
            this.Button_Edit.UseVisualStyleBackColor = true;
            this.Button_Edit.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // Dictionary_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.Button_Edit);
            this.Controls.Add(this.Button_Form);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Check);
            this.Controls.Add(this.outputdict);
            this.Controls.Add(this.inputtext);
            this.Controls.Add(this.DictionaryMenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.DictionaryMenu;
            this.Name = "Dictionary_form";
            this.Text = "Работа со словарём";
            this.DictionaryMenu.ResumeLayout(false);
            this.DictionaryMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip DictionaryMenu;
        private System.Windows.Forms.ToolStripMenuItem TextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextCreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DictCreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DictOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DictSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
        private System.Windows.Forms.RichTextBox inputtext;
        private System.Windows.Forms.ListView outputdict;
        private System.Windows.Forms.ColumnHeader Words;
        private System.Windows.Forms.ColumnHeader Terms;
        private System.Windows.Forms.Button Button_Check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Form;
        private System.Windows.Forms.Button Button_Edit;
    }
}