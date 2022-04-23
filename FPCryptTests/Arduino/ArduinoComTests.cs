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

        [TestMethod()]
        public void ClearAndRegisterTest()
        {
            int id = 1;
            ArduinoCom.clear();
            string fp = ArduinoCom.registerFingerPrint(id);
        }

        [TestMethod()]
        public void DeleteTest() {
            int id = 1;
            ArduinoCom.deleteFingerPrint(id);
        }

        [TestMethod()]
        public void ReadTest()
        {
            int id = 1;
            string fp = ArduinoCom.readFingerPrint();
        }

    }
}
