using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificResearch.API.Data;
using ScientificResearch.Shared.Entities;

namespace ScientificResearch.API.Controllers
{
    [ApiController]
    [Route("/api/investigators")]
    public class InvestigatorsController : ControllerBase
    {

        private readonly DataContext _context;


        public InvestigatorsController(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Investigators.ToListAsync());
        }

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {



            var investigator = await _context.Investigators.FirstOrDefaultAsync(x => x.Id == id);

            if (investigator == null)
            {


                return NotFound();

            }



            return Ok(investigator);


        }




        [HttpPost]
        public async Task<ActionResult> Post(Investigator investigators)
        {
            _context.Add(investigators);
            await _context.SaveChangesAsync();
            return Ok(investigators);
        }

        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Investigator investigator)
        {

            _context.Update(investigator);
            await _context.SaveChangesAsync();
            return Ok(investigator);



        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {



            var Filasafectadas = await _context.Investigators

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



