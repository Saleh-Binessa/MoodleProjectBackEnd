﻿namespace MoodleBackEnd.Models.Entites
{
    public class MaterialEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public int PhaseId { get; set; }
        public PhaseEntity Phase { get; set; }
        public List<TaskEntity> Tasks { get; set; }

        public MaterialEntity() { }
    }
}
