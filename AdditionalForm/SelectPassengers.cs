using AirDispetcher.Data;
using AirDispetcher.Model;
using AirDispetcher.Model.DTO;

namespace AirDispetcher.AdditionalForm
{
    public partial class SelectPassengers : Form
    {
        private FileWork FileWork = new FileWork();
        //private List<Passenger> passengersList = new List<Passenger>();

        public SelectPassengers()
        {
            InitializeComponent();
            LoadPassergerList();
        }

        private List<Passenger> passengersListVal;

        public List<Passenger> passengersList
        {
            get
            {
                return passengersListVal;
            }
            set
            {
                passengersListVal = value;
            }
        }

        public List<Passenger> SelectedPassengerList;

        
        private void LoadPassergerList()
        {
            passengersListVal = FileWork.LoadPassengers();
            if (passengersListVal.Count != 0)
            {
                passengersListVal = passengersListVal.Where(x => x.IsDelet == false).ToList();
                List<PassengerDTO> passengerDTOList = new PassengerDTO().GetPassengerDTO(passengersListVal);
                //List<PassengerDTO> passengerDTOList = passengerDTO.GetPassengerDTO(passengersListVal);
                BindingSource bind = new BindingSource { DataSource = passengerDTOList };
                PassengerListView.DataSource = bind;
            }
        }


        private void SelectButton_Click(object sender, EventArgs e)
        {
            SelectedPassengerList = new List<Passenger>();
            for (int i = 0; i < PassengerListView.Rows.Count - 1; i++)
            {
                if ((bool)PassengerListView.Rows[i].Cells[3].Value)
                {
                    Passenger? passenger = passengersListVal.Where(x => x.Id == (int)PassengerListView.Rows[i].Cells[0].Value).FirstOrDefault();
                    if (passenger != null)
                    {
                        SelectedPassengerList.Add(passenger);
                    }
                }
            }
            this.Hide();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
