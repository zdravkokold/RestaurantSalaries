namespace RestaurantSalaries
{
    partial class SalaryCalculationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            hoursWorkedLabel = new Label();
            hourlyRateLabel = new Label();
            bonusLabel = new Label();
            deductionsLabel = new Label();
            salaryLabel = new Label();
            employeeLabel = new Label();
            calculateBtn = new Button();
            hourlyRateTxt = new TextBox();
            deductionsTxt = new TextBox();
            bonusTxt = new TextBox();
            hoursWorkedTxt = new TextBox();
            employeesDropdown = new ComboBox();
            salaryTxt = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // hoursWorkedLabel
            // 
            hoursWorkedLabel.Location = new Point(437, 248);
            hoursWorkedLabel.Name = "hoursWorkedLabel";
            hoursWorkedLabel.Size = new Size(177, 28);
            hoursWorkedLabel.TabIndex = 12;
            hoursWorkedLabel.Text = "Отработени часове";
            // 
            // hourlyRateLabel
            // 
            hourlyRateLabel.Location = new Point(214, 242);
            hourlyRateLabel.Name = "hourlyRateLabel";
            hourlyRateLabel.Size = new Size(145, 23);
            hourlyRateLabel.TabIndex = 11;
            hourlyRateLabel.Text = "Почсова ставка";
            // 
            // bonusLabel
            // 
            bonusLabel.Location = new Point(214, 342);
            bonusLabel.Name = "bonusLabel";
            bonusLabel.Size = new Size(100, 23);
            bonusLabel.TabIndex = 10;
            bonusLabel.Text = "Бонус";
            // 
            // deductionsLabel
            // 
            deductionsLabel.Location = new Point(449, 342);
            deductionsLabel.Name = "deductionsLabel";
            deductionsLabel.Size = new Size(100, 23);
            deductionsLabel.TabIndex = 9;
            deductionsLabel.Text = "Удръжки";
            // 
            // salaryLabel
            // 
            salaryLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            salaryLabel.Location = new Point(222, 455);
            salaryLabel.Name = "salaryLabel";
            salaryLabel.Size = new Size(123, 47);
            salaryLabel.TabIndex = 8;
            salaryLabel.Text = "Заплата:";
            // 
            // employeeLabel
            // 
            employeeLabel.Location = new Point(214, 148);
            employeeLabel.Name = "employeeLabel";
            employeeLabel.Size = new Size(100, 23);
            employeeLabel.TabIndex = 7;
            employeeLabel.Text = "Служител";
            // 
            // calculateBtn
            // 
            calculateBtn.BackColor = SystemColors.Control;
            calculateBtn.Location = new Point(322, 545);
            calculateBtn.Name = "calculateBtn";
            calculateBtn.Size = new Size(184, 63);
            calculateBtn.TabIndex = 6;
            calculateBtn.Text = "Изчисли";
            calculateBtn.UseVisualStyleBackColor = false;
            calculateBtn.Click += calculateBtn_Click;
            // 
            // hourlyRateTxt
            // 
            hourlyRateTxt.Location = new Point(214, 279);
            hourlyRateTxt.Name = "hourlyRateTxt";
            hourlyRateTxt.Size = new Size(182, 31);
            hourlyRateTxt.TabIndex = 5;
            // 
            // deductionsTxt
            // 
            deductionsTxt.Location = new Point(449, 373);
            deductionsTxt.Name = "deductionsTxt";
            deductionsTxt.Size = new Size(165, 31);
            deductionsTxt.TabIndex = 4;
            // 
            // bonusTxt
            // 
            bonusTxt.Location = new Point(214, 373);
            bonusTxt.Name = "bonusTxt";
            bonusTxt.Size = new Size(182, 31);
            bonusTxt.TabIndex = 3;
            // 
            // hoursWorkedTxt
            // 
            hoursWorkedTxt.Location = new Point(449, 279);
            hoursWorkedTxt.Name = "hoursWorkedTxt";
            hoursWorkedTxt.Size = new Size(165, 31);
            hoursWorkedTxt.TabIndex = 2;
            // 
            // employeesDropdown
            // 
            employeesDropdown.Location = new Point(214, 183);
            employeesDropdown.Name = "employeesDropdown";
            employeesDropdown.Size = new Size(400, 33);
            employeesDropdown.TabIndex = 1;
            // 
            // salaryTxt
            // 
            salaryTxt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            salaryTxt.Location = new Point(339, 455);
            salaryTxt.Name = "salaryTxt";
            salaryTxt.ReadOnly = true;
            salaryTxt.Size = new Size(167, 44);
            salaryTxt.TabIndex = 0;
            salaryTxt.Text = "";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(66, 29);
            label1.Name = "label1";
            label1.Size = new Size(688, 62);
            label1.TabIndex = 13;
            label1.Text = "Калкулатор за изчисляване на заплати";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(100, 82);
            label2.Name = "label2";
            label2.Size = new Size(625, 43);
            label2.TabIndex = 14;
            label2.Text = "(служи само за прогнозно изчисление и не променя заплатата)";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.calculator;
            pictureBox1.Location = new Point(30, 148);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 138);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // SalaryCalculationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(832, 644);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(salaryTxt);
            Controls.Add(employeesDropdown);
            Controls.Add(hoursWorkedTxt);
            Controls.Add(bonusTxt);
            Controls.Add(deductionsTxt);
            Controls.Add(hourlyRateTxt);
            Controls.Add(calculateBtn);
            Controls.Add(employeeLabel);
            Controls.Add(salaryLabel);
            Controls.Add(deductionsLabel);
            Controls.Add(bonusLabel);
            Controls.Add(hourlyRateLabel);
            Controls.Add(hoursWorkedLabel);
            Name = "SalaryCalculationForm";
            Text = "Изчисляване на заплата";
            Load += SalaryCalculationForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label hoursWorkedLabel;
        private Label hourlyRateLabel;
        private Label bonusLabel;
        private Label deductionsLabel;
        private Label salaryLabel;
        private Label employeeLabel;
        private Button calculateBtn;
        private TextBox hourlyRateTxt;
        private TextBox deductionsTxt;
        private TextBox bonusTxt;
        private TextBox hoursWorkedTxt;
        private ComboBox employeesDropdown;
        private RichTextBox salaryTxt;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
