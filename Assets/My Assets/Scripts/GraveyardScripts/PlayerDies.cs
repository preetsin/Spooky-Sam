using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDies : MonoBehaviour
{

    GraveyardController graveyardController;
    GraveyardDataManager graveyardDataManager;
    Animator animator;
    bool isDead;

    void Start()
    {
        animator = GetComponent<Animator>();
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
            GetComponent<InputScript>().enabled = false;
            animator.SetTrigger("isDead");
            isDead = true;

            if (SceneManager.GetActiveScene().name.Equals("graveScene"))
            {
                graveyardDataManager.Shooting = false;
                GameObject.FindGameObjectWithTag("BackgroundSound").GetComponent<AudioSource>().enabled = false;
                //graveyardController.EnableGunShooting(false);
                GetComponent<AudioSource>().enabled = true;
            }   
        }

    }

}

