using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour {
    private int currentIceLevel;
    private int recoveryRate;
    private float labor;
    private int pricePerActivation;
    private float efficieny;
    private int blockCost;

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
        currentIceLevel += recovery_rate;
	}

    private void Activate(PlayerStats playerStats)  // Skicka med ett mäniskoobjekt. 
    {
        // Om player har stamina
        if (playerStats.Stamina > pricePerActivation)
        {
            // SKicka in labor in i isen. 
            labor += pricePerActivation * efficiency;

            // Kontrollera om vi har nått max, isf skapa ny isbit, å ge till spelare. 
            if (labor >  blockCost)
            {
                //Skapa isbit
                //Ge isbit till spelare? Alternativt lägg isbit nånstans?
                //Räkna ut ny labor
                labor -= pricePerActivation;
            }
        }
        // Annars, chilla (och uppdatera bar)
    }
}
