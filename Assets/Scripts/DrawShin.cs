using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawShin : MonoBehaviour {

    public Transform knee;
    public Transform ankle;
    public LineRenderer liney;

    Vector3[] positions;

    // Use this for initialization
    void Start () {
		positions = new Vector3[2];
    }
	
	// Update is called once per frame
	void Update () {
        positions[0] = knee.position;
        positions[1] = ankle.position;

       liney.GetComponent<LineRenderer>().SetPositions(positions);
       transform.position = (knee.position + ankle.position) / 2;
    }
}
