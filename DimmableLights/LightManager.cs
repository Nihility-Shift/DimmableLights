using CG.Game;
using CG.Space;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DimmableLights
{
    internal class LightManager
    {
        private static Dictionary<Light, (Color defaultColor, Color lastColor)> shipLights;
        private static int lightIndex = -1;

        internal static void SetShipLights(object sender, EventArgs e)
        {
            shipLights = ClientGame.Current?.PlayerShip?.GameObject?.GetComponentsInChildren<Light>()?.ToDictionary(light => light, light => (light.color, new Color(0, 0, 0, 0)));
        }

        internal static void CheckLights(object sender, EventArgs e)
        {
            if (shipLights == null || shipLights.Count == 0) return;

            lightIndex++;
            if (lightIndex >= shipLights.Count) lightIndex = 0;

            KeyValuePair<Light, (Color, Color)> pair = shipLights.ElementAt(lightIndex);
            Light light = pair.Key;
            if (light == null)
            {
                shipLights = ClientGame.Current?.PlayerShip?.GameObject?.GetComponentsInChildren<Light>()?.ToDictionary(light => light, light => (light.color, new Color(0, 0, 0, 0)));
                return;
            }
            (Color defaultColor, Color lastColor) = pair.Value;

            if (light.color != lastColor)
            {
                defaultColor = light.color;
                lastColor = defaultColor * Configs.Brightness;
                shipLights[light] = (defaultColor, lastColor);
                light.color = lastColor;
            }
            else if (light.color != defaultColor * Configs.Brightness)
            {
                lastColor = defaultColor * Configs.Brightness;
                shipLights[light] = (defaultColor, lastColor);
                light.color = lastColor;
            }
        }
    }
}
