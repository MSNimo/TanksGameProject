using UnityEngine;

namespace Assets.Code.Structure
{
    public class Game : MonoBehaviour {
        public static Game Ctx;

        public static BulletManager Bullets;
        
        internal void Start() {
            Ctx = this;
            Bullets = new BulletManager(GameObject.Find("Bullets").transform);
        }

        internal void Update() {
        }

        private static bool IsMac() {
            return Application.platform == RuntimePlatform.OSXEditor ||
                   Application.platform == RuntimePlatform.OSXPlayer;
        }
    }
}