using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDies : MonoBehaviour {

    GraveyardController graveyardController;
    Animator animator;
    bool isDead;

	void Start () {
        animator = GetComponent<Animator>();
        isDead = false;
        if (SceneManager.GetActiveScene().name.Equals("graveScene"))
        {
            graveyardController = new GraveyardController();
        }
    }
	
	void FixedUpdate () {

        if (Prefs.playerHealth <= 0 && !isDead)
        {
            animator.SetTrigger("isDead");
            GetComponent<InputScript>().enabled = false;
            isDead = true;
            if (SceneManager.GetActiveScene().name.Equals("graveScene"))
            {
                GameObject.FindGameObjectWithTag("BackgroundSound").GetComponent<AudioSource>().enabled = false;
                graveyardController.EnableGunShooting(false);
                GetComponent<AudioSource>().enabled = true;
            }
        }
	}

}
