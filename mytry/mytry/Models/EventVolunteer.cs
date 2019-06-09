using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mytry.Models
{
    public class EventVolunteer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int VolunteerId { get; set; }
        public int EventId { get; set; }
        public string Mark { get; set; }

      
    }
}
