#nullable enable

namespace Commander.DTOs {
    public class CommandReadDTO {
        public int Id { get; set; }

        public string? HowTo { get; set; }

        public string? Line { get; set; }

        // public string Platform { get; set; } //we can remove this if we don't want to show it to client
}

}