using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;

namespace ChestInterface.Contents.Utils.DataStructures
{
    public class ChestFilter
    {
        internal Point16 chestCoord;
        internal bool disabled;
        internal bool inputAllowFilter;
        internal bool outputAllowFilter;
        internal List<Item> inputFilter; // Inputs from chest to magic storage
        internal List<Item> outputFilter; // Exports from magic storage to chest

        public ChestFilter()
        {
            chestCoord = new Point16(-1, -1);
            disabled = false;
            inputAllowFilter = false; // Likely that you just want certain items to not be input to magic storage
            outputAllowFilter = true; // Likely that you just want certain item to be input into magic storage
        }

        // For buttons for UI
        public void SwitchInputAllowFilter() => inputAllowFilter = !inputAllowFilter;
        public void SwitchOuputAllowFilter() => outputAllowFilter = !outputAllowFilter;

        // Filter methods
        public void AddInput(Item item) => inputFilter.Add(item);
        public void AddOutput(Item item) => outputFilter.Add(item);
        public void RemoveInput(Item item) => inputFilter.Remove(item);
        public void RemoveOutput(Item item) => outputFilter.Remove(item);

        public int GetInputFilterLength() => inputFilter.Count;
        public int GetOutputFilterLength() => outputFilter.Count;

    }
}