using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour {

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
