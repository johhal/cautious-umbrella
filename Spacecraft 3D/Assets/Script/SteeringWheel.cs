using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : ActivableObject  {

    public Ship ship;

    public float labour = 1;

    public float degrees_per_second = 15;

    public Rigidbody rigidBody;

    public float rotationVelocity = 50.0f;

    // Use this for initialization
    void Start () {
        FreezePlayer = true;
        
        //rigidBody = transform.Find("Wheel").GetComponent<Rigidbody>();
       }
	
    public override float Activate(PlayerManager playerManager)
    {
        
        //Check if the steering wheel is connected to a boat...
        if (ship == null)
        {
           return 0.1f;
        }
        //Check if player is indeed trying to steer the ship
        if (playerManager.playerMovement.leftInputX != 0)
        {
            if (playerManager.playerStatsManager.Current_Stamina >= labour)
            {
            
                //playerManager.playerStatsManager.Current_Stamina -= labour * Time.deltaTime;
                ship.Steer(degrees_per_second * playerManager.playerMovement.leftInputX * Time.deltaTime);
                //rigidBody.MoveRotation(new Quaternion(rigidBody.rotation.x,
                //                        rigidBody.rotation.y - (2 * degrees_per_second) * playerManager.playerMovement.leftInputX * Time.deltaTime,
                //                        rigidBody.rotation.z,
                //                        0));
                //float v = playerManager.playerMovement.leftInputX * rotationVelocity * Time.deltaTime;
                //rigidBody.AddTorque(transform.up * v);
                rigidBody.transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotationVelocity * playerManager.playerMovement.leftInputX);
            }
            else
            {
                Debug.Log("CUrrent stamina: " + playerManager.playerStatsManager.Current_Stamina + ", Labour: " + labour);
              }
        }
        
        return 0.0f;
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
