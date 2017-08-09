using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : ActivableObject  {

    public Ship ship;

    public float labour = 1;

    public float degrees_per_second = 15;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;

    // Use this for initialization
    void Start () {
        FreezePlayer = true;
        spriteRenderer = transform.Find("SteeringWheelWheel").GetComponent<SpriteRenderer>();
        rigidBody = transform.Find("SteeringWheelWheel").GetComponent<Rigidbody2D>();
        if (spriteRenderer == null)
        {
            Debug.Log("Spriterenderer is null.");
        }
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
            rigidBody.MoveRotation(rigidBody.rotation - (2 * degrees_per_second) * playerManager.playerMovement.leftInputX * Time.deltaTime);
            
        }
        return 0.1f;
    }

    public override bool FocusGained()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.blue;
            return true;
        }
        return base.FocusGained();
    }

    public override bool FocusLost()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            return true;
        }
        return base.FocusLost();
    }
}
