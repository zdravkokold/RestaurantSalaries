namespace RestaurantSalaries.Forms
{
    partial class EmployeesForm
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
            employeesGridView = new DataGridView();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            formPanel = new Panel();
            saveButton = new Button();
            label2 = new Label();
            nameLabel = new Label();
            positionTextBox = new TextBox();
            nameTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)employeesGridView).BeginInit();
            formPanel.SuspendLayout();
            SuspendLayout();
            // 
            // employeesGridView
            // 
            employeesGridView.AllowUserToOrderColumns = true;
            employeesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeesGridView.Location = new Point(171, 39);
            employeesGridView.Name = "employeesGridView";
            employeesGridView.RowHeadersWidth = 62;
            employeesGridView.Size = new Size(394, 123);
            employeesGridView.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Location = new Point(171, 184);
            addButton.Name = "addButton";
            addButton.Size = new Size(102, 34);
            addButton.TabIndex = 1;
            addButton.Text = "Добави";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(289, 184);
            editButton.Name = "editButton";
            editButton.Size = new Size(128, 34);
            editButton.TabIndex = 2;
            editButton.Text = "Редактирай";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(436, 184);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(103, 34);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Изтрий";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // formPanel
            // 
            formPanel.Controls.Add(saveButton);
            formPanel.Controls.Add(label2);
            formPanel.Controls.Add(nameLabel);
            formPanel.Controls.Add(positionTextBox);
            formPanel.Controls.Add(nameTextBox);
            formPanel.Location = new Point(171, 274);
            formPanel.Name = "formPanel";
            formPanel.Size = new Size(368, 194);
            formPanel.TabIndex = 4;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(129, 136);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(112, 34);
            saveButton.TabIndex = 5;
            saveButton.Text = "Запази";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 37);
            label2.Name = "label2";
            label2.Size = new Size(84, 25);
            label2.TabIndex = 3;
            label2.Text = "Позиция";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(22, 37);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(47, 25);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Име";
            // 
            // positionTextBox
            // 
            positionTextBox.Location = new Point(213, 65);
            positionTextBox.Name = "positionTextBox";
            positionTextBox.Size = new Size(139, 31);
            positionTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(22, 65);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(143, 31);
            nameTextBox.TabIndex = 0;
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(764, 491);
            Controls.Add(formPanel);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(employeesGridView);
            Name = "EmployeesForm";
            Text = "EmployeesForm";
            ((System.ComponentModel.ISupportInitialize)employeesGridView).EndInit();
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView employeesGridView;
        private Button addButton;
        private Button editButton;
        private Button deleteButton;
        private Panel formPanel;
        private Label label2;
        private Label nameLabel;
        private TextBox positionTextBox;
        private TextBox nameTextBox;
        private Button saveButton;
    }
}