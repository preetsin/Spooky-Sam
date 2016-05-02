using UnityEngine;
using System.Collections;

public class SkeletonAIManager : MonoBehaviour {

    SkeletonAI skeletonAI;
    GameObject player;
    Animator animator;
    ChasePlayer chasePlayer;

    int health;
    float delay;
    float hitPause;
    bool canHit;

    void Start ()
    {
        animator = GetComponent<Animator>();
        skeletonAI = new SkeletonAI(animator);
        player = GameObject.FindGameObjectWithTag("Player");
        chasePlayer = this.GetComponent<ChasePlayer>();

        health = 50;
        delay = 0;
        hitPause = 1.5f;
        canHit = true;
    }


    void Update ()
    {
        if (health <= 0)
        {
            chasePlayer.chasing = false;
            skeletonAI.PlayHitAnim(false);
            skeletonAI.PlayWalkingAnim(false);
            skeletonAI.PlayAttackingAnim(false);
            skeletonAI.PlayDeathAnim(true);
            Destroy(this.gameObject, 5);
            Debug.Log("Skeleton health: " + health);
        } 
        else
        {
            Vector3 distance = player.transform.position - this.transform.position;
            distance.y = 0;

            if (distance.magnitude < 5)
            {
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(distance), 0.1f);
            }

            skeletonAI.PlaySpawningAnim(false);
            if (distance.magnitude > 1)
            {
                skeletonAI.PlayWalkingAnim(true);
                skeletonAI.PlayAttackingAnim(false);
            }
            else
            {
                skeletonAI.PlayWalkingAnim(false);
                skeletonAI.PlayAttackingAnim(true);
            }
            
            if (Time.time > delay && health > 0)
            {
                delay = Time.time + hitPause;
                skeletonAI.PlayHitAnim(false);
                chasePlayer.chasing = true;

            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && health > 0)
        {
            chasePlayer.chasing = false;
            health -= 5;
            skeletonAI.PlayHitAnim(true);
            skeletonAI.PlayWalkingAnim(false);
            Debug.Log("Skeleton health: " + health);
        }
    }
    
}
