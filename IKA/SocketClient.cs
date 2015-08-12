using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using MessageBox = System.Windows.Forms.MessageBox;

namespace IKA
{
    public class SocketClient
    {
        public static bool RealTimeDataTransmmission = false;

        public SocketClient()
        {
            ConnectionTemp.PropertyChanged += (s, e) =>
            {
                if(ConnectionTemp.isConnected == false)
                    RealTimeDataTransmmission = false;
            };
        }
        public async static void Send()
        {
            try
            {
                // Create a TcpClient. 
                // Note, for this client to work you need to have a TcpServer  
                // connected to the same address as specified by the server, port 
                // combination.
                TcpClient client = new TcpClient(ConnectionTemp.IPAdress, ConnectionTemp.PortNumber);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(ConnectionTemp.Data);

                // Get a client stream for reading and writing. 
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                await stream.WriteAsync(data, 0, data.Length);


                // Receive the TcpServer.response. 

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                if (responseData == "failed")
                {
                    ConnectionTemp.isConnected = false;
                }
                else
                {
                    ConnectionTemp.isConnected = true;
                    GetFeedback.MainProcess(responseData);
                }

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                ConnectionTemp.isConnected = false;
                MessageBox.Show("Bağlantı kurulurken bir hata oluştu. \n Hata: {0}",e.Message);
            }
        }

        public async static void GetRealTimeData()
        {
            while (true)
            {
                if (ConnectionTemp.isConnected == true)
                    RealTimeDataTransmmission = true;
                    SendData("RT-Data");   
                Thread.Sleep(500);
            }
        }

        public static void Setup (string ipadress, int port)
            {
                ConnectionTemp.IPAdress = ipadress;
                ConnectionTemp.PortNumber = port;
                ConnectionTemp.ReconnectTry = 0;
                SendData("Request:" + ConnectionTemp.verificationID);
            }

        public static void SendData (string msg)
            {
                ConnectionTemp.Data = msg;
                var client = Task.Run(() => Send());
                if (!RealTimeDataTransmmission)
                {
                    var realtime = Task.Run(() => GetRealTimeData());
                }
            }
        }

    }