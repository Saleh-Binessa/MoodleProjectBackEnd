namespace MoodleBackEnd.Models.Entites
{
    public class PhaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseEntity Course { get; set; }
        public List<MaterialEntity> MaterialEntities { get; set; }
    }
}
