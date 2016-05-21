using UnityEngine;
using System.Collections;

public class ChestHandler : MonoBehaviour {

	public GameObject lid;
	public GameObject keys;
	public Animator animator;
	private bool lidCanOpen;
	private bool keysCanMove;

	// Use this for initialization
	void Start () {
		lidCanOpen = false;
		keysCanMove = false;
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player" && Prefs.chestCanOpen) {
			lidCanOpen = true;
			keysCanMove = true;
		}


	}
	
	// Update is called once per frame
	void Update () {
		Quaternion newQuat = new Quaternion (-0.6f, 0.8f, -0.1f, 0.1f);

		if (lidCanOpen) {
			if (lid.transform.rotation != newQuat) {
				lid.transform.Rotate (Time.deltaTime * 0, 0, -1);

			} else {
				lidCanOpen = false;
				animator.SetTrigger ("Pickup");
				Destroy (keys, 3.0f);
				AlertViewHandler alert = FindObjectOfType<AlertViewHandler> ();
				alert.showAlert ("You found the KEYS!!");
				Prefs.hasKeys = true;
			}
		}
	}
}
