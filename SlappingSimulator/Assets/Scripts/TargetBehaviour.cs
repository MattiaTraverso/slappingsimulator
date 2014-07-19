﻿using UnityEngine;
using System.Collections;

public class TargetBehaviour : MonoBehaviour {
	public SlappingBehaviour slappingBehaviour;
	public ChangeRigidbodies changeRigidbodies;
	public JointOrientation jointOrientation;
	public ChangeAudioClipTo changeClip;
	public TweenMotionBlur tweenMotionBlur;
	public GameObject followCamera;
	public Animation animation;
	public AudioClip hitClip;

	public float STRENGTH;

	void OnCollisionEnter(Collision collision) {
		if(!enabled)
			return;

		slappingBehaviour.StopSlapping();
		float averageSpeed = slappingBehaviour.CalculateAverageSpeed();

		//rigidbody.AddForce(transform.forward  * averageSpeed * 3000f, ForceMode.Force);
		changeRigidbodies.ActivateGravity(true);
		changeRigidbodies.RemoveConstraints();
		changeRigidbodies.AddForce(transform.forward  * averageSpeed * STRENGTH);

		Camera.main.gameObject.GetComponent<CameraShake>().enabled = true;
		Camera.main.gameObject.GetComponent<CameraShake>().Shake (averageSpeed / 3f);
		GameObject.Find ("HardSlap").GetComponent<PlayRandomSoundFromArray>().PlayRandomSound();

		jointOrientation.Vibrate();
		changeClip.ChangeClip(hitClip);
		Destroy (animation);
		tweenMotionBlur.enabled = true;
		if (followCamera) followCamera.SetActive(true);
		//Time.timeScale = 0.3f;

		collider.isTrigger = true;

		enabled = false;
	}
}
