using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Diagnostics;

namespace Engr.OpenSCADWrapper.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CubeTest()
        {
            using (var sr = new StreamReader(new OpenSCAD().Generate("cube([2,3,4]);")))
            {
                Assert.AreEqual(Properties.Resources.Cube, sr.ReadToEnd());
            }
        }
    }
}
