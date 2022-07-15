namespace TurkoBey.EzanVakti.Forms
{
    partial class SettingForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAyarlar = new System.Windows.Forms.TabPage();
            this.tabPageHakkinda = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAyarlar);
            this.tabControl1.Controls.Add(this.tabPageHakkinda);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(431, 584);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageAyarlar
            // 
            this.tabPageAyarlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(119)))), ((int)(((byte)(143)))));
            this.tabPageAyarlar.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F);
            this.tabPageAyarlar.Location = new System.Drawing.Point(4, 30);
            this.tabPageAyarlar.Name = "tabPageAyarlar";
            this.tabPageAyarlar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAyarlar.Size = new System.Drawing.Size(423, 550);
            this.tabPageAyarlar.TabIndex = 0;
            this.tabPageAyarlar.Text = "Ayarlar";
            // 
            // tabPageHakkinda
            // 
            this.tabPageHakkinda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(119)))), ((int)(((byte)(143)))));
            this.tabPageHakkinda.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F);
            this.tabPageHakkinda.Location = new System.Drawing.Point(4, 30);
            this.tabPageHakkinda.Name = "tabPageHakkinda";
            this.tabPageHakkinda.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHakkinda.Size = new System.Drawing.Size(423, 550);
            this.tabPageHakkinda.TabIndex = 1;
            this.tabPageHakkinda.Text = "Hakkında";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 584);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(447, 623);
            this.MinimumSize = new System.Drawing.Size(447, 623);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAyarlar;
        private System.Windows.Forms.TabPage tabPageHakkinda;
    }
}