using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update()
	public AudioSource doorOpeningSound, doorLockedSound;
	bool opening;
	bool locked = true;
	public Animator a;

	void Start() {
	}

    void Update() {
        // If the door is opening and it is not fully raised
            // Animate the door raising up
    }

	public void OnDoorClicked() {
		if (locked) {
			PlayDoorLockedAnimation();
		} else {
			PlayDoorOpeningAnimation ();		
		}
    }

    public void Unlock()
    {
		locked = false;
    }

	void PlayDoorLockedAnimation() {
		if (!doorLockedSound.isPlaying) {
			a.SetTrigger ("Active");
			doorLockedSound.Play ();
		}
	}

	void PlayDoorOpeningAnimation() {
		a.SetTrigger ("DoorUnlocked");
		doorOpeningSound.Play ();
		this.GetComponent<BoxCollider> ().enabled = false;		
	}
}
