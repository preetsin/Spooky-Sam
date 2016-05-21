using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {

	int weaponId = 0;
    HouseAlertManager manager;
    AlertViewHandler alert;

    void Awake() {
        manager = HouseAlertManager.Instance;
        alert = FindObjectOfType<AlertViewHandler>();
    }
    void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			switch (gameObject.tag) {
			case "Hammer":
				weaponId = 1;
                manager.grateMsg1 = false;
                break;
            case "Torch":
                weaponId = 4;
                gameObject.transform.Find("TorchHead").GetComponent<MeshRenderer>().enabled = false;
                    if (manager.lightMsg == false)
                    {
                        alert.showAlert("Let there be light! Press '2' to to select flashlight and RMB to use.");
//                        Time.timeScale = 0.0f;
                        manager.lightMsg = true;
                    }
                break;
            case "Sword":
				weaponId = 2;
				alert.showAlert("A sword is rather useless if you don't use it...\n Hit '1' to arm yourself with the sword");

				break;
          
            case "SpacePistol":
				weaponId = 3;
                break;
        }

        Debug.Log ("Weapon ID: " + weaponId);

			col.gameObject.GetComponent<PlayerWeapons> ().setWeapons (weaponId);
			col.GetComponent<Animator> ().SetTrigger ("Pickup");
			GetComponent<MeshRenderer> ().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            

		}

	}


}
