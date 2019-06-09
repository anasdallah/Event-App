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
    public partial class HomePage : MasterDetailPage
    {
        List<Pages> pages = new List<Pages>
        {
            new Pages{Name="List Events", ImageSource="Event.png", Page=new EventList()},
            new Pages{Name="List Volunteer", ImageSource="Voulnteer.png", Page = new VolunteerList()},
            new Pages{Name="My Events",ImageSource="VolOnEve.png",Page=new EventVolunteerList() }


        };

        public HomePage()
        {
            InitializeComponent();
            lstMaster.ItemsSource = pages;
            IsPresented = true;
       }

        private void lstMaster_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           Pages p = e.Item as Pages;
            //p.Page.BindingContext = this.BindingContext as Volunteer;
            if(p.Name=="List Events")
              p.Page.BindingContext = new EventV ();

            Navigation.PushAsync(p.Page);
        }

        private void btnEditProfile_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Sorry!", "This Feature is coming soon", "Ok");
        }

        
    }
}