﻿using UnityEngine;
using System.Collections;

public class TargetBehaviour : MonoBehaviour {
	public SlappingBehaviour slappingBehaviour;
	public ChangeRigidbodies changeRigidbodies;
	public JointOrientation jointOrientation;
	public ChangeAudioClipTo changeClip;
	public TweenMotionBlur tweenMotionBlur;
	public PopUpEffect popupEffect;
	public GameObject followCamera;
	public Animation animation;
	public AudioClip hitClip;
	public AudioClip BELLALAMUSICABELLA;

	public Material LUI;

	public GameObject cameraPlane;
	public GameObject joint;

	int theRecord = 0;

	bool hasDoneRecord = false;

	bool isTakingPicture = false;

	float actualTimer;
	bool wasHit;
	public float TIME_TO_RESTART;
	public float TIME_TO_PICTURE;

	float pictureTimer = 0f;

	public float STRENGTH;
	
	void OnCollisionEnter(Collision collision) {
		if(!enabled)
			return;

		if(wasHit)
			return;

		if (collision.gameObject.name != "Box")
			return;

		slappingBehaviour.StopSlapping();
		float averageSpeed = slappingBehaviour.CalculateAverageSpeed();
		float averageVolume = slappingBehaviour.CalculateAverageVolume();
		float power = averageSpeed + averageVolume / 20f;

		//print (power);

		GameObject.Find ("Debug").GetComponent<DebugValues>().DrawValues(averageSpeed, averageVolume / 20f);



		if (float.IsNaN(power)) {
			power = 1;
			print("NAN");
		}

		bool record = false;

		if ((int)((averageSpeed + averageVolume / 20f) * 100f) > theRecord)
		{
			record = true;
			hasDoneRecord = true;
			theRecord = (int)((averageSpeed + averageVolume / 20f) * 100f);
			GameObject.Find ("Score").GetComponent<SetScoreAndActivate>().ActivateScore((averageSpeed + averageVolume / 20f) * 100f, true);
			GameObject.Find ("HardSlap").GetComponent<PlayRandomSoundFromArray>().PlayRandomSound();
			GameObject.Find("WOW").audio.Play ();
		}
		else if (power < 0.85f)
		{
			GameObject.Find("LowShot").GetComponent<PlayRandomSoundFromArray>().PlayRandomSound();
			GameObject.Find ("Boo").audio.Play ();
			GameObject.Find ("Score").GetComponent<SetScoreAndActivate>().ActivateScore((averageSpeed + averageVolume / 20f) * 100f);
		}

		else 
		{
			GameObject.Find ("MediumShot").GetComponent<PlayRandomSoundFromArray>().PlayRandomSound();
			GameObject.Find ("Score").GetComponent<SetScoreAndActivate>().ActivateScore((averageSpeed + averageVolume / 20f) * 100f);
			GameObject.Find ("Good").audio.Play ();
		}

		GameObject[] spectators = GameObject.FindGameObjectsWithTag("Spectator");
		foreach(GameObject g in spectators)
		{
			if (!record) g.GetComponent<LookAtGuy>().StartFancy(power);
			else g.GetComponent<LookAtGuy>().StartFancy(power * 10f);
		}
//		print (averageSpeed);
//		print (averageVolume / 20f);

		popupEffect.DieOff();

		//rigidbody.AddForce(transform.forward  * averageSpeed * 3000f, ForceMode.Force);
		changeRigidbodies.ActivateGravity(true);
		changeRigidbodies.RemoveConstraints();
		changeRigidbodies.AddForce((transform.forward  * power * STRENGTH) + new Vector3(0f, 4200f * averageSpeed / 2.5f, 0f));

		Camera.main.gameObject.GetComponent<CameraShake>().enabled = true;
		Camera.main.gameObject.GetComponent<CameraShake>().Shake (power / 3f);

		jointOrientation.Vibrate();
		changeClip.ChangeClip(hitClip, 1f);
		animation.enabled = false;
		tweenMotionBlur.enabled = true;
		if (followCamera) followCamera.SetActive(true);
		//Time.timeScale = 0.3f;

		collider.isTrigger = true;
		wasHit = true;
	}

	void Update () {
		if (wasHit) {
			actualTimer += Time.deltaTime;
			
			if (actualTimer > TIME_TO_RESTART)
			{
				actualTimer = 0f;
				wasHit = false;

				if (!hasDoneRecord)
					GameObject.Find ("Restart").GetComponent<Restart>().RestartGame();
				else
				{
					GameObject.Find ("Score").GetComponent<SetScoreAndActivate>().Reset();
					cameraPlane.SetActive(true);
					joint.SetActive(false);
					followCamera.SetActive(false);
					isTakingPicture = true;
				}
				return;
			}
		}

		else if (isTakingPicture)
		{
			pictureTimer += Time.deltaTime;

			if (pictureTimer > TIME_TO_PICTURE)
			{
				pictureTimer = 0f;

				Texture2D LACACCA = cameraPlane.GetComponent<GetWebCam>().GimmePic();

				LUI.SetTexture("_MainTex", LACACCA);
			}
		}
	}
	public void Restart() {
		joint.SetActive(true);
		slappingBehaviour.StopSlapping();
		slappingBehaviour.ClearSlappingData();
		changeRigidbodies.ActivateGravity(false);
		changeRigidbodies.Sleep();

		Camera.main.gameObject.GetComponent<CameraShake>().enabled = false;
		changeClip.ChangeClip(BELLALAMUSICABELLA, 1f);

		animation.enabled = true;
		tweenMotionBlur.enabled = false;

		followCamera.SetActive(false);
		collider.isTrigger = false;

		enabled = true;
	}
}
