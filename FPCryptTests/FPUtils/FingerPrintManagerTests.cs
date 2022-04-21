using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class FingerPrintManagerTests
    {

        private FingerprintManager fingerPrintManager;

        [TestInitialize]
        public void Setup()
        {
            fingerPrintManager = FingerprintManager.getInstance();
        }

        [TestMethod()]
        public void addFPTest()
        {
            fingerPrintManager.addFP("paco");
            fingerPrintManager.addFP("pedro");
        }

        [TestMethod()]
        public void deleteFPTest()
        {
            fingerPrintManager.addFP("piko");
            fingerPrintManager.deleteFP("piko");
        }

        [TestMethod()]
        public void modifyFPTest()
        {
            fingerPrintManager.addFP("saco");
            fingerPrintManager.modifyFP("saco", "lacoo");
        }
    }
}