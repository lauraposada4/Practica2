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

            [HttpPost]
            public async Task<ActionResult> Post(searchActivity searchActivities)
            {
                _context.Add(searchActivities);
                await _context.SaveChangesAsync();
                return Ok(searchActivities);
            }


        

    }
}
