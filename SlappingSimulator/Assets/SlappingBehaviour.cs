using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Pose = Thalmic.Myo.Pose;

public class SlappingBehaviour : MonoBehaviour {
	const bool DEBUG = false;

	bool isSlapping;
	List<float> rotationDegrees;
	Vector3 oldRotation;
	float rotationDelta;

	//DEPRECATED
	//public float slapTriggerTreshold = 30f;

	float record = 0f;

	float startingTime = 0f;
	float endTime = 0f;

	//DEBUG
	public GUIText debugText;

	void Start () {
		oldRotation = transform.rotation.eulerAngles;

		rotationDegrees = new List<float>();
	}

	void Update () {
		CalculateRotationDelta();

		if (isSlapping) {
			rotationDegrees.Add(rotationDelta);
		}

		if (DEBUG) DebugStrength();

		oldRotation = transform.rotation.eulerAngles;
	}

	//Calculate Distance between rotations in different frames, basically velocity of the hit
	void CalculateRotationDelta () {
		rotationDelta = Vector3.Distance(oldRotation, transform.rotation.eulerAngles);
	}

	//If the force of movement is higher than expected, that's a slap. 
	//TODO: Fix the fact that it could start at any time during preparation
	//DEPRECATED
//	void CheckForSlapping () {
//		if (rotationDelta > slapTriggerTreshold)
//		{
//			debugText.text = "SLAPPING";
//
//			StartSlapping();
//		}
//	}
	
	void DebugStrength (){
		float delta = Vector3.Distance(oldRotation, transform.rotation.eulerAngles);
		print (delta);
	}

	public void StartSlapping () {
		isSlapping = true;
		startingTime = Time.time;
		//debugText.text = "SLAPPING";
	}
 
	public void StopSlapping () {
		isSlapping = false;
		endTime = Time.time;
		//debugText.text = "Not Slapping";
	}

	public void ClearSlappingData() {
		rotationDegrees.Clear();
	}

	public void CalculateAverageSpeed() {
		float record = 1 - (endTime - startingTime);

		print (record);
		return;

		//DEPRECATED
		float sum = 0f;
		
		foreach (float f in rotationDegrees)
		{
			sum += f;
		}
		
		float average = sum / rotationDegrees.Count;

		if (average > record)
		{
			debugText.text = "WOW, YOU BEAT THE RECORD. "+average;

			record = average;
		}

		else 
			debugText.text = "You should practice more. Your mere "+average+" did not beat the record "+record;

		ClearSlappingData();
	}
}
