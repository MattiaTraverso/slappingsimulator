using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
		{
			RestartGame();
		}
	}
	void RestartGame() {
		GameObject.Find ("Target").GetComponent<TargetBehaviour>().Restart();

		GameObject[] spectators = GameObject.FindGameObjectsWithTag("Spectator");
		foreach (GameObject g in spectators) g.GetComponent<LookAtGuy>().Restart();
	}
}
