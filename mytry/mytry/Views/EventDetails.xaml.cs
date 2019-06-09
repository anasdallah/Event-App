using mytry.Models;
using SQLite;
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
    public partial class EventDetails : ContentPage
    {
        List<String> lsP = new List<String>()
        {
              "Amman",
              "Zarqa",
              "Irbid",
              "Jerash",
              "Mafraq",
              "Balqa" ,
              "Madaba",
              "Karak" ,
              "Tafilah",
              "Ma'an" ,
              "Aqaba" ,
              "Other country"
        };

        public EventDetails()
        {
            InitializeComponent();
            picker.ItemsSource = lsP;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            EventV eventV = this.BindingContext as EventV;
            Boolean answer = await DisplayAlert("Confirmation", "Are you sure you want to save?", "Yes", "No");
            if (answer)
            {
                if (eventV.Id == 0)
                {
                    eventV.Id = await App.MyEvVl.AddToEvent(eventV);
                }
                else
                {
                    await App.MyEvVl.UpdateEventAsync(eventV);
                }
                await Navigation.PopAsync();
            }
        }

        private async void tbiDelete_Clicked(object sender, EventArgs e)
        {
            Boolean answer = await DisplayAlert("Confirmation", "Are you sure you want to Delte the Event?", "Yes", "No");
            if (answer)
            {
                EventV eventV = this.BindingContext as EventV;
                await App.MyEvVl.DeleteEventAsync(eventV.Id);
                await Navigation.PopAsync();
            }
        }

      
    }
}