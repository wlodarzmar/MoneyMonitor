using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMonitor.Data;
using MoneyMonitor.Models;
using System;
using System.Security.Claims;

namespace FortuneMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WealthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public WealthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
            var wealth = new Wealth
            {
                Name = wealthDto.Name,
                OwnerId = User.FindFirst(x=>x.Type == ClaimTypes.NameIdentifier)?.Value
            };
            dbContext.Wealths.Add(wealth);
            dbContext.SaveChanges();

            var location = this.Url.Action(nameof(this.GetWealth), new { id = wealth.Id });

            return Created(location, wealthDto);
        }
    }

    public class WealthDto
    {
        public string Name { get; set; }
    }
}