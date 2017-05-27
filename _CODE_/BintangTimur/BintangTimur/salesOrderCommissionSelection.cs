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

namespace AlphaSoft
{
    public partial class salesOrderCommissionSelection : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

        private string startDate= "";
        private string endDate = "";
        private DateTime startDateValue;
        private DateTime endDateValue;
        private int selectedUserID = 0; 

        public salesOrderCommissionSelection()
        {
            InitializeComponent();
        }

        public void loadDataSales()
        {
            string sqlCommand = "";
            string sqlCommand1 = "";
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DataGridViewCheckBoxColumn selectiveCheckBoxColumn = new DataGridViewCheckBoxColumn();

            //GET ALL UNPAID TRANSACTION WITHIN THAT PERIOD
            sqlCommand = "SELECT SH.INCLUDE_IN_COMMISSION, SH.SALES_INVOICE AS 'SALES INVOICE', SH.SALES_DATE AS TANGGAL, IFNULL(MC.CUSTOMER_FULL_NAME, 'P-UMUM') AS PELANGGAN, IFNULL(SH.SALES_TOTAL, 0) - IFNULL(SH.SALES_DISCOUNT_FINAL, 0) AS 'TOTAL SALES', IFNULL(TAB1.PAY_AMOUNT, 0) AS 'TOTAL PEMBAYARAN' " +
                                                   "FROM SALES_HEADER SH LEFT OUTER JOIN MASTER_CUSTOMER MC ON SH.CUSTOMER_ID = MC.CUSTOMER_ID, SALES_QUOTATION_HEADER SQH, " +
                                                   "CREDIT LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) PAY_AMOUNT FROM PAYMENT_CREDIT GROUP BY CREDIT_ID) TAB1 ON TAB1.CREDIT_ID = CREDIT.CREDIT_ID " +
                                                   "WHERE SH.SALES_PAID = 0 AND SH.SQ_INVOICE = SQH.SQ_INVOICE AND SQH.SALESPERSON_ID = " + selectedUserID + " AND SH.SALES_VOID = 0 AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  >= '" + startDate + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  <= '" + endDate + "' AND SH.SALES_INVOICE = CREDIT.SALES_INVOICE" ;

            // GET ALL FULLY PAID TRANSACTION WITHIN THAT PERIOD THAT EXCEED TOP DATE
            sqlCommand1 = "SELECT SH.INCLUDE_IN_COMMISSION, SH.SALES_INVOICE AS 'SALES INVOICE', SH.SALES_DATE AS TANGGAL, IFNULL(MC.CUSTOMER_FULL_NAME, 'P-UMUM') AS PELANGGAN, IFNULL(SH.SALES_TOTAL,0) - IFNULL(SH.SALES_DISCOUNT_FINAL, 0) AS 'TOTAL SALES', IFNULL(SH.SALES_TOTAL,0) - IFNULL(SH.SALES_DISCOUNT_FINAL, 0) AS 'TOTAL PEMBAYARAN' " +
                                               "FROM SALES_HEADER SH LEFT OUTER JOIN MASTER_CUSTOMER MC ON SH.CUSTOMER_ID = MC.CUSTOMER_ID, " +
                                               "SALES_QUOTATION_HEADER SQH, " +
                                               "(SELECT C.SALES_INVOICE, C.CREDIT_ID, MAX(PC.PAYMENT_CONFIRMED_DATE) AS LAST_PAYMENT " +
                                                "FROM CREDIT C, PAYMENT_CREDIT PC " +
                                                "WHERE C.CREDIT_PAID = 1 AND PC.CREDIT_ID = C.CREDIT_ID) TAB1 " +
                                                "WHERE SH.SALES_ACTIVE = 1 AND SH.SALES_TOP = 0 AND SH.SALES_PAID = 1 AND SH.SALES_INVOICE = TAB1.SALES_INVOICE AND SH.SALES_VOID = 0 AND TAB1.LAST_PAYMENT > SH.SALES_TOP_DATE " +
                                                "AND SH.SQ_INVOICE = SQH.SQ_INVOICE AND SQH.SALESPERSON_ID = " + selectedUserID + " " +
                                                "AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  >= '" + startDate + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  <= '" + endDate + "'";

            sqlCommand = sqlCommand + " UNION " + sqlCommand1;

            selectiveCheckBoxColumn.Name = "status";
            selectiveCheckBoxColumn.HeaderText = "";
            detailGridView.Columns.Add(selectiveCheckBoxColumn);

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    detailGridView.DataSource = null;
                    dt.Load(rdr);
                    detailGridView.DataSource = dt;

                    detailGridView.Columns["INCLUDE_IN_COMMISSION"].Visible = false;
                    detailGridView.Columns["INCLUDE_IN_COMMISSION"].ReadOnly= true;
                    detailGridView.Columns["SALES INVOICE"].ReadOnly = true;
                    detailGridView.Columns["TANGGAL"].ReadOnly = true;
                    detailGridView.Columns["PELANGGAN"].ReadOnly = true;
                    detailGridView.Columns["TOTAL SALES"].ReadOnly = true;
                    detailGridView.Columns["TOTAL PEMBAYARAN"].ReadOnly = true;

                    for (int i = 0; i < detailGridView.Rows.Count; i++)
                    {
                        if (detailGridView.Rows[i].Cells["INCLUDE_IN_COMMISSION"].Value.ToString() == "1")
                            detailGridView.Rows[i].Cells["status"].Value = true;
                    }
                }
            }
        }

        public salesOrderCommissionSelection(DateTime dateStart, DateTime dateEnd, int userID)
        {
            InitializeComponent();

            startDate = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(dateStart));
            endDate = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(dateEnd));

            startDateValue = dateStart;
            endDateValue = dateEnd;

            selectedUserID = userID;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            string salesInvoice = "";
            MySqlException internalEX = null;

            DS.beginTransaction();

            try
            {
                for (int i = 0;i<detailGridView.Rows.Count;i++)
                {
                    salesInvoice = detailGridView.Rows[i].Cells["SALES INVOICE"].Value.ToString();

                    if (Convert.ToBoolean(detailGridView.Rows[i].Cells["status"].Value) == true)
                        sqlCommand = "UPDATE SALES_HEADER SET INCLUDE_IN_COMMISSION = 1 WHERE SALES_INVOICE = '" + salesInvoice + "' AND SALES_VOID = 0";
                    else
                        sqlCommand = "UPDATE SALES_HEADER SET INCLUDE_IN_COMMISSION = 0 WHERE SALES_INVOICE = '" + salesInvoice + "' AND SALES_VOID = 0";

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                DS.commit();
                result = true;
            }
            catch(Exception ex)
            {
                gUtil.saveSystemDebugLog(0, "[COMMISSION] FAILED TO UPDATE FLAG AT SALES_HEADER [" + ex.Message + "]");
            }

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveDataTransaction())
            { 
                MessageBox.Show("SUCCESS");
                this.Close();
            }
            else
                MessageBox.Show("FAIL");
        }

        private void salesOrderCommissionSelection_Load(object sender, EventArgs e)
        {
            PODtPicker_1.Value = startDateValue;
            PODtPicker_2.Value = endDateValue;

            deskripsiTextBox.Text = DS.getDataSingleValue("SELECT SALES_PERSON_NAME FROM MASTER_SALESPERSON WHERE ID = " + selectedUserID).ToString();

            loadDataSales();

            errorLabel.Text = "";
        }
    }
}
