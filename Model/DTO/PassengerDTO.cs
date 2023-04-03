using AirDispetcher.Data;

namespace AirDispetcher.Model.DTO
{
    public class PassengerDTO
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Passport { get; set; }
        public bool IsSelected { get; set; }

        public List<PassengerDTO> GetPassengerDTO(List<Passenger> passengersList)
        {
            List < PassengerDTO > passengerDTOList = new List<PassengerDTO>();
            if (passengersList != null || passengersList.Count>0)
            {
                foreach(var elem in passengersList)
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
    }
}
