using mytry.Data;
using mytry.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace mytry
{
    public partial class App : Application
    {
        private static DataAccess mystdc;
        public static DataAccess MyEvVl
        {
            get
            {
                if (mystdc is null)
                    mystdc = new DataAccess();
                return mystdc;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new HomePage());
            MainPage = new NavigationPage(new Login());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
