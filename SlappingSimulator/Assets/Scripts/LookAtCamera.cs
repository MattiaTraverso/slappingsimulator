using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {
	public Camera myCamera;

	void Update () {
		transform.LookAt (myCamera.transform,  Vector3.up);
	}
}
