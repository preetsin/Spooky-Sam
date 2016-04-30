using UnityEngine;
using System.Collections;

public class SkeletonAIManager : MonoBehaviour {

    SkeletonAI skeletonAI;
    GameObject player;
    
    void Start ()
    {
        skeletonAI = new SkeletonAI();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update ()
    {
        Vector3 distance = player.transform.position - this.transform.position;
        distance.y = 0;

        if (distance.magnitude < 5)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(distance), 0.1f);
        }

        skeletonAI.PlaySpawningAnim(false);
        if (distance.magnitude > 1)
        {
            skeletonAI.PlayWalkingAnim(true);
            skeletonAI.PlayAttackingAnim(false);
        }
        else
        {
            skeletonAI.PlayWalkingAnim(false);
            skeletonAI.PlayAttackingAnim(true);
        }

    }
}
