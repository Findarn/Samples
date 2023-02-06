
namespace Task2
{
    partial class FormDialog
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
            this.lFonColor = new System.Windows.Forms.Label();
            this.pbFonColor = new System.Windows.Forms.PictureBox();
            this.cbGradient = new System.Windows.Forms.CheckBox();
            this.pbStartGrad = new System.Windows.Forms.PictureBox();
            this.lStartGrad = new System.Windows.Forms.Label();
            this.pbEndGrad = new System.Windows.Forms.PictureBox();
            this.lEndGrad = new System.Windows.Forms.Label();
            this.lGradDir = new System.Windows.Forms.Label();
            this.rbDirHor = new System.Windows.Forms.RadioButton();
            this.rbDirVer = new System.Windows.Forms.RadioButton();
            this.cbGrid = new System.Windows.Forms.CheckBox();
            this.tbGridSize = new System.Windows.Forms.TextBox();
            this.lGridSize = new System.Windows.Forms.Label();
            this.lStreakSize = new System.Windows.Forms.Label();
            this.tbStreakSize = new System.Windows.Forms.TextBox();
            this.cbStreak = new System.Windows.Forms.CheckBox();
            this.cbAxisText = new System.Windows.Forms.CheckBox();
            this.cbStreakText = new System.Windows.Forms.CheckBox();
            this.lFont = new System.Windows.Forms.Label();
            this.nudFont = new System.Windows.Forms.NumericUpDown();
            this.pbColorGrid = new System.Windows.Forms.PictureBox();
            this.bOK = new System.Windows.Forms.Button();
            this.lColorGrid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFonColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartGrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEndGrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lFonColor
            // 
            this.lFonColor.AutoSize = true;
            this.lFonColor.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lFonColor.Location = new System.Drawing.Point(12, 10);
            this.lFonColor.Name = "lFonColor";
            this.lFonColor.Size = new System.Drawing.Size(105, 15);
            this.lFonColor.TabIndex = 0;
            this.lFonColor.Text = "Фоновый цвет: ";
            // 
            // pbFonColor
            // 
            this.pbFonColor.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pbFonColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFonColor.Location = new System.Drawing.Point(157, 10);
            this.pbFonColor.Name = "pbFonColor";
            this.pbFonColor.Size = new System.Drawing.Size(15, 15);
            this.pbFonColor.TabIndex = 1;
            this.pbFonColor.TabStop = false;
            this.pbFonColor.Click += new System.EventHandler(this.pbFonColor_Click);
            // 
            // cbGradient
            // 
            this.cbGradient.AutoSize = true;
            this.cbGradient.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbGradient.Location = new System.Drawing.Point(15, 35);
            this.cbGradient.Name = "cbGradient";
            this.cbGradient.Size = new System.Drawing.Size(131, 19);
            this.cbGradient.TabIndex = 2;
            this.cbGradient.Text = "Градиентный фон";
            this.cbGradient.UseVisualStyleBackColor = true;
            this.cbGradient.CheckedChanged += new System.EventHandler(this.cbGradient_CheckedChanged);
            // 
            // pbStartGrad
            // 
            this.pbStartGrad.BackColor = System.Drawing.Color.White;
            this.pbStartGrad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStartGrad.Location = new System.Drawing.Point(157, 60);
            this.pbStartGrad.Name = "pbStartGrad";
            this.pbStartGrad.Size = new System.Drawing.Size(15, 15);
            this.pbStartGrad.TabIndex = 4;
            this.pbStartGrad.TabStop = false;
            this.pbStartGrad.Visible = false;
            this.pbStartGrad.Click += new System.EventHandler(this.pbStartGrad_Click);
            // 
            // lStartGrad
            // 
            this.lStartGrad.AutoSize = true;
            this.lStartGrad.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStartGrad.Location = new System.Drawing.Point(12, 60);
            this.lStartGrad.Name = "lStartGrad";
            this.lStartGrad.Size = new System.Drawing.Size(140, 15);
            this.lStartGrad.TabIndex = 3;
            this.lStartGrad.Text = "Начальный градиент:";
            this.lStartGrad.Visible = false;
            // 
            // pbEndGrad
            // 
            this.pbEndGrad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pbEndGrad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbEndGrad.Location = new System.Drawing.Point(157, 85);
            this.pbEndGrad.Name = "pbEndGrad";
            this.pbEndGrad.Size = new System.Drawing.Size(15, 15);
            this.pbEndGrad.TabIndex = 6;
            this.pbEndGrad.TabStop = false;
            this.pbEndGrad.Visible = false;
            this.pbEndGrad.Click += new System.EventHandler(this.pbEndGrad_Click);
            // 
            // lEndGrad
            // 
            this.lEndGrad.AutoSize = true;
            this.lEndGrad.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lEndGrad.Location = new System.Drawing.Point(12, 85);
            this.lEndGrad.Name = "lEndGrad";
            this.lEndGrad.Size = new System.Drawing.Size(133, 15);
            this.lEndGrad.TabIndex = 5;
            this.lEndGrad.Text = "Конечный градиент:";
            this.lEndGrad.Visible = false;
            // 
            // lGradDir
            // 
            this.lGradDir.AutoSize = true;
            this.lGradDir.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lGradDir.Location = new System.Drawing.Point(12, 110);
            this.lGradDir.Name = "lGradDir";
            this.lGradDir.Size = new System.Drawing.Size(161, 15);
            this.lGradDir.TabIndex = 7;
            this.lGradDir.Text = "Направление градиента:";
            this.lGradDir.Visible = false;
            // 
            // rbDirHor
            // 
            this.rbDirHor.AutoSize = true;
            this.rbDirHor.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbDirHor.Location = new System.Drawing.Point(15, 135);
            this.rbDirHor.Name = "rbDirHor";
            this.rbDirHor.Size = new System.Drawing.Size(123, 19);
            this.rbDirHor.TabIndex = 8;
            this.rbDirHor.Text = "Горизонтальный";
            this.rbDirHor.UseVisualStyleBackColor = true;
            this.rbDirHor.Visible = false;
            // 
            // rbDirVer
            // 
            this.rbDirVer.AutoSize = true;
            this.rbDirVer.Checked = true;
            this.rbDirVer.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbDirVer.Location = new System.Drawing.Point(15, 160);
            this.rbDirVer.Name = "rbDirVer";
            this.rbDirVer.Size = new System.Drawing.Size(109, 19);
            this.rbDirVer.TabIndex = 9;
            this.rbDirVer.TabStop = true;
            this.rbDirVer.Text = "Вертикальный";
            this.rbDirVer.UseVisualStyleBackColor = true;
            this.rbDirVer.Visible = false;
            // 
            // cbGrid
            // 
            this.cbGrid.AutoSize = true;
            this.cbGrid.Checked = true;
            this.cbGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGrid.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbGrid.Location = new System.Drawing.Point(15, 185);
            this.cbGrid.Name = "cbGrid";
            this.cbGrid.Size = new System.Drawing.Size(61, 19);
            this.cbGrid.TabIndex = 10;
            this.cbGrid.Text = "Сетка";
            this.cbGrid.UseVisualStyleBackColor = true;
            this.cbGrid.CheckedChanged += new System.EventHandler(this.cbGrid_CheckedChanged);
            // 
            // tbGridSize
            // 
            this.tbGridSize.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbGridSize.Location = new System.Drawing.Point(130, 205);
            this.tbGridSize.Name = "tbGridSize";
            this.tbGridSize.Size = new System.Drawing.Size(46, 23);
            this.tbGridSize.TabIndex = 11;
            this.tbGridSize.Text = "1,0";
            // 
            // lGridSize
            // 
            this.lGridSize.AutoSize = true;
            this.lGridSize.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lGridSize.Location = new System.Drawing.Point(12, 210);
            this.lGridSize.Name = "lGridSize";
            this.lGridSize.Size = new System.Drawing.Size(105, 15);
            this.lGridSize.TabIndex = 12;
            this.lGridSize.Text = "Деление сетки:";
            // 
            // lStreakSize
            // 
            this.lStreakSize.AutoSize = true;
            this.lStreakSize.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStreakSize.Location = new System.Drawing.Point(12, 260);
            this.lStreakSize.Name = "lStreakSize";
            this.lStreakSize.Size = new System.Drawing.Size(112, 15);
            this.lStreakSize.TabIndex = 15;
            this.lStreakSize.Text = "Деление штриха:";
            // 
            // tbStreakSize
            // 
            this.tbStreakSize.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbStreakSize.Location = new System.Drawing.Point(130, 257);
            this.tbStreakSize.Name = "tbStreakSize";
            this.tbStreakSize.Size = new System.Drawing.Size(46, 23);
            this.tbStreakSize.TabIndex = 14;
            this.tbStreakSize.Text = "1,0";
            // 
            // cbStreak
            // 
            this.cbStreak.AutoSize = true;
            this.cbStreak.Checked = true;
            this.cbStreak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStreak.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbStreak.Location = new System.Drawing.Point(15, 235);
            this.cbStreak.Name = "cbStreak";
            this.cbStreak.Size = new System.Drawing.Size(89, 19);
            this.cbStreak.TabIndex = 13;
            this.cbStreak.Text = "Штриховка";
            this.cbStreak.UseVisualStyleBackColor = true;
            this.cbStreak.CheckedChanged += new System.EventHandler(this.cbStreak_CheckedChanged);
            // 
            // cbAxisText
            // 
            this.cbAxisText.AutoSize = true;
            this.cbAxisText.Checked = true;
            this.cbAxisText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAxisText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAxisText.Location = new System.Drawing.Point(15, 285);
            this.cbAxisText.Name = "cbAxisText";
            this.cbAxisText.Size = new System.Drawing.Size(117, 19);
            this.cbAxisText.TabIndex = 16;
            this.cbAxisText.Text = "Подписать оси";
            this.cbAxisText.UseVisualStyleBackColor = true;
            // 
            // cbStreakText
            // 
            this.cbStreakText.AutoSize = true;
            this.cbStreakText.Checked = true;
            this.cbStreakText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStreakText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbStreakText.Location = new System.Drawing.Point(15, 310);
            this.cbStreakText.Name = "cbStreakText";
            this.cbStreakText.Size = new System.Drawing.Size(159, 19);
            this.cbStreakText.TabIndex = 17;
            this.cbStreakText.Text = "Подписать штриховку";
            this.cbStreakText.UseVisualStyleBackColor = true;
            // 
            // lFont
            // 
            this.lFont.AutoSize = true;
            this.lFont.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lFont.Location = new System.Drawing.Point(12, 335);
            this.lFont.Name = "lFont";
            this.lFont.Size = new System.Drawing.Size(105, 15);
            this.lFont.TabIndex = 18;
            this.lFont.Text = "Размер шрифта:";
            // 
            // nudFont
            // 
            this.nudFont.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudFont.Location = new System.Drawing.Point(130, 333);
            this.nudFont.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudFont.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudFont.Name = "nudFont";
            this.nudFont.Size = new System.Drawing.Size(46, 23);
            this.nudFont.TabIndex = 19;
            this.nudFont.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // pbColorGrid
            // 
            this.pbColorGrid.BackColor = System.Drawing.Color.Gray;
            this.pbColorGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColorGrid.Location = new System.Drawing.Point(157, 184);
            this.pbColorGrid.Name = "pbColorGrid";
            this.pbColorGrid.Size = new System.Drawing.Size(15, 15);
            this.pbColorGrid.TabIndex = 20;
            this.pbColorGrid.TabStop = false;
            this.pbColorGrid.Click += new System.EventHandler(this.pbColorGrid_Click);
            // 
            // bOK
            // 
            this.bOK.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOK.Location = new System.Drawing.Point(45, 360);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(100, 23);
            this.bOK.TabIndex = 21;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // lColorGrid
            // 
            this.lColorGrid.AutoSize = true;
            this.lColorGrid.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lColorGrid.Location = new System.Drawing.Point(100, 185);
            this.lColorGrid.Name = "lColorGrid";
            this.lColorGrid.Size = new System.Drawing.Size(42, 15);
            this.lColorGrid.TabIndex = 22;
            this.lColorGrid.Text = "Цвет:";
            // 
            // FormDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 389);
            this.Controls.Add(this.lColorGrid);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.pbColorGrid);
            this.Controls.Add(this.nudFont);
            this.Controls.Add(this.lFont);
            this.Controls.Add(this.cbStreakText);
            this.Controls.Add(this.cbAxisText);
            this.Controls.Add(this.lStreakSize);
            this.Controls.Add(this.tbStreakSize);
            this.Controls.Add(this.cbStreak);
            this.Controls.Add(this.lGridSize);
            this.Controls.Add(this.tbGridSize);
            this.Controls.Add(this.cbGrid);
            this.Controls.Add(this.rbDirVer);
            this.Controls.Add(this.rbDirHor);
            this.Controls.Add(this.lGradDir);
            this.Controls.Add(this.pbEndGrad);
            this.Controls.Add(this.lEndGrad);
            this.Controls.Add(this.pbStartGrad);
            this.Controls.Add(this.lStartGrad);
            this.Controls.Add(this.cbGradient);
            this.Controls.Add(this.pbFonColor);
            this.Controls.Add(this.lFonColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Опции фона";
            ((System.ComponentModel.ISupportInitialize)(this.pbFonColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartGrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEndGrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lFonColor;
        private System.Windows.Forms.PictureBox pbFonColor;
        private System.Windows.Forms.CheckBox cbGradient;
        private System.Windows.Forms.PictureBox pbStartGrad;
        private System.Windows.Forms.Label lStartGrad;
        private System.Windows.Forms.PictureBox pbEndGrad;
        private System.Windows.Forms.Label lEndGrad;
        private System.Windows.Forms.Label lGradDir;
        private System.Windows.Forms.RadioButton rbDirHor;
        private System.Windows.Forms.RadioButton rbDirVer;
        private System.Windows.Forms.CheckBox cbGrid;
        private System.Windows.Forms.TextBox tbGridSize;
        private System.Windows.Forms.Label lGridSize;
        private System.Windows.Forms.Label lStreakSize;
        private System.Windows.Forms.TextBox tbStreakSize;
        private System.Windows.Forms.CheckBox cbStreak;
        private System.Windows.Forms.CheckBox cbAxisText;
        private System.Windows.Forms.CheckBox cbStreakText;
        private System.Windows.Forms.Label lFont;
        private System.Windows.Forms.NumericUpDown nudFont;
        private System.Windows.Forms.PictureBox pbColorGrid;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Label lColorGrid;
    }
}