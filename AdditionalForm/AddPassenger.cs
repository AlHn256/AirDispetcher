using AirDispetcher.Data;

namespace AirDispetcher
{
    public partial class AddPassenger : Form
    {
        public AddPassenger()
        {
            InitializeComponent();
        }

        private Passenger passengerVal;
        public Passenger passenger
        {
            get
            {
                return passengerVal;
            }
            set
            {
                passengerVal = value;
            }
        }

        private void AddPassengerButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string FIO = SurnameTextBox.Text + " " + NameTextBox.Text + " " + PatronymicTextBox.Text;
            if (string.IsNullOrEmpty(FIO.Trim())) FIO = "TestFIO" + random.Next(int.MaxValue).ToString();
            string PassportNumber = string.IsNullOrEmpty(PassportNumberTextBox.Text.Trim()) ? random.Next(int.MaxValue).ToString() : PassportNumberTextBox.Text;
            passenger = new Passenger(0, FIO, PassportNumber);
            this.Hide();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
