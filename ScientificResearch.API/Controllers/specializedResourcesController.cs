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

            [HttpPost]
            public async Task<ActionResult> Post(specializedResource specializedResources)
            {
                _context.Add(specializedResources);
                await _context.SaveChangesAsync();
                return Ok(specializedResources);
            }


        

    }
}
