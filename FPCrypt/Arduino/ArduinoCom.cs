using System.IO.Ports;
using System.Management;

namespace FPCrypt
{
    public class ArduinoCom
    {
        private SerialPort serialPort;
        private const string ACK_FP = "fingerprint:";
        private const string ACK_ALIVE = "replay";

        public ArduinoCom()
        {
            string arduinoPort = AutodetectArduinoPort();
            if (arduinoPort == null)
            {
                throw new Exception("Cannot find arduino port");
            }
            serialPort = new SerialPort(arduinoPort, 9600, Parity.None, 8, StopBits.One);
        }


        public string readFingerPrint()
        {
            checkConnection();
            string readedValue = string.Empty;
            serialPort.Open();
            serialPort.Write("Get fingerprint");

            do
            {
                readedValue = serialPort.ReadExisting();
                Thread.Sleep(200);
            } while (!readedValue.Contains(ACK_FP));

            serialPort.Close();
            return readedValue.Replace(ACK_FP, "");
        }


        public void writeInfo(string info, string type)
        {
            checkConnection();
            serialPort.Open();
            serialPort.Write("Show " + type + ":" + info);
            serialPort.Close();
        }


        private string AutodetectArduinoPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                // Do nothing
            }

            return null;
        }


        private void checkConnection()
        {
            serialPort.Open();
            int timeCounter = 0;
            int maxTimeWaiting = 10;
            string response = string.Empty;
            while (timeCounter < maxTimeWaiting && !ACK_ALIVE.Equals(response))
            {
                serialPort.Write("echo");
                response = serialPort.ReadExisting();
                Thread.Sleep(1000);
                timeCounter++;
            }
            serialPort.Close();
            if (timeCounter == maxTimeWaiting || !ACK_ALIVE.Equals(response))
            {
                throw new Exception("Cannot communicate with Arduino");
            }
        }
    }
}


