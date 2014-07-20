using UnityEngine;
using System.Collections;

public class AddBloodSplatter : MonoBehaviour {
	public GameObject blood;
	int timer = 0;

	void Update() 
	{
		timer++;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (timer < 25)
			return;

		timer = 0;
		ContactPoint contact = collision.contacts[0];
		Vector3 pos = new Vector3(contact.point.x, contact.point.y, blood.transform.position.z);
		GameObject newBlood = GameObject.Instantiate(blood, contact.point, Quaternion.identity) as GameObject;
		newBlood.SetActive(true);
		newBlood.GetComponent<AppearEffectBlood>().Initialize();

	}
}
