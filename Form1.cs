using AirDispetcher.AdditionalForm;
using AirDispetcher.Data;
using AirDispetcher.Data.DTO;
using AirDispetcher.Model;
using System.Drawing.Imaging;

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
            var FlightList = MainData.GetFlightList();
            var PassengersList = MainData.GetPassengersList();

            if (FlightList.Count == 0)
            {
                RTB.Text += "Список рейсов пуст!\n";
            }
            if (PassengersList.Count == 0)
            {
                RTB.Text += "Список пассажиров пустой!\n";
            }

            BindingSource bind = new BindingSource { DataSource = FlightList };
            FlightDataGridView.DataSource = bind;
            FlightDataGridView.AllowUserToAddRows = false;

            BindingSource PassenerBind = new BindingSource { DataSource = PassengersList };
            PassenerDataGridView.DataSource = PassenerBind;
            PassenerDataGridView.AllowUserToAddRows = false;

            ShowSearchPassenger(PassengersList);
        }

        private void ShowSearchPassenger(List<Passenger> passengers)
        {
            var SearchPassengerList = new Mapping().GetSearchPassengerDTO(passengers);
            BindingSource SearchPassengerBind = new BindingSource { DataSource = SearchPassengerList };
            SearchDataGridView.DataSource = SearchPassengerBind;
            SearchDataGridView.AllowUserToAddRows = false;
        }

        private void AddFlightButton_Click(object sender, EventArgs e)
        {
            AddFlight addFlight = new AddFlight();
            addFlight.ShowDialog();
            if (addFlight.flight != null)
            {
                MainData.AddFlights(addFlight.flight);
                RTB.Text += "Добавлен новый рейс " + addFlight.flight.Name + "\n";
                ReloadDataGrid();
            }
        }

        private void AddPassenger_Click(object sender, EventArgs e)
        {
            AddPassenger addPassenger = new AddPassenger();
            addPassenger.ShowDialog();
            if (addPassenger.passenger != null)
            {
                MainData.AddPassengers(addPassenger.passenger);
                RTB.Text += addPassenger.passenger.FIO + " добавлен\n";
                ReloadDataGrid();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            List<Passenger> passengers = new List<Passenger>();
            var flightIdList = MainData.GetFlightList().Where(x => x.DepartureTime == FlightDateTimePicker.Value && x.IsDelet == false).Select(x => x.Id).ToList();
            if (flightIdList.Count > 0)
            {
                var PassengerIdList = MainData.GetVTFlightPassengerList().Where(x => flightIdList.Contains(x.FlightId)).Select(x => x.PassengerId).ToList();
                passengers = MainData.GetPassengersList().Where(x => PassengerIdList.Contains(x.Id) && x.IsDelet == false).ToList();
            }

            //Если по дате вылета ни одного пасажира не найдено пробуем найти по номеру рейса если его конечно же ввели
            if (passengers.Count == 0)
            {
                passengers = SerchPassengerByFlightNumber();
            }

            if (passengers.Count == 0 && string.IsNullOrEmpty(FligtNumberTextBox.Text.Trim()))
            {
                RTB.Text = "Пасажиры не найдены!!!\n";
            }
            else
            {
                RTB.Text = string.Empty;
            }
            ShowSearchPassenger(passengers);
        }

        //Поиск пасажиров по номеру рейса
        private List<Passenger> SerchPassengerByFlightNumber()
        {
            int flightId = -1;
            List<Passenger> passengerList = new List<Passenger>();

            if (Int32.TryParse(FligtNumberTextBox.Text, out flightId))
            {
                var flightList = MainData.GetFlightList();
                if (flightList.Any(x => x.Id == flightId && x.IsDelet == false))
                {
                    var flight = flightList.Where(x => x.Id == flightId).FirstOrDefault();
                    if (flight != null)
                    {
                        FlightDateTimePicker.Value = flight.DepartureTime;
                    }

                    var VTFlightPassengerList = MainData.GetVTFlightPassengerList().Where(x => x.FlightId == flightId).Select(x => x.PassengerId);
                    if (VTFlightPassengerList.Count() > 0)
                        passengerList = MainData.GetPassengersList().Where(x => VTFlightPassengerList.Contains(x.Id) && x.IsDelet == false).ToList();
                }
            }

            return passengerList;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FligtNumberTextBox.Text.Trim()))
            {
                List<Passenger> passengers = SerchPassengerByFlightNumber();
                if (passengers.Count == 0)
                {
                    RTB.Text += "Пасажиры не найдены!!!\n";
                }
                ShowSearchPassenger(passengers);
            }
        }

        private void SaveDataMenuItem_Click(object sender, EventArgs e)
        {
            if (FileWork.SaveData(MainData))
                RTB.Text = "Информация сохранена\n";
        }

        //Сохраняем информацию при закрытии формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileWork.SaveData(MainData);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Excel file|*.xlsx|Excel 97-2003|*.xls",
                ValidateNames = true
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileWork = new FileWork(dialog.FileName);
                    MainData = FileWork.LoadeData();
                    ReloadDataGrid();
                }
            }
        }
    }
}