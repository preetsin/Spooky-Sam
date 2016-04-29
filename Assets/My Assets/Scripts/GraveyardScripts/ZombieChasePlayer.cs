using UnityEngine;
using System.Collections;

public class ZombieChasePlayer : MonoBehaviour {

    public Transform player;
    static Animator anim;
    public float walkingSpeed;


    void Start()
    {
        walkingSpeed = 0.004f;
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        if (Vector3.Distance(player.position, this.transform.position) < 100)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if (direction.magnitude > 1.5)
            {
                this.transform.Translate(0, 0, walkingSpeed);
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
}
