using UnityEngine;
using System.Collections;

public class LookAtGuy : MonoBehaviour {
	public Material[] colors;
	public GameObject myChild;

	bool changed;

	void Start () {
		myChild.renderer.material = colors[Random.Range (0, colors.Length)];

	//	iTween.RotateBy (gameObject, iTween.Hash ("y", Random.Range (-20f, 20f), "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.easeInOutQuad, "time", 3.5f));
	//	iTween.MoveBy(gameObject, iTween.Hash ("y", Random.Range (2f, 8f), "time", .5f, "easetype", iTween.EaseType.easeInOutElastic, "delay", Random.Range(0f, 10f)));	
	
		iTween.RotateBy (gameObject, iTween.Hash ("y", Random.Range (-2f, 2f), "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.easeInOutQuad, "time", 6f));
		//iTween.MoveBy(gameObject, iTween.Hash ("y", Random.Range (2f, 8f), "time", .5f, "easetype", iTween.EaseType.easeInOutElastic, "delay", Random.Range(0f, 10f)));	
	}

	void Update() {
		if (!changed)
			if (TargetBehaviour.FLIP_OUT)
			{
				changed = true;
				StartFancy();
			}

	}

	public void StartFancy () {
		iTween.Stop(gameObject);
		iTween.RotateBy (gameObject, iTween.Hash ("y", Random.Range (-20f, 20f), "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.easeInOutQuad, "time", 3.5f));
		iTween.MoveBy(gameObject, iTween.Hash ("y", Random.Range (2f, 8f), "time", .5f, "easetype", iTween.EaseType.easeInOutElastic, "delay", Random.Range(0f, 10f)));	

	}

}
