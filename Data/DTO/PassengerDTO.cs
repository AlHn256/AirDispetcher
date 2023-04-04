using AirDispetcher.Data;

namespace AirDispetcher.Data.DTO
{
    public class PassengerDTO
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Passport { get; set; }
        public bool IsSelected { get; set; }
    }
}
