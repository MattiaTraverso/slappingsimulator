using UnityEngine;
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

	public float STRENGTH;

	public static bool FLIP_OUT;

	void OnCollisionEnter(Collision collision) {
		if(!enabled)
			return;

		if (collision.gameObject.name != "Box")
			return;

		FLIP_OUT = true;

		slappingBehaviour.StopSlapping();
		float averageSpeed = slappingBehaviour.CalculateAverageSpeed();
		float averageVolume = slappingBehaviour.CalculateAverageVolume();
		float power = averageSpeed + averageVolume / 20f;

		GameObject.Find ("Debug").GetComponent<DebugValues>().DrawValues(averageSpeed, averageVolume / 20f);

		if (float.IsNaN(power)) {
			power = 1;
			print("NAN");
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

		//TODO: Add different sounds
		GameObject.Find ("HardSlap").GetComponent<PlayRandomSoundFromArray>().PlayRandomSound();

		jointOrientation.Vibrate();
		changeClip.ChangeClip(hitClip, 1f);
		animation.enabled = false;
		tweenMotionBlur.enabled = true;
		if (followCamera) followCamera.SetActive(true);
		//Time.timeScale = 0.3f;

		collider.isTrigger = true;

		enabled = false;
	}

	public void Restart() {
		FLIP_OUT = false;

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
