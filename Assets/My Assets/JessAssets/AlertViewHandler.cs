using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlertViewHandler : MonoBehaviour {
	
	public Image alertView;
	public Text alertText;
	public static bool alertIsShowing;




	// Use this for initialization
	void Start () {
		alertIsShowing = false;
		if (alertText != null) {
			alertText.enabled = false;
		}

		if (alertView != null) {
			alertView.enabled = false;
		}

	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			dismissAlert ();
		}
	}


	public void showAlert(string whatToSay) {

		if (alertText != null) {
			alertText.enabled = true;
		}

		if (alertView != null) {
			alertView.enabled = true;
		}

		alertText.text = whatToSay;
		alertIsShowing = true;

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
