using System.ComponentModel.DataAnnotations.Schema;

namespace CineBook.Models
{
    public class BookingSeat
    {
        public long Id { get; set; }

        [ForeignKey(nameof(Booking))]
        public long BookingId { get; set; }
        public Booking? Booking { get; set; }

        [ForeignKey(nameof(Seat))]
        public long SeatId { get; set; }
        public Seat? Seat { get; set; }
    }
}
