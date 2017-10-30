﻿using UnityEngine;

namespace Assets.Code.Structure
{
    public class Bullet : MonoBehaviour
    {
        public const float Lifetime = 7.5f; // bullets last this long
        private float _deathtime;

        public void Initialize (Vector2 velocity, float deathtime) {
            GetComponent<Rigidbody2D>().velocity = velocity;
            _deathtime = deathtime;
        }

        internal void Update () {
            if (Time.time > _deathtime) { Die(); }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            Die(); // we die no matter what :(
            Debug.Log("Sad");
            if (other.gameObject.GetComponent<Player>() != null) Game.Score.AddScore(-2);
            if (other.gameObject.GetComponent<Wall>() != null) Debug.Log("Dead");
        }

        private void Die () {
            Destroy(gameObject);
        }
    }
}
