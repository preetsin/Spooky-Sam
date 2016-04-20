using UnityEngine;
using System.Collections;

public class clownWalk : MonoBehaviour {

	public GameObject[] destinations;
	int currDestinationId;
	NavMeshAgent clown;
	GameObject currObj;



	void Start () {

		currDestinationId = 0;
		clown = GetComponent<NavMeshAgent>();

		GameObject currObj = destinations [currDestinationId];
		clown.destination = currObj.transform.position; 

		GetComponent<Animator> ().SetBool ("isWalking", true);

		currObj = destinations[currDestinationId];

	}




	void Update () {


//		clown.transform.rotation = Quaternion.Euler(0, 0, 0);

		if (clown.destination == clown.transform.position) {

			GetComponent<Animator> ().SetBool ("isWalking", false);

			currDestinationId++;


			if (currDestinationId < destinations.Length) {
				
				currObj = destinations [currDestinationId];

			} else {
				
				currDestinationId = 0;

			}

			currObj = destinations [currDestinationId];
			clown.destination = currObj.transform.position; 
			GetComponent<Animator> ().SetBool ("isWalking", true);
		
		}
			
	}
}
