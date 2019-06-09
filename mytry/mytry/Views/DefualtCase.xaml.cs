using mytry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mytry.Views
{
    public partial class DefualtCase : ContentPage
    {
        public DefualtCase()
        {
            InitializeComponent();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            Boolean answer = await DisplayAlert("Confirmation", "Are you sure you want to save?", "Yes", "No");
            if (answer) {
                
                Volunteer vol = new Volunteer { Name = entstdName.Text };
                EventV evt= new EventV{ Title = entCouName.Text };
                EventVolunteer evtVol = new EventVolunteer { Mark = entMarks.Text };
                vol.Id = await App.Mystdc.AddToVolunteer(vol);
                evt.Id = await App.Mystdc.AddToEvent(evt);
                evtVol.Id = await App.Mystdc.AddToEventVolunteer(evtVol);



            }

        }

        private async void Show_Clicked(object sender, EventArgs e)
        {
            lsvEventVoulnteer.ItemsSource = await App.Mystdc.GetAllEventVolunteerAsync();
            lsvVolunteer.ItemsSource = await App.Mystdc.GetAllVolunteerAsync();
            lsvEvent.ItemsSource = await App.Mystdc.GetAllEventAsync();
        }
    }
}
