using Event_Calender_api.Entities;

namespace Event_Calender_api
{
    public class DataContext
    {
        public List<Event> Events { get; set; }
       public DataContext()
        {
            Events=new List<Event> { new Event { Id = 1,
            Title = "Event 1",
            Start = DateTime.Now,
            End = DateTime.Now.AddHours(2)},
                
             new Event  
            {Id = 2,
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
           }, };
        }
    }
}
