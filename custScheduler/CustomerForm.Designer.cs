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
            btnDelete = new Button();
            btnSave = new Button();
            btnNew = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtAddress = new TextBox();
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
            splitContainer1.Panel2.Controls.Add(btnDelete);
            splitContainer1.Panel2.Controls.Add(btnSave);
            splitContainer1.Panel2.Controls.Add(btnNew);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(txtAddress);
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
            label4.Location = new Point(22, 191);
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
            // txtAddress
            // 
            txtAddress.Location = new Point(66, 95);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(157, 87);
            txtAddress.TabIndex = 5;
            // 
            // txtDetails
            // 
            txtDetails.Location = new Point(66, 188);
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
        private TextBox txtAddress;
        private TextBox txtDetails;
        private CheckBox chkActive;
        private ComboBox cmbAddress;
        private TextBox txtCustomerName;
        private TextBox txtID;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnDelete;
        private Button btnSave;
        private Button btnNew;
    }
}