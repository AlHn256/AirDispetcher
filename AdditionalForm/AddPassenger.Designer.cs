namespace AirDispetcher
{
    partial class AddPassenger
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
            AddPassengerButton = new Button();
            CancelButton = new Button();
            NameTextBox = new TextBox();
            NameLabel = new Label();
            SurnameLabel = new Label();
            SurnameTextBox = new TextBox();
            Patronymic = new Label();
            PatronymicTextBox = new TextBox();
            PassportNumberLabel = new Label();
            PassportNumberTextBox = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // AddPassengerButton
            // 
            AddPassengerButton.Location = new Point(10, 313);
            AddPassengerButton.Name = "AddPassengerButton";
            AddPassengerButton.Size = new Size(125, 23);
            AddPassengerButton.TabIndex = 0;
            AddPassengerButton.Text = "Add Passenger";
            AddPassengerButton.UseVisualStyleBackColor = true;
            AddPassengerButton.Click += AddPassengerButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(186, 313);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(125, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(146, 89);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(165, 23);
            NameTextBox.TabIndex = 2;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(10, 90);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(45, 15);
            NameLabel.TabIndex = 3;
            NameLabel.Text = "Name :";
            // 
            // SurnameLabel
            // 
            SurnameLabel.AutoSize = true;
            SurnameLabel.Location = new Point(10, 128);
            SurnameLabel.Name = "SurnameLabel";
            SurnameLabel.Size = new Size(60, 15);
            SurnameLabel.TabIndex = 5;
            SurnameLabel.Text = "Surname :";
            // 
            // SurnameTextBox
            // 
            SurnameTextBox.Location = new Point(146, 125);
            SurnameTextBox.Name = "SurnameTextBox";
            SurnameTextBox.Size = new Size(165, 23);
            SurnameTextBox.TabIndex = 4;
            // 
            // Patronymic
            // 
            Patronymic.AutoSize = true;
            Patronymic.Location = new Point(10, 165);
            Patronymic.Name = "Patronymic";
            Patronymic.Size = new Size(74, 15);
            Patronymic.TabIndex = 7;
            Patronymic.Text = "Patronymic :";
            // 
            // PatronymicTextBox
            // 
            PatronymicTextBox.Location = new Point(146, 162);
            PatronymicTextBox.Name = "PatronymicTextBox";
            PatronymicTextBox.Size = new Size(165, 23);
            PatronymicTextBox.TabIndex = 6;
            // 
            // PassportNumberLabel
            // 
            PassportNumberLabel.AutoSize = true;
            PassportNumberLabel.Location = new Point(12, 203);
            PassportNumberLabel.Name = "PassportNumberLabel";
            PassportNumberLabel.Size = new Size(105, 15);
            PassportNumberLabel.TabIndex = 9;
            PassportNumberLabel.Text = "Passport Number :";
            // 
            // PassportNumberTextBox
            // 
            PassportNumberTextBox.Location = new Point(148, 200);
            PassportNumberTextBox.Name = "PassportNumberTextBox";
            PassportNumberTextBox.Size = new Size(163, 23);
            PassportNumberTextBox.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(39, 21);
            label2.Name = "label2";
            label2.Size = new Size(171, 30);
            label2.TabIndex = 10;
            label2.Text = "New Passenger";
            // 
            // AddPassenger
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 359);
            Controls.Add(label2);
            Controls.Add(PassportNumberLabel);
            Controls.Add(PassportNumberTextBox);
            Controls.Add(Patronymic);
            Controls.Add(PatronymicTextBox);
            Controls.Add(SurnameLabel);
            Controls.Add(SurnameTextBox);
            Controls.Add(NameLabel);
            Controls.Add(NameTextBox);
            Controls.Add(CancelButton);
            Controls.Add(AddPassengerButton);
            Name = "AddPassenger";
            Text = "AddPassenger";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddPassengerButton;
        private Button CancelButton;
        private TextBox NameTextBox;
        private Label NameLabel;
        private Label SurnameLabel;
        private TextBox SurnameTextBox;
        private Label Patronymic;
        private TextBox PatronymicTextBox;
        private Label PassportNumberLabel;
        private TextBox PassportNumberTextBox;
        private Label label2;
    }
}