using UnityEngine;
using System.Collections;

public class PopUpEffect : MonoBehaviour {
	public AudioClip[] insults;

	// Use this for initialization
	void Start () {
		ScaleUp ();
	}

	void ScaleUp()
	{
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0f, "to", 0.45f, "onupdate", "changeScale", "ease", iTween.EaseType.easeInOutSine, "time", 0.4f, "oncomplete", "idle"));
	}
	
	// Update is called once per frame
	void changeScale (float scale) {
		this.transform.localScale = Vector3.one * scale;
	}

	void Update() {
		if (audio.clip)
		{
			if (!audio.isPlaying)
			{
				audio.clip = null;
				iTween.Stop (gameObject);
				ScaleDown ();
			}
		}
	}

	void idle() {
		audio.clip = insults[Random.Range (0, insults.Length)];
		audio.Play ();

		iTween.RotateBy (gameObject, iTween.Hash("x", Random.Range(-0.3f, 0.3f), "easetype", iTween.EaseType.easeInOutBack, "looptype", iTween.LoopType.pingPong, "time", 1.3f));
	}

	void ScaleDown() {
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0.45f, "to", 0, "onupdate", "changeScale", "ease", iTween.EaseType.easeInOutSine, "time", 0.15f, "oncomplete", "wait"));
	}


	void wait() {

	}
}
