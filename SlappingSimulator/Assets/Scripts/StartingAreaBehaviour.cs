using UnityEngine;
using System.Collections;

public class StartingAreaBehaviour : MonoBehaviour {
	public SlappingBehaviour slappingBehaviour;
	public DisableTrigger disableTrigger;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Box")
		{
			slappingBehaviour.StopSlapping();
			slappingBehaviour.ClearSlappingData();
			disableTrigger.RevertCollision();
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.name == "Box")
			slappingBehaviour.StartSlapping();
	}
}
