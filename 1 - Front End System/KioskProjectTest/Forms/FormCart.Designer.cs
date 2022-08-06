namespace KioskProjectTest.Forms
{
    partial class FormCart
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInvalid = new System.Windows.Forms.Label();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.GVInvoice = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLoggedInAs = new System.Windows.Forms.Label();
            this.TAOrder = new KioskProjectTest.DSEmployeeItemOrderTableAdapters.Prac_OrderTableAdapter();
            this.TAOrderItem = new KioskProjectTest.DSEmployeeItemOrderTableAdapters.Prac_OrderItemTableAdapter();
            this.BS_SInvoice = new System.Windows.Forms.BindingSource(this.components);
            this.TA_SOrder = new KioskProjectTest.DSMainTableAdapters.S_OrderTableAdapter();
            this.TA_SOrderItem = new KioskProjectTest.DSMainTableAdapters.S_OrderItemTableAdapter();
            this.TA_SItem = new KioskProjectTest.DSMainTableAdapters.S_ItemTableAdapter();
            this.creditPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAfterCredits = new System.Windows.Forms.TextBox();
            this.tbCurrentCredits = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TA_SEmployee = new KioskProjectTest.DSMainTableAdapters.S_EmployeeTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVInvoice)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_SInvoice)).BeginInit();
            this.creditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.lblInvalid);
            this.groupBox1.Controls.Add(this.btnPlus);
            this.groupBox1.Controls.Add(this.btnMinus);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnFinalize);
            this.groupBox1.Controls.Add(this.lblQuantity);
            this.groupBox1.Controls.Add(this.tbQuantity);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.tbTotal);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.GVInvoice);
            this.groupBox1.Location = new System.Drawing.Point(378, 206);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(699, 341);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your Cart";
            // 
            // lblInvalid
            // 
            this.lblInvalid.AutoSize = true;
            this.lblInvalid.ForeColor = System.Drawing.Color.Red;
            this.lblInvalid.Location = new System.Drawing.Point(312, 300);
            this.lblInvalid.Name = "lblInvalid";
            this.lblInvalid.Size = new System.Drawing.Size(80, 13);
            this.lblInvalid.TabIndex = 9;
            this.lblInvalid.Text = "Invalid Quantity";
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(406, 274);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(45, 20);
            this.btnPlus.TabIndex = 8;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(246, 274);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(45, 20);
            this.btnMinus.TabIndex = 8;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(103, 290);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(68, 27);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear Cart";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFinalize
            // 
            this.btnFinalize.Location = new System.Drawing.Point(517, 295);
            this.btnFinalize.Margin = new System.Windows.Forms.Padding(2);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(76, 22);
            this.btnFinalize.TabIndex = 6;
            this.btnFinalize.Text = "Place Order";
            this.btnFinalize.UseVisualStyleBackColor = true;
            this.btnFinalize.Click += new System.EventHandler(this.btnFinalize_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(329, 257);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Quantity";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(315, 273);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.ReadOnly = true;
            this.tbQuantity.Size = new System.Drawing.Size(76, 20);
            this.tbQuantity.TabIndex = 4;
            this.tbQuantity.Text = "0";
            this.tbQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(103, 258);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(68, 27);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(517, 263);
            this.tbTotal.Margin = new System.Windows.Forms.Padding(2);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(76, 20);
            this.tbTotal.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(535, 246);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total";
            // 
            // GVInvoice
            // 
            this.GVInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVInvoice.Location = new System.Drawing.Point(26, 43);
            this.GVInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.GVInvoice.Name = "GVInvoice";
            this.GVInvoice.RowTemplate.Height = 24;
            this.GVInvoice.Size = new System.Drawing.Size(646, 190);
            this.GVInvoice.TabIndex = 0;
            this.GVInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVInvoice_CellClick);
            this.GVInvoice.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.GVInvoice_RowsAdded);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLoggedInAs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 875);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1535, 29);
            this.panel1.TabIndex = 2;
            // 
            // lblLoggedInAs
            // 
            this.lblLoggedInAs.AutoSize = true;
            this.lblLoggedInAs.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblLoggedInAs.Location = new System.Drawing.Point(9, 8);
            this.lblLoggedInAs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoggedInAs.Name = "lblLoggedInAs";
            this.lblLoggedInAs.Size = new System.Drawing.Size(74, 13);
            this.lblLoggedInAs.TabIndex = 0;
            this.lblLoggedInAs.Text = "Logged in as: ";
            // 
            // TAOrder
            // 
            this.TAOrder.ClearBeforeFill = true;
            // 
            // TAOrderItem
            // 
            this.TAOrderItem.ClearBeforeFill = true;
            // 
            // TA_SOrder
            // 
            this.TA_SOrder.ClearBeforeFill = true;
            // 
            // TA_SOrderItem
            // 
            this.TA_SOrderItem.ClearBeforeFill = true;
            // 
            // TA_SItem
            // 
            this.TA_SItem.ClearBeforeFill = true;
            // 
            // creditPanel
            // 
            this.creditPanel.Controls.Add(this.label4);
            this.creditPanel.Controls.Add(this.label3);
            this.creditPanel.Controls.Add(this.tbAfterCredits);
            this.creditPanel.Controls.Add(this.tbCurrentCredits);
            this.creditPanel.Controls.Add(this.label2);
            this.creditPanel.Controls.Add(this.label1);
            this.creditPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.creditPanel.Location = new System.Drawing.Point(0, 743);
            this.creditPanel.Name = "creditPanel";
            this.creditPanel.Size = new System.Drawing.Size(1535, 132);
            this.creditPanel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(354, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Credits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(354, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Credits";
            // 
            // tbAfterCredits
            // 
            this.tbAfterCredits.Location = new System.Drawing.Point(255, 76);
            this.tbAfterCredits.Name = "tbAfterCredits";
            this.tbAfterCredits.ReadOnly = true;
            this.tbAfterCredits.Size = new System.Drawing.Size(78, 20);
            this.tbAfterCredits.TabIndex = 3;
            this.tbAfterCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCurrentCredits
            // 
            this.tbCurrentCredits.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbCurrentCredits.Location = new System.Drawing.Point(255, 38);
            this.tbCurrentCredits.Name = "tbCurrentCredits";
            this.tbCurrentCredits.ReadOnly = true;
            this.tbCurrentCredits.Size = new System.Drawing.Size(78, 20);
            this.tbCurrentCredits.TabIndex = 2;
            this.tbCurrentCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(28, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your Balance After: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(28, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Current Credit Balance: ";
            // 
            // TA_SEmployee
            // 
            this.TA_SEmployee.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(371, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(305, 39);
            this.label5.TabIndex = 4;
            this.label5.Text = "Review your order";
            // 
            // FormCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 904);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.creditPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCart";
            this.Text = "REVIEW ORDER";
            this.Load += new System.EventHandler(this.FormCart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVInvoice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_SInvoice)).EndInit();
            this.creditPanel.ResumeLayout(false);
            this.creditPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView GVInvoice;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLoggedInAs;
        private DSEmployeeItemOrderTableAdapters.Prac_OrderTableAdapter TAOrder;
        private DSEmployeeItemOrderTableAdapters.Prac_OrderItemTableAdapter TAOrderItem;
        private DSMainTableAdapters.S_OrderTableAdapter TA_SOrder;
        private DSMainTableAdapters.S_OrderItemTableAdapter TA_SOrderItem;
        private System.Windows.Forms.BindingSource BS_SInvoice;
        private System.Windows.Forms.Label lblInvalid;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private DSMainTableAdapters.S_ItemTableAdapter TA_SItem;
        private System.Windows.Forms.Panel creditPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAfterCredits;
        private System.Windows.Forms.TextBox tbCurrentCredits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DSMainTableAdapters.S_EmployeeTableAdapter TA_SEmployee;
        private System.Windows.Forms.Label label5;
    }
}