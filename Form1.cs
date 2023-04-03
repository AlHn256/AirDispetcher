using AirDispetcher.AdditionalForm;
using AirDispetcher.Data;
using AirDispetcher.Model;

namespace AirDispetcher
{
    public partial class Form1 : Form
    {
        private FileWork FileWork = new FileWork();
        private MainData MainData = new MainData();
        public Form1()
        {
            InitializeComponent();
            MainData = FileWork.LoadeData();
            ReloadDataGrid();
        }
        private void ReloadDataGrid()
        {
            
            var PassengersList = MainData.GetPassengersList();
            if (PassengersList.Count == 0)
            {
                RTB.Text += "\nСписок пассажиров пустой!";
            }
            else
            {
                BindingSource bind = new BindingSource { DataSource = PassengersList };
                PassenerDataGridView.DataSource = bind;
                //dataGreedRefresh();
            }

            var FlightList = MainData.GetFlightList();
            if (FlightList.Count == 0)
            {
                RTB.Text += "\nСписок рейсов пуст!";
            }
            else
            {
                BindingSource bind = new BindingSource { DataSource = FlightList };
                FlightDataGridView.DataSource = bind;
                //dataGreedRefresh();
            }
        }

        //private void dataGreedRefresh()
        //{
        //    PassenerDataGridView.Invalidate(true);
        //    PassenerDataGridView.Update();
        //    PassenerDataGridView.Refresh();
        //}

        private void AddFlightButton_Click(object sender, EventArgs e)
        {
            AddFlight addFlight = new AddFlight();
            addFlight.ShowDialog();
            if(addFlight.flight!=null)
            {
                //FileWork.AddFlight(addFlight.flight);
            }
        }

        private void AddPassenger_Click(object sender, EventArgs e)
        {
            AddPassenger addPassenger = new AddPassenger();
            addPassenger.ShowDialog();
            if (addPassenger.passenger != null)
            {
                FileWork.AddPassenger(addPassenger.passenger.FIO, addPassenger.passenger.Passport);
                RTB.Text += addPassenger.passenger.FIO + " добавлен\n";
                ReloadDataGrid();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileWork.SaveData();
        }

    }
}