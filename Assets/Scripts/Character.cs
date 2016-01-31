using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	//movement variables
	public CharacterController character;
	public Camera view;
	protected Vector3 moveDirection;
	public float speed = 15f;
	public float sprintSpeed = 7.5f;
	public float cameraXSensitivity = 10f;
	public float cameraYSensitivity = 10f;
	protected Vector3 cameraRotation;
	public float jumpSpeed = 10f;
	public float gravity = 9.8f;
	protected bool isSprinting = false;
    public float runCost = 1.0f;
    public AudioSource walking, running, current;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
        if (isSprinting)
        {
            gameObject.GetComponent<Stats>().StaminaUse(runCost);
        }
	}
	private void Movement()
	{
		//sprint
		if (Input.GetKeyDown (KeyCode.LeftShift) && Input.GetAxis("Forward") > 0 && !isSprinting) {
            current = running;
			speed += sprintSpeed;
			isSprinting = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift) && isSprinting || Input.GetAxis ("Forward") <= 0 && isSprinting) {
			speed -= sprintSpeed;
            current = walking;
			isSprinting = false;
		}
		//movement
		if (character.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Right"), 0, Input.GetAxis("Forward"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			//current.Play ();
			//jump
			if (Input.GetButton("Jump")){
				moveDirection.y = jumpSpeed;
			}
			
		}

		//quick audio fix for walking
		if (Input.GetKeyDown (KeyCode.W))
			walking.Play ();
		else if (Input.GetKeyUp (KeyCode.W))
			walking.Stop ();
		
		//camera / player rotation
		transform.Rotate (new Vector3 (0, Input.GetAxis ("MouseX") * cameraXSensitivity * Time.deltaTime, 0));
		view.transform.Rotate (new Vector3 (-Input.GetAxis ("MouseY") * cameraYSensitivity * Time.deltaTime, 0, 0));
		//gravity
		moveDirection.y -= gravity * Time.deltaTime;
		//finally telling the character to move.
		character.Move(moveDirection * Time.deltaTime);
	}
}
