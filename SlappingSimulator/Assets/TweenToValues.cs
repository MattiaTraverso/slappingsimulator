using UnityEngine;
using System.Collections;

public class TweenToValues : MonoBehaviour {
	SmoothFollow smoothFollow;
	float timer = 0f;
	bool done;
	public GameObject mainCamera;

	void Update() {
		if (done) {
			if (!audio.isPlaying)
			{
				enabled = false;

				mainCamera.SetActive(true);
				transform.parent.gameObject.SetActive(false);
			}
			return;

		}

		timer += Time.deltaTime;

		if (timer > 7.5f)
		{
			Initialize();
			done = true;
		}
	}

	void Initialize() {
		smoothFollow = GetComponent<SmoothFollow>();
		iTween.ValueTo (gameObject, iTween.Hash("from", smoothFollow.distance, "to", 16f, "time", 2f, "onupdate", "ChangeDistance", "easetype", iTween.EaseType.easeInOutBounce));
		iTween.ValueTo (gameObject, iTween.Hash("from", smoothFollow.height, "to", 0f, "time", 2f, "onupdate", "ChangeHeight", "easetype", iTween.EaseType.easeInOutBounce));
	}
	
	void ChangeDistance(float newDistance)
	{
		smoothFollow.distance = newDistance;
	}

	void ChangeHeight(float newHeight)
	{
		smoothFollow.height = newHeight;
	}
}
