using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificResearch.API.Data;
using ScientificResearch.Shared.Entities;

namespace ScientificResearch.API.Controllers
{
    [ApiController]
    [Route("/api/Publication")]
    public class PublicationsController : ControllerBase
    {



        private readonly DataContext _context;


        public PublicationsController(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Publications.ToListAsync());
        }

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {



            var publication = await _context.Publications.FirstOrDefaultAsync(x => x.Id == id);

            if (publication == null)
            {


                return NotFound();

            }



            return Ok(publication);


        }

        [HttpPost]
        public async Task<ActionResult> Post(Publication publications)
        {
            _context.Add(publications);
            await _context.SaveChangesAsync();
            return Ok(publications);
        }

        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Publication publication)
        {

            _context.Update(publication);
            await _context.SaveChangesAsync();
            return Ok(publication);



        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {



            var Filasafectadas = await _context.Publications

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

