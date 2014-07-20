using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Pose = Thalmic.Myo.Pose;

public class SlappingBehaviour : MonoBehaviour {
	public MicrophoneInput microphoneInput;
	private List<float> volumes = new List<float>();

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
	public GUIText recordText;

	void Start () {
		oldRotation = transform.rotation.eulerAngles;

		rotationDegrees = new List<float>();
	}

	void Update () {
		CalculateRotationDelta();

		if (isSlapping) {
			volumes.Add (microphoneInput.loudness);
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

		volumes.Clear();
		//debugText.text = "SLAPPING";
	}
 
	public void StopSlapping () {
		isSlapping = false;
		endTime = Time.time;
		//debugText.text = "Not Slapping";
	}

	public void ClearSlappingData() {
		rotationDegrees.Clear();
		volumes.Clear ();
		startingTime = 0f;
		endTime = 0f;
	}

	public float CalculateAverageSpeed() {
		float average = 1 - (endTime - startingTime);

		if (average < 0f)
			average = 0f;

		if ((endTime - startingTime) == 0f)
		{
			return 0f;
		}

		if (average > record)
		{
			debugText.text = average.ToString();
			record = average;
		}

		else
		{
			debugText.text = average.ToString();
		}

		recordText.text = record.ToString();

		return average;
	}

	public float CalculateAverageVolume() {
		float sum = 0f;

		foreach (float f in volumes)
		{
			sum += f;
		}

		float average = sum / volumes.Count;

		return average;
	}
}
