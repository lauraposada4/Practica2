using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificResearch.API.Data;
using ScientificResearch.Shared.Entities;

namespace ScientificResearch.API.Controllers
{
    [ApiController]
    [Route("/api/investigators")]
    public class InvestigatorsController: ControllerBase
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

            [HttpPost]
            public async Task<ActionResult> Post(Investigator investigators)
            {
                _context.Add(investigators);
                await _context.SaveChangesAsync();
                return Ok(investigators);
            }

        
    }

}

