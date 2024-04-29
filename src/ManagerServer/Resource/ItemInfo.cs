using System.Collections.Generic;
using JLib.Constants;

namespace ManagerServer.Resource
{
    public class ItemInfo
    {
        public ItemNumber ItemNumber { get; set; }
        public string Name { get; set; }
        public int Colors { get; set; }
        public byte Gender { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
