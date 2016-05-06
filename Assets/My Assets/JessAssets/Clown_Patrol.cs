using UnityEngine;
using System.Collections;

public class Clown_Patrol : MonoBehaviour {
	
	public Transform[] targetDestinations;
	NavMeshAgent agent;
	public Animator animator;

	int targetId;

	void Start () {
		
		targetId = 0;
		agent = GetComponent<NavMeshAgent> ();
		agent.destination = targetDestinations[targetId].position;
		animator.SetBool ("isWalking", true);
	}

	void Update () {

		if (agent.destination == agent.transform.position) {

			targetId++;

			if (targetId >= targetDestinations.Length) {
				targetId = 0;
			}

			agent.destination = targetDestinations[targetId].position;


		}
	
	}
}
