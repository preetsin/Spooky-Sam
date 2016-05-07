using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SkeletonAI") || other.CompareTag("SkeletonArmedAI") || other.CompareTag("ZombieAI"))
        {
            Destroy(this.gameObject);
            Debug.Log("Bullet Destroyed by AI");
        }
        else if (other.name == "Terrain")
        {
            Destroy(this.gameObject);
            Debug.Log("Bullet Destroyed by Terrain");
        }

    }

}
