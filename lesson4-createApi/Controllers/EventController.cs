using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson4_createApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    { 
           static  int count = 3;
        private readonly IDataContext _context;
        public EventController(IDataContext context)
        {
            _context = context;
        }
        // GET: api/<EventController>


        [HttpGet]
        public ActionResult Get()
        {
            //if(context.EventLists is null)
            //    return NotFound();
            return Ok(_context.EventLists);
        }

        //// GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var x= _context.EventLists.Find(ev=>ev.Id==id);
            if (x is null)
                return NotFound();
            return Ok(x);
        }

        // POST api/<EventController>
        [HttpPost]
        public ActionResult Post([FromBody] Event even)
        {
            //if (context.EventLists==null)
            //    return SignIn(context.EventLists)
            //context.EventLists.Add(new Event { Id = count++, Title = even.Title,Start=even.Start });
            if (string.IsNullOrEmpty(even.Title) || even.Start == null)
                return BadRequest();

            _context.EventLists.Add(new Event { Id = count++, Title = even.Title, Start = even.Start });

            return Ok();
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event even)
        {
            var x = _context.EventLists.Find(ev => ev.Id == id);
            if (x is null)
                return NotFound();

            _context.EventLists.Find(ev => ev.Id == id).Title = even.Title;
            _context.EventLists.Find(ev => ev.Id == id).Start = even.Start;
            return Ok(x);
        }
        

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var x = _context.EventLists.Find(ev => ev.Id == id);
            if (x is null)
                return NotFound();
            _context.EventLists.Remove(_context.EventLists.Find(ev => ev.Id == id));
            return Ok(x);
        }
    }
}
