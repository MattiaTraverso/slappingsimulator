using UnityEngine;
using System.Collections;

public class SetScoreAndActivate : MonoBehaviour {

	public void ActivateScore(float s) {
		int score = (int)s;
		GetComponent<TextMesh>().text = score.ToString()+"!!!!!!!!!";
		iTween.RotateBy (gameObject, iTween.Hash("y", Random.Range(-0.03f, 0.03f), "easetype", iTween.EaseType.easeInSine, "looptype", iTween.LoopType.pingPong, "time", 1.3f));
		renderer.enabled = true;
	}

	public void Reset() {
		renderer.enabled = false;
	}
}
