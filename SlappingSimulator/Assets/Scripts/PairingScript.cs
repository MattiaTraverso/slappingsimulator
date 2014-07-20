using UnityEngine;
using System.Collections;

public class PairingScript : MonoBehaviour {
	public float TIME_TO_PAIR;
	float timer;

	public GameObject joint;
	public GameObject targets;
	public GameObject speech;

	public SlappingBehaviour slappingBehaviour;
	public DisableTrigger disableTrigger;

	public GameObject text;
	public GameObject trophy;

	bool hasPaired;
	bool isActive;

	public void Activate (){
		timer = 0f;
		hasPaired = false;

		text.SetActive(true);

		//TODO:UNCOMMENT
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
			GameObject.Find ("Speech Bubble").GetComponent<PopUpEffect>().Restart();
			GameObject.Find ("Speech Bubble").GetComponent<PopUpEffect>().ScaleUp();
		

			slappingBehaviour.StopSlapping();
			slappingBehaviour.ClearSlappingData();
			disableTrigger.RevertCollision(true);

			isActive = false;

			timer = 0f;

			hasPaired = true;

			joint.GetComponent<JointOrientation>().updateReference = true;

			TargetBehaviour.DIRT_FIX = true;

			trophy.SetActive(false);
		}
	}
}
