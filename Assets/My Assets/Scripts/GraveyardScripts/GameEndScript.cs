using UnityEngine;
using System.Collections;

public class GameEndScript : MonoBehaviour {

    GameObject gameEndCamera;
    Camera mainCam;
    Camera gameEndCam;
    Animation gameEndCamAnimation;
    AudioListener gameEndCamAudioListener;
    GraveyardDataManager graveyardDataManager;
    Animator theHudAnimator;
    AudioSource audioSource;
    public AudioClip endClip;


    void Start () {
        gameEndCamera = GameObject.Find("GameCompletionCam");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        gameEndCam = gameEndCamera.GetComponent<Camera>();
        gameEndCamAudioListener = gameEndCam.GetComponent<AudioListener>();
        gameEndCamAnimation = gameEndCamera.GetComponent<Animation>();
        graveyardDataManager = GraveyardDataManager.GetInstance();
        theHudAnimator = GameObject.Find("TheHUD").GetComponent<Animator>();
        audioSource = GameObject.FindGameObjectWithTag("BackgroundSound").GetComponent<AudioSource>();

        gameEndCamAudioListener.enabled = false;
        gameEndCam.enabled = false;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainCam.enabled = false;
            gameEndCam.enabled = true;
            gameEndCamAnimation.Play();
            graveyardDataManager.Shooting = false;
            theHudAnimator.SetTrigger("GameEnded");
            audioSource.clip = endClip;
            audioSource.Play();
        }
    }

}
