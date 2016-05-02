using UnityEngine;
using System.Collections;

public class SkeletonAI  {

    GameObject skeletonAI;
    Animator animator;

	public SkeletonAI(Animator animator)
    {
        skeletonAI = GameObject.FindGameObjectWithTag("SkeletonAI");
        this.animator = animator;    
    }

    public void PlaySpawningAnim (bool spawn) { animator.SetBool("isSpawn", spawn); }

    public void PlayWalkingAnim (bool isWalking) { animator.SetBool("isWalking", isWalking); }

    public void PlayAttackingAnim(bool isAttacking) { animator.SetBool("isAttacking", isAttacking); }

    public void PlayHitAnim(bool isHit) { animator.SetBool("isHit", isHit); }

    public void PlayDeathAnim(bool isDead) { animator.SetBool("isDead", isDead); }

}
