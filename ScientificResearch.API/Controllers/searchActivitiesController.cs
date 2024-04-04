using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificResearch.API.Data;
using ScientificResearch.Shared.Entities;

namespace ScientificResearch.API.Controllers
{
    [ApiController]
    [Route("/api/ searchActivities")]
    public class searchActivitiesController : ControllerBase
    {

        private readonly DataContext _context;


        public searchActivitiesController(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.searchActivities.ToListAsync());
        }

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {



            var searchActivity = await _context.searchActivities.FirstOrDefaultAsync(x => x.Id == id);

            if (searchActivity == null)
            {


                return NotFound();

            }



            return Ok(searchActivity);


        }

        [HttpPost]
        public async Task<ActionResult> Post(searchActivity searchActivities)
        {
            _context.Add(searchActivities);
            await _context.SaveChangesAsync();
            return Ok(searchActivities);
        }

        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(searchActivity searchActivity)
        {

            _context.Update(searchActivity);
            await _context.SaveChangesAsync();
            return Ok(searchActivity);



        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {



            var Filasafectadas = await _context.searchActivities

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
