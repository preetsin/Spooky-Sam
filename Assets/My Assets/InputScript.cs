using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;



public class InputScript : MonoBehaviour
{

    public bool isAttacking;
    public int WeaponState;
    Animator anim;
    CharacterController controller;
    float speed;

	// ========= For graveyard ==============
	bool isOpen;
	// ========= For graveyard end ==============


    void Start() {
        speed = 5f;
         anim = GetComponent< Animator > ();
        controller = GetComponent<CharacterController>();
        isAttacking = false;
        WeaponState = 0;


		// ========= For graveyard ==============
		isOpen = false;
		// ========= For graveyard end ==============

    }

    void Update()
    {
        float move = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", move);
        transform.Rotate(0, Input.GetAxis("Horizontal") * 5f, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if (move < 0)
        {
            forward = transform.TransformDirection(Vector3.back);
        }

        float curSpeed = move * Input.GetAxis("Vertical") * speed;
        controller.SimpleMove(forward * curSpeed);

        if (Input.GetButton("Fire3"))
        {
            anim.SetBool("Run", true);
            speed = 10f;

        }
        if (Input.GetKey(KeyCode.Q))
        {
          
            anim.SetBool("StrafeLeft", true);
            controller.SimpleMove(transform.TransformDirection(Vector3.left) * 5f);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetBool("StrafeLeft", false);
        }
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("StrafeRight", true);
            controller.SimpleMove(transform.TransformDirection(Vector3.right) * 5f);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("StrafeRight", false);
        }
        if (Input.GetButtonUp("Fire3"))
        {
            anim.SetBool("Run", false);
            speed = 3f;

        }
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jump");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            isAttacking = true;
            anim.SetTrigger("Punch");
            
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isAttacking = false;
          

        }
        if (Input.GetKey(KeyCode.C))
        {
            if (anim.GetBool("Crouch") == false)
            {
                anim.SetBool("Crouch", true);
                GetComponent<CharacterController>().height = 0.4f;
                GetComponent<CharacterController>().center = new Vector3(0,0.4f,0);
            }
            else
            {
                anim.SetBool("Crouch", false);
            }
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (GetComponent<PlayerWeapons>().weapons.Contains(1))
            {
                WeaponState = 1;
                GetComponent<Outfitter>().weapons[1].models[0].enabled = true;
            }
        }
        if (Input.GetKey(KeyCode.Alpha0))
        {
            GetComponent<Outfitter>().weapons[1].models[0].enabled = false;
            GetComponent<Outfitter>().weapons[2].models[0].enabled = false;
            GetComponent<Outfitter>().weapons[3].models[0].enabled = false;
            GetComponent<Outfitter>().weapons[4].models[0].enabled = false;
            GetComponent<Outfitter>().weapons[0].models[0].enabled = true;
        }



		if (Input.GetKey (KeyCode.F)) 
		{
			GameObject lever = GameObject.Find ("LeverPivot");
			if (!isOpen) 
			{
				isOpen = true;
				//GameObject.Find ("LeverPivot").transform.Rotate (new Vector3 (0, 0, 9) * Time.deltaTime * 5.0f);
				lever.transform.rotation = Quaternion.Lerp(lever.transform.rotation, Quaternion.Euler (0, 0, 9), Time.time * 2.0f);

			}
			else if (isOpen) 
			{
				isOpen = false;
				//GameObject.Find ("LeverPivot").transform.Rotate (new Vector3 (0, 0, -9) * Time.deltaTime * 5.0f);
				lever.transform.rotation = Quaternion.Lerp(Quaternion.Euler (0, 0, 9), Quaternion.Euler (0, 0, 351), Time.time * 2.0f);

			}

		}


    

	}

}