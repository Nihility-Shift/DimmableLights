using CG.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VoidManager.MPModChecks;

namespace DimmableLights
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public VoidManagerPlugin()
        {
            VoidManager.Events.Instance.HostStartSession += LightManager.SetShipLights;
            VoidManager.Events.Instance.JoinedRoom += LightManager.SetShipLights;
            VoidManager.Events.Instance.LateUpdate += LightManager.CheckLights;
        }

        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "18107";

        public override string Description => "Allows ship lights to be dimmed";
    }
}
