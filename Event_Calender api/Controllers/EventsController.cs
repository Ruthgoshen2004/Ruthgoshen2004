using Event_Calender_api.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event_Calender_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        //BASE
        //PUBLIC BASE B = NEW BASE();
       private readonly DataContext _dataContext;
        public EventsController(DataContext context)
        {
            _dataContext = context;
        }
           
        // GET: api/<EventsController>
        [HttpGet]
        public List<Event> Get()
        {
            return _dataContext.Events;
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            Event event1 = _dataContext.Events.Find(e => e.Id == id);
            if (event1 is null)
                return NotFound();
            return event1;  
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event newEvent)//add
        {
            if(newEvent is null)
                Console.WriteLine("Invalid event data");
            int newEventId = _dataContext.Events.Max(e => e.Id)+1;
            newEvent.Id = newEventId;
            _dataContext.Events.Add(newEvent);         
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Event updateEvent)//update
        {
            if (updateEvent is null)
                return BadRequest("Invalid event data");
            Event eventToUpdate = _dataContext.Events.Find(e => e.Id == id);
            if (eventToUpdate is null)
                return NotFound();//לא מצא
            eventToUpdate.Title = updateEvent.Title;
            eventToUpdate.Start = updateEvent.Start;
            eventToUpdate.End = updateEvent.End;
            return NoContent();//מחזיר 204 מעדכן שהצליח ללא תוכן מוחזר
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Event newEvent= _dataContext.Events.Find(e => e.Id == id);
            if(newEvent != null)
                _dataContext.Events.Remove(newEvent);
        }
    }
}
 