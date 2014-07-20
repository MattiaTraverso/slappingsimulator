using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {
	public void Initialize() {	
		iTween.Stop (gameObject);
		renderer.material.color -= new Color(0f, 0f, 0f, 1f);
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0f, "to", 1f, "onupdate", "changeOpacity", "ease", iTween.EaseType.easeInOutSine, "time", 0.5f, "looptype", iTween.LoopType.pingPong));
	}	

	// Update is called once per frame
	void changeOpacity (float opacity) {
		renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, opacity);
	}
}
