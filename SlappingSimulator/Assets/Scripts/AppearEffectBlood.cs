using UnityEngine;
using System.Collections;

public class AppearEffectBlood : MonoBehaviour {
	
	// Update is called once per frame
	void Start () {
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0f, "to", 1f, "onupdate", "changeScale", "ease", iTween.EaseType.punch, "time", .4f));
	}
	
	// Update is called once per frame
	void changeScale (float scale) {
		this.transform.localScale = Vector3.one * scale;
	}

}
