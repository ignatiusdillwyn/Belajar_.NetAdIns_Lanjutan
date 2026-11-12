using Microsoft.AspNetCore.Mvc;
using CineBook.Services;
using CineBook.DTOs;
using Microsoft.AspNetCore.Authorization;
using Cinebook.Exceptions;

namespace CineBook.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBookings([FromQuery] string? status, [FromQuery] DateTime? date)
        {
            try
            {
                var bookings = await _bookingService.GetAllAsync(status, date);
                var response = bookings.Select(_bookingService.ToDetailResponse).ToList();
                return Ok(response);
            } catch (BookingCloseException)
            {
                throw;
            } catch (Exception ex)
            {
                throw;
            } finally
            {

            }
        }

        [HttpGet("{id:long}")]
        [Authorize]
        public async Task<IActionResult> GetBooking(long id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking == null) return NotFound();
            return Ok(_bookingService.ToDetailResponse(booking));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            try
            {
                long userId = long.Parse(User.FindFirst("userId")!.Value);

                var result = await _bookingService.CreateAsync(request, userId);
                if (result == null)
                    return Conflict(new { error = "Kursi sudah dipesan oleh pengguna lain" });

                return Created($"/api/bookings/{result.Id}", result);
            } catch (SeatNotAvailableException ex)
            {
                return Conflict(new
                {
                    status = "error",
                    message = ex.Message,
                });
            } catch (NotFoundException ex)
            {
                return NotFound(new
                {
                    status = "error",
                    message = ex.Message,
                });
            } catch (InvalidTicketCountException ex)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = ex.Message,
                });
            }
        }

        [HttpPut("{id:long}")]
        [Authorize]
        public async Task<IActionResult> UpdateBooking(long id, [FromBody] CreateBookingRequest request)
        {
            var result = await _bookingService.UpdateAsync(id, request);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        [Authorize]
        public async Task<IActionResult> CancelBooking(long id)
        {
            var success = await _bookingService.CancelAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
