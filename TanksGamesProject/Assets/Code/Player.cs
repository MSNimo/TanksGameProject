using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Structure
{
    public class Player : MonoBehaviour
    {
        private static string _fireaxis;
        private Rigidbody2D _rb;
        private Gun _gun;

        internal void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _gun = GetComponent<Gun>();
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0f;
            _fireaxis = Platform.GetFireAxis(1);
        }

        internal void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetAxis(_fireaxis) != 0) Fire();
        }

        private void move(float direction, float intensity) {

            if (Mathf.Abs(direction) < 0.2f) direction = 0;
            if (Mathf.Abs(intensity) < 0.2f) intensity = 0;

            _rb.MovePosition(_rb.position + (((Vector2)transform.up) * intensity * 5f * Time.deltaTime));
            _rb.MoveRotation(_rb.rotation + (direction * 120f * Time.deltaTime));
        }

        private void Fire()
        {
            _gun.Fire(1);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "Bullet(Clone)")
            {
                if (other.gameObject.GetComponent<SpriteRenderer>().color == Color.red) ScoreManager.AddScore("Player", -1f);
                else ScoreManager.AddScore("Player2", 2f);

            }
        }
    }
}