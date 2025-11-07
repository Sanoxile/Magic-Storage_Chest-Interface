using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.DataStructures;
using ChestInterface.Contents.UI;

// Fix later
namespace ChestInterface.Contents.Systems
{
    public class SystemUI : ModSystem
    {

        public ChestInterfaceUI chestUI;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                chestUI = new();
            }
        }

        public override void Unload()
        {
            chestUI = null;
        }
    }
}