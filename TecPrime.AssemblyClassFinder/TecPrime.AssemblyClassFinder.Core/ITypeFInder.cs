﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TecPrime.AssemblyClassFinder.Core
{
    public interface ITypeFinder
    {
        string RestrictToPattern { get; set; }
        string SkipPattern { get; set; }

        IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true);

        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);

        IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);

        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);
    }
}
