using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlingItem : MonoBehaviour
{
    public GameObject target;
    public GameObject box;
    public GameObject flingBoxy;
    public GameObject stool;
    List<GameObject> boxes;
    bool entered;

    void Awake()
    {
        entered = false;
        boxes = new List<GameObject>();
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
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
    void flingBoxes()
    {
        if (entered)
        {
            Vector3 dir = target.transform.position - box.transform.position;
            dir = dir.normalized;
            GameObject flingBox = (GameObject)Instantiate(flingBoxy, box.transform.position, Quaternion.identity);

            if (boxes.Count > 5)
            {
                GameObject b = boxes[0];
                b.SetActive(false);
                boxes.RemoveAt(0);
            }

            boxes.Add(flingBox);
            flingBox.GetComponent<Animation>().enabled = false;
            flingBox.GetComponent<Animator>().enabled = false;
            flingBox.GetComponent<Rigidbody>().AddForce(dir * 1000, ForceMode.Acceleration);
        }
    }
}

