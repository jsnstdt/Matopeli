using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public bool GameOver = false;
	public Text gameOverText;
	public Text scoreText;
	public GameObject player;
	public PlayerController playerController;
	private int score;
	private float speedModifier = 0.15f;
	public float SpeedModifier {
		get {
			// Mato nopeutuu kun pisteitä kerätään.
			return speedModifier - (score * 0.02f);
		}
	}
		
	void Start () {
		playerController = player.GetComponent<PlayerController> ();	
	}



	public void AddScore() {
		score++;
	}

	// Update is called once per frame
	void Update () {
		// Peli ohi-teksti näkyy vain jos peli on ohi.
		gameOverText.enabled = GameOver;
		scoreText.text = "Pisteet: " + score.ToString();

		//Haluaako pelaaja yrittää uudestaan?
		if (GameOver && Input.GetKey (KeyCode.R)) {
			score = 0;
			// Siirretään parts-listan ensimmäinen jäsen (madon pää) ruudun keskelle.
			playerController.parts [0].transform.position = new Vector2 (0, 0);

			//Poistetaan kaikki muut osat.
			//Ensin poistetaan ne listasta ja sitten tuhotaan ne.
			while (playerController.parts.Count > 1) {
				GameObject part = playerController.parts [1];
				playerController.parts.RemoveAt (1);
				Destroy (part);
			}
			// Jatketaan peliä.
			GameOver = false;

		}

	}
}
