using UnityEngine;
using System.Collections;


// drag A03/player into script

public class spiderHandler : MonoBehaviour {

	Animator anim;
	NavMeshAgent agent;
	public GameObject player;
	Animator playerAnim;
	int spiderHealth;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
		agent = GetComponentInChildren<NavMeshAgent> ();
		spiderHealth = 100;

		playerAnim = player.GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider col) {

		if (col.tag == "Player") {
			if (!Prefs.hasSeenSpider) {
				AlertViewHandler alert = FindObjectOfType<AlertViewHandler> ();
				alert.showAlert ("THESE spiders can't be killed with the sole of your show...\n" +
					"They will hunt you down without motive.\n" +
					"Here's a little advice...");
				alert.showAlert ("AVOID THE SPIDERS!!");
				Prefs.hasSeenSpider = true;
			}
			Prefs.playerHealth -= 5;
		}
	}

	// Update is called once per frame
	void Update () {
		if (!anim.GetBool ("isDead")) {
			
			Vector3 newPos = new Vector3 ();
			newPos.x = player.transform.position.x + player.transform.forward.x;
			newPos.y = player.transform.position.y + player.transform.forward.y;
			newPos.z = player.transform.position.z;
			agent.destination = newPos;

			if (agent.transform.position != agent.destination) {
				gameObject.transform.LookAt (player.transform);
				anim.SetBool ("isAttacking", false);
				anim.SetBool ("isWalking", true);
			} else {
				gameObject.transform.LookAt (player.transform);
				anim.SetBool ("isWalking", false);
				anim.SetBool ("isAttacking", true);
			}
		}
	}
}
