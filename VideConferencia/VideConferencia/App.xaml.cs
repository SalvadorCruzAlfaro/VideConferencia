using System;
using VideConferencia.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideConferencia
{
    public partial class App : Application
    {
        public static string KeyApi = "513ea304620949ab8024fbbe99573ceb";//"dee8f30897584b3a9220a0fcd42fec33"
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
