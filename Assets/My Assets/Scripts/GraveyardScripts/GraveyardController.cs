using UnityEngine;
using System.Collections;

public class GraveyardController {

    Spawner spawnerScript;
    Spawner[] spawnerScripts;
    GameObject player;
    GameObject graveyardController;

    public GraveyardController()
    {
        graveyardController = GameObject.Find("GraveyardController");
        spawnerScripts = graveyardController.GetComponents<Spawner>();
    }


    public void StartSpawningAIs()
    {
        graveyardController.GetComponents<Spawner>();
        foreach(Spawner spawnerScript in spawnerScripts)
        {
            spawnerScript.enabled = true;
        }
    }


    
}
