namespace MoodleBackEnd.Models.Entites
{
public class PhaseMaterial
{
    public int PhaseId { get; set; }
    public PhaseEntity Phase { get; set; }

    public int MaterialId { get; set; }
    public MaterialEntity Material { get; set; }
}

}
