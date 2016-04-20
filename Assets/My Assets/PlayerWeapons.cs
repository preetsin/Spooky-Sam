using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeapons : MonoBehaviour {

    public List<int> weapons;

    void Awake() {
        weapons = new List<int>();
    }

    public void setWeapons(int i) {
        weapons.Add(i);
    }
}
