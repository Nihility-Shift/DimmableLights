using CG.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DimmableLights
{
    internal class LightManager
    {
        private static Dictionary<Light, (Color defaultColor, Color lastColor)> shipLights;

        internal static void SetShipLights()
        {
            shipLights = ClientGame.Current?.PlayerShip?.GameObject?.GetComponentsInChildren<Light>()?.ToDictionary(light => light, light => (light.color, new Color(0, 0, 0, 0)));
        }

        internal static void CheckLights(object sender, EventArgs e)
        {
            if (shipLights == null || shipLights.Count == 0 || Configs.brightnessConfig.Value >= 0.995f) return;

            FixAllLights();
        }

        private static void CheckFixLight(Light light, (Color defaultColor, Color lastColor) color)
        {
            if (light.color != color.lastColor)
            {
                color.defaultColor = light.color;
                color.lastColor = color.defaultColor * Configs.Brightness;
                shipLights[light] = (color.defaultColor, color.lastColor);
                light.color = color.lastColor;
            }
            else if (light.color != color.defaultColor * Configs.Brightness)
            {
                color.lastColor = color.defaultColor * Configs.Brightness;
                shipLights[light] = (color.defaultColor, color.lastColor);
                light.color = color.lastColor;
            }
        }

        private static void FixAllLights()
        {
            for (int i = 0; i < shipLights.Count; i++)
            {
                KeyValuePair<Light, (Color defaultColor, Color lastColor)> pair = shipLights.ElementAt(i);
                if (pair.Key == null) continue;

                CheckFixLight(pair.Key, pair.Value);
            }
        }
    }
}
