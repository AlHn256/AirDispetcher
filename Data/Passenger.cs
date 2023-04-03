namespace AirDispetcher.Data
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Passport { get; set; }
        public bool IsDelet { get; set; }
        public Passenger(int id, string fio, string passport)
        {
            Id = id;
            FIO = fio;
            Passport = passport;
            IsDelet = false;
        }

        public Passenger(int id, string fio, string passport, bool isDelet)
        {
            Id = id;
            FIO = fio;
            Passport = passport;
            IsDelet = isDelet;
        }
    }
}
