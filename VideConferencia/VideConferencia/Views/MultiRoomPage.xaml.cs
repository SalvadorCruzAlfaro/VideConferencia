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
    public partial class MultiRoomPage : ContentPage
    {
        private MultiRoomViewModel _viewModel;

        public MultiRoomPage(MultiRoomViewModel viewModel)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BindingContext = _viewModel = viewModel;
            _viewModel.Init();
        }

        public MultiRoomPage() : this(new MultiRoomViewModel("DesignTimeRoom"))
        {
        }

        protected override void OnDisappearing()
        {
            _viewModel.EndSessionCommand.Execute(false);
            base.OnDisappearing();
        }
    }
}