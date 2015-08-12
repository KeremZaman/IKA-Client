using System.Text;
using Newtonsoft.Json;

namespace IKA
{
    public class CommandFormatter : ICommandFormatter
    {
        public string ReplaceTurkishCharacters(string text)
        {
            StringBuilder sb = new StringBuilder(text);
            string newText =
            sb
            .Replace("ç", "c")
            .Replace("ğ", "g")
            .Replace("ı", "i")
            .Replace("ö", "o")
            .Replace("ü", "u")
            .ToString();
            return newText;
        }

        public string HeadlightCommand()
        {
            Headlight headlights = new Headlight()
            {
                Name = ReplaceTurkishCharacters(HeadlightValues.HeadlightName),
                Selection = ReplaceTurkishCharacters(HeadlightValues.Choice),
                isChecked = HeadlightValues.isChecked
            };
            RootObject HeadlightJSON = new RootObject()
            {
                Client = "desktop",
                headlights = headlights
            };
            string jsonResult = JsonConvert.SerializeObject(HeadlightJSON);
            return jsonResult;
        }

        public string HornCommand()
        {
            Horn horn = new Horn()
            {
                IsPressed = HornValue.isPressed,
                Time = HornValue.time
            };
            RootObject HornJSON = new RootObject()
            {
                Client = "desktop",
                horn = horn
            };
            string jsonResult = JsonConvert.SerializeObject(HornJSON);
            return jsonResult;
        }

        public string MotorCommand(string direction_way,int direction_angle,string acceleration_way,int speed_angle,int acceleration_time,int acceleration_distance)
        {
            Direction direction = new Direction()
            {
                Way = direction_way,
                Angle = direction_angle
            };
            Acceleration acceleration = new Acceleration()
            {
                Way = acceleration_way,
                Angle = speed_angle,
                Time = acceleration_time,
                Distance = acceleration_distance
            };
            Motor motor = new Motor()
            {
                Direction = direction,
                Acceleration = acceleration
            };
            RootObject MotorJSON = new RootObject()
            {
                Client = "desktop",
                motor = motor
            };
            string jsonResult = JsonConvert.SerializeObject(MotorJSON);
            return jsonResult;
        }

        public string BrakeCommand()
        {
            Brake brake = new Brake()
            {
                IsPressed = BrakeValue.IsPressed
            };
            RootObject BrakeJSON = new RootObject()
            {
                Client = "desktop",
                brake = brake
            };
            string jsonResult = JsonConvert.SerializeObject(BrakeJSON);
            return jsonResult;
        }
    }
}
