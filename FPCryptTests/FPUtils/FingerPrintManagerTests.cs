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
    }
}