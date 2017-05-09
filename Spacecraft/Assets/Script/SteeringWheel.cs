using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : ActivableObject  {

    public ShipMovement shipMovement;

    public double turn;
	// Use this for initialization
	void Start () {
		if (shipMovement == null)
        {
            shipMovement = GetComponent<Ship>().shipMovement;
            // Obligatory Crapline delux ultra edition.
        }
	}
	
	// Update is called once per fixed frame
	void FixedUpdate () {
		if (shipMovement != null)
        {
            shipMovement.direction += (2 * System.Math.PI) / 360 * turn;
        }
	}

    public override bool Activate(float PlayerStats)
    {
        return false;
    }
}
