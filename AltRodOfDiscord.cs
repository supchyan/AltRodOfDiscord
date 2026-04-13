using Terraria.ModLoader;

namespace AltRodOfDiscord;

public class AltRodOfDiscord : Mod
{
    public static ModKeybind UseKey { get; private set; }
    public override void Load()
    {
        UseKey = KeybindLoader.RegisterKeybind(this, "UseKey", "C");
    }
    public override void Unload()
    {
        UseKey = null;
    }
}
