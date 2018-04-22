using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introSceneSelect : MonoBehaviour {

    // public string nextScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void transitionTo(string nextScene) {
        Initiate.Fade(nextScene, new Color(1, 1, 1), 1.0f);
    }
}
