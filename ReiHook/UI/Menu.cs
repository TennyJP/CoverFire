using UnityEngine;
using ReiHook.Utilities;

namespace ReiHook.UI
{
    public class Menu : MonoBehaviour
    {
        private Rect MainWindow;
        private Rect PlayerWindow;
        private Rect AimbotWindow;
        private Rect VisualWindow;
        private Rect MiscellaneousWindow;

        GUIStyle WatermarkStyle = new GUIStyle();
        GUIStyle LabelStyle = new GUIStyle();

        private bool bGUI = false;
        private bool bPlayerWindow = false;
        private bool bAimbotWindow = false;
        private bool bVisualWindow = false;
        private bool bMiscellaneousWindow = false;
        private void Start()
        {
            MainWindow = new Rect(20f, 60f, 250f, 150f);
            WatermarkStyle.normal.textColor = Color.yellow; LabelStyle.normal.textColor = Color.white;
        }

        private void Update()
        {
            ToggleMenu();
            if(Input.GetKeyDown(KeyCode.Delete)) { ReiLoader.ReiUnload(); }
        }

        private void ToggleMenu()
        {
            if (Input.GetKeyDown(KeyCode.F4))
            {
                bGUI = !bGUI;
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(20, 20, 200, 60), "UnKnoWnCheaTs.me | Tenny", WatermarkStyle); GUI.Label(new Rect(20, 40, 200, 60), "ReiHook for Cover Fire v1.0", WatermarkStyle);
            if (!bGUI) return;
            GUI.backgroundColor = Color.white; GUI.contentColor = Color.white;
            MainWindow = GUILayout.Window(0, MainWindow, new GUI.WindowFunction(UI), "Menu", new GUILayoutOption[0]);
            if (bPlayerWindow) { PlayerWindow = GUILayout.Window(1, PlayerWindow, new GUI.WindowFunction(UI), "Player", new GUILayoutOption[0]); }
            if (bAimbotWindow) { AimbotWindow = GUILayout.Window(2, AimbotWindow, new GUI.WindowFunction(UI), "Aimbot", new GUILayoutOption[0]); }
            if (bVisualWindow) { VisualWindow = GUILayout.Window(3, VisualWindow, new GUI.WindowFunction(UI), "Visual", new GUILayoutOption[0]); }
            if (bMiscellaneousWindow) { MiscellaneousWindow = GUILayout.Window(4, MiscellaneousWindow, new GUI.WindowFunction(UI), "Miscellaneous", new GUILayoutOption[0]); }
        }

        private void UI(int pID)
        {
            GUI.backgroundColor = Color.white; GUI.contentColor = Color.black;
            switch (pID)
            {
                case 0:
                    GUILayout.Label("Press F4 for Menu", LabelStyle, new GUILayoutOption[0]);
                    GUILayout.Label("Delete to Unhook the Cheat", LabelStyle, new GUILayoutOption[0]);
                    if (GUILayout.Button("Player", new GUILayoutOption[0])) { bPlayerWindow = !bPlayerWindow; }
                    if (GUILayout.Button("Aimbot", new GUILayoutOption[0])) { bAimbotWindow = !bAimbotWindow; }
                    if (GUILayout.Button("Visual", new GUILayoutOption[0])) { bVisualWindow = !bVisualWindow; }
                    if (GUILayout.Button("Miscellaneous", new GUILayoutOption[0])) { bMiscellaneousWindow = !bMiscellaneousWindow; }
                    break;
                case 1:
                    Settings.Health = GUILayout.Toggle(Settings.Health, "Unlimited Health", new GUILayoutOption[0]);
                    break;
                case 2:
                    Settings.Aimbot = GUILayout.Toggle(Settings.Aimbot, "Aimbot [RMouse]", new GUILayoutOption[0]);
                    Settings.AutoAim = GUILayout.Toggle(Settings.AutoAim, "Auto Aim", new GUILayoutOption[0]);
                    GUILayout.Label("Smooth Aim Speed: " + Settings.SmoothAimSpeed, LabelStyle, new GUILayoutOption[0]);
                    Settings.SmoothAimSpeed = (int)GUILayout.HorizontalSlider(Settings.SmoothAimSpeed, 1, 20, new GUILayoutOption[0]);
                    GUILayout.Label("Aimbot Distance: " + Mathf.Round(Settings.AimDistance), LabelStyle, new GUILayoutOption[0]);
                    Settings.AimDistance = Mathf.Round(GUILayout.HorizontalSlider(Settings.AimDistance, 1f, 200f, new GUILayoutOption[0]) * 200f) / 200f;
                    break;
                case 3:
                    Settings.ESP = GUILayout.Toggle(Settings.ESP, "Enable ESP", new GUILayoutOption[0]);
                    Settings.Enemy = GUILayout.Toggle(Settings.Enemy, "Enemy", new GUILayoutOption[0]);
                    Settings.Skeleton = GUILayout.Toggle(Settings.Skeleton, "Skeleton", new GUILayoutOption[0]);
                    break;
                case 4:
                    GUILayout.FlexibleSpace();
                    Settings.NoRecoil = GUILayout.Toggle(Settings.NoRecoil, "No Recoil", new GUILayoutOption[0]);
                    Settings.NoSpread = GUILayout.Toggle(Settings.NoSpread, "No Spread", new GUILayoutOption[0]);
                    Settings.UnlimitedAmmo = GUILayout.Toggle(Settings.UnlimitedAmmo, "Unlimited Ammo", new GUILayoutOption[0]);
                    Settings.RapidFire = GUILayout.Toggle(Settings.RapidFire, "Rapid Fire", new GUILayoutOption[0]);
                    Settings.Reload = GUILayout.Toggle(Settings.Reload, "No Reload", new GUILayoutOption[0]);
                    Settings.OneHitKill = GUILayout.Toggle(Settings.OneHitKill, "One Hit Kill", new GUILayoutOption[0]);
                    GUILayout.Space(1); GUILayout.Label("————————"); GUILayout.Space(1);
                    Settings.XPMultiplier = GUILayout.Toggle(Settings.XPMultiplier, "XP Multiplier [" + Settings.iXPMultiplier + "]", new GUILayoutOption[0]);
                    Settings.iXPMultiplier = (int)GUILayout.HorizontalSlider(Settings.iXPMultiplier, 1, 50, new GUILayoutOption[0]);
                    Settings.DRMultiplier = GUILayout.Toggle(Settings.DRMultiplier, "DR Multiplier [" + Settings.iDRMultiplier + "]", new GUILayoutOption[0]);
                    Settings.iDRMultiplier = (int)GUILayout.HorizontalSlider(Settings.iDRMultiplier, 1, 50, new GUILayoutOption[0]);
                    GUILayout.Space(1); GUILayout.Label("————————"); GUILayout.Space(1);
                    if (GUILayout.Button("Max VIP Points", new GUILayoutOption[0])) { Features.Miscellaneous.Currency.AddVIPPoints(); }
                    if (GUILayout.Button("Max Gold", new GUILayoutOption[0])) { Features.Miscellaneous.Currency.AddGold(); }
                    if (GUILayout.Button("Max Money", new GUILayoutOption[0])) { Features.Miscellaneous.Currency.AddMoney(); }
                    if (GUILayout.Button("Max Cups", new GUILayoutOption[0])) { Features.Miscellaneous.Currency.AddCups(); }
                    if (GUILayout.Button("Max Scraps", new GUILayoutOption[0])) { Features.Miscellaneous.Currency.AddScraps(); }
                    break;
                default:
                    break;
            }
            GUI.DragWindow();
        }
    }
}
