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
	}
	
	// Update is called once per frame
	void Update () {
        playerStats.Regenerate_Stamina();
    }
}
