using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using FirstFloor.ModernUI.Windows.Media;
using IKA.ViewModels;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using VlcControl = Vlc.DotNet.Wpf.VlcControl;

namespace IKA.Views
{
    /// <summary>
    /// Interaction logic for CameraView.xaml
    /// </summary>
    public partial class CameraView : UserControl
    {

        public CameraView()
        {
            InitializeComponent();
            this.DataContext = ViewModelsContainer.CameraViewModel;
            myControl.Visibility = Visibility.Visible;
            StopButton.Visibility = Visibility.Hidden;
            PlayButton.Visibility = Visibility.Visible;
            ConnectionTemp.PropertyChanged += (s, e) =>
            {
                string source = "http://" + ConnectionTemp.IPAdress + ":8080";
                myControl.Source = new Uri(source);
            };
            this.Loaded += (s,e) => { canvas.Focus(); };
        }

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            BeforeVideo.Visibility = Visibility.Hidden;
            PlayButton.Visibility = Visibility.Hidden;
            myControl.Visibility = Visibility.Visible;
            PlayVideo();
            StopButton.Visibility = Visibility.Visible;
            canvas.Focus();
        }

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            myControl.Pause();
            StopButton.Visibility = Visibility.Hidden;
            PlayButton.Visibility = Visibility.Visible;
            canvas.Focus();
        }

        private async void PlayVideo()
        {
            await PlayAsync();
        }

        private Task PlayAsync()
        {
            Task task = Task.Run(() => this.Dispatcher.Invoke(new Action(() => { myControl.Play(); })));
            return task;
        }
        
    }
}
