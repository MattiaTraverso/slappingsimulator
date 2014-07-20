using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeRigidbodies : MonoBehaviour {
	public Rigidbody[] rigids;

	void Start () 
	{
		ActivateGravity(false);
		Sleep ();
	}

	public void Sleep() 
	{
		foreach (Rigidbody rigid in rigids) {
			if (rigid != null)
			{
				rigid.Sleep();
				rigid.velocity = Vector3.zero;
				rigid.angularVelocity = Vector3.zero;
				rigid.isKinematic = true;
			}
		}
	}
	
	public void AddForce(Vector3 force)
	{
		foreach (Rigidbody rigid in rigids) {
			
			if (rigid != null)
			{
				rigid.isKinematic = false;
				rigid.AddForce(force, ForceMode.Force);
			}
		}
	}

	public void ActivateGravity(bool useGravity) {
		foreach (Rigidbody rigid in rigids) {

			if (rigid != null)
			{
				rigid.isKinematic = false;
				rigid.useGravity = useGravity;
			}
		}
	}

	public void RemoveConstraints () {
		foreach (Rigidbody rigid in rigids) {
			
			if (rigid != null)
			{
				rigid.isKinematic = false;
				rigid.constraints = RigidbodyConstraints.None;
			}
		}
	}
}
