using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Vector3 movementVector;
	private CharacterController characterController;
	private Rigidbody2D rigidbody2d;
	public Vector2 speed;
	public float runningSpeed = 15;
	public float movementSpeed = 7;
	public float currentSpeed = 0;
	public float rotation = 0;
	public float rightInputY = 0;
	public float rightInputX = 0;
	public float leftInputY = 0;
	public float leftInputX = 0;
	public int joystickNumber = 2;
	public float rightTrigger = 0;

	void Start ()
	{
		rigidbody2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		string joystickString = joystickNumber.ToString ();
		//Get input

		rightTrigger = -Input.GetAxis ("RightTrigger_P" + joystickString);


		currentSpeed = movementSpeed + (runningSpeed - movementSpeed) * rightTrigger;


		leftInputX = Input.GetAxis ("LeftJoystickX_P" + joystickString) * currentSpeed;
		leftInputY = -Input.GetAxis ("LeftJoystickY_P" + joystickString) * currentSpeed;
		if ((leftInputX != 0) || (leftInputY != 0)) {
			speed = new Vector2 (leftInputX, leftInputY);
			rigidbody2d.MovePosition (rigidbody2d.position + speed * Time.deltaTime);
		}
	}

	void Update ()
	{
		string joystickString = joystickNumber.ToString ();
		//Get input
		rightInputX = -Input.GetAxis ("RightJoystickX_P" + joystickString);
		rightInputY = -Input.GetAxis ("RightJoystickY_P" + joystickString);


		//Check if character should rotate
		if ((rightInputY != 0) || (rightInputX != 0)) {
			//if ((Input.GetAxis ("RightJoystickX") != 0) && (Input.GetAxis ("RightJoystickY") != 0)) {
			rotation = (180 / Mathf.PI) * Mathf.Atan2 (rightInputX, rightInputY);
			//}
			transform.localEulerAngles = new Vector3 (0, 0, rotation);
		}

		//characterController.Move (movementVector * Time.deltaTime);

	}


}