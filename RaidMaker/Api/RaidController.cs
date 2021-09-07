using Microsoft.AspNetCore.Mvc;

namespace RaidMaker.Api
{
    public class RaidController : Controller
    {
        [HttpGet("api/raid/{reference}")]
        public void Do(string reference)
        {
            
        }

        [HttpPost("api/raid")]
        public void Post()
        {
            
        }
    }
}