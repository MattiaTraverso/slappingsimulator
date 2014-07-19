﻿using UnityEngine;
using System.Collections;

public class StartingAreaBehaviour : MonoBehaviour {
	public SlappingBehaviour slappingBehaviour;

	void OnTriggerEnter(Collider collider)
	{
		slappingBehaviour.StopSlapping();
		slappingBehaviour.ClearSlappingData();
	}

	void OnTriggerExit(Collider collider)
	{
		slappingBehaviour.StartSlapping();
	}
}