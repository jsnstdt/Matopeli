﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour {

	public GameObject food;

	void Start () {
		gameObject.transform.position = MakeRandomPosition ();
	}

	Vector2 MakeRandomPosition() {
		int x = Random.Range (-38, 38);
		int y = Random.Range (-28, 28);
		return new Vector2 (x, y);
	}

	// Update is called once per frame
	void Update () {
		
	}

	// Jos mato törmää ruokaan..
	void OnTriggerEnter2D(Collider2D snake) {
		if (snake.gameObject.name == "Pää") {
			GameObject newFood = Instantiate (food);
			newFood.name = "Ruoka";
			Destroy (gameObject);
		}
	}

}
