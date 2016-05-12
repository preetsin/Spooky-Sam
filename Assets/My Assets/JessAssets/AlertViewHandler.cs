using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlertViewHandler : MonoBehaviour {
	
	public Image alertView;
	public Text alertText;
	public static bool alertIsShowing;
	private ArrayList alertQueue;
	int cursor;




	// Use this for initialization
	void Start () {
		alertQueue = new ArrayList ();
		cursor = 0;

		alertIsShowing = false;
		if (alertText != null) {
			alertText.enabled = false;
		}

		if (alertView != null) {
			alertView.enabled = false;
		}

	}




    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Return)) {

			if (cursor < alertQueue.Count) {
				//show next alert in queue
				Debug.Log("getting next in queue");
				string nextInQueue = (string) alertQueue [cursor];
				alertIsShowing = false;
				showAlert (nextInQueue);
				cursor++;
			} else {
				dismissAlert ();
                Time.timeScale = 1;
			}

		}
	}


	public void showAlert(string whatToSay) {
		if (!alertIsShowing) {
			if (alertText != null) {
				alertText.enabled = true;
			}

			if (alertView != null) {
				alertView.enabled = true;
			}
			alertText.text = whatToSay;
			alertIsShowing = true;
		} else {
			//make so only adds if it is not already in queue... nod ouble-ups
			Debug.Log ("Add to queue: " + whatToSay);
			alertQueue.Add (whatToSay);
		}




	}

	public void dismissAlert() {
		Debug.Log ("Alert Dismissed");
		alertIsShowing = false;

		if (alertText != null) {
			alertText.enabled = false;
		}

		if (alertView != null) {
			alertView.enabled = false;
		}


	}
}
