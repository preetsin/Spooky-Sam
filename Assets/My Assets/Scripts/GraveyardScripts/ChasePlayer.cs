using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {

    GameObject player;
    NavMeshAgent agent;

    public bool chasing;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        chasing = true;
    }

    void Update()
    {
        if (chasing)
        {
            agent.destination = player.transform.position;
        }
        else
        {
            return;
        }


    }
}
