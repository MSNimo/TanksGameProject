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
    public class BulletManager : ISaveLoad
    {
        private readonly Transform _holder;

        /// <summary>
        /// Bullet prefab. Use GameObject.Instantiate with this to make a new bullet.
        /// </summary>
        private readonly Object _bullet;

        public BulletManager (Transform holder) {
            _holder = holder;
            _bullet = Resources.Load("Bullet");
        }

        // TODO fill me in
        public void ForceSpawn (Vector2 pos, Quaternion rotation, Vector2 velocity, float deathtime) {
            GameObject new_bullet = (GameObject)Object.Instantiate(_bullet, pos, rotation);
            new_bullet.transform.SetParent(_holder);
            new_bullet.GetComponent<Bullet>().Initialize(velocity, deathtime);
        }

        #region saveload

        // TODO fill me in
        public GameData OnSave () {
            BulletsData bulletsData = new BulletsData();
            bulletsData.Bullets = new List<BulletData>();
            Bullet[] bullets = GameObject.FindObjectsOfType(typeof(Bullet)) as Bullet[];

            foreach (Bullet bullet in bullets)
            {
                BulletData bulletData = new BulletData();

                bulletData.Pos = bullet.GetComponent<Rigidbody2D>().position;
                bulletData.Velocity = bullet.GetComponent<Rigidbody2D>().velocity;
                bulletData.Rotation = bullet.GetComponent<Rigidbody2D>().rotation;
                bulletsData.Bullets.Add(bulletData);     
            }
            return bulletsData;
            //throw new NotImplementedException();
        }

        // TODO fill me in
        public void OnLoad (GameData data) {

            Bullet[] bullets = GameObject.FindObjectsOfType(typeof(Bullet)) as Bullet[];
            foreach (Bullet bullet in bullets) {
                Bullet.Destroy(bullet.gameObject);
            }

            foreach (BulletData bulletData in (data as BulletsData).Bullets) {
                ForceSpawn(bulletData.Pos, Quaternion.Euler(0,0,bulletData.Rotation), bulletData.Velocity, Bullet.Lifetime + Time.time);
            }

            //throw new NotImplementedException();
        }

        #endregion

    }

    /// <summary>
    /// Save data for all bullets in game
    /// </summary>
    public class BulletsData : GameData
    {
        public List<BulletData> Bullets;
    }

    /// <summary>
    /// Save data for a single bullet
    /// </summary>
    public class BulletData
    {
        public Vector2 Pos;
        public Vector2 Velocity;
        public float Rotation;
    }
}