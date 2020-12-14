namespace NetflixApp
{
    partial class FrmMyAccount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMyAccount));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblWarning = new System.Windows.Forms.Label();
            this.cbxSelect = new System.Windows.Forms.ComboBox();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnWatch = new System.Windows.Forms.Button();
            this.cbxTur = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.GridColor = System.Drawing.Color.DarkRed;
            this.dataGridView1.Location = new System.Drawing.Point(0, 223);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1122, 285);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWarning.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWarning.Location = new System.Drawing.Point(235, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(560, 20);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "Öncelikle filmi veya diziyi hangi bilgiye göre arayacağınızı seçiniz";
            // 
            // cbxSelect
            // 
            this.cbxSelect.BackColor = System.Drawing.Color.DarkRed;
            this.cbxSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxSelect.ForeColor = System.Drawing.Color.White;
            this.cbxSelect.FormattingEnabled = true;
            this.cbxSelect.Items.AddRange(new object[] {
            "Film/Dizi adına göre",
            "Türüne göre"});
            this.cbxSelect.Location = new System.Drawing.Point(230, 35);
            this.cbxSelect.Name = "cbxSelect";
            this.cbxSelect.Size = new System.Drawing.Size(222, 28);
            this.cbxSelect.TabIndex = 2;
            this.cbxSelect.SelectedIndexChanged += new System.EventHandler(this.cbxSelect_SelectedIndexChanged);
            // 
            // tbxSearch
            // 
            this.tbxSearch.BackColor = System.Drawing.Color.DarkRed;
            this.tbxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxSearch.ForeColor = System.Drawing.Color.White;
            this.tbxSearch.Location = new System.Drawing.Point(458, 36);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(222, 27);
            this.tbxSearch.TabIndex = 3;
            this.tbxSearch.Visible = false;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // btnWatch
            // 
            this.btnWatch.BackColor = System.Drawing.Color.DarkRed;
            this.btnWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnWatch.ForeColor = System.Drawing.Color.White;
            this.btnWatch.Location = new System.Drawing.Point(701, 30);
            this.btnWatch.Name = "btnWatch";
            this.btnWatch.Size = new System.Drawing.Size(136, 36);
            this.btnWatch.TabIndex = 4;
            this.btnWatch.Text = "İzle";
            this.btnWatch.UseVisualStyleBackColor = false;
            this.btnWatch.Click += new System.EventHandler(this.btnWatch_Click);
            // 
            // cbxTur
            // 
            this.cbxTur.BackColor = System.Drawing.Color.DarkRed;
            this.cbxTur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxTur.ForeColor = System.Drawing.Color.White;
            this.cbxTur.FormattingEnabled = true;
            this.cbxTur.Items.AddRange(new object[] {
            "Aksiyon ve Macera",
            "Bilim Kurgu ve Fantastik Yapımlar",
            "Romantik",
            "Drama",
            "Çocuk ve Aile",
            "Belgesel",
            "Komedi",
            "Aksiyon",
            "Korku",
            "Bilim ve Doğa",
            "Gerilim",
            "Anime",
            "Reality Program",
            "Bilim Kurgu"});
            this.cbxTur.Location = new System.Drawing.Point(458, 36);
            this.cbxTur.Name = "cbxTur";
            this.cbxTur.Size = new System.Drawing.Size(222, 28);
            this.cbxTur.TabIndex = 5;
            this.cbxTur.Visible = false;
            this.cbxTur.SelectedIndexChanged += new System.EventHandler(this.cbxTur_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1074, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(967, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Çıkış yap";
            // 
            // FrmMyAccount
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1122, 508);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbxTur);
            this.Controls.Add(this.btnWatch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.cbxSelect);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMyAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hesabım";
            this.Load += new System.EventHandler(this.FrmMyAccount_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.ComboBox cbxSelect;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnWatch;
        private System.Windows.Forms.ComboBox cbxTur;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;

        #endregion
        //private NetflixDBDataSet netflixDBDataSet;
        //private System.Windows.Forms.BindingSource programBindingSource;
        //private NetflixDBDataSetTableAdapters.ProgramTableAdapter programTableAdapter;
        //private System.Windows.Forms.BindingSource netflixDBDataSetBindingSource;
        //private System.Windows.Forms.DataGridView dataGridView1;
    }
}