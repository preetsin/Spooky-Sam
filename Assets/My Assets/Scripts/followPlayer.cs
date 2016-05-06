using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {
    public GameObject player;
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);
	}
}
