using System;
using System.Collections.Generic;
using Assets.Code.Structure;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Code
{
    /// <summary>
    /// Bullet manager for spawning and tracking all of the game's bullets
    /// </summary>
    public class BulletManager
    {
        private readonly Transform _holder;

        /// <summary>
        /// Bullet prefab. Use GameObject.Instantiate with this to make a new bullet.
        /// </summary>
        private readonly Object _bullet;

        public BulletManager(Transform holder)
        {
            _holder = holder;
            _bullet = Resources.Load("Bullet");
        }

        // TODO fill me in
        public void ForceSpawn(Vector2 pos, Quaternion rotation, Vector2 velocity, float deathtime)
        {
            GameObject new_bullet = (GameObject)Object.Instantiate(_bullet, pos, rotation);
            new_bullet.transform.SetParent(_holder);
            new_bullet.GetComponent<Bullet>().Initialize(velocity, deathtime);
        }
    }
}