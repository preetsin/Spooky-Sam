using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
    public GameObject door;
    Animator anim;
    AlertViewHandler alert;
	// Use this for initialization
	void Awake () {
        anim = door.GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerWeapons>().hasWeapon(4) && other.gameObject.GetComponent<Animator>().GetBool("ShiningTorch"))
        {
            anim.SetBool("Open", true);
            HouseAlertManager.Instance.doorMsg = true;
        }
        else
        {
            if (HouseAlertManager.Instance.doorMsg == false) { 
            FindObjectOfType<AlertViewHandler>().showAlert("This door might open but you cant see a thing!");
            HouseAlertManager.Instance.doorMsg = true;
            Time.timeScale = 0.0f;
            }
        }
    }
}
