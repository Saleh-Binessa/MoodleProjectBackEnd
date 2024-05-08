namespace MoodleBackEnd.Models.Requests
{
    public class SubmissionRequest
    {
        public string SubmissionLink { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
