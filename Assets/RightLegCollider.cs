using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLegCollider : MonoBehaviour {

    public Transform rightKnee;
    public Transform rightFoot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      transform.position = (rightKnee.position + rightFoot.position) / 2;
	}
}
