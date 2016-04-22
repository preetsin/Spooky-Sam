using UnityEngine;
using System.Collections;

public class TopDownCamera : MonoBehaviour
{
	public GameObject player;

	
	void Start()
	{
		shiftCamera();
	}
		
	
	void Update()
	{

		//Calculate the camera movement along the X and Z axes
		float xOffset = Input.GetAxis("Horizontal") * 10.0f * Time.deltaTime;
		float zOffset = Input.GetAxis("Vertical") * 10.0f * Time.deltaTime;
		
		//If zooming in and out is enabled, calculate the Y-axis transform
		float yOffset = 0.0f;
		
		//Be sure to translate relative to world space, so our rotation has no effect
		transform.Translate(xOffset, yOffset, zOffset, Space.World);
	}

	public void shiftCamera() {
		transform.position = player.transform.position;
		transform.Translate(0, 10.0f, 0);
		transform.LookAt(player.transform.position);
	}
}
