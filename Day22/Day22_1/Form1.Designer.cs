﻿namespace Day22_1
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox4 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(363, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(164, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(363, 87);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(164, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(363, 132);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(164, 27);
            textBox3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(154, 41);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 3;
            label1.Text = "Введите значение X:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(155, 87);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 4;
            label2.Text = "Введите значение Y:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(155, 135);
            label3.Name = "label3";
            label3.Size = new Size(151, 20);
            label3.TabIndex = 5;
            label3.Text = "Введите значение Z:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(154, 199);
            label4.Name = "label4";
            label4.Size = new Size(257, 20);
            label4.TabIndex = 6;
            label4.Text = "Результат выполнения программы:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(155, 254);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(496, 27);
            textBox4.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(579, 328);
            button1.Name = "button1";
            button1.Size = new Size(111, 29);
            button1.TabIndex = 8;
            button1.Text = "Выполнить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox4;
        private Button button1;
    }
}
