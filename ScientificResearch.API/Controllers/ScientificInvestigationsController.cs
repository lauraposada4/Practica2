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

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {



            var scientificInvestigation = await _context.ScientificInvestigations.FirstOrDefaultAsync(x => x.Id == id);

            if (scientificInvestigation == null)
            {


                return NotFound();

            }



            return Ok(scientificInvestigation);


        }

        [HttpPost]
        public async Task<ActionResult> Post(ScientificInvestigation scientificInvestigations)
        {
            _context.Add(scientificInvestigations);
            await _context.SaveChangesAsync();
            return Ok(scientificInvestigations);
        }

        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(ScientificInvestigation scientificInvestigation)
        {

            _context.Update(scientificInvestigation);
            await _context.SaveChangesAsync();
            return Ok(scientificInvestigation);



        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {



            var Filasafectadas = await _context.ScientificInvestigations

                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (Filasafectadas == 0)
            {


                return NotFound();

            }


            return NoContent();

        }

    }
}

