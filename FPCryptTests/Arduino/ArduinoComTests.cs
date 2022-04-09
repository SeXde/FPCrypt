using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FPCrypt.Tests
{
    [TestClass()]
    public class ArduinoComTests
    {

        [TestMethod()]
        public void ArduinoComTestReadFingerprint()
        {
            string fingerprint = ArduinoCom.readFingerPrint();
            Assert.IsNotNull(fingerprint, "We should receive a non null string");
        }


        [TestMethod()]
        public void ArduinoComTestWriteInfo()
        {
            ArduinoCom.writeInfo("Hi qtpie", "info");
        }

    }
}
