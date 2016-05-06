using UnityEngine;
using System.Collections;

public class GraveyardEntranceDoor {

    GameObject leftEntranceDoor;
    GameObject rightEntranceDoor;
    Animator leftEntranceDoorAnimator;
    Animator rightEntranceDoorAnimator;


    public GraveyardEntranceDoor()
    {
        leftEntranceDoor = GameObject.FindGameObjectWithTag("GraveyardLeftEntranceDoor");
        leftEntranceDoorAnimator = leftEntranceDoor.GetComponent<Animator>();

        rightEntranceDoor = GameObject.FindGameObjectWithTag("GraveyardRightEntranceDoor");
        rightEntranceDoorAnimator = rightEntranceDoor.GetComponent<Animator>();
    }

    public void Open()
    {
        leftEntranceDoorAnimator.SetBool("OpenDoor", true);
        rightEntranceDoorAnimator.SetBool("OpenDoor", true);
    }

    public void Close()
    {
        leftEntranceDoorAnimator.SetBool("OpenDoor", false);
        rightEntranceDoorAnimator.SetBool("OpenDoor", false);
    }
}
