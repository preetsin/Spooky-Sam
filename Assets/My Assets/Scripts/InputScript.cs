using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;



public class InputScript : MonoBehaviour
{
    public bool torchOn;
    public bool inTunnel;
    public bool isAttacking;
    public int WeaponState;
    Animator anim;
    CharacterController controller;
    float speed;
    Vector3 moveDirection = Vector3.zero;
    // ========= graveyard region starts ================
    GraveyardController graveyardController;
    // ========= graveyard region ends ================


    public Image weaponIconView;
    public Sprite[] weaponIcons;


    void Start() {
        torchOn = false;
        speed = 5f;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        isAttacking = false;
        WeaponState = 0;
        inTunnel = false;

        Debug.Log("Current Scene: " + SceneManager.GetActiveScene().name);


        if (SceneManager.GetActiveScene().name.Equals("graveScene"))
        {
            graveyardController = new GraveyardController();
        }
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", move);
        transform.Rotate(0, Input.GetAxis("Mouse X") * 5f, 0);
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
        if (Input.GetKey(KeyCode.A))
        {

            anim.SetBool("StrafeLeft", true);
            controller.SimpleMove(transform.TransformDirection(Vector3.left) * 5f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("StrafeLeft", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("StrafeRight", true);
            controller.SimpleMove(transform.TransformDirection(Vector3.right) * 5f);
        }
        if (Input.GetKeyUp(KeyCode.D))
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

		if (Input.GetKeyUp (KeyCode.Escape)) {

			if (!AlertViewHandler.alertIsShowing) {
				AlertViewHandler alert = FindObjectOfType<AlertViewHandler>();
				alert.showAlert ("Are you sure you want to leave the game?\n" +
					"Game progress will not be saved\n" +
					"ENTER : Keep playing\n" +
					"Escape : Leave Game");


				if (Input.GetKeyUp (KeyCode.Escape)) {
					SceneManager.LoadScene ("MainMenu");
				}
			}
		}






        moveDirection.y -= 20 * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        // GetComponent<CharacterController>().height = 1.2f;
        //GetComponent<CharacterController>().SimpleMove(new Vector3(0, 0, 0.9f));
        //Invoke("resetController", 0.4f); 
        if (Input.GetButtonDown("Fire2") && anim.GetBool("HasTorch") == true)
        {
            if (!torchOn)
            {
                torchOn = true;
                anim.SetBool("ShiningTorch", true);
                GameObject.FindGameObjectWithTag("Torchy").GetComponent<Light>().intensity = 2;
            }
            else
            {
                torchOn = false;
                anim.SetBool("ShiningTorch", false);
                GameObject.FindGameObjectWithTag("Torchy").GetComponent<Light>().intensity = 0;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {


            isAttacking = true;
            if (anim.GetBool("HasGun") == true)
            {
                anim.SetBool("Shoot", true);
            }
            else
            {
                anim.SetTrigger("Punch");
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isAttacking = false;
            anim.SetBool("Shoot", false);
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
                controller.height = 0.4f;
                controller.center = new Vector3(0, 0.4f, 0);
            }
            else
            {
                if (!inTunnel)
                {
                    anim.SetBool("Crouch", false);
                    controller.height = 1.8f;
                    controller.center = new Vector3(0, 0.9f, 0);
                }
            }
        }


        if (Input.GetKey(KeyCode.Alpha1)) {
           
			if (SceneManager.GetActiveScene().name.Equals("houseScene"))
			{
				anim.SetBool("HasTorch", false);
				anim.SetBool("ShiningTorch", false);
            	GameObject.FindGameObjectWithTag("Torchy").GetComponent<Light>().intensity = 0;
            	GetComponent<Outfitter>().weapons[2].models[0].enabled = false;
			}
            Debug.Log(GetComponent<PlayerWeapons>().weapons);

            if (GetComponent<PlayerWeapons>().weapons.Contains(1))
            { //Hammer
                WeaponState = 1;
                GetComponent<Outfitter>().weapons[1].models[0].enabled = true;
                GetComponent<Outfitter>().weapons[2].models[0].enabled = false;
                weaponIconView.sprite = weaponIcons[0];


            }
            else if (GetComponent<PlayerWeapons>().weapons.Contains(2))
            { //Sword
                GetComponent<Outfitter>().weapons[1].models[0].enabled = false;
                GetComponent<Outfitter>().weapons[2].models[0].enabled = true;
                weaponIconView.sprite = weaponIcons[1];
				anim.SetBool ("hasSword", true);

            }
            else if (GetComponent<PlayerWeapons>().weapons.Contains(3))
            { //SpacePistol
                anim.SetBool("HasGun", true);
                GetComponent<Outfitter>().weapons[1].models[0].enabled = false;
                GetComponent<Outfitter>().weapons[2].models[0].enabled = true;
                weaponIconView.sprite = weaponIcons[2];


                if (SceneManager.GetActiveScene().name.Equals("graveScene"))
                {
                    graveyardController.EnableGunShooting(true);
                    //graveyardController.EnableCrosshair(true);
                }

            }
          


        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GetComponent<PlayerWeapons>().weapons.Contains(4))
            {
                anim.SetBool("HasTorch", true);
                GetComponent<Outfitter>().weapons[1].models[0].enabled = false;
                GetComponent<Outfitter>().weapons[2].models[0].enabled = true;
                //weaponIconView.sprite = weaponIcons[3];
            }
        
        }

    

		if (Input.GetKey(KeyCode.Alpha0))
		{
            anim.SetBool("HasTorch", false);
			GetComponent<Outfitter>().weapons[1].models[0].enabled = false;
			GetComponent<Outfitter>().weapons[2].models[0].enabled = false;
			GetComponent<Outfitter>().weapons[3].models[0].enabled = false;
			GetComponent<Outfitter>().weapons[4].models[0].enabled = false;
			GetComponent<Outfitter>().weapons[0].models[0].enabled = true;
		}





        
        if (Input.GetKey(KeyCode.F))
		{

            // ========= graveyard code starts ==============
            if (SceneManager.GetActiveScene().name.Equals("graveScene"))
            {
                graveyardController.DoorLeverToggledHandler();
            }
            if (SceneManager.GetActiveScene().name.Equals("houseScene"))
            {

                GameObject.FindGameObjectWithTag("GraveyardDoorLever").GetComponent<SecretDoor>().SecretDoorLeverToggledHandler();
            }
            // ========= graveyard region ends ============
        }




    }

    void OnTriggerEnter(Collider other)
    {
        // ========= graveyard region starts ===========
        if (SceneManager.GetActiveScene().name.Equals("graveScene"))
        {
            graveyardController.CloseToDoorLeverHandler(other, true);
        }
        if (SceneManager.GetActiveScene().name.Equals("houseScene"))
        {
            if (other.gameObject.tag == "GraveyardDoorLever")
            {
                other.gameObject.GetComponent<SecretDoor>().closeToLever = true;
            }
        }
        // ========= graveyard region ends ============
    }


    void OnTriggerExit(Collider other)
    {
        // ========= graveyard code starts ==============
        if (SceneManager.GetActiveScene().name.Equals("graveScene"))
        {
            graveyardController.CloseToDoorLeverHandler(other, false);
        }
        // ========= graveyard code ends ==============
    }

    void OnTriggerStay(Collider other) { }

    


}