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
    public partial class Login : ContentPage
    {
        List<Volunteer> volunteers = new List<Volunteer>();
        public static Volunteer User { set; get; }
        public Login()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            volunteers = await App.MyEvVl.GetAllVolunteerAsync();
        }

        private async void btnSignin_Clicked(object sender, EventArgs e)
        {
            bool flag = false;

            foreach (var vol in volunteers)
            {
                if (vol.Name.Equals(entUsername.Text) && vol.Password.Equals(entPassword.Text))
                {
                    User = await App.MyEvVl.FindVolunteerByIdAsync(vol.Id);
                    HomePage homePage = new HomePage()
                    {
                        BindingContext = User,
                    };
                    await Navigation.PushAsync(homePage);
                    flag = true;
                }

            }

            if (!flag) { 
            await DisplayAlert("Error", "Username or password wrong! please try again.", "ok");
            }

        }

        private void btnSignUp_Clicked(object sender, EventArgs e)
        {
            Volunteer volunteer = new Volunteer();
            VolunteerDetails vd = new VolunteerDetails()
            {
                BindingContext = volunteer,
                Title = "Sign up"
            };
            Navigation.PushAsync(vd);
        }
    }
}