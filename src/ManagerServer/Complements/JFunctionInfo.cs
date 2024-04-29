using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServer.Complements
{
    public class JFunctionInfo
    {
        public string Name { get; }
        public int Number { get; }
        public MethodInfo MethodFunc { get; }

        public JFunctionInfo(string name, int number, MethodInfo func)
        {
            Name = name;
            Number = number;
            MethodFunc = func;
        }
    }
}
