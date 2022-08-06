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
    public partial class FormLogin : Form
    {
        private DSMain loginDS;
        private DSLogging loggedIn;
        private Button menuButton;
        private Button reviewButton;
        private Button balancesButton;
        private Button managementButton;
        private Button canteenWorkerButton;
        private Button help;
        private Button loginButton;
        private MainMenu mainMenuForm;

        public FormLogin(DSMain main, DSLogging loggedIn, MainMenu mainMenu,Button menuButton, Button reviewButton, Button balancesButton, Button managementButton, Button canteenWorkerButton, Button help, Button loginButton)
        {
            InitializeComponent();
            loginDS = main;
            this.loggedIn = loggedIn;
            this.menuButton = menuButton;
            this.reviewButton = reviewButton;
            this.balancesButton = balancesButton;
            this.managementButton = managementButton;
            this.canteenWorkerButton = canteenWorkerButton;
            this.help = help;
            this.loginButton = loginButton;
            this.mainMenuForm = mainMenu;   
        }

        public void FormLogin_Load(object sender, EventArgs e)
        {
            LoadTheme();
            mainMenuForm.Size = new Size(235 + this.Width, 120 + this.Height);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUserID.Clear();
            tbPassword.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TA_SLoggedInEmployee.LoginFillBy(loggedIn.S_LoggedInEmployee, int.Parse(tbUserID.Text), tbPassword.Text);
            TA_SLoggedInCanteenWorker.LoginFillBy(loggedIn.S_LoggedInCanteenWorker, int.Parse(tbUserID.Text), tbPassword.Text);
            if (loggedIn.S_LoggedInEmployee.Rows.Count > 0)
            {
                DataRow loggedInEmployee = loggedIn.S_LoggedInEmployee.Rows[0];
                btnLogin.Visible = false;
                btnShow.Visible = false;
                btnClear.Visible = false;
                btnLogout.Visible = true;
                lblLoggedInAs.Visible = true;
                loginButton.Text = "              Logout";

                if (loggedInEmployee.ItemArray[6].ToString() == "Manager")
                {
                    lblLoggedInAs.Text = "Logged in as: " + loggedInEmployee.ItemArray[2].ToString() + " " + loggedInEmployee.ItemArray[3].ToString() + " [Manager]";
                    MessageBox.Show("Greetings, " + loggedInEmployee.ItemArray[2].ToString() + " " + loggedInEmployee.ItemArray[3].ToString());
                    //activation order?
                    managementButton.Visible = true;
                    balancesButton.Visible = true;
                    //reviewButton.Visible = true;
                    menuButton.Visible = true;
                    tbUserID.Clear();
                    tbUserID.ReadOnly = true;
                    tbPassword.Clear();
                    tbPassword.ReadOnly = true;
                    //trying to get the menu to show up
                    mainMenuForm.btnManagement_Click(managementButton, e);
                }
                else
                {
                    lblLoggedInAs.Text = "Logged in as: " + loggedInEmployee.ItemArray[2].ToString() + " " + loggedInEmployee.ItemArray[3].ToString();
                    MessageBox.Show("Greetings, " + loggedInEmployee.ItemArray[2].ToString() + " " + loggedInEmployee.ItemArray[3].ToString());
                    balancesButton.Visible = true;
                    //reviewButton.Visible = true;
                    menuButton.Visible = true;
                    tbUserID.Clear();
                    tbUserID.ReadOnly = true;
                    tbPassword.Clear();
                    tbPassword.ReadOnly = true;
                    help.Visible = true;
                    mainMenuForm.btnItems_Click(menuButton, e);
                }
            } else if (loggedIn.S_LoggedInCanteenWorker.Rows.Count > 0)
            {
                DataRow loggedInCanteenWorker = loggedIn.S_LoggedInCanteenWorker.Rows[0];
                btnLogin.Visible = false;
                btnShow.Visible = false;
                btnClear.Visible = false;
                btnLogout.Visible = true;
                lblLoggedInAs.Visible = true;
                loginButton.Text = "              Logout";
                lblLoggedInAs.Text = "Logged in as : " + loggedInCanteenWorker.ItemArray[2].ToString() + " " + loggedInCanteenWorker.ItemArray[3].ToString() + " [Canteen Worker]";
                MessageBox.Show("Greetings, " + loggedInCanteenWorker.ItemArray[2].ToString() + " " + loggedInCanteenWorker.ItemArray[3].ToString());
                canteenWorkerButton.Visible = true;
                tbUserID.Clear();
                tbUserID.ReadOnly = true;
                tbPassword.Clear();
                tbPassword.ReadOnly = true;
                mainMenuForm.btnCanteenStaff_Click(canteenWorkerButton, e);
            } else
            {
                MessageBox.Show("Unsuccesful Login");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            loggedIn.S_LoggedInEmployee.Rows.Clear();
            loggedIn.S_LoggedInCanteenWorker.Rows.Clear();
            MessageBox.Show("Have a great day!");
            btnLogin.Visible = true;
            btnShow.Visible = true;
            btnClear.Visible = true;
            btnLogout.Visible = false;
            lblLoggedInAs.Visible = false;
            menuButton.Visible = false;
            reviewButton.Visible = false;
            balancesButton.Visible = false;
            managementButton.Visible = false;
            canteenWorkerButton.Visible = false;
            tbUserID.ReadOnly = false;
            tbPassword.ReadOnly = false;
            loginButton.Text = "              Login";
        }

        private void btnShow_MouseDown(object sender, MouseEventArgs e)
        {
            tbPassword.UseSystemPasswordChar = false;
        }

        private void btnShow_MouseUp(object sender, MouseEventArgs e)
        {
            tbPassword.UseSystemPasswordChar = true;
        }
    }
}
