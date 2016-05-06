using UnityEngine;
using System.Collections;

public class ZombieAIManager : MonoBehaviour {

    GraveyardZombieAI zombieAI;
    GameObject player;
    Animator animator;
    ChasePlayer chasePlayer;

    int health;
    float delay;
    float hitPause;

    void Start()
    {
        animator = GetComponent<Animator>();
        zombieAI = new GraveyardZombieAI(animator);
        player = GameObject.FindGameObjectWithTag("Player");
        chasePlayer = this.GetComponent<ChasePlayer>();

        health = 50;
        delay = 0;
        hitPause = 1f;
    }


    void Update()
    {
        if (health <= 0)
        {
            chasePlayer.chasing = false;
            zombieAI.PlayWalkingAnim(false);
            zombieAI.PlayAttackingAnim(false);
            zombieAI.PlayDeathAnim(true);
            Destroy(this.gameObject, 5);
            Debug.Log("Zombie health: " + health);
        }
        else
        {
            Vector3 distance = player.transform.position - this.transform.position;
            distance.y = 0;

            if (distance.magnitude < 5)
            {
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(distance), 0.1f);
            }

            if (distance.magnitude > 2)
            {
                zombieAI.PlayWalkingAnim(true);
                zombieAI.PlayAttackingAnim(false);
            }
            else
            {
                zombieAI.PlayWalkingAnim(false);
                zombieAI.PlayAttackingAnim(true);
            }

            if (Time.time > delay && health > 0)
            {
                delay = Time.time + hitPause;
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
            zombieAI.PlayWalkingAnim(false);
            Debug.Log("zombie health: " + health);
        }
    }
}
