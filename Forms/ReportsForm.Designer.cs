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
            ((System.ComponentModel.ISupportInitialize)salariesGridView).BeginInit();
            SuspendLayout();
            // 
            // salariesGridView
            // 
            salariesGridView.AllowUserToOrderColumns = true;
            salariesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            salariesGridView.Location = new Point(40, 166);
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
            filterTextBox.Name = "filterTextBox";
            filterTextBox.Size = new Size(513, 31);
            filterTextBox.TabIndex = 17;
            // 
            // filterButton
            // 
            filterButton.Location = new Point(658, 28);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(133, 33);
            filterButton.TabIndex = 16;
            filterButton.Text = "Филтриране";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += filterButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 32);
            label6.Name = "label6";
            label6.Size = new Size(83, 25);
            label6.TabIndex = 15;
            label6.Text = "Търсене:";
            // 
            // startDate
            // 
            startDate.Location = new Point(128, 107);
            startDate.Name = "startDate";
            startDate.Size = new Size(296, 31);
            startDate.TabIndex = 18;
            // 
            // endDate
            // 
            endDate.Location = new Point(495, 107);
            endDate.Name = "endDate";
            endDate.Size = new Size(296, 31);
            endDate.TabIndex = 19;
            // 
            // exportReportBtn
            // 
            exportReportBtn.Location = new Point(658, 411);
            exportReportBtn.Name = "exportReportBtn";
            exportReportBtn.Size = new Size(133, 33);
            exportReportBtn.TabIndex = 20;
            exportReportBtn.Text = "Свали отчет";
            exportReportBtn.UseVisualStyleBackColor = true;
            exportReportBtn.Click += exportReportBtn_Click;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(832, 644);
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
    }
}