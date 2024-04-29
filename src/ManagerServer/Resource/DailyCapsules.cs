using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLib.Constants;
using JLib.S4L.Constants;

namespace ManagerServer.Resource
{
    public class DailyCapsules
    {
        public ItemNumber ItemNumber { get; set; }
        public string ItemName { get; set; }
        public ItemPriceType ItemPriceType { get; set; }
        public ItemPeriodType ItemPeriodType { get; set; }
        public ushort ItemPeriod { get; set; }
        public byte ItemCount { get; set; }
        public int ItemChangeForGet { get; set; }
    }
}
