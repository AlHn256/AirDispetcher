using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirDispetcher.Model
{
    internal class Flight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool IsDelet { get; set; }
        public List<Passenger> PassengersList { get; set; }

        public Flight(int id, string name, DateTime departureTime, DateTime arrivalTime, bool isDelet)
        {
            Id = id;
            Name = name;
            DepartureTime = ArrivalTime;
            ArrivalTime = arrivalTime;
            IsDelet = isDelet;
            PassengersList = new List<Passenger>();
        }

        public Flight(int id, string name, DateTime departureTime, DateTime arrivalTime,bool isDelet,List<Passenger> passengersList)
        {
            Id = id;
            Name = name;
            DepartureTime = ArrivalTime;
            ArrivalTime = arrivalTime;
            IsDelet = isDelet;
            PassengersList = passengersList;
        }


        public void AddPassengerList (List<Passenger> passengers)
        {
            PassengersList = passengers;
        }

        public void AddPassenger(Passenger passenger)
        {
            if (!PassengersList.Any(x => x.Id == passenger.Id))
            {
                PassengersList.Add(passenger);
            }
        }

        public void RemovePassenger(Passenger passenger)
        {
            PassengersList.Remove(passenger);
        }

    }
}
