using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wwt_asp_dotnet_string_encoder;

namespace EncodeProcessTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program.string_encoder("Hellow= orld");
        }
    }
}
