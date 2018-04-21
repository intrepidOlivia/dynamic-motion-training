using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocation : MonoBehaviour {

    public Camera thirdPersonCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void moveCameraTo(GameObject location) {
        Debug.Log("Moving camera to:" + location.transform.localPosition);
        thirdPersonCamera.transform.position = location.transform.localPosition;
        thirdPersonCamera.transform.rotation = location.transform.rotation;
    }
}
