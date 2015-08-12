using System.ComponentModel;
using Caliburn.Micro;

namespace IKA.ViewModels
{
    public class ViewModelBase : Screen, IMainScreenTabItem
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
