
namespace IKA
{
    public class HornControl:ControlFromSocket, IHornControl
    {
         public HornControl(ICommandFormatter commandFormatter) : base( commandFormatter)
        {
        }

        public override void SendCommand()
        {
            string msg = _commandFormatter.HornCommand();
            SocketClient.SendData(msg);
        }
    }
}
