

namespace IKA
{
    public class HeadlightFeedback:FeedbackBase
    {
        private static bool _headlight1;
        private static bool _headlight2;
        private static bool _headlight3;
        private static bool _headlight4;
        private static bool _headlight5;
        private static bool _headlight6;
        private static bool _headlight7;
        private static bool _headlight8;
        public static bool headlight1
        {
            get
            {
                return _headlight1;
            }
            set
            {
                _headlight1 = value;
                OnPropertyChanged("headlight1");
            }
        }
        public static bool headlight2
        {
            get
            {
                return _headlight2;
            }
            set
            {
                _headlight2 = value;
                OnPropertyChanged("headlight2");
            }
        }
        public static bool headlight3
        {
            get
            {
                return _headlight3;
            }
            set
            {
                _headlight3 = value;
                OnPropertyChanged("headlight3");
            }
        }
        public static bool headlight4
        {
            get
            {
                return _headlight4;
            }
            set
            {
                _headlight4 = value;
                OnPropertyChanged("headlight4");
            }
        }
        public static bool headlight5
        {
            get
            {
                return _headlight5;
            }
            set
            {
                _headlight5 = value;
                OnPropertyChanged("headlight5");
            }
        }
        public static bool headlight6
        {
            get
            {
                return _headlight6;
            }
            set
            {
                _headlight6 = value;
                OnPropertyChanged("headlight6");
            }
        }
        public static bool headlight7
        {
            get
            {
                return _headlight7;
            }
            set
            {
                _headlight7 = value;
                OnPropertyChanged("headlight7");
            }
        }
        public static bool headlight8
        {
            get
            {
                return _headlight8;
            }
            set
            {
                _headlight8 = value;
                OnPropertyChanged("headlight8");
            }
        }
    }
}
