namespace KlaranDemo
{
    partial class Demo
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
            this.btnPay = new System.Windows.Forms.Button();
            this.lblOrderAmount = new System.Windows.Forms.Label();
            this.txtOrderAmount = new System.Windows.Forms.TextBox();
            this.txtTaxAmount = new System.Windows.Forms.TextBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.labelLocale = new System.Windows.Forms.Label();
            this.cmbLocale = new System.Windows.Forms.ComboBox();
            this.txtKlarnaOrderId = new System.Windows.Forms.TextBox();
            this.lblKlarnaOrderId = new System.Windows.Forms.Label();
            this.btnConfirmation = new System.Windows.Forms.Button();
            this.txtVeritixOrderNo = new System.Windows.Forms.TextBox();
            this.lblOureOrderNo = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.txtTaxRate = new System.Windows.Forms.TextBox();
            this.lblTaxRate = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnAcknowledge = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPay
            // 
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.Location = new System.Drawing.Point(12, 352);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(155, 41);
            this.btnPay.TabIndex = 15;
            this.btnPay.Text = "&2. Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // lblOrderAmount
            // 
            this.lblOrderAmount.AutoSize = true;
            this.lblOrderAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderAmount.Location = new System.Drawing.Point(15, 58);
            this.lblOrderAmount.Name = "lblOrderAmount";
            this.lblOrderAmount.Size = new System.Drawing.Size(140, 24);
            this.lblOrderAmount.TabIndex = 2;
            this.lblOrderAmount.Text = "&Order Amount :";
            // 
            // txtOrderAmount
            // 
            this.txtOrderAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderAmount.Location = new System.Drawing.Point(176, 56);
            this.txtOrderAmount.Name = "txtOrderAmount";
            this.txtOrderAmount.Size = new System.Drawing.Size(143, 29);
            this.txtOrderAmount.TabIndex = 3;
            this.txtOrderAmount.Text = "100.00";
            // 
            // txtTaxAmount
            // 
            this.txtTaxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxAmount.Location = new System.Drawing.Point(176, 146);
            this.txtTaxAmount.Name = "txtTaxAmount";
            this.txtTaxAmount.ReadOnly = true;
            this.txtTaxAmount.Size = new System.Drawing.Size(143, 29);
            this.txtTaxAmount.TabIndex = 8;
            this.txtTaxAmount.TabStop = false;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(15, 148);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(123, 24);
            this.lblTax.TabIndex = 7;
            this.lblTax.Text = "Tax Amount :";
            // 
            // labelLocale
            // 
            this.labelLocale.AutoSize = true;
            this.labelLocale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocale.Location = new System.Drawing.Point(15, 243);
            this.labelLocale.Name = "labelLocale";
            this.labelLocale.Size = new System.Drawing.Size(76, 24);
            this.labelLocale.TabIndex = 11;
            this.labelLocale.Text = "&Locale :";
            // 
            // cmbLocale
            // 
            this.cmbLocale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocale.FormattingEnabled = true;
            this.cmbLocale.Items.AddRange(new object[] {
            "en-GB",
            "sv-SE",
            "en-US"});
            this.cmbLocale.Location = new System.Drawing.Point(176, 243);
            this.cmbLocale.Name = "cmbLocale";
            this.cmbLocale.Size = new System.Drawing.Size(143, 32);
            this.cmbLocale.TabIndex = 12;
            // 
            // txtKlarnaOrderId
            // 
            this.txtKlarnaOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKlarnaOrderId.Location = new System.Drawing.Point(176, 292);
            this.txtKlarnaOrderId.Name = "txtKlarnaOrderId";
            this.txtKlarnaOrderId.Size = new System.Drawing.Size(499, 29);
            this.txtKlarnaOrderId.TabIndex = 14;
            this.txtKlarnaOrderId.TabStop = false;
            this.txtKlarnaOrderId.TextChanged += new System.EventHandler(this.txtKlarnaOrderId_TextChanged);
            // 
            // lblKlarnaOrderId
            // 
            this.lblKlarnaOrderId.AutoSize = true;
            this.lblKlarnaOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKlarnaOrderId.Location = new System.Drawing.Point(15, 294);
            this.lblKlarnaOrderId.Name = "lblKlarnaOrderId";
            this.lblKlarnaOrderId.Size = new System.Drawing.Size(147, 24);
            this.lblKlarnaOrderId.TabIndex = 13;
            this.lblKlarnaOrderId.Text = "Klarna Order Id :";
            // 
            // btnConfirmation
            // 
            this.btnConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmation.Location = new System.Drawing.Point(176, 352);
            this.btnConfirmation.Name = "btnConfirmation";
            this.btnConfirmation.Size = new System.Drawing.Size(155, 41);
            this.btnConfirmation.TabIndex = 16;
            this.btnConfirmation.Text = "&3. Confirmation";
            this.btnConfirmation.UseVisualStyleBackColor = true;
            this.btnConfirmation.Click += new System.EventHandler(this.btnConfirmation_Click);
            // 
            // txtVeritixOrderNo
            // 
            this.txtVeritixOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVeritixOrderNo.Location = new System.Drawing.Point(176, 12);
            this.txtVeritixOrderNo.Name = "txtVeritixOrderNo";
            this.txtVeritixOrderNo.Size = new System.Drawing.Size(143, 29);
            this.txtVeritixOrderNo.TabIndex = 1;
            this.txtVeritixOrderNo.Leave += new System.EventHandler(this.txtVeritixOrderNo_Leave);
            // 
            // lblOureOrderNo
            // 
            this.lblOureOrderNo.AutoSize = true;
            this.lblOureOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOureOrderNo.Location = new System.Drawing.Point(15, 14);
            this.lblOureOrderNo.Name = "lblOureOrderNo";
            this.lblOureOrderNo.Size = new System.Drawing.Size(156, 24);
            this.lblOureOrderNo.TabIndex = 0;
            this.lblOureOrderNo.Text = "&Veritix Order No :";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.Location = new System.Drawing.Point(9, 430);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(154, 24);
            this.lblErrorMessage.TabIndex = 13;
            this.lblErrorMessage.Text = "Error message ...";
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxRate.Location = new System.Drawing.Point(176, 101);
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.Size = new System.Drawing.Size(143, 29);
            this.txtTaxRate.TabIndex = 5;
            this.txtTaxRate.Text = "0";
            // 
            // lblTaxRate
            // 
            this.lblTaxRate.AutoSize = true;
            this.lblTaxRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxRate.Location = new System.Drawing.Point(15, 103);
            this.lblTaxRate.Name = "lblTaxRate";
            this.lblTaxRate.Size = new System.Drawing.Size(147, 24);
            this.lblTaxRate.TabIndex = 4;
            this.lblTaxRate.Text = "&Tax Rate     (%) :";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(176, 192);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(143, 29);
            this.txtTotalAmount.TabIndex = 10;
            this.txtTotalAmount.TabStop = false;
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.AutoSize = true;
            this.lblOrderTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotal.Location = new System.Drawing.Point(15, 194);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(115, 24);
            this.lblOrderTotal.TabIndex = 9;
            this.lblOrderTotal.Text = "Order Total :";
            // 
            // btnCalc
            // 
            this.btnCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalc.Location = new System.Drawing.Point(325, 93);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(123, 41);
            this.btnCalc.TabIndex = 6;
            this.btnCalc.Text = "&1. Calc";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnAcknowledge
            // 
            this.btnAcknowledge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcknowledge.Location = new System.Drawing.Point(348, 352);
            this.btnAcknowledge.Name = "btnAcknowledge";
            this.btnAcknowledge.Size = new System.Drawing.Size(155, 41);
            this.btnAcknowledge.TabIndex = 17;
            this.btnAcknowledge.Text = "&4. Acknowledge";
            this.btnAcknowledge.UseVisualStyleBackColor = true;
            this.btnAcknowledge.Click += new System.EventHandler(this.btnAcknowledge_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapture.Location = new System.Drawing.Point(520, 352);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(155, 41);
            this.btnCapture.TabIndex = 18;
            this.btnCapture.Text = "&5. Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(569, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 32);
            this.btnClear.TabIndex = 30;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(569, 56);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 32);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "C&lose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 460);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnAcknowledge);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblOrderTotal);
            this.Controls.Add(this.txtTaxRate);
            this.Controls.Add(this.lblTaxRate);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.txtVeritixOrderNo);
            this.Controls.Add(this.lblOureOrderNo);
            this.Controls.Add(this.btnConfirmation);
            this.Controls.Add(this.txtKlarnaOrderId);
            this.Controls.Add(this.lblKlarnaOrderId);
            this.Controls.Add(this.cmbLocale);
            this.Controls.Add(this.labelLocale);
            this.Controls.Add(this.txtTaxAmount);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.txtOrderAmount);
            this.Controls.Add(this.lblOrderAmount);
            this.Controls.Add(this.btnPay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Demo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Klarna Demo (POC)";
            this.Load += new System.EventHandler(this.Demo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label lblOrderAmount;
        private System.Windows.Forms.TextBox txtOrderAmount;
        private System.Windows.Forms.TextBox txtTaxAmount;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label labelLocale;
        private System.Windows.Forms.ComboBox cmbLocale;
        private System.Windows.Forms.TextBox txtKlarnaOrderId;
        private System.Windows.Forms.Label lblKlarnaOrderId;
        private System.Windows.Forms.Button btnConfirmation;
        private System.Windows.Forms.TextBox txtVeritixOrderNo;
        private System.Windows.Forms.Label lblOureOrderNo;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.TextBox txtTaxRate;
        private System.Windows.Forms.Label lblTaxRate;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnAcknowledge;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
    }
}