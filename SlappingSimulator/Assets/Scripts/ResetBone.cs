using UnityEngine;
using System.Collections;

public class ResetBone : MonoBehaviour {
	Quaternion oldRotation;

	// Use this for initialization
	void Start () {
		oldRotation = transform.rotation;
	}
	
	public void Reset() {
		transform.rotation = oldRotation;
	}
}
