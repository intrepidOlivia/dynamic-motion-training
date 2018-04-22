using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocation : MonoBehaviour {

    public Camera thirdPersonCamera;
    public GameObject rotationPoint;

    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private int degrees = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isRotatingLeft) {
            rotateLeft();
        }

        if (isRotatingRight) {
            rotateRight();
        }
	}

    public void moveCameraTo(GameObject location) {
        Debug.Log("Moving camera to:" + location.transform.localPosition);
        thirdPersonCamera.transform.position = location.transform.localPosition;
        thirdPersonCamera.transform.rotation = location.transform.rotation;
    }

    public void startRotatingLeft() {
        isRotatingLeft = true;
    }

    public void startRotatingRight() {
        isRotatingRight = true;
    }

    private void rotateLeft() {
        if (degrees > 13) {
            isRotatingLeft = false;
            degrees = 0;
            return;
        }
        thirdPersonCamera.transform.RotateAround(rotationPoint.transform.localPosition, Vector3.up, degrees++);
    }

    private void rotateRight() {
        if (degrees > 13) {
            isRotatingRight = false;
            degrees = 0;
            return;
        }
        thirdPersonCamera.transform.RotateAround(rotationPoint.transform.localPosition, Vector3.down, degrees++);
    }

}
