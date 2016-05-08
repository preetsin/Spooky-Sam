using UnityEngine;
using System.Collections;

public class GraveyardExitDoorManager : MonoBehaviour {

    GameObject graveyardController;
    GraveyardDataManager graveyardDataManager;
    GraveyardExitDoor graveyardExitDoor;
    FlickerLight flickerLight;
    bool doorClosed;

	void Start () {
        graveyardDataManager = GraveyardDataManager.GetInstance();
        graveyardExitDoor = new GraveyardExitDoor();
        graveyardController = GameObject.Find("GraveyardController");
        flickerLight = graveyardController.GetComponent<FlickerLight>();
        doorClosed = false;
    }

    void Update () {

	    if (GameObject.Find("SekeletonAI(Clone)") != null || 
            GameObject.Find("SekeletonArmedAI(Clone)") != null || 
            GameObject.Find("ZombieAI(Clone)") != null)
        {
            graveyardExitDoor.Close();
            doorClosed = true;
        } 
        else
        {
            if (graveyardDataManager.ExitDoorLeverToggled == true && doorClosed == true)
            {
                graveyardExitDoor.Open();
                flickerLight.enabled = false;
            }
            
        }
        
	}
}
