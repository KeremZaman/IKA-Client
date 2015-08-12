using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;

namespace IKA
{
    public class ConnectionTemp:FeedbackBase
    {
        private static bool? _isConnected;
        public static Socket client { get; set; }
        public static string IPAdress { get; set; }
        public static string verificationID { get; set; }
        public static int PortNumber { get; set; }
        public static int ReconnectTry { get; set; }
        public static string Data { get; set; }

        public static bool? isConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                OnPropertyChanged("isConnected");
            }
        }
    }
}
