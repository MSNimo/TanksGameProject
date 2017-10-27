using Assets.Code.Structure;
using Assets.Code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private static string _fireaxis;
    private Rigidbody2D _rb;
    private PolygonCollider2D _pc;
    private Assets.Code.Structure.Gun _gun;

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _pc = GetComponent<PolygonCollider2D>();
        _gun = GetComponent<Gun>();

        _fireaxis = Platform.GetFireAxis();
    }
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}

    /// <summary>
    /// Check the controller for player inputs and respond accordingly.
    /// </summary>
    private void HandleInput()
    {
        if (Input.GetAxis("Horizontal") != 0) Turn(Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Vertical") != 0) Thrust(Input.GetAxis("Vertical"));
        if (Input.GetAxis(_fireaxis) != 0) Fire();
    }

    private void Turn(float direction)
    {
        if (Mathf.Abs(direction) < 0.02f) { return; }
        _rb.AddTorque(direction * -0.05f);
    }

    private void Thrust(float intensity)
    {
        if (Mathf.Abs(intensity) < 0.02f) { return; }
        _rb.AddRelativeForce(Vector2.up * intensity);
    }

    private void Fire()
    {
        _gun.Fire();
    }
}
