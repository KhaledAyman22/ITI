namespace NorthWind_WinApp
{
    partial class frmDetailedViewPrds
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
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.numUnitsinStock = new System.Windows.Forms.NumericUpDown();
            this.prdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitsinStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prdBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(143, 79);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(125, 27);
            this.txtProductName.TabIndex = 0;
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(143, 39);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(50, 20);
            this.lblProductID.TabIndex = 1;
            this.lblProductID.Text = "label1";
            // 
            // numUnitsinStock
            // 
            this.numUnitsinStock.Location = new System.Drawing.Point(143, 129);
            this.numUnitsinStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUnitsinStock.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numUnitsinStock.Name = "numUnitsinStock";
            this.numUnitsinStock.Size = new System.Drawing.Size(150, 27);
            this.numUnitsinStock.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(680, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDetailedViewPrds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numUnitsinStock);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.txtProductName);
            this.Name = "frmDetailedViewPrds";
            this.Text = "frmDetailedViewPrds";
            this.Load += new System.EventHandler(this.frmDetailedViewPrds_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUnitsinStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prdBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtProductName;
        private Label lblProductID;
        private NumericUpDown numUnitsinStock;
        private BindingSource prdBindingSource;
        private Button button1;
    }
}