using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TecPrime.AssemblyClassFinder.Core;

namespace TecPrime.AssemblyClassFinder.Test
{
    [TestClass]
    public class UnitTestAppTypeFinder
    {
        [TestMethod]
        public void TestClassFindConfigPattern()
        {
            ITypeFinder typeFinder = new AppTypeFinder(new IAssemblyLoader[] { new AppDomainLoader() });
            var types = typeFinder.FindClassesOfType<UnitTestAppTypeFinder>();
            int count = 0;
            foreach (var type in types)
            {
                Assert.AreEqual(type.FullName, "TecPrime.AssemblyClassFinder.Test.UnitTestAppTypeFinder");
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void TestClassFind()
        {
            ITypeFinder typeFinder = new AppTypeFinder(new IAssemblyLoader[] { new AppDomainLoader() });
            var types = typeFinder.FindClassesOfType<UnitTestAppTypeFinder>();
            typeFinder.SkipPattern = "^WrongPattern";
            typeFinder.RestrictToPattern = "^TecPrime";
            int count = 0;
            foreach (var type in types)
            {
                Assert.AreEqual(type.FullName, "TecPrime.AssemblyClassFinder.Test.UnitTestAppTypeFinder");
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void TestClassFindRestrictFail()
        {
            ITypeFinder typeFinder = new AppTypeFinder(new IAssemblyLoader[] { new AppDomainLoader() });
            typeFinder.SkipPattern = "";
            typeFinder.RestrictToPattern = "^WrongPattern";
            var types = typeFinder.FindClassesOfType<UnitTestAppTypeFinder>();
            int count = 0;
            foreach (var type in types)
            {
                count++;
            }
            Assert.AreEqual(count, 0);
        }

        [TestMethod]
        public void TestClassFindSkipeFail()
        {
            ITypeFinder typeFinder = new AppTypeFinder(new IAssemblyLoader[] { new AppDomainLoader() });
            typeFinder.SkipPattern = "^TecPrime";
            typeFinder.RestrictToPattern = "";
            var types = typeFinder.FindClassesOfType<UnitTestAppTypeFinder>();
            int count = 0;
            foreach (var type in types)
            {
                count++;
            }
            Assert.AreEqual(count, 0);
        }

        [TestMethod]
        public void TestMatchNoPattern()
        {
            StringMatch match = new StringMatch("", "");
            Assert.IsTrue(match.Matches("TecPrime.AssemblyClassFinder.Test.UnitTestAppTypeFinder.dll"));
        }

        [TestMethod]
        public void TestMatchSkipPattern()
        {
            StringMatch match = new StringMatch(".*", "");
            Assert.IsTrue(match.Matches("TecPrime.AssemblyClassFinder.Test.UnitTestAppTypeFinder.dll"));
        }

        [TestMethod]
        public void TestMatchRestrictToPatternTrue()
        {
            StringMatch match = new StringMatch("", "^Microsoft");
            Assert.IsTrue(match.Matches("TecPrime.AssemblyClassFinder.Test.UnitTestAppTypeFinder.dll"));
        }

        [TestMethod]
        public void TestMatchRestrictToPatternFalse()
        {
            StringMatch match = new StringMatch("", "^TecPrime");
            Assert.IsFalse(match.Matches("TecPrime.AssemblyClassFinder.Test.UnitTestAppTypeFinder.dll"));
        }

        [TestMethod]
        public void TestMatchBothPatternsTrue()
        {
            StringMatch match = new StringMatch(".*", "^Microsoft");
            Assert.IsTrue(match.Matches("TecPrime.AssemblyClassFinder.Test.UnitTestAppTypeFinder.dll"));
        }

        [TestMethod]
        public void TestMatchBothPatternsFalse()
        {
            StringMatch match = new StringMatch(".*", "^TecPrime");
            Assert.IsFalse(match.Matches("TecPrime.AssemblyClassFinder.Test.UnitTestAppTypeFinder.dll"));
        }

    }
}
