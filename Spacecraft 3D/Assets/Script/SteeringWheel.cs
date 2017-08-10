using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : ActivableObject  {

    public Ship ship;

    public float labour = 1;

    public float degrees_per_second = 15;

    public Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        FreezePlayer = true;
        
        rigidBody = transform.Find("Wheel").GetComponent<Rigidbody>();
       }
	
    public override float Activate(PlayerManager playerManager)
    {
        //Check if the steering wheel is connected to a boat...
        if (ship == null)
        {
            return 0.1f;
        }
        if (playerManager.playerStatsManager.Current_Stamina >= labour)
        {
            playerManager.playerStatsManager.Current_Stamina -= labour * Time.deltaTime;
                       ship.Steer(degrees_per_second * playerManager.playerMovement.leftInputX * Time.deltaTime);
            rigidBody.MoveRotation(new Quaternion(rigidBody.rotation.x,
                                    rigidBody.rotation.y - (2 * degrees_per_second) * playerManager.playerMovement.leftInputX * Time.deltaTime,
                                    rigidBody.rotation.z,
                                    0));

        }
        return 0.1f;
    }

    public override bool FocusGained()
    {
        return base.FocusGained();
    }

    public override bool FocusLost()
    {
        return base.FocusLost();
    }
}
