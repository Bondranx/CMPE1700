namespace CMPE1700BrandonFooteICA6
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
            this.tkbNumBlocks = new System.Windows.Forms.TrackBar();
            this.lblNumBlocks = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnFillColor = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.lblFillColor = new System.Windows.Forms.Label();
            this.lblColorDisplay = new System.Windows.Forms.Label();
            this.cldNewDialog = new System.Windows.Forms.ColorDialog();
            this.tmrFillTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tkbNumBlocks)).BeginInit();
            this.SuspendLayout();
            // 
            // tkbNumBlocks
            // 
            this.tkbNumBlocks.LargeChange = 200;
            this.tkbNumBlocks.Location = new System.Drawing.Point(12, 25);
            this.tkbNumBlocks.Maximum = 3000;
            this.tkbNumBlocks.Minimum = 100;
            this.tkbNumBlocks.Name = "tkbNumBlocks";
            this.tkbNumBlocks.Size = new System.Drawing.Size(310, 45);
            this.tkbNumBlocks.SmallChange = 10;
            this.tkbNumBlocks.TabIndex = 0;
            this.tkbNumBlocks.TickFrequency = 100;
            this.tkbNumBlocks.Value = 1500;
            // 
            // lblNumBlocks
            // 
            this.lblNumBlocks.AutoSize = true;
            this.lblNumBlocks.Location = new System.Drawing.Point(122, 9);
            this.lblNumBlocks.Name = "lblNumBlocks";
            this.lblNumBlocks.Size = new System.Drawing.Size(91, 13);
            this.lblNumBlocks.TabIndex = 1;
            this.lblNumBlocks.Text = "Number of Blocks";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(9, 57);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(25, 13);
            this.lblMax.TabIndex = 2;
            this.lblMax.Text = "100";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(291, 57);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(31, 13);
            this.lblMin.TabIndex = 3;
            this.lblMin.Text = "3000";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 138);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnFillColor
            // 
            this.btnFillColor.Location = new System.Drawing.Point(130, 138);
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnFillColor.TabIndex = 5;
            this.btnFillColor.Text = "Fill Color";
            this.btnFillColor.UseVisualStyleBackColor = true;
            this.btnFillColor.Click += new System.EventHandler(this.btnFillColor_Click);
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(247, 138);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(75, 23);
            this.btnFill.TabIndex = 6;
            this.btnFill.Text = "Fill";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // lblFillColor
            // 
            this.lblFillColor.AutoSize = true;
            this.lblFillColor.Location = new System.Drawing.Point(111, 88);
            this.lblFillColor.Name = "lblFillColor";
            this.lblFillColor.Size = new System.Drawing.Size(46, 13);
            this.lblFillColor.TabIndex = 7;
            this.lblFillColor.Text = "Fill Color";
            // 
            // lblColorDisplay
            // 
            this.lblColorDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblColorDisplay.Location = new System.Drawing.Point(162, 82);
            this.lblColorDisplay.Name = "lblColorDisplay";
            this.lblColorDisplay.Size = new System.Drawing.Size(61, 25);
            this.lblColorDisplay.TabIndex = 8;
            // 
            // tmrFillTimer
            // 
            this.tmrFillTimer.Tick += new System.EventHandler(this.tmrFillTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 172);
            this.Controls.Add(this.lblColorDisplay);
            this.Controls.Add(this.lblFillColor);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.btnFillColor);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblNumBlocks);
            this.Controls.Add(this.tkbNumBlocks);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tkbNumBlocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tkbNumBlocks;
        private System.Windows.Forms.Label lblNumBlocks;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnFillColor;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Label lblFillColor;
        private System.Windows.Forms.Label lblColorDisplay;
        private System.Windows.Forms.ColorDialog cldNewDialog;
        private System.Windows.Forms.Timer tmrFillTimer;
    }
}

