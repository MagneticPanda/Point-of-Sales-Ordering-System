using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskProjectTest
{
    public partial class MainMenu : Form
    {

        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        public static Form activeForm;
        private KioskProjectTest.Forms.FormLogin loginForm;
        public static KioskProjectTest.Forms.FormMenu menuForm;
        private KioskProjectTest.Forms.FormCart cartForm;
        private KioskProjectTest.Forms.FormCanteenWorker canteenForm;
        private KioskProjectTest.Forms.FormManagement managementForm;
        private KioskProjectTest.Forms.FormEmpBalances balancesForm;
        private KioskProjectTest.Forms.FormNewInvoice newInvoiceForm;
        private KioskProjectTest.Forms.FormHelp helpForm;

        //Constructor
        public MainMenu()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;

            loginForm = new KioskProjectTest.Forms.FormLogin(this.DSMain, this.DSLogging, this, this.btnItems, this.btnCart, this.btnBalances, this.btnManagement, this.btnCanteenStaff, this.btnQnA, this.btnMainLogin);
            menuForm = new KioskProjectTest.Forms.FormMenu(ref this.DSMain, this.DSLogging, this.btnViewReceipt, this);
            cartForm = new KioskProjectTest.Forms.FormCart(this.DSMain, this.DSLogging);
            canteenForm = new KioskProjectTest.Forms.FormCanteenWorker(this.DSMain, this.DSLogging, this);
            managementForm = new KioskProjectTest.Forms.FormManagement(this.DSMain, this.DSLogging, this);
            balancesForm = new KioskProjectTest.Forms.FormEmpBalances(this.DSMain, this.DSLogging, this);
            helpForm = new KioskProjectTest.Forms.FormHelp();

            
        }

        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            //if the color has already been selected, we select again to choose a different one
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        /*
         * We higlight the button that has been clicked (Active form):
           1. We select a random color for the theme (Optional you can use a single color to highlight the button)
           2. We change the background color of the button
           3. We change the font color of the button
           4. We change the font size of the button
        */
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if(currentButton!= (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor= ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = false;
                }
            }
        }

        //Sets the button controls back to default appearance
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //Method to open the forms in the container panel
        public void OpenChildForm(Form childForm, object btnSender)
        {
            /*
            
            if (activeForm!= null)
            {
                activeForm.Close();
            }
            */
            if (childForm == loginForm)
            {
                this.Width = (805 + 235);
                this.Height = (836 + 120);
                loginForm.LoadTheme();
            }
            else if (childForm == managementForm)
            {
                this.Width = (235 + 1371); 
                this.Height = (120 + 896);
                managementForm.LoadTheme();
            }
            else if (childForm == menuForm)
            {
                this.Width = (235 + 1233);
                this.Height = (120 + 1031);
                menuForm.LoadTheme();
            }
            else if (childForm == balancesForm)
            {
                this.Width = (235 + 1004);
                this.Height = (120 + 937);
                balancesForm.LoadTheme();
            }
            else if (childForm == canteenForm)
            {
                //1161, 811
                this.Width = (235 + 1161); 
                this.Height = (120 + 811);
                canteenForm.LoadTheme();
            }
            else if (childForm == helpForm)
            {
                this.Width = (235 + 1225);
                this.Height = (120 + 957);
            }

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show(); //makes visible = true;
            lblTitle.Text = childForm.Text;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenChildForm(loginForm, sender);
        }

        public void btnItems_Click(object sender, EventArgs e)
        {
            OpenChildForm(menuForm, sender);
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            OpenChildForm(cartForm, sender);
        }

        public void btnCanteenStaff_Click(object sender, EventArgs e)
        {
            OpenChildForm(canteenForm, sender);
        }

        public void btnManagement_Click(object sender, EventArgs e)
        {
            OpenChildForm(managementForm, sender);
        }

        private void btnBalances_Click(object sender, EventArgs e)
        {
            OpenChildForm(balancesForm, sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            /*
            if (activeForm!=null)
            {
                activeForm.Close();
            }
            */
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(111, 191, 61);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        public void btnViewReceipt_Click(object sender, EventArgs e)
        {
            newInvoiceForm = new Forms.FormNewInvoice();
            newInvoiceForm.ShowDialog();
            //OpenChildForm(newInvoiceForm, sender);
        }

        private void btnQnA_Click(object sender, EventArgs e)
        {
            OpenChildForm(helpForm, sender);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            btnLogin_Click(btnMainLogin, e);
        }
    }
}
