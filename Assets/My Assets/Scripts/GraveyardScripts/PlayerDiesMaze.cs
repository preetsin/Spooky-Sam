using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDiesMaze : MonoBehaviour {

    Animator animator;
	bool isDead;
	public Image gameOverBackground;
	public Text gameOverText;

	void Start () {
        animator = GetComponent<Animator>();
		isDead = false;
		gameOverBackground.enabled = false;
		gameOverText.enabled = false;
    }
	
	void FixedUpdate () {

		if (Prefs.playerHealth <= 0 && !isDead)
        {
            animator.SetTrigger("isDead");
			isDead = true;
			gameOverBackground.enabled = true;
			gameOverText.enabled = true;
            GetComponent<InputScript>().enabled = false;
            
        }
	}

}
