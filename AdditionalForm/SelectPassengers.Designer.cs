namespace AirDispetcher.AdditionalForm
{
    partial class SelectPassengers
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
            SelectButton = new Button();
            CancelButton = new Button();
            PassengerListView = new DataGridView();
            PassengerListLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)PassengerListView).BeginInit();
            SuspendLayout();
            // 
            // SelectButton
            // 
            SelectButton.Location = new Point(12, 470);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(75, 23);
            SelectButton.TabIndex = 0;
            SelectButton.Text = "Select";
            SelectButton.UseVisualStyleBackColor = true;
            SelectButton.Click += SelectButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(108, 470);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // PassengerListView
            // 
            PassengerListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PassengerListView.Location = new Point(12, 62);
            PassengerListView.Name = "PassengerListView";
            PassengerListView.RowTemplate.Height = 25;
            PassengerListView.Size = new Size(558, 402);
            PassengerListView.TabIndex = 2;
            // 
            // PassengerListLabel
            // 
            PassengerListLabel.AutoSize = true;
            PassengerListLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            PassengerListLabel.Location = new Point(12, 9);
            PassengerListLabel.Name = "PassengerListLabel";
            PassengerListLabel.Size = new Size(150, 30);
            PassengerListLabel.TabIndex = 3;
            PassengerListLabel.Text = "Passenger List";
            // 
            // SelectPassengers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 505);
            Controls.Add(PassengerListLabel);
            Controls.Add(PassengerListView);
            Controls.Add(CancelButton);
            Controls.Add(SelectButton);
            Name = "SelectPassengers";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PassengerListView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SelectButton;
        private Button CancelButton;
        private DataGridView PassengerListView;
        private Label PassengerListLabel;
    }
}