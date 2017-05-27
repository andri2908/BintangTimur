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

namespace AlphaSoft
{
    public partial class dataSalesPersonDetail : Form
    {
        private int originModuleID = 0;
        private int selectedUserID = 0;

        Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();

        public dataSalesPersonDetail()
        {
            InitializeComponent();
        }

        public dataSalesPersonDetail(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        public dataSalesPersonDetail(int moduleID, int salesPersonID)
        {
            InitializeComponent();
            selectedUserID = salesPersonID;
            originModuleID = moduleID;
        }

        private void loadDataSalesPerson()
        {
            string sqlCommand = "";
            MySqlDataReader rdr;

            sqlCommand = "SELECT * FROM MASTER_SALESPERSON WHERE ID = " + selectedUserID;

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        userNameTextBox.Text = rdr.GetString("SALES_PERSON_NAME");
                        userPhoneTextBox.Text = rdr.GetString("SALES_PERSON_PHONE");

                        if (rdr.GetInt32("SALES_PERSON_ACTIVE") == 0)
                            nonAktifCheckbox.Checked = true;
                    }
                }
            }

        }

        private void dataSalesPersonDetail_Load(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.EDIT_SALESPERSON)
            {
                loadDataSalesPerson();
            }
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string userName = userNameTextBox.Text.Trim();
            string userPhone = MySqlHelper.EscapeString(userPhoneTextBox.Text.Trim());
            byte userStatus = 0;

            if (nonAktifCheckbox.Checked)
                userStatus = 0;
            else
                userStatus = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_SALESPERSON:
                        sqlCommand = "INSERT INTO MASTER_SALESPERSON(SALES_PERSON_NAME, SALES_PERSON_PHONE, SALES_PERSON_ACTIVE) " +
                                            "VALUES ('" + userName + "', '" + userPhone + "', " + userStatus + ")";
                        break;
                    case globalConstants.EDIT_SALESPERSON:
                        sqlCommand = "UPDATE MASTER_SALESPERSON " +
                                            "SET SALES_PERSON_NAME = '" + userName + "', " +
                                            "SALES_PERSON_PHONE = '" + userPhone + "', " +
                                            "SALES_PERSON_ACTIVE = " + userStatus + " " +
                                            "WHERE ID = " + selectedUserID;
                        break;
                }

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        gutil.showDBOPError(ex, "ROLLBACK");
                    }
                }
                gutil.showDBOPError(e, "INSERT");
                result = false;
            }
            finally
            {
                DS.mySqlClose();
            }

            return result;
        }

        private bool dataValidated()
        {
            if (userNameTextBox.Text.Length <= 0)
            {
                errorLabel.Text = "NAMA TIDAK BOLEH KOSONG";
                return false;
            }

            return true;
        }

        private bool saveData()
        {
            bool result = false;

            if (dataValidated())
            {
                result = saveDataTransaction();
            }

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
                MessageBox.Show("SUCCESS");
            else
                MessageBox.Show("FAIL");
        }
    }
}
