using UnityEngine;
using System.Collections;

public class GraveyardDataManager  {

    private static GraveyardDataManager graveyardDataManager = null;
    private GraveyardDataManager() { }

    public static GraveyardDataManager GetInstance()
    {
        // YODA Expression
        if (null == graveyardDataManager)
        {
            graveyardDataManager = new GraveyardDataManager();
        }

        return graveyardDataManager;
    }

    public bool OutsideSingleDoorBroken { get; set; }
    public bool InsideSingleDoorBroken { get; set; }
    public bool ExitDoorLeverToggled { get; set; }
    public bool EnemiesKilled { get; set; }
}
