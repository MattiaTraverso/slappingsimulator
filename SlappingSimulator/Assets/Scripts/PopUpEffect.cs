﻿using UnityEngine;
using System.Collections;

public class PopUpEffect : MonoBehaviour {
	public AudioClip[] insults;
	public Transform transform1;
	public Transform transform2;
	int id = 0;

	// Use this for initialization
	void Start () {
		ScaleUp ();
	}

	void ScaleUp()
	{
		SwitchPosition();
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
		int rand = Random.Range (0, insults.Length);
		audio.clip = insults[rand];
		audio.Play ();

		iTween.RotateBy (gameObject, iTween.Hash("x", Random.Range(-0.05f, 0.05f), "easetype", iTween.EaseType.easeInOutBack, "looptype", iTween.LoopType.pingPong, "time", 1.3f));
	}

	void ScaleDown() {
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0.45f, "to", 0, "onupdate", "changeScale", "ease", iTween.EaseType.easeInOutSine, "time", 0.15f, "oncomplete", "wait"));
	}


	IEnumerator wait() {
		iTween.Stop (gameObject);
		yield return new WaitForSeconds(Random.Range (1f, 2f));
		ScaleUp ();
	}

	void SwitchPosition() {
		if (id == 0) {
			transform.position = transform2.position;
			transform.rotation = transform2.rotation;
			id = 1;
		}
		else {
			id = 0;
			transform.position = transform1.position;
			transform.rotation = transform1.rotation;
		}
	}
}
