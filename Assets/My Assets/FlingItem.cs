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
            if (Random.Range(0, 500) == 11)
            {
                GameObject flingBox = (GameObject)Instantiate(box, box.transform.position, box.transform.rotation);
                flingBox.GetComponent<Rigidbody>().AddForce((box.transform.position - target.transform.position) * 200 * 1 * Time.smoothDeltaTime);
            }
        }
	}
}
