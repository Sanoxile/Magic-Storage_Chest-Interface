using MagicStorage.UI.States;
using System.Collections.Generic;
using Terraria.Localization;
using ChestInterface.Contents.UI.Elements;

namespace ChestInterface.Contents.UI
{
    public class ChestInterfaceUI : BaseStorageUI
    {
    public override string DefaultPage => "Main";

    protected override IEnumerable<string> GetMenuOptions() =>
        new string[] { "Main" };

    protected override BaseStorageUIPage InitPage(string page)
    {
        if (page == "Main")
            return new ChestInterfacePage(this);

        throw new System.ArgumentException("Unknown page: " + page);
    }

    public override string GetSearchText() => string.Empty;

    public override float GetMinimumResizeHeight() => 200f;
    }
}