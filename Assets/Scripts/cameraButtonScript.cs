using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraButtonScript : MonoBehaviour {

    public GameObject targetLocation;
    public Camera controlCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick() {
        controlCamera.GetComponent<CameraLocation>().moveCameraTo(targetLocation);
    }

}
