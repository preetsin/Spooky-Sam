using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Hammer") {
                Debug.Log("HammerTime");
                other.gameObject.GetComponent<PlayerWeapons>().setWeapons(1);
                other.GetComponent<Animator>().SetTrigger("Pickup");
                GetComponent<MeshRenderer>().enabled = false;

            }
        }
    }
}
