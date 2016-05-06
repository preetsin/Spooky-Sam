using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

	void Update () {
        Destroy(this.gameObject, 10);
        Debug.Log("AI Destroyed");
    }
}
