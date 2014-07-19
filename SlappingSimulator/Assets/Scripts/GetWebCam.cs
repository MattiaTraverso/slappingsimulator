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

	void Update () {
		if (isPaused)
			return;

		if (Input.GetKey(KeyCode.Space))
		{
			isPaused = true;

			CameraTexture.Pause();
//
//			print ("WIDTH "+CameraTexture.width); //1280
//			print("HEIGHT "+CameraTexture.height); //720

			Texture2D texture = new Texture2D(200, 400);

			for (int i = 0; i < 200; i++)
			{
				for (int j = 0; j < 400; j++)
				{
					//print (CameraTexture.GetPixel(i, j));//i + (1280 - 200) / 2, j + (720 - 400) / 2));
					texture.SetPixel(i, j, CameraTexture.GetPixel(i + (1280 - 200) / 2, j + (720 - 400) / 2));
				}
			}

			texture.Apply ();

			plane2.renderer.material.SetTexture ("_MainTex", texture);
		}
	}
}
