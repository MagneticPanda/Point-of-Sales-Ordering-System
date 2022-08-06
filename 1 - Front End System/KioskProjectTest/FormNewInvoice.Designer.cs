namespace KioskProjectTest.Forms
{
    partial class FormNewInvoice
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
            this.DS_Main = new KioskProjectTest.DSMain();
            this.TA_SEmployee = new KioskProjectTest.DSMainTableAdapters.S_EmployeeTableAdapter();
            this.TA_SItem = new KioskProjectTest.DSMainTableAdapters.S_ItemTableAdapter();
            this.TA_SOrderItem = new KioskProjectTest.DSMainTableAdapters.S_OrderItemTableAdapter();
            this.TA_SOrder = new KioskProjectTest.DSMainTableAdapters.S_OrderTableAdapter();
            this.CR_Receipt = new KioskProjectTest.Receipt();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // DS_Main
            // 
            this.DS_Main.DataSetName = "DSMain";
            this.DS_Main.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TA_SEmployee
            // 
            this.TA_SEmployee.ClearBeforeFill = true;
            // 
            // TA_SItem
            // 
            this.TA_SItem.ClearBeforeFill = true;
            // 
            // TA_SOrderItem
            // 
            this.TA_SOrderItem.ClearBeforeFill = true;
            // 
            // TA_SOrder
            // 
            this.TA_SOrder.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.DisplayToolbar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CR_Receipt;
            this.crystalReportViewer1.Size = new System.Drawing.Size(884, 913);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormNewInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 913);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "FormNewInvoice";
            this.Text = "Your Receipt";
            this.Load += new System.EventHandler(this.FormNewInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSMain DS_Main;
        private DSMainTableAdapters.S_EmployeeTableAdapter TA_SEmployee;
        private DSMainTableAdapters.S_ItemTableAdapter TA_SItem;
        private DSMainTableAdapters.S_OrderItemTableAdapter TA_SOrderItem;
        private DSMainTableAdapters.S_OrderTableAdapter TA_SOrder;
        private Receipt CR_Receipt;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}