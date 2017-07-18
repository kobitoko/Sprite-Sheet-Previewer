namespace csSpriteSheetPreviewExporter
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
            this.button1 = new System.Windows.Forms.Button();
            this.previewImageBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.GifButton = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.exportGifProgress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OpenFile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // previewImageBox
            // 
            this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewImageBox.Location = new System.Drawing.Point(3, 16);
            this.previewImageBox.Name = "previewImageBox";
            this.previewImageBox.Size = new System.Drawing.Size(580, 410);
            this.previewImageBox.TabIndex = 2;
            this.previewImageBox.TabStop = false;
            this.previewImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.previewImageBox_MouseDown);
            this.previewImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.previewImageBox_MouseMove);
            this.previewImageBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.previewImageBox_MouseWheel);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exportGifProgress);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.GifButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(168, 429);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(0, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(168, 75);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // GifButton
            // 
            this.GifButton.Location = new System.Drawing.Point(12, 398);
            this.GifButton.Name = "GifButton";
            this.GifButton.Size = new System.Drawing.Size(107, 23);
            this.GifButton.TabIndex = 0;
            this.GifButton.Text = "Export Gif";
            this.GifButton.UseVisualStyleBackColor = true;
            this.GifButton.Click += new System.EventHandler(this.GifButton_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoomOut.Location = new System.Drawing.Point(657, 13);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(18, 23);
            this.buttonZoomOut.TabIndex = 1;
            this.buttonZoomOut.Text = "-";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoomIn.Location = new System.Drawing.Point(729, 13);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(19, 23);
            this.buttonZoomIn.TabIndex = 0;
            this.buttonZoomIn.Text = "+";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.previewImageBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(168, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 429);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(754, 41);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.buttonZoomIn);
            this.groupBox4.Controls.Add(this.buttonZoomOut);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 470);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(754, 40);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(681, 14);
            this.textBox1.MaxLength = 5;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "100%";
            this.textBox1.WordWrap = false;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_TextChanged);
            // 
            // exportGifProgress
            // 
            this.exportGifProgress.Location = new System.Drawing.Point(101, 398);
            this.exportGifProgress.Name = "exportGifProgress";
            this.exportGifProgress.Size = new System.Drawing.Size(18, 11);
            this.exportGifProgress.TabIndex = 2;
            this.exportGifProgress.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 510);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox previewImageBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button GifButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ProgressBar exportGifProgress;
    }
}

