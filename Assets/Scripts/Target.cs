using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public Material onMaterial;
    public Material offMaterial;
    public AudioSource successSound;

    void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material = onMaterial;
        successSound.Play();
    }

    void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material = offMaterial;
    }
}
