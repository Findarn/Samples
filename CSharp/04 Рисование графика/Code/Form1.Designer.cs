
namespace Task2
{
    partial class MainForm
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
            this.GBRight = new System.Windows.Forms.GroupBox();
            this.LScaleValue = new System.Windows.Forms.Label();
            this.LScaleText = new System.Windows.Forms.Label();
            this.LPointValue = new System.Windows.Forms.Label();
            this.LPointText = new System.Windows.Forms.Label();
            this.BBack = new System.Windows.Forms.Button();
            this.BColor = new System.Windows.Forms.Button();
            this.BSave = new System.Windows.Forms.Button();
            this.BRandom = new System.Windows.Forms.Button();
            this.PMain = new System.Windows.Forms.Panel();
            this.pbPanel = new System.Windows.Forms.PictureBox();
            this.GBRight.SuspendLayout();
            this.PMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // GBRight
            // 
            this.GBRight.Controls.Add(this.LScaleValue);
            this.GBRight.Controls.Add(this.LScaleText);
            this.GBRight.Controls.Add(this.LPointValue);
            this.GBRight.Controls.Add(this.LPointText);
            this.GBRight.Controls.Add(this.BBack);
            this.GBRight.Controls.Add(this.BColor);
            this.GBRight.Controls.Add(this.BSave);
            this.GBRight.Controls.Add(this.BRandom);
            this.GBRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.GBRight.Location = new System.Drawing.Point(604, 0);
            this.GBRight.Name = "GBRight";
            this.GBRight.Size = new System.Drawing.Size(180, 461);
            this.GBRight.TabIndex = 0;
            this.GBRight.TabStop = false;
            // 
            // LScaleValue
            // 
            this.LScaleValue.AutoSize = true;
            this.LScaleValue.Location = new System.Drawing.Point(141, 421);
            this.LScaleValue.Name = "LScaleValue";
            this.LScaleValue.Size = new System.Drawing.Size(33, 13);
            this.LScaleValue.TabIndex = 7;
            this.LScaleValue.Text = "100%";
            // 
            // LScaleText
            // 
            this.LScaleText.AutoSize = true;
            this.LScaleText.Location = new System.Drawing.Point(6, 421);
            this.LScaleText.Name = "LScaleText";
            this.LScaleText.Size = new System.Drawing.Size(56, 13);
            this.LScaleText.TabIndex = 6;
            this.LScaleText.Text = "Масштаб:";
            // 
            // LPointValue
            // 
            this.LPointValue.AutoSize = true;
            this.LPointValue.Location = new System.Drawing.Point(128, 441);
            this.LPointValue.Name = "LPointValue";
            this.LPointValue.Size = new System.Drawing.Size(46, 13);
            this.LPointValue.TabIndex = 5;
            this.LPointValue.Text = "999;999";
            // 
            // LPointText
            // 
            this.LPointText.AutoSize = true;
            this.LPointText.Location = new System.Drawing.Point(6, 441);
            this.LPointText.Name = "LPointText";
            this.LPointText.Size = new System.Drawing.Size(72, 13);
            this.LPointText.TabIndex = 4;
            this.LPointText.Text = "Координаты:";
            // 
            // BBack
            // 
            this.BBack.Location = new System.Drawing.Point(6, 106);
            this.BBack.Name = "BBack";
            this.BBack.Size = new System.Drawing.Size(162, 23);
            this.BBack.TabIndex = 3;
            this.BBack.Text = "Выбор фона";
            this.BBack.UseVisualStyleBackColor = true;
            this.BBack.Click += new System.EventHandler(this.BBack_Click);
            // 
            // BColor
            // 
            this.BColor.Location = new System.Drawing.Point(6, 77);
            this.BColor.Name = "BColor";
            this.BColor.Size = new System.Drawing.Size(162, 23);
            this.BColor.TabIndex = 2;
            this.BColor.Text = "Цвет графика";
            this.BColor.UseVisualStyleBackColor = true;
            this.BColor.Click += new System.EventHandler(this.BColor_Click);
            // 
            // BSave
            // 
            this.BSave.Location = new System.Drawing.Point(6, 48);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(162, 23);
            this.BSave.TabIndex = 1;
            this.BSave.Text = "Сохранить";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // BRandom
            // 
            this.BRandom.Location = new System.Drawing.Point(6, 19);
            this.BRandom.Name = "BRandom";
            this.BRandom.Size = new System.Drawing.Size(162, 23);
            this.BRandom.TabIndex = 0;
            this.BRandom.Text = "Случайная функция";
            this.BRandom.UseVisualStyleBackColor = true;
            this.BRandom.Click += new System.EventHandler(this.BRandom_Click);
            // 
            // PMain
            // 
            this.PMain.AutoScroll = true;
            this.PMain.Controls.Add(this.pbPanel);
            this.PMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMain.Location = new System.Drawing.Point(0, 0);
            this.PMain.Name = "PMain";
            this.PMain.Size = new System.Drawing.Size(604, 461);
            this.PMain.TabIndex = 1;
            this.PMain.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PMain_MouseWheel);
            // 
            // pbPanel
            // 
            this.pbPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPanel.Location = new System.Drawing.Point(0, 0);
            this.pbPanel.Name = "pbPanel";
            this.pbPanel.Size = new System.Drawing.Size(604, 461);
            this.pbPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPanel.TabIndex = 0;
            this.pbPanel.TabStop = false;
            this.pbPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPanel_MouseDown);
            this.pbPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPanel_MouseMove);
            this.pbPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPanel_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.PMain);
            this.Controls.Add(this.GBRight);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 220);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Задание 2";
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.GBRight.ResumeLayout(false);
            this.GBRight.PerformLayout();
            this.PMain.ResumeLayout(false);
            this.PMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBRight;
        private System.Windows.Forms.Button BBack;
        private System.Windows.Forms.Button BColor;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.Button BRandom;
        private System.Windows.Forms.Panel PMain;
        private System.Windows.Forms.Label LScaleValue;
        private System.Windows.Forms.Label LScaleText;
        private System.Windows.Forms.Label LPointValue;
        private System.Windows.Forms.Label LPointText;
        private System.Windows.Forms.PictureBox pbPanel;
    }
}

