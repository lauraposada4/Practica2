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

            [HttpPost]
            public async Task<ActionResult> Post(Publication publications)
            {
                _context.Add(publications);
                await _context.SaveChangesAsync();
                return Ok(publications);
            }

        
    }

}

