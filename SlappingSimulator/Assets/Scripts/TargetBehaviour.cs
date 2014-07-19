using UnityEngine;
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

		if (float.IsNaN(power)) {
			power = 1;
			print("NAN");
		}

//		print (averageSpeed);
//		print (averageVolume / 20f);



		//rigidbody.AddForce(transform.forward  * averageSpeed * 3000f, ForceMode.Force);
		changeRigidbodies.ActivateGravity(true);
		changeRigidbodies.RemoveConstraints();
		changeRigidbodies.AddForce((transform.forward  * power * STRENGTH) + new Vector3(0f, 4200f * averageSpeed / 2.5f, 0f));

		Camera.main.gameObject.GetComponent<CameraShake>().enabled = true;
		Camera.main.gameObject.GetComponent<CameraShake>().Shake (power / 3f);
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
