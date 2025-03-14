namespace RestaurantSalaries.Forms
{
    partial class ReportsForm
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
            salariesGridView = new DataGridView();
            filterTextBox = new TextBox();
            filterButton = new Button();
            label6 = new Label();
            startDate = new DateTimePicker();
            endDate = new DateTimePicker();
            exportReportBtn = new Button();
            filterByDateBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            totalSalaryExpense = new TextBox();
            ((System.ComponentModel.ISupportInitialize)salariesGridView).BeginInit();
            SuspendLayout();
            // 
            // salariesGridView
            // 
            salariesGridView.AllowUserToOrderColumns = true;
            salariesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            salariesGridView.Location = new Point(40, 204);
            salariesGridView.Name = "salariesGridView";
            salariesGridView.ReadOnly = true;
            salariesGridView.RowHeadersWidth = 62;
            salariesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            salariesGridView.ShowEditingIcon = false;
            salariesGridView.Size = new Size(751, 217);
            salariesGridView.TabIndex = 1;
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(128, 30);
            filterTextBox.Multiline = true;
            filterTextBox.Name = "filterTextBox";
            filterTextBox.Size = new Size(513, 43);
            filterTextBox.TabIndex = 17;
            // 
            // filterButton
            // 
            filterButton.Location = new Point(658, 30);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(133, 57);
            filterButton.TabIndex = 16;
            filterButton.Text = "Филтриране";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += filterButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 30);
            label6.Name = "label6";
            label6.Size = new Size(83, 25);
            label6.TabIndex = 15;
            label6.Text = "Търсене:";
            // 
            // startDate
            // 
            startDate.Location = new Point(40, 143);
            startDate.Name = "startDate";
            startDate.Size = new Size(294, 31);
            startDate.TabIndex = 18;
            // 
            // endDate
            // 
            endDate.Location = new Point(345, 143);
            endDate.Name = "endDate";
            endDate.Size = new Size(296, 31);
            endDate.TabIndex = 19;
            // 
            // exportReportBtn
            // 
            exportReportBtn.Location = new Point(646, 440);
            exportReportBtn.Name = "exportReportBtn";
            exportReportBtn.Size = new Size(145, 45);
            exportReportBtn.TabIndex = 20;
            exportReportBtn.Text = "Свали отчет";
            exportReportBtn.UseVisualStyleBackColor = true;
            exportReportBtn.Click += exportReportBtn_Click;
            // 
            // filterByDateBtn
            // 
            filterByDateBtn.Location = new Point(658, 107);
            filterByDateBtn.Name = "filterByDateBtn";
            filterByDateBtn.Size = new Size(133, 67);
            filterByDateBtn.TabIndex = 21;
            filterByDateBtn.Text = "Филтриране по дата";
            filterByDateBtn.UseVisualStyleBackColor = true;
            filterByDateBtn.Click += filterByDateBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 107);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 22;
            label1.Text = "От дата:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(345, 107);
            label2.Name = "label2";
            label2.Size = new Size(79, 25);
            label2.TabIndex = 23;
            label2.Text = "До дата:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 450);
            label3.Name = "label3";
            label3.Size = new Size(206, 25);
            label3.TabIndex = 24;
            label3.Text = "Общ разход за заплати:";
            // 
            // totalSalaryExpense
            // 
            totalSalaryExpense.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalSalaryExpense.Location = new Point(252, 440);
            totalSalaryExpense.Multiline = true;
            totalSalaryExpense.Name = "totalSalaryExpense";
            totalSalaryExpense.ReadOnly = true;
            totalSalaryExpense.Size = new Size(237, 45);
            totalSalaryExpense.TabIndex = 25;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(832, 644);
            Controls.Add(totalSalaryExpense);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(filterByDateBtn);
            Controls.Add(exportReportBtn);
            Controls.Add(endDate);
            Controls.Add(startDate);
            Controls.Add(filterTextBox);
            Controls.Add(filterButton);
            Controls.Add(label6);
            Controls.Add(salariesGridView);
            Name = "ReportsForm";
            Text = "Отчети и справки";
            ((System.ComponentModel.ISupportInitialize)salariesGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView salariesGridView;
        private TextBox filterTextBox;
        private Button filterButton;
        private Label label6;
        private DateTimePicker startDate;
        private DateTimePicker endDate;
        private Button exportReportBtn;
        private Button filterByDateBtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox totalSalaryExpense;
    }
}