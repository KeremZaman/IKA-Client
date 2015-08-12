using System.Text.RegularExpressions;

namespace IKA
{
    public class Validation:IValidation
    {
        const string ip_pattern = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
        const string port_pattern = @"\d";
        public bool ValidateIP(string ip)
        {
            if (ip != null)
            {
                var regex = new Regex(ip_pattern);
                var match = regex.Match(ip);
                return match.Success;
            }
            return false;
        }
        public bool ValidatePortNumber(string port)
        {
            if (port != null)
            {
                var regex = new Regex(port_pattern);
                var match = regex.Match(port);
                return match.Success;
            }
            return false;
        }
    }
}
