using UnityEngine;
using System.Collections;

public class FlingItem : MonoBehaviour {
    public GameObject target;
    public GameObject box;
    public GameObject flingBoxy;
    public GameObject stool;
    bool entered;

    void Awake() {
        entered = false;
    }

    void Start()
    {
        StartCoroutine(boxFlinger());
    }


    IEnumerator boxFlinger()
    {
        while (true)
        {
            flingBoxes();
            yield return new WaitForSeconds(2);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            entered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            entered = false;
        }
    }


    // Update is called once per frame
    void flingBoxes() {
        if (entered) { 
            Vector3 dir = target.transform.position - box.transform.position;
            dir = dir.normalized;
            GameObject flingBox = (GameObject)Instantiate(flingBoxy, box.transform.position, Quaternion.identity);
            flingBox.GetComponent<Animation>().enabled = false;
            flingBox.GetComponent<Animator>().enabled = false;
            flingBox.GetComponent<Rigidbody>().AddForce(dir * 1000, ForceMode.Acceleration);
        }
    }
  }

