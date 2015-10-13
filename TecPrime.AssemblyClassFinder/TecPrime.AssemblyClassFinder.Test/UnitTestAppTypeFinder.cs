using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TecPrime.AssemblyClassFinder.Core;

namespace TecPrime.AssemblyClassFinder.Test
{
    [TestClass]
    public class UnitTestAppTypeFinder
    {
        [TestMethod]
        public void TestClassFind()
        {
            ITypeFinder typeFinder = new AppTypeFinder(new IAssemblyLoader[] { new AppDomainLoader() });
            var types = typeFinder.FindClassesOfType<UnitTestAppTypeFinder>();
            foreach(var type in types)
            {
                Assert.AreEqual(type.FullName, "TecPrime.AssemblyClassFinder.Test.UnitTestAppTypeFinder");
            }
        }
    }
}
