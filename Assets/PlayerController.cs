using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Vector2 dir = Vector2.right;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Move", 1.0f, 0.3f);
	}
	
	void Move() {
		transform.Translate (dir);
	}

	// Update is called once per frame
	void Update () {

	}
}
