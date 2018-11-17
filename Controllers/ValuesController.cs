using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace radioapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
/*        private radioapi.db.radioContext dbContext = new db.radioContext();

        // GET api/
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return dbContext.Radio.Select(r => $"{r.Id}: {r.Name}").ToList();
        }

        // GET api/1/top/5
        [HttpGet("{id}/top/{top}")]
        public ActionResult<IEnumerable<db.File>> Top(int id, int top=10)
        {
            return dbContext.File.Where(f => f.RadioId == id).OrderByDescending(f => f.CreatedOn).Take(top).ToList();
        }

        // GET api/1/dates
        [HttpGet("{id}/dates")]
        public ActionResult<IEnumerable<DateTime>> Dates(int id)
        {
            return dbContext.File.Where(f => f.RadioId == id).Select(f => (DateTime)f.CreatedOn.Date).Distinct().ToList();
        }*/
    }
}
