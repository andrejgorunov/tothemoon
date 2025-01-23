namespace ConferenceManagementSystem.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SpeakerId { get; set; }
        public virtual Speaker Speaker { get; set; }
        public string Status { get; set; }
    }
}