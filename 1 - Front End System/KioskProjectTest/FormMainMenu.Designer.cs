namespace KioskProjectTest
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnQnA = new System.Windows.Forms.Button();
            this.btnViewReceipt = new System.Windows.Forms.Button();
            this.btnBalances = new System.Windows.Forms.Button();
            this.btnManagement = new System.Windows.Forms.Button();
            this.btnCanteenStaff = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.btnMainLogin = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DSEmployeeItemOrder = new KioskProjectTest.DSEmployeeItemOrder();
            this.DSLogged = new KioskProjectTest.DSLogged();
            this.DSMain = new KioskProjectTest.DSMain();
            this.DSLogging = new KioskProjectTest.DSLogging();
            this.s_LoggedInCanteenWorkerTableAdapter1 = new KioskProjectTest.DSLoggingTableAdapters.S_LoggedInCanteenWorkerTableAdapter();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSEmployeeItemOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSLogged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSLogging)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnQnA);
            this.panelMenu.Controls.Add(this.btnViewReceipt);
            this.panelMenu.Controls.Add(this.btnBalances);
            this.panelMenu.Controls.Add(this.btnManagement);
            this.panelMenu.Controls.Add(this.btnCanteenStaff);
            this.panelMenu.Controls.Add(this.btnCart);
            this.panelMenu.Controls.Add(this.btnItems);
            this.panelMenu.Controls.Add(this.btnMainLogin);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 724);
            this.panelMenu.TabIndex = 0;
            // 
            // btnQnA
            // 
            this.btnQnA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnQnA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQnA.FlatAppearance.BorderSize = 0;
            this.btnQnA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQnA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQnA.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQnA.Image = global::KioskProjectTest.Properties.Resources.help_48;
            this.btnQnA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQnA.Location = new System.Drawing.Point(0, 544);
            this.btnQnA.Name = "btnQnA";
            this.btnQnA.Size = new System.Drawing.Size(220, 60);
            this.btnQnA.TabIndex = 8;
            this.btnQnA.Text = "              FAQ and About Us";
            this.btnQnA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQnA.UseVisualStyleBackColor = true;
            this.btnQnA.Visible = false;
            this.btnQnA.Click += new System.EventHandler(this.btnQnA_Click);
            // 
            // btnViewReceipt
            // 
            this.btnViewReceipt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnViewReceipt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewReceipt.FlatAppearance.BorderSize = 0;
            this.btnViewReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReceipt.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnViewReceipt.Image = global::KioskProjectTest.Properties.Resources.purchase_order_48;
            this.btnViewReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewReceipt.Location = new System.Drawing.Point(0, 320);
            this.btnViewReceipt.Name = "btnViewReceipt";
            this.btnViewReceipt.Size = new System.Drawing.Size(220, 60);
            this.btnViewReceipt.TabIndex = 7;
            this.btnViewReceipt.Text = "              View Receipt";
            this.btnViewReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewReceipt.UseVisualStyleBackColor = true;
            this.btnViewReceipt.Visible = false;
            this.btnViewReceipt.Click += new System.EventHandler(this.btnViewReceipt_Click);
            // 
            // btnBalances
            // 
            this.btnBalances.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBalances.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBalances.FlatAppearance.BorderSize = 0;
            this.btnBalances.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalances.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBalances.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBalances.Image = global::KioskProjectTest.Properties.Resources.report_2_48;
            this.btnBalances.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalances.Location = new System.Drawing.Point(0, 260);
            this.btnBalances.Name = "btnBalances";
            this.btnBalances.Size = new System.Drawing.Size(220, 60);
            this.btnBalances.TabIndex = 6;
            this.btnBalances.Text = "     View Order History";
            this.btnBalances.UseVisualStyleBackColor = true;
            this.btnBalances.Visible = false;
            this.btnBalances.Click += new System.EventHandler(this.btnBalances_Click);
            // 
            // btnManagement
            // 
            this.btnManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnManagement.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnManagement.FlatAppearance.BorderSize = 0;
            this.btnManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagement.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnManagement.Image = global::KioskProjectTest.Properties.Resources.administrator_48;
            this.btnManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagement.Location = new System.Drawing.Point(0, 604);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(220, 60);
            this.btnManagement.TabIndex = 5;
            this.btnManagement.Text = "              Management";
            this.btnManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagement.UseVisualStyleBackColor = true;
            this.btnManagement.Visible = false;
            this.btnManagement.Click += new System.EventHandler(this.btnManagement_Click);
            // 
            // btnCanteenStaff
            // 
            this.btnCanteenStaff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCanteenStaff.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCanteenStaff.FlatAppearance.BorderSize = 0;
            this.btnCanteenStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCanteenStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCanteenStaff.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCanteenStaff.Image = global::KioskProjectTest.Properties.Resources.cook_48;
            this.btnCanteenStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCanteenStaff.Location = new System.Drawing.Point(0, 664);
            this.btnCanteenStaff.Name = "btnCanteenStaff";
            this.btnCanteenStaff.Size = new System.Drawing.Size(220, 60);
            this.btnCanteenStaff.TabIndex = 4;
            this.btnCanteenStaff.Text = "              Canteen Staff";
            this.btnCanteenStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCanteenStaff.UseVisualStyleBackColor = true;
            this.btnCanteenStaff.Visible = false;
            this.btnCanteenStaff.Click += new System.EventHandler(this.btnCanteenStaff_Click);
            // 
            // btnCart
            // 
            this.btnCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCart.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCart.Image = global::KioskProjectTest.Properties.Resources.purchase_order_48;
            this.btnCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCart.Location = new System.Drawing.Point(0, 200);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(220, 60);
            this.btnCart.TabIndex = 3;
            this.btnCart.Text = "              Review Order";
            this.btnCart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Visible = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // btnItems
            // 
            this.btnItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnItems.FlatAppearance.BorderSize = 0;
            this.btnItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnItems.Image = global::KioskProjectTest.Properties.Resources.cupcake_6_48;
            this.btnItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItems.Location = new System.Drawing.Point(0, 140);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(220, 60);
            this.btnItems.TabIndex = 2;
            this.btnItems.Text = "              Place Order";
            this.btnItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Visible = false;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnMainLogin
            // 
            this.btnMainLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMainLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMainLogin.FlatAppearance.BorderSize = 0;
            this.btnMainLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainLogin.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMainLogin.Image = global::KioskProjectTest.Properties.Resources.user_4_48;
            this.btnMainLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainLogin.Location = new System.Drawing.Point(0, 80);
            this.btnMainLogin.Name = "btnMainLogin";
            this.btnMainLogin.Size = new System.Drawing.Size(220, 60);
            this.btnMainLogin.TabIndex = 1;
            this.btnMainLogin.Text = "              Login";
            this.btnMainLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainLogin.UseVisualStyleBackColor = true;
            this.btnMainLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(46, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dimension Data";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(191)))), ((int)(((byte)(61)))));
            this.panelTitleBar.Controls.Add(this.btnCloseChildForm);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(886, 80);
            this.panelTitleBar.TabIndex = 1;
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCloseChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Image = global::KioskProjectTest.Properties.Resources.x_mark_24;
            this.btnCloseChildForm.Location = new System.Drawing.Point(0, 0);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(83, 80);
            this.btnCloseChildForm.TabIndex = 0;
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Visible = false;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(408, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(66, 29);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "HOME";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Controls.Add(this.label4);
            this.panelDesktopPane.Controls.Add(this.label3);
            this.panelDesktopPane.Controls.Add(this.label2);
            this.panelDesktopPane.Controls.Add(this.pictureBox2);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(220, 80);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(886, 644);
            this.panelDesktopPane.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(361, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 39);
            this.label4.TabIndex = 3;
            this.label4.Text = "Canteen";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ordering Kiosk";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(465, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome to the Self-Service";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::KioskProjectTest.Properties.Resources.ddLogo;
            this.pictureBox2.Location = new System.Drawing.Point(212, 322);
            this.pictureBox2.MinimumSize = new System.Drawing.Size(300, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(426, 93);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // DSEmployeeItemOrder
            // 
            this.DSEmployeeItemOrder.DataSetName = "DSEmployeeItemOrder";
            this.DSEmployeeItemOrder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DSLogged
            // 
            this.DSLogged.DataSetName = "DSLogged";
            this.DSLogged.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DSMain
            // 
            this.DSMain.DataSetName = "DSMain";
            this.DSMain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DSLogging
            // 
            this.DSLogging.DataSetName = "DSLogging";
            this.DSLogging.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // s_LoggedInCanteenWorkerTableAdapter1
            // 
            this.s_LoggedInCanteenWorkerTableAdapter1.ClearBeforeFill = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 724);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Application";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktopPane.ResumeLayout(false);
            this.panelDesktopPane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSEmployeeItemOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSLogged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSLogging)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnCanteenStaff;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnMainLogin;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.PictureBox pictureBox2;
        public DSEmployeeItemOrder DSEmployeeItemOrder;
        private System.Windows.Forms.Button btnBalances;
        private DSLogged DSLogged;
        private DSMain DSMain;
        private DSLogging DSLogging;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DSLoggingTableAdapters.S_LoggedInCanteenWorkerTableAdapter s_LoggedInCanteenWorkerTableAdapter1;
        public System.Windows.Forms.Button btnManagement;
        public System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnViewReceipt;
        private System.Windows.Forms.Button btnQnA;
    }
}

