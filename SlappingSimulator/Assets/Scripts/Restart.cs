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

		Camera.main.gameObject.GetComponent<MotionBlur>().blurAmount = 0.01f;
		Camera.main.gameObject.GetComponent<TweenMotionBlur>().enabled = false;

		GameObject.Find ("Target").GetComponent<DisableTrigger>().RevertCollision(true);
	}
}
