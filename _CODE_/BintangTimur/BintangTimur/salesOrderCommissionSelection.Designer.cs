namespace AlphaSoft
{
    partial class salesOrderCommissionSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.detailGridView = new System.Windows.Forms.DataGridView();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PODtPicker_1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.PODtPicker_2 = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.deskripsiTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(5, 5);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 49;
            this.errorLabel.Text = "   ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 29);
            this.panel1.TabIndex = 47;
            // 
            // detailGridView
            // 
            this.detailGridView.AllowUserToAddRows = false;
            this.detailGridView.AllowUserToDeleteRows = false;
            this.detailGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.detailGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.detailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.detailGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.detailGridView.Location = new System.Drawing.Point(1, 105);
            this.detailGridView.Name = "detailGridView";
            this.detailGridView.RowHeadersVisible = false;
            this.detailGridView.Size = new System.Drawing.Size(737, 474);
            this.detailGridView.TabIndex = 61;
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(512, 74);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(71, 17);
            this.checkAll.TabIndex = 62;
            this.checkAll.Text = "Check All";
            this.checkAll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 67;
            this.label1.Text = "Sales Person";
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 63;
            this.label2.Text = "Periode";
            // 
            // PODtPicker_1
            // 
            this.PODtPicker_1.AllowDrop = true;
            this.PODtPicker_1.Enabled = false;
            this.PODtPicker_1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODtPicker_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PODtPicker_1.Location = new System.Drawing.Point(151, 35);
            this.PODtPicker_1.Name = "PODtPicker_1";
            this.PODtPicker_1.Size = new System.Drawing.Size(144, 27);
            this.PODtPicker_1.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(301, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 66;
            this.label5.Text = "-";
            // 
            // PODtPicker_2
            // 
            this.PODtPicker_2.AllowDrop = true;
            this.PODtPicker_2.Enabled = false;
            this.PODtPicker_2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODtPicker_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PODtPicker_2.Location = new System.Drawing.Point(323, 35);
            this.PODtPicker_2.Name = "PODtPicker_2";
            this.PODtPicker_2.Size = new System.Drawing.Size(145, 27);
            this.PODtPicker_2.TabIndex = 65;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(308, 602);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(122, 37);
            this.saveButton.TabIndex = 69;
            this.saveButton.Text = "SAVE ";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deskripsiTextBox
            // 
            this.deskripsiTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deskripsiTextBox.Location = new System.Drawing.Point(151, 68);
            this.deskripsiTextBox.Name = "deskripsiTextBox";
            this.deskripsiTextBox.ReadOnly = true;
            this.deskripsiTextBox.Size = new System.Drawing.Size(346, 27);
            this.deskripsiTextBox.TabIndex = 68;
            // 
            // salesOrderCommissionSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(739, 661);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deskripsiTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PODtPicker_1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PODtPicker_2);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.detailGridView);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "salesOrderCommissionSelection";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES ORDER COMMISSION";
            this.Load += new System.EventHandler(this.salesOrderCommissionSelection_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView detailGridView;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker PODtPicker_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker PODtPicker_2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox deskripsiTextBox;
    }
}