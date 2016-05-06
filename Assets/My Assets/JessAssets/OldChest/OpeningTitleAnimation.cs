using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OpeningTitleAnimation : MonoBehaviour {


	private RawImage openingTitleImage;
	private int timer;
	private float alphaStart = 1.0f;
	private float alphaFinish = 0.0f;


	// Use this for initialization
	void Start () {

		openingTitleImage = GetComponent<RawImage> ();
		timer = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		timer++;

		 if (timer == 120) {
			openingTitleImage.CrossFadeColor (Color.black, 5.0f, false, false);
		} else if (timer == 500) {
			SceneManager.LoadScene ("MainMenu");
		}




	
	}
}
