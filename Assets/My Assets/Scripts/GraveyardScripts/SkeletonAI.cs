using UnityEngine;
using System.Collections;

public class SkeletonAI : MonoBehaviour {

    Animator animator;
	
	void Start (){
        animator = GetComponent<Animator>();
	}
	
	
	void Update () {
        animator.SetBool("isWalking", true);

    }
}
