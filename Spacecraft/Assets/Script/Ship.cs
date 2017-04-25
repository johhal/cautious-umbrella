using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    // The ship
    public ShipMovement shipMovement;
    // For visibility only
    public double x_position;
    public double y_position;
    public double current_speed;
    public double direction;

    // Use this for initialization
    void Start () {
        shipMovement = new ShipMovement(0, 0);
	}

    // Update is called with fixed time
    private void FixedUpdate()
    {
        shipMovement.move();
        x_position = shipMovement.x_position;
        y_position = shipMovement.y_position;
        current_speed = shipMovement.current_speed;
        direction = shipMovement.direction;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
