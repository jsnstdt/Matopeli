using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;
	private int score;
	private float speedModifier = 0.15f;
	public float SpeedModifier {
		get {
			return speedModifier - (score * 0.02f);
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	public void AddScore() {
		score++;
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = "Pisteet: " + score.ToString();
	}
}
