namespace Day23_7
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
            label1 = new Label();
            label2 = new Label();
            listBoxArray = new ListBox();
            txtResult = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 36);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 0;
            label1.Text = "Исходный массив:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(460, 36);
            label2.Name = "label2";
            label2.Size = new Size(155, 20);
            label2.TabIndex = 1;
            label2.Text = "Полученный массив:";
            // 
            // listBoxArray
            // 
            listBoxArray.FormattingEnabled = true;
            listBoxArray.Location = new Point(59, 74);
            listBoxArray.Name = "listBoxArray";
            listBoxArray.Size = new Size(209, 324);
            listBoxArray.TabIndex = 2;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(446, 74);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(190, 324);
            txtResult.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(116, 409);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Заполнить";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(501, 409);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "Замена";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtResult);
            Controls.Add(listBoxArray);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ListBox listBoxArray;
        private TextBox txtResult;
        private Button button1;
        private Button button2;
    }
}
