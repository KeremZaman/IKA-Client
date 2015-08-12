using System.Runtime.Serialization;
namespace IKA
{
    [DataContract]
    public class RootObject
    {
        [DataMember(IsRequired = true)]
        public string Client { get; set; }
        [DataMember(IsRequired = false)]
        public Headlight headlights { get; set; } 
        [DataMember(IsRequired = false)]
        public Horn horn { get; set; }
        [DataMember(IsRequired = false)]
        public Motor motor { get; set; }
        [DataMember(IsRequired = false)]
        public Brake brake { get; set; }
    }

    [DataContract]
    public class Headlight
    {
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string  Selection { get; set; }
        [DataMember(IsRequired = true)]
        public bool isChecked { get; set; }
    }

    [DataContract]
    public class Horn
    {
        [DataMember(IsRequired = true)]
        public bool IsPressed { get; set; }
        [DataMember(IsRequired = true)]
        public int Time { get; set; }
    }

    [DataContract]
    public class Motor
    {
        [DataMember(IsRequired = true)]
        public Direction Direction { get; set; }
        [DataMember(IsRequired = true)]
        public Acceleration Acceleration { get; set; }

    }

    [DataContract]
    public class Direction
    {
        [DataMember(IsRequired = true)]
        public string Way { get; set; }
        [DataMember(IsRequired = true)]
        public int Angle { get; set; }
    }

    [DataContract]
    public class Acceleration
    {
        [DataMember(IsRequired = true)]
        public string Way { get; set; }
        [DataMember(IsRequired = true)]
        public int Angle { get; set; }
        [DataMember(IsRequired = true)]
        public int Time { get; set; }
        [DataMember(IsRequired = true)]
        public int Distance { get; set; }
    }

    [DataContract]
    public class Brake
    {
        [DataMember(IsRequired = true)]
        public bool IsPressed { get; set; }
    }

    
}
