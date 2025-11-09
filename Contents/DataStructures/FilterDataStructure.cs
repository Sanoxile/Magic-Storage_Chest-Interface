using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;

namespace MagicStorageAddons.Contents.DataStructures
{
    public class FilterDataStructure
    {
        public bool disabled;
        public bool inputFilterDisabled;
        public bool outputFilterDisabled;
        public bool inputFilterAllowed; // Determines whether the filters allow only those items or prevent them
        public List<Item> inputFilter; // Items input to magic storage
        public List<Item> outputFilter; // Items output from magic storage
        public Point16[] chestCoords;

        public FilterDataStructure()
        {
            Reset();
        }

        public void ValidateChests()
        {
            for (int i = 0; i < chestCoords.Length; i++)
            {
                if (chestCoords[i].X == -1) break;
                if (Chest.FindChest(chestCoords[i].X, chestCoords[i].Y) == -1)
                {
                    for (int j = i; j < chestCoords.Length; j++)
                    {
                        if (chestCoords[j].X == -1) break;
                        if (j == chestCoords.Length-1)
                        {
                            chestCoords[j] = new Point16(-1 -1);
                            break;
                        }
                        chestCoords[j] = chestCoords[j + 1];
                    }
                    i--;
                }
            }
        }

        public void Disable() => disabled = !disabled;
        public void DisableInputFilter() => inputFilterDisabled = !inputFilterDisabled;
        public void DisableOutputFilter() => outputFilterDisabled = !outputFilterDisabled;
        public void InputFilterToggleAllow() => inputFilterAllowed = !inputFilterAllowed;
        public int GetMaxChests() => chestCoords.Length;
        public void AddInputFilter(Item item) => inputFilter.Add(item);
        public void AddOutputFilter(Item item) => outputFilter.Add(item);
        public List<Item> GetInputFilter()
        {
            List<Item> filter = new();
            foreach (Item item in inputFilter)
            {
                filter.Add(item);
            }
            return filter;
        }
        public List<Item> GetOutputFilter()
        {
            List<Item> filter = new();
            foreach(Item item in outputFilter)
            {
                filter.Add(item);
            }
            return filter;
        }
        public void AddChest(Point16 coord)
        {
            ValidateChests();
            if (Chest.FindChest(coord.X, coord.Y) == -1) return;
            for (int i = 0; i < chestCoords.Length; i++)
            {
                if (chestCoords[i].X == -1)
                {
                    chestCoords[i] = coord;
                    break;
                }
            }
        }
        public void Reset()
        {
            disabled = false;
            inputFilterDisabled = false;
            outputFilterDisabled = false;
            inputFilterAllowed = false;
            inputFilter = new();
            outputFilter = new();
            chestCoords = new Point16[5];

            // Initalize all chest coords with null (-1, -1)
            for (int i = 0; i < chestCoords.Length; i++)
            {
                chestCoords[i] = new Point16(-1, -1);
            }
        }
    }
}