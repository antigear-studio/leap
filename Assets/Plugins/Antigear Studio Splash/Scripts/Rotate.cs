using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

  Rigidbody2D body;

  public float torque;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();

    body.angularVelocity = 2 * torque;
	}
	
	// Update is called once per frame
	void Update () {
		body.AddTorque(torque);
	}
}
