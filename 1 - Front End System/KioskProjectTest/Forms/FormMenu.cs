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
    public partial class FormMenu : Form
    {
        private DSMain menuDS;
        private DSLogging loggedIn;
        private Button receiptButton;
        private MainMenu mainMenu;

        public FormMenu(ref DSMain main, DSLogging loggedIn, Button receiptButton, MainMenu mainMenu)
        {
            InitializeComponent();
            menuDS = main;
            this.loggedIn = loggedIn;
            this.receiptButton = receiptButton;
            this.mainMenu = mainMenu;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            LoadTheme();
            
            BS_SItem.DataSource = menuDS;
            BS_SItem.DataMember = "S_Item";

            GVConfectioneryItems.DataSource = BS_SItem;
            GVCakeItems.DataSource = BS_SItem;
            GVPastryItems.DataSource = BS_SItem;
            GVFrozenItems.DataSource = BS_SItem;
            GVSavoryItems.DataSource = BS_SItem;
            GVDrinks.DataSource = BS_SItem;

            //New additions
            BS_NInvoice.DataSource = menuDS;
            BS_NInvoice.DataMember = "Invoice";
            GV_Invoice.DataSource = BS_NInvoice;
            GV_Invoice.Refresh();
            //GV_Invoice.Columns[0].Visible = false;
            GV_Invoice.Columns[0].HeaderText = "ID";
            GV_Invoice.Columns[1].HeaderText = "Name";
            GV_Invoice.Columns[2].HeaderText = "Description";
            GV_Invoice.Columns[3].HeaderText = "Unit Price";
            GV_Invoice.Columns[4].HeaderText = "Quantity";
            GV_Invoice.Columns[5].HeaderText = "Subtotal";
            GV_Invoice.Columns[2].Width = 300;
            GV_Invoice.Columns[1].Width = 150;
            GV_Invoice.Columns[0].Width = 50;

            GV_Invoice.Columns[0].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GV_Invoice.Columns[1].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GV_Invoice.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GV_Invoice.Columns[3].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GV_Invoice.Columns[4].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GV_Invoice.Columns[5].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GV_Invoice.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GV_Invoice.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GV_Invoice.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tbCurrentBalance.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[8].ToString();
            tbBalanceAfter.Text = (Convert.ToInt32(tbCurrentBalance.Text) - Convert.ToInt32(tbCartTotal.Text)).ToString();

            //GVConfectioneryItems.Columns[0].Visible = false;
            GVConfectioneryItems.Columns[1].Visible = false;
            GVConfectioneryItems.Columns[6].Visible = false;
            GVConfectioneryItems.Columns[7].Visible = false;
            GVConfectioneryItems.Columns[8].Visible = false;
            GVConfectioneryItems.Columns[9].Visible = false;
            GVCakeItems.Columns[0].Visible = false;
            GVCakeItems.Columns[1].Visible = false;
            GVCakeItems.Columns[6].Visible = false;
            GVCakeItems.Columns[7].Visible = false;
            GVCakeItems.Columns[8].Visible = false;
            GVCakeItems.Columns[9].Visible = false;
            GVPastryItems.Columns[0].Visible = false;
            GVPastryItems.Columns[1].Visible = false;
            GVPastryItems.Columns[6].Visible = false;
            GVPastryItems.Columns[7].Visible = false;
            GVPastryItems.Columns[8].Visible = false;
            GVPastryItems.Columns[9].Visible = false;
            GVFrozenItems.Columns[0].Visible = false;
            GVFrozenItems.Columns[1].Visible = false;
            GVFrozenItems.Columns[6].Visible = false;
            GVFrozenItems.Columns[7].Visible = false;
            GVFrozenItems.Columns[8].Visible = false;
            GVFrozenItems.Columns[9].Visible = false;
            GVSavoryItems.Columns[0].Visible = false;
            GVSavoryItems.Columns[1].Visible = false;
            GVSavoryItems.Columns[6].Visible = false;
            GVSavoryItems.Columns[7].Visible = false;
            GVSavoryItems.Columns[8].Visible = false;
            GVSavoryItems.Columns[9].Visible = false;
            GVDrinks.Columns[0].Visible = false;
            GVDrinks.Columns[1].Visible = false;
            GVDrinks.Columns[6].Visible = false;
            GVDrinks.Columns[7].Visible = false;
            GVDrinks.Columns[8].Visible = false;
            GVDrinks.Columns[9].Visible = false;

            btnConfectioneryAddToInvoice.Enabled = false;
            btnCakeAddToInvoice.Enabled = false;
            btnPastryAddToInvoice.Enabled = false;
            btnFrozenAddToInvoice.Enabled = false;
            btnSavoryAddToInvoice.Enabled = false;
            btnDrinkAdd.Enabled = false;
            
            lblLoggedInAs.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2] + " " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[3];
            lblCakeLoggedInAs.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2] + " " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[3];
            lblPastryLoggedInAs.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2] + " " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[3];
            lblFrozenLoggedInAs.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2] + " " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[3];
            lblSavoryLoggedInAs.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2] + " " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[3];
            lblDrinkLoggedInAs.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2] + " " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[3];

            //headings
            GVConfectioneryItems.Columns[0].HeaderText = "ID";
            GVConfectioneryItems.Columns[2].HeaderText = "Name";
            GVConfectioneryItems.Columns[3].HeaderText = "Description";
            GVConfectioneryItems.Columns[4].HeaderText = "Price";
            GVConfectioneryItems.Columns[5].HeaderText = "# In stock";
            GVCakeItems.Columns[0].HeaderText = "ID";
            GVCakeItems.Columns[2].HeaderText = "Name";
            GVCakeItems.Columns[3].HeaderText = "Description";
            GVCakeItems.Columns[4].HeaderText = "Price";
            GVCakeItems.Columns[5].HeaderText = "# In stock";
            GVPastryItems.Columns[0].HeaderText = "ID";
            GVPastryItems.Columns[2].HeaderText = "Name";
            GVPastryItems.Columns[3].HeaderText = "Description";
            GVPastryItems.Columns[4].HeaderText = "Price";
            GVPastryItems.Columns[5].HeaderText = "# In stock";
            GVFrozenItems.Columns[0].HeaderText = "ID";
            GVFrozenItems.Columns[2].HeaderText = "Name";
            GVFrozenItems.Columns[3].HeaderText = "Description";
            GVFrozenItems.Columns[4].HeaderText = "Price";
            GVFrozenItems.Columns[5].HeaderText = "# In stock";
            GVSavoryItems.Columns[0].HeaderText = "ID";
            GVSavoryItems.Columns[2].HeaderText = "Name";
            GVSavoryItems.Columns[3].HeaderText = "Description";
            GVSavoryItems.Columns[4].HeaderText = "Price";
            GVSavoryItems.Columns[5].HeaderText = "# In stock";
            GVDrinks.Columns[0].HeaderText = "ID";
            GVDrinks.Columns[2].HeaderText = "Name";
            GVDrinks.Columns[3].HeaderText = "Description";
            GVDrinks.Columns[4].HeaderText = "Price";
            GVDrinks.Columns[5].HeaderText = "# In stock";

            GVCakeItems.Columns[3].Width = 300;
            GVPastryItems.Columns[3].Width = 280;
            GVSavoryItems.Columns[3].Width = 280;
            GVFrozenItems.Columns[3].Width = 280;
            GVDrinks.Columns[3].Width = 280;
            GVConfectioneryItems.Columns[3].Width = 280;
            GVConfectioneryItems.Columns[2].Width = 150;
            GVCakeItems.Columns[2].Width = 150;
            GVPastryItems.Columns[2].Width = 150;
            GVSavoryItems.Columns[2].Width = 150;
            GVFrozenItems.Columns[2].Width = 150;
            GVDrinks.Columns[2].Width = 165;

            GVConfectioneryItems.Columns[0].Width = 50;
            GVCakeItems.Columns[0].Width = 50;
            GVPastryItems.Columns[0].Width = 50;
            GVSavoryItems.Columns[0].Width = 50;
            GVFrozenItems.Columns[0].Width = 50;
            GVDrinks.Columns[0].Width = 50;

            lblConfectioneryInvalid.Visible = false;
            lblCakeInvalid.Visible = false;
            lblPastryInvalid.Visible = false;
            lblFrozenInvalid.Visible = false;
            lblSavoryInvalid.Visible = false;
            lblInvalidDrink.Visible = false;

            GVConfectioneryItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVConfectioneryItems.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVCakeItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVCakeItems.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVPastryItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVPastryItems.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVSavoryItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVSavoryItems.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVFrozenItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVFrozenItems.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVDrinks.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVDrinks.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            GVConfectioneryItems.Columns[3].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVConfectioneryItems.Columns[4].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVConfectioneryItems.Columns[5].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVConfectioneryItems.Columns[0].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVConfectioneryItems.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 10);

            GVCakeItems.Columns[3].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVCakeItems.Columns[4].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVCakeItems.Columns[5].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVCakeItems.Columns[0].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVCakeItems.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 10);

            GVPastryItems.Columns[3].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVPastryItems.Columns[4].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVPastryItems.Columns[5].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVPastryItems.Columns[0].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVPastryItems.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 10);

            GVSavoryItems.Columns[3].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVSavoryItems.Columns[4].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVSavoryItems.Columns[5].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVSavoryItems.Columns[0].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVSavoryItems.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 10);

            GVFrozenItems.Columns[3].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVFrozenItems.Columns[4].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVFrozenItems.Columns[5].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVFrozenItems.Columns[0].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVFrozenItems.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 10);

            GVDrinks.Columns[3].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVDrinks.Columns[4].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVDrinks.Columns[5].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVDrinks.Columns[0].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVDrinks.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 10);

            this.TA_SItem.categoryFillBy(menuDS.S_Item, "Confectionery");

            mainMenu.Size = new Size(235 + this.Width, 120 + this.Height);
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
        

        //new methods
        //get the total of the cart
        int getTotal()
        {
            int creditSum = 0;
            foreach(DataRow row in menuDS.Invoice.Rows)
            {
                creditSum += Convert.ToInt32(row.ItemArray[5]);
            }
            return creditSum;
                
        }

        private int getNewCreditBalance()
        {
            int current = Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[8]);
            int total = Convert.ToInt32(tbCartTotal.Text.ToString());
            return (current - total);
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbConfectioneryQuantity.Text) + 1;
            tbConfectioneryQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVConfectioneryItems.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbConfectioneryQuantity.Text) * itemPrice;
            tbConfectionerySubtotal.Text = itemSubtotal.ToString();

            if (( quantity > Convert.ToInt32(GVConfectioneryItems.CurrentRow.Cells[5].Value) )|| Convert.ToInt32(tbConfectioneryQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnConfectioneryAddToInvoice.Enabled = false;
                lblConfectioneryInvalid.Visible = true;
            } else
            {
                btnConfectioneryAddToInvoice.Enabled = true;
                lblConfectioneryInvalid.Visible = false;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbConfectioneryQuantity.Text) - 1;
            tbConfectioneryQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVConfectioneryItems.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbConfectioneryQuantity.Text) * itemPrice;
            tbConfectionerySubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVConfectioneryItems.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbConfectioneryQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnConfectioneryAddToInvoice.Enabled = false;
                lblConfectioneryInvalid.Visible = true;
            } else
            {
                btnConfectioneryAddToInvoice.Enabled = true;
                lblConfectioneryInvalid.Visible = false;
            }
        }

        private void btnAddToInvoice_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add " + tbConfectioneryQuantity.Text + "x " + GVConfectioneryItems.CurrentRow.Cells[2].Value.ToString() + " to your order?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool isDuplicate = false;

                DataRow newRow = menuDS.Invoice.NewRow();

                newRow[0] = GVConfectioneryItems.CurrentRow.Cells[0].Value; //itemID
                
                newRow[1] = GVConfectioneryItems.CurrentRow.Cells[2].Value; //itemName
                
                newRow[2] = GVConfectioneryItems.CurrentRow.Cells[3].Value; //itemDesc
                
                newRow[3] = GVConfectioneryItems.CurrentRow.Cells[4].Value; //itemUnitPrice
                

                newRow[4] = Convert.ToInt32(tbConfectioneryQuantity.Text); //quantity
                newRow[5] = Convert.ToInt32(tbConfectionerySubtotal.Text); //subtotal


                for (int i = 0; i < menuDS.Invoice.Rows.Count; i++)
                {
                    if (menuDS.Invoice.Rows[i].ItemArray[0].Equals(newRow[0]))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    menuDS.Invoice.Rows.Add(newRow);
                    MessageBox.Show("Added successfully");
                } else
                {
                    MessageBox.Show("Already added, please view cart");
                }

                tbConfectioneryQuantity.Text = "0";
                tbConfectionerySubtotal.Text = "0";
                
            }
            else
            {
                MessageBox.Show("Not added");
            }
            
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            TA_SItem.categoryFillBy(menuDS.S_Item, tabControl1.SelectedTab.Text);
            //new stuffs
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    confectioneryTab.Controls.Add(panel13);
                    confectioneryTab.Controls.Add(panel7);
                    break;
                case 1:
                    cakeTab.Controls.Add(panel13);
                    cakeTab.Controls.Add(panel7);
                    break;
                case 2:
                    pastryTab.Controls.Add(panel13);
                    pastryTab.Controls.Add(panel7);
                    break;
                case 3:
                    frozenTab.Controls.Add(panel13);
                    frozenTab.Controls.Add(panel7);
                    break;
                case 4:
                    savoryTab.Controls.Add(panel13);
                    savoryTab.Controls.Add(panel7);
                    break;
                case 5:
                    drinkTab.Controls.Add(panel13);
                    drinkTab.Controls.Add(panel7);
                    break;
            }
        }

        private void tbConfectionerySearch_TextChanged(object sender, EventArgs e)
        {
            TA_SItem.CategorySearchFillBy(menuDS.S_Item, "Confectionery", tbConfectionerySearch.Text);
        }

        private void tbCakeSearch_TextChanged(object sender, EventArgs e)
        {
            TA_SItem.CategorySearchFillBy(menuDS.S_Item, "Cake", tbCakeSearch.Text);
        }

        private void tbPastrySearch_TextChanged(object sender, EventArgs e)
        {
            TA_SItem.CategorySearchFillBy(menuDS.S_Item, "Pastry", tbPastrySearch.Text);
        }

        private void tbFrozenSearch_TextChanged(object sender, EventArgs e)
        {
            TA_SItem.CategorySearchFillBy(menuDS.S_Item, "Frozen", tbFrozenSearch.Text);
        }

        private void tbSavorySearch_TextChanged(object sender, EventArgs e)
        {
            TA_SItem.CategorySearchFillBy(menuDS.S_Item, "Savory", tbSavorySearch.Text);
        }

        private void btnCakeMinus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbCakeQuantity.Text) - 1;
            tbCakeQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVCakeItems.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbCakeQuantity.Text) * itemPrice;
            tbCakeSubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVCakeItems.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbCakeQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnCakeAddToInvoice.Enabled = false;
                lblCakeInvalid.Visible = true;
            } else
            {
                btnCakeAddToInvoice.Enabled = true;
                lblCakeInvalid.Visible = false;
            }
        }

        private void btnCakePlus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbCakeQuantity.Text) + 1;
            tbCakeQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVCakeItems.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbCakeQuantity.Text) * itemPrice;
            tbCakeSubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVCakeItems.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbCakeQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnCakeAddToInvoice.Enabled = false;
                lblCakeInvalid.Visible = true;
            } else
            {
                btnCakeAddToInvoice.Enabled = true;
                lblCakeInvalid.Visible = false;
            }
        }

        private void btnPastryMinus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbPastryQuantity.Text) - 1;
            tbPastryQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVPastryItems.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbPastryQuantity.Text) * itemPrice;
            tbPastrySubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVPastryItems.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbPastryQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnPastryAddToInvoice.Enabled = false;
                lblPastryInvalid.Visible = true;
            } else
            {
                btnPastryAddToInvoice.Enabled = true;
                lblPastryInvalid.Visible = false;
            }
        }

        private void btnPastryPlus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbPastryQuantity.Text) + 1;
            tbPastryQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVPastryItems.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbPastryQuantity.Text) * itemPrice;
            tbPastrySubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVPastryItems.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbPastryQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnPastryAddToInvoice.Enabled = false;
                lblPastryInvalid.Visible = true;
            } else
            {
                btnPastryAddToInvoice.Enabled = true;
                lblPastryInvalid.Visible = false;
            }
        }

        private void btnFrozenMinus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbFrozenQuantity.Text) - 1;
            tbFrozenQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVFrozenItems.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbFrozenQuantity.Text) * itemPrice;
            tbFrozenItemSubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVFrozenItems.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbFrozenQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnFrozenAddToInvoice.Enabled = false;
                lblFrozenInvalid.Visible = true;
            } else
            {
                btnFrozenAddToInvoice.Enabled = true;
                lblFrozenInvalid.Visible = false;
            }
        }

        private void btnFrozenPlus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbFrozenQuantity.Text) + 1;
            tbFrozenQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVFrozenItems.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbFrozenQuantity.Text) * itemPrice;
            tbFrozenItemSubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVFrozenItems.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbFrozenQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnFrozenAddToInvoice.Enabled = false;
                lblFrozenInvalid.Visible = true;
            } else
            {
                btnFrozenAddToInvoice.Enabled = true;
                lblFrozenInvalid.Visible = false;
            }
        }

        private void btnSavoryMinus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbSavoryQuantity.Text) - 1;
            tbSavoryQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVSavoryItems.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbSavoryQuantity.Text) * itemPrice;
            tbSavoryItemSubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVSavoryItems.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbSavoryQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnSavoryAddToInvoice.Enabled = false;
                lblSavoryInvalid.Visible = true;
            } else
            {
                btnSavoryAddToInvoice.Enabled = true;
                lblSavoryInvalid.Visible = false;
            }
        }

        private void btnSavoryPlus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbSavoryQuantity.Text) + 1;
            tbSavoryQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVSavoryItems.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbSavoryQuantity.Text) * itemPrice;
            tbSavoryItemSubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVSavoryItems.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbSavoryQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnSavoryAddToInvoice.Enabled = false;
                lblFrozenInvalid.Visible = true;
            } else
            {
                btnSavoryAddToInvoice.Enabled = true;
                lblFrozenInvalid.Visible = false;
            }
        }

        private void GVConfectioneryItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbConfectioneryQuantity.Text = "0";
            tbConfectionerySubtotal.Text = "0";
            btnConfectioneryAddToInvoice.Enabled = false;
        }

        private void GVCakeItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbCakeQuantity.Text = "0";
            tbCakeSubtotal.Text = "0";
            btnCakeAddToInvoice.Enabled = false;
        }

        private void GVPastryItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbPastryQuantity.Text = "0";
            tbPastrySubtotal.Text = "0";
            btnPastryAddToInvoice.Enabled = false;
        }

        private void GVFrozenItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbFrozenQuantity.Text = "0";
            tbFrozenItemSubtotal.Text = "0";
            btnFrozenAddToInvoice.Enabled = false;
        }

        private void GVSavoryItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbSavoryQuantity.Text = "0";
            tbSavoryItemSubtotal.Text = "0";
            btnSavoryAddToInvoice.Enabled = false;
        }

        private void btnCakeAddToInvoice_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add " + tbCakeQuantity.Text + "x " + GVCakeItems.CurrentRow.Cells[2].Value.ToString() + " to your order?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool isDuplicate = false;
                DataRow newRow = menuDS.Invoice.NewRow();
                newRow[0] = GVCakeItems.CurrentRow.Cells[0].Value; //itemID

                newRow[1] = GVCakeItems.CurrentRow.Cells[2].Value; //itemName

                newRow[2] = GVCakeItems.CurrentRow.Cells[3].Value; //itemDesc

                newRow[3] = GVCakeItems.CurrentRow.Cells[4].Value; //itemUnitPrice


                newRow[4] = Convert.ToInt32(tbCakeQuantity.Text); //quantity
                newRow[5] = Convert.ToInt32(tbCakeSubtotal.Text); //subtotal


                for (int i = 0; i < menuDS.Invoice.Rows.Count; i++)
                {
                    if (menuDS.Invoice.Rows[i].ItemArray[0].Equals(newRow[0]))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    menuDS.Invoice.Rows.Add(newRow);
                    MessageBox.Show("Added successfully");
                }
                else
                {
                    MessageBox.Show("Already added, please view cart");
                }

                tbCakeQuantity.Text = "0";
                tbCakeSubtotal.Text = "0";

            }
            else
            {
                MessageBox.Show("Not added");
            }
        }

        private void btnPastryAddToInvoice_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add " + tbPastryQuantity.Text + "x " + GVPastryItems.CurrentRow.Cells[2].Value.ToString() + " to your order?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool isDuplicate = false;
                DataRow newRow = menuDS.Invoice.NewRow();
                newRow[0] = GVPastryItems.CurrentRow.Cells[0].Value; //itemID

                newRow[1] = GVPastryItems.CurrentRow.Cells[2].Value; //itemName

                newRow[2] = GVPastryItems.CurrentRow.Cells[3].Value; //itemDesc

                newRow[3] = GVPastryItems.CurrentRow.Cells[4].Value; //itemUnitPrice


                newRow[4] = Convert.ToInt32(tbPastryQuantity.Text); //quantity
                newRow[5] = Convert.ToInt32(tbPastrySubtotal.Text); //subtotal


                for (int i = 0; i < menuDS.Invoice.Rows.Count; i++)
                {
                    if (menuDS.Invoice.Rows[i].ItemArray[0].Equals(newRow[0]))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    menuDS.Invoice.Rows.Add(newRow);
                    MessageBox.Show("Added successfully");
                }
                else
                {
                    MessageBox.Show("Already added, please view cart");
                }

                tbCakeQuantity.Text = "0";
                tbCakeSubtotal.Text = "0";

            }
            else
            {
                MessageBox.Show("Not added");
            }
        }

        private void btnFrozenAddToInvoice_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add " + tbFrozenQuantity.Text + "x " + GVConfectioneryItems.CurrentRow.Cells[2].Value.ToString() + " to your order?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool isDuplicate = false;
                DataRow newRow = menuDS.Invoice.NewRow();
                newRow[0] = GVFrozenItems.CurrentRow.Cells[0].Value; //itemID

                newRow[1] = GVFrozenItems.CurrentRow.Cells[2].Value; //itemName

                newRow[2] = GVFrozenItems.CurrentRow.Cells[3].Value; //itemDesc

                newRow[3] = GVFrozenItems.CurrentRow.Cells[4].Value; //itemUnitPrice


                newRow[4] = Convert.ToInt32(tbFrozenQuantity.Text); //quantity
                newRow[5] = Convert.ToInt32(tbFrozenItemSubtotal.Text); //subtotal


                for (int i = 0; i < menuDS.Invoice.Rows.Count; i++)
                {
                    if (menuDS.Invoice.Rows[i].ItemArray[0].Equals(newRow[0]))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    menuDS.Invoice.Rows.Add(newRow);
                    MessageBox.Show("Added successfully");
                }
                else
                {
                    MessageBox.Show("Already added, please view cart");
                }

                tbFrozenQuantity.Text = "0";
                tbFrozenItemSubtotal.Text = "0";

            }
            else
            {
                MessageBox.Show("Not added");
            }
        }

        private void btnSavoryAddToInvoice_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add " + tbSavoryQuantity.Text + "x " + GVConfectioneryItems.CurrentRow.Cells[2].Value.ToString() + " to your order?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool isDuplicate = false;
                DataRow newRow = menuDS.Invoice.NewRow();
                newRow[0] = GVSavoryItems.CurrentRow.Cells[0].Value; //itemID

                newRow[1] = GVSavoryItems.CurrentRow.Cells[2].Value; //itemName

                newRow[2] = GVSavoryItems.CurrentRow.Cells[3].Value; //itemDesc

                newRow[3] = GVSavoryItems.CurrentRow.Cells[4].Value; //itemUnitPrice


                newRow[4] = Convert.ToInt32(tbSavoryQuantity.Text); //quantity
                newRow[5] = Convert.ToInt32(tbSavoryItemSubtotal.Text); //subtotal


                for (int i = 0; i < menuDS.Invoice.Rows.Count; i++)
                {
                    if (menuDS.Invoice.Rows[i].ItemArray[0].Equals(newRow[0]))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    menuDS.Invoice.Rows.Add(newRow);
                    MessageBox.Show("Added successfully");
                }
                else
                {
                    MessageBox.Show("Already added, please view cart");
                }

                tbSavoryQuantity.Text = "0";
                tbSavoryItemSubtotal.Text = "0";

            }
            else
            {
                MessageBox.Show("Not added");
            }
        }

        private void btnDrinkMinus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbDrinkQuantity.Text) - 1;
            tbDrinkQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVDrinks.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbDrinkQuantity.Text) * itemPrice;
            tbDrinkSubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVDrinks.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbDrinkQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnDrinkAdd.Enabled = false;
                lblInvalidDrink.Visible = true;
            }
            else
            {
                btnDrinkAdd.Enabled = true;
                lblInvalidDrink.Visible = false;
            }
        }

        private void btnDrinkPlus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbDrinkQuantity.Text) + 1;
            tbDrinkQuantity.Text = quantity.ToString();

            int itemPrice = int.Parse((GVDrinks.CurrentRow.Cells[4].Value).ToString());
            int itemSubtotal = int.Parse(tbDrinkQuantity.Text) * itemPrice;
            tbDrinkSubtotal.Text = itemSubtotal.ToString();

            if (quantity > Convert.ToInt32(GVDrinks.CurrentRow.Cells[5].Value) || Convert.ToInt32(tbDrinkQuantity.Text.ToString()) < 0 || quantity == 0)
            {
                btnDrinkAdd.Enabled = false;
                lblInvalidDrink.Visible = true;
            }
            else
            {
                btnDrinkAdd.Enabled = true;
                lblInvalidDrink.Visible = false;
            }
        }

        private void tbDrinkSearch_TextChanged(object sender, EventArgs e)
        {
            TA_SItem.CategorySearchFillBy(menuDS.S_Item, "Drink", tbDrinkSearch.Text);
        }

        private void btnDrinkAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add " + tbDrinkQuantity.Text + "x " + GVDrinks.CurrentRow.Cells[2].Value.ToString() + " to your order?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool isDuplicate = false;
                DataRow newRow = menuDS.Invoice.NewRow();
                newRow[0] = GVDrinks.CurrentRow.Cells[0].Value; //itemID

                newRow[1] = GVDrinks.CurrentRow.Cells[2].Value; //itemName

                newRow[2] = GVDrinks.CurrentRow.Cells[3].Value; //itemDesc

                newRow[3] = GVDrinks.CurrentRow.Cells[4].Value; //itemUnitPrice


                newRow[4] = Convert.ToInt32(tbDrinkQuantity.Text); //quantity
                newRow[5] = Convert.ToInt32(tbDrinkSubtotal.Text); //subtotal


                for (int i = 0; i < menuDS.Invoice.Rows.Count; i++)
                {
                    if (menuDS.Invoice.Rows[i].ItemArray[0].Equals(newRow[0]))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    menuDS.Invoice.Rows.Add(newRow);
                    MessageBox.Show("Added successfully");
                }
                else
                {
                    MessageBox.Show("Already added, please view cart");
                }

                tbDrinkQuantity.Text = "0";
                tbDrinkSubtotal.Text = "0";

            }
            else
            {
                MessageBox.Show("Not added");
            }
        }

        private void GVDrinks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbDrinkQuantity.Text = "0";
            tbDrinkSubtotal.Text = "0";
            btnDrinkAdd.Enabled = false;
        }

        //----------NEW STUFF-------------
        private void GV_Invoice_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            tbCartTotal.Text = getTotal().ToString();
            GV_Invoice.Refresh();
            tbBalanceAfter.Text = getNewCreditBalance().ToString();
        }

        private void btnCartRemove_Click(object sender, EventArgs e)
        {
            menuDS.Invoice.Rows.RemoveAt(GV_Invoice.CurrentRow.Index);
            tbCartTotal.Text = getTotal().ToString();
            tbBalanceAfter.Text = (Convert.ToInt32(tbCurrentBalance.Text) - Convert.ToInt32(tbCartTotal.Text)).ToString();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            menuDS.Invoice.Rows.Clear();
            tbCartTotal.Text = getTotal().ToString();
            tbCartQuantity.Text = "0";
            tbBalanceAfter.Text = (Convert.ToInt32(tbCurrentBalance.Text) - Convert.ToInt32(tbCartTotal.Text)).ToString();
        }

        private void btnQuantityPlus_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(tbCartQuantity.Text.ToString()) + 1;
            if (quantity < 1 || quantity > TA_SItem.ScalarQuery(Convert.ToInt32(GV_Invoice.CurrentRow.Cells[0].Value))) //selects the quanitity for the matching ID
            {
                btnPlaceOrder.Enabled = false;
                lblInvalidCartQuan.Visible = true;
            }
            else
            {
                btnPlaceOrder.Enabled = true;
                lblInvalidCartQuan.Visible = false;
                tbCartQuantity.Text = quantity.ToString();
                GV_Invoice.CurrentRow.Cells[4].Value = quantity;
                GV_Invoice.CurrentRow.Cells[5].Value = quantity * Convert.ToInt32(GV_Invoice.CurrentRow.Cells[3].Value);
                tbCartTotal.Text = getTotal().ToString();
                tbBalanceAfter.Text = getNewCreditBalance().ToString();
            }
            GV_Invoice.Refresh();
        }

        private void btnQuantityMinus_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(tbCartQuantity.Text.ToString()) - 1;
            if (quantity < 1 || quantity > TA_SItem.ScalarQuery(Convert.ToInt32(GV_Invoice.CurrentRow.Cells[0].Value)))
            {
                btnPlaceOrder.Enabled = false;
                lblInvalidCartQuan.Visible = true;
            }
            else
            {
                btnPlaceOrder.Enabled = true;
                lblInvalidCartQuan.Visible = false;
                tbCartQuantity.Text = quantity.ToString();
                GV_Invoice.CurrentRow.Cells[4].Value = quantity;
                GV_Invoice.CurrentRow.Cells[5].Value = quantity * Convert.ToInt32(GV_Invoice.CurrentRow.Cells[3].Value);
                tbCartTotal.Text = getTotal().ToString();
                tbBalanceAfter.Text = getNewCreditBalance().ToString();
            }
            GV_Invoice.Refresh();
        }

        private void GV_Invoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbCartQuantity.Text = GV_Invoice.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            //update the stock levels, check for availability flag
            //update employee credit balance, check for overdraft
            if (Convert.ToInt32(tbBalanceAfter.Text) < 0)
            {
                DialogResult result = MessageBox.Show("You are about to go into overdraft if you place this order. Do you still wish to proceed? ", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int emp_ID = Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]);
                    TA_SOrder.InsertQuery(emp_ID, null, Convert.ToInt32(tbCartTotal.Text), DateTime.Today.Date.ToString(), DateTime.Now.TimeOfDay.ToString(), "Placed", null);
                    TA_SOrder.Fill(menuDS.S_Order); //dataset gets populated with the newly added record (order)
                    int orderNo = Convert.ToInt32(menuDS.S_Order.Rows[menuDS.S_Order.Rows.Count - 1].ItemArray[0]);
                    foreach (DataRow invoiceRow in menuDS.Invoice.Rows)
                    {
                        DataRow orderItemRow = menuDS.S_OrderItem.NewRow();
                        orderItemRow[0] = orderNo; //orderID
                        orderItemRow[1] = invoiceRow.ItemArray[0]; //itemID
                        orderItemRow[2] = invoiceRow.ItemArray[4]; //Quantity
                        orderItemRow[3] = invoiceRow.ItemArray[3]; //unitPrice
                        orderItemRow[4] = invoiceRow.ItemArray[5]; //subTotal

                        menuDS.S_OrderItem.Rows.Add(orderItemRow);

                        //reducing the quantity of the item and checking that if the quantity reaches 0 then the item becomes unavailable
                        int totalQuantity = (int)TA_SItem.ScalarQuery(Convert.ToInt32(orderItemRow[1])); //gets the item quantity for the provided item ID
                        if (totalQuantity - Convert.ToInt32(orderItemRow[2]) == 0)
                        {
                            TA_SItem.UpdateAvailabilityQuery("Unavailable", Convert.ToInt32(invoiceRow.ItemArray[0]));
                        }
                        TA_SItem.UpdateQuantity(totalQuantity - Convert.ToInt32(orderItemRow[2]), Convert.ToInt32(invoiceRow.ItemArray[0]));
                        
                    }

                    TA_SOrderItem.Update(menuDS.S_OrderItem);

                    if (Convert.ToInt32(tbBalanceAfter.Text) < 0)
                    {
                        TA_SEmployee.UpdateBalance(Convert.ToInt32(tbBalanceAfter.Text), "true", Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]));
                    }
                    else
                    {
                        TA_SEmployee.UpdateBalance(Convert.ToInt32(tbBalanceAfter.Text), "false", Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]));
                    }

                    menuDS.Invoice.Rows.Clear();
                    GV_Invoice.Refresh();
                    loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[9] = true; //setting overdraft status to true
                    TA_SEmployee.Update(menuDS.S_Employee); //making it update to the main employee database
                    MessageBox.Show("Thank you, " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2].ToString() + ", your order has been placed");
                    tbCartQuantity.Text = "0";
                    receiptButton.Visible = true;
                    mainMenu.btnViewReceipt_Click(receiptButton, e);
                }
                else
                {
                    MessageBox.Show("No order made");
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to place this order for " + tbCartTotal.Text + " credits? ", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int emp_ID = Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]);
                    TA_SOrder.InsertQuery(emp_ID, null, Convert.ToInt32(tbCartTotal.Text), DateTime.Today.Date.ToString(), DateTime.Now.TimeOfDay.ToString(), "Placed", null);
                    TA_SOrder.Fill(menuDS.S_Order);
                    int orderNo = Convert.ToInt32(menuDS.S_Order.Rows[menuDS.S_Order.Rows.Count - 1].ItemArray[0]);
                    foreach (DataRow invoiceRow in menuDS.Invoice.Rows)
                    {
                        DataRow orderItemRow = menuDS.S_OrderItem.NewRow();
                        orderItemRow[0] = orderNo; //orderID
                        orderItemRow[1] = invoiceRow.ItemArray[0]; //itemID
                        orderItemRow[2] = invoiceRow.ItemArray[4]; //Quantity
                        orderItemRow[3] = invoiceRow.ItemArray[3]; //unitPrice
                        orderItemRow[4] = invoiceRow.ItemArray[5]; //subTotal
                        menuDS.S_OrderItem.Rows.Add(orderItemRow);
                        int totalQuantity = (int)TA_SItem.ScalarQuery(Convert.ToInt32(orderItemRow[1]));
                        if (totalQuantity - Convert.ToInt32(orderItemRow[2]) == 0)
                        {
                            TA_SItem.UpdateAvailabilityQuery("Unavailable", Convert.ToInt32(invoiceRow.ItemArray[0]));
                        }
                        TA_SItem.UpdateQuantity(totalQuantity - Convert.ToInt32(orderItemRow[2]), Convert.ToInt32(invoiceRow.ItemArray[0]));
                    }
                    TA_SOrderItem.Update(menuDS.S_OrderItem);
                    if (Convert.ToInt32(tbBalanceAfter.Text) < 0)
                    {
                        TA_SEmployee.UpdateBalance(Convert.ToInt32(tbBalanceAfter.Text), "true", Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]));
                    }
                    else
                    {
                        TA_SEmployee.UpdateBalance(Convert.ToInt32(tbBalanceAfter.Text), "false", Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]));
                    }
                    menuDS.Invoice.Rows.Clear();
                    GV_Invoice.Refresh();
                    MessageBox.Show("Thank you, " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2].ToString() + " your order has been placed");
                    tbCartQuantity.Text = "0";
                    receiptButton.Visible = true;
                    mainMenu.btnViewReceipt_Click(receiptButton, e);
                }
                else
                {
                    MessageBox.Show("No order made");
                }
            }

            int currentIndex = tabControl1.SelectedIndex;

            switch (currentIndex)
            {
                case 0:
                    TA_SItem.categoryFillBy(menuDS.S_Item, "Confectionery");
                    GVConfectioneryItems.Refresh();
                    break;
                case 1:
                    TA_SItem.categoryFillBy(menuDS.S_Item, "Cake");
                    GVCakeItems.Refresh();
                    break;
                case 2:
                    TA_SItem.categoryFillBy(menuDS.S_Item, "Pastry");
                    GVPastryItems.Refresh();
                    break;
                case 3:
                    TA_SItem.categoryFillBy(menuDS.S_Item, "Frozen");
                    GVFrozenItems.Refresh();
                    break;
                case 4:
                    TA_SItem.categoryFillBy(menuDS.S_Item, "Savory");
                    GVSavoryItems.Refresh();
                    break;
                case 5:
                    TA_SItem.categoryFillBy(menuDS.S_Item, "Drink");
                    GVDrinks.Refresh();
                    break;
            }

            TA_SLoggedInEmployee.LoginFillBy(loggedIn.S_LoggedInEmployee, Convert.ToInt32(loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[0]), loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[1].ToString());
            tbCurrentBalance.Text = loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[8].ToString();
            tbBalanceAfter.Text = tbCurrentBalance.Text;
        }
    }
}
