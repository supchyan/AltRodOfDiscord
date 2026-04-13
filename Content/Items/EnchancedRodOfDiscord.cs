using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AltRodOfDiscord.Content.Items;

public class EnchancedRodOfDiscord : ModItem
{
    public override string Texture => $"Terraria/Images/Item_{ItemID.RodofDiscord}";
    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Lime;

        Item.width  = 34;
        Item.height = 34;
        Item.scale  = 1f;

        Item.useAnimation   = 20;
        Item.useTime        = 20;
        Item.useStyle       = ItemUseStyleID.Swing;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.RodofDiscord, 1)
            .AddIngredient(ItemID.FragmentNebula, 10)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
    }
    public override bool? UseItem(Player player)
    {
        var Keys = AltRodOfDiscord.UseKey.GetAssignedKeys();
        var IsAssigned = Keys.Count > 0;
        var KeyName = IsAssigned ? Keys[0] : "None";
        Main.NewText($"[c/FFF014:Please use] [{KeyName}] [c/FFF014:keybind instead of general use.]");
        return true;
    }
}
