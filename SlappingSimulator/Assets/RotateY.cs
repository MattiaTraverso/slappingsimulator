using UnityEngine;
using System.Collections;

public class RotateY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.isStatic = true;
		iTween.RotateBy (gameObject, iTween.Hash("y", Random.Range(-30f, 30f), "easetype", iTween.EaseType.easeInSine, "looptype", iTween.LoopType.pingPong, "time", 1.3f));
		enabled = false;
	}
}
