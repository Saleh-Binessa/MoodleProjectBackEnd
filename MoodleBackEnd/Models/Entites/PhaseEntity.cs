namespace MoodleBackEnd.Models.Entites
{
    public class PhaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
        public List<MaterialEntity> Materials { get; set; }
        public PhaseEntity() { }
    }
}
