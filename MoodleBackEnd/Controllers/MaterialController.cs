using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleBackEnd.Models.Entites;
using MoodleBackEnd.Models.Requests;
using MoodleBackEnd.Models.Responses;

namespace MoodleBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly MoodleContext _context;
        public MaterialController(MoodleContext context)
        {
            _context = context;
        }

       // [Authorize(Roles = "Admin,Instructor,Student")]
        [HttpGet]
        public ActionResult<List<MaterialResponse>> GetAllMaterials()
        {
            var materials = _context.Materials.Select(e => new MaterialResponse
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,

            }).ToList();
            return Ok(materials);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Instructor,Student")]
        public ActionResult<MaterialResponse> GetMaterialDetails(int id)
        {
            var material = _context.Materials.Find(id);
            if (material == null)
            {
                return NotFound();
            }
            var response = new MaterialEntity
            {
                Id = material.Id = id,
                Title = material.Title,
                Description = material.Description,
            };
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult AddMaterial(MaterialRequest request)
        {
            var material = new MaterialEntity()
            {

                Title = request.Title,
                Description = request.Description,
                Date = DateOnly.FromDateTime(request.Date),

            };
            _context.Materials.Add(material);
            _context.SaveChanges();
            return Ok(new { Message = "Material Added" });
        }


    }
}
