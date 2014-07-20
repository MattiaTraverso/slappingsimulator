using UnityEngine;
using System.Collections;

public class TweenMotionBlur : MonoBehaviour {
	public float to;

	void Restart () {
		GetComponent<MotionBlur>().blurAmount = 0f;
	}

	void Update () {
		GetComponent<MotionBlur>().blurAmount += Time.deltaTime * 6f;

		if (GetComponent<MotionBlur>().blurAmount >= 0.8f)
		{
			GetComponent<MotionBlur>().blurAmount = 0.8f;
		}
	}
}
