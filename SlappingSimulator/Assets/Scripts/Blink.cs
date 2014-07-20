using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {
	public float from = 0f;
	public float to = 1f;
	public float time = 0.5f;
	public bool startOnItsOwn;

	public void Start() {
		if (startOnItsOwn)
			Initialize();
	}

	public void Initialize() {	
		iTween.Stop (gameObject);
		renderer.material.color -= new Color(0f, 0f, 0f, 1f);
		iTween.ValueTo (gameObject, iTween.Hash ("from", from, "to", to, "onupdate", "changeOpacity", "ease", iTween.EaseType.easeInOutSine, "time", time, "looptype", iTween.LoopType.pingPong));
	}	

	// Update is called once per frame
	void changeOpacity (float opacity) {
		renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, opacity);
	}
}
