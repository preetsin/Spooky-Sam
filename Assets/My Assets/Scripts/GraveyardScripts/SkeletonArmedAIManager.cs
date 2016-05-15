using UnityEngine;
using System.Collections;

public class SkeletonArmedAIManager : MonoBehaviour {

    SkeletonArmedAI skeletonArmedAI;
    GameObject player;
    Animator animator;
    ChasePlayer chasePlayer;

    int health;
    float delay;
    float hitPause;


    void Start()
    {
        animator = GetComponent<Animator>();
        skeletonArmedAI = new SkeletonArmedAI(animator);
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
            skeletonArmedAI.PlayHitAnim(false);
            skeletonArmedAI.PlayWalkingAnim(false);
            skeletonArmedAI.PlayAttackingAnim(false);
            skeletonArmedAI.PlayDeathAnim(true);
            Destroy(this.gameObject, 5);
            Debug.Log("SkeletonArmed health: " + health);

        }
        else
        {
            Vector3 distance = player.transform.position - this.transform.position;
            distance.y = 0;

            if (distance.magnitude < 5)
            {
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(distance), 0.1f);
            }


            skeletonArmedAI.PlaySpawningAnim(false);
            if (distance.magnitude > 2)
            {
                skeletonArmedAI.PlayWalkingAnim(true);
                skeletonArmedAI.PlayAttackingAnim(false);
            }
            else
            {
                skeletonArmedAI.PlayWalkingAnim(false);
                skeletonArmedAI.PlayAttackingAnim(true);
            }

            if (Time.time > delay && health > 0)
            {
                delay = Time.time + hitPause;
                skeletonArmedAI.PlayHitAnim(false);
                chasePlayer.chasing = true;

            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && health > 0)
        {
            chasePlayer.chasing = false;
            health -= 5;
            skeletonArmedAI.PlayHitAnim(true);
            skeletonArmedAI.PlayWalkingAnim(false);
            Debug.Log("Skeleton health: " + health);
        }

        if (other.tag == "Player")
        {
            Prefs.playerHealth -= 5;

            //AlertViewHandler alert = FindObjectOfType<AlertViewHandler>();
            //alert.showAlert("You hit by Armed Skeleton");
        }
    }

    void OnTriggerStay()
    {
        reduceHealth();
    }

    IEnumerator reduceHealth()
    {
        yield return new WaitForSeconds(1);
        Prefs.playerHealth -= 1;
    }
}
