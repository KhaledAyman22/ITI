namespace ADO_WinAPP
{
    partial class frmProductsDetailedView
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
            this.lstPrds = new System.Windows.Forms.ListBox();
            this.txtNewPrice = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblPrdID = new System.Windows.Forms.Label();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.numUnitsInStock = new System.Windows.Forms.NumericUpDown();
            this.btnMovePrev = new System.Windows.Forms.Button();
            this.btnMoveNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitsInStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lstPrds
            // 
            this.lstPrds.FormattingEnabled = true;
            this.lstPrds.ItemHeight = 20;
            this.lstPrds.Location = new System.Drawing.Point(603, 52);
            this.lstPrds.Name = "lstPrds";
            this.lstPrds.Size = new System.Drawing.Size(185, 364);
            this.lstPrds.TabIndex = 0;
            this.lstPrds.SelectedIndexChanged += new System.EventHandler(this.lstPrds_SelectedIndexChanged);
            // 
            // txtNewPrice
            // 
            this.txtNewPrice.Location = new System.Drawing.Point(249, 387);
            this.txtNewPrice.Name = "txtNewPrice";
            this.txtNewPrice.Size = new System.Drawing.Size(125, 27);
            this.txtNewPrice.TabIndex = 1;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(489, 387);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(94, 29);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblPrdID
            // 
            this.lblPrdID.AutoSize = true;
            this.lblPrdID.Location = new System.Drawing.Point(128, 51);
            this.lblPrdID.Name = "lblPrdID";
            this.lblPrdID.Size = new System.Drawing.Size(50, 20);
            this.lblPrdID.TabIndex = 3;
            this.lblPrdID.Text = "Prd ID";
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(128, 110);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.Size = new System.Drawing.Size(125, 27);
            this.txtPrdName.TabIndex = 4;
            // 
            // numUnitsInStock
            // 
            this.numUnitsInStock.Location = new System.Drawing.Point(131, 182);
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
            this.btnMovePrev.Location = new System.Drawing.Point(107, 237);
            this.btnMovePrev.Name = "btnMovePrev";
            this.btnMovePrev.Size = new System.Drawing.Size(94, 29);
            this.btnMovePrev.TabIndex = 6;
            this.btnMovePrev.Text = "<";
            this.btnMovePrev.UseVisualStyleBackColor = true;
            // 
            // btnMoveNext
            // 
            this.btnMoveNext.Location = new System.Drawing.Point(249, 237);
            this.btnMoveNext.Name = "btnMoveNext";
            this.btnMoveNext.Size = new System.Drawing.Size(94, 29);
            this.btnMoveNext.TabIndex = 7;
            this.btnMoveNext.Text = ">";
            this.btnMoveNext.UseVisualStyleBackColor = true;
            // 
            // frmProductsDetailedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMoveNext);
            this.Controls.Add(this.btnMovePrev);
            this.Controls.Add(this.numUnitsInStock);
            this.Controls.Add(this.txtPrdName);
            this.Controls.Add(this.lblPrdID);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtNewPrice);
            this.Controls.Add(this.lstPrds);
            this.Name = "frmProductsDetailedView";
            this.Text = "frmProductsDetailedView";
            this.Load += new System.EventHandler(this.frmProductsDetailedView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUnitsInStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstPrds;
        private TextBox txtNewPrice;
        private Button btnExecute;
        private Label lblPrdID;
        private TextBox txtPrdName;
        private NumericUpDown numUnitsInStock;
        private Button btnMovePrev;
        private Button btnMoveNext;
    }
}