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
            Assert.IsNotNull(arduinoCom);
        }


        [TestMethod()]
        public void ArduinoComTestReadFingerprint()
        {
            ArduinoCom arduinoCom = new ArduinoCom();
            string fingerprint = arduinoCom.readFingerPrint();
            Assert.IsNotNull(fingerprint);
        }


        [TestMethod()]
        public void ArduinoComTestWriteInfo()
        {
            ArduinoCom arduinoCom = new ArduinoCom();
            arduinoCom.writeInfo("Hi qtpie", "info");
            Assert.IsNotNull(arduinoCom);
        }

    }
}
