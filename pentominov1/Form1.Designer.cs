namespace pentominov1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerPomeranje = new System.Windows.Forms.Timer(this.components);
            this.labelNaRedu = new System.Windows.Forms.Label();
            this.labelBrIgraca = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonNovaIgra = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPomeranje
            // 
            this.timerPomeranje.Interval = 500;
            this.timerPomeranje.Tick += new System.EventHandler(this.timerPomeranje_Tick);
            // 
            // labelNaRedu
            // 
            this.labelNaRedu.AutoSize = true;
            this.labelNaRedu.BackColor = System.Drawing.Color.Transparent;
            this.labelNaRedu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNaRedu.Location = new System.Drawing.Point(512, 50);
            this.labelNaRedu.Name = "labelNaRedu";
            this.labelNaRedu.Size = new System.Drawing.Size(182, 25);
            this.labelNaRedu.TabIndex = 3;
            this.labelNaRedu.Text = "IGRAČ NA REDU : ";
            // 
            // labelBrIgraca
            // 
            this.labelBrIgraca.AutoSize = true;
            this.labelBrIgraca.BackColor = System.Drawing.Color.Transparent;
            this.labelBrIgraca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBrIgraca.Location = new System.Drawing.Point(690, 44);
            this.labelBrIgraca.Name = "labelBrIgraca";
            this.labelBrIgraca.Size = new System.Drawing.Size(31, 32);
            this.labelBrIgraca.TabIndex = 4;
            this.labelBrIgraca.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(957, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "2";
            // 
            // buttonNovaIgra
            // 
            this.buttonNovaIgra.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonNovaIgra.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonNovaIgra.Location = new System.Drawing.Point(1169, 44);
            this.buttonNovaIgra.Name = "buttonNovaIgra";
            this.buttonNovaIgra.Size = new System.Drawing.Size(75, 61);
            this.buttonNovaIgra.TabIndex = 7;
            this.buttonNovaIgra.Text = "NOVA IGRA";
            this.buttonNovaIgra.UseVisualStyleBackColor = false;
            this.buttonNovaIgra.Click += new System.EventHandler(this.buttonNovaIgra_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pentominov1.Properties.Resources.kucica2;
            this.pictureBox1.Location = new System.Drawing.Point(1169, 142);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(54, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1037, 350);
            this.label3.TabIndex = 9;
            this.label3.Text = resources.GetString("label3.Text");
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1378, 644);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonNovaIgra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelBrIgraca);
            this.Controls.Add(this.labelNaRedu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PENTOMINO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerPomeranje;
        private System.Windows.Forms.Label labelNaRedu;
        private System.Windows.Forms.Label labelBrIgraca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonNovaIgra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}

