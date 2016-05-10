using UnityEngine;
using System.Collections;

public class FlickerLight : MonoBehaviour {

    GameObject[] lightPosts;
    FlickerLight flickerLights;

    void Start()
    {
        lightPosts = GameObject.FindGameObjectsWithTag("GraveyardLightpost");
        StartFlickeringSound();
    }

    void FixedUpdate () {

        var randomNumber = Random.value;

        if(randomNumber <= 0.9) { lightPosts[0].SetActive(false); } 
        else { lightPosts[0].SetActive(true); }

        if (randomNumber >= 0.1) { lightPosts[1].SetActive(false); } 
        else { lightPosts[1].SetActive(true); }

        if (randomNumber >= 0.3 && randomNumber <= 0.4) { lightPosts[2].SetActive(true); }
        else { lightPosts[2].SetActive(false); }

        if (randomNumber >= 0.6 && randomNumber <= 0.7) { lightPosts[3].SetActive(true); }
        else { lightPosts[3].SetActive(false); }
    }

    private void StartFlickeringSound()
    {
        foreach (GameObject lightPost in lightPosts)
        {
            lightPost.GetComponent<AudioSource>().enabled = true;
        }
    }
}
