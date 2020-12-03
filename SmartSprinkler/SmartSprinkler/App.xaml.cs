using Microsoft.WindowsAzure.MobileServices;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartSprinkler.Model;

namespace SmartSprinkler
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        public static MobileServiceClient MobileService = new MobileServiceClient("https://smartsprinklerapi.azurewebsites.net");

        public static Users user = new Users();
        public static int StringToNullableInt(string strNum)
        {
            int valor = Convert.ToInt32(strNum);
            return (valor);
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
