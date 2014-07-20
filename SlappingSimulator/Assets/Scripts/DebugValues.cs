using UnityEngine;
using System.Collections;

public class DebugValues : MonoBehaviour {
	public GUIText speed;
	public GUIText volume;
	public GUIText amountVolumes;
	public GUIText startedOrNot;

	public void DrawValues (float averageSpeed, float averageVolume)
	{
		speed.text = averageSpeed.ToString();
		volume.text = averageVolume.ToString();
	}

	public void DrawVolumesAmount(int amount)
	{
		amountVolumes.text = amount.ToString();
	}

	public void DrawStartedOrNot(bool isStarted)
	{
		startedOrNot.text = isStarted.ToString();
	}

}
