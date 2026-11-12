using System.ComponentModel.DataAnnotations;

namespace CineBook.DTOs
{
    public class TheaterRequest
    {
        [Required(ErrorMessage = "Nama theater wajib diisi")]
        [MaxLength(100, ErrorMessage = "Nama theater maksimal 100 karakter")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255, ErrorMessage = "Lokasi maksimal 255 karakter")]
        public string Location { get; set; } = string.Empty;
    }
}
