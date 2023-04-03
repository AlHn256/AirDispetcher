namespace AirDispetcher
{
    partial class Form1
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
            TabControl = new TabControl();
            SearchTabPage = new TabPage();
            button1 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            SearchDataGridView = new DataGridView();
            FlightsTabPage = new TabPage();
            AddFlightButton = new Button();
            FlightDataGridView = new DataGridView();
            PassengersTabPage = new TabPage();
            AddPassenger = new Button();
            PassenerDataGridView = new DataGridView();
            RTB = new RichTextBox();
            TabControl.SuspendLayout();
            SearchTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SearchDataGridView).BeginInit();
            FlightsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FlightDataGridView).BeginInit();
            PassengersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PassenerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabControl.Controls.Add(SearchTabPage);
            TabControl.Controls.Add(FlightsTabPage);
            TabControl.Controls.Add(PassengersTabPage);
            TabControl.Location = new Point(4, 1);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(793, 470);
            TabControl.TabIndex = 0;
            // 
            // SearchTabPage
            // 
            SearchTabPage.Controls.Add(button1);
            SearchTabPage.Controls.Add(textBox2);
            SearchTabPage.Controls.Add(label2);
            SearchTabPage.Controls.Add(textBox1);
            SearchTabPage.Controls.Add(label1);
            SearchTabPage.Controls.Add(SearchDataGridView);
            SearchTabPage.Location = new Point(4, 24);
            SearchTabPage.Name = "SearchTabPage";
            SearchTabPage.Padding = new Padding(3);
            SearchTabPage.Size = new Size(785, 442);
            SearchTabPage.TabIndex = 0;
            SearchTabPage.Text = "Поиск рейса по номеру";
            SearchTabPage.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(412, 6);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Поиск";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(309, 6);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(88, 23);
            textBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(210, 9);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 3;
            label2.Text = "Время вылета : ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(101, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(88, 23);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 9);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 1;
            label1.Text = "Номер рейса : ";
            // 
            // SearchDataGridView
            // 
            SearchDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SearchDataGridView.Location = new Point(6, 35);
            SearchDataGridView.Name = "SearchDataGridView";
            SearchDataGridView.RowTemplate.Height = 25;
            SearchDataGridView.Size = new Size(773, 401);
            SearchDataGridView.TabIndex = 0;
            // 
            // FlightsTabPage
            // 
            FlightsTabPage.Controls.Add(AddFlightButton);
            FlightsTabPage.Controls.Add(FlightDataGridView);
            FlightsTabPage.Location = new Point(4, 24);
            FlightsTabPage.Name = "FlightsTabPage";
            FlightsTabPage.Padding = new Padding(3);
            FlightsTabPage.Size = new Size(785, 442);
            FlightsTabPage.TabIndex = 1;
            FlightsTabPage.Text = "Рейсы";
            FlightsTabPage.UseVisualStyleBackColor = true;
            // 
            // AddFlightButton
            // 
            AddFlightButton.Location = new Point(6, 411);
            AddFlightButton.Name = "AddFlightButton";
            AddFlightButton.Size = new Size(153, 23);
            AddFlightButton.TabIndex = 1;
            AddFlightButton.Text = "Добавить новый рейс";
            AddFlightButton.UseVisualStyleBackColor = true;
            AddFlightButton.Click += AddFlightButton_Click;
            // 
            // FlightDataGridView
            // 
            FlightDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FlightDataGridView.Location = new Point(6, 6);
            FlightDataGridView.Name = "FlightDataGridView";
            FlightDataGridView.RowTemplate.Height = 25;
            FlightDataGridView.Size = new Size(773, 399);
            FlightDataGridView.TabIndex = 0;
            // 
            // PassengersTabPage
            // 
            PassengersTabPage.Controls.Add(AddPassenger);
            PassengersTabPage.Controls.Add(PassenerDataGridView);
            PassengersTabPage.Location = new Point(4, 24);
            PassengersTabPage.Name = "PassengersTabPage";
            PassengersTabPage.Size = new Size(785, 442);
            PassengersTabPage.TabIndex = 3;
            PassengersTabPage.Text = "Пассажиры";
            PassengersTabPage.UseVisualStyleBackColor = true;
            // 
            // AddPassenger
            // 
            AddPassenger.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AddPassenger.Location = new Point(3, 409);
            AddPassenger.MaximumSize = new Size(200, 30);
            AddPassenger.MinimumSize = new Size(200, 29);
            AddPassenger.Name = "AddPassenger";
            AddPassenger.Size = new Size(200, 30);
            AddPassenger.TabIndex = 1;
            AddPassenger.Text = "Add New Passenger";
            AddPassenger.UseVisualStyleBackColor = true;
            AddPassenger.Click += AddPassenger_Click;
            // 
            // PassenerDataGridView
            // 
            PassenerDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PassenerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PassenerDataGridView.Location = new Point(4, 3);
            PassenerDataGridView.Name = "PassenerDataGridView";
            PassenerDataGridView.RowTemplate.Height = 25;
            PassenerDataGridView.Size = new Size(778, 400);
            PassenerDataGridView.TabIndex = 0;
            // 
            // RTB
            // 
            RTB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RTB.Location = new Point(4, 477);
            RTB.Name = "RTB";
            RTB.Size = new Size(789, 36);
            RTB.TabIndex = 1;
            RTB.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 517);
            Controls.Add(RTB);
            Controls.Add(TabControl);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            TabControl.ResumeLayout(false);
            SearchTabPage.ResumeLayout(false);
            SearchTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SearchDataGridView).EndInit();
            FlightsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FlightDataGridView).EndInit();
            PassengersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PassenerDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControl;
        private TabPage SearchTabPage;
        private TabPage FlightsTabPage;
        private TabPage PassengersTabPage;
        private DataGridView PassenerDataGridView;
        private RichTextBox RTB;
        private Button AddPassenger;
        private Button button1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private DataGridView SearchDataGridView;
        private Button AddFlightButton;
        private DataGridView FlightDataGridView;
    }
}