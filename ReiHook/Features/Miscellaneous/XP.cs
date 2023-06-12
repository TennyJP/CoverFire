using ReiHook.Utilities;
using UnityEngine;

namespace ReiHook.Features.Miscellaneous {
    internal class XP : MonoBehaviour {
        private void Update() {
            if (Settings.XPMultiplier) {
                Mercenarios.XPMultiplier = Settings.iXPMultiplier;
            }
        }
    }
}
