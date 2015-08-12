using System.Collections.Generic;
using System.Windows.Input;

namespace IKA.ViewModels
{
    public class CameraViewModel:ViewModelBase
    {
        private IMotorControl _motorControl;
        private readonly IHornControl _hornControl;
        private readonly IBrakeControl _brakeControl;
        private List<Key> motorKeys;
        public int direction_angle
        {
            get { return DirectionFeedback.DirectionAngle; }
            set { DirectionFeedback.DirectionAngle = value; }
        }
        public double speed
        {
            get { return SpeedFeedback.Speed; }
            set { SpeedFeedback.Speed = value; }
        }

        public CameraViewModel(IMotorControl motorControl,IHornControl hornControl,IBrakeControl brakeControl)
        {
            _hornControl = hornControl;
            _motorControl = motorControl;
            _brakeControl = brakeControl;
            SpeedFeedback.PropertyChanged += (s,e) => { RaisePropertyChanged("speed");};
            DirectionFeedback.PropertyChanged += (s, e) => { RaisePropertyChanged("direction_angle"); };
            motorKeys = new List<Key>() {Key.W,Key.A,Key.S,Key.D};
        }
        public void onKeyDown(KeyEventArgs e)
        {
            if (motorKeys.Contains(e.Key))   // W,A,S,D are used for direction controlling.
            {
                MotorValue.acceleration_time = 0;
                MotorValue.acceleration_distance = 0;
                if (Keyboard.IsKeyDown(Key.D))
                {
                    MotorValue.direction_way = "Right";
                    MotorValue.direction_angle = 1;
                }
                else if (Keyboard.IsKeyDown(Key.A))
                {
                    MotorValue.direction_way = "Left";
                    MotorValue.direction_angle = 1;
                }

                if (Keyboard.IsKeyDown(Key.W))
                {
                    MotorValue.acceleration_way = "Forward";
                    MotorValue.acceleration_angle = 1;
                }
                else if (Keyboard.IsKeyDown(Key.D))
                {
                    MotorValue.acceleration_way = "Backward";
                    MotorValue.acceleration_angle = 1;
                }
                _motorControl.SendCommand();
            }
            if (Keyboard.IsKeyDown(Key.Space) && !HornValue.isPressed) //Space is used for horn.
            {
                HornValue.isPressed = true;
                HornValue.time = 0;
                _hornControl.SendCommand();
            }
            if (Keyboard.IsKeyDown(Key.RightShift) && !BrakeValue.IsPressed) // Right Shift is used for brake.
            {
                BrakeValue.IsPressed = true;
                _brakeControl.SendCommand();
            }
        }

        public void onKeyUp(KeyEventArgs e)
        {
            if (Keyboard.IsKeyUp(Key.Space))
            {
                HornValue.isPressed = false;
                HornValue.time = 0;
                _hornControl.SendCommand();
            }
            if (Keyboard.IsKeyUp(Key.RightShift))
            {
                BrakeValue.IsPressed = false;
                _brakeControl.SendCommand();
            }
        }
    }
}
