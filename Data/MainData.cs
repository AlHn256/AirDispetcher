namespace AirDispetcher.Data
{
    internal class MainData
    {
        private List<Passenger> PassengersList { get; set; }
        private int LastPassengerId { get; set; }
        private List<Flight> FlightsList { get; set; }
        private int LastFlightsId { get; set; }
        private List<VTFlightPassenger> VTFlightPassengerList { get; set; }

        public MainData()
        {
            PassengersList = new List<Passenger>();
            LastPassengerId = 0;
            FlightsList= new List<Flight>();
            LastFlightsId = 0;
            VTFlightPassengerList = new List<VTFlightPassenger>();
        }
        public MainData(List<VTFlightPassenger> vtFlightPassengerList, List<Flight> flightsList, List<Passenger> passengersList)
        {
            AddPassengersList(passengersList);
            AddFlightsList(flightsList);
            AddVTFlightPassengerList(vtFlightPassengerList);
        }

        public List<Passenger> GetPassengersList()
        {
            return PassengersList;
        }

        public List<Flight> GetFlightList()
        {
            return FlightsList;
        }
        public List<VTFlightPassenger> GetVTFlightPassengerList()
        {
            return VTFlightPassengerList;
        }

        public void AddPassengersList(List<Passenger> passengersList)
        {
            PassengersList = passengersList;
            if (PassengersList.Count != 0)
            {
                LastPassengerId = PassengersList.Max(x => x.Id);
            }
            else LastPassengerId = 0;
        }

        public void AddFlightsList(List<Flight> flightsList)
        {
            FlightsList = flightsList;
            
            if (FlightsList.Count != 0)
            {
                LastFlightsId = FlightsList.Max(x => x.Id);
            }
            else LastFlightsId = 0;
        }

        public void AddVTFlightPassengerList(List<VTFlightPassenger> vtFlightPassengerList)
        {
            VTFlightPassengerList = vtFlightPassengerList;
        }

        public void AddPassengers(Passenger passenger)
        {
            passenger.Id = ++LastPassengerId;
            PassengersList.Add(passenger);
        }

        public void AddFlights(Flight flight)
        {
            flight.Id= ++LastFlightsId;
            FlightsList.Add(flight);
            if (flight.PassengersList != null)
            {
                if (flight.PassengersList.Count != 0)
                {foreach(var Passenger in flight.PassengersList)
                    {
                        AddVTFlightPassenger(new VTFlightPassenger()
                        {
                            PassengerId = Passenger.Id,
                            FlightId = flight.Id
                        });
                    }
                }
            }
        }

        private bool CheckVFTCopy(VTFlightPassenger vtFlightPassenger)
        {
            return VTFlightPassengerList.Any(x => x.PassengerId == vtFlightPassenger.PassengerId && x.FlightId == vtFlightPassenger.FlightId);
        }
        public void AddVTFlightPassenger(VTFlightPassenger vtFlightPassenger)
        {
            if (!CheckVFTCopy(vtFlightPassenger))
            VTFlightPassengerList.Add(vtFlightPassenger);
        }
    }
}
