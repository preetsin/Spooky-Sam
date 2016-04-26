using UnityEngine;
using System.Collections;

public class Clown_huddle : MonoBehaviour {

	NavMeshAgent agent;
	public Animator animator;
	public bool kneel = false;
	public bool sit = false;

	public AudioSource swordHitSFX;



	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		animator.SetBool ("isKneeling", kneel);
		animator.SetBool ("isSitting", sit);

	}

	void OnTriggerEnter(Collider col) {
		Debug.Log ("HIT!!");
		animator.SetTrigger ("respondToAttack");
		swordHitSFX.Play ();

	}
	
	void Update () {
	
	}
}
