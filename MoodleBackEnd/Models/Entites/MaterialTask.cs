namespace MoodleBackEnd.Models.Entites
{
    public class MaterialTask
    {
        public int MaterialId { get; set; }
        public MaterialEntity Material { get; set; }

        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
    }

}
