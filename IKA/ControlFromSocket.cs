
namespace IKA
{
    public abstract class ControlFromSocket : IControlFromSocket
    {
        protected readonly ICommandFormatter _commandFormatter;

        public ControlFromSocket(ICommandFormatter commandFormatter)
        {
            _commandFormatter = commandFormatter;
        }

        public virtual void SendCommand()
        {
            string msg = _commandFormatter.ReplaceTurkishCharacters("message");
            SocketClient.SendData(msg);
        }
    }
}
