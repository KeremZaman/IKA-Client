using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace IKA
{
    public static class GetFeedback
    {
        public static JObject feedback_json { get; set; }
        private static List<bool> headlights = new List<bool>() 
        { HeadlightFeedback.headlight1, HeadlightFeedback.headlight2, HeadlightFeedback.headlight3, HeadlightFeedback.headlight4, HeadlightFeedback.headlight5, HeadlightFeedback.headlight6, HeadlightFeedback.headlight7, HeadlightFeedback.headlight8 };
        private static List<bool> headlights_new = new List<bool>();
        public static void MainProcess(string json)
        {
            GetJSON(json);
            if (feedback_json["Headlights"] != null)
                SetValueForHeadlights();
            if (feedback_json["Speed"] != null)
                SpeedFeedback.Speed = Convert.ToDouble(feedback_json["Speed"]);
            if (feedback_json["DirectionAngle"] != null)
                DirectionFeedback.DirectionAngle = Convert.ToInt32(feedback_json["DirectionAngle"]);
                
        }
        public static void GetJSON(string json)
        {
            feedback_json= JObject.Parse(json);
        }

        public static void SetValueForHeadlights()
        {
            var open_headlights = headlights.Where(x => x == true).ToList();
            foreach (var onoff_headlight in feedback_json["Headlights"]["On/Off"].Children().ToList())
            {
                switch (onoff_headlight.ToString())
                {
                    case "left":
                        HeadlightFeedback.headlight1 = true;
                        break;
                    case "right":
                        HeadlightFeedback.headlight3 = true;
                        break;
                    case "top":
                        HeadlightFeedback.headlight5 = true;
                        break;
                    case "angel":
                        HeadlightFeedback.headlight7 = true;
                        break;
                }
            }
            foreach (var blink_headlight in feedback_json["Headlights"]["Blink"].Children().ToList())
            {
                switch (blink_headlight.ToString())
                {
                    case "left":
                        HeadlightFeedback.headlight2 = true;
                        break;
                    case "right":
                        HeadlightFeedback.headlight4 = true;
                        break;
                    case "top":
                        HeadlightFeedback.headlight6 = true;
                        break;
                    case "angel":
                        HeadlightFeedback.headlight8 = true;
                        break;
                }
            }
        }
    }
}
