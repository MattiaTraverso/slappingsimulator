﻿using UnityEngine;
using System.Collections;

public class TargetBehaviour : MonoBehaviour {
	public SlappingBehaviour slappingBehaviour;
	public ChangeRigidbodies changeRigidbodies;
	public JointOrientation jointOrientation;
	
	void OnCollisionEnter(Collision collision) {
		slappingBehaviour.StopSlapping();
		float averageSpeed = slappingBehaviour.CalculateAverageSpeed();

		//rigidbody.AddForce(transform.forward  * averageSpeed * 3000f, ForceMode.Force);
		changeRigidbodies.ActivateGravity(true);
		changeRigidbodies.RemoveConstraints();
		changeRigidbodies.AddForce(transform.forward  * averageSpeed * 30000f);

		Camera.main.gameObject.GetComponent<CameraShake>().Shake (averageSpeed);
		GameObject.Find ("HardSlap").GetComponent<PlayRandomSoundFromArray>().PlayRandomSound();

		jointOrientation.Vibrate();

		collider.isTrigger = true;
	}
}
