using System.Collections.Generic;
using System.Reflection;

namespace TecPrime.AssemblyClassFinder.Core
{
    public interface IAssemblyLoader
    {
        IList<Assembly> GetAssemblies();
    }
}
