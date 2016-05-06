using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
    public GameObject door;
    Animator anim;
	// Use this for initialization
	void Awake () {
        anim = door.GetComponent<Animator>();
	}

    void OnTriggerEnter() {
        anim.SetBool("Open", true);
    }
}
