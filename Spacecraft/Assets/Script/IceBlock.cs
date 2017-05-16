using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IceBlock : ActivableObject {
    public int currentIceLevel;
    public int recoveryRate;
    public float labor;
    public int pricePerActivation;
    public float efficiency;
    public int cubeCost;

    // Use this for initialization
    void Start ()//int currentIceLevel, int recoveryRate, int labor)
    {
        //this.currentIceLevel = currentIceLevel;
        //this.recoveryRate = recoveryRate;
        //this.labor = labor;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentIceLevel += recoveryRate;
	}

    public override float Activate(PlayerStats playerStats)  // Skicka med ett mäniskoobjekt. 
    {
        // Om player har stamina
        if (playerStats.Current_Stamina > pricePerActivation)
        {
            // SKicka in labor in i isen. 
            labor += pricePerActivation * efficiency;

            // Kontrollera om vi har nått max, isf skapa ny isbit, å ge till spelare. 
            if (labor >  cubeCost)
            {
                //Skapa isbit
                GameObject iceCube = new GameObject();
                GameObject.Instantiate(iceCube, transform.position, transform.rotation); //Lägger till...nånting...
                //GameObject instance = Instantiate(Resources.Load("IceCube"), transform) as GameObject;

                //Ge isbit till spelare? Alternativt lägg isbit nånstans?
                //Räkna ut ny labor
                labor -= pricePerActivation;
            }
            return 0.1f;
        }
        return 0.1f;
        // Annars, chilla (och uppdatera bar)
    }
}
