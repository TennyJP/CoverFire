using ReiHook.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ReiHook.Features.Visuals {
    public class ESP : MonoBehaviour {
        private static Camera ReiCamera;
        private static List<EnemyController> enemyController = new List<EnemyController>();
        private void Update() {
            ReiCamera = Camera.main;
            if (Settings.ESP) {
                enemyController = FindObjectsOfType<EnemyController>().ToList();
            }
        }

        void OnGUI() {
            if (Event.current.type != EventType.Repaint) return;
            if (Settings.ESP) {
                if (Settings.Enemy || Settings.Skeleton) {
                    foreach (EnemyController Enemy in enemyController) {
                        if (!Enemy || Enemy.isDead) continue;
                        Vector3 WorldToScreen = ReiCamera.WorldToScreenPoint(Enemy.transform.position);
                        float ReiDistance = Vector3.Distance(ReiCamera.transform.position, Enemy.transform.position);
                        float CurrentHealth = Enemy.GetCurrentHealth();
                        if (Render.IsOnScreen(WorldToScreen)) {
                            if (Settings.Skeleton) {
                                Skeleton(Enemy.anim);
                            }
                            if (Settings.Enemy) {
                                Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Enemy", Color.red, true, 12, FontStyle.Normal);
                                Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 12), Mathf.Round(CurrentHealth) + " HP", Color.white, true, 12, FontStyle.Normal);
                                Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 24), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                            }
                        }
                    }
                }
            }
        }

        private static readonly HumanBodyBones[] humanBodyBones =
        {
            HumanBodyBones.Head,
            HumanBodyBones.Neck,
            HumanBodyBones.Chest,
            HumanBodyBones.LeftShoulder,
            HumanBodyBones.LeftUpperArm,
            HumanBodyBones.LeftLowerArm,
            HumanBodyBones.LeftHand,
            HumanBodyBones.RightShoulder,
            HumanBodyBones.RightUpperArm,
            HumanBodyBones.RightLowerArm,
            HumanBodyBones.RightHand,
            HumanBodyBones.Hips,
            HumanBodyBones.LeftUpperLeg,
            HumanBodyBones.LeftLowerLeg,
            HumanBodyBones.LeftFoot,
            HumanBodyBones.RightUpperLeg,
            HumanBodyBones.RightLowerLeg,
            HumanBodyBones.RightFoot
        };

        private static void Skeleton(Animator animator) {
            if (animator == null || !animator.isHuman || !animator.isInitialized) { return; }
            Vector3[] BoneArray = new Vector3[humanBodyBones.Length];
            for (int i = 0; i < humanBodyBones.Length; i++) {
                Transform BonePosition = animator.GetBoneTransform(humanBodyBones[i]);
                if (BonePosition != null) BoneArray[i] = Render.WorldToScreenPoint(BonePosition.position);
                else return;
            }
            Color color = Color.white;
            if (Settings.Skeleton) {
                Render.DrawLine(BoneArray[0], BoneArray[1], 1f, color);
                Render.DrawLine(BoneArray[1], BoneArray[2], 1f, color);
                Render.DrawLine(BoneArray[2], BoneArray[3], 1f, color);
                Render.DrawLine(BoneArray[2], BoneArray[7], 1f, color);
                Render.DrawLine(BoneArray[3], BoneArray[4], 1f, color);
                Render.DrawLine(BoneArray[4], BoneArray[5], 1f, color);
                Render.DrawLine(BoneArray[5], BoneArray[6], 1f, color);
                Render.DrawLine(BoneArray[7], BoneArray[8], 1f, color);
                Render.DrawLine(BoneArray[8], BoneArray[9], 1f, color);
                Render.DrawLine(BoneArray[9], BoneArray[10], 1f, color);
                Render.DrawLine(BoneArray[2], BoneArray[11], 1f, color);
                Render.DrawLine(BoneArray[11], BoneArray[12], 1f, color);
                Render.DrawLine(BoneArray[11], BoneArray[15], 1f, color);
                Render.DrawLine(BoneArray[12], BoneArray[13], 1f, color);
                Render.DrawLine(BoneArray[13], BoneArray[14], 1f, color);
                Render.DrawLine(BoneArray[15], BoneArray[16], 1f, color);
                Render.DrawLine(BoneArray[16], BoneArray[17], 1f, color);
            }
        }
    }
}
