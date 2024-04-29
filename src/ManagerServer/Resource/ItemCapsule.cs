using JLib.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServer.Resource
{
    public class ItemCapsule
    {
        public ItemNumber Capsule { get; }
        public List<ItemNumber> ItemId { get; }
        public List<byte> ItemSlot { get; }
        public List<string> ItemEffect { get; }
        public List<byte> ItemColor { get; }

        public ItemCapsule(uint capsuleId)
        {
            Capsule = new ItemNumber(capsuleId);
            ItemId = new List<ItemNumber>();
            ItemSlot = new List<byte>();
            ItemEffect = new List<string>();
            ItemColor = new List<byte>();
        }
    }
}
