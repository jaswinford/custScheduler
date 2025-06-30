namespace custScheduler
{
    partial class CustomerForm
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
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            txtPostalCode = new TextBox();
            cmbCity = new ComboBox();
            txtAddress2 = new TextBox();
            txtAddress1 = new TextBox();
            txtPhone = new TextBox();
            label5 = new Label();
            btnDelete = new Button();
            btnSave = new Button();
            btnNew = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDetails = new TextBox();
            chkActive = new CheckBox();
            cmbAddress = new ComboBox();
            txtCustomerName = new TextBox();
            txtID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label9);
            splitContainer1.Panel2.Controls.Add(label8);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(txtPostalCode);
            splitContainer1.Panel2.Controls.Add(cmbCity);
            splitContainer1.Panel2.Controls.Add(txtAddress2);
            splitContainer1.Panel2.Controls.Add(txtAddress1);
            splitContainer1.Panel2.Controls.Add(txtPhone);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(btnDelete);
            splitContainer1.Panel2.Controls.Add(btnSave);
            splitContainer1.Panel2.Controls.Add(btnNew);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(txtDetails);
            splitContainer1.Panel2.Controls.Add(chkActive);
            splitContainer1.Panel2.Controls.Add(cmbAddress);
            splitContainer1.Panel2.Controls.Add(txtCustomerName);
            splitContainer1.Panel2.Controls.Add(txtID);
            splitContainer1.Size = new Size(700, 450);
            splitContainer1.SplitterDistance = 377;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(377, 450);
            dataGridView1.TabIndex = 0;
            dataGridView1.Click += dataGridView1_Click;
            dataGridView1.KeyPress += dataGridView1_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 185);
            label9.Name = "label9";
            label9.Size = new Size(70, 15);
            label9.TabIndex = 22;
            label9.Text = "Postal Code";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(32, 156);
            label8.Name = "label8";
            label8.Size = new Size(28, 15);
            label8.TabIndex = 21;
            label8.Text = "City";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 127);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 20;
            label7.Text = "Line2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 98);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 19;
            label6.Text = "Line1";
            // 
            // txtPostalCode
            // 
            txtPostalCode.Location = new Point(79, 182);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(144, 23);
            txtPostalCode.TabIndex = 18;
            txtPostalCode.TextChanged += txtPostalCode_TextChanged;
            txtPostalCode.KeyPress += txtPostalCode_KeyPress;
            // 
            // cmbCity
            // 
            cmbCity.FormattingEnabled = true;
            cmbCity.Location = new Point(66, 153);
            cmbCity.Name = "cmbCity";
            cmbCity.Size = new Size(157, 23);
            cmbCity.TabIndex = 17;
            cmbCity.SelectedIndexChanged += cmbCity_SelectedIndexChanged;
            // 
            // txtAddress2
            // 
            txtAddress2.Location = new Point(66, 124);
            txtAddress2.Name = "txtAddress2";
            txtAddress2.Size = new Size(157, 23);
            txtAddress2.TabIndex = 16;
            txtAddress2.TextChanged += txtAddress2_TextChanged;
            // 
            // txtAddress1
            // 
            txtAddress1.Location = new Point(66, 95);
            txtAddress1.Name = "txtAddress1";
            txtAddress1.Size = new Size(157, 23);
            txtAddress1.TabIndex = 15;
            txtAddress1.TextChanged += txtAddress1_TextChanged;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(66, 211);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(157, 23);
            txtPhone.TabIndex = 14;
            txtPhone.TextChanged += txtPhone_TextChanged;
            txtPhone.KeyPress += txtPhone_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 214);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 13;
            label5.Text = "Phone";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(229, 65);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(229, 36);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(229, 10);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 10;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 240);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 9;
            label4.Text = "Details";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 69);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 8;
            label3.Text = "Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 40);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 7;
            label2.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 14);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 6;
            label1.Text = "ID";
            // 
            // txtDetails
            // 
            txtDetails.Location = new Point(66, 240);
            txtDetails.Multiline = true;
            txtDetails.Name = "txtDetails";
            txtDetails.ReadOnly = true;
            txtDetails.Size = new Size(157, 69);
            txtDetails.TabIndex = 4;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Location = new Point(164, 10);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(59, 19);
            chkActive.TabIndex = 3;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            chkActive.CheckedChanged += chkActive_CheckedChanged;
            // 
            // cmbAddress
            // 
            cmbAddress.FormattingEnabled = true;
            cmbAddress.Location = new Point(66, 66);
            cmbAddress.Name = "cmbAddress";
            cmbAddress.Size = new Size(157, 23);
            cmbAddress.TabIndex = 2;
            cmbAddress.SelectedIndexChanged += cmbAddress_SelectedIndexChanged;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(66, 37);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(157, 23);
            txtCustomerName.TabIndex = 1;
            txtCustomerName.TextChanged += txtCustomerName_TextChanged;
            // 
            // txtID
            // 
            txtID.Location = new Point(66, 8);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(92, 23);
            txtID.TabIndex = 0;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 450);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "CustomerForm";
            Text = "Customers";
            Load += CustomerForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private TextBox txtDetails;
        private CheckBox chkActive;
        private TextBox txtCustomerName;
        private TextBox txtID;
        private Label label4;
        private Label label2;
        private Label label1;
        private Button btnDelete;
        private Button btnSave;
        private Button btnNew;
        private TextBox txtPhone;
        private Label label5;
        private Label label3;
        private ComboBox cmbAddress;
        private ComboBox cmbCity;
        private TextBox txtAddress2;
        private TextBox txtAddress1;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox txtPostalCode;
    }
}