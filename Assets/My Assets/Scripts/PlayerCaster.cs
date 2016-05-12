using UnityEngine;
using System.Collections;

public class PlayerCaster : MonoBehaviour {
    RaycastHit hitObj;
    Animator anim;
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	void Update () {
        if (anim.GetBool("ShiningTorch") == true) {
            Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(gameObject.transform.position + new Vector3(0f, 1f, 0f), fwd * 50, Color.green);
           
            if (Physics.Raycast(gameObject.transform.position + new Vector3(0f, 1f, 0f), fwd, out hitObj, 20f))
            {
                if (hitObj.transform.tag == "Ghoul")
                {
                    hitObj.transform.GetComponent<GhoulNav>().trapped = true;
                    Debug.Log("Close to enemy" + hitObj.distance);

                }
            }

        }


    }
}
