using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayRandomSoundFromArray : MonoBehaviour {
	List<AudioClip> clips = new List<AudioClip>();

	public void PlayRandomSound() {
		int rand = Random.Range (0, clips.Count);

		audio.clip = clips[rand];

		audio.Play ();
	}
}
