using UnityEngine;
using System.Collections;

public class AppearEffectBlood : MonoBehaviour {
	
	// Update is called once per frame
	public void Initialize () {
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0f, "to", 1f, "onupdate", "changeScale", "ease", iTween.EaseType.punch, "time", 0.3f));
	}
	
	// Update is called once per frame
	void changeScale (float scale) {
		this.transform.localScale = Vector3.one * scale;
	}

}
