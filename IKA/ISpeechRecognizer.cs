namespace IKA
{
    public interface ISpeechRecognizer
    {
        void InitializeRecognizer();
        void StartRecognizing();
        void EndRecognizing();
    }
}