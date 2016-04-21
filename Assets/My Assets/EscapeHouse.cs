using UnityEngine;
using System.Collections;

public class EscapeHouse : MonoBehaviour
{
    public GameObject brokenGrate;
    GameObject player;

    bool escaped = false;
    bool inTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            inTrigger = true;
           
        }
    }


    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }



    void Update()
    {
        if (inTrigger)
        {
            if (player.GetComponent<InputScript>().WeaponState == 1 && player.GetComponent<InputScript>().isAttacking == true)
            {
                escaped = true;
                Debug.Log("escaped");
            }
            if (escaped)
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<MeshCollider>().enabled = false;
                brokenGrate.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }

}