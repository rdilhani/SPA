namespace SMS
{
    partial class frmEvents
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
            this.btnClickMe = new System.Windows.Forms.Button();
            this.txtCoord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblTextLength = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.trcbRed = new System.Windows.Forms.TrackBar();
            this.trcbGreen = new System.Windows.Forms.TrackBar();
            this.trcbBlue = new System.Windows.Forms.TrackBar();
            this.timerColor = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClickMe
            // 
            this.btnClickMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClickMe.Location = new System.Drawing.Point(27, 179);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(317, 71);
            this.btnClickMe.TabIndex = 0;
            this.btnClickMe.Text = "CLICK ME..";
            this.btnClickMe.UseVisualStyleBackColor = true;
            this.btnClickMe.Click += new System.EventHandler(this.btnClickMe_Click);
            // 
            // txtCoord
            // 
            this.txtCoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoord.Location = new System.Drawing.Point(217, 116);
            this.txtCoord.Name = "txtCoord";
            this.txtCoord.Size = new System.Drawing.Size(127, 38);
            this.txtCoord.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mouse Coordinates:";
            // 
            // txtText
            // 
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(217, 20);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(127, 38);
            this.txtText.TabIndex = 1;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // lblTextLength
            // 
            this.lblTextLength.AutoSize = true;
            this.lblTextLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextLength.Location = new System.Drawing.Point(31, 29);
            this.lblTextLength.Name = "lblTextLength";
            this.lblTextLength.Size = new System.Drawing.Size(138, 25);
            this.lblTextLength.TabIndex = 2;
            this.lblTextLength.Text = "Text Lenght: 0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.60976F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.39024F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.trcbRed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.trcbGreen, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.trcbBlue, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(446, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.14286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.85714F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(205, 94);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 24);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(3, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 24);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Blue;
            this.pictureBox3.Location = new System.Drawing.Point(3, 66);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 24);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // trcbRed
            // 
            this.trcbRed.Location = new System.Drawing.Point(35, 3);
            this.trcbRed.Maximum = 255;
            this.trcbRed.Name = "trcbRed";
            this.trcbRed.Size = new System.Drawing.Size(167, 24);
            this.trcbRed.TabIndex = 1;
            // 
            // trcbGreen
            // 
            this.trcbGreen.Location = new System.Drawing.Point(35, 33);
            this.trcbGreen.Maximum = 255;
            this.trcbGreen.Name = "trcbGreen";
            this.trcbGreen.Size = new System.Drawing.Size(167, 27);
            this.trcbGreen.TabIndex = 1;
            // 
            // trcbBlue
            // 
            this.trcbBlue.Location = new System.Drawing.Point(35, 66);
            this.trcbBlue.Maximum = 255;
            this.trcbBlue.Name = "trcbBlue";
            this.trcbBlue.Size = new System.Drawing.Size(167, 25);
            this.trcbBlue.TabIndex = 1;
            // 
            // timerColor
            // 
            this.timerColor.Enabled = true;
            this.timerColor.Interval = 20;
            this.timerColor.Tick += new System.EventHandler(this.timerColor_Tick);
            // 
            // frmEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 292);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblTextLength);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCoord);
            this.Controls.Add(this.btnClickMe);
            this.Name = "frmEvents";
            this.Text = "frmEvents";
            this.Load += new System.EventHandler(this.frmEvents_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmEvents_MouseMove);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClickMe;
        private System.Windows.Forms.TextBox txtCoord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblTextLength;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TrackBar trcbRed;
        private System.Windows.Forms.TrackBar trcbGreen;
        private System.Windows.Forms.TrackBar trcbBlue;
        private System.Windows.Forms.Timer timerColor;
    }
}