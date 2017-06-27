using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour {
    public float Max_Stamina = 100;
    public float Current_Stamina = 100;
    public float Stamina_Regen = 5;

   private void Update()
    {
        Regenerate();
    }

    //Used to regenerate player stamina
    void Regenerate()
    {
        Current_Stamina += Stamina_Regen * Time.deltaTime;
        if (Current_Stamina > Max_Stamina)
        {
            Current_Stamina = Max_Stamina;
        }
    }
}
