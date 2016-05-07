using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SkeletonAI") || 
            other.CompareTag("SkeletonArmedAI") || 
            other.CompareTag("ZombieAI") || 
            other.name == "Terrain" || 
            other.CompareTag("SingleDoor"))
        {
            Destroy(this.gameObject);
            if (other.CompareTag("SingleDoor"))
            {
                Debug.Log("Bullet Destroyed ");
            }
            
        }

    }

}
