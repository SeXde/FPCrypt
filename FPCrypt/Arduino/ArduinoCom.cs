﻿using System.IO.Ports;

namespace FPCrypt
{
    public delegate void Notify(string message);
    public static class ArduinoCom
    {
        private static SerialPort serialPort;
        private static string ACK_FP = "fingerprint:";
        private static string ACK_ALIVE = "replay";
        private static string ACK_DELETE = "done";
        private static string ACK_ERROR = "error";
        private static int TIME_OUT = 50;
        public static event Notify fingerprintEvents;


        public static string readFingerPrint()
        {
            var task = Task.Run(() => doReadFingerPrint());
            if (task.Wait(TimeSpan.FromSeconds(TIME_OUT)))
                return task.Result;
            else
                throw new Exception("Timeout");
        }

        public static string registerFingerPrint(int id)
        {
            var task = Task.Run(() => doRegisterFingerprint(id));
            if (task.Wait(TimeSpan.FromSeconds(TIME_OUT)))
                return task.Result;
            else
                throw new Exception("Timeout");
        }

        public static void deleteFingerPrint(int id)
        {
            var task = Task.Run(() => doDeleteFingerprint(id));
            if (!task.Wait(TimeSpan.FromSeconds(TIME_OUT)))
            {
                throw new Exception("Timeout");
            }
        }

        public static void clear()
        {
            var task = Task.Run(() => doClear());
            if (!task.Wait(TimeSpan.FromSeconds(TIME_OUT)))
            {
                throw new Exception("Timeout");
            }
        }


        private static string doReadFingerPrint()
        {
            setPort();
            string readedValue = string.Empty;
            serialPort.Write("Get fingerprint");

            do
            {
                Thread.Sleep(1000);
                readedValue = serialPort.ReadExisting();
                fingerprintEvents.Invoke(readedValue);
            } while (!readedValue.Contains(ACK_FP) && !readedValue.Contains(ACK_ERROR));

            if (readedValue.Contains(ACK_ERROR))
            {
                throw new Exception("Error trying to read fingerprint");
            }

            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            return readedValue.Replace(ACK_FP, "").Trim();
        }

        private static string doRegisterFingerprint(int id)
        {
            setPort();
            string readedValue = string.Empty;
            serialPort.Write("Register fingerprint:" + id);

            do
            {
                Thread.Sleep(500);
                readedValue = serialPort.ReadExisting();
                fingerprintEvents.Invoke(readedValue);
            } while (!readedValue.Contains(ACK_FP) && !readedValue.Contains(ACK_ERROR));

            if (readedValue.Contains(ACK_ERROR))
            {
                throw new Exception("Error trying to register fingerprint");
            }

            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            return readedValue.Replace(ACK_FP, "").Trim();

        }

        private static void doDeleteFingerprint(int id)
        {
            setPort();
            string readedValue = string.Empty;
            serialPort.Write("Delete fingerprint:" + id);

            do
            {
                Thread.Sleep(500);
                readedValue = serialPort.ReadExisting();
                fingerprintEvents.Invoke(readedValue);
            } while (!readedValue.Contains(ACK_DELETE) && !readedValue.Contains(ACK_ERROR));

            if (readedValue.Contains(ACK_ERROR))
            {
                throw new Exception("Error trying to delete fingerprint");
            }

            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }

        }

        private static void doClear()
        {
            setPort();
            string readedValue = string.Empty;
            serialPort.Write("Clear");

            do
            {
                Thread.Sleep(500);
                readedValue = serialPort.ReadExisting();
                fingerprintEvents.Invoke(readedValue);
            } while (!readedValue.Contains(ACK_DELETE) && !readedValue.Contains(ACK_ERROR));

            if (readedValue.Contains(ACK_ERROR))
            {
                throw new Exception("Error trying to clear db");
            }

            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }

        }

        private static void doWriteInfo(string info, string type)
        {
            setPort();
            string readedValue = string.Empty;
            do
            {
                serialPort.Write("Show " + type + ":" + info);
                Thread.Sleep(1010);
                readedValue = serialPort.ReadExisting();
                fingerprintEvents.Invoke(readedValue);
            } while (!readedValue.Contains(ACK_ALIVE) && !readedValue.Contains(ACK_ERROR));

            if (readedValue.Contains(ACK_ERROR))
            {
                throw new Exception("Error trying to write info");
            }

            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }


        public static void writeInfo(string info, string type)
        {
            var task = Task.Run(() => doWriteInfo(info, type));
            if (!task.Wait(TimeSpan.FromSeconds(TIME_OUT)))
                throw new Exception("Cannot communicate with Arduino");
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
                }
                catch (Exception exception)
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
