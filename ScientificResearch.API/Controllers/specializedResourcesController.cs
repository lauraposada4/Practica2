using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificResearch.API.Data;
using ScientificResearch.Shared.Entities;

namespace ScientificResearch.API.Controllers
{

    [ApiController]
    [Route("/api/specializedResources")]
    public class specializedResourcesController : ControllerBase
    {

        private readonly DataContext _context;


        public specializedResourcesController(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.specializedResources.ToListAsync());
        }

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {



            var specializedResource = await _context.specializedResources.FirstOrDefaultAsync(x => x.Id == id);

            if (specializedResource == null)
            {


                return NotFound();

            }



            return Ok(specializedResource);


        }

        [HttpPost]
        public async Task<ActionResult> Post(specializedResource specializedResources)
        {
            _context.Add(specializedResources);
            await _context.SaveChangesAsync();
            return Ok(specializedResources);
        }


        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(specializedResource specializedResource)
        {

            _context.Update(specializedResource);
            await _context.SaveChangesAsync();
            return Ok(specializedResource);



        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {



            var Filasafectadas = await _context.specializedResources

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
