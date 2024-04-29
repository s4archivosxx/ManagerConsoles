using JLib.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServer.Resource
{
    public class ItemToolTipBase
    {
        public ItemNumber Id { get; set; }
        public ItemToolTipItemBaseBase Base { get; set; }

        public ItemToolTipBase()
        {
            Base = new ItemToolTipItemBaseBase();
        }
    }

    public class ItemToolTipItemBaseBase
    {
        public string DiffKey { get; set; }
        public string AttribPen { get; set; }
        public string AttribAP { get; set; }
    }
}
