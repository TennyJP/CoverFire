using ReiHook.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReiHook.Features.Player {
    public class Player : MonoBehaviour {
        PlayerControl playerControl;
        private void Update() {
            if (playerControl == null) { playerControl = FindObjectOfType<PlayerControl>(); }
            if (Settings.Health) {
                playerControl.actual_life = playerControl.initial_life;
            }
        }
    }
}
