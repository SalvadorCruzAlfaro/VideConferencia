using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideConferencia.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace VideConferencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomPage : ContentPage
    {
        RoomViewModel viewModel;

        public RoomPage(RoomViewModel viewModel)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BindingContext = this.viewModel = viewModel;
            viewModel.Init();
        }

        public RoomPage() : this(new RoomViewModel("DesignTimeRoom"))
        {

        }

        protected override void OnDisappearing()
        {
            viewModel.EndSessionCommand.Execute(false);
            base.OnDisappearing();
        }
    }
}