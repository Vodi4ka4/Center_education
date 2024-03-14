namespace Center_education
{
    partial class Contract
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
            this.button_contract = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_update_table = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_contract
            // 
            this.button_contract.Location = new System.Drawing.Point(135, 282);
            this.button_contract.Name = "button_contract";
            this.button_contract.Size = new System.Drawing.Size(120, 23);
            this.button_contract.TabIndex = 1;
            this.button_contract.Text = "Заключить договор";
            this.button_contract.UseVisualStyleBackColor = true;
            this.button_contract.Click += new System.EventHandler(this.button_contract_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(505, 255);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_update_table
            // 
            this.button_update_table.Location = new System.Drawing.Point(12, 282);
            this.button_update_table.Name = "button_update_table";
            this.button_update_table.Size = new System.Drawing.Size(117, 23);
            this.button_update_table.TabIndex = 4;
            this.button_update_table.Text = "Обновить таблицу";
            this.button_update_table.UseVisualStyleBackColor = true;
            this.button_update_table.Click += new System.EventHandler(this.button_update_table_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Contract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 338);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_update_table);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_contract);
            this.Name = "Contract";
            this.Text = "Contract";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_contract;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_update_table;
        private System.Windows.Forms.Label label1;
    }
}