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
    public partial class FormManagement : Form
    {
        DSMain managementDS;
        DSLogging loggedIn;
        MainMenu mainMenu;

        public FormManagement(DSMain main, DSLogging loggedIn, MainMenu mainMenu)
        {
            managementDS = main;
            
            InitializeComponent();
            this.loggedIn = loggedIn;

            this.BS_SItems.DataSource = managementDS;
            this.BS_SItems.DataMember = "S_Item";
            GVItems.DataSource = BS_SItems;
            
            this.BS_SEmployees.DataSource = managementDS;
            this.BS_SEmployees.DataMember = "S_Employee";
            GVEmployees.DataSource = BS_SEmployees;

            this.BS_SCanteenWorker.DataSource = managementDS;
            this.BS_SCanteenWorker.DataMember = "S_CanteenWorker";
            GVCanteenWorkers.DataSource = BS_SCanteenWorker;

            this.mainMenu = mainMenu;
            
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

        private bool containsLetters(string s)
        {
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return s.All(c => allowedCharacters.Contains(c));
        }

        private List<string> currentItems()
        {
            List<string> items = new List<string>();
            foreach (DataRow row in managementDS.S_Item.Rows)
            {
                items.Add(row.ItemArray[2].ToString());
            }
            return items;
        }

        private void FormManagement_Load(object sender, EventArgs e)
        {
            LoadTheme();
            TA_SItems.Fill(managementDS.S_Item);
            TA_SEmployee.Fill(managementDS.S_Employee);
            //GVEmployees.Columns[0].Visible = false;
            GVEmployees.Columns[1].Visible = false;
            GVEmployees.Columns[9].Visible = false;
            GVItems.Columns[9].Visible = false;

            TA_SCanteenWorker.Fill(managementDS.S_CanteenWorker);
            GVEmployees.Refresh();
            GVCanteenWorkers.Refresh();
            //heading set
            GVItems.Columns[0].HeaderText = "ID";
            GVItems.Columns[1].HeaderText = "Category";
            GVItems.Columns[2].HeaderText = "Name";
            GVItems.Columns[3].HeaderText = "Description";
            GVItems.Columns[4].HeaderText = "Price";
            GVItems.Columns[5].HeaderText = "Quantity";
            GVItems.Columns[6].HeaderText = "Threshold";
            GVItems.Columns[7].HeaderText = "Availability";
            GVItems.Columns[8].HeaderText = "Archive status";
            GVItems.Columns[3].Width = 300;

            GVEmployees.Columns[0].HeaderText = "ID";
            GVEmployees.Columns[2].HeaderText = "First Name";
            GVEmployees.Columns[3].HeaderText = "Surname";
            GVEmployees.Columns[4].HeaderText = "Email";
            GVEmployees.Columns[5].HeaderText = "Phone Number";
            GVEmployees.Columns[6].HeaderText = "Role";
            GVEmployees.Columns[7].HeaderText = "Credit Limit";
            GVEmployees.Columns[8].HeaderText = "Credit Balance";
            //GVEmployees.Columns[9].HeaderText = "Overdaft Status";
            GVEmployees.Columns[4].Width = 270;
            GVEmployees.Columns[6].Width = 150;

            GVCanteenWorkers.Columns[0].HeaderText = "ID";
            GVCanteenWorkers.Columns[1].HeaderText = "Password";
            GVCanteenWorkers.Columns[2].HeaderText = "First Name";
            GVCanteenWorkers.Columns[3].HeaderText = "Surname";
            GVCanteenWorkers.Columns[4].HeaderText = "Phone Number";
            GVCanteenWorkers.Columns[5].HeaderText = "Email";
            GVCanteenWorkers.Columns[6].HeaderText = "Archive Status";
            GVCanteenWorkers.Columns[5].Width = 270;
            lblLoggedInAsItems.Text = "Logged in as: " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[2].ToString() + " " + loggedIn.S_LoggedInEmployee.Rows[0].ItemArray[3].ToString() + " [Manager]";

            //new
            cb_filterby.SelectedIndex = 0;
            GVCanteenWorkers.Columns[1].Visible = false;
            cb_employeeSearchBy.SelectedIndex = 0;
            cb_WorkerSearchBy.SelectedIndex = 0;

            GVItems.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVItems.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVItems.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVItems.Columns[0].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVItems.Columns[1].DefaultCellStyle.Font = new Font("Century Gothic", 9);
            GVItems.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVItems.Columns[3].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVItems.Columns[4].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVItems.Columns[5].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVItems.Columns[6].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVItems.Columns[7].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVItems.Columns[8].DefaultCellStyle.Font = new Font("Century Gothic", 10);

            GVEmployees.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVEmployees.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVEmployees.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVEmployees.Columns[0].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVEmployees.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVEmployees.Columns[3].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVEmployees.Columns[4].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVEmployees.Columns[5].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVEmployees.Columns[6].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVEmployees.Columns[7].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVEmployees.Columns[8].DefaultCellStyle.Font = new Font("Century Gothic", 10);

            GVCanteenWorkers.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GVCanteenWorkers.Columns[0].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVCanteenWorkers.Columns[1].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVCanteenWorkers.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVCanteenWorkers.Columns[3].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVCanteenWorkers.Columns[4].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVCanteenWorkers.Columns[5].DefaultCellStyle.Font = new Font("Century Gothic", 10);
            GVCanteenWorkers.Columns[6].DefaultCellStyle.Font = new Font("Century Gothic", 10);

            mainMenu.Size = new Size(235 + this.Width, 120 + this.Height);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string categoryFilter = cb_filterby.SelectedItem.ToString();
            if (categoryFilter == "<None>" || categoryFilter == null)
            {
                TA_SItems.SearchFillBy(managementDS.S_Item, tbSearch.Text);
            }
            else
            {
                TA_SItems.CategorySearchFillBy(managementDS.S_Item, categoryFilter, tbSearch.Text);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Equals("") || tbPrice.Text.Equals("") || tbCategory.Text.Equals("") || tbDescription.Text.Equals("") || tbAvailability.Text.Equals("")
                || tbQuantity.Text.Equals("") || tbThreshold.Text.Equals(""))
            {
                MessageBox.Show("Do not leave fields blank");
            }
            BS_SItems.EndEdit();
            TA_SItems.Update(managementDS);
            MessageBox.Show("Item updated");
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            BS_SItems.MoveFirst();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            BS_SItems.MoveNext();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            BS_SItems.MovePrevious();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            BS_SItems.MoveLast();
        }

        private void btnFirstEmp_Click(object sender, EventArgs e)
        {
            BS_SEmployees.MoveFirst();
        }

        private void btnNextEmp_Click(object sender, EventArgs e)
        {
            BS_SEmployees.MoveNext();
        }

        private void btnPrevEmp_Click(object sender, EventArgs e)
        {
            BS_SEmployees.MovePrevious();
        }

        private void btnLastEmp_Click(object sender, EventArgs e)
        {
            BS_SEmployees.MoveLast();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove this item?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                BS_SItems.RemoveCurrent();
                TA_SItems.Update(managementDS);
                MessageBox.Show("Item removed");
            }
            else
            {
                MessageBox.Show("Item NOT removed");
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (tbItemName.Text.Equals("") || tbItemDescription.Text.Equals("") || tbItemPrice.Equals("") || tbItemQuantity.Text.Equals("") || tbItemThreshold.Text.Equals("") || cbCategory.SelectedItem.ToString().Equals(""))
            {
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                TA_SItems.Insert(cbCategory.GetItemText(this.cbCategory.SelectedItem), tbItemName.Text, tbItemDescription.Text, Convert.ToInt32(tbItemPrice.Text), Convert.ToInt32(tbItemQuantity.Text), Convert.ToInt32(tbItemThreshold.Text), "Available", "false", null);
                TA_SItems.Fill(managementDS.S_Item);
                MessageBox.Show("Item added");
                tbItemName.Clear();
                tbItemDescription.Clear();
                tbItemPrice.Clear();
                tbItemQuantity.Clear();
                tbItemThreshold.Clear();
                lblIvalidItemName.Visible = false;
                lblInvalidDescrip.Visible = false;
                lblInvalidItemPrice.Visible = false;
                lblInvalidItemQuantity.Visible = false;
                lblInvaidItemThreshold.Visible = false;
                cbCategory.SelectedIndex = -1;
            }
            
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            BS_SEmployees.EndEdit();
            TA_SEmployee.Update(managementDS);
            MessageBox.Show("Credit limit updated");
        }

        private void btnGlobalLimit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to want to set the monthly global credit limit to " + tbGlobalLimit.Text, "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                TA_SEmployee.UpdateLimit(Convert.ToInt32(tbGlobalLimit.Text));
                TA_SEmployee.Fill(managementDS.S_Employee);
                foreach (DataRow employee in managementDS.S_Employee.Rows)
                {
                    TA_SEmployee.UpdateBalance(Convert.ToInt32(tbGlobalLimit.Text), "false", Convert.ToInt32(employee.ItemArray[0]));
                }
                TA_SEmployee.Fill(managementDS.S_Employee);
                tbGlobalLimit.Clear();
                lblInvalidGlobalCredit.Visible = false;
                MessageBox.Show("Monthly Limit Set");
            }
            else
            {
                MessageBox.Show("Operation aborted");
                tbGlobalLimit.Clear();
                lblInvalidGlobalCredit.Visible = false;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text.Length > 30)
            {
                lblInvalidName.Text = "Too long";
                lblInvalidName.Visible = true;
                btnUpdate.Enabled = false;
            }
            else if (tbName.Text.Equals(""))
            {
                lblInvalidName.Text = "Can't be blank";
                lblInvalidName.Visible = true;
                btnUpdate.Enabled = false;
            }
            else
            {
                lblInvalidName.Visible = false;
                btnUpdate.Enabled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            if (tbCategory.Text.Contains("Confectionery") || tbCategory.Text.Contains("Cake"))
            {
                lblInvalidCategory.Visible = false;
                btnUpdate.Enabled = true;
            } else if (tbCategory.Text.Contains("Pastry") || tbCategory.Text.Contains("Frozen"))
            {
                lblInvalidCategory.Visible = false;
                btnUpdate.Enabled = true;
            } else if (tbCategory.Text.Contains("Savory") || tbCategory.Text.Contains("Drink"))
            {
                lblInvalidCategory.Visible = false;
                btnUpdate.Enabled = true;
            } else
            {
                lblInvalidCategory.Visible = true;
                btnUpdate.Enabled = false;
            }
        }

        private void tbAvailability_TextChanged(object sender, EventArgs e)
        {
            if (tbAvailability.Text.Contains("Available") || tbAvailability.Text.Contains("Unavailable"))
            {
                lblInvalidAvailability.Visible = false;
                btnUpdate.Enabled = true;
            }
            else
            {
                lblInvalidAvailability.Visible = true;
                btnUpdate.Enabled = false;
            }
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            int price = 0;
            bool isNumber = int.TryParse(tbPrice.Text, out price);
            if (isNumber)
            {
                if (price < 0)
                {
                    lblInvalidPrice.Text = "No negatives";
                    lblInvalidPrice.Visible = true;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    lblInvalidPrice.Visible = false;
                    btnUpdate.Enabled = true;
                }
            }
            else
            {
                if (tbPrice.Text.Equals(""))
                {
                    lblInvalidPrice.Text = "Can't be empty";
                    lblInvalidPrice.Visible = true;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    lblInvalidPrice.Text = "No letters";
                    lblInvalidPrice.Visible = true;
                    btnUpdate.Enabled = false;
                }
                
            }
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            int quantity = 0;
            bool isNumber = int.TryParse(tbQuantity.Text, out quantity);
            if (isNumber)
            {
                if (quantity < 0)
                {
                    lblInvalidQuantity.Text = "No negatives";
                    lblInvalidQuantity.Visible = true;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    lblInvalidQuantity.Visible = false;
                    btnUpdate.Enabled = true;
                }
            }
            else
            {
                if (tbQuantity.Text.Equals(""))
                {
                    lblInvalidQuantity.Text = "Can't be empty";
                    lblInvalidQuantity.Visible = true;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    lblInvalidQuantity.Text = "No letters";
                    lblInvalidQuantity.Visible = true;
                    btnUpdate.Enabled = false;
                }
                    
            }
            
        }


        private void tbItemName_TextChanged(object sender, EventArgs e)
        {
            List<string> allItems = currentItems();

            if (tbItemName.Text.Length > 30)
            {
                lblIvalidItemName.Text = "Too long";
                lblIvalidItemName.Visible = true;
                btnAddItem.Enabled = false;
            }
            else if (tbItemName.Text.Equals(""))
            {
                lblIvalidItemName.Text = "Can't be empty";
                lblIvalidItemName.Visible = true;
                btnAddItem.Enabled = false;
            }
            else if (allItems.IndexOf(tbItemName.Text) >= 0)
            {
                lblIvalidItemName.Text = "Already exists";
                lblIvalidItemName.Visible = true;
                btnAddItem.Enabled = false;
            }
            else
            {
                lblIvalidItemName.Visible = false;
                btnAddItem.Enabled = true;
            }

        }

        private void tbItemPrice_TextChanged(object sender, EventArgs e)
        {
            /*
            int price = 0;
            bool isNumber = int.TryParse(tbPrice.Text, out price);
            if (isNumber)
            {
                if (price < 0)
                {
                    lblInvalidPrice.Text = "No negatives";
                    lblInvalidPrice.Visible = true;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    lblInvalidPrice.Visible = false;
                    btnUpdate.Enabled = true;
                }
            }
            else
            {
                if (tbPrice.Text.Equals(""))
                {
                    lblInvalidPrice.Text = "Can't be empty";
                    lblInvalidPrice.Visible = true;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    lblInvalidPrice.Text = "No letters";
                    lblInvalidPrice.Visible = true;
                    btnUpdate.Enabled = false;
                }
                
            }
            */
            int itemPrice = 0;
            bool isNumber = int.TryParse(tbItemPrice.Text, out itemPrice);
            if (isNumber)
            {
                if (itemPrice < 0)
                {
                    lblInvalidItemPrice.Text = "No negatives";
                    lblInvalidItemPrice.Visible = true;
                    btnAddItem.Enabled = false;
                }
                else
                {
                    lblInvalidItemPrice.Visible = false;
                    btnAddItem.Enabled = true;
                }
            }
            else
            {
                if (tbItemPrice.Text.Equals(""))
                {
                    lblInvalidItemPrice.Text = "Can't be empty";
                    lblInvalidItemPrice.Visible = true;
                    btnAddItem.Enabled = false;
                }
                else
                {
                    lblInvalidItemPrice.Text = "No letters";
                    lblInvalidItemPrice.Visible = true;
                    btnAddItem.Enabled = false;
                }
            }
        }

        private void tbItemQuantity_TextChanged(object sender, EventArgs e)
        {
            int itemQuantity = 0;
            bool isNumber = int.TryParse(tbItemQuantity.Text, out itemQuantity);
            if (isNumber)
            {
                if (itemQuantity < 0)
                {
                    lblInvalidItemQuantity.Text = "No negatives";
                    lblInvalidItemQuantity.Visible = true;
                    btnAddItem.Enabled = false;
                }
                else
                {
                    lblInvalidItemQuantity.Visible = false;
                    btnAddItem.Enabled = true;
                }
            }
            else
            {
                if (tbItemQuantity.Text.Equals(""))
                {
                    lblInvalidItemQuantity.Text = "Can't be empty";
                    lblInvalidItemQuantity.Visible = true;
                    btnAddItem.Enabled = false;
                }
                else
                {
                    lblInvalidItemQuantity.Text = "No letters";
                    lblInvalidItemQuantity.Visible = true;
                    btnAddItem.Enabled = false;
                }
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int creditLimit = 0;
            bool isNumber = int.TryParse(tbIndividualCredit.Text, out creditLimit);

            if (isNumber)
            {
                if (creditLimit < 0)
                {
                    lblInvalidIndividualCredit.Text = "No negatives allowed";
                    lblInvalidIndividualCredit.Visible = true;
                    btnUpdateEmp.Enabled = false;
                }
                else
                {
                    lblInvalidIndividualCredit.Visible = false;
                    btnUpdateEmp.Enabled = true;
                }
            }
            else
            {
                if (tbIndividualCredit.Text.Equals(""))
                {
                    lblInvalidIndividualCredit.Text = "Can't be blank";
                    lblInvalidIndividualCredit.Visible = true;
                    btnUpdateEmp.Enabled = false;
                }
                else
                {
                    lblInvalidIndividualCredit.Text = "Invalid character";
                    lblInvalidIndividualCredit.Visible = true;
                    btnUpdateEmp.Enabled = false;
                }
            }
            
        }

        private void tbGlobalLimit_TextChanged(object sender, EventArgs e)
        {
            int credLimit = 0;
            bool isNumber = int.TryParse(tbGlobalLimit.Text, out credLimit);
            if (isNumber)
            {
                if (credLimit < 0)
                {
                    lblInvalidLimit.Text = "No negatives allowed";
                    lblInvalidLimit.Visible = true;
                    btnGlobalLimit.Enabled = false;
                }
                else
                {
                    lblInvalidLimit.Visible = false;
                    btnGlobalLimit.Enabled = true;
                }
            }
            else
            {
                if (tbGlobalLimit.Text.Equals(""))
                {
                    lblInvalidLimit.Text = "Can't be blank";
                    lblInvalidLimit.Visible = true;
                    btnGlobalLimit.Enabled = false;
                }
                else
                {
                    lblInvalidLimit.Text = "No letters";
                    lblInvalidLimit.Visible = true;
                    btnGlobalLimit.Enabled = false;
                }

            }
            
        }

        private void tbThreshold_TextChanged(object sender, EventArgs e)
        {
            int threshold = 0;
            bool isNumber = int.TryParse(tbThreshold.Text, out threshold);
            if (isNumber)
            {
                if (threshold < 0)
                {
                    lblInvalidThreshold.Text = "No negatives";
                    lblInvalidThreshold.Visible = true;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    lblInvalidThreshold.Visible = false;
                    btnUpdate.Enabled = true;
                }
            }
            else
            {
                if (tbThreshold.Text.Equals(""))
                {
                    lblInvalidThreshold.Text = "Can't be empty";
                    lblInvalidThreshold.Visible = true;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    lblInvalidThreshold.Text = "No letters";
                    lblInvalidThreshold.Visible = true;
                    btnUpdate.Enabled = false;
                }
            }
            
        }

        private void tbItemThreshold_TextChanged(object sender, EventArgs e)
        {
            int itemThreshold = 0;
            bool isNumber = int.TryParse(tbItemThreshold.Text, out itemThreshold);
            if (isNumber)
            {
                if (itemThreshold < 0)
                {
                    lblInvaidItemThreshold.Text = "No negatives";
                    lblInvaidItemThreshold.Visible = true;
                    btnAddItem.Enabled = false;
                }
                else
                {
                    lblInvaidItemThreshold.Visible = false;
                    btnAddItem.Enabled = true;
                }
            }
            else
            {
                if (tbItemThreshold.Text.Equals(""))
                {
                    lblInvaidItemThreshold.Text = "Can't be empty";
                    lblInvaidItemThreshold.Visible = true;
                    btnAddItem.Enabled = false;
                }
                else
                {
                    lblInvaidItemThreshold.Text = "No letters";
                    lblInvaidItemThreshold.Visible = true;
                    btnAddItem.Enabled = false;
                }
            }
        }

        private void btnWorkerUpdate_Click(object sender, EventArgs e)
        {
            BS_SCanteenWorker.EndEdit();
            TA_SCanteenWorker.Update(managementDS);
            MessageBox.Show("Workere detals updated");
        }

        private void btnWorkerRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove this worker?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                BS_SCanteenWorker.RemoveCurrent();
                TA_SCanteenWorker.Update(managementDS);
                MessageBox.Show("Entry removed");
            } else
            {
                MessageBox.Show("NOT removed");
            }
        }

        private void btnWorkerArchive_Click(object sender, EventArgs e)
        {
            string currentStatus = GVCanteenWorkers.CurrentRow.Cells[6].Value.ToString();
            if (currentStatus == "false")
            {
                TA_SCanteenWorker.UpdateArchiveStatusQuery("true", Convert.ToInt32(GVCanteenWorkers.CurrentRow.Cells[0].Value));
                TA_SCanteenWorker.Fill(managementDS.S_CanteenWorker);
            } if (currentStatus == "true")
            {
                TA_SCanteenWorker.UpdateArchiveStatusQuery("false", Convert.ToInt32(GVCanteenWorkers.CurrentRow.Cells[0].Value));
                TA_SCanteenWorker.Fill(managementDS.S_CanteenWorker);
            }
            
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // Generate a random number between two numbers    
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        //creates a  random password with first 4 characters lowercase, a random number, and 2 uppercase letters
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private void btnAddNewWorker_Click(object sender, EventArgs e)
        {
            if (tbWorkerID.Text.Equals("") || tbWorkerFName.Text.Equals("") || tbWorkerEmail.Text.Equals("") || tbWorkerLName.Text.Equals("") || tbWorkerPhNo.Text.Equals(""))
            {
                MessageBox.Show("Please fill in all required fields");
            }
            else
            {
                tbWorkerPwd.Text = RandomPassword();
                MailMessage mail = new MailMessage("codenamedevnd@gmail.com", tbWorkerEmail.Text, "Your password", "Hi there,\n\n" + "Your password is:\n" + tbWorkerPwd.Text
                    + "\n\nKind regards\nThe CNDND Team");

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("codenamedevnd@gmail.com", "WestGroup2");
                client.EnableSsl = true;
                client.Send(mail);

                TA_SCanteenWorker.Insert(Convert.ToInt32(tbWorkerID.Text), tbWorkerPwd.Text, tbWorkerFName.Text, tbWorkerLName.Text, tbWorkerPhNo.Text, tbWorkerEmail.Text, "false");
                MessageBox.Show("New canteen worker added and Email Sent");
                TA_SCanteenWorker.Fill(managementDS.S_CanteenWorker);
                tbWorkerID.Clear();
                tbWorkerFName.Clear();
                tbWorkerLName.Clear();
                tbWorkerPwd.Clear();
                tbWorkerEmail.Clear();
                tbWorkerPhNo.Clear();
                lblNewIDInvalid.Visible = false;
                lblNewNameInvalid.Visible = false;
                lblInvalidNewEmail.Visible = false;
                lblNewSurnameInvalid.Visible = false;
                lblNewPhNoInvalid.Visible = false;
            }
            
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            BS_SCanteenWorker.MoveFirst();
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            BS_SCanteenWorker.MoveNext();
        }

        private void btnMovePrev_Click(object sender, EventArgs e)
        {
            BS_SCanteenWorker.MovePrevious();
        }

        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            BS_SCanteenWorker.MoveLast();
        }

        private void btnToggleArchive_Click(object sender, EventArgs e)
        {
            string currentStatus = GVItems.CurrentRow.Cells[8].Value.ToString();
            if (currentStatus == "false")
            {
                TA_SItems.UpdateArchiveQuery("true", Convert.ToInt32(GVItems.CurrentRow.Cells[0].Value));
                //new
                TA_SItems.UpdateAvailabilityQuery("Unavailable", Convert.ToInt32(GVItems.CurrentRow.Cells[0].Value));
                TA_SItems.Fill(managementDS.S_Item);
            }
            if (currentStatus == "true")
            {
                TA_SItems.UpdateArchiveQuery("false", Convert.ToInt32(GVItems.CurrentRow.Cells[0].Value));
                //new
                TA_SItems.Fill(managementDS.S_Item);
            }
        }

        private void tbSearchEmp_TextChanged(object sender, EventArgs e)
        {
            if (cb_employeeSearchBy.SelectedItem.ToString() == "Name")
            {
                TA_SEmployee.SearchFillBy(managementDS.S_Employee, tbSearchEmp.Text);
            }
            else if (cb_employeeSearchBy.SelectedItem.ToString() == "Surname")
            {
                TA_SEmployee.SurnameSearchFillBy(managementDS.S_Employee, tbSearchEmp.Text);
            }
            
        }

        private void tbCanteenSearch_TextChanged(object sender, EventArgs e)
        {
            if (cb_WorkerSearchBy.SelectedItem.ToString() == "Name")
            {
                TA_SCanteenWorker.SearchFillBy(managementDS.S_CanteenWorker, tbCanteenSearch.Text);
            }
            else if (cb_WorkerSearchBy.SelectedItem.ToString() == "Surname")
            {
                TA_SCanteenWorker.SurnameSearchFillBy(managementDS.S_CanteenWorker, tbCanteenSearch.Text);
            }
            
        }
        

        private void tbFName_TextChanged(object sender, EventArgs e)
        {
            bool containsInt = tbFName.Text.Any(char.IsDigit);
            if (containsInt)
            {
                lblInvalidWorkerFName.Text = "No numbers";
                lblInvalidWorkerFName.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else if (tbFName.Text.Length > 20)
            {
                    lblInvalidWorkerFName.Text = "Too long";
                    lblInvalidWorkerFName.Visible = true;
                    btnWorkerUpdate.Enabled = false;   
            }
            else if (tbFName.Text.Equals(""))
            {
                lblInvalidWorkerFName.Text = "Can't be blank";
                lblInvalidWorkerFName.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else
            {
                lblInvalidWorkerFName.Visible = false;
                btnWorkerUpdate.Enabled = true;
            }
        }

        private void tbLName_TextChanged(object sender, EventArgs e)
        {
            bool containsInt = tbLName.Text.Any(char.IsDigit);
            if (containsInt)
            {
                lblInvalidWorkerLName.Text = "No numbers";
                lblInvalidWorkerLName.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else if (tbLName.Text.Length > 20)
            {
                lblInvalidWorkerLName.Text = "Too long";
                lblInvalidWorkerLName.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else if (tbLName.Text.Equals(""))
            {
                lblInvalidWorkerLName.Text = "Can't be blank";
                lblInvalidWorkerLName.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else
            {
                lblInvalidWorkerLName.Visible = false;
                btnWorkerUpdate.Enabled = true;
            }
        }

        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (tbPhoneNumber.Text.IndexOf('0') != 0)
            {
                lblInvalidWorkerPh.Text = "Must start with 0";
                lblInvalidWorkerPh.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else if (tbPhoneNumber.Text.ToString().Length < 9)
            {
                lblInvalidWorkerPh.Text = "Too short";
                lblInvalidWorkerPh.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else if (tbPhoneNumber.Text.ToString().Length > 9)
            {
                lblInvalidWorkerPh.Text = "Too long";
                lblInvalidWorkerPh.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else if (!Char.IsDigit(ch) && ch != 46)
            {
                lblInvalidWorkerPh.Text = "Invalid Character";
                lblInvalidWorkerPh.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else
            {
                lblNewPhNoInvalid.Visible = false;
                btnWorkerUpdate.Enabled = true;
            }

        }

        private void tbWorkerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }


        private void tbWorkerPhNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (tbWorkerPhNo.Text.IndexOf('0') != 0)
            {
                lblNewPhNoInvalid.Text = "Must start with 0";
                lblNewPhNoInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else if (tbWorkerPhNo.Text.ToString().Length < 9)
            {
                lblNewPhNoInvalid.Text = "Too short";
                lblNewPhNoInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else if(tbWorkerPhNo.Text.ToString().Length > 9)
            {
                lblNewPhNoInvalid.Text = "Too long";
                lblNewPhNoInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else if (!Char.IsDigit(ch) && ch != 46)
            {
                lblNewPhNoInvalid.Text = "Invalid Character";
                lblNewPhNoInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else if (tbWorkerPhNo.Text.Equals(""))
            {
                lblNewPhNoInvalid.Text = "Can't be blank";
                lblNewPhNoInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else
            {
                lblNewPhNoInvalid.Visible = false;
                btnAddNewWorker.Enabled = true;
            }
            
        }


        bool isValidEmail(string email)
        {
            int periodCouter = 0;
            int atCounter = 0;
            for(int i = 0; i < email.Length; i++)
            {
                if (email[i].Equals('.'))
                {
                    periodCouter = periodCouter + 1;
                }
                if (email[i].Equals('@'))
                {
                    atCounter = atCounter + 1;
                }
            }

            if (periodCouter >= 1 && atCounter == 1)
            {
                if (email.Contains(".com") || email.Contains(".co.za"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            if (!isValidEmail(tbEmail.Text))
            {
                lblInvalidEmail.Text = "Not valid";
                lblInvalidEmail.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else if(tbEmail.Text.Length > 35)
            {
                lblInvalidEmail.Text = "Too long";
                lblInvalidEmail.Visible = true;
                btnWorkerUpdate.Enabled = false;
            }
            else
            {
                lblInvalidEmail.Visible = false;
                btnWorkerUpdate.Enabled = true;
            }
        }

        private void tbWorkerEmail_TextChanged(object sender, EventArgs e)
        {
            if (!isValidEmail(tbWorkerEmail.Text))
            {
                lblInvalidNewEmail.Text = "Invalid email";
                lblInvalidNewEmail.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else if (tbWorkerEmail.Text.Length > 35)
            {
                lblInvalidNewEmail.Text = "Too long";
                lblInvalidNewEmail.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else
            {
                lblInvalidNewEmail.Visible = false;
                btnAddNewWorker.Enabled = true;
            }
        }

        private void cb_filterby_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_filterby.SelectedItem.ToString() == "<None>")
            {
                tbSearch.Clear();
                TA_SItems.Fill(managementDS.S_Item);
            }
            else if (cb_filterby.SelectedItem.ToString() == "Archived")
            {
                tbSearch.Clear();
                TA_SItems.ArchiveStatusFillBy(managementDS.S_Item, "true");
            }
            else if (cb_filterby.SelectedItem.ToString() == "Not Archived")
            {
                tbSearch.Clear();
                TA_SItems.ArchiveStatusFillBy(managementDS.S_Item, "false");
            }
            else if (cb_filterby.SelectedItem.ToString() == "Available")
            {
                tbSearch.Clear();
                TA_SItems.AvailabilityFillBy(managementDS.S_Item, "Available");
            }
            else if (cb_filterby.SelectedItem.ToString() == "Unavailable")
            {
                tbSearch.Clear();
                TA_SItems.AvailabilityFillBy(managementDS.S_Item, "Unavailable");
            }
            else if (cb_filterby.SelectedItem.ToString() == "Below Threshold")
            {
                tbSearch.Clear();
                TA_SItems.ThresholdFillBy(managementDS.S_Item);
            }
            else
            {
                tbSearch.Clear();
                string category = cb_filterby.SelectedItem.ToString();
                TA_SItems.FilterFillBy(managementDS.S_Item, category);
            }
        }

        private void btnFilterClear_Click(object sender, EventArgs e)
        {
            cb_filterby.SelectedIndex = 0;
            if (tbSearch.Text == "")
            {
                TA_SItems.Fill(managementDS.S_Item);
            }
            else
            {
                TA_SItems.SearchFillBy(managementDS.S_Item, tbSearch.Text);
            }
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            if (tbDescription.Text.Equals(""))
            {
                lblInvalidDesc.Text = "Can't be empty";
                lblInvalidDesc.Visible = true;
                btnUpdate.Enabled = false;
            }
            else if(tbDescription.Text.Length > 50)
            {
                lblInvalidDesc.Text = "Too long";
                lblInvalidDesc.Visible = true;
                btnUpdate.Enabled = false;
            }
            else
            {
                lblInvalidDesc.Visible = false;
                btnUpdate.Enabled = true;
            }
        }

        private void tbItemDescription_TextChanged(object sender, EventArgs e)
        {
            if (tbItemDescription.Text.Equals(""))
            {
                lblInvalidDescrip.Text = "Can't be empty";
                lblInvalidDescrip.Visible = true;
                btnAddItem.Enabled = false;
            }
            else if (tbItemDescription.Text.Length > 50)
            {
                lblInvalidDescrip.Text = "Too long";
                lblInvalidDescrip.Visible = true;
                btnAddItem.Enabled = false;
            }
            else
            {
                lblInvalidDescrip.Visible = false;
                btnAddItem.Enabled = true;
            }
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {
            int workerID = 0;
            bool isNumber = int.TryParse(tbID.Text, out workerID);
            if (isNumber)
            {
                if (tbID.Text.Length > 4)
                {
                    lblInvalidWorkerID.Text = "Too long";
                    lblInvalidWorkerID.Visible = true;
                    btnWorkerUpdate.Enabled = false;
                }
                else
                {
                    lblInvalidWorkerID.Visible = false;
                    btnWorkerUpdate.Enabled = true;
                }
            }
            else
            {
                if (tbID.Text.Equals(""))
                {
                    lblInvalidWorkerID.Text = "Can't be blank";
                    lblInvalidWorkerID.Visible = true;
                    btnWorkerUpdate.Enabled = false;
                }
                else
                {
                    lblInvalidWorkerID.Text = "No letters";
                    lblInvalidWorkerID.Visible = true;
                    btnWorkerUpdate.Enabled = false;
                }
            }
        }

        private List<string> allId()
        {
            List<string> id = new List<string>();
            foreach (DataRow row in managementDS.S_CanteenWorker)
            {
                id.Add(row.ItemArray[0].ToString());
            }
            return id;
        }

        private void tbWorkerID_TextChanged(object sender, EventArgs e)
        {
            List<string> allIDs = allId();
            int workerID = 0;
            bool isNumber = int.TryParse(tbWorkerID.Text, out workerID);
            if (isNumber)
            {
                if (tbWorkerID.Text.Length > 4)
                {
                    lblNewIDInvalid.Text = "Too long";
                    lblNewIDInvalid.Visible = true;
                    btnAddNewWorker.Enabled = false;
                }
                else if (allIDs.IndexOf(tbWorkerID.Text) >= 0)
                {
                    lblNewIDInvalid.Text = "Already Taken";
                    lblNewIDInvalid.Visible = true;
                    btnAddNewWorker.Enabled = false;
                }
                else 
                {
                    lblNewIDInvalid.Visible = false;
                    btnAddNewWorker.Enabled = true;
                }
            }
            else
            {
                if (tbWorkerID.Text.Equals(""))
                {
                    lblNewIDInvalid.Text = "Can't be blank";
                    lblNewIDInvalid.Visible = true;
                    btnAddNewWorker.Enabled = false;
                }
                else
                {
                    lblNewIDInvalid.Text = "No letters";
                    lblNewIDInvalid.Visible = true;
                    btnAddNewWorker.Enabled = false;
                }
            }
        }

        private void tbWorkerFName_TextChanged(object sender, EventArgs e)
        {
            bool containsInt = tbWorkerFName.Text.Any(char.IsDigit);
            if (containsInt)
            {
                lblNewNameInvalid.Text = "No numbers";
                lblNewNameInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else if (tbWorkerFName.Text.Length > 20)
            {
                lblNewNameInvalid.Text = "Too long";
                lblNewNameInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else if (tbWorkerFName.Text.Equals(""))
            {
                lblNewNameInvalid.Text = "Can't be blank";
                lblNewNameInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else
            {
                lblNewNameInvalid.Visible = false;
                btnAddNewWorker.Enabled = true;
            }
        }

        private void tbWorkerLName_TextChanged(object sender, EventArgs e)
        {
            bool containsInt = tbWorkerLName.Text.Any(char.IsDigit);
            if (containsInt)
            {
                lblNewSurnameInvalid.Text = "No numbers";
                lblNewSurnameInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else if (tbWorkerLName.Text.Length > 20)
            {
                lblNewSurnameInvalid.Text = "Too long";
                lblNewSurnameInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else if (tbWorkerLName.Text.Equals(""))
            {
                lblNewSurnameInvalid.Text = "Can't be blank";
                lblNewSurnameInvalid.Visible = true;
                btnAddNewWorker.Enabled = false;
            }
            else
            {
                lblNewSurnameInvalid.Visible = false;
                btnAddNewWorker.Enabled = true;
            }
        }

        private void tbID_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbID, "- Length: 4 char\n- No letters\n- Cannot be blank");
        }

        private void tbFName_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbFName, "- Cannot exceed 20 characters\n- No numbers\n- Cannot be blank");
        }

        private void tbLName_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbLName, "- Cannot exceed 20 characters\n- No numbers\n- Cannot be blank");
        }

        private void tbPhoneNumber_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbPhoneNumber, "- Length: 10 numbers\n- Must start with '0'\n- No letters");
        }

        private void tbEmail_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbEmail, "- Cannot exceed 35 characters\n- Must contain '@' for mail server\n- Must contain at least 1 period\n - Must end with either '.com' or '.co.za' top-level domains");
        }

        private void tbWorkerID_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbWorkerID, "- Length: 4 char\n- No letters\n- Cannot be blank");
        }

        private void tbWorkerFName_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbWorkerFName, "- Cannot exceed 20 characters\n- No numbers\n- Cannot be blank");
        }

        private void tbWorkerLName_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbWorkerLName, "- Cannot exceed 20 characters\n- No numbers\n- Cannot be blank");
        }

        private void tbWorkerEmail_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbWorkerEmail, "- Cannot exceed 35 characters\n- Must contain '@' for mail server\n- Must contain at least 1 period\n - Must end with either '.com' or '.co.za' top-level domains");
        }

        private void tbWorkerPhNo_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbWorkerPhNo, "- Length: 10 numbers\n- Must start with '0'\n- No letters\n- Cannot be blank");
        }

        private void cb_employeeSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearchEmp.Clear();
        }

        private void cb_WorkerSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCanteenSearch.Clear();
        }

        private void tbItemName_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbItemName, "- Cannot exceed 30 characters\n- Cannot be blank\n- Must not already exist");
        }

        private void tbItemDescription_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbItemDescription, "- Cannot exceed 50 characters\n- Cannot be blank");
        }

        private void tbItemPrice_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbItemPrice, "-No negatives\n- Cannot be blank\n- Only numbers allowed");
        }

        private void tbItemQuantity_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbItemQuantity, "-No negatives\n- Cannot be blank\n- Only numbers allowed");
        }

        private void tbItemThreshold_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbItemThreshold, "-No negatives\n- Cannot be blank\n- Only numbers allowed");
        }

        private void tbName_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbName, "- Cannot exceed 30 characters\n- Cannot be blank\n- Must not already exist");
        }

        private void tbAvailability_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbAvailability, "- Can only be \"Available\" or \"Unavailable\"");
        }

        private void tbPrice_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbPrice, "-No negatives\n- Cannot be blank\n- Only numbers allowed");
        }

        private void tbQuantity_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbQuantity, "-No negatives\n- Cannot be blank\n- Only numbers allowed");
        }

        private void tbCategory_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbCategory, "- Can only be Cake, Savory, Pastry, Confectioney, Frozen or Drink");
        }

        private void tbThreshold_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbThreshold, "-No negatives\n- Cannot be blank\n- Only numbers allowed");
        }

        private void tbDescription_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbDescription, "- Cannot exceed 50 characters\n- Cannot be blank");
        }
    }
}
