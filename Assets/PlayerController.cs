using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public List<GameObject> parts; // Lista madon osista.
	public GameObject head; // Madon pää
	private Vector2 dir; // Madon suunta
	private float speedMultiplier; // Madon nopeus
	private BoxCollider2D cldr; // BoxCollider2D jolla tarkistetaan osuuko mato johonkin omaan osaansa
								// tai kentän reunaan.

	void Start () {
		cldr = GetComponent<BoxCollider2D> ();
		parts.Add (head); // Lisätään pää listaan.
		speedMultiplier = 1.0f;
		dir = Vector2.right; // Liikutaan aluksi oikealle.
		// Liikutetaan matoa sekunnin jälkeen tietyin aikavälein.
		// Mato liikkuu aluksi 0.3 sekunnin välein, mutta nopeutuu kun pisteet kasvavat.
		InvokeRepeating ("Move", 1.0f, 0.3f * speedMultiplier);
	}
	
	void Move() {
		// Liikutetaan pelaajaa tietyn määrän. Fysiikkamoottoria ei tarvitse käyttää
		// yksinkertaisessa matopelissä.
		transform.Translate (dir);
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

	void OnTriggerEnter2D(Collider2D snake) {
	}
}
