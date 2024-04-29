using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServer.Resource
{
    public class DumpedEffect
    {
        public uint Id { get; }
        public string Name { get; }
        public int PowerLevel { get; }

        public DumpedEffect(uint id, string name, int power)
        {
            Id = id;
            Name = name;
            PowerLevel = power;
        }
    }
}
