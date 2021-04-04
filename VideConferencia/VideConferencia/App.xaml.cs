using System;
using VideConferencia.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideConferencia
{
    public partial class App : Application
    {
        public static string KeyApi = "API_KEY";
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
