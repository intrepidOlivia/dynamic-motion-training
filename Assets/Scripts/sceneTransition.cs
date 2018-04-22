using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Transition() {
        Initiate.Fade("example-scene-1", new Color(0, 0, 0), 1.0f);
    }
}
