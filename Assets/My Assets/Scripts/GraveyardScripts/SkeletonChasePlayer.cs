using UnityEngine;
using System.Collections;

public class SkeletonChasePlayer : MonoBehaviour {

    public Transform player;
    static Animator anim;
    NavMeshAgent agent;

    void Start ()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }


    void Update ()
    {
        agent.destination = player.position;

        Vector3 distance = player.position - this.transform.position;
        distance.y = 0;

        anim.SetBool("isSpawn", false);
        if (distance.magnitude > 1)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);
        }

    }
}
