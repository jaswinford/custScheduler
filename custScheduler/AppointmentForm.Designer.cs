
namespace custScheduler
{
    partial class AppointmentForm
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            IDBox = new TextBox();
            customerComboBox = new ComboBox();
            label3 = new Label();
            titleTextBox = new TextBox();
            label4 = new Label();
            descriptionTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            startDTPick = new DateTimePicker();
            endDTPick = new DateTimePicker();
            lblDetails = new Label();
            locationTextBox = new TextBox();
            contactTextBox = new TextBox();
            typeTextBox = new TextBox();
            txtURL = new TextBox();
            appointmentGrid = new DataGridView();
            panel1 = new Panel();
            label12 = new Label();
            txtClock = new TextBox();
            label11 = new Label();
            cmbTimezone = new ComboBox();
            monthCalendar = new MonthCalendar();
            menuStrip1 = new MenuStrip();
            newToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            customersToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            typesByMonthToolStripMenuItem = new ToolStripMenuItem();
            scheduleByUserToolStripMenuItem = new ToolStripMenuItem();
            additionalToolStripMenuItem = new ToolStripMenuItem();
            timerClock = new System.Windows.Forms.Timer(components);
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentGrid).BeginInit();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 1, 0);
            tableLayoutPanel2.Controls.Add(appointmentGrid, 0, 1);
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 24);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1264, 737);
            tableLayoutPanel2.TabIndex = 7;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(IDBox, 1, 0);
            tableLayoutPanel1.Controls.Add(customerComboBox, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(titleTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(descriptionTextBox, 1, 3);
            tableLayoutPanel1.Controls.Add(label5, 2, 0);
            tableLayoutPanel1.Controls.Add(label6, 2, 1);
            tableLayoutPanel1.Controls.Add(label7, 2, 2);
            tableLayoutPanel1.Controls.Add(label8, 2, 3);
            tableLayoutPanel1.Controls.Add(label9, 0, 4);
            tableLayoutPanel1.Controls.Add(label10, 2, 4);
            tableLayoutPanel1.Controls.Add(startDTPick, 1, 4);
            tableLayoutPanel1.Controls.Add(endDTPick, 3, 4);
            tableLayoutPanel1.Controls.Add(lblDetails, 0, 5);
            tableLayoutPanel1.Controls.Add(locationTextBox, 3, 0);
            tableLayoutPanel1.Controls.Add(contactTextBox, 3, 1);
            tableLayoutPanel1.Controls.Add(typeTextBox, 3, 2);
            tableLayoutPanel1.Controls.Add(txtURL, 3, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(253, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(1008, 244);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 30);
            label1.TabIndex = 0;
            label1.Text = "Id";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(67, 30);
            label2.TabIndex = 1;
            label2.Text = "Customer";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // IDBox
            // 
            IDBox.Dock = DockStyle.Fill;
            IDBox.Location = new Point(76, 3);
            IDBox.Name = "IDBox";
            IDBox.ReadOnly = true;
            IDBox.Size = new Size(432, 23);
            IDBox.TabIndex = 2;
            // 
            // customerComboBox
            // 
            customerComboBox.Dock = DockStyle.Fill;
            customerComboBox.FormattingEnabled = true;
            customerComboBox.Location = new Point(76, 33);
            customerComboBox.Name = "customerComboBox";
            customerComboBox.Size = new Size(432, 23);
            customerComboBox.TabIndex = 3;
            customerComboBox.SelectedIndexChanged += customerComboBox_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 60);
            label3.Name = "label3";
            label3.Size = new Size(67, 30);
            label3.TabIndex = 4;
            label3.Text = "Title";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // titleTextBox
            // 
            titleTextBox.Dock = DockStyle.Fill;
            titleTextBox.Location = new Point(76, 63);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(432, 23);
            titleTextBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 90);
            label4.Name = "label4";
            label4.Size = new Size(67, 90);
            label4.TabIndex = 6;
            label4.Text = "Description";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Dock = DockStyle.Fill;
            descriptionTextBox.Location = new Point(76, 93);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(432, 84);
            descriptionTextBox.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(514, 0);
            label5.Name = "label5";
            label5.Size = new Size(53, 30);
            label5.TabIndex = 8;
            label5.Text = "Location";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(514, 30);
            label6.Name = "label6";
            label6.Size = new Size(53, 30);
            label6.TabIndex = 9;
            label6.Text = "Contact";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(514, 60);
            label7.Name = "label7";
            label7.Size = new Size(53, 30);
            label7.TabIndex = 10;
            label7.Text = "Type";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(514, 90);
            label8.Name = "label8";
            label8.Size = new Size(53, 90);
            label8.TabIndex = 11;
            label8.Text = "URL";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(3, 180);
            label9.Name = "label9";
            label9.Size = new Size(67, 30);
            label9.TabIndex = 13;
            label9.Text = "Start";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(514, 180);
            label10.Name = "label10";
            label10.Size = new Size(53, 30);
            label10.TabIndex = 14;
            label10.Text = "End";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // startDTPick
            // 
            startDTPick.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            startDTPick.Dock = DockStyle.Fill;
            startDTPick.Format = DateTimePickerFormat.Custom;
            startDTPick.Location = new Point(76, 183);
            startDTPick.Name = "startDTPick";
            startDTPick.Size = new Size(432, 23);
            startDTPick.TabIndex = 15;
            // 
            // endDTPick
            // 
            endDTPick.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            endDTPick.Dock = DockStyle.Fill;
            endDTPick.Format = DateTimePickerFormat.Custom;
            endDTPick.Location = new Point(573, 183);
            endDTPick.Name = "endDTPick";
            endDTPick.Size = new Size(432, 23);
            endDTPick.TabIndex = 16;
            // 
            // lblDetails
            // 
            lblDetails.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblDetails, 4);
            lblDetails.Dock = DockStyle.Fill;
            lblDetails.Location = new Point(3, 210);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(1002, 34);
            lblDetails.TabIndex = 17;
            lblDetails.Text = "label11";
            lblDetails.TextAlign = ContentAlignment.MiddleRight;
            // 
            // locationTextBox
            // 
            locationTextBox.Dock = DockStyle.Fill;
            locationTextBox.Location = new Point(573, 3);
            locationTextBox.Name = "locationTextBox";
            locationTextBox.Size = new Size(432, 23);
            locationTextBox.TabIndex = 18;
            // 
            // contactTextBox
            // 
            contactTextBox.Dock = DockStyle.Fill;
            contactTextBox.Location = new Point(573, 33);
            contactTextBox.Name = "contactTextBox";
            contactTextBox.Size = new Size(432, 23);
            contactTextBox.TabIndex = 19;
            // 
            // typeTextBox
            // 
            typeTextBox.Dock = DockStyle.Fill;
            typeTextBox.Location = new Point(573, 63);
            typeTextBox.Name = "typeTextBox";
            typeTextBox.Size = new Size(432, 23);
            typeTextBox.TabIndex = 20;
            // 
            // txtURL
            // 
            txtURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtURL.Location = new Point(573, 93);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(432, 23);
            txtURL.TabIndex = 21;
            // 
            // appointmentGrid
            // 
            appointmentGrid.AllowUserToAddRows = false;
            appointmentGrid.AllowUserToDeleteRows = false;
            appointmentGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel2.SetColumnSpan(appointmentGrid, 2);
            appointmentGrid.Dock = DockStyle.Fill;
            appointmentGrid.Location = new Point(3, 253);
            appointmentGrid.Name = "appointmentGrid";
            appointmentGrid.ReadOnly = true;
            appointmentGrid.Size = new Size(1258, 481);
            appointmentGrid.TabIndex = 3;
            appointmentGrid.Click += appointmentGrid_Changed;
            appointmentGrid.KeyUp += appointmentGrid_KeyUp;
            // 
            // panel1
            // 
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtClock);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(cmbTimezone);
            panel1.Controls.Add(monthCalendar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(244, 244);
            panel1.TabIndex = 4;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(9, 220);
            label12.Name = "label12";
            label12.Size = new Size(86, 15);
            label12.TabIndex = 6;
            label12.Text = "Corrected Time";
            // 
            // txtClock
            // 
            txtClock.Location = new Point(103, 214);
            txtClock.Name = "txtClock";
            txtClock.ReadOnly = true;
            txtClock.Size = new Size(132, 23);
            txtClock.TabIndex = 5;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 189);
            label11.Name = "label11";
            label11.Size = new Size(59, 15);
            label11.TabIndex = 4;
            label11.Text = "TimeZone";
            // 
            // cmbTimezone
            // 
            cmbTimezone.FormattingEnabled = true;
            cmbTimezone.Location = new Point(74, 183);
            cmbTimezone.Name = "cmbTimezone";
            cmbTimezone.Size = new Size(161, 23);
            cmbTimezone.TabIndex = 3;
            cmbTimezone.SelectedIndexChanged += cmbTimezone_SelectedIndexChanged;
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(8, 9);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { newToolStripMenuItem, refreshToolStripMenuItem, deleteToolStripMenuItem, saveToolStripMenuItem, viewToolStripMenuItem, reportsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(43, 20);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(58, 20);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(52, 20);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(43, 20);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customersToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // customersToolStripMenuItem
            // 
            customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            customersToolStripMenuItem.Size = new Size(129, 22);
            customersToolStripMenuItem.Text = "Customers";
            customersToolStripMenuItem.Click += customersToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { typesByMonthToolStripMenuItem, scheduleByUserToolStripMenuItem, additionalToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(59, 20);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // typesByMonthToolStripMenuItem
            // 
            typesByMonthToolStripMenuItem.Name = "typesByMonthToolStripMenuItem";
            typesByMonthToolStripMenuItem.Size = new Size(164, 22);
            typesByMonthToolStripMenuItem.Text = "Types By Month";
            typesByMonthToolStripMenuItem.Click += typesByMonthToolStripMenuItem_Click;
            // 
            // scheduleByUserToolStripMenuItem
            // 
            scheduleByUserToolStripMenuItem.Name = "scheduleByUserToolStripMenuItem";
            scheduleByUserToolStripMenuItem.Size = new Size(164, 22);
            scheduleByUserToolStripMenuItem.Text = "Schedule by User";
            scheduleByUserToolStripMenuItem.Click += scheduleByUserToolStripMenuItem_Click;
            // 
            // additionalToolStripMenuItem
            // 
            additionalToolStripMenuItem.Name = "additionalToolStripMenuItem";
            additionalToolStripMenuItem.Size = new Size(164, 22);
            additionalToolStripMenuItem.Text = "Additional";
            additionalToolStripMenuItem.Click += additionalToolStripMenuItem_Click;
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 500;
            timerClock.Tick += timerClock_Tick;
            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 761);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AppointmentForm";
            Text = "Appointments";
            Load += Form1_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentGrid).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private TextBox IDBox;
        private ComboBox customerComboBox;
        private Label label3;
        private TextBox titleTextBox;
        private Label label4;
        private TextBox descriptionTextBox;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private DataGridView appointmentGrid;
        private Label label9;
        private Label label10;
        private DateTimePicker startDTPick;
        private DateTimePicker endDTPick;
        private Label lblDetails;
        private TextBox locationTextBox;
        private TextBox contactTextBox;
        private TextBox typeTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem customersToolStripMenuItem;
        private TextBox txtURL;
        private Panel panel1;
        private Label label12;
        private TextBox txtClock;
        private Label label11;
        private ComboBox cmbTimezone;
        private MonthCalendar monthCalendar;
        private System.Windows.Forms.Timer timerClock;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem typesByMonthToolStripMenuItem;
        private ToolStripMenuItem scheduleByUserToolStripMenuItem;
        private ToolStripMenuItem additionalToolStripMenuItem;
    }
}