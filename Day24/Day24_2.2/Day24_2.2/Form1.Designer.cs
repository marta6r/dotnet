namespace Day24_2._2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userControlTimer21 = new UserControlTimer2();
            SuspendLayout();
            // 
            // userControlTimer21
            // 
            userControlTimer21.Location = new Point(149, 72);
            userControlTimer21.Name = "userControlTimer21";
            userControlTimer21.Size = new Size(188, 188);
            userControlTimer21.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(userControlTimer21);
            Name = "Form1";
            Text = "WinTimer2";
            ResumeLayout(false);
        }

        #endregion

        private UserControlTimer2 userControlTimer21;
    }
}
