using UnityEngine;
using System.Collections;

public class GraveyardZombieAI {

    GameObject zombieAI;
    Animator animator;

    public GraveyardZombieAI()
    {
        zombieAI = GameObject.FindGameObjectWithTag("ZombieAI");
        animator = zombieAI.GetComponent<Animator>();
    }

    public void PlayWalkingAnim(bool walking) { animator.SetBool("isWalking", walking); }

    public void PlayAttackingAnim(bool attacking) { animator.SetBool("isAttacking", attacking); }

}
