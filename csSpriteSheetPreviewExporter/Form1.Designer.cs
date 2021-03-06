﻿namespace csSpriteSheetPreviewExporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.previewImageBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.exportGifProgress = new System.Windows.Forms.ProgressBar();
            this.SpriteSheetOptions = new System.Windows.Forms.GroupBox();
            this.RowsY = new System.Windows.Forms.Label();
            this.ColumnsX = new System.Windows.Forms.Label();
            this.RowsYin = new System.Windows.Forms.TextBox();
            this.ColumnsXin = new System.Windows.Forms.TextBox();
            this.GifButton = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.playButton = new System.Windows.Forms.Button();
            this.fpsValue = new System.Windows.Forms.TextBox();
            this.framesBar = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SpriteSheetOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.framesBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // previewImageBox
            // 
            this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewImageBox.Location = new System.Drawing.Point(3, 16);
            this.previewImageBox.Name = "previewImageBox";
            this.previewImageBox.Size = new System.Drawing.Size(778, 451);
            this.previewImageBox.TabIndex = 2;
            this.previewImageBox.TabStop = false;
            this.previewImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.previewImageBox_MouseDown);
            this.previewImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.previewImageBox_MouseMove);
            this.previewImageBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.previewImageBox_MouseWheel);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.exportGifProgress);
            this.groupBox1.Controls.Add(this.SpriteSheetOptions);
            this.groupBox1.Controls.Add(this.GifButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(784, 49);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // exportGifProgress
            // 
            this.exportGifProgress.Location = new System.Drawing.Point(754, 26);
            this.exportGifProgress.Name = "exportGifProgress";
            this.exportGifProgress.Size = new System.Drawing.Size(18, 11);
            this.exportGifProgress.TabIndex = 2;
            this.exportGifProgress.Visible = false;
            // 
            // SpriteSheetOptions
            // 
            this.SpriteSheetOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SpriteSheetOptions.Controls.Add(this.RowsY);
            this.SpriteSheetOptions.Controls.Add(this.ColumnsX);
            this.SpriteSheetOptions.Controls.Add(this.RowsYin);
            this.SpriteSheetOptions.Controls.Add(this.ColumnsXin);
            this.SpriteSheetOptions.Location = new System.Drawing.Point(146, 14);
            this.SpriteSheetOptions.Name = "SpriteSheetOptions";
            this.SpriteSheetOptions.Size = new System.Drawing.Size(205, 37);
            this.SpriteSheetOptions.TabIndex = 1;
            this.SpriteSheetOptions.TabStop = false;
            // 
            // RowsY
            // 
            this.RowsY.AutoSize = true;
            this.RowsY.Location = new System.Drawing.Point(114, 12);
            this.RowsY.Name = "RowsY";
            this.RowsY.Size = new System.Drawing.Size(34, 13);
            this.RowsY.TabIndex = 4;
            this.RowsY.Text = "Rows";
            // 
            // ColumnsX
            // 
            this.ColumnsX.AutoSize = true;
            this.ColumnsX.Location = new System.Drawing.Point(6, 12);
            this.ColumnsX.Name = "ColumnsX";
            this.ColumnsX.Size = new System.Drawing.Size(47, 13);
            this.ColumnsX.TabIndex = 3;
            this.ColumnsX.Text = "Columns";
            // 
            // RowsYin
            // 
            this.RowsYin.Location = new System.Drawing.Point(154, 9);
            this.RowsYin.Name = "RowsYin";
            this.RowsYin.Size = new System.Drawing.Size(40, 20);
            this.RowsYin.TabIndex = 1;
            this.RowsYin.Text = "1";
            this.RowsYin.TextChanged += new System.EventHandler(this.RowsYin_TextChanged);
            // 
            // ColumnsXin
            // 
            this.ColumnsXin.Location = new System.Drawing.Point(59, 9);
            this.ColumnsXin.Name = "ColumnsXin";
            this.ColumnsXin.Size = new System.Drawing.Size(40, 20);
            this.ColumnsXin.TabIndex = 0;
            this.ColumnsXin.Text = "1";
            this.ColumnsXin.TextChanged += new System.EventHandler(this.ColumnsXin_TextChanged);
            // 
            // GifButton
            // 
            this.GifButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GifButton.Location = new System.Drawing.Point(672, 14);
            this.GifButton.Name = "GifButton";
            this.GifButton.Size = new System.Drawing.Size(100, 23);
            this.GifButton.TabIndex = 0;
            this.GifButton.Text = "Export Gif";
            this.GifButton.UseVisualStyleBackColor = true;
            this.GifButton.Click += new System.EventHandler(this.GifButton_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoomOut.Location = new System.Drawing.Point(687, 13);
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
            this.buttonZoomIn.Location = new System.Drawing.Point(759, 13);
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
            this.groupBox2.Location = new System.Drawing.Point(0, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 470);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // playButton
            // 
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.playButton.Location = new System.Drawing.Point(100, 14);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(23, 23);
            this.playButton.TabIndex = 4;
            this.playButton.Text = "|>";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // fpsValue
            // 
            this.fpsValue.Location = new System.Drawing.Point(50, 15);
            this.fpsValue.Name = "fpsValue";
            this.fpsValue.Size = new System.Drawing.Size(27, 20);
            this.fpsValue.TabIndex = 3;
            this.fpsValue.Text = "30";
            this.fpsValue.TextChanged += new System.EventHandler(this.fpsValue_TextChanged);
            // 
            // framesBar
            // 
            this.framesBar.AutoSize = false;
            this.framesBar.LargeChange = 1;
            this.framesBar.Location = new System.Drawing.Point(129, 13);
            this.framesBar.Maximum = 2;
            this.framesBar.Name = "framesBar";
            this.framesBar.Size = new System.Drawing.Size(552, 35);
            this.framesBar.TabIndex = 2;
            this.framesBar.Scroll += new System.EventHandler(this.framesBar_Scroll);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fpsLabel);
            this.groupBox4.Controls.Add(this.playButton);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.fpsValue);
            this.groupBox4.Controls.Add(this.buttonZoomIn);
            this.groupBox4.Controls.Add(this.framesBar);
            this.groupBox4.Controls.Add(this.buttonZoomOut);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 519);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(784, 42);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(20, 17);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(24, 13);
            this.fpsLabel.TabIndex = 5;
            this.fpsLabel.Text = "Fps";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(711, 14);
            this.textBox1.MaxLength = 5;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "100%";
            this.textBox1.WordWrap = false;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Sprite Sheet Previewer";
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.SpriteSheetOptions.ResumeLayout(false);
            this.SpriteSheetOptions.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.framesBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox previewImageBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button GifButton;
        private System.Windows.Forms.GroupBox SpriteSheetOptions;
        private System.Windows.Forms.ProgressBar exportGifProgress;
        private System.Windows.Forms.TrackBar framesBar;
        private System.Windows.Forms.TextBox fpsValue;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TextBox RowsYin;
        private System.Windows.Forms.TextBox ColumnsXin;
        private System.Windows.Forms.Label RowsY;
        private System.Windows.Forms.Label ColumnsX;
        private System.Windows.Forms.Label fpsLabel;
    }
}

