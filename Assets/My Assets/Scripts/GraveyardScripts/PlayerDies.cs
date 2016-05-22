using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDies : MonoBehaviour
{

    GraveyardController graveyardController;
    GraveyardDataManager graveyardDataManager;
    bool isDead;

    void Start()
    {
        isDead = false;
        if (SceneManager.GetActiveScene().name.Equals("graveScene"))
        {
            graveyardController = new GraveyardController();
            graveyardDataManager = GraveyardDataManager.GetInstance();
        }
    }

    void FixedUpdate()
    {

        if (Prefs.playerHealth <= 0 && !isDead)
        {

            if (SceneManager.GetActiveScene().name.Equals("graveScene"))
            {
                graveyardDataManager.Shooting = false;
                GameObject.FindGameObjectWithTag("BackgroundSound").GetComponent<AudioSource>().enabled = false;
                GetComponent<AudioSource>().enabled = true;
            }   
        }

    }

}

