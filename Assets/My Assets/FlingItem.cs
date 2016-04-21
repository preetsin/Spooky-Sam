using UnityEngine;
using System.Collections;

public class FlingItem : MonoBehaviour {
    public GameObject target;
    public GameObject box;
    public GameObject stool;
    bool entered;
    
    void Awake() {
        entered = false;
    }


    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            entered = true;
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (entered)
        {
            if (Random.Range(0, 200) == 11)
            {

                Vector3   dir = target.transform.position - box.transform.position;
                dir = dir.normalized;
                GameObject flingBox = (GameObject)Instantiate(box, box.transform.position, Quaternion.identity);
                flingBox.GetComponent<Animation>().enabled = false;
                flingBox.GetComponent<Animator>().enabled = false;
                flingBox.GetComponent<Rigidbody>().AddForce(dir * 1000, ForceMode.Acceleration);
            }
        }
	}
}
