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
    public partial class VolunteerList : ContentPage
    {
        List<Volunteer> volunteers = new List<Volunteer>();
        public VolunteerList()
        {
            InitializeComponent();
            lsvVolunteer.ItemsSource = volunteers;
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            volunteers = await App.MyEvVl.GetAllVolunteerAsync();
            lsvVolunteer.ItemsSource = volunteers;
        }



        private async void lsvVolunteer_Refreshing(object sender, EventArgs e)
        {
            volunteers = await App.MyEvVl.GetAllVolunteerAsync();
            lsvVolunteer.ItemsSource = volunteers;
        }



        private async void lsvVolunteer_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            VolunteerDetails volunteerDetails = new VolunteerDetails()
            {
                BindingContext = e.Item as Volunteer,
                Title = "Update Volunteer"
            };
           await Navigation.PushAsync(volunteerDetails);
        }

        private async void btnAddVolunteer_Clicked(object sender, EventArgs e)
        {
            Volunteer volunteer = new Volunteer();
            VolunteerDetails volunteerDetails = new VolunteerDetails()
            {
                BindingContext = volunteer,
                Title = "Add Volunteer"
            };

            await Navigation.PushAsync(volunteerDetails);
        }
        //private async void Age_ValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    lblSlider.Text = e.NewValue.ToString();
        //    List<Volunteer> byAge = await App.MyEvVl.GetEventByAge(e.NewValue);

        //}
    }
}