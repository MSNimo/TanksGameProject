using System;
using Assets.Code.Structure;
using UnityEngine;

namespace Assets.Code
{
    /// <summary>
    /// Player controller class
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Player : MonoBehaviour, ISaveLoad
    {
        private static string _fireaxis;
        private Rigidbody2D _rb;
        private Gun _gun;


        // ReSharper disable once UnusedMember.Global
        internal void Start () {
            _rb = GetComponent<Rigidbody2D>();
            _gun = GetComponent<Gun>();

            _fireaxis = Platform.GetFireAxis();
        }

        // ReSharper disable once UnusedMember.Global
        internal void Update () {
            HandleInput();
        }

        /// <summary>
        /// Check the controller for player inputs and respond accordingly.
        /// </summary>
        private void HandleInput () {
            if (Input.GetAxis("Horizontal") != 0) Turn(Input.GetAxis("Horizontal"));
            if (Input.GetAxis("Vertical") != 0) Thrust(Input.GetAxis("Vertical"));
            if (Input.GetAxis(_fireaxis) != 0) Fire();
        }

        private void Turn (float direction) {
            if (Mathf.Abs(direction) < 0.02f) { return; }
            _rb.AddTorque(direction * -0.05f);
        }

        private void Thrust (float intensity) {
            if (Mathf.Abs(intensity) < 0.02f) { return; }
            _rb.AddRelativeForce(Vector2.up * intensity);
        }

        private void Fire () {
            _gun.Fire();
        }

        #region saveload

        // TODO fill me in
        public GameData OnSave () {
            PlayerGameData playerGameData = new PlayerGameData();
            Player player = GameObject.FindObjectOfType<Player>();
            playerGameData.Pos = player.GetComponent<Rigidbody2D>().position;
            playerGameData.Velocity = player.GetComponent<Rigidbody2D>().velocity;
            playerGameData.Rotation = player.GetComponent<Rigidbody2D>().rotation;
            playerGameData.AngularVelocity = player.GetComponent<Rigidbody2D>().angularVelocity;
            return playerGameData;
            //throw new NotImplementedException();
        }

        // TODO fill me in
        public void OnLoad (GameData data) {

            Player player = GameObject.FindObjectOfType<Player>();
            player.GetComponent<Rigidbody2D>().position = (data as PlayerGameData).Pos;
            player.GetComponent<Rigidbody2D>().velocity = (data as PlayerGameData).Velocity;
            player.GetComponent<Rigidbody2D>().rotation = (data as PlayerGameData).Rotation;
            player.GetComponent<Rigidbody2D>().angularVelocity = Mathf.Deg2Rad*(data as PlayerGameData).AngularVelocity;
            //throw new NotImplementedException();
        }
        
        #endregion
    }

    public class PlayerGameData : GameData
    {
        public Vector2 Pos;
        public Vector2 Velocity;
        public float Rotation;
        public float AngularVelocity; // reaed as DEGREES but stored as RADIANS; COME ON UNITY
    }
}
