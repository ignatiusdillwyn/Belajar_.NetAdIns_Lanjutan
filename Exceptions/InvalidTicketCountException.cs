namespace Cinebook.Exceptions
{
    public class InvalidTicketCountException : Exception
    {
        public InvalidTicketCountException(int totalTickets, int totalSeat, string message = "") : base($"Jumlah tiket {totalTickets} harus sama dengan jumlah kursi {totalSeat}") { }
    }
}
