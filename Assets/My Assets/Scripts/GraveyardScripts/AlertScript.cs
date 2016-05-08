using UnityEngine;
using System.Collections;

public class AlertScript : MonoBehaviour {

    AlertViewHandler alert;

    bool exitDoorMsgDisplayed;
    bool doorLeverCageMsgDisplayed;
    bool outsideDoorInstructionDisplayed;

    void Start()
    {
        alert = FindObjectOfType<AlertViewHandler>();
        exitDoorMsgDisplayed = false;
        doorLeverCageMsgDisplayed = false;
        outsideDoorInstructionDisplayed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.gameObject.name == "ExitDoorLeverCageInstructionCollider" && !doorLeverCageMsgDisplayed)
        {
            alert.showAlert("Find gun to shootdown door and get access to Exit Door Lever.");
            doorLeverCageMsgDisplayed = true;
        }
        
        if (other.CompareTag("Player") && this.gameObject.name == "ExitDoorInstructionCollider" && !exitDoorMsgDisplayed)
        {
            alert.showAlert("Toggle Door Lever to Open Exit door.");
            exitDoorMsgDisplayed = true;
        }

        if (other.CompareTag("Player") && this.gameObject.name == "OutsideDoorInstructionCollider" && !outsideDoorInstructionDisplayed)
        {
            alert.showAlert("Door is locked. Will need to jump over the fence");
            outsideDoorInstructionDisplayed = true;
        }
    }
}
