using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

	public GameObject gameControllerObj;
	public GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = gameControllerObj.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		// Jos törmätään muuhun kuin ruokaan.
		if (coll.tag != "Food") {
			gameController.GameOver = true;
		}
	}
}
