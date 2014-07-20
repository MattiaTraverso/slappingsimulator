using UnityEngine;
using System.Collections;

public class StartingAreaBehaviour : MonoBehaviour {
	public SlappingBehaviour slappingBehaviour;
	public DisableTrigger disableTrigger;
	int timer = 0;


	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Box")
		{ 
			slappingBehaviour.StopSlapping();
			slappingBehaviour.ClearSlappingData();
			disableTrigger.RevertCollision(true);
			//print ("ENTER");
		}
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.gameObject.name == "Box")
		{
			slappingBehaviour.StopSlapping();
			slappingBehaviour.ClearSlappingData();
			disableTrigger.RevertCollision(true);
			//print ("STAY");
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.name == "Box")
		{
			//print ("EXIT");
			disableTrigger.RevertCollision();
			slappingBehaviour.StartSlapping();
		}
	}
}
