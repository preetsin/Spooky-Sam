using UnityEngine;
using System.Collections;

public class AlertScript : MonoBehaviour {

    AlertViewHandler alert;
    GraveyardDataManager graveyardDataManager;

    bool exitDoorMsgDisplayed;
    bool doorLeverCageMsgDisplayed;
    bool outsideDoorInstructionDisplayed;

    void Start()
    {
        alert = FindObjectOfType<AlertViewHandler>();
        graveyardDataManager = GraveyardDataManager.GetInstance();
        exitDoorMsgDisplayed = false;
        doorLeverCageMsgDisplayed = false;
        outsideDoorInstructionDisplayed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && 
            this.gameObject.name == "ExitDoorLeverCageInstructionCollider" &&   
            !doorLeverCageMsgDisplayed &&                                       // checking if message not displayed before
            graveyardDataManager.InsideSingleDoorBroken == false &&             // checking if door already shootdown
            graveyardDataManager.OutsideSingleDoorBroken == false)               
        {
            alert.showAlert("Find gun to shootdown door and get access to Exit Door Lever.");
            doorLeverCageMsgDisplayed = true;
        }
        
        if (other.CompareTag("Player") && 
            this.gameObject.name == "ExitDoorInstructionCollider" && 
            !exitDoorMsgDisplayed &&
            graveyardDataManager.InsideSingleDoorBroken == false)
        {
            alert.showAlert("Toggle Door Lever to Open Exit door.");
            exitDoorMsgDisplayed = true;
        }

        if (other.CompareTag("Player") && 
            this.gameObject.name == "OutsideDoorInstructionCollider" && 
            !outsideDoorInstructionDisplayed && 
            graveyardDataManager.OutsideSingleDoorBroken == false)
        {
            alert.showAlert("Door is locked. Will need to jump over the fence");
            outsideDoorInstructionDisplayed = true;
        }
    }
}
