
namespace Warships
{
    partial class ConstructorForm
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
            this.Field = new System.Windows.Forms.TableLayoutPanel();
            this.Button4S = new System.Windows.Forms.Button();
            this.RB_H = new System.Windows.Forms.RadioButton();
            this.RB_V = new System.Windows.Forms.RadioButton();
            this.Button3S = new System.Windows.Forms.Button();
            this.Button2S = new System.Windows.Forms.Button();
            this.Button1S = new System.Windows.Forms.Button();
            this.TBName = new System.Windows.Forms.TextBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.Label4S = new System.Windows.Forms.Label();
            this.Label3S = new System.Windows.Forms.Label();
            this.Label2S = new System.Windows.Forms.Label();
            this.Label1S = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RB1S = new System.Windows.Forms.RadioButton();
            this.RB2S = new System.Windows.Forms.RadioButton();
            this.RB3S = new System.Windows.Forms.RadioButton();
            this.RB4S = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TBKatN1 = new System.Windows.Forms.TextBox();
            this.TBKatN2 = new System.Windows.Forms.TextBox();
            this.TBKatN3 = new System.Windows.Forms.TextBox();
            this.TBKatN4 = new System.Windows.Forms.TextBox();
            this.TBCorN1 = new System.Windows.Forms.TextBox();
            this.TBCorN2 = new System.Windows.Forms.TextBox();
            this.TBCorN3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TBFrigN1 = new System.Windows.Forms.TextBox();
            this.TBFrigN2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TBLinN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.LabelShips = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RBNoName = new System.Windows.Forms.RadioButton();
            this.RBUser = new System.Windows.Forms.RadioButton();
            this.RBStandart = new System.Windows.Forms.RadioButton();
            this.MenuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MenuDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // Field
            // 
            this.Field.BackgroundImage = global::Warships.Properties.Resources.фон;
            this.Field.ColumnCount = 2;
            this.Field.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Field.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Field.Location = new System.Drawing.Point(12, 12);
            this.Field.Name = "Field";
            this.Field.RowCount = 2;
            this.Field.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Field.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Field.Size = new System.Drawing.Size(300, 300);
            this.Field.TabIndex = 0;
            // 
            // Button4S
            // 
            this.Button4S.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button4S.Font = new System.Drawing.Font("Consolas", 12F);
            this.Button4S.Location = new System.Drawing.Point(318, 84);
            this.Button4S.Name = "Button4S";
            this.Button4S.Size = new System.Drawing.Size(170, 27);
            this.Button4S.TabIndex = 1;
            this.Button4S.Text = "Четырёхпалубный";
            this.Button4S.UseVisualStyleBackColor = true;
            this.Button4S.Click += new System.EventHandler(this.Button4S_Click);
            // 
            // RB_H
            // 
            this.RB_H.AutoSize = true;
            this.RB_H.Checked = true;
            this.RB_H.Font = new System.Drawing.Font("Consolas", 10F);
            this.RB_H.Location = new System.Drawing.Point(319, 57);
            this.RB_H.Name = "RB_H";
            this.RB_H.Size = new System.Drawing.Size(130, 21);
            this.RB_H.TabIndex = 2;
            this.RB_H.TabStop = true;
            this.RB_H.Text = "Горизонтально";
            this.RB_H.UseVisualStyleBackColor = true;
            // 
            // RB_V
            // 
            this.RB_V.AutoSize = true;
            this.RB_V.Font = new System.Drawing.Font("Consolas", 10F);
            this.RB_V.Location = new System.Drawing.Point(455, 57);
            this.RB_V.Name = "RB_V";
            this.RB_V.Size = new System.Drawing.Size(114, 21);
            this.RB_V.TabIndex = 3;
            this.RB_V.Text = "Вертикально";
            this.RB_V.UseVisualStyleBackColor = true;
            // 
            // Button3S
            // 
            this.Button3S.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button3S.Font = new System.Drawing.Font("Consolas", 12F);
            this.Button3S.Location = new System.Drawing.Point(318, 142);
            this.Button3S.Name = "Button3S";
            this.Button3S.Size = new System.Drawing.Size(170, 27);
            this.Button3S.TabIndex = 5;
            this.Button3S.Text = "Трёхпалубный";
            this.Button3S.UseVisualStyleBackColor = true;
            this.Button3S.Click += new System.EventHandler(this.Button3S_Click);
            // 
            // Button2S
            // 
            this.Button2S.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button2S.Font = new System.Drawing.Font("Consolas", 12F);
            this.Button2S.Location = new System.Drawing.Point(318, 200);
            this.Button2S.Name = "Button2S";
            this.Button2S.Size = new System.Drawing.Size(170, 27);
            this.Button2S.TabIndex = 6;
            this.Button2S.Text = "Двухпалубный";
            this.Button2S.UseVisualStyleBackColor = true;
            this.Button2S.Click += new System.EventHandler(this.Button2S_Click);
            // 
            // Button1S
            // 
            this.Button1S.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button1S.Font = new System.Drawing.Font("Consolas", 12F);
            this.Button1S.Location = new System.Drawing.Point(318, 258);
            this.Button1S.Name = "Button1S";
            this.Button1S.Size = new System.Drawing.Size(170, 27);
            this.Button1S.TabIndex = 7;
            this.Button1S.Text = "Однопалубный";
            this.Button1S.UseVisualStyleBackColor = true;
            this.Button1S.Click += new System.EventHandler(this.Button1S_Click);
            // 
            // TBName
            // 
            this.TBName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBName.Location = new System.Drawing.Point(465, 11);
            this.TBName.MaxLength = 13;
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(125, 26);
            this.TBName.TabIndex = 8;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Font = new System.Drawing.Font("Consolas", 14F);
            this.LabelName.Location = new System.Drawing.Point(319, 12);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(140, 22);
            this.LabelName.TabIndex = 9;
            this.LabelName.Text = "Имя игрока 1:";
            // 
            // Label4S
            // 
            this.Label4S.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label4S.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label4S.Font = new System.Drawing.Font("Consolas", 12F);
            this.Label4S.Location = new System.Drawing.Point(319, 114);
            this.Label4S.Name = "Label4S";
            this.Label4S.Size = new System.Drawing.Size(169, 25);
            this.Label4S.TabIndex = 10;
            this.Label4S.Text = "Не размещено: 1";
            // 
            // Label3S
            // 
            this.Label3S.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label3S.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label3S.Font = new System.Drawing.Font("Consolas", 12F);
            this.Label3S.Location = new System.Drawing.Point(319, 172);
            this.Label3S.Name = "Label3S";
            this.Label3S.Size = new System.Drawing.Size(169, 25);
            this.Label3S.TabIndex = 11;
            this.Label3S.Text = "Не размещено: 2";
            // 
            // Label2S
            // 
            this.Label2S.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2S.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label2S.Font = new System.Drawing.Font("Consolas", 12F);
            this.Label2S.Location = new System.Drawing.Point(319, 230);
            this.Label2S.Name = "Label2S";
            this.Label2S.Size = new System.Drawing.Size(169, 25);
            this.Label2S.TabIndex = 12;
            this.Label2S.Text = "Не размещено: 3";
            // 
            // Label1S
            // 
            this.Label1S.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label1S.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label1S.Font = new System.Drawing.Font("Consolas", 12F);
            this.Label1S.Location = new System.Drawing.Point(319, 288);
            this.Label1S.Name = "Label1S";
            this.Label1S.Size = new System.Drawing.Size(169, 25);
            this.Label1S.TabIndex = 14;
            this.Label1S.Text = "Не размещено: 4";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RB1S);
            this.panel1.Controls.Add(this.RB2S);
            this.panel1.Controls.Add(this.RB3S);
            this.panel1.Controls.Add(this.RB4S);
            this.panel1.Location = new System.Drawing.Point(494, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(61, 229);
            this.panel1.TabIndex = 15;
            // 
            // RB1S
            // 
            this.RB1S.AutoSize = true;
            this.RB1S.Enabled = false;
            this.RB1S.Location = new System.Drawing.Point(3, 180);
            this.RB1S.Name = "RB1S";
            this.RB1S.Size = new System.Drawing.Size(14, 13);
            this.RB1S.TabIndex = 3;
            this.RB1S.TabStop = true;
            this.RB1S.UseVisualStyleBackColor = true;
            // 
            // RB2S
            // 
            this.RB2S.AutoSize = true;
            this.RB2S.Enabled = false;
            this.RB2S.Location = new System.Drawing.Point(3, 122);
            this.RB2S.Name = "RB2S";
            this.RB2S.Size = new System.Drawing.Size(14, 13);
            this.RB2S.TabIndex = 2;
            this.RB2S.TabStop = true;
            this.RB2S.UseVisualStyleBackColor = true;
            // 
            // RB3S
            // 
            this.RB3S.AutoSize = true;
            this.RB3S.Enabled = false;
            this.RB3S.Location = new System.Drawing.Point(3, 64);
            this.RB3S.Name = "RB3S";
            this.RB3S.Size = new System.Drawing.Size(14, 13);
            this.RB3S.TabIndex = 1;
            this.RB3S.TabStop = true;
            this.RB3S.UseVisualStyleBackColor = true;
            // 
            // RB4S
            // 
            this.RB4S.AutoSize = true;
            this.RB4S.Checked = true;
            this.RB4S.Enabled = false;
            this.RB4S.Location = new System.Drawing.Point(3, 6);
            this.RB4S.Name = "RB4S";
            this.RB4S.Size = new System.Drawing.Size(14, 13);
            this.RB4S.TabIndex = 0;
            this.RB4S.TabStop = true;
            this.RB4S.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F);
            this.label1.Location = new System.Drawing.Point(217, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Катеры";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TBKatN1
            // 
            this.TBKatN1.Enabled = false;
            this.TBKatN1.Font = new System.Drawing.Font("Consolas", 9F);
            this.TBKatN1.Location = new System.Drawing.Point(12, 540);
            this.TBKatN1.MaxLength = 19;
            this.TBKatN1.Name = "TBKatN1";
            this.TBKatN1.Size = new System.Drawing.Size(140, 22);
            this.TBKatN1.TabIndex = 17;
            this.TBKatN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBKatN2
            // 
            this.TBKatN2.Enabled = false;
            this.TBKatN2.Font = new System.Drawing.Font("Consolas", 9F);
            this.TBKatN2.Location = new System.Drawing.Point(158, 540);
            this.TBKatN2.MaxLength = 19;
            this.TBKatN2.Name = "TBKatN2";
            this.TBKatN2.Size = new System.Drawing.Size(140, 22);
            this.TBKatN2.TabIndex = 18;
            this.TBKatN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBKatN3
            // 
            this.TBKatN3.Enabled = false;
            this.TBKatN3.Font = new System.Drawing.Font("Consolas", 9F);
            this.TBKatN3.Location = new System.Drawing.Point(304, 540);
            this.TBKatN3.MaxLength = 19;
            this.TBKatN3.Name = "TBKatN3";
            this.TBKatN3.Size = new System.Drawing.Size(140, 22);
            this.TBKatN3.TabIndex = 19;
            this.TBKatN3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBKatN4
            // 
            this.TBKatN4.Enabled = false;
            this.TBKatN4.Font = new System.Drawing.Font("Consolas", 9F);
            this.TBKatN4.Location = new System.Drawing.Point(450, 540);
            this.TBKatN4.MaxLength = 19;
            this.TBKatN4.Name = "TBKatN4";
            this.TBKatN4.Size = new System.Drawing.Size(140, 22);
            this.TBKatN4.TabIndex = 20;
            this.TBKatN4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCorN1
            // 
            this.TBCorN1.Enabled = false;
            this.TBCorN1.Font = new System.Drawing.Font("Consolas", 9F);
            this.TBCorN1.Location = new System.Drawing.Point(82, 487);
            this.TBCorN1.MaxLength = 19;
            this.TBCorN1.Name = "TBCorN1";
            this.TBCorN1.Size = new System.Drawing.Size(140, 22);
            this.TBCorN1.TabIndex = 21;
            this.TBCorN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCorN2
            // 
            this.TBCorN2.Enabled = false;
            this.TBCorN2.Font = new System.Drawing.Font("Consolas", 9F);
            this.TBCorN2.Location = new System.Drawing.Point(228, 487);
            this.TBCorN2.MaxLength = 19;
            this.TBCorN2.Name = "TBCorN2";
            this.TBCorN2.Size = new System.Drawing.Size(140, 22);
            this.TBCorN2.TabIndex = 22;
            this.TBCorN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCorN3
            // 
            this.TBCorN3.Enabled = false;
            this.TBCorN3.Font = new System.Drawing.Font("Consolas", 9F);
            this.TBCorN3.Location = new System.Drawing.Point(374, 487);
            this.TBCorN3.MaxLength = 19;
            this.TBCorN3.Name = "TBCorN3";
            this.TBCorN3.Size = new System.Drawing.Size(140, 22);
            this.TBCorN3.TabIndex = 23;
            this.TBCorN3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F);
            this.label7.Location = new System.Drawing.Point(217, 459);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 25);
            this.label7.TabIndex = 24;
            this.label7.Text = "Корветы";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TBFrigN1
            // 
            this.TBFrigN1.Enabled = false;
            this.TBFrigN1.Font = new System.Drawing.Font("Consolas", 9F);
            this.TBFrigN1.Location = new System.Drawing.Point(158, 434);
            this.TBFrigN1.MaxLength = 19;
            this.TBFrigN1.Name = "TBFrigN1";
            this.TBFrigN1.Size = new System.Drawing.Size(140, 22);
            this.TBFrigN1.TabIndex = 25;
            this.TBFrigN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBFrigN2
            // 
            this.TBFrigN2.Enabled = false;
            this.TBFrigN2.Font = new System.Drawing.Font("Consolas", 9F);
            this.TBFrigN2.Location = new System.Drawing.Point(304, 434);
            this.TBFrigN2.MaxLength = 19;
            this.TBFrigN2.Name = "TBFrigN2";
            this.TBFrigN2.Size = new System.Drawing.Size(140, 22);
            this.TBFrigN2.TabIndex = 26;
            this.TBFrigN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F);
            this.label8.Location = new System.Drawing.Point(217, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 25);
            this.label8.TabIndex = 27;
            this.label8.Text = "Фрегаты";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TBLinN
            // 
            this.TBLinN.Enabled = false;
            this.TBLinN.Font = new System.Drawing.Font("Consolas", 9F);
            this.TBLinN.Location = new System.Drawing.Point(228, 381);
            this.TBLinN.MaxLength = 19;
            this.TBLinN.Name = "TBLinN";
            this.TBLinN.Size = new System.Drawing.Size(140, 22);
            this.TBLinN.TabIndex = 28;
            this.TBLinN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F);
            this.label9.Location = new System.Drawing.Point(217, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 25);
            this.label9.TabIndex = 29;
            this.label9.Text = "Линкор";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSave.Font = new System.Drawing.Font("Consolas", 12F);
            this.ButtonSave.Location = new System.Drawing.Point(216, 568);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(170, 27);
            this.ButtonSave.TabIndex = 30;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // LabelShips
            // 
            this.LabelShips.AutoSize = true;
            this.LabelShips.Font = new System.Drawing.Font("Consolas", 14F);
            this.LabelShips.Location = new System.Drawing.Point(12, 319);
            this.LabelShips.Name = "LabelShips";
            this.LabelShips.Size = new System.Drawing.Size(160, 22);
            this.LabelShips.TabIndex = 31;
            this.LabelShips.Text = "Имена кораблей:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RBNoName);
            this.panel2.Controls.Add(this.RBUser);
            this.panel2.Controls.Add(this.RBStandart);
            this.panel2.Location = new System.Drawing.Point(168, 318);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 30);
            this.panel2.TabIndex = 32;
            // 
            // RBNoName
            // 
            this.RBNoName.AutoSize = true;
            this.RBNoName.Font = new System.Drawing.Font("Consolas", 10F);
            this.RBNoName.Location = new System.Drawing.Point(297, 1);
            this.RBNoName.Name = "RBNoName";
            this.RBNoName.Size = new System.Drawing.Size(90, 21);
            this.RBNoName.TabIndex = 35;
            this.RBNoName.TabStop = true;
            this.RBNoName.Text = "Без имён";
            this.RBNoName.UseVisualStyleBackColor = true;
            this.RBNoName.CheckedChanged += new System.EventHandler(this.RBNoName_CheckedChanged);
            // 
            // RBUser
            // 
            this.RBUser.AutoSize = true;
            this.RBUser.Font = new System.Drawing.Font("Consolas", 10F);
            this.RBUser.Location = new System.Drawing.Point(136, 1);
            this.RBUser.Name = "RBUser";
            this.RBUser.Size = new System.Drawing.Size(154, 21);
            this.RBUser.TabIndex = 34;
            this.RBUser.TabStop = true;
            this.RBUser.Text = "Пользовательские";
            this.RBUser.UseVisualStyleBackColor = true;
            this.RBUser.CheckedChanged += new System.EventHandler(this.RBUser_CheckedChanged);
            // 
            // RBStandart
            // 
            this.RBStandart.AutoSize = true;
            this.RBStandart.Checked = true;
            this.RBStandart.Font = new System.Drawing.Font("Consolas", 10F);
            this.RBStandart.Location = new System.Drawing.Point(10, 1);
            this.RBStandart.Name = "RBStandart";
            this.RBStandart.Size = new System.Drawing.Size(114, 21);
            this.RBStandart.TabIndex = 33;
            this.RBStandart.TabStop = true;
            this.RBStandart.Text = "Стандартные";
            this.RBStandart.UseVisualStyleBackColor = true;
            this.RBStandart.CheckedChanged += new System.EventHandler(this.RBStandart_CheckedChanged);
            // 
            // MenuDelete
            // 
            this.MenuDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemDelete});
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(180, 26);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.Size = new System.Drawing.Size(179, 22);
            this.MenuItemDelete.Text = "Удалить корабль";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // ConstructorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 601);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LabelShips);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TBLinN);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TBFrigN2);
            this.Controls.Add(this.TBFrigN1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TBCorN3);
            this.Controls.Add(this.TBCorN2);
            this.Controls.Add(this.TBCorN1);
            this.Controls.Add(this.TBKatN4);
            this.Controls.Add(this.TBKatN3);
            this.Controls.Add(this.TBKatN2);
            this.Controls.Add(this.TBKatN1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Label1S);
            this.Controls.Add(this.Label2S);
            this.Controls.Add(this.Label3S);
            this.Controls.Add(this.Label4S);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.TBName);
            this.Controls.Add(this.Button1S);
            this.Controls.Add(this.Button2S);
            this.Controls.Add(this.Button3S);
            this.Controls.Add(this.RB_V);
            this.Controls.Add(this.RB_H);
            this.Controls.Add(this.Button4S);
            this.Controls.Add(this.Field);
            this.MaximumSize = new System.Drawing.Size(618, 640);
            this.MinimumSize = new System.Drawing.Size(618, 640);
            this.Name = "ConstructorForm";
            this.Text = "Warships - Constructor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.MenuDelete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Field;
        private System.Windows.Forms.Button Button4S;
        private System.Windows.Forms.RadioButton RB_H;
        private System.Windows.Forms.RadioButton RB_V;
        private System.Windows.Forms.Button Button3S;
        private System.Windows.Forms.Button Button2S;
        private System.Windows.Forms.Button Button1S;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label Label4S;
        private System.Windows.Forms.Label Label3S;
        private System.Windows.Forms.Label Label2S;
        private System.Windows.Forms.Label Label1S;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RB1S;
        private System.Windows.Forms.RadioButton RB2S;
        private System.Windows.Forms.RadioButton RB3S;
        private System.Windows.Forms.RadioButton RB4S;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBKatN1;
        private System.Windows.Forms.TextBox TBKatN2;
        private System.Windows.Forms.TextBox TBKatN3;
        private System.Windows.Forms.TextBox TBKatN4;
        private System.Windows.Forms.TextBox TBCorN1;
        private System.Windows.Forms.TextBox TBCorN2;
        private System.Windows.Forms.TextBox TBCorN3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBFrigN1;
        private System.Windows.Forms.TextBox TBFrigN2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TBLinN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label LabelShips;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton RBNoName;
        private System.Windows.Forms.RadioButton RBUser;
        private System.Windows.Forms.RadioButton RBStandart;
        private System.Windows.Forms.ContextMenuStrip MenuDelete;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
    }
}