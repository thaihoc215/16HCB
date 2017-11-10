namespace _1642021_2d
{
    partial class frmSprite
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
            this.timeMove = new System.Windows.Forms.Timer(this.components);
            this.timeChange = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timeMove
            // 
            this.timeMove.Tick += new System.EventHandler(this.timeMove_Tick_1);
            // 
            // timeChange
            // 
            this.timeChange.Tick += new System.EventHandler(this.timeChange_Tick_1);
            // 
            // frmSprite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_1642021_2d.Properties.Resources.Idle__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(109, 109);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "frmSprite";
            this.Text = "Sprite2D";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timeMove;
        private System.Windows.Forms.Timer timeChange;
    }
}

