using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectRandomTextureFromArray : MonoBehaviour {
	public List<Texture2D> textures;

	// Use this for  initialization
	void Start () {
		renderer.material.SetTexture("_MainTex", textures[Random.Range (0, textures.Count)]);
	}

}
