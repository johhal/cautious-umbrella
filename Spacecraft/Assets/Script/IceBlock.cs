using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour {
    private int current_ice_level;
    private int recovery_rate;
    private int labor;

	// Use this for initialization
	void Start (int current_ice_level, int recovery_rate, int labor)
    {
        this.current_ice_level = current_ice_level;
        this.recovery_rate = recovery_rate;
        this.labor = labor;
	}
	
	// Update is called once per frame
	void Update ()
    {
        current_ice_level += recovery_rate;
	}

    private void activate_object()  // Skicka med ett mäniskoobjekt. 
    {
        // Om player har stamina
        // SKicka in labor in i isen. 
        // Kontrollera om vi har nått max, isf skapa ny isbit, å ge till spelare. 
        // Annars, chilla (och uppdatera bar)
    }
}
