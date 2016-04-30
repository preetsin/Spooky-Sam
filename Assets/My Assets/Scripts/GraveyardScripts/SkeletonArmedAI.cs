using UnityEngine;
using System.Collections;

public class SkeletonArmedAI {

    GameObject skeletonArmedAI;
    Animator animator;

    public SkeletonArmedAI()
    {
        skeletonArmedAI = GameObject.FindGameObjectWithTag("SkeletonArmedAI");
        animator = skeletonArmedAI.GetComponent<Animator>();
    }

    public void PlaySpawningAnim(bool spawn) { animator.SetBool("isSpawn", spawn); }

    public void PlayWalkingAnim(bool walking) { animator.SetBool("isWalking", walking); }

    public void PlayAttackingAnim(bool attacking) { animator.SetBool("isAttacking", attacking); }
}
