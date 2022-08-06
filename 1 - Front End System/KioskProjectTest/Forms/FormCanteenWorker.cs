using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web; //enables browser-server communication
using System.Net.Mail; //used to send electronic mail to a Simple Mail Transfer Protocol (SMTP) server for delivery

namespace KioskProjectTest.Forms
{
    public partial class FormCanteenWorker : Form
    {
       DSMain canteenDS;
        DSLogging loggedin;
        MainMenu mainMenu;
        public FormCanteenWorker(DSMain main, DSLogging loggedin, MainMenu mainMenu)
        {
            InitializeComponent();
            canteenDS = main;
            this.loggedin = loggedin;
            BS_SItems.DataSource = dSMain;
            BS_SItems.DataMember = "S_Item";

            BS2_SItems.DataSource = canteenDS;
            BS2_SItems.DataMember = "S_Item";

            this.mainMenu = mainMenu;
        }

        private void FormCanteenWorker_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSMain.CanteenInnerJoin' table. You can move, or remove it, as needed.
            this.canteenInnerJoinTableAdapter.Fill(this.dSMain.CanteenInnerJoin);
            // TODO: This line of code loads data into the 'dSMain.S_OrderItem' table. You can move, or remove it, as needed.
            this.s_OrderItemTableAdapter.Fill(this.dSMain.S_OrderItem);
            // TODO: This line of code loads data into the 'dSMain.S_Order' table. You can move, or remove it, as needed.
            this.s_OrderTableAdapter.PlacedFillBy(this.dSMain.S_Order);
            LoadTheme();
            TA_SItems.Fill(canteenDS.S_Item);
            GVItems.DataSource = BS2_SItems;
            GVItems.Columns[4].Visible = false;
            GVItems.Columns[5].Visible = false;
            GVItems.Columns[6].Visible = false;
            GVItems.Columns[8].Visible = false;
            GVItems.Columns[9].Visible = false;
            GVItems.Refresh();

            GVItems.Columns[0].HeaderText = "ID";
            GVItems.Columns[1].HeaderText = "Category";
            GVItems.Columns[2].HeaderText = "Name";
            GVItems.Columns[3].HeaderText = "Description";
            GVItems.Columns[7].HeaderText = "Availability";
            GVItems.Columns[3].Width = 200;

            //new
            cbFilterBy.SelectedIndex = 0;

            s_OrderDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            s_OrderDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            s_OrderDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            s_OrderItemDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            s_OrderItemDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            s_OrderItemDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            s_OrderItemDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            GVItems.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            mainMenu.Size = new Size(235 + this.Width, 120 + this.Height);

            lblCanteenLoggedInAs.Text = "Logged in as: " + loggedin.S_LoggedInCanteenWorker.Rows[0].ItemArray[2].ToString() + " " + loggedin.S_LoggedInCanteenWorker.Rows[0].ItemArray[3].ToString() + " [Canteen Worker]";
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

        private void cbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderStatus = cbOrderStatus.GetItemText(this.cbOrderStatus.SelectedItem);
            int workerID = Convert.ToInt32(loggedin.S_LoggedInCanteenWorker.Rows[0].ItemArray[0]);
            if (orderStatus == "Ready")
            {
                s_OrderTableAdapter.UpdateQuery(workerID, orderStatus, null, Convert.ToInt32(s_OrderDataGridView.CurrentRow.Cells[0].Value));
                this.s_OrderTableAdapter.PlacedFillBy(this.dSMain.S_Order);
                s_OrderDataGridView.Refresh();

                string employeeEmailAddress = TA_SEmployee.GetEmployeeEmail(Convert.ToInt32(s_OrderTableAdapter.GetEmpID(Convert.ToInt32(s_OrderDataGridView.CurrentRow.Cells[0].Value))));
                MailMessage mail = new MailMessage("codenamedevnd@gmail.com", employeeEmailAddress, "Order #" + Convert.ToInt32(s_OrderDataGridView.CurrentRow.Cells[0].Value) +" is ready", "Hello there, your order is ready for collection");

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("codenamedevnd@gmail.com", "WestGroup2");
                client.EnableSsl = true;
                //client.Send(mail);
                cbOrderStatus.SelectedIndex = -1;
                MessageBox.Show("Email has been successfully sent");


            } else if (orderStatus == "Picked up") //picked up
            {
                s_OrderTableAdapter.UpdateQuery(workerID, orderStatus, DateTime.Now.TimeOfDay.ToString(), Convert.ToInt32(s_OrderDataGridView.CurrentRow.Cells[0].Value));
                this.s_OrderTableAdapter.PlacedFillBy(this.dSMain.S_Order);
                cbOrderStatus.SelectedIndex = -1;
            }
        }

        private void s_OrderItemDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (s_OrderItemDataGridView.Rows.Count >= 1)
            {
                TA_SItems.IDFillBy(dSMain.S_Item, Convert.ToInt32(s_OrderItemDataGridView.CurrentRow.Cells[1].Value));
            }
        }

        private void cbAvailability_SelectedIndexChanged(object sender, EventArgs e)
        {
            string availability = cbAvailability.GetItemText(this.cbAvailability.SelectedItem);
            TA_SItems.UpdateAvailabilityQuery(availability, Convert.ToInt32(GVItems.CurrentRow.Cells[0].Value));
            TA_SItems.Fill(canteenDS.S_Item);
            cbAvailability.SelectedIndex = -1;

            string category = cbFilterBy.SelectedItem.ToString();
            TA_SItems.FilterFillBy(canteenDS.S_Item, category);

            MessageBox.Show("Availability status updated");
        }

        private void tbSearchItem_TextChanged(object sender, EventArgs e)
        {
            string categoryFilter = cbFilterBy.SelectedItem.ToString();
            if (categoryFilter == "<None>" || categoryFilter == null)
            {
                TA_SItems.SearchFillBy(canteenDS.S_Item, tbSearchItem.Text);
            }
            else
            {
                TA_SItems.CategorySearchFillBy(canteenDS.S_Item, categoryFilter, tbSearchItem.Text);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "<None>")
            {
                tbSearchItem.Clear();
                TA_SItems.Fill(canteenDS.S_Item);
            }
            else
            {
                tbSearchItem.Clear();
                string category = cbFilterBy.SelectedItem.ToString();
                TA_SItems.FilterFillBy(canteenDS.S_Item, category);
            }
        }

        private void s_OrderDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (s_OrderDataGridView.Rows.Count > 1)
            {
                canteenInnerJoinTableAdapter.OrderNoFillBy(dSMain.CanteenInnerJoin, Convert.ToInt32(s_OrderDataGridView.CurrentRow.Cells[0].Value));
            }
        }
    }
}
