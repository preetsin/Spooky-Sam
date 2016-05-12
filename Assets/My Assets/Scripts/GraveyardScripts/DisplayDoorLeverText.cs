using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DisplayDoorLeverText : MonoBehaviour {

	TextMesh leverText;

	void Start () 
	{
		leverText = GameObject.Find ("LeverText").GetComponent<TextMesh> ();
	}

    void OnTriggerStay()
    {

        if (SceneManager.GetActiveScene().name.Equals("graveScene"))
        {
            leverText.text = "Press 'F' to open exit door";
        }
        if (SceneManager.GetActiveScene().name.Equals("houseScene"))
        {
            leverText.text = "Press 'F' to pull lever";
        }
    }

        

	void OnTriggerEnter(Collider other)
	{
	}

	void OnTriggerExit(Collider other)
	{
		leverText.text = "";
	}


}
