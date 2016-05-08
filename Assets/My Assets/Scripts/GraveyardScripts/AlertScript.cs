using UnityEngine;
using System.Collections;

public class AlertScript : MonoBehaviour {

    AlertViewHandler alert;

    void Start()
    {
        alert = FindObjectOfType<AlertViewHandler>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.gameObject.name == "ExitDoorLeverCageInstructionCollider")
        {
            alert.showAlert("Find gun to shootdown door and get access to Exit Door Lever.");
        }
        
        if (other.CompareTag("Player") && this.gameObject.name == "ExitDoorInstructionCollider")
        {
            alert.showAlert("Toggle Door Lever to Open Exit door .");
        }

    }
}
