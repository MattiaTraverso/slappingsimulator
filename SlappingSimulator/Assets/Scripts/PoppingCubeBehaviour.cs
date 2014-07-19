using UnityEngine;
using System.Collections;

public class PoppingCubeBehaviour : MonoBehaviour {
	public GameObject manichino;
	bool scaleUp;

	void Start () {
		transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
	}

	void Update () {
		if (scaleUp)
		{
			transform.localScale += new Vector3(Time.deltaTime * 13f, Time.deltaTime * 13f, Time.deltaTime * 13f);

			if (transform.localScale.x >= 6f)
			{
				enabled = false;
			}

			return;
		}

		//print (manichino.transform.position.z - this.transform.position.z);

		if (Vector3.Distance(manichino.transform.position, transform.position) < 15f)
		{
			scaleUp = true;
		}
	}
}
