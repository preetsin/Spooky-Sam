using UnityEngine;
using System.Collections;

public class Eyeball_Patrol : MonoBehaviour {
	
	public Transform[] targetDestinations;
	NavMeshAgent agent;

	int targetId;

	void Start () {
		
		targetId = 0;
		agent = GetComponent<NavMeshAgent> ();
		agent.destination = targetDestinations[targetId].position;
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
