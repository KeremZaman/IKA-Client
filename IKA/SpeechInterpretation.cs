using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IKA
{
    public class SpeechInterpretation : ISpeechInterpretation
    {
        private readonly IMotorControl _motorControl;
        private readonly IHeadlightControl _headlightControl;
        private readonly IHornControl _hornControl;
        private int number;
        private static Dictionary<string, long> numberTable = new Dictionary<string, long>
        {{"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},
        {"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},
        {"ten",10},{"eleven",11},{"twelve",12},{"thirteen",13},
        {"fourteen",14},{"fifteen",15},{"sixteen",16},
        {"seventeen",17},{"eighteen",18},{"nineteen",19},{"twenty",20},
        {"thirty",30},{"forty",40},{"fifty",50},{"sixty",60},
        {"seventy",70},{"eighty",80},{"ninety",90},{"hundred",100},
        {"thousand",1000},{"million",1000000}};

        public SpeechInterpretation(IMotorControl motorControl,IHeadlightControl headlightControl,IHornControl hornControl)
        {
            _motorControl = motorControl;
            _headlightControl = headlightControl;
            _hornControl = hornControl;
        }
        public void Interpret(string text)
        {
            text = text.Trim().ToLower();
            if (text.StartsWith("go"))
                Go(text);
            else if(text.StartsWith("brake"))
                Brake();
            else if (text.StartsWith("rotate"))
                Rotate(text);
            else if(text.StartsWith("turn on"))
                TurnOn(text);
            else if(text.StartsWith("turn off"))
                TurnOff(text);
            else if(text.StartsWith("blink on"))
                BlinkOn(text);
            else if (text.StartsWith("blink off"))
                BlinkOff(text);
            else if (text.StartsWith("sound") || text.StartsWith("hoot") || text.StartsWith("silence"))
                Hoot(text);
        }

        public long ExtractNumber(string numberString)
        {
            var numbers = Regex.Matches(numberString, @"\w+").Cast<Match>()
                   .Select(m => m.Value.ToLowerInvariant())
                   .Where(v => numberTable.ContainsKey(v))
                   .Select(v => numberTable[v]);
            long acc = 0, total = 0L;
            foreach (var n in numbers)
            {
                if (n >= 1000)
                {
                    total += (acc * n);
                    acc = 0;
                }
                else if (n >= 100)
                {
                    acc *= n;
                }
                else acc += n;
            }
            return (total + acc) * (numberString.StartsWith("minus",
                  StringComparison.InvariantCultureIgnoreCase) ? -1 : 1);

        }

        public void Go(string text)
        {
            Match match = Regex.Match(text, @"go (.+) (meter|second)");
            number = Convert.ToInt32(ExtractNumber(match.Groups[1].ToString()));
            var unit_of_measure = match.Groups[2].ToString();
            if (unit_of_measure == "meter")
            {
                MotorValue.acceleration_distance = number;
                MessageBox.Show("The feature has not been set yet.");
            }
            else if (unit_of_measure == "second")
                MotorValue.acceleration_time = number;
            MotorValue.acceleration_angle = 0;
            MotorValue.acceleration_way = "Forward";
            _motorControl.SendCommand();
        }

        public void Brake()
        {
            MessageBox.Show("The feature has not been set yet");
        }

        public void Rotate(string text)
        {
            Match match = Regex.Match(text, @"rotate (.+) degre(e|es) to (left|right)");
            number = Convert.ToInt32(ExtractNumber(match.Groups[1].ToString()));
            var rotation = match.Groups[3].ToString();
            if (rotation == "left")
                MotorValue.direction_way = "Left";
            else if (rotation == "right")
                MotorValue.direction_way = "Right";
            MotorValue.direction_angle = number;
            _motorControl.SendCommand();
        }

        public void TurnOn(string text)
        {
            var headlight = Regex.Match(text, @"turn on (.+)").Groups[1].ToString().Replace("headlight", "").Replace("eyes","").Trim();
            if (headlight != null)
            {
                HeadlightValues.HeadlightName = headlight;
                HeadlightValues.Choice = "On/Off";
                HeadlightValues.isChecked = true;
                _headlightControl.SendCommand();
            }
        }

        public void TurnOff(string text)
        {
            var headlight = Regex.Match(text, @"turn off (.+)").Groups[1].ToString().Replace("headlight", "").Replace("eyes", "").Trim();
            if (headlight != null)
            {
                HeadlightValues.HeadlightName = headlight;
                HeadlightValues.Choice = "On/Off";
                HeadlightValues.isChecked = false;
                _headlightControl.SendCommand();
                switch (headlight)
                {
                    case "left":
                        HeadlightFeedback.headlight1 = false;
                        break;
                    case "right":
                        HeadlightFeedback.headlight3 = false;
                        break;
                    case "top":
                        HeadlightFeedback.headlight5 = false;
                        break;
                    case "angel":
                        HeadlightFeedback.headlight7 = false;
                        break;
                }
            }
        }

        public void BlinkOn(string text)
        {
            var headlight = Regex.Match(text, @"blink on (.+)").Groups[1].ToString().Replace("headlight", "").Replace("eyes", "").Trim();
            if (headlight != null)
            {
                HeadlightValues.HeadlightName = headlight;
                HeadlightValues.Choice = "Blink";
                HeadlightValues.isChecked = true;
                _headlightControl.SendCommand();
            }
        }

        public void BlinkOff(string text)
        {
            var headlight = Regex.Match(text, @"blink off (.+)").Groups[1].ToString().Replace("headlight", "").Replace("eyes", "").Trim();
            if (headlight != null)
            {
                HeadlightValues.HeadlightName = headlight;
                HeadlightValues.Choice = "Blink";
                HeadlightValues.isChecked = false;
                _headlightControl.SendCommand();
                switch (headlight)
                {
                    case "left":
                        HeadlightFeedback.headlight2 = false;
                        break;
                    case "right":
                        HeadlightFeedback.headlight4 = false;
                        break;
                    case "top":
                        HeadlightFeedback.headlight6 = false;
                        break;
                    case "angel":
                        HeadlightFeedback.headlight8 = false;
                        break;
                }
            }

        }

        public void Hoot(string text)
        {
            if (text.StartsWith("sound"))
            {
                int time = Convert.ToInt32(ExtractNumber(Regex.Match(text, @"sound the horn for (.+) secon(d|ds)").Groups[1].ToString()));
                HornValue.isPressed = true;
                HornValue.time = time;
                _hornControl.SendCommand();
            }
            else if (text.StartsWith("hoot"))
            {
                HornValue.isPressed = true;
                HornValue.time = 0;
                _hornControl.SendCommand();
            }
            else
            {
                HornValue.isPressed = false;
                HornValue.time = 0;
                _hornControl.SendCommand();
            }
        }
    }
}
