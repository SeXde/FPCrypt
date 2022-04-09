using System.IO.Ports;
using System.Management;

namespace FPCrypt
{
    public static class ArduinoCom
    {
        private static SerialPort serialPort;
        private static string ACK_FP = "fingerprint:";
        private static string ACK_ALIVE = "replay";


        public static string readFingerPrint()
        {
            setPort();
            string readedValue = string.Empty;
            serialPort.Write("Get fingerprint");

            do
            {
                readedValue = serialPort.ReadExisting();
                Thread.Sleep(200);
            } while (!readedValue.Contains(ACK_FP));

            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            return readedValue.Replace(ACK_FP, "");
        }


        public static void writeInfo(string info, string type)
        {
            setPort();
            string readedValue = string.Empty;
            do
            {
                serialPort.Write("Show " + type + ":" + info);
                Thread.Sleep(1005);
                readedValue = serialPort.ReadExisting();
            } while (!readedValue.Contains(ACK_ALIVE));
            
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }


        private static void setPort()
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            int i = 0;
            int maxPortNumber = 10;
            Exception ex;
            do
            {
                ex = null;
                serialPort.PortName = "COM" + i;
                try
                {
                    serialPort.Open();
                } catch(Exception exception)
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                    ex = exception;
                }
                i++;
            } while (ex != null && i < maxPortNumber);
            if (ex != null || i == maxPortNumber)
            {
                throw new Exception("Cannot find Arduino port");
            }
        }
    }
}


