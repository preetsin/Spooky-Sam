using UnityEngine;
using System.Collections;

public class SkeletonArmedAI {

    GameObject skeletonArmedAI;
    Animator animator;

    public SkeletonArmedAI(Animator animator)
    {
        skeletonArmedAI = GameObject.FindGameObjectWithTag("SkeletonArmedAI");
        this.animator = animator;
    }

    public void PlaySpawningAnim(bool spawn) { animator.SetBool("isSpawn", spawn); }

    public void PlayWalkingAnim(bool walking) { animator.SetBool("isWalking", walking); }

    public void PlayAttackingAnim(bool attacking) { animator.SetBool("isAttacking", attacking); }

    public void PlayHitAnim(bool isHit) { animator.SetBool("isHit", isHit); }

    public void PlayDeathAnim(bool isDead) { animator.SetBool("isDead", isDead); }
}
