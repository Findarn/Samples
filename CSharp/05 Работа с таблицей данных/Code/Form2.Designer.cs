
namespace C_3
{
    partial class ModelForm
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.TLoad = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            this.DGV.RowTemplate.Height = 25;
            this.DGV.Size = new System.Drawing.Size(684, 571);
            this.DGV.TabIndex = 0;
            // 
            // PB
            // 
            this.PB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PB.Location = new System.Drawing.Point(0, 548);
            this.PB.Margin = new System.Windows.Forms.Padding(10);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(684, 23);
            this.PB.TabIndex = 1;
            // 
            // TLoad
            // 
            this.TLoad.Interval = 300;
            this.TLoad.Tick += new System.EventHandler(this.TLoad_Tick);
            // 
            // ModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 571);
            this.Controls.Add(this.PB);
            this.Controls.Add(this.DGV);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 610);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 300);
            this.Name = "ModelForm";
            this.ShowIcon = false;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.ModelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.Timer TLoad;
    }
}