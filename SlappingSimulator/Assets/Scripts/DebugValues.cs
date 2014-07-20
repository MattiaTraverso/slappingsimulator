using UnityEngine;
using System.Collections;

public class DebugValues : MonoBehaviour {
	public GUIText speed;
	public GUIText volume;
	public GUIText amountVolumes;
	public GUIText startedOrNot;
	public const bool DEBUG = false;

	void Start()
	{
		if (!DEBUG)
		{
			speed.enabled = volume.enabled = amountVolumes.enabled = startedOrNot.enabled = false;
		}
	}

	public void DrawValues (float averageSpeed, float averageVolume)
	{
		if (!DEBUG)
			return;

		speed.text = averageSpeed.ToString();
		volume.text = averageVolume.ToString();
	}

	public void DrawVolumesAmount(int amount)
	{
		if (!DEBUG)
			return;

		amountVolumes.text = amount.ToString();
	}

	public void DrawStartedOrNot(bool isStarted)
	{
		if (!DEBUG)
			return;

		startedOrNot.text = isStarted.ToString();
	}

}
