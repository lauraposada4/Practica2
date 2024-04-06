using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificResearch.API.Data;
using ScientificResearch.Shared.Entities;

namespace ScientificResearch.API.Controllers
{

    [ApiController]
    [Route("/api/ResearcherParticipations")]
    public class ResearcherParticipationsController : ControllerBase
    {

            private readonly DataContext _context;


        public ResearcherParticipationsController(DataContext context)
            {
                _context = context;
            }

            //Metodo Get - Lista
            [HttpGet]
            public async Task<ActionResult> Get()
            {
                return Ok(await _context.ResearcherParticipations.ToListAsync());
            }

            // Método Get- por Id
            [HttpGet("id:int")]
            public async Task<ActionResult> Get(int id)
            {



            var researcherParticipation = await _context.ResearcherParticipations.FirstOrDefaultAsync(x => x.Id == id);

                if (researcherParticipation == null)
                {


                    return NotFound();

                }



                return Ok(researcherParticipation);


            }




            [HttpPost]
            public async Task<ActionResult> Post(ResearcherParticipation researcherParticipations)
            {
                _context.Add(researcherParticipations);
                await _context.SaveChangesAsync();
                return Ok(researcherParticipations);
            }

            // Método actualizar
            [HttpPut]
            public async Task<ActionResult> Put(ResearcherParticipation researcherParticipation)
            {

                _context.Update(researcherParticipation);
                await _context.SaveChangesAsync();
                return Ok(researcherParticipation);



            }


            //Médoro eliminar registro
            [HttpDelete("id:int")]
            public async Task<ActionResult> Delete(int id)
            {



                var Filasafectadas = await _context.ResearcherParticipations

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
