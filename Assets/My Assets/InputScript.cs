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
    Vector3 moveDirection = Vector3.zero;
    // ========= graveyard region starts ================
    GraveyardController graveyardController;
    // ========= graveyard region ends ================


    void Start() {
        speed = 5f;
         anim = GetComponent< Animator > ();
        controller = GetComponent<CharacterController>();
        isAttacking = false;
        WeaponState = 0;


        // ========= graveyard region starts ================
        graveyardController = new GraveyardController();
        // ========= graveyard region ends ================

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
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            anim.SetTrigger("Jump");
            moveDirection.y = 10f;


        }


        moveDirection.y -= 20 * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    
    // GetComponent<CharacterController>().height = 1.2f;
    //GetComponent<CharacterController>().SimpleMove(new Vector3(0, 0, 0.9f));
    //Invoke("resetController", 0.4f); 



      

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
                controller.height = 0.4f;
                controller.center = new Vector3(0,0.4f,0);
            }
            else
            {
                anim.SetBool("Crouch", false);
                controller.height = 1.8f;
                controller.center = new Vector3(0, 0.9f, 0);
            }
        }


		if (Input.GetKey(KeyCode.Alpha1)) {

			Debug.Log (GetComponent<PlayerWeapons> ().weapons);

			if (GetComponent<PlayerWeapons> ().weapons.Contains (1)) { //Hammer
				
				GetComponent<Outfitter>().weapons[1].models[0].enabled = true;
				GetComponent<Outfitter>().weapons[2].models[0].enabled = false;

			} else if (GetComponent<PlayerWeapons> ().weapons.Contains (2)) { //Sword
				GetComponent<Outfitter>().weapons[1].models[0].enabled = false;
				GetComponent<Outfitter>().weapons[2].models[0].enabled = true;

			} else if (GetComponent<PlayerWeapons>().weapons.Contains (3)) { //Rifle or Spear
                GetComponent<Outfitter>().weapons[1].models[0].enabled = false;
                GetComponent<Outfitter>().weapons[2].models[0].enabled = true;
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





        
        if (Input.GetKey(KeyCode.F))
		{
            // ========= graveyard code starts ==============
            graveyardController.DoorLeverToggledHandler();
            // ========= graveyard region ends ============
        }




    }

    void OnTriggerEnter(Collider other)
    {
        // ========= graveyard region starts ===========
        graveyardController.CloseToDoorLeverHandler(other, true);
        // ========= graveyard region ends ============
    }


    void OnTriggerExit(Collider other)
    {
        // ========= graveyard code starts ==============
        graveyardController.CloseToDoorLeverHandler(other, false);
        // ========= graveyard code ends ==============
    }

    void OnTriggerStay(Collider other) { }

    


}