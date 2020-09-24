using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MoneyMonitor.Data;
using System.Security.Claims;
using MoneyMonitor.Models;

namespace FortuneMonitor.Controllers
{
    [Route("api/wealth/{wealthId}/[controller]")]
    [Authorize]
    [ApiController]
    public class YearController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public YearController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetYears(int wealthId)
        {
            string userId = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var yearDtos = dbContext.Years
                .Where(x => x.WealthId == wealthId && x.Wealth.OwnerId == userId)
                .Select(ToYearDto)
                .ToList();

            return Ok(yearDtos);
        }

        private YearDto ToYearDto(Year year)
        {
            return new YearDto
            {
                Id = year.Id,
                Name = year.Name,
                Order = year.Order
            };
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetYear(int wealthId, int id)
        {
            Year year = dbContext.Years
                .Where(x => x.WealthId == wealthId && x.Id == id)
                .SingleOrDefault();

            return Ok(year);
        }

        [HttpPost]
        public IActionResult AddYear(int wealthId, YearDto yearDto)
        {
            Year year = this.ToYear(yearDto, wealthId, User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            dbContext.Years.Add(year);
            this.dbContext.SaveChanges();

            var location = this.Url.Action(nameof(this.GetYear), new { wealthId = wealthId, id = year.Id });
            return Created(location, ToYearDto(year));
        }

        private Year ToYear(YearDto dto, int wealthId, string userId)
        {
            return new Year
            {
                WealthId = wealthId,
                Name = dto.Name,
                Order = dto.Order
            };
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int wealthId, int id)
        {
            var year = dbContext.Years.Where(x => x.WealthId == wealthId && x.Id == id)
                .SingleOrDefault();

            dbContext.Years.Remove(year);
            dbContext.SaveChanges();

            return NoContent();
        }
    }

    public class YearDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
