using UnityEngine;
using System.Collections;

public class GraveyardController {

    GraveyardDataManager graveyardDataManager;
    Spawner spawnerScript;
    Spawner[] spawnerScripts;
    GameObject player;
    GameObject graveyardController;

    DoorLever doorLever;
    GraveyardExitDoor graveyardExitDoor;
    GraveyardEntranceDoor graveyardEntranceDoor;

    GameObject[] lightPosts;
    Crosshair crosshairScript;
    FlickerLight flickerLight;

    ParticleSystem particleSystem;

    float delay;

    public GraveyardController()
    {
        graveyardController = GameObject.Find("GraveyardController");

        doorLever = new DoorLever();
        graveyardExitDoor = new GraveyardExitDoor();
        graveyardEntranceDoor = new GraveyardEntranceDoor();
        delay = 0.0f;

        lightPosts = GameObject.FindGameObjectsWithTag("GraveyardLightpost");

        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        crosshairScript = mainCamera.GetComponent<Crosshair>();
        flickerLight = graveyardController.GetComponent<FlickerLight>();

        graveyardDataManager = GraveyardDataManager.GetInstance();
        
    }


    public void StartSpawningAIs()
    {
        spawnerScripts = graveyardController.GetComponents<Spawner>();
        graveyardController.GetComponents<Spawner>();
        foreach(Spawner spawnerScript in spawnerScripts)
        {
            spawnerScript.enabled = true;
        }
    }

    // Used in InputScript Update() to handle DoorLever functionallity when 'F' pressed to toggle off and on 
    public void DoorLeverToggledHandler()
    {

        if (doorLever.CloseToDoorLever && Time.time > delay)
        {
            delay = Time.time + doorLever.DelayTime;
            GameObject lever = GameObject.Find("LeverPivot");
            if (!doorLever.Toggled)
            {
                lever.transform.rotation = Quaternion.Lerp(lever.transform.rotation, Quaternion.Euler(0, 0, 15), Time.time * 2.0f);
                graveyardExitDoor.Open();
                graveyardEntranceDoor.Close();
                doorLever.Toggled = true;
                StartSpawningAIs();
                //TurnOffLights();
                flickerLight.enabled = true;
                graveyardDataManager.ExitDoorLeverToggled = true;
            }
            else if (doorLever.Toggled)
            {
                lever.transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 9), Quaternion.Euler(0, 0, 345), Time.time * 2.0f);
                graveyardExitDoor.Close();
                //graveyardEntranceDoor.Open(); // logic will change once level2 key thing sorted. 
                doorLever.Toggled = false;
            }
        }
    }
    
    public void CloseToDoorLeverHandler (Collider other, bool setBool)
    {
        if (other.CompareTag("GraveyardDoorLever")) { doorLever.CloseToDoorLever = setBool; }
    }
    
    public void TurnOnLights()
    {
        foreach (GameObject lightPost in lightPosts)
        {
            lightPost.SetActive(true);
        }
    }

    //public void TurnOffLights()
    //{
    //    lightPosts[1].SetActive(false);
    //    lightPosts[2].SetActive(false);
    //    lightPosts[3].SetActive(false);

    //    //foreach (GameObject lightPost in lightPosts)
    //    //{
    //    //    lightPost.SetActive(false);
    //    //}
    //}

    public void EnableGunShooting(bool enable)
    {
        GameObject.Find("BulletEmitter").GetComponent<Shoot>().enabled = enable;
    }

    public void EnableCrosshair(bool enable)
    {
        crosshairScript.enabled = enable;
        Cursor.visible = false;
    }
    
}
