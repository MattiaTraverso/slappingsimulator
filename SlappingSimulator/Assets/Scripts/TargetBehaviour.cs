using UnityEngine;
using System.Collections;

public class TargetBehaviour : MonoBehaviour {
	public SlappingBehaviour slappingBehaviour;

	void OnCollisionEnter(Collision collision) {
		slappingBehaviour.StopSlapping();
		float averageSpeed = slappingBehaviour.CalculateAverageSpeed();

		rigidbody.AddForce(transform.forward  * averageSpeed * 300f, ForceMode.Force);
		Camera.main.gameObject.GetComponent<CameraShake>().Shake (averageSpeed);
		GameObject.Find ("HardSlap").GetComponent<PlayRandomSoundFromArray>().PlayRandomSound();
	}
}
