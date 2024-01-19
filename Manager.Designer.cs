namespace Center_education
{
    partial class Manager
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
            this.comboBox_table = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_update_table = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_table
            // 
            this.comboBox_table.FormattingEnabled = true;
            this.comboBox_table.Location = new System.Drawing.Point(12, 23);
            this.comboBox_table.Name = "comboBox_table";
            this.comboBox_table.Size = new System.Drawing.Size(121, 21);
            this.comboBox_table.TabIndex = 0;
            this.comboBox_table.SelectedIndexChanged += new System.EventHandler(this.comboBox_table_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Таблицы";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(613, 311);
            this.dataGridView1.TabIndex = 2;
            // 
            // button_update_table
            // 
            this.button_update_table.Location = new System.Drawing.Point(139, 21);
            this.button_update_table.Name = "button_update_table";
            this.button_update_table.Size = new System.Drawing.Size(117, 23);
            this.button_update_table.TabIndex = 3;
            this.button_update_table.Text = "Обновить таблицу";
            this.button_update_table.UseVisualStyleBackColor = true;
            this.button_update_table.Click += new System.EventHandler(this.button_update_table_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(262, 23);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(78, 21);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "Добавить";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(753, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_update_table);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_table);
            this.Name = "Manager";
            this.Text = "Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_table;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_update_table;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label2;
    }
}