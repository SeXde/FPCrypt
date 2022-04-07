using System.IO.Ports;
using System.Management;

namespace FPCrypt
{
    public class ArduinoCom
    {
        private SerialPort serialPort;
        private const string ACK_FP = "fingerprint:";

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
            // TODO
        }

    }
}

