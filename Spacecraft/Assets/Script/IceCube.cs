using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : CarriableObject
{
    public SpriteRenderer spriteRenderer;
    public float currentIceLevel = 100;
    public float decreaseRate = 1;

    public GameObject carryingPlayer;
    // Use this for initialization
    void Start()//int currentIceLevel, int recoveryRate, int labor)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("DecreaseIceLevel", 1.0f, 0.1f);
    }

    //Used to regenerate player stamina
    void DecreaseIceLevel()
    {
        currentIceLevel -= decreaseRate;
        if(currentIceLevel < 0)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update () {
		//if (carryingPlayer != null)
  //      {
  //          transform.position  = carryingPlayer.transform.position;
  //      }
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

    public override float Activate(PlayerManager playerManager)  // Skicka med ett mäniskoobjekt. 
    {
        Debug.Log("IceCube - Activate");
       if (playerManager.carryManager.IsCarrying())
        {
            Debug.Log("IceCube - Carrymanager is carrying..");
            return 0.1f;
        }

       //Check if the carrymanager could pick me up...
        if (playerManager.carryManager.PickMeUp(this))
        {
            Debug.Log("IceCube - CarryManager Picked me up");
            return 1;
        }
        else
        {
            Debug.Log("IceCube - CarryManager did not pick me up");
            return 0.1f;
        }
               
    }
    public override bool pickUp(PlayerManager playerManager)
    {
        return true;
    }
    
    public override bool drop()
    {
        return false;
    }
}
