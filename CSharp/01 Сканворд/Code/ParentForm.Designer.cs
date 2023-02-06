namespace Проект
{
    partial class ParentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentForm));
            this.menuParent = new System.Windows.Forms.MenuStrip();
            this.модульРаботыСоСловарёмПонятийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.модульСоставленияСканвордаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuParent
            // 
            this.menuParent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.модульРаботыСоСловарёмПонятийToolStripMenuItem,
            this.модульСоставленияСканвордаToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuParent.Location = new System.Drawing.Point(0, 0);
            this.menuParent.Name = "menuParent";
            this.menuParent.Size = new System.Drawing.Size(984, 24);
            this.menuParent.TabIndex = 1;
            this.menuParent.Text = "menuStrip1";
            // 
            // модульРаботыСоСловарёмПонятийToolStripMenuItem
            // 
            this.модульРаботыСоСловарёмПонятийToolStripMenuItem.Name = "модульРаботыСоСловарёмПонятийToolStripMenuItem";
            this.модульРаботыСоСловарёмПонятийToolStripMenuItem.Size = new System.Drawing.Size(228, 20);
            this.модульРаботыСоСловарёмПонятийToolStripMenuItem.Text = "Модуль работы со словарём понятий";
            this.модульРаботыСоСловарёмПонятийToolStripMenuItem.Click += new System.EventHandler(this.модульРаботыСоСловарёмПонятийToolStripMenuItem_Click);
            // 
            // модульСоставленияСканвордаToolStripMenuItem
            // 
            this.модульСоставленияСканвордаToolStripMenuItem.Name = "модульСоставленияСканвордаToolStripMenuItem";
            this.модульСоставленияСканвордаToolStripMenuItem.Size = new System.Drawing.Size(194, 20);
            this.модульСоставленияСканвордаToolStripMenuItem.Text = "Модуль составления сканворда";
            this.модульСоставленияСканвордаToolStripMenuItem.Click += new System.EventHandler(this.модульСоставленияСканвордаToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.menuParent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuParent;
            this.Name = "ParentForm";
            this.Text = "Автоматизированная система генерирования сканворда на заданную тему";
            this.Load += new System.EventHandler(this.ParentForm_Load);
            this.menuParent.ResumeLayout(false);
            this.menuParent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuParent;
        private System.Windows.Forms.ToolStripMenuItem модульРаботыСоСловарёмПонятийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem модульСоставленияСканвордаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

