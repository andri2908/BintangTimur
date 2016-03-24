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

using System.Text.RegularExpressions;

namespace RoyalPetz_ADMIN
{
    public partial class dataProdukDetailForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();

        private int originModuleID = 0;
        private int selectedInternalProductID = 0;
        private string selectedProductID = "";
        private int selectedUnitID;
        private string photoFileName = "";
        private List<int> currentSelectedKategoriID = new List<int>();
        private List<string> detailQty = new List<string>();
        private bool isLoading = false;
        private string previousInput = "";
        
        private string stokAwalText = "";
        private string limitStokText = "";
        private string hppValueText = "";
        private string hargaEcerValueText = "";
        private string hargaPartaiText = "";
        private string hargaGrosirValueText = "";
        private string selectedPhoto = "";
        private int options = 0;
        private stokPecahBarangForm parentForm;
        
        public dataProdukDetailForm()
        {
            InitializeComponent();
        }

        public dataProdukDetailForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
        }

        public dataProdukDetailForm(int moduleID, stokPecahBarangForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentForm = thisParentForm;
        }

        private void calculateTotal()
        {
            double totalQty = 0;

            //for (int i = 0; i < detailLokasiDataGridView.Rows.Count; i++)
            //{
            //    totalQty = totalQty + Convert.ToDouble(detailLokasiDataGridView.Rows[i].Cells["locationQty"].Value);
            //}
            for (int i = 0; i < detailQty.Count; i++)
                totalQty = totalQty + Convert.ToDouble(detailQty[i]);

            stokAwalTextBox.Text = totalQty.ToString();
        }

        private void detailLokasiDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((detailLokasiDataGridView.CurrentCell.ColumnIndex == 2)
                && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
           
            if (isLoading)
                return;

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            rowSelectedIndex = detailLokasiDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailLokasiDataGridView.Rows[rowSelectedIndex];

            previousInput = "";
            if (detailQty.Count < rowSelectedIndex + 1)
            {
                if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (dataGridViewTextBoxEditingControl.Text.Length > 0))
                {
                    detailQty.Add(dataGridViewTextBoxEditingControl.Text);
                }
                else
                {
                    dataGridViewTextBoxEditingControl.Text = previousInput;
                }
            }
            else
            {
                if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (dataGridViewTextBoxEditingControl.Text.Length > 0))
                {
                    detailQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                }
                else
                {
                    dataGridViewTextBoxEditingControl.Text = detailQty[rowSelectedIndex];
                }
            }

            try
            {
                calculateTotal();
            }
            catch (Exception ex)
            {
                //dataGridViewTextBoxEditingControl.Text = previousInput;
            }
        }

        public void setSelectedUnitID(int unitID)
        {
            selectedUnitID = unitID;
        }

        public void addSelectedKategoriID(int kategoriID)
        {
            bool exist = false;
            for (int i = 0; ((i<currentSelectedKategoriID.Count) && (exist == false));i++)
            {
                if (currentSelectedKategoriID[i] == kategoriID)
                    exist = true;
            }

            if (!exist)
                currentSelectedKategoriID.Add(kategoriID);
        }

        private bool checkRegEx(string textToCheck)
        {
            if (gUtil.matchRegEx(textToCheck, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
                return true;

            return false;            
        }

        public dataProdukDetailForm(int moduleID, int productID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedInternalProductID = productID;
        }

        private void stokAwalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (checkRegEx(stokAwalTextBox.Text))
                stokAwalText = stokAwalTextBox.Text;
            else
                stokAwalTextBox.Text = stokAwalText;
        }

        private void limitStokTextBox_TextChanged(object sender, EventArgs e)
        {
            if (checkRegEx(limitStokTextBox.Text))
                limitStokText = limitStokTextBox.Text;
            else
                limitStokTextBox.Text = limitStokText;
        }

        private void hppTextBox_TextChanged(object sender, EventArgs e)
        {
            if (checkRegEx(hppTextBox.Text))
                hppValueText = hppTextBox.Text;
            else
                hppTextBox.Text = hppValueText;
        }

        private void hargaEcerTextBox_TextChanged(object sender, EventArgs e)
        {
            if (checkRegEx(hargaEcerTextBox.Text))
                hargaEcerValueText = hargaEcerTextBox.Text;
            else
                hargaEcerTextBox.Text = hargaEcerValueText;
        }

        private void hargaPartaiTextBox_TextChanged(object sender, EventArgs e)
        {
            if (checkRegEx(hargaPartaiTextBox.Text))
                hargaPartaiText = hargaPartaiTextBox.Text;
            else
                hargaPartaiTextBox.Text = hargaPartaiText;
        }

        private void hargaGrosirTextBox_TextChanged(object sender, EventArgs e)
        {
            if (checkRegEx(hargaGrosirTextBox.Text))
                hargaGrosirValueText = hargaGrosirTextBox.Text;
            else
                hargaGrosirTextBox.Text = hargaGrosirValueText;
        }

        private void loadProdukData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string productShelves = "";
            string fileName = "";

            DS.mySqlConnect();

            // LOAD PRODUCT DATA
            using (rdr = DS.getData("SELECT * FROM MASTER_PRODUCT WHERE ID =  " + selectedInternalProductID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        //kodeProdukTextBox.Text = rdr.GetString("PRODUCT_ID");
                        //barcodeTextBox.Text = rdr.GetString("PRODUCT_BARCODE");
                        selectedProductID = rdr.GetString("PRODUCT_ID");
                        namaProdukTextBox.Text = rdr.GetString("PRODUCT_NAME");
                        produkDescTextBox.Text = rdr.GetString("PRODUCT_DESCRIPTION");
                        hppTextBox.Text = rdr.GetString("PRODUCT_BASE_PRICE");
                        hargaEcerTextBox.Text = rdr.GetString("PRODUCT_RETAIL_PRICE");
                        hargaPartaiTextBox.Text = rdr.GetString("PRODUCT_BULK_PRICE");
                        hargaGrosirTextBox.Text = rdr.GetString("PRODUCT_WHOLESALE_PRICE"); ;
                        merkTextBox.Text = rdr.GetString("PRODUCT_BRAND");
                        stokAwalTextBox.Text = rdr.GetString("PRODUCT_STOCK_QTY");
                        limitStokTextBox.Text = rdr.GetString("PRODUCT_LIMIT_STOCK");

                        productShelves = rdr.GetString("PRODUCT_SHELVES");

                        //noRakBarisTextBox.Text = productShelves.Substring(0, 2);
                        //noRakKolomTextBox.Text = productShelves.Substring(2); 

                        selectedUnitID = rdr.GetInt32("UNIT_ID");
                        if (rdr.GetString("PRODUCT_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;
                        
                        if (rdr.GetString("PRODUCT_IS_SERVICE").Equals("1"))
                            produkJasaCheckbox.Checked = true;
                        else
                            produkJasaCheckbox.Checked = false;

                        fileName = rdr.GetString("PRODUCT_PHOTO_1").Trim();

                        if (!fileName.Equals(""))
                        {
                            try
                            {
                                panelImage.BackgroundImageLayout = ImageLayout.Stretch;
                                panelImage.BackgroundImage = Image.FromFile("PRODUCT_PHOTO/" + fileName);

                                selectedPhoto = "PRODUCT_PHOTO/" + fileName;
                                photoFileName = fileName;
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }
        }

        private void loadProductLocationData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            string sqlCommand;

            if (originModuleID == globalConstants.NEW_PRODUK)
            {
                sqlCommand = "SELECT ID, LOCATION_NAME , 0 AS 'JUMLAH' FROM MASTER_LOCATION";

            }
            else
            {
                sqlCommand = "SELECT M.ID, LOCATION_NAME, PRODUCT_LOCATION_QTY AS 'JUMLAH' FROM MASTER_LOCATION M, PRODUCT_LOCATION P " +
                                    "WHERE P.LOCATION_ID = M.ID AND P.PRODUCT_ID = '" + selectedProductID + "'";
            }

            using (rdr = DS.getData(sqlCommand))
            {
                detailLokasiDataGridView.Rows.Clear();
                if (rdr.HasRows)
                {
                    //dt.Load(rdr);

                    while (rdr.Read())
                    {
                        detailQty.Add(rdr.GetString("JUMLAH"));
                        detailLokasiDataGridView.Rows.Add(rdr.GetString("ID"), rdr.GetString("LOCATION_NAME"), rdr.GetString("JUMLAH"));
                    }                    
                }
            }
        }

        private void loadProductCategoryData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            //if (kodeProdukTextBox.Text.Equals(""))
            //    return;

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM PRODUCT_CATEGORY WHERE PRODUCT_ID =  '" + selectedProductID+"'"))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        addSelectedKategoriID(rdr.GetInt32("CATEGORY_ID"));
                    }
                }
            }
        }

        private void loadUnitIDInformation()
        {
            string sqlCommand;
            string unitName = "";
            DS.mySqlConnect();

            if (selectedUnitID == 0)
                return;

            sqlCommand = "SELECT IFNULL(UNIT_NAME, '') FROM MASTER_UNIT WHERE UNIT_ID = " + selectedUnitID;
            unitName = DS.getDataSingleValue(sqlCommand).ToString();

            unitTextBox.Text = unitName;
        }

        private void loadKategoriIDInformation()
        {
            string sqlCommand;
            string kategoriName = "";

            DS.mySqlConnect();

            produkKategoriTextBox.Text = "";

            for (int i = 0;i<currentSelectedKategoriID.Count;i++)
            {
                sqlCommand = "SELECT IFNULL(CATEGORY_NAME, '') FROM MASTER_CATEGORY WHERE CATEGORY_ID = " + currentSelectedKategoriID[i];

                if (!kategoriName.Equals(""))
                    kategoriName = kategoriName + ", ";

                kategoriName = kategoriName + DS.getDataSingleValue(sqlCommand).ToString();
            }

            produkKategoriTextBox.Text = kategoriName;
        }

        private void searchUnitButton_Click(object sender, EventArgs e)
        {
            dataSatuanForm displayedForm = new dataSatuanForm(globalConstants.PRODUK_DETAIL_FORM, this);
            displayedForm.ShowDialog(this);

            loadUnitIDInformation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = openFileDialog1.FileName;
                    panelImage.BackgroundImageLayout = ImageLayout.Stretch;
                    panelImage.BackgroundImage = Image.FromFile(fileName);

                    selectedPhoto = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void searchKategoriButton_Click(object sender, EventArgs e)
        {
            dataKategoriProdukForm displayedForm = new dataKategoriProdukForm(globalConstants.PRODUK_DETAIL_FORM, this);
            displayedForm.ShowDialog(this);

            loadKategoriIDInformation();
        }

        private bool dataValidated()
        {
            if (namaProdukTextBox.Text.Equals(""))
            {
                errorLabel.Text = "NAMA PRODUK TIDAK BOLEH KOSONG";
                return false;
            }

            if (hppTextBox.Text.Length <= 0 || Convert.ToInt32(hppTextBox.Text) == 0)
            {
                errorLabel.Text = "HARGA POKOK TIDAK BOLEH 0 / KOSONG";
                return false;
            }

            if (hargaEcerTextBox.Text.Length <= 0 || Convert.ToInt32(hargaEcerTextBox.Text) == 0)
            {
                errorLabel.Text = "HARGA ECER TIDAK BOLEH 0 / KOSONG";
                return false;
            }

            if (hargaGrosirTextBox.Text.Length <= 0 || Convert.ToInt32(hargaGrosirTextBox.Text) == 0)
            {
                errorLabel.Text = "HARGA PARTAI TIDAK BOLEH 0 / KOSONG";
                return false;
            }

            if (hargaPartaiTextBox.Text.Length <= 0 || Convert.ToInt32(hargaPartaiTextBox.Text) == 0)
            {
                errorLabel.Text = "HARGA GROSIR TIDAK BOLEH 0 / KOSONG";
                return false;
            }

            if (unitTextBox.Text.Equals(""))
            {
                errorLabel.Text = "UNIT TIDAK BOLEH KOSONG";
                return false;
            }

            return true;
        }

        private string getProdukID()
        {
            string productID = "";
            //if (originModuleID == globalConstants.NEW_PRODUK)
            //    return "TMPPRD001";
            //else
            //    return kodeProdukTextBox.Text;

            productID = (Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(MAX(PRODUCT_ID), 0) FROM MASTER_PRODUCT")) + 1).ToString();

            return productID;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            string noRakBaris = "";
            string noRakKolom = "";
            //string produkBarcode = "";
            MySqlException internalEX = null;

            //string produkID = getProdukID();
            //productID = kodeProdukTextBox.Text.Trim();
            //string produkBarcode = barcodeTextBox.Text;
            //if (produkBarcode.Equals(""))
            //    produkBarcode = " ";

            if (originModuleID != globalConstants.EDIT_PRODUK)
                selectedProductID = getProdukID();

            string produkName = namaProdukTextBox.Text.Trim();

            string produkDesc = produkDescTextBox.Text.Trim();
            if (produkDesc.Equals(""))
                produkDesc = " ";

            string produkHargaPokok = hppTextBox.Text;
            string produkHargaEcer = hargaEcerTextBox.Text;
            string produkHargaPartai = hargaPartaiTextBox.Text;
            string produkHargaGrosir = hargaGrosirTextBox.Text;

            string produkBrand = merkTextBox.Text.Trim();
            if (produkBrand.Equals(""))
                produkBrand = " ";

            string produkQty = stokAwalTextBox.Text;
            if (produkQty.Equals(""))
                produkQty = "0";

            string limitStock = limitStokTextBox.Text;
            if (limitStock.Equals(""))
                limitStock = "0";

            //noRakBaris = noRakBarisTextBox.Text;
            //noRakKolom= noRakKolomTextBox.Text;
            
            while (noRakBaris.Length < 2)
                noRakBaris = "-" + noRakBaris;

            while (noRakKolom.Length < 2)
                noRakKolom = "0" + noRakKolom;

            string produkShelves = noRakBaris + noRakKolom;

            byte produkSvc = 0;
            if (produkJasaCheckbox.Checked)
                produkSvc = 1;
            else
                produkSvc = 0;

            byte produkStatus = 0;
            if (nonAktifCheckbox.Checked)
                produkStatus = 0;
            else
                produkStatus = 1;

            string produkPhoto = " ";
            if (!selectedPhoto.Equals(""))
                produkPhoto = selectedProductID + ".jpg";

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.EDIT_PRODUK:
                            // UPDATE MASTER_PRODUK TABLE
                            sqlCommand = "UPDATE MASTER_PRODUCT SET " +
            //                                    "PRODUCT_BARCODE = '" + produkBarcode + "', " +
                                                "PRODUCT_NAME =  '" + produkName + "', " +
                                                "PRODUCT_DESCRIPTION =  '" + produkDesc + "', " +
                                                "PRODUCT_BASE_PRICE = " + produkHargaPokok + ", " +
                                                "PRODUCT_RETAIL_PRICE = " + produkHargaEcer + ", " +
                                                "PRODUCT_BULK_PRICE =  " + produkHargaPartai + ", " +
                                                "PRODUCT_WHOLESALE_PRICE = " + produkHargaGrosir + ", " +
                                                "PRODUCT_PHOTO_1 = '" + produkPhoto + "', " +
                                                "UNIT_ID = " + selectedUnitID + ", " +
                                                "PRODUCT_STOCK_QTY = " + produkQty + ", " +
                                                "PRODUCT_LIMIT_STOCK = " + limitStock + ", " +
                                                "PRODUCT_SHELVES = '" + produkShelves + "', " +
                                                "PRODUCT_ACTIVE = " + produkStatus + ", " +
                                                "PRODUCT_BRAND = '" + produkBrand + "', " +
                                                "PRODUCT_IS_SERVICE = " + produkSvc + " " +
                                                "WHERE PRODUCT_ID = '" + selectedProductID + "'";


                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            // UPDATE PRODUCT_CATEGORY TABLE
                            // delete the content first, and insert the new data based on the currentSelectedKategoryID LIST
                            sqlCommand = "DELETE FROM PRODUCT_CATEGORY WHERE PRODUCT_ID = '" + selectedProductID + "'";
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            // SAVE TO PRODUCT_CATEGORY TABLE
                            for (int i = 0; i < currentSelectedKategoriID.Count(); i++)
                            {
                                sqlCommand = "INSERT INTO PRODUCT_CATEGORY (PRODUCT_ID, CATEGORY_ID) VALUES ('" + selectedProductID + "', " + currentSelectedKategoriID[i] + ")";
                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }

                            // UPDATE PRODUCT LOCATION TABLE
                            for (int j = 0; j < detailQty.Count;j++)
                            {
                                sqlCommand = "UPDATE PRODUCT_LOCATION SET PRODUCT_LOCATION_QTY = " + Convert.ToDouble(detailQty[j]) + " WHERE LOCATION_ID = " + detailLokasiDataGridView.Rows[j].Cells["ID"].Value.ToString() + " AND PRODUCT_ID = '" + selectedProductID + "'";
                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        break;

                    default: // NEW PRODUK
                        // SAVE TO MASTER_PRODUK TABLE
                        sqlCommand = "INSERT INTO MASTER_PRODUCT " +
                                            "(PRODUCT_ID, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_BASE_PRICE, PRODUCT_RETAIL_PRICE, PRODUCT_BULK_PRICE, PRODUCT_WHOLESALE_PRICE, PRODUCT_PHOTO_1, UNIT_ID, PRODUCT_STOCK_QTY, PRODUCT_LIMIT_STOCK, PRODUCT_SHELVES, PRODUCT_ACTIVE, PRODUCT_BRAND, PRODUCT_IS_SERVICE) " +
                                            "VALUES " +
                                            "('" + selectedProductID + "', '" + produkName + "', '" + produkDesc + "', " + produkHargaPokok + ", " + produkHargaEcer + ", " + produkHargaPartai + ", " + produkHargaGrosir + ", '" + produkPhoto + "', " + selectedUnitID + ", " + produkQty + ", " + limitStock + ", '" + produkShelves + "', " + produkStatus + ", '" + produkBrand + "', " + produkSvc + ")";

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // SAVE TO PRODUCT_CATEGORY TABLE
                        for (int i = 0; i < currentSelectedKategoriID.Count(); i++)
                        {
                            sqlCommand = "INSERT INTO PRODUCT_CATEGORY (PRODUCT_ID, CATEGORY_ID) VALUES ('" + selectedProductID + "', " + currentSelectedKategoriID[i] + ")";
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }

                        // SAVE TO PRODUCT_LOCATION_TABLE
                        for (int j = 0; j < detailQty.Count; j++)
                        {
                            sqlCommand = "INSERT INTO PRODUCT_LOCATION (LOCATION_ID, PRODUCT_ID, PRODUCT_LOCATION_QTY) VALUES (" + detailLokasiDataGridView.Rows[j].Cells["ID"].Value.ToString() + ", '" + selectedProductID + "', " + Convert.ToDouble(detailQty[j]) + ")";
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }
                        break;
                }

                //DS.executeNonQueryCommand(sqlCommand);

                if (!selectedPhoto.Equals("PRODUCT_PHOTO/" + produkPhoto) && !selectedPhoto.Equals("") && result == true)
                {
                    panelImage.BackgroundImage = null;
                    System.IO.File.Copy(selectedPhoto, "PRODUCT_PHOTO/" + produkPhoto + "_temp");

                    if (System.IO.File.Exists("PRODUCT_PHOTO/" + produkPhoto))
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        System.IO.File.Delete("PRODUCT_PHOTO/" + produkPhoto);
                    }

                    System.IO.File.Move("PRODUCT_PHOTO/" + produkPhoto + "_temp", "PRODUCT_PHOTO/" + produkPhoto);
                    panelImage.BackgroundImage = Image.FromFile("PRODUCT_PHOTO/" + produkPhoto);
                }

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
                        gUtil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gUtil.showDBOPError(e, "ROLLBACK");
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

        private int getInternalProductID(string productID)
        {
            int result;
            DS.mySqlConnect();

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT ID FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int internalProductID;
            if (saveData())
            {
                //MessageBox.Show("SUCCESS");
                gUtil.showSuccess(options);
                if (originModuleID == globalConstants.STOK_PECAH_BARANG)
                {
                    internalProductID = getInternalProductID(selectedProductID);
                    parentForm.setNewSelectedProductID(internalProductID);

                    this.Close();
                }
                gUtil.ResetAllControls(this);
                stokAwalTextBox.Text = "0";
                limitStokTextBox.Text = "0";
                hppTextBox.Text = "0";
                hargaEcerTextBox.Text = "0";
                hargaGrosirTextBox.Text = "0";
                hargaPartaiTextBox.Text = "0";

                selectedPhoto = "";
                panelImage.BackgroundImage = null;
                errorLabel.Text = "";
                detailLokasiDataGridView.Rows.Clear();
                originModuleID = globalConstants.NEW_PRODUK;
                options = gUtil.INS;
            }
        }

        private bool productIDExist()
        {
            bool result = false;

            //if (!DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '"+kodeProdukTextBox.Text.Trim()+"'").ToString().Equals("0"))
            //{
            //    result = true;
            //}

            return result;
        }

        private bool barcodeExist()
        {
            bool result = false;

            //if (!DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_PRODUCT WHERE PRODUCT_BARCODE = '" + barcodeTextBox.Text.Trim() + "'").ToString().Equals("0"))
            //{
            //    result = true;
            //}

            return result;
        }

        private void kodeProdukTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((productIDExist()) &&  (originModuleID != globalConstants.EDIT_PRODUK))
                errorLabel.Text = "PRODUK ID SUDAH ADA";
            else
                errorLabel.Text = "";
        }

        private void kodeProdukTextBox_TextChanged(object sender, EventArgs e)
        {
//            string temp = kodeProdukTextBox.Text.Trim();
//            kodeProdukTextBox.Text = temp;
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gUtil.ResetAllControls(this);

            stokAwalTextBox.Text = "0";
            limitStokTextBox.Text = "0";
            hppTextBox.Text = "0";
            hargaEcerTextBox.Text = "0";
            hargaGrosirTextBox.Text = "0";
            hargaPartaiTextBox.Text = "0";

            selectedPhoto = "";
            panelImage.BackgroundImage = null;
            errorLabel.Text = "";
            detailLokasiDataGridView.Rows.Clear();
            currentSelectedKategoriID.Clear();
            originModuleID = globalConstants.NEW_PRODUK;
            options = gUtil.INS;
        }

        private void dataProdukDetailForm_Load(object sender, EventArgs e)
        {
            detailLokasiDataGridView.EditingControlShowing += detailLokasiDataGridView_EditingControlShowing;

            errorLabel.Text = "";

            isLoading = true;

            loadProdukData();

            loadProductLocationData();

            loadUnitIDInformation();

            loadProductCategoryData();

            loadKategoriIDInformation();

            isLoading = false;

            switch (originModuleID)
            {
                case globalConstants.NEW_PRODUK:
                    options = gUtil.INS;
                    break;
                case globalConstants.EDIT_PRODUK:
                    options = gUtil.UPD;
                    break;
            }
        
            gUtil.reArrangeTabOrder(this);            
        }

        private void barcodeTextBox_Validated(object sender, EventArgs e)
        {
            if ((barcodeExist()) && (originModuleID == globalConstants.NEW_PRODUK))
                errorLabel.Text = "BARCODE SUDAH ADA";
            else
                errorLabel.Text = "";
        }

        private void dataProdukDetailForm_Activated(object sender, EventArgs e)
        {
        }
    }
}
