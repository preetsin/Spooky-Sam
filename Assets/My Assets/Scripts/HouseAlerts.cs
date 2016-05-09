using UnityEngine;
using System.Collections;

public class HouseAlerts : MonoBehaviour {

   
    AlertViewHandler alertView;
  
    
    // Use this for initialization
	void Start () {
        alertView = FindObjectOfType<AlertViewHandler>();
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && this.gameObject.name == "Tunnel_Grate") {
            if (HouseAlertManager.Instance.grateMsg1 ==  false) {
                alertView.showAlert("The grate looks damaged. Find something to smash it");
                HouseAlertManager.Instance.grateMsg1 = true;
            }
        }
    }


}
