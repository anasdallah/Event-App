using mytry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mytry.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventVolunteerList : ContentPage
    {
        public static List<EventV> selectedEvents = EventList.selectedEvents;

        List<EventVolunteer> eventVolunteers = new List<EventVolunteer>();


        List<EventV> myEventsList = new List<EventV>();
        List<EventV> testList = new List<EventV>();

        public EventVolunteerList()
        {
            InitializeComponent();

            //  progressBar.Progress = .2;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            // progressBar.IsVisible = true;

            eventVolunteers = await App.MyEvVl.GetAllEventsForVolunteer();
            if (eventVolunteers.Count() != 0)
            {
                foreach (var ev in eventVolunteers)
                {
                    EventV eventV = await App.MyEvVl.GetEventsByIdAsync(ev.EventId);
                    myEventsList.RemoveAll(eventt => eventt.Id == eventV.Id);
                    myEventsList.Add(eventV);
                }
                //progressBar.IsVisible = false;
            }
            if (myEventsList.Count() != 0)
            {
                // progressBar.IsVisible = false;
                //lsvEventForVolunteer.ItemsSource = myEventsList;
                lsvEventForVolunteer.ItemsSource = myEventsList;
            }

        }

        private async void lsvEventForVolunteer_Refreshing(object sender, EventArgs e)
        {
            eventVolunteers = await App.MyEvVl.GetAllEventsForVolunteer();
            if (eventVolunteers.Count() != 0)
            {
                foreach (var ev in eventVolunteers)
                {
                    EventV eventV = await App.MyEvVl.GetEventsByIdAsync(ev.EventId);
                    myEventsList.RemoveAll(eventt => eventt.Id == eventV.Id);

                    myEventsList.Add(eventV);
                }
                //progressBar.IsVisible = false;
            }
            if (myEventsList.Count() != 0)
            {
                // progressBar.IsVisible = false;
                //lsvEventForVolunteer.ItemsSource = myEventsList;
                lsvEventForVolunteer.ItemsSource = myEventsList;
            }
            lsvEventForVolunteer.EndRefresh();

        }
    }
}











