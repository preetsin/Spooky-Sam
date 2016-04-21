using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Player is close by");
		} else {
			Debug.Log ("not sure who this is");
		}
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
