using UnityEngine;
using System.Collections;

public class SkeletonArmedAIManager : MonoBehaviour {

    SkeletonArmedAI skeletonArmedAI;
    GameObject player;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        skeletonArmedAI = new SkeletonArmedAI(animator);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
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
        
    }
}
