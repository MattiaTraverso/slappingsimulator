using UnityEngine;
using System.Collections;

public class PairingScript : MonoBehaviour {
	public float TIME_TO_PAIR;
	float timer;

	public GameObject joint;
	public GameObject targets;
	public GameObject speech;

	public GameObject text;

	bool hasPaired;
	bool isActive;

	public void Activate (){
		timer = 0f;
		hasPaired = false;

		text.SetActive(true);

		joint.SetActive(false);
		speech.SetActive(false);
		targets.SetActive(false);

		renderer.enabled = true;
		GetComponent<Blink>().Initialize();
		isActive = true;
	}
	// Update is called once per frame
	void Update () {
		if (hasPaired)
			return;

		if (!isActive)
			return;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			timer = TIME_TO_PAIR;
		}

		timer += Time.deltaTime;

		if (timer > TIME_TO_PAIR)
		{
			joint.SetActive(true);
			joint.GetComponent<JointOrientation>().updateReference = true;

			targets.SetActive(true);

			renderer.enabled = false;
			text.SetActive(false);
			speech.SetActive(true);

			isActive = false;

			timer = 0f;

			hasPaired = true;
		}
	}
}
