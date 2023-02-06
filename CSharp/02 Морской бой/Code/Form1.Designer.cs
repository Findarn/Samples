
namespace Warships
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Player1Name = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.PlayerCurrentAction = new System.Windows.Forms.Label();
            this.GameResult = new System.Windows.Forms.Label();
            this.BattleLog = new System.Windows.Forms.RichTextBox();
            this.Player2Field = new System.Windows.Forms.TableLayoutPanel();
            this.Player1Field = new System.Windows.Forms.TableLayoutPanel();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(984, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.новаяИграToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // Player1Name
            // 
            this.Player1Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player1Name.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Player1Name.Location = new System.Drawing.Point(12, 24);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(300, 24);
            this.Player1Name.TabIndex = 3;
            this.Player1Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player2Name
            // 
            this.Player2Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player2Name.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Player2Name.Location = new System.Drawing.Point(672, 24);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(300, 24);
            this.Player2Name.TabIndex = 4;
            this.Player2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerCurrentAction
            // 
            this.PlayerCurrentAction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PlayerCurrentAction.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerCurrentAction.Location = new System.Drawing.Point(316, 53);
            this.PlayerCurrentAction.MaximumSize = new System.Drawing.Size(350, 24);
            this.PlayerCurrentAction.Name = "PlayerCurrentAction";
            this.PlayerCurrentAction.Size = new System.Drawing.Size(350, 24);
            this.PlayerCurrentAction.TabIndex = 5;
            this.PlayerCurrentAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameResult
            // 
            this.GameResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameResult.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameResult.Location = new System.Drawing.Point(318, 314);
            this.GameResult.MaximumSize = new System.Drawing.Size(350, 40);
            this.GameResult.Name = "GameResult";
            this.GameResult.Size = new System.Drawing.Size(350, 39);
            this.GameResult.TabIndex = 7;
            this.GameResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BattleLog
            // 
            this.BattleLog.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BattleLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.BattleLog.Location = new System.Drawing.Point(316, 80);
            this.BattleLog.Name = "BattleLog";
            this.BattleLog.ReadOnly = true;
            this.BattleLog.Size = new System.Drawing.Size(350, 231);
            this.BattleLog.TabIndex = 8;
            this.BattleLog.Text = "";
            // 
            // Player2Field
            // 
            this.Player2Field.BackgroundImage = global::Warships.Properties.Resources.фон;
            this.Player2Field.ColumnCount = 2;
            this.Player2Field.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Player2Field.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Player2Field.Location = new System.Drawing.Point(672, 53);
            this.Player2Field.Name = "Player2Field";
            this.Player2Field.RowCount = 2;
            this.Player2Field.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Player2Field.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Player2Field.Size = new System.Drawing.Size(300, 300);
            this.Player2Field.TabIndex = 2;
            // 
            // Player1Field
            // 
            this.Player1Field.BackgroundImage = global::Warships.Properties.Resources.фон;
            this.Player1Field.ColumnCount = 2;
            this.Player1Field.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Player1Field.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Player1Field.Location = new System.Drawing.Point(12, 53);
            this.Player1Field.Name = "Player1Field";
            this.Player1Field.RowCount = 2;
            this.Player1Field.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Player1Field.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Player1Field.Size = new System.Drawing.Size(300, 300);
            this.Player1Field.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 361);
            this.Controls.Add(this.BattleLog);
            this.Controls.Add(this.GameResult);
            this.Controls.Add(this.PlayerCurrentAction);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.Player1Name);
            this.Controls.Add(this.Player2Field);
            this.Controls.Add(this.Player1Field);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MaximumSize = new System.Drawing.Size(1000, 400);
            this.MinimumSize = new System.Drawing.Size(1000, 400);
            this.Name = "MainForm";
            this.Text = "Война корабли";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel Player1Field;
        private System.Windows.Forms.TableLayoutPanel Player2Field;
        private System.Windows.Forms.Label Player1Name;
        private System.Windows.Forms.Label Player2Name;
        private System.Windows.Forms.Label PlayerCurrentAction;
        private System.Windows.Forms.Label GameResult;
        private System.Windows.Forms.RichTextBox BattleLog;
    }
}

