namespace MoodleBackEnd.Models.Entites
{
    public class MaterialEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public ICollection<MaterialTask> Tasks { get; set; }
        public ICollection<PhaseMaterial> Phases { get; set; }

        public MaterialEntity() { }
    }
}
