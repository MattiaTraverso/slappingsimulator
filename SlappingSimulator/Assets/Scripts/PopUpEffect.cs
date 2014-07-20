using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopUpEffect : MonoBehaviour {
	public List<AudioClip> insults;
	List<AudioClip> currentInsults;

	public Transform transform1;
	public Transform transform2;
	int id = 0;

	bool isDead;

	// Use this for initialization
	void Start () {
		ScaleUp ();

		currentInsults = insults;
	}

	public void ScaleUp()
	{
		iTween.Stop (gameObject);
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
		if (currentInsults.Count == 0)
			currentInsults = insults;

		int rand = Random.Range (0, currentInsults.Count);
		audio.clip = currentInsults[rand];
		currentInsults.Remove (audio.clip);
		audio.Play ();

		iTween.RotateBy (gameObject, iTween.Hash("x", Random.Range(-0.05f, 0.05f), "easetype", iTween.EaseType.easeInOutBack, "looptype", iTween.LoopType.pingPong, "time", 1.3f));
	}

	void ScaleDown() {
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0.45f, "to", 0, "onupdate", "changeScale", "ease", iTween.EaseType.easeInOutSine, "time", 0.15f, "oncomplete", "wait"));
	}


	IEnumerator wait() {
		iTween.Stop (gameObject);
		yield return new WaitForSeconds(Random.Range (1f, 2f));

		if (!isDead)
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

	public void DieOff() {
		//print ("TACCI MIA");
		iTween.Stop(gameObject);
		audio.Stop ();
		isDead = true;
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0.45f, "to", 0, "onupdate", "changeScale", "time", 0.15f, "oncomplete", "KillMe"));
	}

	public void KillMe() {
		enabled = false;
	}

	public void Restart() {
		enabled = true;
		iTween.Stop (gameObject);
		ScaleUp();
	}
}
