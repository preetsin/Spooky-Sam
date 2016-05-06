using UnityEngine;
using System.Collections;

public class GraveyardExitDoor
{

    GameObject leftExitDoor;
    GameObject rightExitDoor;
    Animator leftExitDoorAnimator;
    Animator rightExitDoorAnimator;


    public GraveyardExitDoor()
    {
        leftExitDoor = GameObject.FindGameObjectWithTag("GraveyardLeftExitDoor");
        leftExitDoorAnimator = leftExitDoor.GetComponent<Animator>();

        rightExitDoor = GameObject.FindGameObjectWithTag("GraveyardRightExitDoor");
        rightExitDoorAnimator = rightExitDoor.GetComponent<Animator>();
    }

    public void Open()
    {
        leftExitDoorAnimator.SetBool("OpenDoor", true);
        rightExitDoorAnimator.SetBool("OpenDoor", true);
    }

    public void Close()
    {
        leftExitDoorAnimator.SetBool("OpenDoor", false);
        rightExitDoorAnimator.SetBool("OpenDoor", false);
    }


}
