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

    public void PlayWalkingAnim (bool walking) { animator.SetBool("isWalking", walking); }

    public void PlayAttackingAnim(bool attacking) { animator.SetBool("isAttacking", attacking); }
    
}
