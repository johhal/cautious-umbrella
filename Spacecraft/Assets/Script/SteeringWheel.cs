using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : ActivableObject  {

    public Ship ship;

    public float labour = 5;
    public double turn;
	// Use this for initialization
	void Start () {
		if (ship == null)
        {
            ship = GetComponent<Ship>();
            // Obligatory Crapline delux ultra edition.
        }
	}
	
    public override bool Activate(PlayerStats playerStats)
    {
        //Check if the steering wheel is connected to a boat...
        if (ship == null)
        {
            return false;
        }
        if (playerStats.Current_Stamina >= labour)
        {
            playerStats.Current_Stamina -= labour;
            ship.direction += (2 * System.Math.PI) / 360 * turn;
            transform.Rotate(Vector3.forward * 2);
        }
        return false;
    }
}
