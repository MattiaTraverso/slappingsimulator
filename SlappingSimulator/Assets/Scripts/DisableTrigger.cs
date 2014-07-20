using UnityEngine;
using System.Collections;

public class DisableTrigger : MonoBehaviour {

	public void RevertCollision(bool b = false)
	{
		collider.isTrigger = b;
	}
}
