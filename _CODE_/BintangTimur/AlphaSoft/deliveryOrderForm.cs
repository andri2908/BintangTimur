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
    public partial class deliveryOrderForm : Form
    {
        private string selectedSalesInvoice = "";
        private string salesRevNo = "";
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");
        private globalUtilities gUtil = new globalUtilities();
        private bool isPreOrderSales = false;

        public deliveryOrderForm()
        {
            InitializeComponent();
        }

        public deliveryOrderForm(string invoiceNo, string revNo)
        {
            InitializeComponent();

            selectedSalesInvoice = invoiceNo;
            salesRevNo = revNo;
        }


        private void loadInvoiceData()
        {
            string sqlCommand;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            DataGridViewTextBoxColumn qtyColumn = new DataGridViewTextBoxColumn();

            // LOAD DATA HEADER
            sqlCommand = "SELECT SH.IS_PREORDER, SH.SALES_INVOICE, IFNULL(MC.CUSTOMER_FULL_NAME, '') AS CUSTOMER_NAME FROM SALES_HEADER SH LEFT OUTER JOIN MASTER_CUSTOMER MC ON (SH.CUSTOMER_ID = MC.CUSTOMER_ID) WHERE SH.SALES_INVOICE = '" + selectedSalesInvoice + "' AND SH.REV_NO = " + salesRevNo;

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        noInvoiceTextBox.Text = rdr.GetString("SALES_INVOICE");
                        customerNameTextBox.Text = rdr.GetString("CUSTOMER_NAME");
                        
                        if (rdr.GetInt32("IS_PREORDER") == 1)
                            isPreOrderSales = true;
                    }
                }
            }
            rdr.Close();

            // LOAD DATA DETAIL
            sqlCommand = "SELECT SD.ID, SD.PRODUCT_ID, SD.IS_COMPLETED, IF(SD.IS_COMPLETED = 1, 'COMPLETED', 'PENDING') AS STATUS, MP.PRODUCT_NAME AS 'NAMA PRODUK', SD.PRODUCT_QTY AS 'ORDER QTY', IFNULL(TAB1.QTY, 0) AS 'DELIVERED QTY' " +
                                    "FROM SALES_DETAIL SD LEFT OUTER JOIN " +
                                    "(SELECT DH.SALES_INVOICE, DH.REV_NO, DD.PRODUCT_ID, SUM(DD.PRODUCT_QTY) AS QTY FROM DELIVERY_ORDER_HEADER DH, DELIVERY_ORDER_DETAIL DD WHERE DD.DO_ID = DH.DO_ID AND DH.SALES_INVOICE = '" + selectedSalesInvoice + "' AND DH.REV_NO = " + salesRevNo + " GROUP BY DD.PRODUCT_ID) TAB1 ON (TAB1.PRODUCT_ID = SD.PRODUCT_ID) " +
                                    ", MASTER_PRODUCT MP " +
                                    "WHERE SD.PRODUCT_ID = MP.PRODUCT_ID AND SD.SALES_INVOICE = '" + selectedSalesInvoice + "' AND SD.REV_NO = " + salesRevNo;

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    detailGridView.DataSource = dt;

                    detailGridView.Columns["ID"].Visible = false;
                    detailGridView.Columns["PRODUCT_ID"].Visible = false;
                    detailGridView.Columns["IS_COMPLETED"].Visible = false;

                    detailGridView.Columns["NAMA PRODUK"].Width = 200;
                    detailGridView.Columns["NAMA PRODUK"].ReadOnly = true;

                    detailGridView.Columns["ORDER QTY"].Width = 200;
                    detailGridView.Columns["ORDER QTY"].ReadOnly = true;

                    detailGridView.Columns["DELIVERED QTY"].Width = 200;
                    detailGridView.Columns["DELIVERED QTY"].ReadOnly = true;

                    qtyColumn.Name = "qty";
                    qtyColumn.HeaderText = "QTY";
                    qtyColumn.Width = 200;
                    detailGridView.Columns.Add(qtyColumn);

                    for (int i = 0; i < detailGridView.Rows.Count; i++)
                    {
                        if (detailGridView.Rows[i].Cells["IS_COMPLETED"].Value.ToString().Equals("1"))
                            detailGridView.Rows[i].Cells["QTY"].ReadOnly = true;
                        else
                            detailGridView.Rows[i].Cells["QTY"].Style.BackColor = Color.LightBlue;

                        detailGridView.Rows[i].Cells["QTY"].Value = 0;
                    }

                }
            }
            rdr.Close();

        }

        private void deliveryOrderForm_Load(object sender, EventArgs e)
        {
            Button[] arrButton = new Button[2];

            DODtPicker.Format = DateTimePickerFormat.Custom;
            DODtPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            errorLabel.Text = "";

            loadInvoiceData();

            arrButton[0] = saveButton;
            arrButton[1] = reprintButton;

            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);
        }

        private bool dataValidated()
        {
            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;
            string productID = "";
            double orderQty = 0;
            double deliveredQty = 0;
            double qty = 0;
            int fullfilledItem = 0;
            int status = 0;
            int lineItemID = 0;
            int locationID = gUtil.loadlocationID(2);

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // INSERT DATA HEADER
                sqlCommand = "INSERT INTO DELIVERY_ORDER_HEADER (DO_ID, SALES_INVOICE, REV_NO, DO_DATE) VALUES ('" + noInvoiceTextBox.Text + "', '" + selectedSalesInvoice + "', " + salesRevNo + ", STR_TO_DATE('" + DODtPicker.Value + "', '%d-%m-%Y'))";
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                // INSERT DATA DETAIL
                for (int i =0;i<detailGridView.Rows.Count;i++)
                {
                    productID = detailGridView.Rows[i].Cells["PRODUCT_ID"].Value.ToString();
                    orderQty = Convert.ToDouble(detailGridView.Rows[i].Cells["ORDER QTY"].Value);
                    deliveredQty = Convert.ToDouble(detailGridView.Rows[i].Cells["DELIVERED QTY"].Value);
                    qty = Convert.ToDouble(detailGridView.Rows[i].Cells["QTY"].Value);
                    status = Convert.ToInt32(detailGridView.Rows[i].Cells["IS_COMPLETED"].Value);
                    lineItemID = Convert.ToInt32(detailGridView.Rows[i].Cells["ID"].Value);

                    if (status == 0 && qty > 0)
                    {
                        // INSERT INTO DETAIL
                        sqlCommand = "INSERT INTO DELIVERY_ORDER_DETAIL (DO_ID, PRODUCT_ID, PRODUCT_QTY) VALUES ('" + noInvoiceTextBox.Text + "', '" + productID + "', " + qty + ")";
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // REDUCE STOCK
                        if (!gUtil.productIsService(productID))
                        {
                            // REDUCE STOCK AT MASTER STOCK
                            sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY - " + qty + " WHERE PRODUCT_ID = '" + productID + "'";
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            // REDUCE STOCK AT PRODUCT LOCATION
                            sqlCommand = "UPDATE PRODUCT_LOCATION SET PRODUCT_LOCATION_QTY = PRODUCT_LOCATION_QTY - " + qty + " WHERE PRODUCT_ID = '" + productID + "' AND LOCATION_ID = " + locationID;
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }

                        if (orderQty <= deliveredQty + qty)
                        {
                            // ORDER FULFILLED
                            fullfilledItem++;

                            sqlCommand = "UPDATE SALES_DETAIL SET IS_COMPLETED = 1 WHERE SALES_INVOICE = '" + selectedSalesInvoice + "' AND REV_NO = " + salesRevNo + " AND PRODUCT_QTY = " + orderQty + " AND ID = " + lineItemID;
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }
                    }
                    else if (status == 1)
                        fullfilledItem++;
                }


                if (fullfilledItem == detailGridView.Rows.Count - 1)
                {
                    // WHOLE ORDER COMPLETED
                    // UPDATE SALES HEADER SET SALES ACTIVE TO 0
                    sqlCommand = "UPDATE SALES_HEADER SET SALES_ACTIVE = 0 WHERE SALES_INVOICE = '" + selectedSalesInvoice + "' AND REV_NO = '" + salesRevNo + "'";
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                DS.commit();
                result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        private bool saveData()
        {
            if (dataValidated())
                return saveDataTransaction();

            return false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                MessageBox.Show("SUCCESS");

                gUtil.setReadOnlyAllControls(this);
                reprintButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("FAIL");
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {

        }
    }
}
