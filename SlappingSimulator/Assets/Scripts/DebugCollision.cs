using UnityEngine;
using System.Collections;

public class DebugCollision : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown(KeyCode.J))
		{
			collider.isTrigger = false;
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{
			Application.LoadLevel(0);
		}
	}
}
