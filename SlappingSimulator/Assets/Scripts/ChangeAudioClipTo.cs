using UnityEngine;
using System.Collections;

public class ChangeAudioClipTo : MonoBehaviour {

	public void ChangeClip(AudioClip clip, float pitch)
	{
		audio.clip = clip;
		audio.Play ();
	}
}
