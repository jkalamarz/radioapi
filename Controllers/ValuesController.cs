using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace radioapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private radioapi.Db.radioContext dbContext = new Db.radioContext();

        // GET api/
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return dbContext.Radio.Select(r => $"{r.Id}: {r.Name}").ToList();
        }

        // GET api/1/top/5
        [HttpGet("{id}/top/{top}")]
        public ActionResult<IEnumerable<Db.Program>> Top(int id, int top=10)
        {
            return dbContext.Program.Where(f => f.RadioId == id).OrderByDescending(f => f.Timestamp).Take(top).ToList();
        }

        // GET api/1/search/strefa
        [HttpGet("{id}/search/{filter}")]
        public ActionResult<IEnumerable<Db.Program>> Search(int id, string filter)
        {
            return dbContext.Program.Where(f => f.RadioId == id).Where(p => p.Title.Contains(filter) || p.Author.Contains(filter)).OrderByDescending(f => f.Timestamp).Take(50).ToList();
        }

        // GET api/1/dates
        [HttpGet("{id}/dates")]
        public ActionResult<IEnumerable<DateTime>> Dates(int id)
        {
            return dbContext.Program.FromSql("select distinct DATE(timestamp) as Timestamp from program where radio_id={0}", id).Select(p => p.Timestamp).ToList();
        }
    }
}
