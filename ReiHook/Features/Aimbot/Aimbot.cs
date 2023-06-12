using ReiHook.Utilities;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ReiHook.Features.Aimbot {
    public class Aimbot : MonoBehaviour {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private void Update() {
            if (Settings.Aimbot) {
                if (Input.GetKey(KeyCode.Mouse1) && !Settings.AutoAim) {
                    Aim();
                }
                if (Settings.AutoAim) {
                    Aim();
                }
            }
        }
        private void Aimbot() {
            float AimPositionY = 0;
            float AimPositionX = 0;
            foreach (EnemyController Enemy in FindObjectsOfType<EnemyController>()) {
                Vector3 NPCPosition = Enemy.transform.position;
                float ReiDistance = Vector3.Distance(Camera.main.transform.position, Enemy.transform.position);
                if (ReiDistance < Settings.AimDistance) {
                    if (!Enemy.isDead) {
                        Vector2 NPCHead = Camera.main.WorldToScreenPoint(Enemy.Head.transform.position);
                        double distance = Vector2.Distance(new Vector2(Screen.width, Screen.height) / 2, NPCHead);
                        if (distance < 250) {
                            AimPositionY = NPCHead.y; AimPositionX = NPCHead.x;
                        }
                    }
                }
            }
            AimAtPos(AimPositionX, AimPositionY);
        }

        private const int MOUSEEVENTF_MOVE = 0x0001;
        public static void Move(int xDelta, int yDelta) {
            mouse_event(MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
        }

        private void AimAtPos(float x, float y) {
            int ScreenCenterX = (Screen.width / 2);
            int ScreenCenterY = (Screen.height / 2);
            float TargetX = 0;
            float TargetY = 0;
            if (x != 0 && x != ScreenCenterX) {
                if (x > ScreenCenterX) {
                    TargetX = -(ScreenCenterX - x);
                    if (TargetX + ScreenCenterX > ScreenCenterX * 2) TargetX = 0;
                }

                if (x < ScreenCenterX) {
                    TargetX = x - ScreenCenterX;
                    if (TargetX + ScreenCenterX < 0) TargetX = 0;
                }
            }
            if (y != 0 && y != ScreenCenterY) {
                if (y > ScreenCenterY) {
                    TargetY = ScreenCenterY - y;
                    if (TargetY + ScreenCenterY > ScreenCenterY * 2) TargetY = 0;
                }

                if (y < ScreenCenterY) {
                    TargetY = -(y - ScreenCenterY);
                    if (TargetY + ScreenCenterY < 0) TargetY = 0;
                }
            }
            TargetX /= (int)Settings.SmoothAimSpeed;
            TargetY /= (int)Settings.SmoothAimSpeed;
            if (Math.Abs(TargetX) < 1) {
                if (TargetX > 0) {
                    TargetX = 1;
                }
                if (TargetX < 0) {
                    TargetX = -1;
                }
            }
            if (Math.Abs(TargetY) < 1) {
                if (TargetY > 0) {
                    TargetY = 1;
                }
                if (TargetY < 0) {
                    TargetY = -1;
                }
            }
            Move((int)TargetX, (int)TargetY);
        }
    }
}
