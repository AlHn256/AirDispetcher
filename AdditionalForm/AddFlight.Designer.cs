namespace AirDispetcher.AdditionalForm
{
    partial class AddFlight
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
            SelectPassengersButton = new Button();
            CancelButton = new Button();
            AddFlightButton = new Button();
            FlightLabel = new Label();
            label2 = new Label();
            label3 = new Label();
            FlightNameTextBox = new TextBox();
            DepartureDateTimePicker = new DateTimePicker();
            ArrivalDateTimePicker = new DateTimePicker();
            label1 = new Label();
            label4 = new Label();
            NumberOfPassengerTextBox = new TextBox();
            SuspendLayout();
            // 
            // SelectPassengersButton
            // 
            SelectPassengersButton.Location = new Point(108, 244);
            SelectPassengersButton.Name = "SelectPassengersButton";
            SelectPassengersButton.Size = new Size(128, 23);
            SelectPassengersButton.TabIndex = 0;
            SelectPassengersButton.Text = "Select Passengers";
            SelectPassengersButton.UseVisualStyleBackColor = true;
            SelectPassengersButton.Click += SelectPassengersButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(152, 326);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(84, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddFlightButton
            // 
            AddFlightButton.Location = new Point(25, 326);
            AddFlightButton.Name = "AddFlightButton";
            AddFlightButton.Size = new Size(103, 23);
            AddFlightButton.TabIndex = 2;
            AddFlightButton.Text = "Add Flight";
            AddFlightButton.UseVisualStyleBackColor = true;
            AddFlightButton.Click += AddFlightButton_Click;
            // 
            // FlightLabel
            // 
            FlightLabel.AutoSize = true;
            FlightLabel.Location = new Point(25, 51);
            FlightLabel.Name = "FlightLabel";
            FlightLabel.Size = new Size(33, 15);
            FlightLabel.TabIndex = 3;
            FlightLabel.Text = "Рейс";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 111);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 4;
            label2.Text = "Время вылета:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 167);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 5;
            label3.Text = "Время прибытия:";
            // 
            // FlightNameTextBox
            // 
            FlightNameTextBox.Location = new Point(25, 69);
            FlightNameTextBox.Name = "FlightNameTextBox";
            FlightNameTextBox.Size = new Size(211, 23);
            FlightNameTextBox.TabIndex = 6;
            // 
            // DepartureDateTimePicker
            // 
            DepartureDateTimePicker.Location = new Point(25, 129);
            DepartureDateTimePicker.Name = "DepartureDateTimePicker";
            DepartureDateTimePicker.Size = new Size(211, 23);
            DepartureDateTimePicker.TabIndex = 9;
            // 
            // ArrivalDateTimePicker
            // 
            ArrivalDateTimePicker.Location = new Point(25, 185);
            ArrivalDateTimePicker.Name = "ArrivalDateTimePicker";
            ArrivalDateTimePicker.Size = new Size(211, 23);
            ArrivalDateTimePicker.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(25, 9);
            label1.Name = "label1";
            label1.Size = new Size(145, 30);
            label1.TabIndex = 11;
            label1.Text = "Новый рейс";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 226);
            label4.Name = "label4";
            label4.Size = new Size(124, 15);
            label4.TabIndex = 12;
            label4.Text = "Пасажиров на рейсе:";
            // 
            // NumberOfPassengerTextBox
            // 
            NumberOfPassengerTextBox.Location = new Point(25, 244);
            NumberOfPassengerTextBox.Name = "NumberOfPassengerTextBox";
            NumberOfPassengerTextBox.Size = new Size(57, 23);
            NumberOfPassengerTextBox.TabIndex = 13;
            NumberOfPassengerTextBox.Text = "0";
            NumberOfPassengerTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // AddFlight
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 361);
            Controls.Add(NumberOfPassengerTextBox);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(ArrivalDateTimePicker);
            Controls.Add(DepartureDateTimePicker);
            Controls.Add(FlightNameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(FlightLabel);
            Controls.Add(AddFlightButton);
            Controls.Add(CancelButton);
            Controls.Add(SelectPassengersButton);
            MaximumSize = new Size(280, 400);
            MinimumSize = new Size(280, 400);
            Name = "AddFlight";
            Text = "AddFlight";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SelectPassengersButton;
        private Button CancelButton;
        private Button AddFlightButton;
        private Label FlightLabel;
        private Label label2;
        private Label label3;
        private TextBox FlightNameTextBox;
        private DateTimePicker DepartureDateTimePicker;
        private DateTimePicker ArrivalDateTimePicker;
        private Label label1;
        private Label label4;
        private TextBox NumberOfPassengerTextBox;
    }
}