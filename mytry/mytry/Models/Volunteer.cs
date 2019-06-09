using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mytry.Models
{
    public class Volunteer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
        public int PhoneNo { get; set; }
        public int Age { get; set; }

        public string JobTitle { get; set; }
        public bool IsAvilabel { get; set; }


        // public DateTime AvilabelFromDate { get; set; }

        //  public DateTime AvilabelToDate { get; set; }

        //  public DateTime AvilabelFromTime { get; set; }
        // public DateTime AvilabelToTime { get; set; }

    }
}
