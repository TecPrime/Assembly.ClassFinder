using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TecPrime.AssemblyClassFinder.Core
{
    public class AppDomainLoader : IAssemblyLoader
    {
        public IList<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().ToList();
        }
    }
}
