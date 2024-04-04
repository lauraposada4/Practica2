using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificResearch.API.Data;
using ScientificResearch.Shared.Entities;

namespace ScientificResearch.API.Controllers
{
    [ApiController]
    [Route("/api/ScientificInvestigations")]
    public class ScientificInvestigationsController : ControllerBase
    {


        private readonly DataContext _context;


        public ScientificInvestigationsController(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ScientificInvestigations.ToListAsync());

        }
        [HttpPost]
        public async Task<ActionResult> Post(ScientificInvestigation scientificInvestigations)
        {
            _context.Add(scientificInvestigations);
            await _context.SaveChangesAsync();
            return Ok(scientificInvestigations);
        }


    }
}

