#nullable enable

using System.ComponentModel.DataAnnotations;

namespace Commander.DTOs {
    public class CommandUpdateDTO {
        //Maps to our internal Command model
        [Required]
        [MaxLength(250)]
        public string? HowTo { get; set; }
        [Required]
        public string? Line { get; set; }
        [Required]
        public string? Platform { get; set; }
}

}