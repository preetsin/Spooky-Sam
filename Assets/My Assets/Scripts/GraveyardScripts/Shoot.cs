using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    GraveyardDataManager graveyardDataManager;
    public Rigidbody bullet;
    public float forceSpeed;
    AudioSource gunShot;

    void Start()
    {
        graveyardDataManager = GraveyardDataManager.GetInstance();
        graveyardDataManager.Shooting = true;
        gunShot = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && graveyardDataManager.Shooting)
        {
            InvokeRepeating("ShootBullet", 0.1f, 0.2f); 
        }

        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("ShootBullet");
        }

    }

    void ShootBullet()
    {
        Rigidbody instantiateBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
        instantiateBullet.velocity = transform.TransformDirection(new Vector3(0, 0, forceSpeed));
        gunShot.Play();
    }

}
