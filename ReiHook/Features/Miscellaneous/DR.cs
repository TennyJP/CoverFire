using ReiHook.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReiHook.Features.Miscellaneous {
    internal class DR : MonoBehaviour {
        private void Update() {
            if (Settings.DRMultiplier) {
                Mercenarios.DRMultiplier = Settings.iDRMultiplier;
            }
        }
    }
}
