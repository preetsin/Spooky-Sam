using UnityEngine;
using System.Collections;

public class HouseAlerts : MonoBehaviour {

   
    AlertViewHandler alertView;
  
    
    // Use this for initialization
	void Start () {
        alertView = FindObjectOfType<AlertViewHandler>();

        alertView.showAlert("You awake in the house.  There’s a chill in your bones and something seems not quite right!");
        alertView.showAlert("You must discover the secrets that lie within if you wish to survive.");
        alertView.showAlert("Find your way to freedom");
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player" && this.gameObject.name == "Tunnel_Grate"){
            if (HouseAlertManager.Instance.grateMsg1 == false){
                if (other.gameObject.GetComponent<PlayerWeapons>().hasWeapon(1)){
                    alertView.showAlert("This grate looks weak. See f you can smash it open with your hammer");
                }else{
                    alertView.showAlert("The grate looks damaged. Find something to smash it");
                }
                Time.timeScale = 0.0f;
                HouseAlertManager.Instance.grateMsg1 = true;
            }
        }
    }


}
