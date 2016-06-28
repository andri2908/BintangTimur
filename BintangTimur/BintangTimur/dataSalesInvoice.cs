using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace BintangTimur
{
    public partial class dataSalesInvoice : Form
    {
        private globalUtilities gUtil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");
        private int customerID = 0;

        private int originModuleID = 0;

        public dataSalesInvoice()
        {
            InitializeComponent();
        }

        public dataSalesInvoice(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void fillInCustomerCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1";

            customerCombo.Items.Clear();
            customerHiddenCombo.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        customerCombo.Items.Add(rdr.GetString("CUSTOMER_FULL_NAME"));
                        customerHiddenCombo.Items.Add(rdr.GetString("CUSTOMER_ID"));
                    }
                }
            }
        }

        private void loadInvoiceData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string dateFrom, dateTo;
            string noInvoiceParam = "";
            string whereClause1 = "";
            string sqlClause1 = "";
            string sqlClause2 = "";

            DS.mySqlConnect();

            if (originModuleID == globalConstants.SALES_QUOTATION)
            {
                sqlClause1  = "SELECT ID, SQ_INVOICE AS 'NO INVOICE', CUSTOMER_FULL_NAME AS 'CUSTOMER', DATE_FORMAT(SQ_DATE, '%d-%M-%Y')  AS 'TGL INVOICE', SQ_TOTAL AS 'TOTAL', SQ_APPROVED AS STATUS " +
                                       "FROM SALES_QUOTATION_HEADER SQ, MASTER_CUSTOMER MC " +
                                       "WHERE SQ.CUSTOMER_ID = MC.CUSTOMER_ID";

                sqlClause2 = "SELECT ID, SQ_INVOICE AS 'NO INVOICE', '' AS 'CUSTOMER', DATE_FORMAT(SQ_DATE, '%d-%M-%Y') AS 'TGL INVOICE', SQ_TOTAL AS 'TOTAL', SQ_APPROVED AS STATUS " +
                                       "FROM SALES_QUOTATION_HEADER SQ " +
                                       "WHERE SQ.CUSTOMER_ID = 0";
            }

            if (!showAllCheckBox.Checked)
            {
                if (noInvoiceTextBox.Text.Length > 0)
                {
                    noInvoiceParam = MySqlHelper.EscapeString(noInvoiceTextBox.Text);
                    whereClause1 = whereClause1 + " AND SQ.SQ_INVOICE LIKE '%" + noInvoiceParam + "%'";
                }

                dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_1.Value));
                dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_2.Value));
                whereClause1 = whereClause1 + " AND DATE_FORMAT(SQ.SQ_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(SQ.SQ_DATE, '%Y%m%d')  <= '" + dateTo + "'";

                if (customerID > 0)
                {
                    sqlCommand = sqlClause1 + whereClause1 + " AND AND SQ.CUSTOMER_ID = " + customerID;
                }
                else
                {
                    sqlCommand = sqlClause1 + whereClause1 + " UNION " + sqlClause2 + whereClause1;
                }
            }

            using (rdr = DS.getData(sqlCommand))
            {
                dataPenerimaanBarang.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataPenerimaanBarang.DataSource = dt;

                    dataPenerimaanBarang.Columns["ID"].Visible = false;

                    dataPenerimaanBarang.Columns["NO INVOICE"].Width = 200;
                    dataPenerimaanBarang.Columns["TGL INVOICE"].Width = 200;
                    dataPenerimaanBarang.Columns["CUSTOMER"].Width = 200;
                    dataPenerimaanBarang.Columns["TOTAL"].Width = 200;
                }

                rdr.Close();
            }
        }

        private void dataSalesInvoice_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            Button[] arrButton = new Button[2];

            PODtPicker_1.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            PODtPicker_2.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            fillInCustomerCombo();

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_SALES_QUOTATION, gUtil.getUserGroupID());

            if (userAccessOption == 1)
                newButton.Visible = true;
            else
                newButton.Visible = false;

            arrButton[0] = displayButton;
            arrButton[1] = newButton;
            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            loadInvoiceData();
        }

        private void customerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerID = Convert.ToInt32(customerHiddenCombo.Items[customerCombo.SelectedIndex].ToString());
        }

        private void displaySpecificForm(string noInvoice)
        {
            switch(originModuleID)
            {
                case globalConstants.SALES_QUOTATION:
                        cashierForm displayedForm = new cashierForm(globalConstants.EDIT_SALES_QUOTATION, noInvoice);
                        displayedForm.ShowDialog(this);
                    break;
                default:
                        cashierForm cashierFormDisplay= new cashierForm();
                        cashierFormDisplay.ShowDialog(this);
                    break;
            }
        }

        private void dataPenerimaanBarang_DoubleClick(object sender, EventArgs e)
        {
            string noInvoice = "";

            if (dataPenerimaanBarang.Rows.Count <= 0)
                return;

            int rowSelectedIndex = (dataPenerimaanBarang.SelectedCells[0].RowIndex);
            DataGridViewRow selectedRow = dataPenerimaanBarang.Rows[rowSelectedIndex];
            noInvoice = selectedRow.Cells["NO INVOICE"].Value.ToString();

            displaySpecificForm(noInvoice);
        }

        private void dataPenerimaanBarang_KeyDown(object sender, KeyEventArgs e)
        {
            string noInvoice = "";
            if (e.KeyCode == Keys.Enter)
            {
                int rowSelectedIndex = (dataPenerimaanBarang.SelectedCells[0].RowIndex);
                DataGridViewRow selectedRow = dataPenerimaanBarang.Rows[rowSelectedIndex];
                noInvoice = selectedRow.Cells["NO INVOICE"].Value.ToString();

                displaySpecificForm(noInvoice);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (originModuleID != 0)
            { 
                cashierForm displayedForm = new cashierForm(originModuleID, true);
                displayedForm.ShowDialog(this);
            }
            else
            {
                cashierForm cashierDisplayForm = new cashierForm();
                cashierDisplayForm.ShowDialog(this);
            }
        }
    }
}
