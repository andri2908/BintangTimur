namespace AlphaSoft
{
    partial class dataSalesPerson
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
            this.namaUserTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataUserGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.usernonactiveoption = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // namaUserTextbox
            // 
            this.namaUserTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaUserTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaUserTextbox.Location = new System.Drawing.Point(158, 43);
            this.namaUserTextbox.Name = "namaUserTextbox";
            this.namaUserTextbox.Size = new System.Drawing.Size(214, 27);
            this.namaUserTextbox.TabIndex = 0;
            this.namaUserTextbox.TextChanged += new System.EventHandler(this.namaUserTextbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(155, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama";
            // 
            // dataUserGridView
            // 
            this.dataUserGridView.AllowUserToAddRows = false;
            this.dataUserGridView.AllowUserToDeleteRows = false;
            this.dataUserGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataUserGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataUserGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataUserGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataUserGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataUserGridView.Location = new System.Drawing.Point(1, 106);
            this.dataUserGridView.Name = "dataUserGridView";
            this.dataUserGridView.ReadOnly = true;
            this.dataUserGridView.RowHeadersVisible = false;
            this.dataUserGridView.Size = new System.Drawing.Size(634, 445);
            this.dataUserGridView.TabIndex = 4;
            this.dataUserGridView.DoubleClick += new System.EventHandler(this.dataUserGridView_DoubleClick);
            this.dataUserGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataUserGridView_KeyDown);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.newButton.ForeColor = System.Drawing.Color.Black;
            this.newButton.Location = new System.Drawing.Point(378, 42);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(73, 27);
            this.newButton.TabIndex = 4;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // usernonactiveoption
            // 
            this.usernonactiveoption.AutoSize = true;
            this.usernonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernonactiveoption.Location = new System.Drawing.Point(158, 71);
            this.usernonactiveoption.Name = "usernonactiveoption";
            this.usernonactiveoption.Size = new System.Drawing.Size(176, 19);
            this.usernonactiveoption.TabIndex = 1;
            this.usernonactiveoption.Text = "Tampilkan Sales Non Aktif?";
            this.usernonactiveoption.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Controls.Add(this.usernonactiveoption);
            this.groupBox1.Controls.Add(this.namaUserTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // dataSalesPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(636, 549);
            this.Controls.Add(this.dataUserGridView);
            this.Controls.Add(this.groupBox1);
            this.Name = "dataSalesPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dataSalesPeson";
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox namaUserTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataUserGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox usernonactiveoption;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}