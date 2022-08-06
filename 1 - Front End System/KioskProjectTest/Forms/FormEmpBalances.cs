using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskProjectTest.Forms
{
    public partial class FormEmpBalances : Form
    {
        DSMain balancesDS;
        DSLogging loggedIn;
        MainMenu mainMenu;

        public FormEmpBalances(DSMain main ,DSLogging loggedIn, MainMenu mainMenu)
        {
            this.balancesDS = main;
            this.loggedIn = loggedIn;
            InitializeComponent();
            BS_SItem.DataSource = dSMain;
            BS_SItem.DataMember = "S_Item";

            this.mainMenu = mainMenu;
        }

        private void FormEmpBalances_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSMain.OrderItemInnerJoin' table. You can move, or remove it, as needed.
            this.orderItemInnerJoinTableAdapter.Fill(this.dSMain.OrderItemInnerJoin);
            // TODO: This line of code loads data into the 'dSMain.OrderItemInnerJoin' table. You can move, or remove it, as needed.
            this.orderItemInnerJoinTableAdapter.Fill(this.dSMain.OrderItemInnerJoin);
            // TODO: This line of code loads data into the 'dSMain.S_OrderItem' table. You can move, or remove it, as needed.
            this.s_OrderTableAdapter.empIDFillBy(this.dSMain.S_Order, Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]));
            // TODO: This line of code loads data into the 'dSMain.S_Order' table. You can move, or remove it, as needed.
            this.s_OrderItemTableAdapter.Fill(this.dSMain.S_OrderItem);

            LoadTheme();
            lblLoggedInAs.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2].ToString() + " " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[3].ToString();

            tbCreditLimit.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[7].ToString();
            tbCreditBalance.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[8].ToString();
            pnlCredits.BackColor = ThemeColor.SecondaryColor;

            mainMenu.Size = new Size(235 + this.Width, 120 + this.Height);
            cb_datePeriod.SelectedIndex = 0;

            s_OrderDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            s_OrderDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            s_OrderItemDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            s_OrderItemDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            s_OrderItemDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        public void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                if (btns.GetType() == typeof(Panel))
                {
                    Panel panel = (Panel)btns;
                    panel.BackColor = ThemeColor.PrimaryColor;
                }
            }
        }

        private void prac_OrderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.s_OrderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSMain);
        }

        private void s_OrderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.s_OrderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSMain);

        }

        private void s_OrderItemDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (s_OrderItemDataGridView.Rows.Count > 1)
            {
                TA_SItem.IDFillBy(dSMain.S_Item, Convert.ToInt32(s_OrderItemDataGridView.CurrentRow.Cells[1].Value));
            }
        }

        private void cb_datePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_datePeriod.SelectedItem.ToString() ==  "All Time")
            {
                this.s_OrderTableAdapter.empIDFillBy(this.dSMain.S_Order, Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]));
                this.s_OrderItemTableAdapter.Fill(this.dSMain.S_OrderItem);
            }
            else if (cb_datePeriod.SelectedItem.ToString() == "Past 7 days")
            {
                DateTime todayDate = DateTime.Today.Date;
                DateTime fromDate = todayDate.AddDays(-7);
                this.s_OrderTableAdapter.DateFillBy(this.dSMain.S_Order, Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]), fromDate.ToString(), todayDate.ToString());
            }
            else if (cb_datePeriod.SelectedItem.ToString() == "Past 30 days")
            {
                DateTime todayDate = DateTime.Today.Date;
                DateTime fromDate = todayDate.AddDays(-30);
                this.s_OrderTableAdapter.DateFillBy(this.dSMain.S_Order, Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]), fromDate.ToString(), todayDate.ToString());
            }
            else if (cb_datePeriod.SelectedItem.ToString() == "Today")
            {
                DateTime todayDate = DateTime.Today;
                DateTime fromDate = DateTime.Today;
                this.s_OrderTableAdapter.DateFillBy(this.dSMain.S_Order, Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]), fromDate.ToString(), todayDate.ToString());
            }
        }

        private void s_OrderDataGridView_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(s_OrderDataGridView, "Select an order to view its details");
        }

        private void s_OrderDataGridView_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(s_OrderDataGridView, "Select an order to view its details");
        }

        private void s_OrderDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (s_OrderDataGridView.Rows.Count > 1)
            {
                orderItemInnerJoinTableAdapter.OrderNoFillBy(dSMain.OrderItemInnerJoin, Convert.ToInt32(s_OrderDataGridView.CurrentRow.Cells[0].Value));
            }
        }
    }
}
