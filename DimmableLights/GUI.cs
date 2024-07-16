using UnityEngine;
using VoidManager.CustomGUI;
using VoidManager.Utilities;

namespace DimmableLights
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name() => "Dimmable Lights";

        public override void Draw()
        {
            GUILayout.Label($"Ship Brightness: {Configs.brightnessConfig.Value*100:0}%");
            GUITools.DrawSlider(ref Configs.brightnessConfig, 0f, 1f);
        }
    }
}
