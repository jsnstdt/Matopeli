using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector2 dir; // Madon suunta
	public List<GameObject> parts; // Lista madon osista.
	public GameObject head; // Madon pää
	public GameObject part; // Madon muu osa
	public GameObject gameControllerObj;
	public GameController gameController;

	void Start () {
		gameController = gameControllerObj.GetComponent<GameController> ();
		parts.Add (head); // Lisätään pää listaan.
		dir = Vector2.right; // Liikutaan aluksi oikealle.
		// Liikutetaan matoa sekunnin jälkeen tietyin aikavälein.
		// Mato liikkuu aluksi 0.3 sekunnin välein, mutta nopeutuu kun pisteet kasvavat.
		InvokeRepeating ("Move", 1.0f, gameController.SpeedModifier);
	}
	
	void Move() {
		Vector2 headPos = head.gameObject.transform.position;
		// Liikutetaan pelaajaa tietyn määrän. Fysiikkamoottoria ei tarvitse käyttää
		// yksinkertaisessa matopelissä.
		if (!gameController.GameOver) {
			transform.Translate (dir);
			if (parts.Count > 1) {
				parts [parts.Count - 1].transform.position = headPos;
				parts.Insert (1, parts [parts.Count - 1]);
				parts.RemoveAt (parts.Count - 1);
			}
		}
	}

	public void AddPart() {
		GameObject newPart = Instantiate (part);
		parts.Add (newPart);
		gameController.AddScore ();
	}

	// Update is called once per frame
	void Update () {

		// Tarkistetaan yrittääkö pelaaja liikkua johonkin suuntaan.
		float horiz = Input.GetAxis ("Horizontal");
		float verti = Input.GetAxis ("Vertical");

		// Vaihdetaan mahdollisesti suuntaa, ja tarkistetaan että pelaaja pystyy varmasti
		// kääntyä haluttuun suuntaan.

		if (horiz != 0) {
			if (dir != Vector2.right && horiz < 0)
				dir = Vector2.left;
			else if (dir != Vector2.left && horiz > 0)
				dir = Vector2.right;
		}
		if (verti != 0) {
			if (dir != Vector2.up && verti < 0)
				dir = Vector2.down;
			else if (dir != Vector2.down && verti > 0)
				dir = Vector2.up;
		}
	}
}
