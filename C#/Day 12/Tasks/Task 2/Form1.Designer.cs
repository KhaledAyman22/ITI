namespace Task_2
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
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblPrdID = new System.Windows.Forms.Label();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.numUnitsInStock = new System.Windows.Forms.NumericUpDown();
            this.btnMovePrev = new System.Windows.Forms.Button();
            this.btnMoveNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.id_val = new System.Windows.Forms.Label();
            this.cat = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitsInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(342, 409);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(94, 29);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // lblPrdID
            // 
            this.lblPrdID.AutoSize = true;
            this.lblPrdID.Location = new System.Drawing.Point(93, 62);
            this.lblPrdID.Name = "lblPrdID";
            this.lblPrdID.Size = new System.Drawing.Size(50, 20);
            this.lblPrdID.TabIndex = 3;
            this.lblPrdID.Text = "Prd ID";
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(168, 149);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.Size = new System.Drawing.Size(150, 27);
            this.txtPrdName.TabIndex = 4;
            // 
            // numUnitsInStock
            // 
            this.numUnitsInStock.Location = new System.Drawing.Point(168, 223);
            this.numUnitsInStock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUnitsInStock.Name = "numUnitsInStock";
            this.numUnitsInStock.Size = new System.Drawing.Size(150, 27);
            this.numUnitsInStock.TabIndex = 5;
            // 
            // btnMovePrev
            // 
            this.btnMovePrev.Location = new System.Drawing.Point(273, 351);
            this.btnMovePrev.Name = "btnMovePrev";
            this.btnMovePrev.Size = new System.Drawing.Size(94, 29);
            this.btnMovePrev.TabIndex = 6;
            this.btnMovePrev.Text = "<";
            this.btnMovePrev.UseVisualStyleBackColor = true;
            // 
            // btnMoveNext
            // 
            this.btnMoveNext.Location = new System.Drawing.Point(415, 351);
            this.btnMoveNext.Name = "btnMoveNext";
            this.btnMoveNext.Size = new System.Drawing.Size(94, 29);
            this.btnMoveNext.TabIndex = 7;
            this.btnMoveNext.Text = ">";
            this.btnMoveNext.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "In Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Price";
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(168, 287);
            this.price.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(150, 27);
            this.price.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Category Name";
            // 
            // id_val
            // 
            this.id_val.AutoSize = true;
            this.id_val.Location = new System.Drawing.Point(168, 62);
            this.id_val.Name = "id_val";
            this.id_val.Size = new System.Drawing.Size(0, 20);
            this.id_val.TabIndex = 11;
            // 
            // cat
            // 
            this.cat.FormattingEnabled = true;
            this.cat.Location = new System.Drawing.Point(168, 109);
            this.cat.Name = "cat";
            this.cat.Size = new System.Drawing.Size(151, 28);
            this.cat.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.price);
            this.Controls.Add(this.id_val);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMoveNext);
            this.Controls.Add(this.btnMovePrev);
            this.Controls.Add(this.numUnitsInStock);
            this.Controls.Add(this.txtPrdName);
            this.Controls.Add(this.lblPrdID);
            this.Controls.Add(this.btnExecute);
            this.Name = "Form1";
            this.Text = "frmProductsDetailedView";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.numUnitsInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnExecute;
        private Label lblPrdID;
        private TextBox txtPrdName;
        private NumericUpDown numUnitsInStock;
        private Button btnMovePrev;
        private Button btnMoveNext;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown price;
        private Label label4;
        private Label id_val;
        private ComboBox cat;
    }
}
