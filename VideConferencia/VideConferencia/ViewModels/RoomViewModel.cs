using VideConferencia.Views;
using Xamarin.Agora.Full.Forms;
using Xamarin.Forms;

namespace VideConferencia.ViewModels
{
    public class RoomViewModel : BaseViewModel
    {
        private bool _isEnded = false;
        private IAgoraService _agoraService;

        private bool _isAudioMute;
        public bool IsAudioMute
        {
            get => _isAudioMute;
            set => SetProperty(ref _isAudioMute, value);
        }

        private bool _isVideoMute;
        public bool IsVideoMute
        {
            get => _isVideoMute;
            set => SetProperty(ref _isVideoMute, value);
        }

        private bool _isSpeakerEnabled;
        public bool IsSpeakerEnabled
        {
            get => _isSpeakerEnabled;
            set => SetProperty(ref _isSpeakerEnabled, value);
        }

        private bool _isCameraSwitched;
        public bool IsCameraSwitched
        {
            get => _isCameraSwitched;
            set => SetProperty(ref _isCameraSwitched, value);
        }

        public string Room { get; set; }

        public Command EndSessionCommand { get; }
        public Command AudioMuteCommand { get; }
        public Command VideoMuteCommand { get; }
        public Command SpeakerCommand { get; }
        public Command SwitchCameraCommand { get; }
        public Command VideoTapCommand { get; }

        public RoomViewModel(string roomName = null)
        {
            Title = roomName;
            Room = roomName;

            EndSessionCommand = new Command(OnEndSession);
            AudioMuteCommand = new Command(OnAudioMute);
            VideoMuteCommand = new Command(OnVideoMute);
            SpeakerCommand = new Command(OnSpeaker);
            SwitchCameraCommand = new Command(SwitchCamera);
            VideoTapCommand = new Command(TapVideo);
        }

        private void TapVideo(object param)
        {
            if (param is AgoraVideoView view)
            {
                //cycle through all video display modes
                var mode = (int)view.Mode + 1;
                view.Mode = (VideoDisplayMode)(mode < 4 ? mode : 1);
            }
        }

        private void SwitchCamera(object param)
        {
            IsCameraSwitched = !IsCameraSwitched;
            _agoraService.ToggleCamera();
        }

        private void OnSpeaker(object param)
        {
            IsSpeakerEnabled = !IsSpeakerEnabled;
            _agoraService.SetSpeakerEnabled(IsSpeakerEnabled);
        }

        private void OnAudioMute(object param)
        {
            IsAudioMute = !IsAudioMute;
            _agoraService.SetAudioMute(IsAudioMute);
        }

        private void OnVideoMute(object param)
        {
            IsVideoMute = !IsVideoMute;
            _agoraService.SetVideoMute(IsVideoMute);
        }

        private void OnEndSession(object param)
        {
            if (_isEnded)
            {
                return;
            }
            _isEnded = true;
            _agoraService.EndSession();
            if (param == null || (param is bool && (bool)param != false))
                (Application.Current.MainPage as MainPage).Detail.Navigation.PopAsync();
        }

        public  void Init()
        {
            _isEnded = false;
            if (_agoraService == null)
            {
                _agoraService = AgoraService.Current;
                _agoraService.JoinChannelSuccess += (uid) => { };
                _agoraService.OnDisconnected += OnDisconnected;
                _agoraService.OnNewStream += OnNewStream;
                _agoraService.StartSession(Room, App.KeyApi, webSdkInteroperability: true);
                //Grabar();
            }
        }

        private void OnNewStream(uint arg1, int arg2, int arg3)
        {

        }


        private void OnDisconnected(uint obj)
        {

        }
    }

    public class callerIdRequest
    {
        public string registratioId { get; set; }
    }

    public class callerIdResponse
    {
        public bool exitoso { get; set; }

        public int tipo { get; set; }

        //public string[] urlVideos { get; set; }

        public string registratioId { get; set; }
    }

}
