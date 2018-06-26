namespace SE_Project
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.userText = new System.Windows.Forms.RichTextBox();
            this.samText = new System.Windows.Forms.RichTextBox();
            this.sam_Label = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.waveBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 370);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // userText
            // 
            this.userText.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.userText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userText.Font = new System.Drawing.Font("Sitka Display", 10.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userText.ForeColor = System.Drawing.Color.Black;
            this.userText.Location = new System.Drawing.Point(519, 284);
            this.userText.Name = "userText";
            this.userText.Size = new System.Drawing.Size(470, 78);
            this.userText.TabIndex = 3;
            this.userText.Text = "Your Command:";
            this.userText.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.userText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clearText);
            // 
            // samText
            // 
            this.samText.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.samText.Font = new System.Drawing.Font("Sitka Display", 10.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.samText.ForeColor = System.Drawing.Color.Black;
            this.samText.Location = new System.Drawing.Point(810, 19);
            this.samText.Name = "samText";
            this.samText.ReadOnly = true;
            this.samText.Size = new System.Drawing.Size(179, 259);
            this.samText.TabIndex = 7;
            this.samText.Text = "SAM\'s response:";
            // 
            // sam_Label
            // 
            this.sam_Label.AutoSize = true;
            this.sam_Label.Font = new System.Drawing.Font("OCR A Extended", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sam_Label.ForeColor = System.Drawing.Color.Aqua;
            this.sam_Label.Location = new System.Drawing.Point(15, 12);
            this.sam_Label.Name = "sam_Label";
            this.sam_Label.Size = new System.Drawing.Size(78, 35);
            this.sam_Label.TabIndex = 8;
            this.sam_Label.Text = "SAM";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(452, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 62);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImage = global::SE_Project.Properties.Resources.Mic;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(21, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 62);
            this.button1.TabIndex = 5;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownEvent);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUpEvent);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::SE_Project.Properties.Resources.UI_giff;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // waveBox
            // 
            this.waveBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("waveBox.BackgroundImage")));
            this.waveBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.waveBox.Image = ((System.Drawing.Image)(resources.GetObject("waveBox.Image")));
            this.waveBox.Location = new System.Drawing.Point(519, 13);
            this.waveBox.Name = "waveBox";
            this.waveBox.Size = new System.Drawing.Size(285, 265);
            this.waveBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.waveBox.TabIndex = 9;
            this.waveBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1000, 370);
            this.Controls.Add(this.waveBox);
            this.Controls.Add(this.sam_Label);
            this.Controls.Add(this.samText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userText);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox userText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox samText;
        private System.Windows.Forms.Label sam_Label;
        private System.Windows.Forms.PictureBox waveBox;
    }
}

