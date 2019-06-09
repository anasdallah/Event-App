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
    public partial class EventList : ContentPage
    {
        List<EventV> events = new List<EventV>();
        public static List<EventV> selectedEvents = new List<EventV>();



        public EventList()
        {
            InitializeComponent();
            lsvEvent.ItemsSource = events;
            tbiEventSelected.Text = "Add to My Event";
        }

        private async void lsvEvent_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            EventDetails eventDetails = new EventDetails()
            {
                Title = "Update Event"
            };
            eventDetails.BindingContext = e.Item as EventV;
            await Navigation.PushAsync(eventDetails);
        }



        private async void btnAddEvent_Clicked(object sender, EventArgs e)
        {
            EventV ev = new EventV();

            EventDetails eventDetails = new EventDetails()
            {
                BindingContext = ev,
                Title = "Create Event"

            };
            await Navigation.PushAsync(eventDetails);
        }

        private async void lsvEvent_Refreshing(object sender, EventArgs e)
        {
            events = await App.MyEvVl.GetAllEventAsync();
           
            lsvEvent.ItemsSource = events;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (this.Title.Equals("Filter By Address"))
            {

                EventV eventV = BindingContext as EventV;
                events = await App.MyEvVl.GetAllEventsByAddress(eventV.Address);
                foreach (var ee in events)
                {
                    await App.MyEvVl.SetVolunteerNo(ee.Id);
                }
                lsvEvent.ItemsSource = events;
            }
            else
            {
                events = await App.MyEvVl.GetAllEventAsync();
                
                lsvEvent.ItemsSource = events;
            }
        }

        private void lsvEvent_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }



        private async void tbiEventSelected_Clicked_1(object sender, EventArgs e)
        {
            selectedEvents.Add(lsvEvent.SelectedItem as EventV);

            if (selectedEvents.Count() != 0)
            {
                foreach (var selectedevents in selectedEvents)
                {
                    
                   
                    EventVolunteer eventVolunteer = new EventVolunteer
                    {
                        VolunteerId = Login.User.Id,
                        EventId = selectedevents.Id
                    };
                    eventVolunteer.Id = await App.MyEvVl.InsetIntoEVtable(eventVolunteer);
                }
                // await progressBar.ProgressTo(.99, 4000, Easing.Linear);

            }



        }



        private async void UpdateTheEvent_Clicked(object sender, EventArgs e)
        {
            EventDetails eventDetails = new EventDetails()
            {
                Title = "Update Event"
            };
            eventDetails.BindingContext = lsvEvent.SelectedItem as EventV;
            await Navigation.PushAsync(eventDetails);

        }

        private void btnFiltering_Clicked(object sender, EventArgs e)
        {
            EventV eventV = BindingContext as EventV;
            FilteringLists filtering = new FilteringLists();
            filtering.BindingContext = eventV;
            Navigation.PushAsync(filtering);
        }

        private void sbEvents_SearchButtonPressed(object sender, EventArgs e)
        {
            string searchKeyword = sbEvents.Text;
            IEnumerable<EventV> result = events.Where(ev => ev.Title.Contains(searchKeyword));
            if (result.Count() == 0)
                lsvEvent.ItemsSource = new List<EventV> { new EventV { Title = "not found" } };
            else
                lsvEvent.ItemsSource = result;
        }


        private void sbEvents_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchKeyword = e.NewTextValue;
            IEnumerable<EventV> result = events.Where(ev => ev.Title.Contains(searchKeyword));
            if (result.Count() == 0)
                lsvEvent.ItemsSource = new List<EventV> { new EventV { Title = "not found" } };
            else
                lsvEvent.ItemsSource = result;

        }

        private async void SortByTitle_Clicked(object sender, EventArgs e)
        {
            events = await App.MyEvVl.GetAllEventsOrderByAsce();
            lsvEvent.ItemsSource = events;
        }

        private async void SortByTitleDesc_Clicked(object sender, EventArgs e)
        {
            events = await App.MyEvVl.GetAllEventsOrderByDesc();
            lsvEvent.ItemsSource = events;
        }
    }
}
