using System.ComponentModel.DataAnnotations;


#nullable enable

namespace Commander.Models {
    public class Command {
        [Key]
        public int Id { get; set; }

        [Required] //attribute to specify value cannot be null
        [MaxLength(250)]
        public string? HowTo { get; set; }

        [Required]
        public string? Line { get; set; } //command line snippet we'll store in database

        [Required]
        public string? Platform { get; set; }
    }
}
