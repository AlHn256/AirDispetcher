using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirDispetcher.Data.DTO
{
    internal class Mapping
    {
        public List<PassengerDTO> GetPassengerDTO(List<Passenger> passengersList)
        {
            List<PassengerDTO> passengerDTOList = new List<PassengerDTO>();
            if (passengersList != null || passengersList.Count > 0)
            {
                foreach (var elem in passengersList)
                {
                    passengerDTOList.Add(new PassengerDTO()
                    {
                        Id = elem.Id,
                        FIO = elem.FIO,
                        Passport = elem.Passport,
                        IsSelected = false
                    });
                }
            }
            return passengerDTOList;
        }

        public List<FlightPassengerDTO> GetSearchPassengerDTO(List<Passenger> passengersList)
        {
            List<FlightPassengerDTO> passengerDTOList = new List<FlightPassengerDTO> ();
            if (passengersList != null || passengersList.Count > 0)
            {
                foreach (var elem in passengersList)
                {
                    passengerDTOList.Add(new FlightPassengerDTO()
                    {
                        FIO = elem.FIO,
                        Passport = elem.Passport
                    });
                }
            }
            return passengerDTOList;
        }
    }
}
