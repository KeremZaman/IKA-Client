using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using FirstFloor.ModernUI.Presentation;

namespace IKA.ViewModels
{
    public class MainViewModel : Screen//Conductor<IMainScreenTabItem>.Collection.OneActive
    {
        private const string WindowTitleDefault = "IKA - Kontrol Paneli";
        private string _windowTitle = WindowTitleDefault;
        public LinkGroupCollection MenuLinkGroups { get; private set; }
        private readonly ISpeechRecognizer _speechRecognizer;
        public MainViewModel(HeadlightViewModel headlightViewModel, ConnectionViewModel connectionViewModel,CameraViewModel cameraViewModel,ISpeechRecognizer speechRecognizer)
        {
            ViewModelsContainer.HeadlightViewModel = headlightViewModel;
            ViewModelsContainer.ConnectionViewModel = connectionViewModel;
            ViewModelsContainer.CameraViewModel = cameraViewModel;
            _speechRecognizer = speechRecognizer;
            _speechRecognizer.InitializeRecognizer();
        }
        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value;
                NotifyOfPropertyChange(() => WindowTitle);
            }
        }

        /* onMainKeyUp and onMainKeyDown provide access for SpeechRecognizer from everywhere. */
        public void onMainKeyUp(KeyEventArgs e)
        {
            if (Keyboard.IsKeyUp(Key.M))
                _speechRecognizer.EndRecognizing();
        }

        public void onMainKeyDown(KeyEventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.M))
                Task.Run(() => _speechRecognizer.StartRecognizing());
        }
            
    }

}
