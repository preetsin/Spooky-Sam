using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public Rigidbody bullet;
    public float forceSpeed;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiateBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;

            instantiateBullet.velocity = transform.TransformDirection(new Vector3(0, 0, forceSpeed));
        }
    }
}
