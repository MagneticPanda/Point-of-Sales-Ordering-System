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
    public partial class FormCart : Form
    {
        private DSMain cartDS;
        private DSLogging loggedIn;

        public FormCart(DSMain main, DSLogging loggedIn)
        {
            InitializeComponent();
            cartDS = main;
            this.loggedIn = loggedIn;
        }

        private void FormCart_Load(object sender, EventArgs e)
        {
            LoadTheme();
            creditPanel.BackColor = ThemeColor.SecondaryColor;
            BS_SInvoice.DataSource = cartDS;
            BS_SInvoice.DataMember = "Invoice";
            GVInvoice.DataSource = BS_SInvoice;
            GVInvoice.Columns[0].Visible = false; //hide the ItemID
            GVInvoice.Refresh();
            lblLoggedInAs.Text = "Logged in as: " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2].ToString() + " " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[3].ToString();
            lblInvalid.Visible = false;
            tbCurrentCredits.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[8].ToString();
            tbAfterCredits.Text = (Convert.ToInt32(tbCurrentCredits.Text) - Convert.ToInt32(tbTotal.Text)).ToString();

            GVInvoice.Columns[1].HeaderText = "Name";
            GVInvoice.Columns[2].HeaderText = "Description";
            GVInvoice.Columns[3].HeaderText = "Unit Price";
            GVInvoice.Columns[4].HeaderText = "Quantity";
            GVInvoice.Columns[5].HeaderText = "Subtotal";
            GVInvoice.Columns[2].Width = 200;
        }

        private void LoadTheme()
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

       public int getTotal()
        {
            int creditSum = 0;
            foreach (DataRow row in cartDS.Invoice.Rows)
            {
                creditSum += Convert.ToInt32(row.ItemArray[5]);
            }
            return creditSum;
        }

        private int getNewCreditBalance()
        {
            int current = Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[8]);
            int total = Convert.ToInt32(tbTotal.Text.ToString());
            return (current - total);
        }

        private void GVInvoice_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            tbTotal.Text = getTotal().ToString();
            GVInvoice.Refresh();
            tbAfterCredits.Text = getNewCreditBalance().ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cartDS.Invoice.Rows.RemoveAt(GVInvoice.CurrentRow.Index);
            tbTotal.Text = getTotal().ToString();
            tbAfterCredits.Text = (Convert.ToInt32(tbCurrentCredits.Text) - Convert.ToInt32(tbTotal.Text)).ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cartDS.Invoice.Rows.Clear();
            tbTotal.Text = getTotal().ToString();
            tbQuantity.Text = "0";
            tbAfterCredits.Text = (Convert.ToInt32(tbCurrentCredits.Text) - Convert.ToInt32(tbTotal.Text)).ToString();
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            //update the stock levels, check for availability flag
            //update employee credit balance, check for overdraft
            if (Convert.ToInt32(tbAfterCredits.Text) < 0)
            {
                DialogResult result = MessageBox.Show("You are about to go into overdraft if you place this order. Do you still wish to proceed? ", "Confirmation", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    int emp_ID = Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]);
                    TA_SOrder.InsertQuery(emp_ID, null, Convert.ToInt32(tbTotal.Text), DateTime.Today.Date.ToString(), DateTime.Now.TimeOfDay.ToString(), "Placed", null);
                    TA_SOrder.Fill(cartDS.S_Order);
                    int orderNo = Convert.ToInt32(cartDS.S_Order.Rows[cartDS.S_Order.Rows.Count - 1].ItemArray[0]);
                    foreach (DataRow invoiceRow in cartDS.Invoice.Rows)
                    {
                        DataRow orderItemRow = cartDS.S_OrderItem.NewRow();
                        orderItemRow[0] = orderNo; //orderID
                        orderItemRow[1] = invoiceRow.ItemArray[0]; //itemID
                        orderItemRow[2] = invoiceRow.ItemArray[4]; //Quantity
                        orderItemRow[3] = invoiceRow.ItemArray[3]; //unitPrice
                        orderItemRow[4] = invoiceRow.ItemArray[5]; //subTotal
                        cartDS.S_OrderItem.Rows.Add(orderItemRow);
                        int totalQuantity = (int)TA_SItem.ScalarQuery(Convert.ToInt32(orderItemRow[1]));
                        TA_SItem.UpdateQuantity( totalQuantity - Convert.ToInt32(orderItemRow[2]), Convert.ToInt32(invoiceRow.ItemArray[0]) );
                    }
                    TA_SOrderItem.Update(cartDS.S_OrderItem);
                    if (Convert.ToInt32(tbAfterCredits.Text) < 0)
                    {
                        TA_SEmployee.UpdateBalance(Convert.ToInt32(tbAfterCredits.Text), "true", Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]));
                    } else
                    {
                        TA_SEmployee.UpdateBalance(Convert.ToInt32(tbAfterCredits.Text), "false", Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]));
                    }
                    cartDS.Invoice.Rows.Clear();
                    GVInvoice.Refresh();
                    loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[9] = true;
                    TA_SEmployee.Update(cartDS.S_Employee);
                    MessageBox.Show("Thank you, " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2].ToString() + ", your order has been placed");
                    tbQuantity.Text = "0";
                } else
                {
                    MessageBox.Show("No order made");
                }
            } else
            {
                DialogResult result = MessageBox.Show("Do you want to place this order for " + tbTotal.Text + " credits? ", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int emp_ID = Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]);
                    TA_SOrder.InsertQuery(emp_ID, null, Convert.ToInt32(tbTotal.Text), DateTime.Today.Date.ToString(), DateTime.Now.TimeOfDay.ToString(), "Placed", null);
                    TA_SOrder.Fill(cartDS.S_Order);
                    int orderNo = Convert.ToInt32(cartDS.S_Order.Rows[cartDS.S_Order.Rows.Count - 1].ItemArray[0]);
                    foreach (DataRow invoiceRow in cartDS.Invoice.Rows)
                    {
                        DataRow orderItemRow = cartDS.S_OrderItem.NewRow();
                        orderItemRow[0] = orderNo; //orderID
                        orderItemRow[1] = invoiceRow.ItemArray[0]; //itemID
                        orderItemRow[2] = invoiceRow.ItemArray[4]; //Quantity
                        orderItemRow[3] = invoiceRow.ItemArray[3]; //unitPrice
                        orderItemRow[4] = invoiceRow.ItemArray[5]; //subTotal
                        cartDS.S_OrderItem.Rows.Add(orderItemRow);
                        int totalQuantity = (int)TA_SItem.ScalarQuery(Convert.ToInt32(orderItemRow[1]));
                        TA_SItem.UpdateQuantity(totalQuantity - Convert.ToInt32(orderItemRow[2]), Convert.ToInt32(invoiceRow.ItemArray[0]));
                    }
                    TA_SOrderItem.Update(cartDS.S_OrderItem);
                    if (Convert.ToInt32(tbAfterCredits.Text) < 0)
                    {
                        TA_SEmployee.UpdateBalance(Convert.ToInt32(tbAfterCredits.Text), "true" ,Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]));
                    } else
                    {
                        TA_SEmployee.UpdateBalance(Convert.ToInt32(tbAfterCredits.Text), "false" ,Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]));
                    }
                    cartDS.Invoice.Rows.Clear();
                    GVInvoice.Refresh();
                    MessageBox.Show("Thank you, " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2].ToString() + " your order has been placed");
                    tbQuantity.Text = "0";
                } else
                {
                    MessageBox.Show("No order made");
                }
            }
            

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(tbQuantity.Text.ToString()) + 1;
            if (quantity < 1 || quantity > TA_SItem.ScalarQuery(Convert.ToInt32(GVInvoice.CurrentRow.Cells[0].Value)))
            {
                btnFinalize.Enabled = false;
                lblInvalid.Visible = true;
            }
            else
            {
                btnFinalize.Enabled = true;
                lblInvalid.Visible = false;
                tbQuantity.Text = quantity.ToString();
                GVInvoice.CurrentRow.Cells[4].Value = quantity;
                GVInvoice.CurrentRow.Cells[5].Value = quantity * Convert.ToInt32(GVInvoice.CurrentRow.Cells[3].Value);
                tbTotal.Text = getTotal().ToString();
                tbAfterCredits.Text = getNewCreditBalance().ToString();
            }
            GVInvoice.Refresh();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(tbQuantity.Text.ToString()) - 1;
            if (quantity < 1 || quantity > TA_SItem.ScalarQuery(Convert.ToInt32(GVInvoice.CurrentRow.Cells[0].Value)))
            {
                btnFinalize.Enabled = false;
                lblInvalid.Visible = true;
            }
            else
            {
                btnFinalize.Enabled = true;
                lblInvalid.Visible = false;
                tbQuantity.Text = quantity.ToString();
                GVInvoice.CurrentRow.Cells[4].Value = quantity;
                GVInvoice.CurrentRow.Cells[5].Value = quantity * Convert.ToInt32(GVInvoice.CurrentRow.Cells[3].Value);
                tbTotal.Text = getTotal().ToString();
                tbAfterCredits.Text = getNewCreditBalance().ToString();
            }
            GVInvoice.Refresh();
        }

        private void GVInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbQuantity.Text = GVInvoice.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
