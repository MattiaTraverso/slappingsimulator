using UnityEngine;
using System.Collections;

public class LookAtGuy : MonoBehaviour {
	public Material[] colors;
	public GameObject myChild;

	void Start () {
		myChild.renderer.material = colors[Random.Range (0, colors.Length)];
	}
}
