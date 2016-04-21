using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	bool attackMode = false;
	int currentEnemyId = 0;
	public GameObject[] enemyObjects;

	GameObject player;

	AudioSource backgroundMusicSource;
	AudioClip backgroundMusic;






	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {

			player = col.gameObject;

			backgroundMusicSource.Play ();

			attackMode = true;

			foreach (GameObject enemyObj in enemyObjects) {

				Animator enemyAnimator = enemyObj.GetComponentInChildren<Animator> ();

				// enemies all stand up to face player
				enemyAnimator.SetBool ("isSitting", false);
				enemyAnimator.SetBool ("isKneeling", false);
				enemyAnimator.SetBool ("isWalking", false);

				enemyObj.transform.LookAt (player.transform);

			}
		}
	}


	void Start () {

		backgroundMusicSource = gameObject.GetComponent<AudioSource> ();

	
	}
	
	void Update () {

		if (attackMode) {


			//clown get ready to fight... each showing off their signature move
			//clown attack one by one
		}
	
	}
}
