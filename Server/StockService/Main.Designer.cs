namespace StockService
{
    partial class Main
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
            this.transactionsList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StockType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStockType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStockValue = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // transactionsList
            // 
            this.transactionsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.ClientName,
            this.StockType,
            this.Type,
            this.Quantity});
            this.transactionsList.FullRowSelect = true;
            this.transactionsList.GridLines = true;
            this.transactionsList.Location = new System.Drawing.Point(12, 12);
            this.transactionsList.MultiSelect = false;
            this.transactionsList.Name = "transactionsList";
            this.transactionsList.Size = new System.Drawing.Size(526, 336);
            this.transactionsList.TabIndex = 0;
            this.transactionsList.UseCompatibleStateImageBehavior = false;
            this.transactionsList.View = System.Windows.Forms.View.Details;
            this.transactionsList.SelectedIndexChanged += new System.EventHandler(this.transactionsList_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 43;
            // 
            // ClientName
            // 
            this.ClientName.Text = "Client Name";
            this.ClientName.Width = 112;
            // 
            // StockType
            // 
            this.StockType.Text = "Stock Type";
            this.StockType.Width = 83;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(557, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client Name:";
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Enabled = false;
            this.textBoxClientName.Location = new System.Drawing.Point(630, 65);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(100, 20);
            this.textBoxClientName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(557, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stock Type:";
            // 
            // textBoxStockType
            // 
            this.textBoxStockType.Enabled = false;
            this.textBoxStockType.Location = new System.Drawing.Point(630, 98);
            this.textBoxStockType.Name = "textBoxStockType";
            this.textBoxStockType.Size = new System.Drawing.Size(100, 20);
            this.textBoxStockType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quantity:";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Enabled = false;
            this.textBoxQuantity.Location = new System.Drawing.Point(630, 131);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuantity.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(557, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stock Value:";
            // 
            // textBoxStockValue
            // 
            this.textBoxStockValue.Location = new System.Drawing.Point(630, 164);
            this.textBoxStockValue.Name = "textBoxStockValue";
            this.textBoxStockValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxStockValue.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(560, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(630, 35);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Trans. ID:";
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 71;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 386);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxStockValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxStockType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxClientName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.transactionsList);
            this.Name = "Main";
            this.Text = "TDIN - Finantial Institute - Stock Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView transactionsList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader ClientName;
        private System.Windows.Forms.ColumnHeader StockType;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStockType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStockValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader Type;
    }
}

