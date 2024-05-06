using MoodleBackEnd.Models.Entites.Users;
using MoodleBackEnd.Models.Entites;

namespace MoodleBackEnd.Models.Responses
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
      //  public List<PhaseEntity> Phases { get; set; }
      //  public List<StudentEntity> Students { get; set; }
    }
}
