using mytry.Models;
using mytry.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mytry.Data
{
    public class DataAccess
    {
        private SQLiteAsyncConnection _database;
        public DataAccess()
        {
            _database = new SQLiteDatabase().GetConnectionAsync();
            _database.CreateTableAsync<Volunteer>();
            _database.CreateTableAsync<EventV>();
            _database.CreateTableAsync<EventVolunteer>();
            _database.ExecuteAsync("ALTER TABLE EventVolunteer" +
                                                " ADD CONSTRAINT FK_EventVolunteer_Volunteer" +
                                                " FOREIGN KEY (VolunteerId) REFERENCES Volunteer(Id)");
            _database.ExecuteAsync("ALTER TABLE EventVolunteer" +
                                                " ADD CONSTRAINT FK_EventVolunteer_EventV" +
                                                " FOREIGN KEY (EventId) REFERENCES EventV(Id)");

        }










        //event methods
        public Task<int> AddToEvent(EventV obj)
        {
            return _database.InsertAsync(obj);
        }
        public Task<List<EventV>> GetAllEventsByAddress(string Address)
        {
            return _database.Table<EventV>().Where(ev => ev.Address == Address).ToListAsync();
        }

        public Task<List<EventV>> GetAllEventsOrderByAsce()
        {
            return _database.Table<EventV>().OrderBy(ev => ev.Title).ToListAsync();
        }
        public Task<List<EventV>> GetAllEventsOrderByDesc()
        {
            return _database.Table<EventV>().OrderByDescending(ev => ev.Title).ToListAsync();
        }
        public Task<List<EventV>> GetAllEventAsync()
        {
            return _database.Table<EventV>().ToListAsync();
        }
        public async Task<EventV> GetEventsByIdAsync(int eventId)
        {
            return await _database.Table<EventV>().Where(e => e.Id == eventId).FirstOrDefaultAsync();
        }

        public Task<int> DeleteEventAsync(int id)
        {
            return _database.DeleteAsync<EventV>(id);
        }

        public Task<int> UpdateEventAsync(EventV obj)
        {
            return _database.UpdateAsync(obj);
        }
        public Task<EventV> FindEventByIdAsync(int EventId)
        {
            return _database.Table<EventV>().Where(ev => ev.Id == EventId).FirstOrDefaultAsync();
        }

        //volunteer methods
        public Task<int> AddToVolunteer(Volunteer obj)
        {
            return _database.InsertAsync(obj);
        }

        public Task<List<Volunteer>> GetAllVolunteerAsync()
        {
            return _database.Table<Volunteer>().ToListAsync();
        }

        public Task<int> DeleteVolunteerAsync(int id)
        {
            return _database.DeleteAsync<Volunteer>(id);
        }

        public Task<int> UpdateVolunteerAsync(Volunteer obj)
        {
            return _database.UpdateAsync(obj);
        }
        public Task<Volunteer> FindVolunteerByIdAsync(int volunteerId)
        {
            return _database.Table<Volunteer>().Where(v => v.Id == volunteerId).FirstOrDefaultAsync();
        }


        //EventVolunteer methods
        public Task<int> AddToEventVolunteer(EventVolunteer obj)
        {
            return _database.InsertAsync(obj);
        }

        public Task<List<EventVolunteer>> GetAllEventVolunteerAsync()
        {
            return _database.Table<EventVolunteer>().ToListAsync();
        }

        public Task<List<EventVolunteer>> FindByAsync(int eventId)
        {
            return _database.Table<EventVolunteer>().Where(evol => evol.VolunteerId == Login.User.Id && evol.EventId == eventId).ToListAsync();
        }

        public Task<List<Volunteer>> GetEventByAge(double age)
        {
            int ageInt = (int)Math.Ceiling(age);
            return _database.Table<Volunteer>().Where(ev => ev.Age >= ageInt - 5 && ev.Age <= ageInt + 5).ToListAsync();
        }

        public async Task<int> InsetIntoEVtable(EventVolunteer obj)
        {

            return await _database.InsertAsync(obj);
        }

        public async Task<List<EventVolunteer>> GetAllEventsForVolunteer()
        {
            return await _database.Table<EventVolunteer>().Where(ev => ev.VolunteerId == Login.User.Id).ToListAsync();
        }
        public async Task<List<EventVolunteer>> GetAllVolunteerNoForEvent()
        {
            return await _database.QueryAsync<EventVolunteer>("SELECT * FROM EventVolunteer GROUP BY VolunteerId");
        }

        public async Task<int> SetVolunteerNo(int eventid)
        {
            return await _database.ExecuteAsync(
                                                "Update EventV"
                                                +" SET VolunteerNo = ("
                                                +" SELECT COUNT(VolunteerId)"
                                                +" FROM EventVolunteer "
                                                +$" WHERE EventId = {eventid}"
                                                +" GROUP BY EventId)"
                                                + $" WHERE Id = {eventid}");
                                                
        }
    }
}
