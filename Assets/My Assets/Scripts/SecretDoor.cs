using UnityEngine;
using System.Collections;

public class SecretDoor : MonoBehaviour {
    public GameObject secretDoor;
    public GameObject doorLeverPivot;
    public bool closeToLever;
    bool toggled;
	AlertViewHandler alertView;
   


	void Start(){
		alertView = FindObjectOfType<AlertViewHandler> ();

	}
    public SecretDoor() {
        closeToLever = false;
        toggled = false;
	
      
    }
     
    public void SecretDoorLeverToggledHandler()
    {
        if (closeToLever)
        {
          
            if (!toggled)
            {
                   doorLeverPivot.transform.rotation = Quaternion.Lerp(doorLeverPivot.transform.rotation, Quaternion.Euler(0, 0, 15), Time.time * 2.0f);
                  
                   GetComponent<AudioSource>().Play();
                   openSecretDoor();
				if (HouseAlertManager.Instance.leverlMessage == false) {
					alertView.showAlert ("It sounds like a secret door just opened somewhere...");
					HouseAlertManager.Instance.leverlMessage = true;
				}
           }
            //else if (doorLever.Toggled)
            //{
            //    lever.transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 9), Quaternion.Euler(0, 0, 345), Time.time * 2.0f);
              
            //    doorLever.Toggled = false;
            //}
        }
    }


    void openSecretDoor() {
       secretDoor.transform.position += new Vector3(0f,-20f,0f);

        toggled = true;
    }





    
}
