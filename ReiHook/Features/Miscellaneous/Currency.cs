using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReiHook.Features.Miscellaneous {
    public class Currency : MonoBehaviour {
        public static void AddVIPPoints() {
            Mercenarios.addVIPPoints(999999999);
        }
        public static void AddGold() {
            Mercenarios.addgold(999999999);
        }
        public static void AddMoney() {
            Mercenarios.addcoins(999999999);
        }
        public static void AddCups() {
            Mercenarios.addcups(999999999);
        }
        public static void AddScraps() {
            Mercenarios.addscraps(999999999);
        }
    }
}
