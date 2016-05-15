using UnityEngine;
using System.Collections;


public class GhoulHealth : MonoBehaviour
{

    Animator anim;
    private int health;
    public bool dead;

    void Start() {
        anim = GetComponent<Animator>();
        //anim.SetBool("Alive", true);
        dead = false;
        health = 100;
    }

    

    public void decrementHealth(int val){
        anim.SetTrigger("Hit");
        health -= val;

        testHealth();

    }

    void testHealth() {
        if (health <= 0)
        {
            anim.SetTrigger("Die");
            dead = true;
            //GetComponent<GhoulNav>().enabled = false;
            Debug.Log("Ghoul dead" + dead);
        }
        Debug.Log("Ghoul Health" + health);

    }

}

