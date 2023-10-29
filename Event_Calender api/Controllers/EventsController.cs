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
        public static List<Event> events = new List<Event>
        {
           new Event
           {
            Id = 1,
            Title = "Event 1",
            Start = DateTime.Now,
            End = DateTime.Now.AddHours(2)
            },
           new Event
           {
            Id = 2,
            Title = "Event 2",
            Start = DateTime.Now.AddHours(3),
            End = DateTime.Now.AddHours(5)
           },
            new Event
           {
            Id = 3,
            Title = "Event 3",
            Start = DateTime.Now.AddHours(3),
            End = DateTime.Now.AddHours(5)
           },


        };
        // GET: api/<EventsController>
        [HttpGet]
        public List<Event> Get()
        {
            return events;
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            Event event1 = events.Find(e => e.Id == id);
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
            int newEventId = events.Max(e => e.Id)+1;
            newEvent.Id = newEventId;
            events.Add(newEvent);         
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Event updateEvent)//update
        {
            if (updateEvent is null)
                return BadRequest("Invalid event data");
            Event eventToUpdate = events.Find(e => e.Id == id);
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
            Event newEvent=events.Find(e => e.Id == id);
            if(newEvent != null)
                events.Remove(newEvent);
        }
    }
}
