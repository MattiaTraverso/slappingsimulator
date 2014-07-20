using UnityEngine;
using System.Collections;

public class GetWebCam : MonoBehaviour {
	public GameObject cameraPlane;
	WebCamTexture CameraTexture;
	bool isPaused;
	public GameObject plane2;

	void Start() {
		Initialize();
	}

	public void Initialize(){
		WebCamDevice[] devices = WebCamTexture.devices;
		string camName = devices[0].name;
		
		CameraTexture = new WebCamTexture(camName, Screen.width, Screen.height, 30);
		CameraTexture.Play();
		cameraPlane.renderer.material.SetTexture("_MainTex", CameraTexture);
		
	}

	public Texture2D GimmePic()
	{
		CameraTexture.Pause();
		
		Texture2D texture = new Texture2D(200, 400);
		
		for (int i = 0; i < 200; i++)
		{
			for (int j = 0; j < 400; j++)
			{
				texture.SetPixel(i, j, CameraTexture.GetPixel(i + (1280 - 200) / 2, j + (720 - 400) / 2));
			}
		}
		
		texture.Apply ();
		
		return texture;
	}
}
