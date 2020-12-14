namespace NetflixApp
{
    partial class FrmPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPoint));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbxPoint = new System.Windows.Forms.ComboBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.btnPoint = new System.Windows.Forms.Button();
            this.lblEpisode = new System.Windows.Forms.Label();
            this.lblFilmName = new System.Windows.Forms.Label();
            this.pnlFilmInfos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxPoint
            // 
            this.cbxPoint.BackColor = System.Drawing.Color.DarkRed;
            this.cbxPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxPoint.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbxPoint.FormattingEnabled = true;
            this.cbxPoint.Location = new System.Drawing.Point(112, 199);
            this.cbxPoint.Name = "cbxPoint";
            this.cbxPoint.Size = new System.Drawing.Size(102, 39);
            this.cbxPoint.TabIndex = 0;
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.BackColor = System.Drawing.Color.Transparent;
            this.lblPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPoint.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPoint.Location = new System.Drawing.Point(13, 198);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(93, 36);
            this.lblPoint.TabIndex = 1;
            this.lblPoint.Text = "Puan ";
            // 
            // btnPoint
            // 
            this.btnPoint.BackColor = System.Drawing.Color.DarkRed;
            this.btnPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPoint.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPoint.Location = new System.Drawing.Point(231, 199);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(135, 39);
            this.btnPoint.TabIndex = 3;
            this.btnPoint.Text = "Gönder";
            this.btnPoint.UseVisualStyleBackColor = false;
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
            // 
            // lblEpisode
            // 
            this.lblEpisode.AutoSize = true;
            this.lblEpisode.BackColor = System.Drawing.Color.Transparent;
            this.lblEpisode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEpisode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEpisode.Location = new System.Drawing.Point(12, 114);
            this.lblEpisode.Name = "lblEpisode";
            this.lblEpisode.Size = new System.Drawing.Size(202, 32);
            this.lblEpisode.TabIndex = 6;
            this.lblEpisode.Text = "Bölüm Sayısı : ";
            // 
            // lblFilmName
            // 
            this.lblFilmName.AutoSize = true;
            this.lblFilmName.BackColor = System.Drawing.Color.Transparent;
            this.lblFilmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFilmName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFilmName.Location = new System.Drawing.Point(13, 62);
            this.lblFilmName.Name = "lblFilmName";
            this.lblFilmName.Size = new System.Drawing.Size(79, 32);
            this.lblFilmName.TabIndex = 5;
            this.lblFilmName.Text = "Adı : ";
            // 
            // pnlFilmInfos
            // 
            this.pnlFilmInfos.AutoSize = true;
            this.pnlFilmInfos.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilmInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pnlFilmInfos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlFilmInfos.Location = new System.Drawing.Point(12, 9);
            this.pnlFilmInfos.Name = "pnlFilmInfos";
            this.pnlFilmInfos.Size = new System.Drawing.Size(272, 38);
            this.pnlFilmInfos.TabIndex = 4;
            this.pnlFilmInfos.Text = "Program Bilgileri";
            // 
            // FrmPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(663, 396);
            this.Controls.Add(this.lblEpisode);
            this.Controls.Add(this.lblFilmName);
            this.Controls.Add(this.pnlFilmInfos);
            this.Controls.Add(this.btnPoint);
            this.Controls.Add(this.cbxPoint);
            this.Controls.Add(this.lblPoint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPoint_FormClosing);
            this.Load += new System.EventHandler(this.FrmPoint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbxPoint;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Button btnPoint;
        private System.Windows.Forms.Label lblEpisode;
        private System.Windows.Forms.Label lblFilmName;
        private System.Windows.Forms.Label pnlFilmInfos;
    }
}