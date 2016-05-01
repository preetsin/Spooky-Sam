using UnityEngine;
using System.Collections;

public class GraveyardZombieAI {

    GameObject zombieAI;
    Animator animator;

    public GraveyardZombieAI(Animator animator)
    {
        zombieAI = GameObject.FindGameObjectWithTag("ZombieAI");
        this.animator = animator;
    }

    public void PlayWalkingAnim(bool walking) { animator.SetBool("isWalking", walking); }

    public void PlayAttackingAnim(bool attacking) { animator.SetBool("isAttacking", attacking); }

}
