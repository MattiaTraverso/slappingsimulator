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
		iTween.Stop ();

		GameObject.Find ("Target").GetComponent<TargetBehaviour>().Restart();

		GameObject[] spectators = GameObject.FindGameObjectsWithTag("Spectator");
		foreach (GameObject g in spectators) g.GetComponent<LookAtGuy>().Restart();

 		GameObject.Find ("Speech Bubble").GetComponent<PopUpEffect>().Restart();
		GameObject.Find ("Speech").SetActive(true);
	}
}
