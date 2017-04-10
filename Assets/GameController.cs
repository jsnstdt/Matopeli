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

	// Use this for initialization
	void Start () {
		playerController = player.GetComponent<PlayerController> ();	
	}



	public void AddScore() {
		score++;
	}

	// Update is called once per frame
	void Update () {
		gameOverText.enabled = GameOver;
		scoreText.text = "Pisteet: " + score.ToString();

		if (GameOver && Input.GetKey (KeyCode.R)) {
			score = 0;
			playerController.parts [0].transform.position = new Vector2 (0, 0);
			while (playerController.parts.Count > 1) {
				GameObject part = playerController.parts [1];
				playerController.parts.RemoveAt (1);
				Destroy (part);
			}
			GameOver = false;
		}

	}
}
