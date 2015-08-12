using System.ComponentModel;

namespace IKA
{
    public class FeedbackBase
    {
        public static event PropertyChangedEventHandler PropertyChanged;

        public static void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(new FeedbackBase(), new PropertyChangedEventArgs(propertyName));
        }
    }
}
