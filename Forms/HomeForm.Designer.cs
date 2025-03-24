namespace RestaurantSalaries.Forms
{
    partial class HomeForm
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
            calculatorBtn = new Button();
            employeesBtn = new Button();
            mainPanel = new Panel();
            pictureBox2 = new PictureBox();
            returnButton = new Button();
            reportsBtn = new Button();
            regiterEmployeesBtn = new Button();
            pictureBox1 = new PictureBox();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // calculatorBtn
            // 
            calculatorBtn.Location = new Point(12, 400);
            calculatorBtn.Name = "calculatorBtn";
            calculatorBtn.Size = new Size(129, 72);
            calculatorBtn.TabIndex = 0;
            calculatorBtn.Text = "Изчисляване на заплати";
            calculatorBtn.UseVisualStyleBackColor = true;
            calculatorBtn.Click += calculatorBtn_Click;
            // 
            // employeesBtn
            // 
            employeesBtn.Location = new Point(12, 235);
            employeesBtn.Name = "employeesBtn";
            employeesBtn.Size = new Size(129, 72);
            employeesBtn.TabIndex = 1;
            employeesBtn.Text = "Служители";
            employeesBtn.UseVisualStyleBackColor = true;
            employeesBtn.Click += employeesBtn_Click;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(pictureBox2);
            mainPanel.Location = new Point(161, 12);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(927, 700);
            mainPanel.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.restaurant;
            pictureBox2.Location = new Point(241, 408);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(371, 212);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // returnButton
            // 
            returnButton.Location = new Point(12, 157);
            returnButton.Name = "returnButton";
            returnButton.Size = new Size(129, 68);
            returnButton.TabIndex = 2;
            returnButton.Text = "Начало";
            returnButton.UseVisualStyleBackColor = true;
            returnButton.Click += returnButton_Click;
            // 
            // reportsBtn
            // 
            reportsBtn.Location = new Point(12, 316);
            reportsBtn.Name = "reportsBtn";
            reportsBtn.Size = new Size(129, 72);
            reportsBtn.TabIndex = 3;
            reportsBtn.Text = "Справки и отчети";
            reportsBtn.UseVisualStyleBackColor = true;
            reportsBtn.Click += reportsBtn_Click;
            // 
            // regiterEmployeesBtn
            // 
            regiterEmployeesBtn.Location = new Point(12, 484);
            regiterEmployeesBtn.Name = "regiterEmployeesBtn";
            regiterEmployeesBtn.Size = new Size(129, 72);
            regiterEmployeesBtn.TabIndex = 4;
            regiterEmployeesBtn.Text = "Регистрирай служители";
            regiterEmployeesBtn.UseVisualStyleBackColor = true;
            regiterEmployeesBtn.Click += regiterEmployeesBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(129, 129);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1088, 654);
            Controls.Add(pictureBox1);
            Controls.Add(regiterEmployeesBtn);
            Controls.Add(reportsBtn);
            Controls.Add(returnButton);
            Controls.Add(mainPanel);
            Controls.Add(employeesBtn);
            Controls.Add(calculatorBtn);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Система за управление на възнагражденията в ресторант";
            mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button calculatorBtn;
        private Button employeesBtn;
        private Panel mainPanel;
        private Button returnButton;
        private Button reportsBtn;
        private Button regiterEmployeesBtn;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}