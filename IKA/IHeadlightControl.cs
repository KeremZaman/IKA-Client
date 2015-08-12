namespace IKA
{
    public interface IHeadlightControl:IControlFromSocket
    {
        void SendCommand();
    }
}