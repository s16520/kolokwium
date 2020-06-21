using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.DTOs.Requests
{
    public class AddPlayerRequest
    {
        [Required(ErrorMessage = "Name Required !")]
        [MaxLength(30)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Name Required !")]
        [MaxLength(50)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Name Required !")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Name Required !")]
        public int NumOnShirt { get; set; }
       
        public string? Comment { get; set; }
    }
}
