using System;

namespace IKA.ViewModels
{
    public sealed class ConnectionViewModel : ViewModelBase
    {
        private Validation _validation;
        private string _ipAdress;
        private string _port;
        private string _msg;
        private string _verificationID;
        private string _connectionStatus;
        private string _connectionColor;
        public string ipAdress
        {
            get { return _ipAdress; }
            set
            {
                _ipAdress = value;
                NotifyOfPropertyChange(() => ipAdress);
            }
        }
        public string port
        {
            get { return _port; }
            set
            {
                _port = value;
                NotifyOfPropertyChange(() => port);
            }
        }

        public string verificationID
        {
            get { return _verificationID; }
            set
            {
                _verificationID = value;
                NotifyOfPropertyChange(() => verificationID);
            }
        }
        public string msg
        {
            get { return _msg; }
            set
            {
                if (_msg != value)
                {
                    _msg = value;
                    RaisePropertyChanged("msg");
                    NotifyOfPropertyChange(() => msg);
                }
            }
        }

        public string connectionStatus
        {
            get
            {
                if (ConnectionTemp.isConnected == true)
                {
                    _connectionStatus = "Bağlandı.";
                    connectionColor = "LimeGreen";
                }
                else if (ConnectionTemp.isConnected == false)
                {
                    _connectionStatus = "Bağlanamadı.";
                    connectionColor = "Red";
                }
                else
                {
                    _connectionStatus = "Bağlantı yok.";
                    connectionColor = "White";
                }
                return _connectionStatus;
            }
            set
            {
                if (_connectionStatus != value)
                {
                    _connectionStatus = value;
                    RaisePropertyChanged("connectionStatus");
                    NotifyOfPropertyChange(() => connectionStatus);
                }
            }
        }
        public string connectionColor
        {
            get { return _connectionColor; }
            set
            {
                if (_connectionColor != value)
                {
                    _connectionColor = value;
                    RaisePropertyChanged("connectionColor");
                    NotifyOfPropertyChange(() => connectionColor);
                }
            }
        }

        public ConnectionViewModel(Validation validation)
        {
            _validation = validation;
            ConnectionTemp.PropertyChanged += (s,e) => { RaisePropertyChanged("connectionStatus"); };
            DisplayName = "Bağlantı Ayarları";
        }

        public void Validate() // Do validation for IP and port inputs.
        {
            var isValidIP = _validation.ValidateIP(ipAdress);
            var isValidPort = _validation.ValidatePortNumber(port);

            if (isValidIP && isValidPort)
            {
                msg = "";
                int port_number = Convert.ToInt32(port);
                ConnectionTemp.verificationID = verificationID;
                Connect(ipAdress,port_number);
            }
            else
            {
                msg = "Hatalı!";
            }
        }
        public void Connect(string ip,int port)
        {
            SocketClient.Setup(ip,port);
        }

        
    }
}

