using UnityEngine;
using System.Collections;

public class StartingAreaBehaviour : MonoBehaviour {
	public SlappingBehaviour slappingBehaviour;
	public DisableTrigger disableTrigger;

	void OnTriggerEnter(Collider collider)
	{
		slappingBehaviour.StopSlapping();
		slappingBehaviour.ClearSlappingData();
		disableTrigger.RevertCollision();
	}

	void OnTriggerExit(Collider collider)
	{
		slappingBehaviour.StartSlapping();
	}
}
