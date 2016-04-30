using UnityEngine;
using System.Collections;

public class SkeletonArmedChasePlayer : MonoBehaviour {

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
        Vector3 distance = player.position - this.transform.position;
        distance.y = 0;

        if (distance.magnitude < 5)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(distance), 0.1f);
        }


        anim.SetBool("isSpawn", false);
        if (distance.magnitude > 2)
        {
            agent.destination = player.position;
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
