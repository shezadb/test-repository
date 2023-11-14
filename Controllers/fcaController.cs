using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionTargets.Models;
using Microsoft.EntityFrameworkCore;
namespace ProductionTargets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class fcaController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public fcaController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<FCA>> Get()
        {
            var items = await _dbContext.FCAs.ToListAsync();

            return items;
        }

        [HttpGet("{faultID}")]
        public async Task<FCA> Get(string faultID)
        {
            var item = await _dbContext.FCAs.FirstOrDefaultAsync(item => item.faultID == faultID);
            
            return item;
        }

        [HttpPut("{faultID}")]
        public async Task<bool> Update(FCA fca, string faultID)
        {
            var existingItem = await _dbContext.FCAs.FirstOrDefaultAsync(i => i.faultID == faultID);
            System.Console.WriteLine(existingItem.fault);
          //  existingItem.id = fca.id;
            existingItem.faultID = fca.faultID;
            existingItem.fault = fca.fault;
            existingItem.cause = fca.cause;
            System.Console.WriteLine(existingItem.cause);
            var result = await _dbContext.SaveChangesAsync();
            System.Console.WriteLine(result);
            return result > 0;
        }
        [HttpPost]
        public async Task<int> Create(FCA fca)
        {
            System.Console.WriteLine("cccc");
            System.Console.WriteLine(fca.cause);
            await _dbContext.FCAs.AddAsync(fca);
            await _dbContext.SaveChangesAsync();
            return fca.id;
        }
        //[HttpPut("{id}")]
        //public async Task<bool> Update(kpvItem item, int id)
        //{
        //    var existingItem = await _dbContext.kpvItems.FirstOrDefaultAsync(i => i.id == id);
        //    existingItem.TagName = item.TagName;
        //    existingItem.currentValue = item.currentValue;
        //    existingItem.Monday = item.Monday;
        //    existingItem.Tuesday = item.Tuesday;
        //    existingItem.Wednesday = item.Wednesday;
        //    existingItem.Thursday = item.Thursday;
        //    existingItem.Friday = item.Friday;
        //    existingItem.Saturday = item.Saturday;
        //    existingItem.Sunday = item.Sunday;
        //    var result = await _dbContext.SaveChangesAsync();
        //    return result > 0;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
