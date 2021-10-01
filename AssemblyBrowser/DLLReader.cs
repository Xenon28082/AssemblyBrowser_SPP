using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AssemblyBrowser
{
    public class DLLReader : IReader
    {

        private Assembly asm;
        public List<ListFrame> typeList = new List<ListFrame>();
        
        private MethodInfo[] GetMethods(Type type)
        {
            return type.GetMethods();
        }

        private FieldInfo[] GetFields(Type type)
        {
            return type.GetFields();;
        }

        private PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties();
        }

        private Assembly LoadAssembly(string path)
        {
            return Assembly.LoadFrom(path);;
        }

        private Type[] GetTypes()
        {
            return asm.GetTypes();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var frame in typeList)
            {
                builder.Append($"{frame.ToString()}");    
            }
            
            return builder.ToString();
        }

        private void sortList()
        {
            
        }
        
        public void GetResult(string path)
        {
            asm = LoadAssembly(path);
            Type[] asmTypes = GetTypes();
            foreach (var type in asmTypes)
            {
                ListFrame frame = new ListFrame();
                frame._nameSpace = type.Namespace;
                frame._class = type.Name;
                frame._fields = GetFields(type).ToList();
                frame._methods = GetMethods(type).ToList();
                frame._properties = GetProperties(type).ToList();
                typeList.Add(frame);
            }
            
        }
    }
}