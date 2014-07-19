using UnityEngine;
using System.Collections;

public class OffsetY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Random.Range(0f, 1f) < 0.5f)
		{
			this.transform.position += new Vector3(0f, Random.Range (0f, 100f), 0f);
		}

		else
		{
			this.transform.position += new Vector3(0f, Random.Range (0f, 100f), 0f);
		}

		gameObject.isStatic = true;

		iTween.MoveBy(gameObject, iTween.Hash ("y", Random.Range (-30f, 30f), "time", 1.30f, "easetype", iTween.EaseType.easeInOutElastic, "looptype", iTween.LoopType.pingPong));
		enabled = false;
	}

}
