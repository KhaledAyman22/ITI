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
            this.components = new System.ComponentModel.Container();
            this.bSrc = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.publishDate = new System.Windows.Forms.DateTimePicker();
            this.title = new System.Windows.Forms.TextBox();
            this.type = new System.Windows.Forms.TextBox();
            this.notes = new System.Windows.Forms.TextBox();
            this.advance = new System.Windows.Forms.NumericUpDown();
            this.royalty = new System.Windows.Forms.NumericUpDown();
            this.ytd = new System.Windows.Forms.NumericUpDown();
            this.price = new System.Windows.Forms.NumericUpDown();
            this.publisherCombo = new System.Windows.Forms.ComboBox();
            this.save = new System.Windows.Forms.Button();
            this.titleId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.royalty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ytd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Publisher";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(478, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Advance";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(478, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Royalty";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(478, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "YTD Sales";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(478, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Notes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(478, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "Publish Date";
            // 
            // publishDate
            // 
            this.publishDate.Location = new System.Drawing.Point(600, 297);
            this.publishDate.Name = "publishDate";
            this.publishDate.Size = new System.Drawing.Size(282, 27);
            this.publishDate.TabIndex = 10;
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(119, 143);
            this.title.MaxLength = 80;
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(282, 27);
            this.title.TabIndex = 11;
            // 
            // type
            // 
            this.type.Location = new System.Drawing.Point(119, 189);
            this.type.MaxLength = 12;
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(282, 27);
            this.type.TabIndex = 12;
            // 
            // notes
            // 
            this.notes.Location = new System.Drawing.Point(600, 244);
            this.notes.MaxLength = 200;
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(282, 27);
            this.notes.TabIndex = 13;
            // 
            // advance
            // 
            this.advance.DecimalPlaces = 5;
            this.advance.Location = new System.Drawing.Point(600, 94);
            this.advance.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.advance.Name = "advance";
            this.advance.Size = new System.Drawing.Size(282, 27);
            this.advance.TabIndex = 14;
            // 
            // royalty
            // 
            this.royalty.Location = new System.Drawing.Point(600, 143);
            this.royalty.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.royalty.Name = "royalty";
            this.royalty.Size = new System.Drawing.Size(282, 27);
            this.royalty.TabIndex = 15;
            // 
            // ytd
            // 
            this.ytd.Location = new System.Drawing.Point(600, 190);
            this.ytd.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ytd.Name = "ytd";
            this.ytd.Size = new System.Drawing.Size(282, 27);
            this.ytd.TabIndex = 16;
            // 
            // price
            // 
            this.price.DecimalPlaces = 5;
            this.price.Location = new System.Drawing.Point(119, 290);
            this.price.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(282, 27);
            this.price.TabIndex = 17;
            // 
            // publisherCombo
            // 
            this.publisherCombo.FormattingEnabled = true;
            this.publisherCombo.Location = new System.Drawing.Point(119, 239);
            this.publisherCombo.Name = "publisherCombo";
            this.publisherCombo.Size = new System.Drawing.Size(282, 28);
            this.publisherCombo.TabIndex = 18;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(390, 399);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(94, 29);
            this.save.TabIndex = 20;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // titleId
            // 
            this.titleId.Location = new System.Drawing.Point(119, 98);
            this.titleId.MaxLength = 6;
            this.titleId.Name = "titleId";
            this.titleId.Size = new System.Drawing.Size(282, 27);
            this.titleId.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 450);
            this.Controls.Add(this.titleId);
            this.Controls.Add(this.save);
            this.Controls.Add(this.publisherCombo);
            this.Controls.Add(this.price);
            this.Controls.Add(this.ytd);
            this.Controls.Add(this.royalty);
            this.Controls.Add(this.advance);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.type);
            this.Controls.Add(this.title);
            this.Controls.Add(this.publishDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.royalty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ytd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BindingSource bSrc;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private DateTimePicker publishDate;
        private TextBox title;
        private TextBox type;
        private TextBox notes;
        private NumericUpDown advance;
        private NumericUpDown royalty;
        private NumericUpDown ytd;
        private NumericUpDown price;
        private ComboBox publisherCombo;
        private Button save;
        private TextBox titleId;
    }
}