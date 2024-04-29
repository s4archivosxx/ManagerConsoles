using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServer.Attributes
{
    public class FunctionAttribute : Attribute
    {
        public string Name { get; }
        public int Number { get; }

        /// <summary>
        /// Enlazador de funciones
        /// </summary>
        /// <param name="name">Nombre de la función</param>
        /// <param name="number">Número de función</param>
        public FunctionAttribute(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}
