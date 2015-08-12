
namespace IKA
{
    public class HeadlightControl:ControlFromSocket, IHeadlightControl
    {
        public HeadlightControl(ICommandFormatter commandFormatter) : base( commandFormatter)
        {
        }

        public override void SendCommand()
        {
            string msg = _commandFormatter.HeadlightCommand();
            SocketClient.SendData(msg);
        }
    }
}
