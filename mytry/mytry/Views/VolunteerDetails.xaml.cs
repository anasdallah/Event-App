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
    public partial class VolunteerDetails : ContentPage
    {
        public VolunteerDetails()
        {
            InitializeComponent();

        }

        private void stpAge_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblAge.Text = e.NewValue.ToString();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            Volunteer volunteer= this.BindingContext as Volunteer;
            Boolean answer = await DisplayAlert("Confirmation", "Are you sure you want to save?", "Yes", "No");
            if (answer)
            {
                if (volunteer.Id == 0)
                {
                    volunteer.Id = await App.MyEvVl.AddToVolunteer(volunteer);
                }
                else
                {
                    await App.MyEvVl.UpdateVolunteerAsync(volunteer);
                }
                await Navigation.PopAsync();
            
            

            }
        }

        
    

    private async void tbiDelete_Clicked(object sender, EventArgs e)
        {
            Boolean answer = await DisplayAlert("Confirmation", "Are you sure you want to Delte the Event?", "Yes", "No");
            if (answer)
            {
                Volunteer volunteer = this.BindingContext as Volunteer;
                await App.MyEvVl.DeleteVolunteerAsync(volunteer.Id);
                await Navigation.PopAsync();
            }
        }
    }
}