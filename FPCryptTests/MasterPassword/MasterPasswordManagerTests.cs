using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class MasterPasswordManagerTests
    {
        private MasterPasswordManager masterPasswordManager;

        [TestInitialize]
        public void getInstanceTest()
        {
            masterPasswordManager = MasterPasswordManager.getInstance();
        }

        [TestMethod()]
        public void checkMP()
        {
            masterPasswordManager.checkMasterpassword("1234");
        }
    }
}