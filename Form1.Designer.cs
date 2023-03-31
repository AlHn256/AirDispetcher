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
            FlightsTabPage = new TabPage();
            PassengersTabPage = new TabPage();
            AddPassenger = new Button();
            PassenerDataGridView = new DataGridView();
            RTB = new RichTextBox();
            TabControl.SuspendLayout();
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
            SearchTabPage.Location = new Point(4, 24);
            SearchTabPage.Name = "SearchTabPage";
            SearchTabPage.Padding = new Padding(3);
            SearchTabPage.Size = new Size(785, 442);
            SearchTabPage.TabIndex = 0;
            SearchTabPage.Text = "Поиск рейса по номеру";
            SearchTabPage.UseVisualStyleBackColor = true;
            // 
            // FlightsTabPage
            // 
            FlightsTabPage.Location = new Point(4, 24);
            FlightsTabPage.Name = "FlightsTabPage";
            FlightsTabPage.Padding = new Padding(3);
            FlightsTabPage.Size = new Size(785, 442);
            FlightsTabPage.TabIndex = 1;
            FlightsTabPage.Text = "Рейсы";
            FlightsTabPage.UseVisualStyleBackColor = true;
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
            AddPassenger.Location = new Point(4, 410);
            AddPassenger.Name = "AddPassenger";
            AddPassenger.Size = new Size(125, 29);
            AddPassenger.TabIndex = 1;
            AddPassenger.Text = "Add New Passenger";
            AddPassenger.UseVisualStyleBackColor = true;
            AddPassenger.Click += AddPassenger_Click;
            // 
            // PassenerDataGridView
            // 
            PassenerDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PassenerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PassenerDataGridView.Location = new Point(0, 3);
            PassenerDataGridView.Name = "PassenerDataGridView";
            PassenerDataGridView.RowTemplate.Height = 25;
            PassenerDataGridView.Size = new Size(785, 401);
            PassenerDataGridView.TabIndex = 0;
            // 
            // RTB
            // 
            RTB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RTB.Location = new Point(4, 470);
            RTB.Name = "RTB";
            RTB.Size = new Size(789, 43);
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
    }
}