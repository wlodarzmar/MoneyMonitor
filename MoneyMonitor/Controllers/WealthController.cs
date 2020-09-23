using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FortuneMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WealthController : ControllerBase
    {
        public WealthController()
        {
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetWealth(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create(WealthDto wealthDto)
        {
            var location = this.Url.Action(nameof(this.GetWealth), new { id = 0 });
            return Created(location, wealthDto);
        }
    }

    public class WealthDto
    {
        public string Name { get; set; }
    }
}