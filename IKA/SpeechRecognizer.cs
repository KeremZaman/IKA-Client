using System;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Recognition.SrgsGrammar;
using System.Xml;

namespace IKA
{
    public class SpeechRecognizer : ISpeechRecognizer
    {
        public static double validity = 0.82;
        public static SpeechRecognitionEngine recognizer;
        private static bool Continue;
        private readonly ISpeechInterpretation _speechInterpretation;

        public SpeechRecognizer(ISpeechInterpretation speechInterpretation)
        {
            _speechInterpretation = speechInterpretation;
        }
        public void InitializeRecognizer()
        {
            recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            string xmlGrammar = Environment.CurrentDirectory+"\\grammar.grxml";
            string cfgGrammar = Environment.CurrentDirectory+"grammar.cfg";
            FileStream fs = new FileStream(cfgGrammar, FileMode.Create);
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(xmlGrammar, settings);
            SrgsGrammarCompiler.Compile(reader, (Stream)fs);
            fs.Close();
            Grammar g = new Grammar(cfgGrammar, "commands");
            recognizer.LoadGrammar(g);
            recognizer.SpeechRecognized +=
            new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            recognizer.SetInputToDefaultAudioDevice();
        }
        public void StartRecognizing()
        {
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            Continue = true;
            while (Continue)
            {
                Console.WriteLine("...");
            }
        }

        public void EndRecognizing()
        {
            Continue = false;
            recognizer.RecognizeAsyncStop();
        }

         void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence >= validity)
            {
                _speechInterpretation.Interpret(e.Result.Text);
                Console.WriteLine("Recognized text: " + e.Result.Text);
            }
        }
    }
}
