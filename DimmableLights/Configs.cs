using BepInEx.Configuration;
using UnityEngine;

namespace DimmableLights
{
    internal class Configs
    {
        internal static ConfigEntry<float> brightnessConfig;
        internal static Color Brightness { get; private set; }

        internal static void Load(BepinPlugin plugin)
        {
            brightnessConfig = plugin.Config.Bind("DimmableLights", "brightness", 1f);
            brightnessConfig.SettingChanged += (sender, e) => Brightness = new Color(brightnessConfig.Value, brightnessConfig.Value, brightnessConfig.Value, 1f);
            Brightness = new Color(brightnessConfig.Value, brightnessConfig.Value, brightnessConfig.Value, 1f);
        }
    }
}
