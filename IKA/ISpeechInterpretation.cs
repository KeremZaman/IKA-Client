namespace IKA
{
    public interface ISpeechInterpretation
    {
        void Interpret(string text);
        long ExtractNumber(string numberString);
        void Go(string text);
        void Brake();
        void Rotate(string text);
        void TurnOn(string text);
        void TurnOff(string text);
        void BlinkOn(string text);
        void BlinkOff(string text);
    }
}