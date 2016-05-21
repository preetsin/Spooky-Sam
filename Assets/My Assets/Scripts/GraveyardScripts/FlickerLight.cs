using UnityEngine;
using System.Collections;

public class FlickerLight : MonoBehaviour {

    GameObject[] pointLights;
    FlickerLight flickerLights;
    GameObject lightPost;

    void Start()
    {
        pointLights = GameObject.FindGameObjectsWithTag("GraveyardLightpost");
        lightPost = GameObject.Find("Lightpost (2)");
        StartFlickeringSound();
    }

    void FixedUpdate () {

        var randomNumber = Random.value;

        if(randomNumber <= 0.9) { pointLights[0].SetActive(false); } 
        else { pointLights[0].SetActive(true); }

        if (randomNumber >= 0.1) { pointLights[1].SetActive(false); } 
        else { pointLights[1].SetActive(true); }

        if (randomNumber == 0.3) { pointLights[2].SetActive(true); }
        else { pointLights[2].SetActive(false); }

        if (randomNumber == 0.6) { pointLights[3].SetActive(true); }
        else { pointLights[3].SetActive(false); }
    }

    private void StartFlickeringSound()
    {
        lightPost.GetComponent<AudioSource>().enabled = true;
    }
}
