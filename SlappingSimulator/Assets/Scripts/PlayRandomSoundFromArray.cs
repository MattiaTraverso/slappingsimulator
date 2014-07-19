using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayRandomSoundFromArray : MonoBehaviour {
	public AudioClip[] clips;

	public void PlayRandomSound() {
		int rand = Random.Range (0, clips.Length);

		audio.clip = clips[rand];

		audio.Play ();
	}
}
