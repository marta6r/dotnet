namespace Day23_8
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
            dataGridViewMatrix = new DataGridView();
            button1 = new Button();
            txtResult = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMatrix).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMatrix
            // 
            dataGridViewMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMatrix.Location = new Point(34, 29);
            dataGridViewMatrix.Name = "dataGridViewMatrix";
            dataGridViewMatrix.RowHeadersWidth = 51;
            dataGridViewMatrix.Size = new Size(300, 188);
            dataGridViewMatrix.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(51, 277);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(426, 29);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(289, 188);
            txtResult.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtResult);
            Controls.Add(button1);
            Controls.Add(dataGridViewMatrix);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMatrix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewMatrix;
        private Button button1;
        private TextBox txtResult;
    }
}
