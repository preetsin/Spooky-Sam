using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {

    GameObject player;
    NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = player.transform.position;
    }
}
