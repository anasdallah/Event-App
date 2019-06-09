using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mytry.Models
{
   public class EventV
    {
        [PrimaryKey,AutoIncrement]
        public int Id{ get; set; }
        public string Title { get; set; }

        public string Address{ get; set; }

        public string Detail { get; set; }

        public DateTime EventDate{ get; set; }

        public int VolunteerNo { get; set; }

    }
}
