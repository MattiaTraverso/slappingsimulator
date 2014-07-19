using UnityEngine;
using System.Collections;

public class ChangeRigidbodies : MonoBehaviour {
	void Start () 
	{
		ActivateGravity(true);
	}

	public void AddForce(Vector3 force)
	{
		foreach (Transform child in transform) {
			Rigidbody rigid = child.gameObject.GetComponent<Rigidbody>();
			
			if (rigid != null)
			{
				rigid.AddForce(force, ForceMode.Force);
			}
		}
	}

	public void ActivateGravity(bool useGravity) {
		foreach (Transform child in transform) {
			Rigidbody rigid = child.gameObject.GetComponent<Rigidbody>();

			if (rigid != null)
			{
				rigid.useGravity = useGravity;
			}
		}
	}

	public void RemoveConstraints () {
		foreach (Transform child in transform) {
			Rigidbody rigid = child.gameObject.GetComponent<Rigidbody>();
			
			if (rigid != null)
			{
				rigid.constraints = RigidbodyConstraints.None;
			}
		}
	}
}
