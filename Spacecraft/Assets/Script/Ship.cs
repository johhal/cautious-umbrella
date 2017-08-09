using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    // Keep track of ships speed and movement
    //Current x position
    public double x_position;
    //Current y position
    public double y_position;
    //Current velocity
    public double current_speed;
    //Current travel direction
    public double direction;
    //Drag. Depends on boat size
    public double drag = 0.1;
    //Current acceleration
    public double acceleration = 0;
    //Current rotation
    public double rotation = 0;
    //Max rotation in each direction.
    public double max_rotation = 40;
    //Efficiency of the rudder
    public double stear_efficiency = 0.1;
    //Rudder drag
    public double rudder_drag = 0.2;
    //Used to convert 
    private double DegreeToRad =(2 * Mathf.PI) / 360;
    //Min rotation allowed before set to zero
    public double MinMovementValue = 0.01;
       
    // Use this for initialization
    void Start () {
        x_position= 0;
        y_position = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        //Calculate the speed from the current acceleration.
        current_speed += Time.deltaTime * acceleration;
        //Deaccelerate due to boat size and current speed
        if (current_speed < MinMovementValue)
        {
            current_speed = 0;
        }
        else
        {
            current_speed -= (current_speed * drag * Time.deltaTime);
        }
        
        //Calculate the new direction
        direction += (rotation * stear_efficiency) * Time.deltaTime;
        
        //Decrease rotation. If rotation < min_rotation set it to zero
        if (Mathf.Abs((float) rotation) < MinMovementValue)
        {
            rotation = 0;
        }
        else
        {
            rotation -= rotation * rudder_drag * Time.deltaTime;
        }
        //Calculate new position
        Move();

        //Change the ship sprite direction
        Animate();
    }

    public void Animate()
    {
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = (float) direction;
        transform.rotation = Quaternion.Euler(rotationVector);
        //gameObject.transform.rotation = new Quaternion(0,0, (float) (DegreeToRad * direction),0);
    }

    //Used to change the rotation of the rudder.
    public void Steer(double change_in_rotation)
    {
        Debug.Log("Steer, change_in_rotation: " + change_in_rotation);
        //Debug.Log("Steer, max_rotation: " + max_rotation);
        rotation += change_in_rotation;
        if (rotation > max_rotation)
        {
            rotation = max_rotation;
        }
        else if (rotation < -max_rotation)
        {
            rotation = -max_rotation;
        }
        //Debug.Log("Steer, rotation: " + rotation);
    }

    private void Move()
    {
        //x-axel arccos
        x_position = x_position + System.Math.Cos(DegreeToRad * direction) * current_speed * Time.deltaTime;

        //y-axel arcsin
        y_position = y_position + System.Math.Sin(DegreeToRad * direction) * current_speed * Time.deltaTime;
    }
}
