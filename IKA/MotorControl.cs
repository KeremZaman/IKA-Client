
namespace IKA
{
    public class MotorControl:ControlFromSocket, IMotorControl
    {
        public MotorControl(ICommandFormatter commandFormatter):base(commandFormatter){ }
        public override void SendCommand()
        {
            string msg = _commandFormatter.MotorCommand(MotorValue.direction_way, MotorValue.direction_angle,
                MotorValue.acceleration_way, MotorValue.acceleration_angle,MotorValue.acceleration_time,MotorValue.acceleration_distance);
            SocketClient.SendData(msg);
        }

    }
}
