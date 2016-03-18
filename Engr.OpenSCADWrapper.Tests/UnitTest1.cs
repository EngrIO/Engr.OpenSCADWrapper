using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engr.OpenSCADWrapper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()

        {
            var openscad = new OpenSCAD();
            //openscad.Run("");
            openscad.Generate("");
        }
    }
}
