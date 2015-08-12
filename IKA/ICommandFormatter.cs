namespace IKA
{
    public interface ICommandFormatter
    {
        string ReplaceTurkishCharacters(string text);
        string HeadlightCommand();
        string HornCommand();

        string MotorCommand(string direction_way, int direction_angle, string acceleration_way, int speed_angle,
            int acceleration_time, int acceleration_distance);

        string BrakeCommand();
    }
}