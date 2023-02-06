namespace Проект
{
    partial class Scan_form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scan_form));
            this.ScanMenu = new System.Windows.Forms.MenuStrip();
            this.сканвордToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.словарьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableScan = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChoseRows = new System.Windows.Forms.NumericUpDown();
            this.ChoseColumns = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.типЯчейкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.неопределеноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.понятиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.букваСловаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.понятиеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.направлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вправоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.внизToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стартоваяПозицияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сверхуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сверхусправаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.снизусправаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.снизуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.снизуслеваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слеваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слевасверхуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьМакетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьМакетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.экспортСканвордаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.ScanMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChoseRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoseColumns)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScanMenu
            // 
            this.ScanMenu.AllowMerge = false;
            this.ScanMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сканвордToolStripMenuItem,
            this.словарьToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.ScanMenu.Location = new System.Drawing.Point(0, 0);
            this.ScanMenu.Name = "ScanMenu";
            this.ScanMenu.Size = new System.Drawing.Size(822, 24);
            this.ScanMenu.TabIndex = 0;
            this.ScanMenu.Text = "menuStrip1";
            // 
            // сканвордToolStripMenuItem
            // 
            this.сканвордToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьМакетToolStripMenuItem,
            this.сохранитьМакетToolStripMenuItem,
            this.toolStripMenuItem1,
            this.экспортСканвордаToolStripMenuItem});
            this.сканвордToolStripMenuItem.Name = "сканвордToolStripMenuItem";
            this.сканвордToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.сканвордToolStripMenuItem.Text = "Сканворд";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Enabled = false;
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.создатьToolStripMenuItem.Text = "Создать макет";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // словарьToolStripMenuItem
            // 
            this.словарьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.очиститьToolStripMenuItem});
            this.словарьToolStripMenuItem.Name = "словарьToolStripMenuItem";
            this.словарьToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.словарьToolStripMenuItem.Text = "Словарь";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Enabled = false;
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справкаToolStripMenuItem.Text = "О программе";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // tableScan
            // 
            this.tableScan.ColumnCount = 2;
            this.tableScan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableScan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableScan.Location = new System.Drawing.Point(12, 50);
            this.tableScan.Margin = new System.Windows.Forms.Padding(0);
            this.tableScan.Name = "tableScan";
            this.tableScan.RowCount = 2;
            this.tableScan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableScan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableScan.Size = new System.Drawing.Size(800, 800);
            this.tableScan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Строки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(137, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Столбцы";
            // 
            // ChoseRows
            // 
            this.ChoseRows.Location = new System.Drawing.Point(81, 27);
            this.ChoseRows.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.ChoseRows.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ChoseRows.Name = "ChoseRows";
            this.ChoseRows.Size = new System.Drawing.Size(50, 20);
            this.ChoseRows.TabIndex = 8;
            this.ChoseRows.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ChoseColumns
            // 
            this.ChoseColumns.Location = new System.Drawing.Point(217, 27);
            this.ChoseColumns.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.ChoseColumns.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ChoseColumns.Name = "ChoseColumns";
            this.ChoseColumns.Size = new System.Drawing.Size(50, 20);
            this.ChoseColumns.TabIndex = 9;
            this.ChoseColumns.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типЯчейкиToolStripMenuItem,
            this.направлениеToolStripMenuItem,
            this.стартоваяПозицияToolStripMenuItem,
            this.понятиеToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 92);
            // 
            // типЯчейкиToolStripMenuItem
            // 
            this.типЯчейкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.неопределеноToolStripMenuItem,
            this.понятиеToolStripMenuItem,
            this.букваСловаToolStripMenuItem});
            this.типЯчейкиToolStripMenuItem.Name = "типЯчейкиToolStripMenuItem";
            this.типЯчейкиToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.типЯчейкиToolStripMenuItem.Text = "Тип ячейки";
            // 
            // неопределеноToolStripMenuItem
            // 
            this.неопределеноToolStripMenuItem.Name = "неопределеноToolStripMenuItem";
            this.неопределеноToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.неопределеноToolStripMenuItem.Text = "Неопределено";
            this.неопределеноToolStripMenuItem.Click += new System.EventHandler(this.неопределеноToolStripMenuItem_Click);
            // 
            // понятиеToolStripMenuItem
            // 
            this.понятиеToolStripMenuItem.Name = "понятиеToolStripMenuItem";
            this.понятиеToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.понятиеToolStripMenuItem.Text = "Понятие";
            this.понятиеToolStripMenuItem.Click += new System.EventHandler(this.понятиеToolStripMenuItem_Click);
            // 
            // букваСловаToolStripMenuItem
            // 
            this.букваСловаToolStripMenuItem.Name = "букваСловаToolStripMenuItem";
            this.букваСловаToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.букваСловаToolStripMenuItem.Text = "Буква слова";
            // 
            // понятиеToolStripMenuItem1
            // 
            this.понятиеToolStripMenuItem1.Name = "понятиеToolStripMenuItem1";
            this.понятиеToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.понятиеToolStripMenuItem1.Text = "Понятие";
            // 
            // направлениеToolStripMenuItem
            // 
            this.направлениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вправоToolStripMenuItem,
            this.внизToolStripMenuItem});
            this.направлениеToolStripMenuItem.Name = "направлениеToolStripMenuItem";
            this.направлениеToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.направлениеToolStripMenuItem.Text = "Направление";
            // 
            // вправоToolStripMenuItem
            // 
            this.вправоToolStripMenuItem.Name = "вправоToolStripMenuItem";
            this.вправоToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.вправоToolStripMenuItem.Text = "Вправо";
            this.вправоToolStripMenuItem.Click += new System.EventHandler(this.вправоToolStripMenuItem_Click);
            // 
            // внизToolStripMenuItem
            // 
            this.внизToolStripMenuItem.Name = "внизToolStripMenuItem";
            this.внизToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.внизToolStripMenuItem.Text = "Вниз";
            this.внизToolStripMenuItem.Click += new System.EventHandler(this.внизToolStripMenuItem_Click);
            // 
            // стартоваяПозицияToolStripMenuItem
            // 
            this.стартоваяПозицияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сверхуToolStripMenuItem,
            this.сверхусправаToolStripMenuItem,
            this.справаToolStripMenuItem,
            this.снизусправаToolStripMenuItem,
            this.снизуToolStripMenuItem,
            this.снизуслеваToolStripMenuItem,
            this.слеваToolStripMenuItem,
            this.слевасверхуToolStripMenuItem});
            this.стартоваяПозицияToolStripMenuItem.Name = "стартоваяПозицияToolStripMenuItem";
            this.стартоваяПозицияToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.стартоваяПозицияToolStripMenuItem.Text = "Стартовая позиция";
            // 
            // сверхуToolStripMenuItem
            // 
            this.сверхуToolStripMenuItem.Name = "сверхуToolStripMenuItem";
            this.сверхуToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.сверхуToolStripMenuItem.Text = "Сверху";
            this.сверхуToolStripMenuItem.Click += new System.EventHandler(this.сверхуToolStripMenuItem_Click);
            // 
            // сверхусправаToolStripMenuItem
            // 
            this.сверхусправаToolStripMenuItem.Name = "сверхусправаToolStripMenuItem";
            this.сверхусправаToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.сверхусправаToolStripMenuItem.Text = "Сверху-справа";
            this.сверхусправаToolStripMenuItem.Click += new System.EventHandler(this.сверхусправаToolStripMenuItem_Click);
            // 
            // справаToolStripMenuItem
            // 
            this.справаToolStripMenuItem.Name = "справаToolStripMenuItem";
            this.справаToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.справаToolStripMenuItem.Text = "Справа";
            this.справаToolStripMenuItem.Click += new System.EventHandler(this.справаToolStripMenuItem_Click);
            // 
            // снизусправаToolStripMenuItem
            // 
            this.снизусправаToolStripMenuItem.Name = "снизусправаToolStripMenuItem";
            this.снизусправаToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.снизусправаToolStripMenuItem.Text = "Снизу-справа";
            this.снизусправаToolStripMenuItem.Click += new System.EventHandler(this.снизусправаToolStripMenuItem_Click);
            // 
            // снизуToolStripMenuItem
            // 
            this.снизуToolStripMenuItem.Name = "снизуToolStripMenuItem";
            this.снизуToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.снизуToolStripMenuItem.Text = "Снизу";
            this.снизуToolStripMenuItem.Click += new System.EventHandler(this.снизуToolStripMenuItem_Click);
            // 
            // снизуслеваToolStripMenuItem
            // 
            this.снизуслеваToolStripMenuItem.Name = "снизуслеваToolStripMenuItem";
            this.снизуслеваToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.снизуслеваToolStripMenuItem.Text = "Снизу-слева";
            this.снизуслеваToolStripMenuItem.Click += new System.EventHandler(this.снизуслеваToolStripMenuItem_Click);
            // 
            // слеваToolStripMenuItem
            // 
            this.слеваToolStripMenuItem.Name = "слеваToolStripMenuItem";
            this.слеваToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.слеваToolStripMenuItem.Text = "Слева";
            this.слеваToolStripMenuItem.Click += new System.EventHandler(this.слеваToolStripMenuItem_Click);
            // 
            // слевасверхуToolStripMenuItem
            // 
            this.слевасверхуToolStripMenuItem.Name = "слевасверхуToolStripMenuItem";
            this.слевасверхуToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.слевасверхуToolStripMenuItem.Text = "Слева-сверху";
            this.слевасверхуToolStripMenuItem.Click += new System.EventHandler(this.слевасверхуToolStripMenuItem_Click);
            // 
            // открытьМакетToolStripMenuItem
            // 
            this.открытьМакетToolStripMenuItem.Name = "открытьМакетToolStripMenuItem";
            this.открытьМакетToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьМакетToolStripMenuItem.Text = "Открыть макет";
            this.открытьМакетToolStripMenuItem.Click += new System.EventHandler(this.открытьМакетToolStripMenuItem_Click);
            // 
            // сохранитьМакетToolStripMenuItem
            // 
            this.сохранитьМакетToolStripMenuItem.Enabled = false;
            this.сохранитьМакетToolStripMenuItem.Name = "сохранитьМакетToolStripMenuItem";
            this.сохранитьМакетToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьМакетToolStripMenuItem.Text = "Сохранить макет";
            this.сохранитьМакетToolStripMenuItem.Click += new System.EventHandler(this.сохранитьМакетToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // экспортСканвордаToolStripMenuItem
            // 
            this.экспортСканвордаToolStripMenuItem.Enabled = false;
            this.экспортСканвордаToolStripMenuItem.Name = "экспортСканвордаToolStripMenuItem";
            this.экспортСканвордаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.экспортСканвордаToolStripMenuItem.Text = "Экспорт сканворда";
            this.экспортСканвордаToolStripMenuItem.Click += new System.EventHandler(this.экспортСканвордаToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(273, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Тема сканворда:";
            // 
            // Scan_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(822, 861);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChoseColumns);
            this.Controls.Add(this.ChoseRows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableScan);
            this.Controls.Add(this.ScanMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ScanMenu;
            this.Name = "Scan_form";
            this.Text = "Составление сканворда";
            this.ScanMenu.ResumeLayout(false);
            this.ScanMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChoseRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoseColumns)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ScanMenu;
        private System.Windows.Forms.ToolStripMenuItem сканвордToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem словарьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableScan;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ChoseRows;
        private System.Windows.Forms.NumericUpDown ChoseColumns;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem типЯчейкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem неопределеноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem понятиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem букваСловаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem понятиеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem направлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вправоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem внизToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стартоваяПозицияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сверхуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сверхусправаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снизусправаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снизуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снизуслеваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слеваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слевасверхуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьМакетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьМакетToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem экспортСканвордаToolStripMenuItem;
        private System.Windows.Forms.Label label3;
    }
}