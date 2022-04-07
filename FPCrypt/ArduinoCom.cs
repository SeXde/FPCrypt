using System.IO.Ports;
using System.Management;

namespace FPCrypt
{
    public class ArduinoCom
    {
        private SerialPort serialPort;

        public ArduinoCom()
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            string arduinoPort = AutodetectArduinoPort();
            if (arduinoPort == null)
            {
                throw new Exception("Cannot find arduino port");
            }
            serialPort.PortName = arduinoPort;
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

    }
}
