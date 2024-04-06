using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificResearch.API.Data;
using ScientificResearch.Shared.Entities;
using System.Reflection;

namespace ScientificResearch.API.Controllers
{
    [ApiController]
    [Route("/api/ResourceAllocations")]
    public class ResourceAllocationsController : ControllerBase
    {
        
        

            private readonly DataContext _context;


            public  ResourceAllocationsController(DataContext context)
            {
                _context = context;
            }

            //Metodo Get - Lista
            [HttpGet]
            public async Task<ActionResult> Get()
            {
                return Ok(await _context.ResourceAllocations.ToListAsync());
            }

            // Método Get- por Id
            [HttpGet("id:int")]
            public async Task<ActionResult> Get(int id)
            {



                var resourceAllocation = await _context.ResourceAllocations.FirstOrDefaultAsync(x => x.Id == id);

                if (resourceAllocation == null)
                {


                    return NotFound();

                }



                return Ok(resourceAllocation);


            }
        [HttpPost]
            public async Task<ActionResult> Post(ResourceAllocation resourceAllocations)
            {
                _context.Add(resourceAllocations);
                await _context.SaveChangesAsync();
                return Ok(resourceAllocations);
            }

            // Método actualizar
            [HttpPut]
            public async Task<ActionResult> Put(ResourceAllocation resourceAllocation)
            {

                _context.Update(resourceAllocation);
                await _context.SaveChangesAsync();
                return Ok(resourceAllocation);



            }


            //Médoro eliminar registro
            [HttpDelete("id:int")]
            public async Task<ActionResult> Delete(int id)
            {



                var Filasafectadas = await _context.ResourceAllocations

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
