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
    public partial class ConnectPage : ContentPage
    {
        private ConnectViewModel _viewModel;
        public ConnectPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BindingContext = _viewModel = new ConnectViewModel();
            RoomName.Keyboard = Keyboard.Create(KeyboardFlags.None);
        }

        private void Handle_OneToOne_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_viewModel.RoomName))
                Navigation.PushAsync(new RoomPage(new RoomViewModel(_viewModel.RoomName)));
        }

        private void Handle_Group_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_viewModel.RoomName))
                Navigation.PushAsync(new MultiRoomPage(new MultiRoomViewModel(_viewModel.RoomName)));
        }
    }
}