using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IceBlock : ActivableObject {
    public int currentIceLevel;
    public int recoveryRate;
    public float totalLabor;
    public int labor;
    public float efficiency;
    public int cubeCost;
    public GameObject iceCube;
    public SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start ()//int currentIceLevel, int recoveryRate, int labor)
    {
        //this.currentIceLevel = currentIceLevel;
        //this.recoveryRate = recoveryRate;
        //this.labor = labor;
        iceCube = Resources.Load("Prefabs/IceCube") as GameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentIceLevel += recoveryRate;
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
        // Om player har stamina
        if (playerManager.playerStatsManager.Current_Stamina > labor)
        {
            //Remove used stamina
            playerManager.playerStatsManager.Current_Stamina -= labor;
            // SKicka in labor in i isen. 
            totalLabor += labor * efficiency;

            // Kontrollera om vi har nått max, isf skapa ny isbit, å ge till spelare. 
            if (totalLabor >  cubeCost)
            {
                //Skapa isbit
                if(iceCube != null)
                {
                    GameObject instance = Instantiate(iceCube) as GameObject;
                    instance.transform.position = transform.position;
                }
                //Ge isbit till spelare? Alternativt lägg isbit nånstans?
                //Räkna ut ny labor
                totalLabor -= cubeCost;
            }
            return 0.1f;
        }
        return 0.1f;
        // Annars, chilla (och uppdatera bar)
    }
}
