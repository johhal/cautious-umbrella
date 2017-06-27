﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : ActivableObject  {

    public Ship ship;

    public float labour = 1;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;

    // Use this for initialization
    void Start () {
        FreezePlayer = true;
        spriteRenderer = transform.FindChild("SteeringWheelWheel").GetComponent<SpriteRenderer>();
        rigidBody = transform.FindChild("SteeringWheelWheel").GetComponent<Rigidbody2D>();
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
            playerManager.playerStatsManager.Current_Stamina -= labour;
            ship.Steer(1 * playerManager.playerMovement.leftInputX);
            rigidBody.MoveRotation(rigidBody.rotation - 5 * playerManager.playerMovement.leftInputX);
            
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
