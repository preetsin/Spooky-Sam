using UnityEngine;
using System.Collections;

public class ZombieAIManager : MonoBehaviour {

    GraveyardZombieAI graveyardZombieAI;
    GameObject player;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        graveyardZombieAI = new GraveyardZombieAI(animator);
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
        
        if (distance.magnitude > 2)
        {
            graveyardZombieAI.PlayWalkingAnim(true);
            graveyardZombieAI.PlayAttackingAnim(false);
        }
        else
        {
            graveyardZombieAI.PlayWalkingAnim(false);
            graveyardZombieAI.PlayAttackingAnim(true);
        }

    }
}
