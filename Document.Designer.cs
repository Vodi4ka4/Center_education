namespace Center_education
{
    partial class Document
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
            this.button_receipt = new System.Windows.Forms.Button();
            this.button_contract_pdf = new System.Windows.Forms.Button();
            this.button_contract_txt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_receipt
            // 
            this.button_receipt.Location = new System.Drawing.Point(34, 23);
            this.button_receipt.Name = "button_receipt";
            this.button_receipt.Size = new System.Drawing.Size(164, 28);
            this.button_receipt.TabIndex = 0;
            this.button_receipt.Text = "Квитанцию на оплату в PDF ";
            this.button_receipt.UseVisualStyleBackColor = true;
            this.button_receipt.Click += new System.EventHandler(this.button_receipt_Click);
            // 
            // button_contract_pdf
            // 
            this.button_contract_pdf.Location = new System.Drawing.Point(34, 57);
            this.button_contract_pdf.Name = "button_contract_pdf";
            this.button_contract_pdf.Size = new System.Drawing.Size(86, 23);
            this.button_contract_pdf.TabIndex = 1;
            this.button_contract_pdf.Text = "Договор в pdf";
            this.button_contract_pdf.UseVisualStyleBackColor = true;
            this.button_contract_pdf.Click += new System.EventHandler(this.button_contract_pdf_Click);
            // 
            // button_contract_txt
            // 
            this.button_contract_txt.Location = new System.Drawing.Point(34, 86);
            this.button_contract_txt.Name = "button_contract_txt";
            this.button_contract_txt.Size = new System.Drawing.Size(86, 23);
            this.button_contract_txt.TabIndex = 2;
            this.button_contract_txt.Text = "Договор в txt";
            this.button_contract_txt.UseVisualStyleBackColor = true;
            this.button_contract_txt.Click += new System.EventHandler(this.button_contract_txt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 173);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_contract_txt);
            this.Controls.Add(this.button_contract_pdf);
            this.Controls.Add(this.button_receipt);
            this.Name = "Document";
            this.Text = "Document";
            this.Load += new System.EventHandler(this.Document_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_receipt;
        private System.Windows.Forms.Button button_contract_pdf;
        private System.Windows.Forms.Button button_contract_txt;
        private System.Windows.Forms.Label label1;
    }
}