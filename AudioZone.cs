using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour {

    private string theCollider;
    

    void OnTriggerEnter(Collider other)
    {
        theCollider = other.tag;

        if (theCollider == "Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().loop = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        theCollider = other.tag;

        if (theCollider == "Player")
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().loop = false;
        }
    }
}
