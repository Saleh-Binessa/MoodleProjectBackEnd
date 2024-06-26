﻿namespace MoodleBackEnd.Models.Entites
{
    public class SubmissionEntity
    {
        public int Id { get; set; }
        public string SubmissionLink { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public int TaskEntityId { get; set; }
        public TaskEntity Task { get; set; }
        public int GradeId { get; set; }
        public GradeEntity Grade { get; }
    }
}
