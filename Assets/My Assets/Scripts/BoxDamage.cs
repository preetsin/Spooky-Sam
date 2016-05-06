using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoxDamage : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            //            other.GetComponent<PlayerHealth>().health -= 10; 
            Prefs.playerHealth -= 10;
            //


            //            Text text = other.GetComponent<PlayerHealth>().canvas.transform.Find("Health").GetComponent<Text>();
            //            text.text = (string) other.GetComponent<PlayerHealth>().health.ToString();
        }
        else {
            GetComponent<AudioSource>().Play();
        }
    } 
}
