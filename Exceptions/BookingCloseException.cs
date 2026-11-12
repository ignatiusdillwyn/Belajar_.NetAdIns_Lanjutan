namespace Cinebook.Exceptions
{
    public class BookingCloseException : Exception
    {
        public BookingCloseException(string message = "waktu booking sudah tutup") : base(message) { }
    }
}
