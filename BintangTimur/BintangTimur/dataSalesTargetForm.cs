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
    public partial class dataSalesTargetForm : Form
    {
        string currentYear = "";
        int numericCurrentYear = 0;
        string currentMonth = "";
        int numericMonth = 0;

        private Data_Access DS = new Data_Access();

        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

        public dataSalesTargetForm()
        {
            InitializeComponent();
        }

        private void loadSalesTargetData(int currentYear, bool loadAll = true)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            int currentMonth = 0;
            int numRows = 0;

            // LOAD DATAGRID
            sqlCommand = "SELECT TARGET_MONTH, TARGET_YEAR AS TAHUN, SUBSTRING('JAN FEB MAR APR MAY JUN JUL AUG SEP OCT NOV DEC ', (TARGET_MONTH * 4) - 3, 3) AS BULAN, TARGET_AMOUNT AS TARGET FROM MASTER_SALES_TARGET WHERE TARGET_YEAR >= " + (currentYear - 10) + " AND TARGET_YEAR <= " + (currentYear + 10) + " ORDER BY TARGET_YEAR, TARGET_MONTH ASC";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataSalesTarget.DataSource = dt;
                    dataSalesTarget.Columns["TARGET_MONTH"].Visible = false;
                    dataSalesTarget.Columns["TAHUN"].Width = 100;
                    dataSalesTarget.Columns["BULAN"].Width = 100;
                    dataSalesTarget.Columns["TARGET"].Width = 200;
                }
            }

            if (!loadAll)
                return;

            // LOAD CURRENT MONTH DATA, IF ANY
            currentMonth = periodeBulanCombo.SelectedIndex + 1;
            sqlCommand = "SELECT COUNT(1) FROM MASTER_SALES_TARGET WHERE TARGET_YEAR = " + currentYear + " AND TARGET_MONTH = " + currentMonth;
            numRows = Convert.ToInt32(DS.getDataSingleValue(sqlCommand));

            if (numRows > 0)
            {
                sqlCommand = "SELECT IFNULL(TARGET_AMOUNT, 0) FROM MASTER_SALES_TARGET WHERE TARGET_YEAR = " + currentYear + " AND TARGET_MONTH = " + currentMonth;
                targetPenjualanTextBox.Text = DS.getDataSingleValue(sqlCommand).ToString();
            }
            else
                targetPenjualanTextBox.Text = "0";
        }

        private bool dataValidated()
        {
            return true;
        }

        private bool saveDataTransaction()
        {
            string sqlCommand = "";
            int numRows;
            bool result = false;
            MySqlException internalEX = null;
            int selectedMonth = 0;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // CHECK FOR CURRENT ENTRY
                sqlCommand = "SELECT COUNT(1) FROM MASTER_SALES_TARGET WHERE TARGET_YEAR = " + periodeTahunCombo.Text + " AND TARGET_MONTH = " + periodeBulanCombo.SelectedIndex + 1;
                numRows = Convert.ToInt32(DS.getDataSingleValue(sqlCommand));

                if (numRows > 0)
                {
                    // UPDATE DATA SALES TARGET
                    sqlCommand = "UPDATE MASTER_SALES_TARGET SET TARGET_AMOUNT = " + targetPenjualanTextBox.Text + " WHERE TARGET_YEAR = " + periodeTahunCombo.Text + " AND TARGET_MONTH = " + selectedMonth;
                }
                else
                {
                    // INSERT NEW DATA SALES TARGET
                    selectedMonth = periodeBulanCombo.SelectedIndex + 1;
                    sqlCommand = "INSERT INTO MASTER_SALES_TARGET (TARGET_MONTH, TARGET_YEAR, TARGET_AMOUNT) VALUES (" + selectedMonth + ", " + periodeTahunCombo.Text + ", " + targetPenjualanTextBox.Text + ")";
                }

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception EX)
            {
                result = false;
            }
            finally
            {
                DS.mySqlClose();
            }

            return result;
        }

        private bool saveData()
        {
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
        }

        private void dataSalesTargetForm_Load(object sender, EventArgs e)
        {
            currentYear = String.Format(culture, "{0:yyyy}", DateTime.Now); ;
            numericCurrentYear = Convert.ToInt32(currentYear);

            currentMonth = String.Format(culture, "{0:MM}", DateTime.Now); ;
            numericMonth = Convert.ToInt32(currentMonth);
            
                // FILL IN YEAR COMBO
            periodeTahunCombo.Items.Clear();
            for (int i = numericCurrentYear - 10; i<=numericCurrentYear+10;i++)
            {
                periodeTahunCombo.Items.Add(i.ToString());
            }
            periodeTahunCombo.SelectedIndex = 10;
            periodeTahunCombo.Text = currentYear;

            // FILL IN MONTH COMBO
            periodeBulanCombo.SelectedIndex = numericMonth-1;
            periodeBulanCombo.Text = periodeBulanCombo.Items[periodeBulanCombo.SelectedIndex].ToString();

            loadSalesTargetData(numericCurrentYear);

            gutil.reArrangeTabOrder(this);
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            saveData();
            MessageBox.Show("DONE");
            loadSalesTargetData(Convert.ToInt32(periodeTahunCombo.Text), false);
        }

        private void dataSalesTarget_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataSalesTarget_DoubleClick(object sender, EventArgs e)
        {
            int selectedMonth = 0;
            string selectedYear = "";
            string selectedAmount = "";

            if (dataSalesTarget.Rows.Count <= 0)
                return;

            int rowSelectedIndex = (dataSalesTarget.SelectedCells[0].RowIndex);
            DataGridViewRow selectedRow = dataSalesTarget.Rows[rowSelectedIndex];
            selectedMonth = Convert.ToInt32(selectedRow.Cells["TARGET_MONTH"].Value.ToString());
            selectedYear = selectedRow.Cells["TAHUN"].Value.ToString();
            selectedAmount = selectedRow.Cells["TARGET"].Value.ToString();

            periodeBulanCombo.SelectedIndex = selectedMonth - 1;
            periodeBulanCombo.Text = periodeBulanCombo.Items[selectedMonth - 1].ToString();

            periodeTahunCombo.Text = selectedYear;

            targetPenjualanTextBox.Text = selectedAmount;
        }

        private void dataSalesTarget_KeyDown(object sender, KeyEventArgs e)
        {
            int selectedMonth = 0;
            string selectedYear = "";
            string selectedAmount = "";

            if (e.KeyCode == Keys.Enter)
            {
                if (dataSalesTarget.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = (dataSalesTarget.SelectedCells[0].RowIndex);
                DataGridViewRow selectedRow = dataSalesTarget.Rows[rowSelectedIndex];
                selectedMonth = Convert.ToInt32(selectedRow.Cells["TARGET_MONTH"].Value.ToString());
                selectedYear = selectedRow.Cells["TAHUN"].Value.ToString();
                selectedAmount = selectedRow.Cells["TARGET"].Value.ToString();

                periodeBulanCombo.SelectedIndex = selectedMonth - 1;
                periodeBulanCombo.Text = periodeBulanCombo.Items[selectedMonth - 1].ToString();

                periodeTahunCombo.Text = selectedYear;

                targetPenjualanTextBox.Text = selectedAmount;
            }
        }
    }
}
