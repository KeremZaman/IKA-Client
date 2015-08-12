using System.Threading.Tasks;

namespace IKA.ViewModels
{
    public sealed class HeadlightViewModel : ViewModelBase
    {
        private HeadlightControl _headlightControl;
        public bool headlight1_isChecked
        {
            get { return HeadlightFeedback.headlight1; }
            set { HeadlightFeedback.headlight1 = value; }
        }
        public bool headlight2_isChecked
        {
            get { return HeadlightFeedback.headlight2; }
            set { HeadlightFeedback.headlight2 = value; }
        }
        public bool headlight3_isChecked
        {
            get { return HeadlightFeedback.headlight3; }
            set { HeadlightFeedback.headlight3 = value; }
        }
        public bool headlight4_isChecked
        {
            get { return HeadlightFeedback.headlight4; }
            set { HeadlightFeedback.headlight4 = value; }
        }
        public bool headlight5_isChecked
        {
            get { return HeadlightFeedback.headlight5; }
            set { HeadlightFeedback.headlight5 = value; }
        }
        public bool headlight6_isChecked
        {
            get { return HeadlightFeedback.headlight6; }
            set { HeadlightFeedback.headlight6 = value; }
        }
        public bool headlight7_isChecked
        {
            get { return HeadlightFeedback.headlight7; }
            set { HeadlightFeedback.headlight7 = value; }
        }
        public bool headlight8_isChecked
        {
            get { return HeadlightFeedback.headlight8; }
            set { HeadlightFeedback.headlight8 = value; }
        }
        public HeadlightViewModel(HeadlightControl headlightControl)
        {
            _headlightControl = headlightControl;
            HeadlightFeedback.PropertyChanged += (s, e) => { RaisePropertyChanged(""); };
        }
        public void RadioButtonHandler(string groupname, string content, bool isChecked)
        {
            HeadlightValues.HeadlightName = groupname;
            HeadlightValues.Choice = content;
            HeadlightValues.isChecked = isChecked;
            _headlightControl.SendCommand();
        }
    }
}