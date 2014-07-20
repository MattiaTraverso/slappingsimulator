using UnityEngine;
using System.Collections;

public class SetScoreAndActivate : MonoBehaviour {

	public void ActivateScore(float s) {
		int score = (int)s;
		GetComponent<TextMesh>().text = score.ToString()+"!!!!!!!!!";
		iTween.RotateBy (gameObject, iTween.Hash("y", Random.Range(Random.Range (-0.8f, -0.4f), Random.Range (0.4f, 0.8f)), "easetype", iTween.EaseType.easeInSine, "looptype", iTween.LoopType.pingPong, "time", .4f));
		iTween.RotateBy (gameObject, iTween.Hash("z", Random.Range(Random.Range (-0.8f, -0.4f), Random.Range (0.4f, 0.8f)), "easetype", iTween.EaseType.easeInSine, "looptype", iTween.LoopType.pingPong, "time", .4f));

		renderer.enabled = true;

		GetComponent<LerpColor>().enabled = true;
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0.5f, "to", 1.17f, "onupdate", "changeScale", "ease", iTween.EaseType.easeInOutSine, "time", .6f, "looptype", iTween.LoopType.pingPong));
	}
	
	// Update is called once per frame
	void changeScale (float scale) {
		this.transform.localScale = Vector3.one * scale;
	}
	
	public void Reset() {
		renderer.enabled = false;
		GetComponent<LerpColor>().enabled = false;
	}
}
