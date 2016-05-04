using UnityEngine;
using System.Collections;


public class PlayerInTunnel : MonoBehaviour
{
   public GameObject player;
    
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("In Tunnel");
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<InputScript>().inTunnel = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<InputScript>().inTunnel = false;
        }
    }
}


