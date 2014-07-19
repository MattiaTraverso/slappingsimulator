using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public GameObject target;
	public float speed;
	public float maxDistance;
	
	// Update is called once per frame
	void Update () {
		//if (Vector3.Distance (transform.position, target.transform.position) < maxDistance)
		//	return;

		Vector3 distanceVector = target.transform.position - transform.position;
		distanceVector.Normalize();
		distanceVector *= 2f;
//
//
		transform.position += distanceVector;
		//transform.position = Vector3.Lerp (transform.position, target.transform.position, Time.deltaTime * speed); 
	}
}
