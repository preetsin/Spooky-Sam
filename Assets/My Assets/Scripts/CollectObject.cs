using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {

	int weaponId = 0;

	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Player") {
			switch (gameObject.tag) {
			case "Hammer":
				weaponId = 1;
				break;

			case "Sword":
				weaponId = 2;
				break;
          
            case "Spear":
				weaponId = 3;
                break;
        }

        Debug.Log ("Weapon ID: " + weaponId);

			col.gameObject.GetComponent<PlayerWeapons> ().setWeapons (weaponId);
			col.GetComponent<Animator> ().SetTrigger ("Pickup");
			GetComponent<MeshRenderer> ().enabled = false;

		}

	}


}
