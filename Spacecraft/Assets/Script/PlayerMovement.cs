using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool MovementEnabled = true;
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

    private bool button_a_old = false;
    private bool button_b_old = false;

    public bool button_a_down = false;
    public bool button_b_down = false;
    public bool button_a_pressed = false;
    public bool button_b_pressed = false;
    public bool moving;


    void Start ()
	{
		rigidbody2d = GetComponent<Rigidbody2D> ();
        
    }

	void FixedUpdate ()
	{
        moving = false;
		string joystickString = joystickNumber.ToString ();
        //Get input

       rightTrigger = -Input.GetAxis ("RightTrigger_P" + joystickString);
        
		currentSpeed = movementSpeed + (runningSpeed - movementSpeed) * rightTrigger;


		leftInputX = Input.GetAxis ("LeftJoystickX_P" + joystickString);
		leftInputY = -Input.GetAxis ("LeftJoystickY_P" + joystickString);

        if (MovementEnabled)
        {
            if ((leftInputX != 0) || (leftInputY != 0))
            {
                //Move player
                speed = new Vector2(leftInputX * currentSpeed, leftInputY * currentSpeed);
                rigidbody2d.MovePosition(rigidbody2d.position + speed * Time.deltaTime);
                //Rotate player
                rotation = (180 / Mathf.PI) * Mathf.Atan2(-leftInputX, leftInputY);
                transform.localEulerAngles = new Vector3(0, 0, rotation);
                if (speed != Vector2.zero )
                {
                    moving = true;
                }
            }
        }

        MovementEnabled = true;
    }

	void Update ()
	{
		string joystickString = joystickNumber.ToString ();
		//Get input
		//rightInputX = -Input.GetAxis ("RightJoystickX_P" + joystickString);
		//rightInputY = -Input.GetAxis ("RightJoystickY_P" + joystickString);

        
  //      if (MovementEnabled)
  //      {
  //          //Check if character should rotate
  //          if ((rightInputY != 0) || (rightInputX != 0))
  //          {
  //              //if ((Input.GetAxis ("RightJoystickX") != 0) && (Input.GetAxis ("RightJoystickY") != 0)) {
  //              rotation = (180 / Mathf.PI) * Mathf.Atan2(rightInputX, rightInputY);
  //              //}
  //              transform.localEulerAngles = new Vector3(0, 0, rotation);
  //          }
  //      }

        button_a_down = Input.GetButton("A_P" + joystickString);
        button_b_down = Input.GetButton("B_P" + joystickString);

        if(button_a_down && !button_a_old)
        {
            button_a_pressed = true;
        }
        else
        {
            button_a_pressed = false;
        }

        if (button_b_down && !button_b_old)
        {
            button_b_pressed = true;
        }
        else
        {
            button_b_pressed = false;
        }

        button_a_old = button_a_down;
        button_b_old = button_b_down;
        //characterController.Move (movementVector * Time.deltaTime);

    }
 }