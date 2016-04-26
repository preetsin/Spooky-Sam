using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int health;
    //Text text;
    string healthText;
    public GameObject canvas;
	// Use this for initialization
	void Awake () {
        health = 60;
	}
    void Start()
    {
        StartCoroutine(giveHealth());
    }
    
    IEnumerator giveHealth()
    {
        while (true)
        {
            addTenPercent();
            Debug.Log("Added Health");
            healthText = health.ToString();
            Text text = canvas.transform.Find("Health").GetComponent<Text>();
            text.text = healthText;
            yield return new WaitForSeconds(10);
        }
    }

    void addTenPercent()
    {
        health += (health / 10);
        health %= 100;
    }

    // Update is called once per frame
    void Update () {
	    


	}
}
