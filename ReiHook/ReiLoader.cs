using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ReiHook
{
    public class ReiLoader : MonoBehaviour
    {
        public static GameObject pLoader;
        public static void ReiAyanami() {
            pLoader = new GameObject();
            pLoader.AddComponent<UI.Menu>();
            pLoader.AddComponent<Features.Player.Player>();

            pLoader.AddComponent<Features.Aimbot.Aimbot>();

            pLoader.AddComponent<Features.Visuals.ESP>();

            pLoader.AddComponent<Features.Miscellaneous.XP>();
            pLoader.AddComponent<Features.Miscellaneous.DR>();
            pLoader.AddComponent<Features.Miscellaneous.Weapon>();
            DontDestroyOnLoad(pLoader);
        }

        public static void ReiUnload() {
            Destroy(pLoader);
        }
    }
}
