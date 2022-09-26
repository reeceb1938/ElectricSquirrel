namespace Employment.Core.DTOs
{
    public class Shift
    {
        public int Id { get; set; }
        public Employer Employer { get; set; }
        public Role Role { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int BreakInMinutes { get; set; }
        public DateTime RecordedStartDateTime { get; set; }
        public DateTime RecordedEndDateTime { get; set; }
        public int RecordedBreakInMinutes { get; set; }
        public bool IsProspective { get; set; }
    }
}
