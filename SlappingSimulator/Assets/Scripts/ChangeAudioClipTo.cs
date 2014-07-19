using UnityEngine;
using System.Collections;

public class ChangeAudioClipTo : MonoBehaviour {

	public void ChangeClip(AudioClip clip)
	{
		audio.clip = clip;
		audio.Play ();
		audio.pitch = 2f;
	}
}
