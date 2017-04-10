using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour {

	public GameObject food;
	public GameObject player;

	void Start () {
		gameObject.transform.position = MakeRandomPosition ();
	}

	Vector2 MakeRandomPosition() {
		int x = Random.Range (-19, 19);
		int y = Random.Range (-14, 14);
		return new Vector2 (x, y);
	}

	// Update is called once per frame
	void Update () {
		
	}

	// Jos mato törmää ruokaan..
	void OnTriggerEnter2D(Collider2D snake) {
		if (snake.gameObject.name == "Pää") {
			snake.gameObject.GetComponentInParent<PlayerController> ().AddPart ();
			GameObject newFood = Instantiate (food);
			newFood.name = "Ruoka";
			Destroy (gameObject);
		}
	}

}
