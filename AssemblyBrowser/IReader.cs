using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowser
{
    public interface IReader
    {
        void GetResult(string path);
    }
}