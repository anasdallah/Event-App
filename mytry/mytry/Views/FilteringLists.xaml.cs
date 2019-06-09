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
	public partial class FilteringLists : ContentPage
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
        public FilteringLists ()
		{
			InitializeComponent ();
            picker.ItemsSource = lsP;
        }

        private async void NavBack_Clicked(object sender, EventArgs e)
        {
            EventV eventV = BindingContext as EventV;
           eventV.Address = picker.SelectedItem.ToString();
            EventList eventList = new EventList() {
                BindingContext = eventV,
                Title = "Filter By Address"
            };
            await Navigation.PushAsync(eventList);
        }
    }
}