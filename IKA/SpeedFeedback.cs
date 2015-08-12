

namespace IKA
{
    public  class SpeedFeedback:FeedbackBase
    {
        private static double _speed;
        public static double Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
                OnPropertyChanged("Speed");
            }
        }
    }
}
