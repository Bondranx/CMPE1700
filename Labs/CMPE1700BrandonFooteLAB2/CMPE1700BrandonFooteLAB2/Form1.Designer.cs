namespace CMPE1700BrandonFooteLAB2
{
    partial class frmMain
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
            this.btnNewGame = new System.Windows.Forms.Button();
            this.chbxDebug = new System.Windows.Forms.CheckBox();
            this.lblNumMines = new System.Windows.Forms.Label();
            this.lblMines = new System.Windows.Forms.Label();
            this.tmrGameTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(64, 81);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // chbxDebug
            // 
            this.chbxDebug.AutoSize = true;
            this.chbxDebug.Location = new System.Drawing.Point(104, 38);
            this.chbxDebug.Name = "chbxDebug";
            this.chbxDebug.Size = new System.Drawing.Size(58, 17);
            this.chbxDebug.TabIndex = 1;
            this.chbxDebug.Text = "Debug";
            this.chbxDebug.UseVisualStyleBackColor = true;
            this.chbxDebug.CheckedChanged += new System.EventHandler(this.chbxDebug_CheckedChanged);
            // 
            // lblNumMines
            // 
            this.lblNumMines.AutoSize = true;
            this.lblNumMines.Location = new System.Drawing.Point(63, 38);
            this.lblNumMines.Name = "lblNumMines";
            this.lblNumMines.Size = new System.Drawing.Size(13, 13);
            this.lblNumMines.TabIndex = 2;
            this.lblNumMines.Text = "0";
            this.lblNumMines.Visible = false;
            // 
            // lblMines
            // 
            this.lblMines.AutoSize = true;
            this.lblMines.Location = new System.Drawing.Point(19, 38);
            this.lblMines.Name = "lblMines";
            this.lblMines.Size = new System.Drawing.Size(38, 13);
            this.lblMines.TabIndex = 3;
            this.lblMines.Text = "Mines:";
            // 
            // tmrGameTimer
            // 
            this.tmrGameTimer.Interval = 50;
            this.tmrGameTimer.Tick += new System.EventHandler(this.tmrGameTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 117);
            this.Controls.Add(this.lblMines);
            this.Controls.Add(this.lblNumMines);
            this.Controls.Add(this.chbxDebug);
            this.Controls.Add(this.btnNewGame);
            this.Name = "frmMain";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.CheckBox chbxDebug;
        private System.Windows.Forms.Label lblNumMines;
        private System.Windows.Forms.Label lblMines;
        public System.Windows.Forms.Timer tmrGameTimer;
    }
}

