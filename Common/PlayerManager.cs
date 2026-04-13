using AltRodOfDiscord.Content.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace AltRodOfDiscord.Common;
public class PlayerManager : ModPlayer
{
    public int TickRate = 60; // huh

    public bool HasAltRodOfDiscord => Main.LocalPlayer.HasItem(ModContent.ItemType<EnchancedRodOfDiscord>());
    public bool HasChaosState => Main.LocalPlayer.HasBuff(BuffID.ChaosState);
    public bool IsMouseOverBlock => Collision.SolidCollision(Main.MouseWorld, 1, 1);

    public int ImmuneTime = 30;

    void DrawDust()
    {
        for (int i = 0; i < 32; i++)
        {
            var player = Main.LocalPlayer;

            var dust = Dust.NewDustDirect(player.position, player.width, player.height, 
                DustID.TeleportationPotion);
        }
    }
    public override void ProcessTriggers(TriggersSet triggersSet)
    {
        if (AltRodOfDiscord.UseKey.JustPressed && 
            HasAltRodOfDiscord &&
            !HasChaosState && !IsMouseOverBlock)
        {
            DrawDust();
            
            Main.LocalPlayer.position =
                Main.MouseWorld - new Vector2(.5f * Main.LocalPlayer.width, Main.LocalPlayer.height);

            DrawDust();

            SoundEngine.PlaySound(SoundID.Item8);

            Main.LocalPlayer.AddBuff(BuffID.ChaosState, 6 * TickRate);

            Main.LocalPlayer.immune = true;
            Main.LocalPlayer.immuneTime = ImmuneTime;
        }
    }
}