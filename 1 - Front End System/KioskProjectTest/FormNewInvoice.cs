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
    public partial class FormNewInvoice : Form
    {
        public FormNewInvoice()
        {
            InitializeComponent();
        }

        private void FormNewInvoice_Load(object sender, EventArgs e)
        {
            //Fill in every order
            TA_SOrder.Fill(DS_Main.S_Order);
            //only getting the last one now
            int newOrderNo = Convert.ToInt32(DS_Main.S_Order.Rows[DS_Main.S_Order.Count - 1].ItemArray[0]);
            TA_SOrder.OrderNoFillBy(DS_Main.S_Order, newOrderNo);
            TA_SOrderItem.OrderNoFillBy(DS_Main.S_OrderItem, newOrderNo);
            TA_SItem.Fill(DS_Main.S_Item);
            TA_SEmployee.IDFillBy(DS_Main.S_Employee, Convert.ToInt32(DS_Main.S_Order.Rows[0].ItemArray[1]));

            CR_Receipt.SetDataSource(DS_Main);
        }
    }
}
