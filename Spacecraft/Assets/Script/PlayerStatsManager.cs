using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour {
    public float Max_Stamina = 100;
    public float Current_Stamina = 100;
    public float Stamina_Regen = 1;

    public PlayerStats playerStats;
	// Use this for initialization
	void Start () {
        playerStats = new PlayerStats(Max_Stamina, Current_Stamina, Stamina_Regen);
        InvokeRepeating("Regenerate", 1.0f, 0.1f);
    }

    //Used to regenerate player stamina
    void Regenerate()
    {
        playerStats.Regenerate_Stamina();
    }
}
