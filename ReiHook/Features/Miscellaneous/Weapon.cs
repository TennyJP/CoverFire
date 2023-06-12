using ReiHook.Utilities;
using RootMotion.Demos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReiHook.Features.Miscellaneous {
    public class Weapon : MonoBehaviour {
        PlayerControl player;
        private void Update() {
            if (player == null) { player = FindObjectOfType<PlayerControl>(); }
            if (Settings.NoRecoil) {
                player.CurrentWeapon.ApplyRecoil(Vector3.zero);
                player.CurrentWeapon.WeaponParams.RecoilRatio = 0f;
            }
            if (Settings.NoSpread) {
                player.CurrentWeapon.WeaponParams.DispersionRatioMax = 0f;
                player.CurrentWeapon.WeaponParams.DispersionRatioMin = 0f;
            }
            if (Settings.UnlimitedAmmo) {
                player.CurrentWeapon.CurrentClip = 2147483647;
                player.CurrentWeapon.WeaponParams.ClipSize = 2147483647;
            }
            if (Settings.RapidFire) {
                player.CurrentWeapon.WeaponParams.Cadency = 0f;
            }
            if (Settings.Reload) {
                player.CurrentWeapon.WeaponParams.ReloadTime = 0f;
            }
            if (Settings.OneHitKill) {
                player.CurrentWeapon.WeaponParams.Damage = 2147483647f;
            }
        }
    }
}
