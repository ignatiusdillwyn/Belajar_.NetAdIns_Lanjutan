namespace Cinebook.Exceptions
{
    public class SeatNotAvailableException : Exception
    {
        //Default Message
        public SeatNotAvailableException(string seatCode) : base($"Kursi {seatCode} sudah dipesan oleh pengguna lain") { }
    }
}
