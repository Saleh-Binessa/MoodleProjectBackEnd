﻿namespace MoodleBackEnd.Models.Responses
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
