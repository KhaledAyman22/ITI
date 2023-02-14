namespace Task_2
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
            this.color = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // color
            // 
            this.color.Location = new System.Drawing.Point(338, 409);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(94, 29);
            this.color.TabIndex = 0;
            this.color.Text = "Color";
            this.color.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.color);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.winMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.winMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.winMouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Button color;
    }
}