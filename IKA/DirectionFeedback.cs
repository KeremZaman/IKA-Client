
namespace IKA
{
    public class DirectionFeedback:FeedbackBase
    {
        private static int _directionAngle;
        public static int DirectionAngle
        {
            get
            {
                return _directionAngle;
            }
            set
            {
                _directionAngle = value;
                OnPropertyChanged("DirectionAngle");
            }
        }
    }
}
