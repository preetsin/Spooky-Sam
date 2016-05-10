using UnityEngine;
using System.Collections;

public class BackgroundAudiosChanger : MonoBehaviour {

    public AudioClip secondClip;
    public AudioClip thirdClip;

    bool playingSecondClip;
    bool playingThirdClip;
    AudioSource sound;

    GraveyardDataManager graveyardDataManager;
	void Start () {
        graveyardDataManager = GraveyardDataManager.GetInstance();
        sound = GetComponent<AudioSource>();
        playingSecondClip = false;
        playingThirdClip = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (graveyardDataManager.ExitDoorLeverToggled && !playingSecondClip)
        {
            sound.clip = secondClip;
            sound.Play();
            playingSecondClip = true;
            Debug.Log("Playing Second Clip");
        }

        if (graveyardDataManager.EnemiesKilled && !playingThirdClip)
        {
            sound.clip = thirdClip;
            sound.Play();
            playingThirdClip = true;
            Debug.Log("Playing third Clip");
        }
	
	}
}
