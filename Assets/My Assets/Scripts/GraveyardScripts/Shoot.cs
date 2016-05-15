using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public Rigidbody bullet;
    bool buttonUp;
    public float forceSpeed;
    AudioSource gunShot;

    void Start()
    {
        gunShot = GetComponent<AudioSource>();
        buttonUp = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("Shooting", 0.001f, 0.1f);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Shooting");
        }

    }

    void Shooting()
    {
        Rigidbody instantiateBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
        instantiateBullet.velocity = transform.TransformDirection(new Vector3(0, 0, forceSpeed));
        gunShot.Play();
    }

}
