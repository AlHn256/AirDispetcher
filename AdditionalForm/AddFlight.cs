using AirDispetcher.Data;

namespace AirDispetcher.AdditionalForm
{
    public partial class AddFlight : Form
    {
        public AddFlight()
        {
            InitializeComponent();
        }

        private Flight flightVal;
        public Flight flight
        {
            get
            {
                return flightVal;
            }
            set
            {
                flightVal = value;
            }
        }

        private List<Passenger> passengerList = new List<Passenger>();

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SelectPassengersButton_Click(object sender, EventArgs e)
        {
            SelectPassengers selectPassengers = new SelectPassengers();
            selectPassengers.ShowDialog();
            if (selectPassengers.SelectedPassengerList != null)
            {
                passengerList = selectPassengers.SelectedPassengerList;
                NumberOfPassengerTextBox.Text = passengerList.Count.ToString();
            }
        }

        private void AddFlightButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string FlightName = FlightNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(FlightName)) FlightName = "FlightName_" + random.Next(int.MaxValue).ToString();

            flight = new Flight(0, FlightName, DepartureDateTimePicker.Value, ArrivalDateTimePicker.Value, false, passengerList);
            this.Hide();
        }
    }
}
