using HarmonyLib;
using VoidManager.Utilities;

namespace DimmableLights
{
    [HarmonyPatch(typeof(PlayerShip), MethodType.Constructor)]
    internal class PlayerShipPatch
    {
        static void Postfix()
        {
            Tools.DelayDo(LightManager.SetShipLights, 2000);
        }
    }
}
