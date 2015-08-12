
namespace IKA
{
    public class BrakeControl:ControlFromSocket, IBrakeControl
    {
        public BrakeControl(ICommandFormatter commandFormatter) : base( commandFormatter)
        {
        }

        public override void SendCommand()
        {
            string msg = _commandFormatter.BrakeCommand();
            SocketClient.SendData(msg);
        }
    }
}
