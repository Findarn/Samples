namespace Лабиринт
{
    partial class Labirint
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPath = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.NumSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.LabirintTable = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumSize)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCreate,
            this.MenuGenerate,
            this.MenuPath,
            this.MenuClear});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(921, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuCreate
            // 
            this.MenuCreate.Name = "MenuCreate";
            this.MenuCreate.Size = new System.Drawing.Size(101, 20);
            this.MenuCreate.Text = "Создание поля";
            this.MenuCreate.Click += new System.EventHandler(this.MenuCreate_Click);
            // 
            // MenuGenerate
            // 
            this.MenuGenerate.Name = "MenuGenerate";
            this.MenuGenerate.Size = new System.Drawing.Size(109, 20);
            this.MenuGenerate.Text = "Разметка клеток";
            this.MenuGenerate.Click += new System.EventHandler(this.MenuGenerate_Click);
            // 
            // MenuPath
            // 
            this.MenuPath.Name = "MenuPath";
            this.MenuPath.Size = new System.Drawing.Size(96, 20);
            this.MenuPath.Text = "Поиск выхода";
            this.MenuPath.Click += new System.EventHandler(this.MenuPath_Click);
            // 
            // MenuClear
            // 
            this.MenuClear.Name = "MenuClear";
            this.MenuClear.Size = new System.Drawing.Size(71, 20);
            this.MenuClear.Text = "Очистить";
            this.MenuClear.Click += new System.EventHandler(this.MenuClear_Click);
            // 
            // NumSize
            // 
            this.NumSize.Location = new System.Drawing.Point(753, 4);
            this.NumSize.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.NumSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumSize.Name = "NumSize";
            this.NumSize.Size = new System.Drawing.Size(40, 20);
            this.NumSize.TabIndex = 1;
            this.NumSize.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(646, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Строки и столбцы:";
            // 
            // LabirintTable
            // 
            this.LabirintTable.ColumnCount = 2;
            this.LabirintTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LabirintTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LabirintTable.Location = new System.Drawing.Point(12, 27);
            this.LabirintTable.Name = "LabirintTable";
            this.LabirintTable.RowCount = 2;
            this.LabirintTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LabirintTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LabirintTable.Size = new System.Drawing.Size(900, 900);
            this.LabirintTable.TabIndex = 3;
            // 
            // Labirint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(921, 941);
            this.Controls.Add(this.LabirintTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumSize);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Labirint";
            this.Text = "Labirint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuGenerate;
        private System.Windows.Forms.ToolStripMenuItem MenuPath;
        private System.Windows.Forms.ToolStripMenuItem MenuClear;
        private System.Windows.Forms.NumericUpDown NumSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel LabirintTable;
    }
}

