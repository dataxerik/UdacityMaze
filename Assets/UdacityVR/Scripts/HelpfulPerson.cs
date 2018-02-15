using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpfulPerson : MonoBehaviour {
	public AudioSource helpSpeech;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySpeech(){
		if (!helpSpeech.isPlaying) {
			helpSpeech.Play ();
		}
	}
}
