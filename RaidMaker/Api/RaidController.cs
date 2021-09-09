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
        public AddRaidResponse AddRaid([FromBody]AddRaidRequest request)
        {
            return new AddRaidResponse {Test = request.DiscordText};
        }
    }

    public class AddRaidRequest
    {
        public string DiscordText { get; set; }
    }

    public class AddRaidResponse
    {
        public string Test { get; set; }
    }
}