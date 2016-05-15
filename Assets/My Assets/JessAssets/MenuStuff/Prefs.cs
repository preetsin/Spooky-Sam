using UnityEngine;
using System.Collections;

public class Prefs : MonoBehaviour {
    public static int lastHealth = 50;
    public static int playerHealth = 50;

    void Start() {
        lastHealth = playerHealth;
    }

    void Update() {
        lastHealth = playerHealth;
    }

}
