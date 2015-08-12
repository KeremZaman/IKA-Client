namespace IKA
{
    public interface IValidation
    {
        bool ValidateIP(string ip);
        bool ValidatePortNumber(string port);
    }
}