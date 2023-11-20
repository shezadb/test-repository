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
    public class kpvItemController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public kpvItemController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<kpvItem>> Get()
        {
            var items = await _dbContext.kpvItems.ToListAsync();

            return items;
        }

        [HttpGet("{id}")]
        public async Task<kpvItem> Get(int id)
        {
            var item = await _dbContext.kpvItems.FirstOrDefaultAsync(item => item.id == id);

            return item;
        }

        //[HttpGet()]
        //public async int Get()
        //{
        //    var item = await _dbContext.kpvItems.FromSqlRaw("",null);

        //    return 0;
        //}

        [HttpPost]
        public async Task<int> Create(kpvItem item)
        {
            await _dbContext.kpvItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return item.id;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(kpvItem item, int id)
        {
            var existingItem = await _dbContext.kpvItems.FirstOrDefaultAsync(i => i.id == id);
            existingItem.TagName = item.TagName;
            existingItem.currentValue = item.currentValue;
            existingItem.Monday = item.Monday;
            existingItem.Tuesday = item.Tuesday;
            existingItem.Wednesday = item.Wednesday;
            existingItem.Thursday = item.Thursday;
            existingItem.Friday = item.Friday;
            existingItem.Saturday = item.Saturday;
            existingItem.Sunday = item.Sunday;
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        //[HttpPut("{id}")]
        //public async Task<bool> UpdateValues(double dayVal, string dayStr, int id)
        //{
        //    var existingItem = await _dbContext.kpvItems.FirstOrDefaultAsync(i => i.id == id);

        //    existingItem.Monday = 1;

        //    var result = await _dbContext.SaveChangesAsync();

        //    return result > 0;
        //}

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext.kpvItems.FirstOrDefaultAsync(item => item.id == id);
            Console.WriteLine(item);
            _dbContext.kpvItems.Remove(item);
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }


    }
}
