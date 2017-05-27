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
    public partial class dataSalesPerson : Form
    {
        private int originModuleID = 0;
        private int selectedUserID = 0;

        Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();

        public dataSalesPerson()
        {
            InitializeComponent();
        }

        private void loadUserData(string userNameParam)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string userName = "";

            userName = MySqlHelper.EscapeString(userNameParam);

            DS.mySqlConnect();

            sqlCommand = "SELECT ID, SALES_PERSON_NAME AS 'NAMA', SALES_PERSON_PHONE AS 'TELEPON' FROM MASTER_SALESPERSON WHERE SALES_PERSON_NAME LIKE '%" + userNameParam + "%'";

            if (usernonactiveoption.Checked == false)
            {
                sqlCommand = sqlCommand + " AND SALES_PERSON_ACTIVE = 1";
            }

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataUserGridView.DataSource = dt;

                    dataUserGridView.Columns["ID"].Visible = false;
                }
            }
        }

        private void namaUserTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);
        }

        private void displaySpecificForm()
        {
            switch (originModuleID)
            {
                default:
                    gutil.saveSystemDebugLog(0, "CREATE DATA SALES_PERSON FORM, UID [" + selectedUserID + "]");
                    dataSalesPersonDetail displayForm = new dataSalesPersonDetail(globalConstants.EDIT_SALESPERSON, selectedUserID);
                    displayForm.ShowDialog(this);
                    break;
            }
        }

        private void dataUserGridView_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dataUserGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataUserGridView.Rows[selectedrowindex];
            selectedUserID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            displaySpecificForm();
        }

        private void dataUserGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int selectedrowindex = dataUserGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataUserGridView.Rows[selectedrowindex];
                selectedUserID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                displaySpecificForm();
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dataSalesPersonDetail displayForm = new dataSalesPersonDetail(globalConstants.NEW_SALESPERSON);
            displayForm.ShowDialog(this);
        }
    }
}
