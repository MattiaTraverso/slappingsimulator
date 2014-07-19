using UnityEngine;
using System.Collections;

public class DisableTrigger : MonoBehaviour {

	public void RevertCollision()
	{
		collider.isTrigger = false;
	}
}
