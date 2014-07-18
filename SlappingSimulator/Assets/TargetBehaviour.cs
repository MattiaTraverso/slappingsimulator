using UnityEngine;
using System.Collections;

public class TargetBehaviour : MonoBehaviour {
	public SlappingBehaviour slappingBehaviour;

	void OnTriggerEnter(Collider collider) {
		slappingBehaviour.StopSlapping();
		slappingBehaviour.CalculateAverageSpeed();
	}
}
