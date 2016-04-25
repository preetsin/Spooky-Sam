using UnityEngine;
using System.Collections;

public class DoorLever
{
    public DoorLever()
    {
        Toggled = false;
        CloseToDoorLever = false;
        DelayTime = 0.15f;
    }

    public bool Toggled { get; set; }
    public bool CloseToDoorLever { get; set; }
    public float DelayTime { get; set; }
}
