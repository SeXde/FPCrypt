using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FPCrypt.Tests
{
    [TestClass()]
    public class ArduinoComTests
    {
        [TestMethod()]
        public void ArduinoComTestSerialPort()
        {
            ArduinoCom arduinoCom = new ArduinoCom();
            Assert.IsNotNull(arduinoCom, "ArduinoCom should not be null if we instance the class.");
        }


        [TestMethod()]
        public void ArduinoComTestReadFingerprint()
        {
            ArduinoCom arduinoCom = new ArduinoCom();
            string fingerprint = arduinoCom.readFingerPrint();
            Assert.IsNotNull(fingerprint, "We should receive a non null string");
        }


        [TestMethod()]
        public void ArduinoComTestWriteInfo()
        {
            ArduinoCom arduinoCom = new ArduinoCom();
            arduinoCom.writeInfo("Hi qtpie", "info");
            Assert.IsNotNull(arduinoCom, "If we have established a connection it cannot not be null");
        }

    }
}
